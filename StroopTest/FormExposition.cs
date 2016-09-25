/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

// beginAudio
using NAudio.Wave;
using System.Collections.Generic;
using System.Media;
// endAudio 

namespace StroopTest
{
    public partial class FormExposition : Form
    {
        CancellationTokenSource cts;
        StroopProgram programInUse = new StroopProgram(); // programa em uso
        
        private static float elapsedTime; // tempo decorrido
        private string path; // = (Path.GetDirectoryName(Application.ExecutablePath) + "/StroopTestFiles/"); // caminho diretório

        private List<string> outputContent;

        private string outputDataPath;

        // beginAudio
        private WaveIn waveSource = null; // entrada de áudio
        public WaveFileWriter waveFile = null; // arquivo salvar áudio
        // endAudio

        //playAudio
        private SoundPlayer Player = new SoundPlayer();

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

        private async void startExpo() // clique do botão define o programa a ser executado e inicia exposição
        {
            try
            {
                if (!File.Exists(path + "/prg/" + programInUse.ProgramName + ".prg")) { throw new Exception("Arquivo programa: " + programInUse.ProgramName + ".prg" + "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/")); } // confere existência do arquivo
                programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg");

                if (programInUse.NeedsEdition)
                {
                    MessageBox.Show("O programa contém parâmetros incorretos e/ou está incompleto!\nCorrija o programa na interface a seguir.");
                    repairProgram(programInUse, path);
                    programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg");
                }

                var cvt = new FontConverter();
                wordLabel.Font = cvt.ConvertFromString(wordLabel.Font.FontFamily + ";" + programInUse.FontWordLabel + "pt") as Font;
                wordLabel.Visible = false;
                wordLabel.Name = "error";
                wordLabel.FlatStyle = FlatStyle.Flat;
                wordLabel.TextAlign = ContentAlignment.MiddleCenter;
                wordLabel.AutoEllipsis = true;
                wordLabel.Dock = DockStyle.Fill;
                wordLabel.AutoSize = false;

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
                    case "txtaud":
                        await startWordExposition(programInUse);
                        break;
                    case "imgaud":
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

        private void repairProgram(StroopProgram program, string path)
        {
            FormPrgConfig configureProgram;

            try
            {
                    configureProgram = new FormPrgConfig(path, "/" + programInUse.ProgramName);
                    configureProgram.ShowDialog();
            }
            catch (Exception ex) { throw new Exception("Edição não pode ser feita " + ex.Message); }
        }

        private async Task startWordExposition(StroopProgram program) // inicia exposição de palavra
        {
            cts = new CancellationTokenSource();
            
            Controls.Add(this.wordLabel);
            BackColor = Color.White;

            string textCurrent = null, colorCurrent = null;
            int textArrayCounter = 0, colorArrayCounter = 0;
            string outputFileName = "";
            
            var interval = Task.Run(async delegate{ await Task.Delay(program.IntervalTime, cts.Token); });
            var exposition = Task.Run(async delegate{ await Task.Delay(program.ExpositionTime, cts.Token); });
            outputContent = new List<string>();

            string[] labelText = null, labelColor = null, audioDirs = null;
            int audioCounter = 0;

            string audioDetail = "false";

            try
            {
                outputFileName = outputDataPath + program.UserName + "_" + program.ProgramName + ".txt";

                // Define vetor de estímulos a ser apresentado

                labelText = program.readListFile(path + "/lst/" + program.WordsListFile); // vetor de strings recebem as listas de palavra e cor
                labelColor = program.readListFile(path + "/lst/" + program.ColorsListFile);
                
                if (program.AudioListFile != "false")
                {
                    audioDirs = StroopProgram.readDirListFile(path + "/lst/" + program.AudioListFile);
                    if (program.ExpositionRandom)
                    {
                        audioDirs = shuffleArray(audioDirs, program.NumExpositions, 6);
                    }
                }

                if (program.ExpositionRandom) // se exposição aleatória, randomiza itens de acordo com o numero de estimulos
                {
                    labelText = shuffleArray(labelText, program.NumExpositions, 1);
                    labelColor = shuffleArray(labelColor, program.NumExpositions, 5);
                }
                
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
                    textArrayCounter = 0; // zera contadores
                    colorArrayCounter = 0;

                    changeBackgroundColor(program, true); // muda cor de fundo se houver parametro                    
                    elapsedTime = 0; // zera tempo em milissegundos decorrido

                    // beginAudio
                    if (program.AudioCapture && program.ExpositionType != "txtaud") { startRecordingAudio(program); } // inicia gravação áudio
                    // endAudio

                    await Task.Delay(program.IntervalTime, cts.Token);

                    for (int counter = 1; counter <= program.NumExpositions; counter++) // inicia loop com exposições
                    {
                        wordLabel.Visible = false; // intervalo
                        await intervalOrFixPoint(program, cts.Token);

                        textCurrent = labelText[textArrayCounter];
                        colorCurrent = labelColor[colorArrayCounter];
                        
                        if (textArrayCounter == labelText.Count()-1) { textArrayCounter = 0; }
                        else textArrayCounter++;
                        if (colorArrayCounter == labelColor.Count()-1) { colorArrayCounter = 0; }
                        else colorArrayCounter++;

                        wordLabel.Text = textCurrent;
                        wordLabel.ForeColor = ColorTranslator.FromHtml(colorCurrent);
                        wordLabel.Left = (this.ClientSize.Width - wordLabel.Width) / 2; // centraliza label da palavra
                        wordLabel.Top = (this.ClientSize.Height - wordLabel.Height) / 2;
                        
                        if (program.AudioListFile.ToLower() != "false" && program.ExpositionType == "txtaud") // reproduz audio
                        {
                            if (audioCounter == audioDirs.Length) { audioCounter = 0; }
                            audioDetail = audioDirs[audioCounter];
                            Player.SoundLocation = audioDetail;
                            audioCounter++;
                            Player.Play();
                        }

                        elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                        SendKeys.SendWait("s");
                        wordLabel.Visible = true;

                        StroopProgram.writeLineOutput(program, textCurrent, colorCurrent, counter, outputContent, elapsedTime, program.ExpositionType, Path.GetFileNameWithoutExtension(audioDetail));
                        
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
            int j, k;
            int arrayCounter = 0;
            string[] labelText = null, imageDirs = null, audioDirs = null, subtitlesArray = null;
            string outputFileName = "";
            string actualImagePath = "";
            this.BackColor = Color.White;
            string audioDetail = "false";
            

            //audioDirs = StroopProgram.readDirListFile(path + "/lst/" + program.AudioListFile); // auxiliar recebe o vetor original
            
            try
            {
                wordLabel.ForeColor = Color.Red;

                outputFileName = outputDataPath + program.UserName + "_" + program.ProgramName + ".txt";
                
                if (program.ExpandImage) { pictureBox1.Dock = DockStyle.Fill; }
                else { pictureBox1.Dock = DockStyle.None; }

                // Define vetor de estímulos a ser apresentado
                //audioDirs = StroopProgram.readDirListFile(path + "/lst/" + program.AudioListFile); // auxiliar recebe o vetor original
                imageDirs = StroopProgram.readDirListFile(path + "/lst/" + program.ImagesListFile); // auxiliar recebe o vetor original
                if (program.ExpositionRandom) // se exposição aleatória, randomiza itens de acordo com o numero de estimulos
                {
                    imageDirs = shuffleArray(imageDirs, program.NumExpositions, 3);
                }
                
                if (program.SubtitleShow)
                {
                    subtitlesArray = program.readListFile(path + "/lst/" + program.SubtitlesListFile);
                    if(program.SubtitleColor.ToLower() != "false")
                    {
                        subtitleLabel.ForeColor = ColorTranslator.FromHtml(program.SubtitleColor);
                    } else
                    {
                        subtitleLabel.ForeColor = Color.Black;
                    }
                    subtitleLabel.Enabled = true;
                    subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2; // centraliza label da palavra
                    subtitleLabel.Top = (pictureBox1.Bottom + 50);
                }

                if (program.AudioListFile != "false")
                {
                    audioDirs = StroopProgram.readDirListFile(path + "/lst/" + program.AudioListFile);
                    if (program.ExpositionRandom)
                    {
                        audioDirs = shuffleArray(audioDirs, program.NumExpositions, 6);
                    }
                }
                if (program.WordsListFile.ToLower() != "false") { labelText = program.readListFile(path + "/lst/" + program.WordsListFile); }
                
                await showInstructions(program, cts.Token); // Apresenta instruções se houver

                outputContent = new List<string>();
                
                while (true)
                {

                    changeBackgroundColor(program, true); // muda cor de fundo se houver parametro
                    pictureBox1.BackColor = BackColor;

                    elapsedTime = 0; // zera tempo em milissegundos decorrido
                    j = 0; k = 0;
                    arrayCounter = 0;
                    var audioCounter = 0;

                    // beginAudio
                    if (program.AudioCapture && program.ExpositionType != "txtaud") { startRecordingAudio(program); } // inicia gravação áudio
                    // endAudio

                    await Task.Delay(program.IntervalTime, cts.Token);
                    

                    if (program.ExpositionType == "imgtxt")
                    {
                        for (int counter = 0; counter < program.NumExpositions; counter++) // AQUI ver estimulo -> palavra ou imagem como um só e ter intervalo separado
                        {
                            pictureBox1.Visible = false; wordLabel.Visible = false;
                            if (program.SubtitleShow) {subtitleLabel.Visible = false;}
                            await intervalOrFixPoint(program, cts.Token);

                            if (arrayCounter == imageDirs.Count()-1) { arrayCounter = 0; }
                            pictureBox1.Image = Image.FromFile(imageDirs[arrayCounter]);
                            
                            elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                            SendKeys.SendWait("s");
                            pictureBox1.Visible = true;
                            wordLabel.Visible = false;
                            actualImagePath = Path.GetFileName(imageDirs[arrayCounter].ToString());
                            arrayCounter++;

                            if (program.SubtitleShow)
                            {
                                subtitleLabel.Visible = true;
                                subtitleLabel.Text = subtitlesArray[k];
                                defineSubPosition(program.SubtitlePlace);
                                if (k == (subtitlesArray.Count() - 1)) k = 0;
                                else k++;
                            }

                            StroopProgram.writeLineOutput(program, actualImagePath, "false", counter + 1, outputContent, elapsedTime, "img", audioDetail);
                            await Task.Delay(program.ExpositionTime, cts.Token);

                            pictureBox1.Visible = false;
                            wordLabel.Visible = false;

                            await Task.Delay(program.IntervalTime, cts.Token);

                            if (program.WordsListFile.ToLower() != "false") // se tiver palavras intercala elas com a imagem
                            {
                                if (j == labelText.Count()-1) { j = 0; }
                                wordLabel.Text = labelText[j];

                                wordLabel.Left = (this.ClientSize.Width - wordLabel.Width) / 2;
                                wordLabel.Top = (this.ClientSize.Height - wordLabel.Height) / 2;
                                
                                elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                                SendKeys.SendWait("s");
                                pictureBox1.Visible = false;
                                wordLabel.Visible = true;
                                actualImagePath = wordLabel.Text;
                                j++;

                                StroopProgram.writeLineOutput(program, actualImagePath, "false", counter + 1, outputContent, elapsedTime, "txt", audioDetail);
                                await Task.Delay(program.ExpositionTime, cts.Token);
                            }
                        }
                    }
                    else
                    {
                        int imgCounter = 0;
                        for (int counter = 0; counter < program.NumExpositions; counter++) // AQUI ver estinulo -> palavra ou imagem como um só e ter intervalo separado
                        {
                            pictureBox1.Visible = false; wordLabel.Visible = false;
                            if (program.SubtitleShow) { subtitleLabel.Visible = false; }
                            await intervalOrFixPoint(program, cts.Token);


                            if (imgCounter == imageDirs.Count()-1) { imgCounter = 0; }
                            pictureBox1.Image = Image.FromFile(imageDirs[imgCounter]);
                            
                            
                            if (program.AudioListFile.ToLower() != "false" && program.ExpositionType == "imgaud")
                            {
                                if (audioCounter == audioDirs.Length) { audioCounter = 0; }
                                audioDetail = audioDirs[audioCounter];
                                Player.SoundLocation = audioDetail;
                                audioCounter++;
                                Player.Play();
                            }
                            
                            elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                            SendKeys.SendWait("s");

                            pictureBox1.Visible = true;

                            if (program.SubtitleShow)
                            {
                                subtitleLabel.Visible = true;
                                subtitleLabel.Text = subtitlesArray[k];
                                defineSubPosition(program.SubtitlePlace);
                                if (k == (subtitlesArray.Count() - 1)) k = 0;
                                else k++;
                            }

                            StroopProgram.writeLineOutput(program, Path.GetFileName(imageDirs[imgCounter].ToString()), "false", counter + 1, outputContent, elapsedTime, program.ExpositionType, Path.GetFileNameWithoutExtension(audioDetail));
                            imgCounter++;
                            
                            //subtitleLabel.Location = new Point((ClientSize.Width / 2 - subtitleLabel.Width / 2), pictureBox1.Bottom + 50);
                            await Task.Delay(program.ExpositionTime, cts.Token);
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
                wordLabel.Font = new Font(wordLabel.Font.FontFamily, 160);
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

        private void defineSubPosition(int subtitleLocation)
        {
            switch (subtitleLocation)
            {
                case 1: //baixo
                    subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2;
                    subtitleLabel.Top = (pictureBox1.Bottom + 50);
                    break;
                case 2: //esquerda
                    subtitleLabel.Left = (pictureBox1.Left - (subtitleLabel.Width + 50));
                    subtitleLabel.Top = (this.ClientSize.Height - subtitleLabel.Height) / 2;
                    break;
                case 3: //direita
                    subtitleLabel.Left = (pictureBox1.Left + pictureBox1.Width + 50);
                    subtitleLabel.Top = (this.ClientSize.Height - subtitleLabel.Height) / 2;
                    break;
                case 4: // cima
                    subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2;
                    subtitleLabel.Top = (pictureBox1.Top - (subtitleLabel.Height + 50));
                    break;
                default: // centro
                    subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2;
                    subtitleLabel.Top = (this.ClientSize.Height - subtitleLabel.Height) / 2;
                    break;
            }

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

        private string[] shuffleArray(string[] array, int expectedLength, int rndSeed) // randomiza Vetor - parâmetros: vetor / tamanho esperado do vetor randomizado
        {
            List<string> randomArray = new List<string>();
            Random rnd = new Random(DateTime.Now.Millisecond + expectedLength + rndSeed);
            try
            {
                if (expectedLength == array.Count()) // se pretende-se manter o mesmo tamanho do vetor, não há repetições
                {
                    randomArray = array.OrderBy(x => rnd.Next()).ToList();
                }
                else
                {
                    for (int i = 0; i < expectedLength; i++) // se não o vetor aleatório será preenchido com valores aleatórios do original, podendo haver repetições
                    {
                        randomArray.Add(array[rnd.Next(array.Length)]);
                    }
                }
                return randomArray.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na randomização da lista de estímulos:\n" + ex.Message);
            }
        }

        private async Task showInstructions(StroopProgram program, CancellationToken token) // apresenta instruções
        {
            if (program.InstructionText != null)
            {
                instructionLabel.Enabled = true; instructionLabel.Visible = true;
                for (int i = 0; i < program.InstructionText.Count; i++)
                {
                    instructionLabel.Text = program.InstructionText[i];
                    await Task.Delay(StroopProgram.instructionAwaitTime);
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
            if (waveFile == null) return;
            waveFile.Write(e.Buffer, 0, e.BytesRecorded);
            waveFile.Flush();
        } 

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.StopRecording();
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
                int intervalTime = 400;

                if (program.IntervalTimeRandom && program.IntervalTime > 400)
                {
                    Random random = new Random();
                    intervalTime = random.Next(400, program.IntervalTime);
                }
                else
                {
                    intervalTime = program.IntervalTime;
                }

                if (program.FixPoint != "+" && program.FixPoint != "o")
                {
                    await Task.Delay(intervalTime);
                }
                else
                {
                    if (program.FixPointColor == "false") { program.FixPointColor = "#D01C1F"; }
                    SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(program.FixPointColor));

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
                            await Task.Delay(intervalTime);
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
                            await Task.Delay(intervalTime);
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
