using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform.Views
{
    public partial class FormReactExposition : Form
    {
        ReactionProgram programInUse = new ReactionProgram();
        ReactionTest executingTest = new ReactionTest();
        private static float elapsedTime;               
        private string path;                           
        private List<string> outputContent;            
        private string outputDataPath;                
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private string outputFile;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private int compareTimes = 0;
        private int backWorkStatus;
        BackgroundWorker timingExposition = new BackgroundWorker();
        BackgroundWorker intervalBW = new BackgroundWorker();
        private string progress;
        
        public FormReactExposition(string prgName, string participantName, string defaultPath)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            path = defaultPath + "/ReactionTestFiles/";
            outputDataPath = path + "/data";
            startTime = hour + "_" + minutes + "_" + seconds;
            programInUse.ProgramName = prgName;
            executingTest.ParticipantName = participantName;
            startExposition();
        }


        private void startExposition()
        {
            if (programInUse.Ready(path))
            {
                initializeExposition();
            }
            else
            {
                if (!programInUse.Exists(path))
                {
                    throw new Exception("Arquivo programa: " + programInUse.ProgramName + ".prg" +
                                    "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/"));
                }
                else if (programInUse.NeedsEdition)
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
            programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg");
            switch (programInUse.ExpositionType)
            {
                case "Formas":
                    await shapeExposition();
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
                    throw new Exception("Tipo de Exposição: " + programInUse.ExpositionType + " inválido!");
            }
        }


        private async Task shapeExposition()
        {
            cancellationTokenSource = new CancellationTokenSource();
            await showInstructions(programInUse, cancellationTokenSource.Token);

            elapsedTime = 0; // elapsed time to zero


            //changeBackgroundColor(programInUse, true);

            await Task.Delay(programInUse.IntervalTime, cancellationTokenSource.Token);
            for (int counter = 0; counter < programInUse.NumExpositions; counter++)
            {
                if (programInUse.FixPoint != "+" && programInUse.FixPoint != "o")
                {
                    // if program doesnt have a fix point, do nothing
                }
                else // if it uses fixPoint
                {
                    makingFixPoint();
                }
                
                await intervalTime(); // do this only first interval time, then it only does that within jobs
                
                //preparing execution
                expositionBackground(timingExposition);
                if (backWorkStatus == 0)
                {
                    this.CreateGraphics().Clear(ActiveForm.BackColor);
                    Console.WriteLine("Participante apertou o botão");
                }
                else if (backWorkStatus == 1)
                {
                    this.CreateGraphics().Clear(ActiveForm.BackColor);
                    Console.WriteLine("Participante não apertou o botão a tempo");
                }
                this.CreateGraphics().Clear(ActiveForm.BackColor);

            }
            cancellationTokenSource = null;
            Close();
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

        private async Task intervalTime()
        {
            int intervalTime = 200; // minimal rnd interval time

            // if random interval active, it will be a value between 200 and the defined interval time
            if (programInUse.IntervalTimeRandom && programInUse.IntervalTime > 200) 
            {
                Random random = new Random();
                intervalTime = random.Next(200, programInUse.IntervalTime);
            }
            else
            {
                intervalTime = programInUse.IntervalTime;
            }
            await Task.Delay(intervalTime);
            // if there is no fixPoint determination, just wait intervalTime
        }

        private void drawSquareShape()
        {
            int brush25 = 25;
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(programInUse.StimulusColor));
            Color newColor = ColorTranslator.FromHtml(programInUse.StimulusColor);
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            Graphics formGraphicsSquare = this.CreateGraphics();
            Random random = new Random();
            float[,] position = new float[4,2]{ { programInUse.StimulusDistance, 0 }, { 0, programInUse.StimulusDistance }, 
                                                { -programInUse.StimulusDistance, 0 }, { 0, -programInUse.StimulusDistance } };
            int index = random.Next(0, 3);
            float xSquare = (clientMiddle[0] - brush25) + position[index,0];
            float ySquare = (clientMiddle[1] - brush25) + position[index,1];
            float widthSquare = programInUse.StimuluSize;
            float heightSquare = programInUse.StimuluSize;

            formGraphicsSquare.FillRectangle(myBrush, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();
            
        }


        private void makingFixPoint()
        {
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(programInUse.FixPointColor));
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            int brush25 = 25;
            int brush4 = 4;

            switch (programInUse.FixPoint)
            {
                case "+": // cross fixPoint
                    Graphics formGraphicsCross1 = this.CreateGraphics();
                    Graphics formGraphicsCross2 = this.CreateGraphics();
                    float xCross1 = clientMiddle[0] - brush25;
                    float yCross1 = clientMiddle[1] - brush4;
                    float xCross2 = clientMiddle[0] - brush4;
                    float yCross2 = clientMiddle[1] - brush25;
                    float widthCross = 2 * brush25;
                    float heightCross = 2 * brush4;
                    formGraphicsCross1.FillRectangle(myBrush, xCross1, yCross1, widthCross, heightCross);
                    formGraphicsCross2.FillRectangle(myBrush, xCross2, yCross2, heightCross, widthCross);
                    formGraphicsCross1.Dispose();
                    formGraphicsCross2.Dispose();
                    break;
                case "o": // circle fixPoint
                    Graphics formGraphicsEllipse = this.CreateGraphics();
                    float xEllipse = clientMiddle[0] - brush25;
                    float yEllipse = clientMiddle[1] - brush25;
                    float widthEllipse = 2 * brush25;
                    float heightEllipse = 2 * brush25;
                    formGraphicsEllipse.FillEllipse(myBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
                    formGraphicsEllipse.Dispose();
                    break;
            }
            myBrush.Dispose();
        }

        private void repairProgram()
        {
            try
            {
                FormTRConfig configureProgram = new FormTRConfig(programInUse.ProgramName);
                configureProgram.Path = path;
                this.Controls.Add(configureProgram);
            }
            catch (Exception ex) { throw new Exception("Edição não pode ser feita " + ex.Message); }
        }

        private void exposition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (timingExposition.WorkerSupportsCancellation == true)
                {
                    timingExposition.CancelAsync();
                }
            }
        }

        private void expositionBackground(BackgroundWorker bw)
        {
            bw = new BackgroundWorker();
            backWorkStatus = 100;
            bw.DoWork += new DoWorkEventHandler(expositionBW_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(expositionBW_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(expositionBW_RunWorkerCompleted);
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void expositionBW_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            //startsExposition
            drawSquareShape();
            DateTime nowTime = DateTime.Now;
            DateTime finalTime = DateTime.Now.AddMilliseconds(programInUse.ExpositionTime);
            compareTimes = DateTime.Compare(nowTime, finalTime);
            while (compareTimes < 0)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    nowTime = DateTime.Now;
                    compareTimes = DateTime.Compare(nowTime, finalTime);
                }
            }
            worker.ReportProgress((100)); // work is done if reached here
        }

        private void expositionBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress = (e.ProgressPercentage.ToString() + "%");
        }

        private void expositionBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                backWorkStatus = 0; // the work was cancelled
            }

            else if (!(e.Error == null))
            {
                backWorkStatus = -1;
                //there was an error while doing work
            }

            else
            {
                backWorkStatus = 1;
                // the work was done without any trouble
            }
        }

        private void intervalBW_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int counter = 0; counter < programInUse.NumExpositions; counter++)
            {
                if (programInUse.FixPoint != "+" && programInUse.FixPoint != "o")
                {
                    // if program doesnt have a fix point, do nothing
                }
                else // if it uses fixPoint
                {
                    makingFixPoint();
                }

               // await intervalTime(); // do this only first interval time, then it only does that within jobs

                //preparing execution
                expositionBackground(timingExposition);
                if (backWorkStatus == 0)
                {
                    this.CreateGraphics().Clear(ActiveForm.BackColor);
                    Console.WriteLine("Participante apertou o botão");
                }
                else if (backWorkStatus == 1)
                {
                    this.CreateGraphics().Clear(ActiveForm.BackColor);
                    Console.WriteLine("Participante não apertou o botão a tempo");
                }
                this.CreateGraphics().Clear(ActiveForm.BackColor);

            }
            Close();
        }

        private void intervalBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void intervalBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
