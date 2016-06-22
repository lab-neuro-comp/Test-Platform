/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;

// beginAudio
using NAudio.Wave;
using System.Collections.Generic;
// endAudio

namespace StroopTest
{
    public partial class FormExposition : Form
    {
        CancellationTokenSource cts;
        StroopProgram programInUse = new StroopProgram(); // programa em uso
        
        private static float elapsedTime; // tempo decorrido
        private string path;// = (Path.GetDirectoryName(Application.ExecutablePath) + "/StroopTestFiles/"); // caminho diretório
        private int instrAwaitTime = 4000;

        private List<string> outputContent;

        private string outputDataPath;

        // beginAudio
        private WaveIn waveSource = null; // entrada de áudio
        public WaveFileWriter waveFile = null; // arquivo salvar áudio
        // endAudio
        
        public FormExposition(string prgName, string usrName, string defaultFolderPath)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            InitializeComponent();
            path = defaultFolderPath + "/StroopTestFiles/";
            outputDataPath = defaultFolderPath + "/data/";
            programInUse.ProgramName = prgName;
            programInUse.UserName = usrName;
            startExpo();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\mywavfile.wav");
        player.Play();
        */

        private async void startExpo() // clique do botão define o programa a ser executado e inicia exposição
        {
            try
            {
                if (!File.Exists(path + "/prg/" + programInUse.ProgramName + ".prg")) { throw new Exception("Arquivo programa: " + programInUse.ProgramName + ".prg" + "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/")); } // confere existência do arquivo
                programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg");
                
                switch (programInUse.ExpositionType)
                {
                    case "txt":
                        await startWordExposition(programInUse);
                        break;
                    case "imgtxt":
                        await startImageExposition(programInUse);
                        break;
                    case "img":
                        await startImageExposition(programInUse);
                        break;
                    default:
                        throw new Exception("Tipo de Exposição: " + programInUse.ExpositionType + " inválido!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private async Task startWordExposition(StroopProgram program) // inicia exposição de palavra
        {
            cts = new CancellationTokenSource();

            wordLabel.Visible = false;
            wordLabel.Name = "error";
            wordLabel.FlatStyle = FlatStyle.Flat;
            wordLabel.Font = new Font("Microsoft Sans Serif", 160, FontStyle.Bold);
            wordLabel.TextAlign = ContentAlignment.MiddleCenter;
            wordLabel.AutoEllipsis = true;
            wordLabel.Dock = DockStyle.Fill;

            wordLabel.AutoSize = false;

            this.Controls.Add(this.wordLabel);
            this.BackColor = Color.White;

            string t1 = null, c1 = null;
            string outputFileName = "";

            Random rnd1 = new Random(DateTime.Now.Millisecond + 1); // cria duas randomizações a partir de sementes diferentes
            Random rnd2 = new Random(DateTime.Now.Millisecond + 2);

            var interval = Task.Run(async delegate{ await Task.Delay(program.IntervalTime, cts.Token); });

            var exposition = Task.Run(async delegate{ await Task.Delay(program.ExpositionTime, cts.Token); });
            
            outputContent = new List<string>();

            try
            {
                outputFileName = outputDataPath + program.UserName + "_" + program.ProgramName + ".txt";
                
                string[] labelText = program.readListFile(path + "/lst/" + program.WordsListFile); // vetor de strings recebem as listas de palavra e cor
                string[] labelColor = program.readListFile(path + "/lst/" + program.ColorsListFile);

                var cvt = new FontConverter();
                wordLabel.Font = cvt.ConvertFromString("Myriad Pro; " + program.FontWordLabel + "pt") as Font;

                foreach (string c in labelColor)
                {
                    if(!Regex.IsMatch(c, "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$"))
                    {
                        throw new Exception("A lista de cores '" + program.ColorsListFile + "' contém valores inválidos!\n" + c + " por exemplo não é um valor válido. A lista de cores deve conter apenas valores hexadecimais (ex: #000000)");
                    }
                }
                
                await showInstructions(program, cts.Token); // Apresenta instruções se houver
                
                while (true) // laço de repetição do programa até que o usuário decida não repetir mais o mesmo programa
                {
                    int i = 0, j = 0; // zera contadores para apresentação não randômica
                    
                    changeBackgroundColor(program, true); // muda cor de fundo se houver parametro                    
                    elapsedTime = 0; // zera tempo em milissegundos decorrido

                    // beginAudio
                    if (program.AudioCapture) { startRecordingAudio(program); } // inicia gravação áudio
                    // endAudio

                    await Task.Delay(program.IntervalTime, cts.Token);

                    for (int counter = 1; counter <= program.NumExpositions; counter++) // inicia loop com exposições
                    {
                        wordLabel.Visible = false; // intervalo
                        await intervalOrFixPoint(program, cts.Token);

                        if (program.ExpositionRandom) // se for exposição aleatoria
                        {
                            t1 = labelText[rnd1.Next(labelText.Length)]; // randomiza listas
                            c1 = labelColor[rnd2.Next(labelColor.Length)];
                        }
                        else // se for exposição sequencial
                        {
                            t1 = labelText[i];
                            c1 = labelColor[j];
                            if(i == labelText.Length - 1) { i = 0; }
                            else { i++; }
                            if (j == labelColor.Length - 1) { j = 0; }
                            else { j++; }
                        }
                        wordLabel.Text = t1;
                        wordLabel.ForeColor = ColorTranslator.FromHtml(c1);
                        wordLabel.Left = (this.ClientSize.Width - wordLabel.Width) / 2;
                        wordLabel.Top = (this.ClientSize.Height - wordLabel.Height) / 2;

                        elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                        SendKeys.SendWait("s");
                        wordLabel.Visible = true;

                        StroopProgram.writeLineOutput(program, t1, c1, counter, outputContent, elapsedTime);
                        
                        await Task.Delay(program.ExpositionTime, cts.Token);
                    }
                    
                    wordLabel.Visible = false;
                    await Task.Delay(program.IntervalTime, cts.Token);

                    // beginAudio
                    if (program.AudioCapture) { startRecordingAudio(program); } // inicia gravação áudio
                    // endAudio
                    changeBackgroundColor(program, false); // retorna à cor de fundo padrão

                    break;
                    /*
                    DialogResult dialogResult = MessageBox.Show("Deseja repetir o teste?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa
                    if (dialogResult == DialogResult.Yes) { MessageBox.Show("O teste será repetido!"); } // se deseja repetir o programa mantém o laço while
                    if (dialogResult == DialogResult.No) { break; } // se não deseja repetir quebra o laço
                    */
            }
                StroopProgram.writeOutputFile(outputFileName, string.Join("\n", outputContent.ToArray()));
                Close(); // finaliza exposição após execução
            }
            catch(TaskCanceledException)
            {
                StroopProgram.writeOutputFile(outputFileName, string.Join("\n", outputContent.ToArray()));
                throw new Exception("A Exposição '" + program.ProgramName + "' foi cancelada!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cts = null;
        }
        
        private async Task startImageExposition(StroopProgram program) // inicia exposição de imagem
        {
            cts = new CancellationTokenSource();
            int i, j, k;
            string[] labelText = null, imageDirs = null, audioDirs = null, subtitlesArray = null;
            string outputFileName = "";
            this.BackColor = Color.White;



            try
            {
                outputFileName = outputDataPath + program.UserName + "_" + program.ProgramName + ".txt";

                if (program.ExpandImage) { pictureBox1.Dock = DockStyle.Fill; }
                else { pictureBox1.Dock = DockStyle.None; }
                var cvt = new FontConverter();
                Font f = cvt.ConvertFromString("Myriad Pro; " + program.FontWordLabel + "pt") as Font;
                this.wordLabel.Font = f;
                wordLabel.ForeColor = Color.Red;

                imageDirs = StroopProgram.readDirListFile(path + "/lst/" + program.ImagesListFile);

                if (program.SubtitleShow)
                {
                    subtitlesArray = program.readListFile(path + "/lst/" + program.SubtitlesListFile);
                    subtitleLabel.ForeColor = ColorTranslator.FromHtml(program.SubtitleColor);
                    subtitleLabel.Enabled = true;
                }

                if (program.AudioListFile != "false") { audioDirs = StroopProgram.readDirListFile(path + "/lst/" + program.AudioListFile); }

                string auxString = "";

                if (program.WordsListFile.ToLower() != "false") { labelText = program.readListFile(path + "/lst/" + program.WordsListFile); }
                
                Random rnd = new Random(DateTime.Now.Millisecond + 1);
                Random rnd2 = new Random(DateTime.Now.Millisecond + 2);
                Random rnd3 = new Random(DateTime.Now.Millisecond + 3);
                var randomNumbers = Enumerable.Range(0, imageDirs.Count()).OrderBy(x => rnd3.Next()).ToList(); // evita repetição no aleatorio de imagens

                await showInstructions(program, cts.Token); // Apresenta instruções se houver

                outputContent = new List<string>();

                while (true)
                {
                    changeBackgroundColor(program, true); // muda cor de fundo se houver parametro
                    
                    elapsedTime = 0; // zera tempo em milissegundos decorrido
                    i = 0; j = 0; k = 0;

                    // beginAudio
                    if (program.AudioCapture) { startRecordingAudio(program); } // inicia gravação áudio
                    // endAudio

                    await Task.Delay(program.IntervalTime, cts.Token);

                    if (program.ExpositionType == "imgtxt")
                    {
                        for (int counter = 0; counter < program.NumExpositions; counter++) // AQUI ver estinulo -> palavra ou imagem como um só e ter intervalo separado
                        {
                            if (counter == imageDirs.Count()) { counter = 0; }
                            pictureBox1.Visible = false; wordLabel.Visible = false;
                            if (program.SubtitleShow)
                            {
                                subtitleLabel.Visible = false;
                            }
                            await intervalOrFixPoint(program, cts.Token);

                            if (counter % 2 == 0)
                            {
                                if (program.ExpositionRandom == true)
                                {
                                    if(imageDirs.Count() <= program.NumExpositions)
                                    {
                                        pictureBox1.Image = Image.FromFile(imageDirs[randomNumbers[i++]]); // aleatorio que não repete imagens se numero de estimulos for = numero de apresentacoes
                                    }
                                    else
                                    {
                                        pictureBox1.Image = Image.FromFile(imageDirs[rnd.Next(imageDirs.Length)]); // aleatorio que não repete imagens se numero de estimulos for = numero de apresentacoes
                                    }
                                }
                                else
                                {
                                    if (i == imageDirs.Count()) { i = 0; }
                                    pictureBox1.Image = Image.FromFile(imageDirs[i]);
                                }
                                //elapsedTime = elapsedTimeExpo + elapsedTime;
                                elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                                SendKeys.SendWait("s");
                                pictureBox1.Visible = true;
                                wordLabel.Visible = false;
                                auxString = Path.GetFileName(imageDirs[i].ToString());
                                i++;
                            }
                            else
                            {
                                if (program.WordsListFile.ToLower() != "false") // se tiver palavras intercala elas com a imagem
                                {
                                    if (j == labelText.Count()) { j = 0; }
                                    wordLabel.Text = labelText[j];

                                    wordLabel.Left = (this.ClientSize.Width - wordLabel.Width) / 2;
                                    wordLabel.Top = (this.ClientSize.Height - wordLabel.Height) / 2;

                                    elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                                    SendKeys.SendWait("s");
                                    pictureBox1.Visible = false;
                                    wordLabel.Visible = true;
                                    auxString = wordLabel.Text;
                                    j++;
                                }
                            }


                            subtitleLabel.Location = new Point((ClientSize.Width / 2 - subtitleLabel.Width / 2), pictureBox1.Bottom + 50);
                            StroopProgram.writeLineOutput(program, auxString, "false", counter + 1, outputContent, elapsedTime);
                            await Task.Delay(program.ExpositionTime, cts.Token);
                        }
                    }
                    else
                    {
                        for (int counter = 0; counter < program.NumExpositions; counter++) // AQUI ver estinulo -> palavra ou imagem como um só e ter intervalo separado
                        {
                            if (counter == imageDirs.Count()) { counter = 0; }
                            pictureBox1.Visible = false; wordLabel.Visible = false;
                            if (program.SubtitleShow)
                            {
                                subtitleLabel.Visible = false;
                            }
                            await intervalOrFixPoint(program, cts.Token);

                            if (program.ExpositionRandom == true)
                            {
                                if (imageDirs.Count() <= program.NumExpositions)
                                {
                                    pictureBox1.Image = Image.FromFile(imageDirs[randomNumbers[i++]]); // aleatorio que não repete imagens se numero de estimulos for = numero de apresentacoes
                                }
                                else
                                {
                                    pictureBox1.Image = Image.FromFile(imageDirs[rnd.Next(imageDirs.Length)]); // aleatorio que não repete imagens se numero de estimulos for = numero de apresentacoes
                                }
                            }
                            else
                            {
                                if (i == imageDirs.Count()) { i = 0; }
                                pictureBox1.Image = Image.FromFile(imageDirs[i]);
                            }
                            
                            elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                            SendKeys.SendWait("s");
                            pictureBox1.Visible = true;

                            if (program.SubtitleShow)
                            {
                                subtitleLabel.Visible = true;
                                subtitleLabel.Text = subtitlesArray[k];
                                if (k == (subtitlesArray.Count() - 1)) k = 0;
                                else k++;
                            }

                            StroopProgram.writeLineOutput(program, Path.GetFileName(imageDirs[i].ToString()), "false", counter + 1, outputContent, elapsedTime);
                            i++;


                            subtitleLabel.Location = new Point((ClientSize.Width / 2 - subtitleLabel.Width / 2), pictureBox1.Bottom + 50);
                            await Task.Delay(program.ExpositionTime, cts.Token);
                            //g = Graphics.FromImage(pictureBox1.Image);
                            //showSubtitle(program, g, counter);
                        }
                    }
                    
                    pictureBox1.Visible = false; wordLabel.Visible = false;
                    if (program.SubtitleShow)
                    {
                        subtitleLabel.Visible = false;
                    }

                    await Task.Delay(program.IntervalTime, cts.Token);

                    // beginAudio
                    if (program.AudioCapture) { startRecordingAudio(program); } // inicia gravação áudio
                    // endAudio

                    changeBackgroundColor(program, false); // retorna à cor de fundo padrão

                    break;
                    /*
                    DialogResult dialogResult = MessageBox.Show("Deseja repetir o teste?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa

                    if (dialogResult == DialogResult.Yes) { MessageBox.Show("O teste será repetido!"); } // se deseja repetir o programa mantém o laço while
                    if (dialogResult == DialogResult.No) { break; } // se não deseja repetir quebra o laço
                    */
                }
                pictureBox1.Dock = DockStyle.None;
                wordLabel.Font = new Font("Microsoft Sans Serif", 160);
                wordLabel.ForeColor = Color.Black;
                StroopProgram.writeOutputFile(outputFileName, string.Join("\n", outputContent.ToArray()));
                Close();
            }
            catch (TaskCanceledException)
            {
                StroopProgram.writeOutputFile(outputFileName, string.Join("\n", outputContent.ToArray()));
                throw new Exception("A Exposição '" + program.ProgramName + "' foi cancelada!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cts = null;
        }
        
        /*
        private void showImageInPanel(StroopProgram program, Graphics g, int index)
        {
            if (program.ExpandImage)
            {
                program.SubtitlePlace = 0;
            }

            string[] labelText = program.readListFile(path + "/lst/" + "padrao_Words.lst");

            panel1.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                PointF locationToDraw = new PointF();

                SizeF textSize = e.Graphics.MeasureString(labelText[index], Font, 60);

                switch (program.SubtitlePlace)
                {
                    case 1: //baixo
                        locationToDraw.X = ClientSize.Width / 2 - textSize.Width / 2;
                        locationToDraw.Y = panel1.Location.Y + panel1.Height + 50;
                        break;
                    case 2: //esquerda
                        locationToDraw.X = panel1.Location.X - (textSize.Width + 50);
                        locationToDraw.Y = ClientSize.Height / 2 - textSize.Height / 2;
                        break;
                    case 3: //direita
                        locationToDraw.X = panel1.Location.X + panel1.Width + 50;
                        locationToDraw.Y = ClientSize.Height / 2 - textSize.Height / 2;
                        break;
                    case 4: // cima
                        locationToDraw.X = panel1.Location.Y - (textSize.Height + 50);
                        locationToDraw.Y = ClientSize.Width / 2 - textSize.Width / 2;
                        break;
                    default: // centro
                        locationToDraw.X = ClientSize.Width / 2 - textSize.Width / 2;
                        locationToDraw.Y = ClientSize.Height / 2 - textSize.Height / 2;
                        break;
                }

                e.Graphics.DrawString(labelText[index], Font, Brushes.Black, locationToDraw);
            });
        }
        */

        private async Task showInstructions(StroopProgram program, CancellationToken token) // apresenta instruções
        {
            if (program.InstructionText != null)
            {
                instructionLabel.Enabled = true; instructionLabel.Visible = true;
                for (int i = 0; i < program.InstructionText.Count; i++)
                {
                    instructionLabel.Text = program.InstructionText[i];
                    await Task.Delay(instrAwaitTime);
                }
                instructionLabel.Enabled = false; instructionLabel.Visible = false;
            }
        }

        private void changeBackgroundColor(StroopProgram program, bool flag) // muda cor de fundo
        {
            if (flag && program.BackgroundColor.ToLower() != "false")
            { 
                    this.BackColor = ColorTranslator.FromHtml(program.BackgroundColor);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        // beginAudio
        private void startRecordingAudio(StroopProgram program)
        {
            int waveInDevices = WaveIn.DeviceCount;
            if(waveInDevices != 0)
            {
                string now = program.InitialDate.Day + "." + program.InitialDate.Month + "_" + DateTime.Now.Hour.ToString() + "h" + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString();

                waveSource = new WaveIn();
                waveSource.WaveFormat = new WaveFormat(44100, 1);

                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

                waveFile = new WaveFileWriter(outputDataPath + "/audio_" + program.UserName + "_" + program.ProgramName + "_" + now + ".wav", waveSource.WaveFormat);

                waveSource.StartRecording();
            }
        } // inicia gravação de áudio

        private void stopRecordingAudio()
        {
            waveSource.StopRecording();
        } // para gravação de áudio

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        } 

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }
            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }
        // endAudio
        
        private async Task intervalOrFixPoint(StroopProgram program, CancellationToken token)
        {
            try
            {
                if (program.FixPoint != "+" && program.FixPoint != "o")
                {
                    await Task.Delay(program.IntervalTime);
                }
                else
                {
                    SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml("#D01C1F"));
                    switch (program.FixPoint)
                    {
                        case "+":
                            Graphics formGraphicsCross1 = this.CreateGraphics();
                            Graphics formGraphicsCross2 = this.CreateGraphics();
                            float xCross1 = ClientSize.Width / 2 - 25;
                            float yCross1 = ClientSize.Height / 2 - 4;
                            float xCross2 = ClientSize.Width / 2 - 4;
                            float yCross2 = ClientSize.Height / 2 - 25;
                            float widthCross = 2 * 25;
                            float heightCross = 2 * 4;
                            formGraphicsCross1.FillRectangle(myBrush, xCross1, yCross1, widthCross, heightCross);
                            formGraphicsCross2.FillRectangle(myBrush, xCross2, yCross2, heightCross, widthCross);
                            await Task.Delay(program.IntervalTime);
                            formGraphicsCross1.Dispose();
                            formGraphicsCross2.Dispose();
                            break;
                        case "o":
                            Graphics formGraphicsEllipse = this.CreateGraphics();
                            float xEllipse = ClientSize.Width / 2 - 25;
                            float yEllipse = ClientSize.Height / 2 - 25;
                            float widthEllipse = 2 * 25;
                            float heightEllipse = 2 * 25;
                            formGraphicsEllipse.FillEllipse(myBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
                            await Task.Delay(program.IntervalTime);
                            formGraphicsEllipse.Dispose();
                            break;
                    }
                    myBrush.Dispose();
                }
            }
            catch
            {
                this.Close();
            }
        }
        
        private void FormExposition_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(cts != null)
                cts.Cancel();
        }
    }
}
