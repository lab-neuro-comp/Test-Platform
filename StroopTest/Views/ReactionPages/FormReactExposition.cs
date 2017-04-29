using System;
using System.Collections.Generic;
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
        CancellationTokenSource cancellationTokenSource;


        public FormReactExposition(string prgName, string participantName, string defaultPath)
        {
            path = defaultPath + "/ReactionTestFiles/";
            outputDataPath = path + "/data";
            startTime = hour + "_" + minutes + "_" + seconds;
            programInUse.ProgramName = prgName;
            executingTest.ParticipantName = participantName;
            startExposition();
        }


        public void startExposition()
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
            Console.Write(programInUse.ExpositionType);
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
            var interval = Task.Run(async delegate {
                await Task.Delay(programInUse.IntervalTime,
                                  cancellationTokenSource.Token);
            });
            var exposition = Task.Run(async delegate {
                await Task.Delay(programInUse.ExpositionTime,
                                 cancellationTokenSource.Token);
            });
            try
            {
                await showInstructions(programInUse, cancellationTokenSource.Token);
                string printCount = "";
                while (true)
                {
                    elapsedTime = 0; // elapsed time to zero
                    //changeBackgroundColor(programInUse, true);
                    await Task.Delay(programInUse.IntervalTime, cancellationTokenSource.Token);
                    for (int counter = 0; counter < programInUse.NumExpositions; counter++)
                    {
                        await intervalTime();

                        //preparing execution
                        await drawSquareShape();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            // if there is no fixPoint determination, just wait intervalTime
            if (programInUse.FixPoint != "+" && programInUse.FixPoint != "o")
            {
                await Task.Delay(intervalTime);
            }
            else // if it uses fixPoint
            {
                await makingFixPoint(intervalTime);
            }

        }

        private async Task drawSquareShape()
        {
            int brush25 = 25;
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(programInUse.FixPointColor));
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            Graphics formGraphicsEllipse = this.CreateGraphics();
            float xEllipse = clientMiddle[0] - brush25 * programInUse.StimulusDistance / 10;
            float yEllipse = clientMiddle[1] - brush25 * programInUse.StimulusDistance / 10;
            float widthEllipse = 2 * brush25;
            float heightEllipse = 2 * brush25;
            formGraphicsEllipse.FillEllipse(myBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
            await Task.Delay(programInUse.ExpositionTime, cancellationTokenSource.Token);
            formGraphicsEllipse.Dispose();
        }


        private async Task makingFixPoint(int intervalTime)
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
                    await Task.Delay(intervalTime);
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
                    await Task.Delay(intervalTime);
                    formGraphicsEllipse.Dispose();
                    break;
            }
            myBrush.Dispose();
        }

        private void repairProgram()
        {
            try
            {
                FormTRConfig configureProgram = new FormTRConfig();
                configureProgram.Path = path;
                configureProgram.PrgName = "/" + programInUse.ProgramName;
                this.Controls.Add(configureProgram);
            }
            catch (Exception ex) { throw new Exception("Edição não pode ser feita " + ex.Message); }
        }

    }
}
