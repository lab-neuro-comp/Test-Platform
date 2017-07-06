using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform.Views
{
    public partial class FormReactExposition : Form
    {
        ReactionTest executingTest = new ReactionTest();
        private string path;                           
        private string outputDataPath;                
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

        public FormReactExposition(string prgName, string participantName, string defaultPath, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            path = defaultPath + "/ReactionTestFiles/";
            outputDataPath = path + "/data/";
            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.setProgramInUse(path + "/prg/", prgName);
            executingTest.Mark = mark;
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
                    throw new Exception("Arquivo programa: " + executingTest.ProgramInUse.ProgramName + ".prg" +
                                    "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/"));
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
            await exposition();
        }


        private async Task exposition()
        {
            cancellationTokenSource = new CancellationTokenSource();
            await showInstructions(executingTest.ProgramInUse, cancellationTokenSource.Token);
            //changeBackgroundColor(programInUse, true);

            await Task.Delay(executingTest.ProgramInUse.IntervalTime, cancellationTokenSource.Token);
            startingIntervalBwWorker();
        }

        private void startingIntervalBwWorker()
        {
            if (intervalBW.IsBusy != true)
            {
                intervalBW.RunWorkerAsync();
            }
        }

        private async Task showInstructions(ReactionProgram program, CancellationToken token) // apresenta instruções
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

        private void drawFullSquareShape()
        {
            int brush25 = 25;
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            
            int[] screenPosition = randomScreenPosition();
            float xSquare = (clientMiddle[X] - brush25) + screenPosition[X];
            float ySquare = (clientMiddle[Y] - brush25) + screenPosition[Y];
            float widthSquare = executingTest.ProgramInUse.StimuluSize;
            float heightSquare = executingTest.ProgramInUse.StimuluSize;

            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsSquare = CreateGraphics();
            formGraphicsSquare.FillRectangle(myBrush, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();
            
        }

        private void drawSquareShape()
        {
            int brush25 = 25;
            int[] screenPosition = randomScreenPosition();
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };           
            float xSquare = (clientMiddle[X] - brush25) + screenPosition[X];
            float ySquare = (clientMiddle[Y] - brush25) + screenPosition[Y];

            float widthSquare = executingTest.ProgramInUse.StimuluSize;
            float heightSquare = executingTest.ProgramInUse.StimuluSize;

            Pen myPen = new Pen(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsSquare = CreateGraphics();
            formGraphicsSquare.DrawRectangle(myPen, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();

        }

        private void drawFullCircleShape()
        {
            int brush25 = 25;
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };            
            int[] screenPosition = randomScreenPosition();
            
            float xEllipse = (clientMiddle[X] - brush25) + screenPosition[X];
            float yEllipse = (clientMiddle[Y] - brush25) + screenPosition[Y];
            float widthEllipse = executingTest.ProgramInUse.StimuluSize;
            float heightEllipse = executingTest.ProgramInUse.StimuluSize;

            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Graphics formGraphicsEllipse = CreateGraphics();
            formGraphicsEllipse.FillEllipse(myBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
            formGraphicsEllipse.Dispose();

        }

        private void drawCircleShape()
        {
            int brush25 = 25;
            
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            int[] screenPosition = randomScreenPosition();
            float xEllipse = (clientMiddle[X] - brush25) + screenPosition[X];
            float yEllipse = (clientMiddle[Y] - brush25) + screenPosition[Y];

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
            int[] screenPosition = randomScreenPosition();
            int heightTriangle = executingTest.ProgramInUse.StimuluSize;

            Point point1 = new Point((clientMiddle[X]) + screenPosition[X] + (heightTriangle / 3),
                (clientMiddle[Y] - (heightTriangle / 2)) + screenPosition[Y]);
            Point point2 = new Point((clientMiddle[X] - (3 * heightTriangle / 4)) + screenPosition[X], (clientMiddle[Y] - (heightTriangle / 2)) + screenPosition[Y]);
            Point point3 = new Point((clientMiddle[X] - (heightTriangle / 2)) + screenPosition[X] + (heightTriangle / 3),
                                        (clientMiddle[Y] - (heightTriangle / 2)) + screenPosition[Y] - heightTriangle);

            Point[] trianglePoints = { point1, point2, point3 };
            return trianglePoints;
        }

        private void repairProgram()
        {
            try
            {
                FormTRConfig configureProgram = new FormTRConfig(executingTest.ProgramInUse.ProgramName);
                configureProgram.Path = path;
                this.Controls.Add(configureProgram);
            }
            catch (Exception ex) { throw new Exception("Edição não pode ser feita " + ex.Message); }
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
            executingTest.CurrentShape = shape;
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

        private void showStimulus()
        {
            switch (executingTest.ProgramInUse.ExpositionType)
            {
                case "Formas":
                    drawShape();
                    break;
                case "Palavra":
                    // await wordExposition();
                    break;
                case "Imagem":
                    // await imageExposition();
                    break;
                case "Imagem e Palavra":
                    // await imageWordExposition();
                    break;
                case "Palavra com Áudio":
                    // await wordAudioExposition();
                    break;
                case "Imagem com Áudio":
                // await imageAudioExposition();
                default:
                    throw new Exception("Tipo de Exposição: " + executingTest.ProgramInUse.ExpositionType + " inválido!");

            }
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
            Console.WriteLine(currentExposition);
        }

        private void expositionBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!cancelExposition)
            {
                CreateGraphics().Clear(ActiveForm.BackColor);
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
                                              currentExposition + 1, expositionAccumulative);
            }

            else if ((e.Cancelled == true) && intervalCancelled)
            {
                /* user clicked before stimulus is shown*/
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, intervalElapsedTime - intervalShouldBe,
                                              currentExposition + 1, expositionAccumulative);
            }
            else
            {
                /* user missed stimulus */
                executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, 0, currentExposition + 1, expositionAccumulative);
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

            for (int counter = 0; counter < executingTest.ProgramInUse.NumExpositions; counter++)
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

        /* creates a x and y vector according to program stimulus distance randomly, from four different positions */
        private int[] randomScreenPosition (){
            int[,] position = new int[4, 2]{ { (executingTest.ProgramInUse.StimulusDistance + (executingTest.ProgramInUse.StimulusDistance / 4)), 0 }, // on the right side of the screen
                                             { 0, (executingTest.ProgramInUse.StimulusDistance - (executingTest.ProgramInUse.StimulusDistance / 4))}, // on bottom of the screen
                                             { -(executingTest.ProgramInUse.StimulusDistance + (executingTest.ProgramInUse.StimulusDistance / 4)), 0 }, // on the left side of the screen
                                             { 0, -( executingTest.ProgramInUse.StimulusDistance - (executingTest.ProgramInUse.StimulusDistance / 4)) } }; // on top of the screen
            Random random = new Random();
            int index = random.Next(0, 4);
            return new int []{ position[index, X], position[index, Y] };
        }
    }
}
