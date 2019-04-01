using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Controllers;
using TestPlatform.Models;
using TestPlatform.Models.Tests.SpacialRecognition;

namespace TestPlatform.Views.SpacialRecognitionPages
{
    public partial class SpacialRecognitionExposition : Form
    {
        SpacialRecognitionTest executingTest = new SpacialRecognitionTest();
        private string startTime;
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private List<Control> stimuluControls;
        private List<Control> currentControl;
        private Control newStimulu;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private string outputFile;
        private Control objectClicked;
        private Control LastControlRendered;

        private bool exposing;
        private bool nextStimulu;
        private int stimulusToShow;
        private bool cancelExposition = false, cancelAttempt = false;
        private int currentExposition;
        private int colorListPosition = 0, imageListPosition = 0, wordListPosition = 0;

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private string[] imagesList = null;
        private string[] wordsList = null;
        private string[] colorsList = null;

        private Stopwatch accumulativeStopWatch = new Stopwatch();
        private Stopwatch hitStopWatch;
        private int intervalShouldBe;
        private long attemptIntervalTime, expositionAccumulative, stimuluIntervalTime;

        private bool intervalCancelled;
        private bool waitingExpositionEnd;

        StimulusPosition stimuluPosition;
        

        public SpacialRecognitionExposition(string prgName, string participantName, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            ExpositionController.formSecondScreen(this);

            InitializeComponent();

            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.setProgramInUse(prgName);
            executingTest.Mark = mark;

            stimuluControls = new List<Control>();
            outputFile = SpacialRecognitionProgram.GetResultsPath() + executingTest.ParticipantName + "_" + executingTest.ProgramInUse.ProgramName + ".txt";
            startExposition();
            this.ShowDialog();
        }

        private void startExposition()
        {
            if (executingTest.ProgramInUse.Ready())
            {
                initializeExposition();
            }
            else
            {
                throw new Exception(LocRM.GetString("file", currentCulture) + executingTest.ProgramInUse.ProgramName + ".prg" +
                                LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(SpacialRecognitionProgram.GetProgramsPath() + "/prg/"));
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

            await Task.Delay(executingTest.ProgramInUse.IntervalTime, cancellationTokenSource.Token);
            startingIntervalBwWorker();
        }

        private void startingIntervalBwWorker()
        {
            if (expositionControllerBW.IsBusy != true)
            {
                expositionControllerBW.RunWorkerAsync();
            }
        }

        // show participant instructions to execute during test
        private async Task showInstructions(SpacialRecognitionProgram program, CancellationToken token)
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

        private void loadLists()
        {
            switch (executingTest.ProgramInUse.StimuluType)
            {
                case SpacialRecognitionProgram.IMAGE_TEST: /*image*/
                    imagesList = executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();
                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        imagesList = ExpositionController.ShuffleArray(imagesList, executingTest.ProgramInUse.NumExpositions, 3);
                    }
                    break;
                default: /*word or word and color*/
                    wordsList = executingTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        wordsList = ExpositionController.ShuffleArray(wordsList, executingTest.ProgramInUse.NumExpositions, 3);
                    }
                    if (executingTest.ProgramInUse.StimuluSingleColor == "false") //if stimulusColor is false then there exists a color list
                    {
                        colorsList = executingTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                        if (executingTest.ProgramInUse.ExpositionRandom)
                        {
                            colorsList = ExpositionController.ShuffleArray(colorsList, executingTest.ProgramInUse.NumExpositions, 3);
                        }
                    }
                    else //if stimulusColor isn't false then there is no color list
                    {
                        colorsList = new string[] { executingTest.ProgramInUse.StimuluSingleColor };
                        colorsList = ExpositionController.ShuffleArray(colorsList, executingTest.ProgramInUse.NumExpositions, 3);
                    }
                    break;
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

        private void expositionBW_DoWork(object sender, DoWorkEventArgs e)
        {
            bool userClicked = false;
            generateStimulus();
            int attempt = 0, time;
            /*wait interval between attempts*/
            attemptIntervalTime = waitIntervalTime(executingTest.ProgramInUse.IntervalTimeRandom,
                executingTest.ProgramInUse.IntervalTime);
            /*set exposition accumulative time and test exposition time*/
            executingTest.ExpositionTime = DateTime.Now;
            expositionAccumulative = accumulativeStopWatch.ElapsedMilliseconds;
            /*send mark keys*/
            if (!cancelExposition)
            {
                SendKeys.SendWait(executingTest.Mark.ToString());
            }
            while (!cancelAttempt && attempt < executingTest.ProgramInUse.StimuluCount)
            {
                waitingExpositionEnd = true;
                attempt++;
                stimulusToShow = attempt;
                expositionBW.ReportProgress(attempt / (executingTest.ProgramInUse.StimuluCount) * 100, stimuluControls);
                hitStopWatch = new Stopwatch();
                hitStopWatch.Start();

                if (intervalCancelled)
                {
                    e.Cancel = true;
                }
                else
                {
                    time = executingTest.ProgramInUse.ExpositionTime;
                    while (hitStopWatch.ElapsedMilliseconds < time)
                    {
                        if (nextStimulu)
                        {
                            nextStimulu = false;
                            hitStopWatch.Stop();
                            userClicked = true;
                            break;
                        }
                        else
                        {
                            /* just wait for exposition time to be finished */
                        }
                    }
                }
                waitingExpositionEnd = false;
                exposing = false;
                expositionControllerBW.ReportProgress(50, currentControl);
                if (objectClicked != null && this.objectClicked.Location.Equals(this.stimuluControls[attempt - 1].Location))
                {
                    if (!userClicked)
                    {
                        new System.Media.SoundPlayer(TestPlatform.Properties.Resources.error).Play();
                        writeErrorResult(LastControlRendered);
                    }
                    else
                    {
                        new System.Media.SoundPlayer(TestPlatform.Properties.Resources.hit).Play();
                        writeHitResult(LastControlRendered);
                    }
                    userClicked = false;
                    stimuluIntervalTime = waitIntervalTime(executingTest.ProgramInUse.IntervalTimeRandom,
                    executingTest.ProgramInUse.IntervalTime);
                }
                else
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    stimuluIntervalTime = waitIntervalTime(executingTest.ProgramInUse.IntervalTimeRandom,
                    executingTest.ProgramInUse.IntervalTime/2);
                    attempt--;
                    stimulusToShow = attempt;
                    writeMissResults(LastControlRendered);
                    continue;
                }
            }
        }
        
    private void writeHitResult(Control control){
            string stimulu;
            string stimuluType, listName;
            Size size;
            if(this.executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.IMAGE_TEST)
            {
                listName = this.executingTest.ProgramInUse.getImageListFile().ListName;
                stimuluType = "image";
                size = control.Size;
                stimulu = control.Tag.ToString();
            }
            else
            {
                listName = this.executingTest.ProgramInUse.getWordListFile().ListName;
                size = control.PreferredSize;
                stimulu = control.Text;
                if (this.executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.WORD_TEST)
                {
                    stimuluType = "word";
                }
                else{
                    stimuluType = "word and color";
                }
            }
            this.executingTest.WriteLineOutput(
                attemptIntervalTime,
                stimuluIntervalTime,
                hitStopWatch.ElapsedMilliseconds,
                stimulusToShow,
                currentExposition,
                "true",
                stimulu,
                listName,
                stimuluType,
                getForeColor(control),
                stimuluPosition.getStimulusPositionMap(objectClicked.Location, size),
                stimuluPosition.getStimulusPositionMap(control.Location, size)
                );
        }

        private void writeMissResults(Control control)
        {
            string stimulu;
            string stimuluType, listName;
            Size size;
            if (this.executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.IMAGE_TEST)
            {
                listName = this.executingTest.ProgramInUse.getImageListFile().ListName;
                stimuluType = "image";
                size = control.Size;
                stimulu = control.Tag.ToString();
            }
            else
            {
                listName = this.executingTest.ProgramInUse.getWordListFile().ListName;
                size = control.PreferredSize;
                stimulu = control.Text;
                if (this.executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.WORD_TEST)
                {
                    stimuluType = "word";
                }
                else
                {
                    stimuluType = "word and color";
                }
            }
            this.executingTest.WriteLineOutput(
                attemptIntervalTime,
                stimuluIntervalTime,
                hitStopWatch.ElapsedMilliseconds,
                stimulusToShow,
                currentExposition,
                "-",
                stimulu,
                listName,
                stimuluType,
                getForeColor(control),
                "-",
                stimuluPosition.getStimulusPositionMap(control.Location, size)
                );
        }

        private void writeErrorResult(Control control)
        {
            string stimulu;
            string stimuluType, listName;
            Size size;
            if (this.executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.IMAGE_TEST)
            {
                listName = this.executingTest.ProgramInUse.getImageListFile().ListName;
                stimuluType = "image";
                size = control.Size;
                stimulu = control.Tag.ToString();
            }
            else
            {
                listName = this.executingTest.ProgramInUse.getWordListFile().ListName;
                size = control.PreferredSize;
                stimulu = control.Text;
                if (this.executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.WORD_TEST)
                {
                    stimuluType = "word";
                }
                else
                {
                    stimuluType = "word and color";
                }
            }
            this.executingTest.WriteLineOutput(
                attemptIntervalTime,
                stimuluIntervalTime,
                hitStopWatch.ElapsedMilliseconds,
                stimulusToShow,
                currentExposition,
                "false",
                stimulu,
                listName,
                stimuluType,
                getForeColor(control),
                stimuluPosition.getStimulusPositionMap(objectClicked.Location, size),
                stimuluPosition.getStimulusPositionMap(control.Location, size)
                );
        }

        private String getForeColor(Control control)
        {
            string color = "";
            if (this.executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.IMAGE_TEST)
            {
                color = "-";
            }
            else
            {
                color = ColorTranslator.ToHtml(control.ForeColor);
            }
            return color;
        }

        private void generateStimulus()
        {
            Console.WriteLine("GenerateStimulus");
            stimuluPosition = new StimulusPosition(ClientSize, 1);
            Size size;
            stimuluControls.Clear();
            for (int i = 0; i < executingTest.ProgramInUse.StimuluCount; i++)
            {
                if (executingTest.ProgramInUse.StimuluType == SpacialRecognitionProgram.IMAGE_TEST)
                {
                    newStimulu = ExpositionController.InitializeImageBox(executingTest.ProgramInUse.StimuluSize, Image.FromFile(imagesList[imageListPosition]), false, this);
                    newStimulu.Tag = imagesList[imageListPosition];
                    size = newStimulu.Size;
                }
                else
                {
                    newStimulu = ExpositionController.InitializeButton(wordsList[wordListPosition]);
                    newStimulu.Font = new Font("Arial", this.executingTest.ProgramInUse.FontSize, FontStyle.Bold);
                    newStimulu.ForeColor = ColorTranslator.FromHtml(colorsList[colorListPosition]);

                    size = newStimulu.PreferredSize;
                }
                newStimulu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SpacialRecognitionExposition_MouseClick);
                newStimulu.Location = stimuluPosition.getRandomPosition(size);
                stimuluControls.Add(newStimulu);
            }
            if (colorsList != null && ++colorListPosition >= colorsList.Length)
            {
                colorListPosition = 0;
            }
            if (imagesList != null && ++imageListPosition >= imagesList.Length)
            {
                imageListPosition = 0;
            }
            if (wordsList != null && ++wordListPosition >= wordsList.Length)
            {
                wordListPosition = 0;
            }
        }

        private void SpacialRecognitionExposition_MouseClick(object sender, MouseEventArgs e)
        {
            SendUserResponse((Control)sender);
        }

        private void SendUserResponse(Control objectClicked)
        {
            if (expositionBW.WorkerSupportsCancellation == true)
            {
                this.objectClicked = objectClicked;
                this.nextStimulu = true;
            }
        }

        private void expositionBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exposing = true;
            currentControl = (List<Control>)e.UserState;
            expositionControllerBW.ReportProgress(20, (List<Control>)e.UserState);
        }

        private void expositionBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*do Nothing*/
        }

        private void expositionControllerBW_DoWork(object sender, DoWorkEventArgs e)
        {
            /*define test initil time and start accumulative stopwatch*/
            executingTest.InitialDate = DateTime.Now;
            accumulativeStopWatch.Start();

            /*exposition*/
            for (int i = 0; i < this.executingTest.ProgramInUse.NumExpositions; i++)
            {
                startExpositionBW();
                currentExposition = i;
                while (expositionBW.IsBusy)
                {
                    /*do nothing*/
                }
                Thread.Sleep(10);
            }
        }

        private void startExpositionBW()
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

        private void expositionControllerBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                List<Control> controls = (List<Control>)e.UserState;
                for (int i = 0; i < stimulusToShow; i++)
                {
                    Control c = controls[i];
                    if (exposing)
                    {
                        this.Controls.Add(c);
                        LastControlRendered = c;
                    }
                    else
                    {
                        this.Controls.Remove(c);
                    }
                }
                if (this.executingTest.ProgramInUse.PlayExpositionSound && exposing && !cancelExposition)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.bell);
                    player.Play();
                }
            }
            catch (Exception)
            {
                /*do nothing*/
            }
        }

        private void expositionControllerBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = "";
            if (e.Error == null)
            {
                /* exposition was a success*/
                do
                {
                    result = string.Join("\n", executingTest.Output.ToArray());
                } while (result == "");
                Program.writeOutputFile(outputFile, result);
                if (Application.OpenForms.OfType<SpacialRecognitionExposition>().Any())
                {
                    Close();
                }
            }
            else
            {
                /* there was an error while doing exposition */
            }
            CancelExposition();
        }


        private void MatchingExposition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CancelExposition();
            }
        }

        private void CancelExposition()
        {
            cancelExposition = true;
            if (expositionBW.IsBusy && !waitingExpositionEnd)
            {
                expositionBW.CancelAsync();
            }
            else if (expositionControllerBW.IsBusy && !waitingExpositionEnd)
            {
                expositionControllerBW.CancelAsync();
            }
            else
            {
                /*do nothing*/
            }
            while (expositionBW.CancellationPending && expositionControllerBW.CancellationPending)
            {
                //wait
                Thread.Sleep(10);
            }
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm is SpacialRecognitionExposition)
                {
                    Close();
                }
            }
        }
    }
}
