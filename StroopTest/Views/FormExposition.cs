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


using NAudio.Wave;
using System.Collections.Generic;
using System.Media;
using System.Drawing.Drawing2D;
using StroopTest.Models;


namespace StroopTest
{
    public partial class FormExposition : Form
    {
        CancellationTokenSource cts;
        StroopProgram programInUse = new StroopProgram(); // program in current use
        private static float elapsedTime;                // elapsed time during each item exposition
        private string path;                            // global program path
        private List<string> outputContent;            // output file content
        private string outputDataPath;                // output file Path
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        // beginAudio
        private WaveIn waveSource = null;       // audio input
        public WaveFileWriter waveFile = null; // writer audio file
        // endAudio
        
        private SoundPlayer Player = new SoundPlayer(); // audio player

        public FormExposition(string prgName, string usrName, string defaultFolderPath)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
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

        private async void startExpo() // starts Exposition
        {
            try
            {
                if (!File.Exists(path + "/prg/" + programInUse.ProgramName + ".prg")) { throw new Exception("Arquivo programa: " + programInUse.ProgramName + ".prg" + "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/")); } // confere existência do arquivo
                programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg"); // reads program into programInUse

                if (programInUse.NeedsEdition) // if program is incomplete
                {
                    MessageBox.Show("O programa contém parâmetros incorretos e/ou está incompleto!\nCorrija o programa na interface a seguir.");
                    repairProgram(programInUse, path); // opens prgConfig for program edition
                    programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg"); // reads new program
                }

                wordLabel.Name = "error";
                wordLabel.Visible = false;
                wordLabel.FlatStyle = FlatStyle.Flat;
                wordLabel.TextAlign = ContentAlignment.MiddleCenter;
                wordLabel.AutoEllipsis = true;
                wordLabel.Dock = DockStyle.Fill;
                wordLabel.AutoSize = false;
                wordLabel.Font = new Font(wordLabel.Font.FontFamily, Single.Parse(programInUse.FontWordLabel));
                BackColor = Color.White;

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

        private async Task startWordExposition(StroopProgram program) // starts colored words exposition - classic Stroop
        {
            cts = new CancellationTokenSource();
            string textCurrent = null, colorCurrent = null, outputFileName = null; string audioDetail = "false";
            string[] labelText = null, labelColor = null, audioDirs = null, subtitlesArray = null;
            int textArrayCounter = 0, colorArrayCounter = 0, audioCounter = 0, subtitleCounter = 0;
            List<string> outputContent = new List<string>();

            var interval = Task.Run(async delegate{ await Task.Delay(program.IntervalTime, cts.Token); });
            var exposition = Task.Run(async delegate{ await Task.Delay(program.ExpositionTime, cts.Token); });
            
            try
            {
                outputFileName = outputDataPath + program.UserName + "_" + program.ProgramName + ".txt"; // defines outputFileName
                // reading list files:
                labelText = StroopProgram.readListFile(path + "/lst/" + program.WordsListFile); // string array receives wordsList itens from list file
                labelColor = StroopProgram.readListFile(path + "/lst/" + program.ColorsListFile); // string array receives colorsList itens from list file
                if (program.ExpositionRandom) // if the presentation is random, shuffles arrays
                {
                    labelText = shuffleArray(labelText, program.NumExpositions, 1);
                    labelColor = shuffleArray(labelColor, program.NumExpositions, 5);
                }
                if (program.AudioListFile != "false") // if there is an audioFile to be played, string array receives audioList itens from list file
                {
                    audioDirs = StroopProgram.readDirListFile(path + "/lst/" + program.AudioListFile);
                    if (program.ExpositionRandom) { audioDirs = shuffleArray(audioDirs, program.NumExpositions, 6); } // if the presentation is random, shuffles array
                }
                foreach (string c in labelColor) // tests if colors list contains only hexadecimal color codes
                {
                    if(!Regex.IsMatch(c, "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$"))
                    {
                        throw new Exception("A lista de cores '" + program.ColorsListFile + "' contém valores inválidos!\n" + c + " por exemplo não é um valor válido. A lista de cores deve conter apenas valores hexadecimais (ex: #000000)");
                    }
                }
                // presenting test instructions:
                await showInstructions(program, cts.Token);
                string printCount = "";
                
                while (true)
                {
                    textArrayCounter = 0; // counters to zero
                    colorArrayCounter = 0;
                    elapsedTime = 0; // elapsed time to zero
                    changeBackgroundColor(program, true); // changes background color, if there is one defined
                    await Task.Delay(program.IntervalTime, cts.Token); // first interval before exposition begins
                    if (program.AudioCapture && program.ExpositionType != "txtaud") { startRecordingAudio(program); } // starts audio recording
                    // exposition loop:
                    for (int counter = 1; counter <= program.NumExpositions; counter++) 
                    {
                        if (counter < 10)// contador p/ arquivo de audio
                        {
                            printCount = "0" + counter.ToString();
                        }
                        else
                        {
                            printCount = counter.ToString();
                        }

                        subtitleLabel.Visible = false;
                        wordLabel.Visible = false;
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

                        if (program.SubtitleShow)
                        {
                            if (program.SubtitleColor.ToLower() != "false")
                            {
                                subtitleLabel.ForeColor = ColorTranslator.FromHtml(program.SubtitleColor);
                            }
                            else
                            {
                                subtitleLabel.ForeColor = Color.Black;
                            }
                            subtitleLabel.Text = subtitlesArray[subtitleCounter];
                            defineSubPosition(program.SubtitlePlace);
                            subtitleLabel.Visible = true;
                            if (subtitleCounter == (subtitlesArray.Count() - 1)) subtitleCounter = 0;
                            else subtitleCounter++;
                        }

                        StroopProgram.writeLineOutput(program, textCurrent, colorCurrent, counter, outputContent, elapsedTime, program.ExpositionType, audioDetail, hour, minutes, seconds);
                        
                        await Task.Delay(program.ExpositionTime, cts.Token);
                    }

                    wordLabel.Visible = false;
                    await Task.Delay(program.IntervalTime, cts.Token);
                    // beginAudio
                    if (program.AudioCapture && program.ExpositionType != "txtaud") { stopRecordingAudio(); } // para gravação áudio
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
                if (program.AudioCapture) { stopRecordingAudio(); }
                throw new Exception("A Exposição '" + program.ProgramName + "' foi cancelada!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cts = null;
        }

        public static Image RotateImage(string imgPath, float rotationAngle)
        {
            Image img = Image.FromFile(imgPath);
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }
        
        private async Task startImageExposition(StroopProgram program) // inicia exposição de imagem
        {
            cts = new CancellationTokenSource();
            int j, k;
            int arrayCounter = 0;
            string[] labelText = null, imageDirs = null, audioDirs = null, subtitlesArray = null;
            string outputFileName = "";
            string actualImagePath = "";
            string audioDetail = "false";
            try
            {
                BackColor = Color.White;
                wordLabel.ForeColor = Color.Red;

                outputFileName = outputDataPath + program.UserName + "_" + program.ProgramName + ".txt";
                
                if (program.ExpandImage) { imgPictureBox.Dock = DockStyle.Fill; }
                else { imgPictureBox.Dock = DockStyle.None; }

                imageDirs = StroopProgram.readDirListFile(path + "/lst/" + program.ImagesListFile); // auxiliar recebe o vetor original
                if (program.ExpositionRandom) // se exposição aleatória, randomiza itens de acordo com o numero de estimulos
                {
                    imageDirs = shuffleArray(imageDirs, program.NumExpositions, 3);
                }

                if (program.SubtitleShow)
                {
                    subtitlesArray = StroopProgram.readListFile(path + "/lst/" + program.SubtitlesListFile);
                    if(program.SubtitleColor.ToLower() != "false")
                    {
                        subtitleLabel.ForeColor = ColorTranslator.FromHtml(program.SubtitleColor);
                    } else
                    {
                        subtitleLabel.ForeColor = Color.Black;
                    }
                    subtitleLabel.Enabled = true;
                    subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2; // centraliza label da palavra
                    subtitleLabel.Top = (imgPictureBox.Bottom + 50);
                }


                if (program.AudioListFile != "false")
                {
                    audioDirs = StroopProgram.readDirListFile(path + "/lst/" + program.AudioListFile);
                    if (program.ExpositionRandom)
                    {
                        audioDirs = shuffleArray(audioDirs, program.NumExpositions, 6);
                    }
                }
                if (program.WordsListFile.ToLower() != "false") { labelText = StroopProgram.readListFile(path + "/lst/" + program.WordsListFile); }
                
                await showInstructions(program, cts.Token); // Apresenta instruções se houver

                outputContent = new List<string>();
                
                while (true)
                {

                    changeBackgroundColor(program, true); // muda cor de fundo se houver parametro
                    imgPictureBox.BackColor = BackColor;

                    elapsedTime = 0; // zera tempo em milissegundos decorrido
                    j = 0; k = 0;
                    arrayCounter = 0;
                    var audioCounter = 0;
                    
                    await Task.Delay(program.IntervalTime, cts.Token);
                    string printCount = "";
                    // beginAudio
                    if (program.AudioCapture) { startRecordingAudio(program); } // inicia gravação áudio
                    // endAudio

                    if (program.ExpositionType == "imgtxt")
                    {
                        for (int counter = 0; counter < program.NumExpositions; counter++) // AQUI ver estimulo -> palavra ou imagem como um só e ter intervalo separado
                        {
                            if(counter < 10)// contador p/ arquivo de audio
                            {
                                printCount = "0" + counter.ToString();
                            }else
                            {
                                printCount = counter.ToString();
                            }
                            

                            imgPictureBox.Visible = false; wordLabel.Visible = false;
                            if (program.SubtitleShow) { subtitleLabel.Visible = false; }
                            await intervalOrFixPoint(program, cts.Token);

                            if (arrayCounter == imageDirs.Count()) { arrayCounter = 0; }
                            if(program.RotateImage != 0) { imgPictureBox.Image = RotateImage(imageDirs[arrayCounter], program.RotateImage); }
                            else { imgPictureBox.Image = Image.FromFile(imageDirs[arrayCounter]); }

                            elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                            SendKeys.SendWait("s");
                            imgPictureBox.Visible = true;
                            wordLabel.Visible = false;
                            actualImagePath = Path.GetFileName(imageDirs[arrayCounter].ToString());
                            arrayCounter++;

                            if (program.SubtitleShow)
                            {
                                if (program.SubtitleColor.ToLower() != "false")
                                {
                                    subtitleLabel.ForeColor = ColorTranslator.FromHtml(program.SubtitleColor);
                                }
                                else
                                {
                                    subtitleLabel.ForeColor = Color.Black;
                                }
                                subtitleLabel.Text = subtitlesArray[k];
                                defineSubPosition(program.SubtitlePlace);
                                subtitleLabel.Visible = true;
                                if (k == (subtitlesArray.Count() - 1)) k = 0;
                                else k++;
                            }

                            StroopProgram.writeLineOutput(program, actualImagePath, "false", counter + 1, outputContent, elapsedTime, "img", audioDetail, hour, minutes, seconds);
                            
                            await Task.Delay(program.ExpositionTime, cts.Token);
                            
                            imgPictureBox.Visible = false;
                            wordLabel.Visible = false;

                            await Task.Delay(program.DelayTime, cts.Token);

                            if (program.WordsListFile.ToLower() != "false") // se tiver palavras intercala elas com a imagem
                            {
                                if (j == labelText.Count()-1) { j = 0; }
                                wordLabel.Text = labelText[j];

                                wordLabel.Left = (this.ClientSize.Width - wordLabel.Width) / 2;
                                wordLabel.Top = (this.ClientSize.Height - wordLabel.Height) / 2;
                                
                                elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                                SendKeys.SendWait("s");
                                imgPictureBox.Visible = false;
                                wordLabel.ForeColor = ColorTranslator.FromHtml(program.WordColor);
                                wordLabel.Visible = true;
                                actualImagePath = wordLabel.Text;
                                j++;

                                StroopProgram.writeLineOutput(program, actualImagePath, "false", counter + 1, outputContent, elapsedTime, "txt", audioDetail, hour, minutes, seconds);
                                
                                await Task.Delay(program.ExpositionTime, cts.Token);
                            }

                            await Task.Delay(program.IntervalTime, cts.Token);
                        }
                    }
                    else
                    {
                        for (int counter = 0; counter < program.NumExpositions; counter++) // AQUI ver estinulo -> palavra ou imagem como um só e ter intervalo separado
                        {
                            imgPictureBox.Visible = false; wordLabel.Visible = false;
                            if (program.SubtitleShow) { subtitleLabel.Visible = false; }
                            await intervalOrFixPoint(program, cts.Token);


                            if (arrayCounter == imageDirs.Count()) { arrayCounter = 0; }
                            if (program.RotateImage != 0) { imgPictureBox.Image = RotateImage(imageDirs[arrayCounter], program.RotateImage); }
                            else { imgPictureBox.Image = Image.FromFile(imageDirs[arrayCounter]); }

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

                            imgPictureBox.Visible = true;

                            if (program.SubtitleShow)
                            {
                                if (program.SubtitleColor.ToLower() != "false")
                                {
                                    subtitleLabel.ForeColor = ColorTranslator.FromHtml(program.SubtitleColor);
                                }
                                else
                                {
                                    subtitleLabel.ForeColor = Color.Black;
                                }
                                subtitleLabel.Text = subtitlesArray[k];
                                defineSubPosition(program.SubtitlePlace);
                                subtitleLabel.Visible = true;
                                if (k == (subtitlesArray.Count() - 1)) k = 0;
                                else k++;
                            }

                            StroopProgram.writeLineOutput(program, Path.GetFileName(imageDirs[arrayCounter].ToString()), "false", counter + 1, outputContent, elapsedTime, program.ExpositionType, Path.GetFileNameWithoutExtension(audioDetail), hour, minutes, seconds);
                            
                            arrayCounter++;
                            await Task.Delay(program.ExpositionTime, cts.Token);
                        }
                    }
                    
                    imgPictureBox.Visible = false; wordLabel.Visible = false;
                    if (program.SubtitleShow)
                    {
                        subtitleLabel.Visible = false;
                    }

                    await Task.Delay(program.IntervalTime, cts.Token);
                    // beginAudio
                    if (program.AudioCapture) { stopRecordingAudio(); } // para gravação áudio
                    // endAudio
                    changeBackgroundColor(program, false); // retorna à cor de fundo padrão

                    break;
                    /*
                    DialogResult dialogResult = MessageBox.Show("Deseja repetir o teste?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa

                    if (dialogResult == DialogResult.Yes) { MessageBox.Show("O teste será repetido!"); } // se deseja repetir o programa mantém o laço while
                    if (dialogResult == DialogResult.No) { break; } // se não deseja repetir quebra o laço
                    */
                }
                imgPictureBox.Dock = DockStyle.None;
                wordLabel.Font = new Font(wordLabel.Font.FontFamily, 160);
                wordLabel.ForeColor = Color.Black;
                StroopProgram.writeOutputFile(outputFileName, string.Join("\n", outputContent.ToArray()));
                Close();
            }
            catch (TaskCanceledException)
            {
                StroopProgram.writeOutputFile(outputFileName, string.Join("\n", outputContent.ToArray()));
                if (program.AudioCapture) { stopRecordingAudio(); }
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
                    subtitleLabel.Top = (imgPictureBox.Bottom + 50);
                    break;
                case 2: //esquerda
                    subtitleLabel.Left = (imgPictureBox.Left - (subtitleLabel.Width + 50));
                    subtitleLabel.Top = (this.ClientSize.Height - subtitleLabel.Height) / 2;
                    break;
                case 3: //direita
                    subtitleLabel.Left = (imgPictureBox.Left + imgPictureBox.Width + 50);
                    subtitleLabel.Top = (this.ClientSize.Height - subtitleLabel.Height) / 2;
                    break;
                case 4: // cima
                    subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2;
                    subtitleLabel.Top = (imgPictureBox.Top - (subtitleLabel.Height + 50));
                    break;
                default: // centro
                    subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2;
                    subtitleLabel.Top = (this.ClientSize.Height - subtitleLabel.Height) / 2;
                    break;
            }

        }
        
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
                string now = program.InitialDate.Day + "." + program.InitialDate.Month + "_" + hour + "h" + minutes + "." + seconds;

                waveSource = new WaveIn();
                waveSource.WaveFormat = new WaveFormat(44100, 1);

                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);
                
                waveFile = new WaveFileWriter(outputDataPath + "/audio_" + program.UserName + "_" + program.ProgramName + "_" + now + ".wav", waveSource.WaveFormat);

                waveSource.StartRecording();
            }
            else
            {
                MessageBox.Show("Dispositivos para gravação de áudio não foram detectados.\nO áudio não será gravado!");
            }
        } // inicia gravação de áudio

        private void stopRecordingAudio()
        {
            if (waveSource != null)
            {
                waveSource.StopRecording();
            }
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
                int intervalTime = 400; // minimal rnd interval time
                if (program.IntervalTimeRandom && program.IntervalTime > 400) // if rnd interval active, it will be a value between 400 and the defined interval time
                {
                    Random random = new Random();
                    intervalTime = random.Next(400, program.IntervalTime);
                }
                else
                {
                    intervalTime = program.IntervalTime;
                }

                if (program.FixPoint != "+" && program.FixPoint != "o") // if there is no fixPoint determination, executes normal intervalTime
                {
                    await Task.Delay(intervalTime);
                }
                else // if it uses fixPoint
                {
                    SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(program.FixPointColor));

                    switch (program.FixPoint)
                    {
                        case "+": // cross fixPoint
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
                        case "o": // circle fixPoint
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
        
        private void FormExposition_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(cts != null)
                cts.Cancel();
        }
    }
}
