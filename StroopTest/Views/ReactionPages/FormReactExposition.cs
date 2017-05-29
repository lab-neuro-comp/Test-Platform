﻿using System;
using System.ComponentModel;
using System.Diagnostics;
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
        ReactionTest executingTest = new ReactionTest();
        private string path;                           
        private string outputDataPath;                
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private string outputFile;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private int intervalElapsedTime;
        private Stopwatch hitStopWatch = new Stopwatch();
        private int currentExposition = 0;

        public FormReactExposition(string prgName, string participantName, string defaultPath)
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



        private void drawSquareShape()
        {
            int brush25 = 25;
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor));
            Color newColor = ColorTranslator.FromHtml(executingTest.ProgramInUse.StimulusColor);
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            Graphics formGraphicsSquare = CreateGraphics();
            Random random = new Random();
            float[,] position = new float[4,2]{ { executingTest.ProgramInUse.StimulusDistance * 0.75f, 0 }, { 0, executingTest.ProgramInUse.StimulusDistance * 0.75f}, 
                                                { -executingTest.ProgramInUse.StimulusDistance * 0.75f, 0 }, { 0, -executingTest.ProgramInUse.StimulusDistance * 0.75f } };
            int index = random.Next(0, 3);
            float xSquare = (clientMiddle[0] - brush25) + position[index,0];
            float ySquare = (clientMiddle[1] - brush25) + position[index,1];
            float widthSquare = executingTest.ProgramInUse.StimuluSize;
            float heightSquare = executingTest.ProgramInUse.StimuluSize;

            formGraphicsSquare.FillRectangle(myBrush, xSquare, ySquare, widthSquare, heightSquare);
            formGraphicsSquare.Dispose();
            
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
            else if (e.KeyCode == Keys.K)
            {
                Close();
            }
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

        private void showStimulus()
        {
            switch (executingTest.ProgramInUse.ExpositionType)
            {
                case "Formas":
                    drawSquareShape();
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

            intervalElapsedTime = ExpositionsViews.waitTime(executingTest.ProgramInUse.IntervalTimeRandom, 
                executingTest.ProgramInUse.IntervalTime);

            /*starts Exposition*/
            hitStopWatch = new Stopwatch();
            hitStopWatch.Start();

            showStimulus();
            

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

        private void expositionBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(currentExposition);
        }

        private void expositionBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CreateGraphics().Clear(ActiveForm.BackColor);
            ExpositionsViews.makingFixPoint(executingTest.ProgramInUse.FixPoint,executingTest.ProgramInUse.FixPointColor,
                this);
            if ((e.Cancelled == true))
            {
                executingTest.writeLineOutput(intervalElapsedTime, hitStopWatch.ElapsedMilliseconds,
                                              currentExposition);
            }

            else if (!(e.Error == null))
            {
                //there was an error while doing work
            }
            else
            {
                executingTest.writeLineOutput(intervalElapsedTime, 0, currentExposition);
                hitStopWatch.Stop();
                // the work was done without any trouble, person missed exposition
            }
            expositionBW.Dispose();
        }

        private void intervalBW_DoWork(object sender, DoWorkEventArgs e)
        {
            ExpositionsViews.makingFixPoint(executingTest.ProgramInUse.FixPoint, executingTest.ProgramInUse.FixPointColor,
                this);
            executingTest.InitialTime = DateTime.Now;
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
    }
}
