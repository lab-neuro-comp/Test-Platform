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
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private string outputFile;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private static int X = 0;
        private static int Y = 1;
        private int intervalElapsedTime;
        private int intervalShouldBe;
        private long expositionAccumulative;
        private Stopwatch hitStopWatch = new Stopwatch();
        private Stopwatch accumulativeStopWatch = new Stopwatch();
        private int currentExposition = 0;
        private bool intervalCancelled;
        private bool cancelExposition = false;
        private string[] imagesList = null;
        private int imageCounter = 0;
        private PictureBox imgPictureBox = new PictureBox();
        private bool exposing = false;
        private string currentStimulus = null;
        private string position = null;
        private int currentPosition;
        private bool currentBeep = false;
        private int[,] positions;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public FormReactExposition(string prgName, string participantName, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.setProgramInUse(path + "/prg/", prgName);
            executingTest.Mark = mark;

            // initializes position propertie so that they become avaible for stimulus
            positions = new int[9, 2]{      {0, 0 }, //center position
                                            { (2 * executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize), 0 }, // on the right side of the screen
                                            { - (2 * executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize), 0 }, // on the left side of the screen
                                             { 0, ( - executingTest.ProgramInUse.StimulusDistance + executingTest.ProgramInUse.StimuluSize)}, // on top of the screen
                                             { 0, (executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize) }, // on bottom of the screen
                                             { - (2 * executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize),
                                                ( - executingTest.ProgramInUse.StimulusDistance + executingTest.ProgramInUse.StimuluSize)
                                             }, // on left top of the screen
                                             {  (2 * executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize),
                                                ( - executingTest.ProgramInUse.StimulusDistance + executingTest.ProgramInUse.StimuluSize)
                                             }, // on right top of the screen
                                             { - (2 * executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize),
                                                (executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize)
                                             }, // on left bottom of the screen
                                             { (2 * executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize),
                                                (executingTest.ProgramInUse.StimulusDistance - executingTest.ProgramInUse.StimuluSize)
                                             } // on right bottom of the screen                                             
                                     }; 

            outputFile = outputDataPath + executingTest.ParticipantName + "_" + executingTest.ProgramInUse.ProgramName + ".txt";
            startExposition();
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


        private async void initializeExposition()
        {
            switch (executingTest.ProgramInUse.ExpositionType)
            {
                case "images":
                    imagesList = executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();

                    if (executingTest.ProgramInUse.ExpositionRandom)
                    {
                        imagesList = ExpositionController.ShuffleArray(imagesList, executingTest.ProgramInUse.NumExpositions, 3);
                    }
                    break;
            }
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
            if (e.KeyCode == Keys.Space)
            {
                if (expositionBW.WorkerSupportsCancellation == true)
                {
                    expositionBW.CancelAsync();
                }
            }
            else if (e.KeyCode == Keys.Escape)
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
                Close();
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
            currentStimulus = shape;
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

        private void drawImage()
        {
            int[] screenPosition = ScreenPosition();
            imgPictureBox = new PictureBox();
            imgPictureBox.Size = new Size(executingTest.ProgramInUse.StimuluSize, executingTest.ProgramInUse.StimuluSize);
            imgPictureBox.Location = new Point(screenPosition[X], screenPosition[Y]);
            imgPictureBox.Image = Image.FromFile(imagesList[imageCounter]);
            currentStimulus = imagesList[imageCounter];
            imgPictureBox.Enabled = true;
            imageCounter++;            
            if(imageCounter == imagesList.Length)
            {
                imageCounter = 0;
            }
            expositionBW.ReportProgress(currentExposition / executingTest.ProgramInUse.NumExpositions * 100, imgPictureBox);
        }

        private void showStimulus()
        {
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
                    //  wordExposition();
                    break;
                case "images":
                    drawImage();
                    break;
                case "imageAndWord":
                    //  imageWordExposition();
                    break;
                case "wordWithAudio":
                    // wordAudioExposition();
                    break;
                case "imageWithAudio":
                    // imageAudioExposition();
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
            /*parameterizing object to backgroundworker*/
            BackgroundWorker worker = sender as BackgroundWorker;

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
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        /* just wait for exposition time to be finished */
                    }
                }
            }
        }

        private void expositionBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exposing = true;
            intervalBW.ReportProgress(20, imgPictureBox);
        }

        private void expositionBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!cancelExposition)
            {
                this.CreateGraphics().Clear(ActiveForm.BackColor);
                if (imgPictureBox.Enabled)
                {
                    exposing = false;
                    intervalBW.ReportProgress(50, imgPictureBox);
                }
                ExpositionsViews.makingFixPoint(executingTest.ProgramInUse.FixPoint, executingTest.ProgramInUse.FixPointColor,
                    this);
            }
            else
            {
                /*do nothing*/
            }
            
            if ((e.Cancelled == true) && !intervalCancelled)
            {
                /* user clicked after stimulus is shown*/
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, hitStopWatch.ElapsedMilliseconds,
                                              currentExposition + 1, expositionAccumulative, currentStimulus, position_converter(currentPosition), currentBeep);
            }

            else if ((e.Cancelled == true) && intervalCancelled)
            {
                /* user clicked before stimulus is shown*/
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, intervalElapsedTime - intervalShouldBe,
                                              currentExposition + 1, expositionAccumulative, currentStimulus, position_converter(currentPosition), currentBeep);
            }
            else
            {
                /* user missed stimulus */
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, 0, currentExposition + 1, expositionAccumulative, currentStimulus, position_converter(currentPosition),
                                                currentBeep);
                hitStopWatch.Stop();
            }
            expositionBW.Dispose();
        }

        private void intervalBW_DoWork(object sender, DoWorkEventArgs e)
        {
            ExpositionsViews.makingFixPoint(executingTest.ProgramInUse.FixPoint, executingTest.ProgramInUse.FixPointColor,
                this);

            executingTest.InitialTime = DateTime.Now;
            accumulativeStopWatch.Start();

            for (int counter = 0; counter < executingTest.ProgramInUse.NumExpositions && !cancelExposition; counter++)
            {
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
                Close();
            }
            else
            {
                /* there was an error while doing exposition */
            }
        }

        /* creates a x and y vector according to program stimulus distance randomly, accordingly to program, that can be 1, 2, 4 or 8 positions */
        private int[] ScreenPosition (){
            switch (executingTest.ProgramInUse.NumberPositions)
            {
                case 1:
                    return centerShapePosition();
                case 2:
                    return randomScreenTwoPositions();
                case 4:
                    return randomScreenFourPositions();
                case 8:
                    return randomScreenEightPositions();
                default:
                    throw new Exception(LocRM.GetString("positionInvalid", currentCulture));
            }
        }

        /* creates a x and y vector on center of the screen */
        private int[] centerShapePosition()
        {
            currentPosition = 0;
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            return new int[] { (int)clientMiddle[X], (int)clientMiddle[Y] };
        }

        /* creates a x and y vector according to program stimulus distance randomly, from two different positions */
        private int[] randomScreenTwoPositions()
        {
            Random random = new Random();
            int index = random.Next(1, 3);
            currentPosition = index;

            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            int x = (int)(clientMiddle[X]) + positions[index, X];
            int y = (int)(clientMiddle[Y]) + positions[index, Y];

            int[] coordinates = CoordinatesWithinRange(x, y);
            return coordinates;
        }

        /* creates a x and y vector according to program stimulus distance randomly, from four different positions */
        private int[] randomScreenFourPositions()
        {
            Random random = new Random();
            int index = random.Next(1, 5);
            currentPosition = index;

            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            int x = (int)(clientMiddle[X]) + positions[index, X];
            int y = (int)(clientMiddle[Y]) + positions[index, Y];

            int[] coordinates = CoordinatesWithinRange(x, y);
            return coordinates;
        }

        /* creates a x and y vector according to program stimulus distance randomly, from eight different positions */
        private int[] randomScreenEightPositions()
        {

            Random random = new Random();
            int index = random.Next(1, 9);
            currentPosition = index;

            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            int x = (int)(clientMiddle[X]) + positions[index, X];
            int y = (int)(clientMiddle[Y]) + positions[index, Y];

            int[] coordinates = CoordinatesWithinRange(x, y);
            return coordinates;
        }

        // checks if generated coordinates for stimulus are within screen range and if they are not, put them inside of it
        private int[] CoordinatesWithinRange(int x, int y)
        {
            float[] clientSize = { (ClientSize.Width), (ClientSize.Height) };
            if (x > clientSize[X] || (x + executingTest.ProgramInUse.StimuluSize > clientSize[X] ) ) 
            {
                x = (int)clientSize[X] - (executingTest.ProgramInUse.StimuluSize);
            }
            else if (x < 1)
            {
                x = 1;
            }

            if (y > clientSize[Y])
            {
                y = (int)clientSize[Y] - executingTest.ProgramInUse.StimuluSize;
            }
            else if (y < 1)
            {
                y = 1;
            }

            return new int[] { x, y };
        }

        // draw on screen filled square stimulus
        private void drawFullSquareShape()
        {

            int[] screenPosition = this.ScreenPosition();
            float xSquare = screenPosition[X];
            float ySquare = screenPosition[Y];
            float widthSquare = executingTest.ProgramInUse.StimuluSize;
            float heightSquare = executingTest.ProgramInUse.StimuluSize;

            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsSquare = CreateGraphics();
            formGraphicsSquare.FillRectangle(myBrush, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();

        }

        private void drawSquareShape()
        {
            int[] screenPosition = this.ScreenPosition();
            float xSquare = screenPosition[X];
            float ySquare = screenPosition[Y];

            float widthSquare = executingTest.ProgramInUse.StimuluSize;
            float heightSquare = executingTest.ProgramInUse.StimuluSize;

            Pen myPen = new Pen(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsSquare = CreateGraphics();
            formGraphicsSquare.DrawRectangle(myPen, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();

        }

        private void drawFullCircleShape()
        {
            int[] screenPosition = this.ScreenPosition();
            float xEllipse = screenPosition[X];
            float yEllipse = screenPosition[Y];

            float widthEllipse = executingTest.ProgramInUse.StimuluSize;
            float heightEllipse = executingTest.ProgramInUse.StimuluSize;

            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsEllipse = CreateGraphics();
            formGraphicsEllipse.FillEllipse(myBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
            formGraphicsEllipse.Dispose();

        }

        private void drawCircleShape()
        {
            int[] screenPosition = this.ScreenPosition();
            float xEllipse = screenPosition[X];
            float yEllipse = screenPosition[Y];

            float widthEllipse = executingTest.ProgramInUse.StimuluSize;
            float heightEllipse = executingTest.ProgramInUse.StimuluSize;

            Pen myPen = new Pen(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsEllipse = CreateGraphics();
            formGraphicsEllipse.DrawEllipse(myPen, xEllipse, yEllipse, widthEllipse, heightEllipse);
            formGraphicsEllipse.Dispose();
        }

        private void triangleShape_draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            ExpositionsViews.makingFixPoint(executingTest.ProgramInUse.FixPoint, executingTest.ProgramInUse.FixPointColor,
                this);
            Pen myPen = new Pen(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor), 1);
            Point[] trianglePoints = createTrianglePoints();
            g.DrawPolygon(myPen, trianglePoints);
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
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsTriangle = CreateGraphics();
            formGraphicsTriangle.FillPolygon(myBrush, trianglePoints, newFillMode);
            formGraphicsTriangle.Dispose();

        }

        private Point[] createTrianglePoints()
        {
            int[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            int[] screenPosition = this.ScreenPosition();
            int heightTriangle = executingTest.ProgramInUse.StimuluSize;

            Point point1 = new Point( screenPosition[X] + (heightTriangle / 3), (heightTriangle / 2) + screenPosition[Y]);
            Point point2 = new Point( (8 * heightTriangle / 6) + screenPosition[X], (heightTriangle / 2) + screenPosition[Y]);
            Point point3 = new Point(((heightTriangle / 2)) + screenPosition[X] + (heightTriangle / 3), ((heightTriangle / 2)) + screenPosition[Y] - heightTriangle);

            Point[] trianglePoints = { point1, point2, point3 };
            return trianglePoints;
        }

        // interval background worker sends message to main thread so that ui controls can be added or removed
        private void intervalBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (exposing)
            {
                this.Controls.Add(imgPictureBox);
            }
            else
            {
                this.Controls.Remove(imgPictureBox);
            }
        }

        private string position_converter(int index)
        {
            switch (index)
            {
                case 0:
                    return LocRM.GetString("center",currentCulture);
                case 1:
                    return LocRM.GetString("right", currentCulture);
                case 2:
                    return LocRM.GetString("left", currentCulture);
                case 3:
                    return LocRM.GetString("up", currentCulture);
                case 4:
                    return LocRM.GetString("down", currentCulture);
                case 5:
                    return LocRM.GetString("up_left", currentCulture);
                case 6:
                    return LocRM.GetString("up_right", currentCulture);
                case 7:
                    return LocRM.GetString("down_left", currentCulture);
                case 8:
                    return LocRM.GetString("down_right", currentCulture);
                default:
                    return LocRM.GetString("invalid", currentCulture);
            }
                
        }
    }
}
