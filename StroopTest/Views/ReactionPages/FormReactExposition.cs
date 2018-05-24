using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Controllers;
using TestPlatform.Models;

namespace TestPlatform.Views
{
    public partial class FormReactExposition : Form
    {
        ReactionTest executingTest = new ReactionTest();
        private string path = Global.reactionTestFilesPath;                           
        private string outputDataPath = Global.reactionTestFilesPath + Global.resultsFolderName;

        private static int IMAGE = 0;
        private static int WORD = 1;

        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private string outputFile;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        
        private int intervalElapsedTime;
        private int intervalShouldBe;
        private long expositionAccumulative;
        private Stopwatch hitStopWatch = new Stopwatch();
        private Stopwatch accumulativeStopWatch = new Stopwatch();
        private bool intervalCancelled;
        private bool cancelExposition = false;

        private string[] imagesList = null;
        private string[] wordsList = null;
        private string[] audioList = null;
        private string[] colorsList = null;

        private int imageCounter = 0;
        private int wordCounter = 0;
        private int colorCounter = 0;
        private int audioCounter = 0;

        private PictureBox imgPictureBox = new PictureBox();
        private System.Windows.Forms.Label wordLabel = new System.Windows.Forms.Label();

        private bool exposing = false;
        private string[] currentStimuli = {"-", "-" };
        private string[] currentLists = { "-", "-" };
        private int currentPosition;
        private string currentPositionOutput;
        private bool currentBeep = false;
        private string currentColor = "false";
        private int currentExposition = 0;

        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        private int lastType = 1;
        private Control currentControl = null;
        private SoundPlayer Player = new SoundPlayer();

        public FormReactExposition(string prgName, string participantName, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            ExpositionController.formSecondScreen(this);
            InitializeComponent();
            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.setProgramInUse(path + "/prg/", prgName);
            executingTest.Mark = mark;
            
            outputFile = outputDataPath + executingTest.ParticipantName + "_" + executingTest.ProgramInUse.ProgramName + ".txt";
            startExposition();
            this.ShowDialog();
        }


        private void startExposition()
        {
            if (executingTest.ProgramInUse.Ready(path))
            {
                initializeExposition();
            }
            else
            {
                if (!executingTest.ProgramInUse.Exists(path))
                {
                    throw new Exception(LocRM.GetString("file", currentCulture) + executingTest.ProgramInUse.ProgramName + ".prg" +
                                    LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(path + "/prg/"));
                }
                else if (executingTest.ProgramInUse.NeedsEdition)
                {
                    repairProgram();
                }

                else
                {
                    // do nothing
                }
                
            }
        }


        private void loadLists()
        {
            switch (executingTest.ProgramInUse.ExpositionType)
            {
                case "shapes":
                    if(executingTest.ProgramInUse.StimulusColor == "false") //if stimulusColor is false then there exists a color list
                    { 
                        colorsList = executingTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    }
                    else //if stimulusColor isn't false then there is no color list
                    {
                       colorsList = new string[] { executingTest.ProgramInUse.StimulusColor };
                    }
                    colorsList = ExpositionController.ShuffleArray(colorsList, executingTest.ProgramInUse.NumExpositions, 3);
                    break;
                case "images":
                    imagesList = executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();

                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        imagesList = ExpositionController.ShuffleArray(imagesList, executingTest.ProgramInUse.NumExpositions, 3);
                    }
                    break;
                case "words":
                    wordsList = executingTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                    if(executingTest.ProgramInUse.StimulusColor == "false") //if stimulusColor is false then there exists a color list
                    { 
                        colorsList = executingTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    }
                    else //if stimulusColor isn't false then there is no color list
                    {
                       colorsList = new string[] { executingTest.ProgramInUse.StimulusColor };
                    }
                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        wordsList = ExpositionController.ShuffleArray(wordsList, executingTest.ProgramInUse.NumExpositions, 9);
                        colorsList = ExpositionController.ShuffleArray(colorsList, executingTest.ProgramInUse.NumExpositions, 3);
                    }
                    break;
                case "imageAndWord":

                    wordsList = executingTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                    imagesList = executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();
                    if (executingTest.ProgramInUse.StimulusColor == "false") //if stimulusColor is false then there exists a color list
                    {
                        colorsList = executingTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    }
                    else //if stimulusColor isn't false then there is no color list
                    {
                        colorsList = new string[] { executingTest.ProgramInUse.StimulusColor };
                    }
                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        Random rnd = new Random(DateTime.Now.Millisecond);
                        wordsList = ExpositionController.ShuffleArray(wordsList, wordsList.Length, 9);
                        imagesList = ExpositionController.ShuffleArray(imagesList, wordsList.Length, 10);
                        colorsList = ExpositionController.ShuffleArray(colorsList, executingTest.ProgramInUse.NumExpositions, 3);
                    }
                    break;
                case "wordWithAudio":
                    wordsList = executingTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                    audioList = executingTest.ProgramInUse.getAudioListFile().ListContent.ToArray();
                    if (executingTest.ProgramInUse.StimulusColor == "false") //if stimulusColor is false then there exists a color list
                    {
                        colorsList = executingTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    }
                    else //if stimulusColor isn't false then there is no color list
                    {
                        colorsList = new string[] { executingTest.ProgramInUse.StimulusColor };
                    }
                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        wordsList = ExpositionController.ShuffleArray(wordsList, executingTest.ProgramInUse.NumExpositions, 9);
                        colorsList = ExpositionController.ShuffleArray(colorsList, executingTest.ProgramInUse.NumExpositions, 3);
                        audioList = ExpositionController.ShuffleArray(wordsList, executingTest.ProgramInUse.NumExpositions, 9);
                    }
                    break;
                case "imageWithAudio":
                    imagesList = executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();
                    audioList = executingTest.ProgramInUse.getAudioListFile().ListContent.ToArray();
                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        imagesList = ExpositionController.ShuffleArray(imagesList, executingTest.ProgramInUse.NumExpositions, 3);
                        audioList = ExpositionController.ShuffleArray(wordsList, executingTest.ProgramInUse.NumExpositions, 9);
                    }
                    break;
            }
        }


        private async void initializeExposition()
        {
            loadLists();
            await exposition();
        }


        private async Task exposition()
        {
            cancellationTokenSource = new CancellationTokenSource();
            await showInstructions(executingTest.ProgramInUse, cancellationTokenSource.Token);
            changeBackgroundColor();

            await Task.Delay(executingTest.ProgramInUse.IntervalTime, cancellationTokenSource.Token);
            startingIntervalBwWorker();
        }


        private void changeBackgroundColor()
        {
            if (executingTest.ProgramInUse.BackgroundColor.ToLower() != "false")
            {
                this.BackColor = ColorTranslator.FromHtml(executingTest.ProgramInUse.BackgroundColor);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private void startingIntervalBwWorker()
        {
            if (intervalBW.IsBusy != true)
            {
                intervalBW.RunWorkerAsync();
            }
        }

        // show participant instructions to execute during test
        private async Task showInstructions(ReactionProgram program, CancellationToken token)
        {
            if (program.InstructionText != null)
            {
                instructionLabel.Enabled = true; instructionLabel.Visible = true;
                for (int i = 0; i < program.InstructionText.Count; i++)
                {
                    instructionLabel.Text = program.InstructionText[i];
                    await Task.Delay(Program.instructionAwaitTime);
                }
                instructionLabel.Enabled = false; instructionLabel.Visible = false;
            }
        }

        private void repairProgram()
        {
            try
            {
                FormTRConfig configureProgram = new FormTRConfig(executingTest.ProgramInUse.ProgramName);
                this.Controls.Add(configureProgram);
            }
            catch (Exception ex)
            {
                throw new Exception(LocRM.GetString("couldntEdit", currentCulture) + ex.Message);
            }
        }

        private void exposition_KeyDown(object sender, KeyEventArgs e)
        {
            // user entered any key, if it is escape finish exposition
            if (e.KeyCode != Keys.Escape)
            {
                UserResponseControl(e.KeyCode);
            }
            else
            {
                CancelExposition();
            }
        }

        private void UserResponseControl(Keys keyCode)
        {
            if (executingTest.ProgramInUse.ResponseType.Equals("space") && keyCode == Keys.Space)
            {
                SendUserResponse(LocRM.GetString("spaceBar", currentCulture));
            }
            else if (executingTest.ProgramInUse.ResponseType.Equals("arrows"))
            {
                switch (keyCode)
                {                    
                    case Keys.Up:
                        SendUserResponse(LocRM.GetString("arrowUp", currentCulture));
                        break;
                    case Keys.Down:
                        SendUserResponse(LocRM.GetString("arrowDown", currentCulture));
                        break;
                    case Keys.Left:
                        SendUserResponse(LocRM.GetString("arrowLeft", currentCulture));
                        break;
                    case Keys.Right:
                        SendUserResponse(LocRM.GetString("arrowRight", currentCulture));
                        break;
                }
            }
        }

        private void SendUserResponse(string keyName)
        {
            if (expositionBW.WorkerSupportsCancellation == true)
            {
                executingTest.CurrentResponse = keyName;
                expositionBW.CancelAsync();
            }
        }

        private void CancelExposition()
        {
            cancelExposition = true;
            if (expositionBW.IsBusy)
            {
                expositionBW.CancelAsync();
            }
            else if (intervalBW.IsBusy)
            {
                intervalBW.CancelAsync();
            }
            else
            {
                /*do nothing*/
            }
            while (expositionBW.CancellationPending && intervalBW.CancellationPending)
            {
                //wait
                Thread.Sleep(10);
            }
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm is FormReactExposition)
                {
                    Close();
                }
            }
        }

        private int waitIntervalTime(bool isWaitTimeRandom, int waitTime)
        {
            int intervalTimeRandom = 200; // minimal rnd interval time
            intervalCancelled = false;

            // if random interval active, it will be a value between 200 and the defined interval time
            if (isWaitTimeRandom && waitTime > 400)
            {
                Random random = new Random();
                intervalTimeRandom = random.Next(400, waitTime);
            }
            else
            {
                intervalTimeRandom = waitTime;
            }

            Stopwatch intervalStopWatch = new Stopwatch();
            intervalStopWatch.Start();
            while (intervalStopWatch.ElapsedMilliseconds < intervalTimeRandom)
            {
                if (expositionBW.CancellationPending)
                {
                    intervalCancelled = true;
                    break;
                }
                /* just wait for interval time to be finished */
            }
            intervalShouldBe = intervalTimeRandom;
            intervalStopWatch.Stop();
            int elapsedTime = (int)intervalStopWatch.ElapsedMilliseconds;
            return elapsedTime;
        }


        private void expositionBackground()
        {
            expositionBW = new BackgroundWorker();
            expositionBW.WorkerSupportsCancellation = true;
            expositionBW.WorkerReportsProgress = true;
            expositionBW.DoWork += new DoWorkEventHandler(expositionBW_DoWork);
            expositionBW.ProgressChanged += new ProgressChangedEventHandler(expositionBW_ProgressChanged);
            expositionBW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(expositionBW_RunWorkerCompleted);
            if (!expositionBW.IsBusy)
            {
                expositionBW.RunWorkerAsync();
            }
            else
            {
                /*do nothing*/
            }
        }

        private void singleShapeExposition(string shape)
        {
            currentStimuli[0] = shape;
            switch (shape)
            {
                case "fullSquare":
                    drawFullSquareShape();
                    break;
                case "fullCircle":
                    drawFullCircleShape();
                    break;
                case "fullTriangle":
                    drawFullTriangleShape();
                    break;
                case "square":
                    drawSquareShape();
                    break;
                case "circle":
                    drawCircleShape();
                    break;
                case "triangle":
                    drawTriangleShape();
                    break;
            }
        }

        private void drawShape()
        {
            List<string> shapes = executingTest.ProgramInUse.StimuluShape.Split(',').ToList();
            currentColor = colorsList[colorCounter];
            if (shapes.Count == 1)
            {
                singleShapeExposition(shapes[0]);
            }
            else
            {
                randomShapeExposition(shapes);
            }
        }

        private void randomShapeExposition(List<string> shapes)
        {
            Random random = new Random();
            int index = random.Next(0, shapes.Count - 1);
            singleShapeExposition(shapes[index]);
        }

        private void drawWord()
        {
            Point screenPosition = ScreenPosition(wordLabel.PreferredSize);

            // configuring label that have word stimulus dimensions, color and position
            wordLabel = ExpositionController.InitializeWordLabel(executingTest.ProgramInUse.FontSize, wordsList[wordCounter], colorsList[colorCounter], screenPosition);

            currentStimuli[0] = wordsList[wordCounter];
            currentLists[0] = executingTest.ProgramInUse.getWordListFile().ListName;

            currentColor = colorsList[colorCounter];
            wordCounter++;

            if(wordCounter == wordsList.Length)
            {
                wordCounter = 0;
            }
            colorCounter++;
            if (colorCounter == colorsList.Length)
            {
                colorCounter = 0;
            }
            expositionBW.ReportProgress(currentExposition / executingTest.ProgramInUse.NumExpositions * 100, wordLabel);
        }

        private void drawImage()
        {
            imgPictureBox = ExpositionController.InitializeImageBox(executingTest.ProgramInUse.StimuluSize, Image.FromFile(imagesList[imageCounter]), 
                                                                     executingTest.ProgramInUse.ExpandImage, this);
            Point screenPosition = ScreenPosition(imgPictureBox.Size);
            imgPictureBox.Location = screenPosition;

            currentStimuli[0] = StrList.outPutItemName(imagesList[imageCounter]);
            currentLists[0] = executingTest.ProgramInUse.getImageListFile().ListName;

            imageCounter++;            
            if(imageCounter == imagesList.Length)
            {
                imageCounter = 0;
            }
            expositionBW.ReportProgress(currentExposition / executingTest.ProgramInUse.NumExpositions * 100, imgPictureBox);
        }

        private void playAudio()
        {
            string currentAudio = audioList[audioCounter];
            currentStimuli[1] = StrList.outPutItemName(currentAudio);
            currentLists[1] = executingTest.ProgramInUse.getAudioListFile().ListName;

            Player.SoundLocation = currentAudio;
            audioCounter++;
            if (audioCounter == audioList.Length)
            {
                audioCounter = 0;
            }
            Player.Play();
        }

        // image and word expositions take turns accordingly to the last stimulus shown to user
        private void imageWordExposition()
        {
            if(lastType == WORD)
            {
                drawImage();
                lastType = IMAGE;
                currentColor = "false";
            }
            else if (lastType == IMAGE)
            {
                drawWord();
                lastType = WORD;
            }
        }

        private void showStimulus()
        {
            this.CreateGraphics().Clear(ActiveForm.BackColor);
            if (executingTest.ProgramInUse.IsBeeping)
            {
                MakeBeep();
            }

            switch (executingTest.ProgramInUse.ExpositionType)
            {
                case "shapes":
                    drawShape();
                    break;
                case "words":
                    drawWord();
                    break;
                case "images":
                    drawImage();
                    break;
                case "imageAndWord":
                    imageWordExposition();
                    break;
                case "wordWithAudio":
                    drawWord();
                    playAudio();
                    break;
                case "imageWithAudio":
                    drawImage();
                    playAudio();
                    break;
                default:
                    throw new Exception(LocRM.GetString("expoType", currentCulture) + executingTest.ProgramInUse.ExpositionType + LocRM.GetString("invalid", currentCulture));

            }
        }

        private void MakeBeep()
        {
            bool beep;
            if (executingTest.ProgramInUse.BeepingRandom)
            {
                Random gen = new Random();
                int prob = gen.Next(1,100);
                beep = (prob >= 50);
            }
            else
            {
                beep = true;
            }

            if (beep)
            {
                currentBeep = true;
                beepBackground();
            }
            else
            {
                currentBeep = false;
            }
            
        }

        private void beepBackground()
        {
            BackgroundWorker beepBW = new BackgroundWorker();
            beepBW.WorkerSupportsCancellation = true;
            beepBW.DoWork += new DoWorkEventHandler(beepBW_DoWork);
            if (!beepBW.IsBusy)
            {
                beepBW.RunWorkerAsync();
            }
            else
            {
                /*do nothing*/
            }
        }

        private void beepBW_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.Beep(400, executingTest.ProgramInUse.BeepDuration);
        }

        private void expositionBW_DoWork(object sender, DoWorkEventArgs e)
        {

            intervalElapsedTime = waitIntervalTime(executingTest.ProgramInUse.IntervalTimeRandom, 
                executingTest.ProgramInUse.IntervalTime);

            /*starts Exposition*/
            expositionAccumulative = accumulativeStopWatch.ElapsedMilliseconds;
            hitStopWatch = new Stopwatch();
            hitStopWatch.Start();

            // Sending mark to neuronspectrum to sinalize that exposition of stimulus started
            SendKeys.SendWait(executingTest.Mark.ToString());
            executingTest.ExpositionTime = DateTime.Now;

            showStimulus();
            
            if (intervalCancelled)
            {
                e.Cancel = true;
            }
            else
            {
                while (hitStopWatch.ElapsedMilliseconds < executingTest.ProgramInUse.ExpositionTime)
                {
                    if (expositionBW.CancellationPending)
                    {
                        hitStopWatch.Stop();
                        if (Player.SoundLocation != null)
                        {
                            Player.Stop();
                            Player = new SoundPlayer();
                        }
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        /* just wait for exposition time to be finished */
                    }
                }
            }

            if (Player.SoundLocation != null)
            {
                Player.Stop();
                Player = new SoundPlayer();
            }
        }

        private void expositionBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exposing = true;
            currentControl = (Control)e.UserState;
            intervalBW.ReportProgress(20, (Control)e.UserState);
        }

        private void expositionBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!cancelExposition)
            {
                // cleaning screen
                if (ActiveForm != null)
                {
                    this.CreateGraphics().Clear(ActiveForm.BackColor);

                }
                // if expositions type uses any kind of control to show stimulus such as a word label or image picture box 
                if (currentControl != null)
                {
                    // if current control is enabled it means that just showed a stimulus
                    if (currentControl.Enabled)
                    {
                        // signaling to interval background worker that exposing must end and control must be removed from screen
                        exposing = false;
                        intervalBW.ReportProgress(50, currentControl);
                    }
                }
                ExpositionController.makingFixPoint(executingTest.ProgramInUse.FixPoint, executingTest.ProgramInUse.FixPointColor, this);
            }
            else
            {
                /*do nothing*/
            }

            if ((e.Cancelled == true) && !intervalCancelled)
            {
                /* user clicked after stimulus is shown*/
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, hitStopWatch.ElapsedMilliseconds,
                                              currentExposition + 1, expositionAccumulative, currentLists,currentStimuli, currentPositionOutput, currentBeep, currentColor);
            }

            else if ((e.Cancelled == true) && intervalCancelled)
            {
                /* user clicked before stimulus is shown*/
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, intervalElapsedTime - intervalShouldBe,
                                              currentExposition + 1, expositionAccumulative, currentLists, currentStimuli, currentPositionOutput, currentBeep, currentColor);
            }
            else
            {
                /* user missed stimulus */
                executingTest.CurrentResponse = "NA";
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, 0, currentExposition + 1, expositionAccumulative, currentLists, currentStimuli, 
                                                currentPositionOutput, currentBeep, currentColor);
                hitStopWatch.Stop();
            }
            expositionBW.Dispose();
        }

        private void intervalBW_DoWork(object sender, DoWorkEventArgs e)
        {
            

            executingTest.InitialTime = DateTime.Now;
            accumulativeStopWatch.Start();

            for (int counter = 0; counter < executingTest.ProgramInUse.NumExpositions && !cancelExposition; counter++)
            {
                ExpositionController.makingFixPoint(executingTest.ProgramInUse.FixPoint, executingTest.ProgramInUse.FixPointColor,
                this);
                currentExposition = counter;
                //preparing execution
                expositionBackground();
                while (expositionBW.IsBusy)
                {
                    /* wait for exposition to be finished */
                }
                Thread.Sleep(1);

            }
        }

        private void intervalBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                /* exposition was a success*/
                Program.writeOutputFile(outputFile, string.Join("\n", executingTest.Output.ToArray()));
                if (Application.OpenForms.OfType<FormReactExposition>().Any())
                {
                    Close();
                }
            }
            else
            {
                /* there was an error while doing exposition */
            }
        }

        /* creates a x and y vector according to program stimulus distance randomly, accordingly to program, that can be between 1 and 8 positions */
        private Point ScreenPosition (Size size){
            switch (executingTest.ProgramInUse.NumberPositions)
            {
                case 1:
                    return centerShapePosition(size);
                case 2:
                    return randomScreenTwoPositions(size);
                case 3:
                    return randomScreenThreePositions(size);
                case 4:
                    return randomScreenFourPositions(size);
                case 5:
                    return randomScreenFivePositions(size);
                case 6:
                    return randomScreenSixtPositions(size);
                case 7:
                    return randomScreenSevenPositions(size);
                case 8:
                    return randomScreenEightPositions(size);
                default:
                    throw new Exception(LocRM.GetString("positionInvalid", currentCulture));
            }
        }

        private Point randomScreenSevenPositions(Size size)
        {
            Random random = new Random();
            int index = random.Next(0, 7);
            currentPosition = index;

            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.sevenPointsPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }

        private Point randomScreenSixtPositions(Size size)
        {
            Random random = new Random();
            int index = random.Next(0, 6);
            currentPosition = index;

            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.sixPointsPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }

        private Point randomScreenFivePositions(Size size)
        {
            Random random = new Random();
            int index = random.Next(0, 5);
            currentPosition = index;

            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.fivePointsPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }

        private Point randomScreenThreePositions(Size size)
        {
            Random random = new Random();
            int index = random.Next(0, 3);
            currentPosition = index;

            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.threePointsPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }

        /* creates a x and y vector on center of the screen */
        private Point centerShapePosition(Size size)
        {
            currentPosition = 2;
            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.threePointsPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }

        /* creates a x and y vector according to program stimulus distance randomly, from two different positions */
        private Point randomScreenTwoPositions(Size size)
        {
            Random random = new Random();
            int index = random.Next(0, 2);
            currentPosition = index;

            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.twoPointsHorizontalPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }

        /* creates a x and y vector according to program stimulus distance randomly, from four different positions */
        private Point randomScreenFourPositions(Size size)
        {
            Random random = new Random();
            int index = random.Next(0, 4);
            currentPosition = index;

            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.fourPointsPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }

        /* creates a x and y vector according to program stimulus distance randomly, from eight different positions */
        private Point randomScreenEightPositions(Size size)
        {

            Random random = new Random();
            int index = random.Next(0, 8);
            currentPosition = index;

            StimulusPosition stimulusPosition = new StimulusPosition(ClientSize, size);
            Point newPoint = stimulusPosition.eightPointsPosition(currentPosition);
            currentPositionOutput = stimulusPosition.CurrentPosition;

            return newPoint;
        }
        
        // draw on screen filled square stimulus
        private void drawFullSquareShape()
        {
            int size = ExpositionController.CentimeterToPixel(executingTest.ProgramInUse.StimuluSize, this);
            float widthSquare = size;
            float heightSquare = size;

            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(colorsList[colorCounter]));
            Graphics formGraphicsSquare = CreateGraphics();

            Point screenPosition = this.ScreenPosition(new Size((int)widthSquare, (int)heightSquare));
            float xSquare = screenPosition.X;
            float ySquare = screenPosition.Y;
            formGraphicsSquare.FillRectangle(myBrush, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();
            colorCounter++;
            if (colorCounter == colorsList.Length)
            {
                colorCounter = 0;
            }
        }

        private void drawSquareShape()
        {
            int size = ExpositionController.CentimeterToPixel(executingTest.ProgramInUse.StimuluSize, this);
            float widthSquare = size;
            float heightSquare = size;

            Pen myPen = new Pen(ColorTranslator.FromHtml(colorsList[colorCounter]));
            Graphics formGraphicsSquare = CreateGraphics();

            Point screenPosition = this.ScreenPosition(new Size((int)widthSquare, (int)heightSquare));
            float xSquare = screenPosition.X;
            float ySquare = screenPosition.Y;
            formGraphicsSquare.DrawRectangle(myPen, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();
            colorCounter++;
            if (colorCounter == colorsList.Length)
            {
                colorCounter = 0;
            }
        }

        private void drawFullCircleShape()
        {
            int size = ExpositionController.CentimeterToPixel(executingTest.ProgramInUse.StimuluSize, this);
            float widthEllipse = size;
            float heightEllipse = size;

            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(colorsList[colorCounter]));
            Graphics formGraphicsEllipse = CreateGraphics();

            Point screenPosition = this.ScreenPosition(new Size((int)widthEllipse, (int)heightEllipse));
            float xEllipse = screenPosition.X;
            float yEllipse = screenPosition.Y;
            formGraphicsEllipse.FillEllipse(myBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
            formGraphicsEllipse.Dispose();
            colorCounter++;
            if (colorCounter == colorsList.Length)
            {
                colorCounter = 0;
            }
        }

        private void drawCircleShape()
        {
            int size = ExpositionController.CentimeterToPixel(executingTest.ProgramInUse.StimuluSize, this);
            float widthEllipse = size;
            float heightEllipse = size;

            Pen myPen = new Pen(ColorTranslator.FromHtml(colorsList[colorCounter]));
            Graphics formGraphicsEllipse = CreateGraphics();

            Point screenPosition = this.ScreenPosition(new Size((int)widthEllipse, (int)heightEllipse));
            float xEllipse = screenPosition.X;
            float yEllipse = screenPosition.Y;
            formGraphicsEllipse.DrawEllipse(myPen, xEllipse, yEllipse, widthEllipse, heightEllipse);
            formGraphicsEllipse.Dispose();
            colorCounter++;
            if (colorCounter == colorsList.Length)
            {
                colorCounter = 0;
            }
        }

        private void triangleShape_draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen myPen = new Pen(ColorTranslator.FromHtml(colorsList[colorCounter]), 1);
            Point[] trianglePoints = createTrianglePoints();
            g.DrawPolygon(myPen, trianglePoints);
            colorCounter++;
            if (colorCounter == colorsList.Length)
            {
                colorCounter = 0;
            }
        }


        private void drawTriangleShape()
        {
            Paint -= new PaintEventHandler(triangleShape_draw);
            Paint += new PaintEventHandler(triangleShape_draw);
            Invalidate();
        }

        private void drawFullTriangleShape()
        {
            Point[] trianglePoints = createTrianglePoints();

            FillMode newFillMode = FillMode.Winding;
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(colorsList[colorCounter]));
            Graphics formGraphicsTriangle = CreateGraphics();
            formGraphicsTriangle.FillPolygon(myBrush, trianglePoints, newFillMode);
            formGraphicsTriangle.Dispose();
            colorCounter++;
            if (colorCounter == colorsList.Length)
            {
                colorCounter = 0;
            }

        }

        private Point[] createTrianglePoints()
        {
            int[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            int size = ExpositionController.CentimeterToPixel(executingTest.ProgramInUse.StimuluSize, this);
            int heightTriangle = size;
            Point screenPosition = this.ScreenPosition(new Size(heightTriangle, heightTriangle));
            screenPosition.X -= heightTriangle / 3;
            screenPosition.Y += heightTriangle / 2;

            Point point1 = new Point( screenPosition.X + (heightTriangle / 3), (heightTriangle / 2) + screenPosition.Y);
            Point point2 = new Point( (8 * heightTriangle / 6) + screenPosition.X, (heightTriangle / 2) + screenPosition.Y);
            Point point3 = new Point(((heightTriangle / 2)) + screenPosition.X + (heightTriangle / 3), ((heightTriangle / 2)) + screenPosition.Y - heightTriangle);

            Point[] trianglePoints = { point1, point2, point3 };
            return trianglePoints;
        }

        // interval background worker sends message to main thread so that ui controls can be added or removed
        private void intervalBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (exposing && !cancelExposition)
            {
                this.Controls.Add((Control)e.UserState);
            }
            else if (!cancelExposition)
            {
                this.Controls.Remove((Control)e.UserState);
            }
        }
    }
}
