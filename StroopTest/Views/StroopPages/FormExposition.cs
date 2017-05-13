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


using System.Collections.Generic;
using System.Media;
using System.Drawing.Drawing2D;
using StroopTest.Models;
using StroopTest.Controllers;
using TestPlatform.Models;

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
        private string now;
        private string outputFile;
        private Audio audioControl = new Audio();
        private SoundPlayer Player = new SoundPlayer();
        private string defaultFolderPath;

        public FormExposition(string prgName, string usrName, string defaultFolderPath)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            this.defaultFolderPath = defaultFolderPath;
            path = defaultFolderPath + "/StroopTestFiles/";
            outputDataPath = path + "/data/";
            programInUse.ProgramName = prgName;
            programInUse.UserName = usrName;
            startExpo();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == Keys.Escape)
            {
                MessageBox.Show("A exposição foi cancelada.");
                if(programInUse.AudioCapture)
                    audioControl.saveRecording(outputDataPath + "/audio_" + programInUse.UserName + "_" + programInUse.ProgramName + "_" + now + ".wav");
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void startExpo() // starts Exposition
        {
            try
            {
                if (!programInUse.Exists(path)) {
                    throw new Exception("Arquivo programa: " + programInUse.ProgramName + ".prg" + 
                                        "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/"));
                } // confere existência do arquivo
                programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg"); // reads program into programInUse
                now = programInUse.InitialDate.Day + "." + programInUse.InitialDate.Month + "_" + hour + "h" + minutes + "." + seconds;
                outputFile = outputDataPath + programInUse.UserName + "_" + programInUse.ProgramName + ".txt";
                if (programInUse.NeedsEdition) // if program is incomplete
                {
                    MessageBox.Show("O programa contém parâmetros incorretos e/ou está incompleto!\nCorrija o programa na interface a seguir.");
                    repairProgram(); // opens prgConfig for program edition
                    programInUse.readProgramFile(path + "/prg/" + programInUse.ProgramName + ".prg"); // reads new program
                }
                configWordLabel();
                
                switch (programInUse.ExpositionType)
                {
                    case "txt":
                        await startWordExposition();
                        break;
                    case "imgtxt":
                        await startImageExposition();
                        break;
                    case "img":
                        await startImageExposition();
                        break;
                    case "txtaud":
                        await startWordExposition();
                        break;
                    case "imgaud":
                        await startImageExposition();
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

        private void configWordLabel()
        {
            wordLabel.Name = "error";
            wordLabel.Left = (this.ClientSize.Width - wordLabel.Width) / 2;
            wordLabel.Top = (this.ClientSize.Height - wordLabel.Height) / 2;
            wordLabel.Visible = false;
            wordLabel.FlatStyle = FlatStyle.Flat;
            wordLabel.TextAlign = ContentAlignment.MiddleCenter;
            wordLabel.AutoEllipsis = true;
            wordLabel.Dock = DockStyle.Fill;
            wordLabel.AutoSize = false;
            wordLabel.Font = new Font(wordLabel.Font.FontFamily, Single.Parse(programInUse.FontWordLabel));
            BackColor = Color.White;

        }

        private void repairProgram()
        {
            try
            {

                FormPrgConfig configureProgram = new FormPrgConfig();
                configureProgram.Path = path;
                configureProgram.PrgName = "/" + programInUse.ProgramName;
                this.Controls.Add(configureProgram);
            }
            catch (Exception ex) { throw new Exception("Edição não pode ser feita " + ex.Message); }
        }

        private async Task startWordExposition() // starts colored words exposition - classic Stroop
        {
            cts = new CancellationTokenSource();
            string textCurrent = null, colorCurrent = null, audioDetail = "false";
            string[] labelText = null, labelColor = null, audioDirs = null, subtitlesArray = null;
            int textArrayCounter = 0, colorArrayCounter = 0, audioCounter = 0, subtitleCounter = 0;
            List<string> outputContent = new List<string>();

            var interval = Task.Run(async delegate{ await Task.Delay(programInUse.IntervalTime, cts.Token); });
            var exposition = Task.Run(async delegate{ await Task.Delay(programInUse.ExpositionTime, cts.Token); });
            
            try
            {
                // reading list files:
                labelText = StrList.readListFile(defaultFolderPath + "/Lst/" + programInUse.WordsListFile); // string array receives wordsList itens from list file
                labelColor = StrList.readListFile(defaultFolderPath + "/Lst/" + programInUse.ColorsListFile); // string array receives colorsList itens from list file
                subtitlesArray = configureSubtitle();
                if (programInUse.ExpositionRandom) // if the presentation is random, shuffles arrays
                {
                    labelText = ExpositionController.shuffleArray(labelText, programInUse.NumExpositions, 1);
                    labelColor = ExpositionController.shuffleArray(labelColor, programInUse.NumExpositions, 5);
                }
                if (programInUse.AudioListFile != "false") // if there is an audioFile to be played, string array receives audioList itens from list file
                {
                    audioDirs = StroopProgram.readDirListFile(defaultFolderPath + "/Lst/" + programInUse.AudioListFile);
                    if (programInUse.ExpositionRandom) { audioDirs = ExpositionController.shuffleArray(audioDirs, programInUse.NumExpositions, 6); } // if the presentation is random, shuffles array
                }
                    if(!Validations.allHexPattern(labelColor))
                    {
                        throw new Exception("A lista de cores '" + programInUse.ColorsListFile + "' contém valores inválidos!\n A lista de"+ 
                            "cores deve conter apenas valores hexadecimais (ex: #000000)");
                    }
                
                // presenting test instructions:
                await showInstructions(programInUse, cts.Token);
                string printCount = "";
                while (true)
                {
                    textArrayCounter = 0; // counters to zero
                    colorArrayCounter = 0;
                    elapsedTime = 0; // elapsed time to zero
                    subtitleCounter = 0;
                    changeBackgroundColor(programInUse, true); // changes background color, if there is one defined
                    await Task.Delay(programInUse.IntervalTime, cts.Token); // first interval before exposition begins
                    if (programInUse.AudioCapture && programInUse.ExpositionType != "txtaud") {
                        startRecordingAudio();
                    } 
                    // exposition loop:
                    for (int counter = 1; counter <= programInUse.NumExpositions; counter++) 
                    {
                        subtitleLabel.Visible = false;
                        wordLabel.Visible = false;
                        await intervalOrFixPoint(programInUse, cts.Token);

                        if (counter < 10)// contador p/ arquivo de audio
                        {
                            printCount = "0" + counter.ToString();
                        }
                        else
                        {
                            printCount = counter.ToString();
                        }                      
                        
                        textCurrent = labelText[textArrayCounter];
                        colorCurrent = labelColor[colorArrayCounter];
                        
                        if (textArrayCounter == labelText.Count()-1) { textArrayCounter = 0; }
                        else textArrayCounter++;
                        if (colorArrayCounter == labelColor.Count()-1) { colorArrayCounter = 0; }
                        else colorArrayCounter++;
                        wordLabel.Text = textCurrent;
                        wordLabel.ForeColor = ColorTranslator.FromHtml(colorCurrent);
                        
                        if (programInUse.AudioListFile.ToLower() != "false" && 
                            programInUse.ExpositionType == "txtaud") // reproduz audio
                        {
                            if (audioCounter == audioDirs.Length) { audioCounter = 0; }
                            audioDetail = audioDirs[audioCounter];
                            Player.SoundLocation = audioDetail;
                            audioCounter++;
                            Player.Play();
                        }

                        elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                        SendKeys.SendWait("="); //sending event to neuronspectrum
                        if (programInUse.SubtitleShow)
                        {
                            subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                        }
                        wordLabel.Visible = true;
                        


                        StroopProgram.writeLineOutputResult(programInUse, textCurrent, colorCurrent, counter, 
                            outputContent, elapsedTime, programInUse.ExpositionType, audioDetail, hour, minutes, seconds);
                        
                        await Task.Delay(programInUse.ExpositionTime, cts.Token);
                    }
                    wordLabel.Visible = false;
                    subtitleLabel.Visible = false;
                    await Task.Delay(programInUse.IntervalTime, cts.Token);
                    // beginAudio
                    if (programInUse.AudioCapture && programInUse.ExpositionType != "txtaud") {
                        stopRecordingAudio();
                    } 
                    // endAudio
                    changeBackgroundColor(programInUse, false); // retorna à cor de fundo padrão

                    break;
                    /*
                    DialogResult dialogResult = MessageBox.Show("Deseja repetir o teste?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa
                    if (dialogResult == DialogResult.Yes) { MessageBox.Show("O teste será repetido!"); } // se deseja repetir o programa mantém o laço while
                    if (dialogResult == DialogResult.No) { break; } // se não deseja repetir quebra o laço
                    */
            }
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
                Close(); // finaliza exposição após execução
            }
            catch(TaskCanceledException)
            {
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
                if (programInUse.AudioCapture) { stopRecordingAudio(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        
        private async Task startImageExposition() // inicia exposição de imagem
        {
            cts = new CancellationTokenSource();
            int j, subtitleCounter = 0;
            int arrayCounter = 0;
            string[] labelText = null, imageDirs = null, audioDirs = null, subtitlesArray = null;
            string actualImagePath = "";
            string audioDetail = "false";
            try
            {
                BackColor = Color.White;
                wordLabel.ForeColor = Color.Red;

                
                if (programInUse.ExpandImage) { imgPictureBox.Dock = DockStyle.Fill; }
                else { imgPictureBox.Dock = DockStyle.None; }

                imageDirs = StroopProgram.readDirListFile(defaultFolderPath + "/Lst/" + programInUse.ImagesListFile); // auxiliar recebe o vetor original
                if (programInUse.ExpositionRandom) // se exposição aleatória, randomiza itens de acordo com o numero de estimulos
                {
                    imageDirs = ExpositionController.shuffleArray(imageDirs, programInUse.NumExpositions, 3);
                }

                subtitlesArray = configureSubtitle();


                if (programInUse.AudioListFile != "false")
                {
                    audioDirs = StroopProgram.readDirListFile(defaultFolderPath + "/Lst/" + programInUse.AudioListFile);
                    if (programInUse.ExpositionRandom)
                    {
                        audioDirs = ExpositionController.shuffleArray(audioDirs, programInUse.NumExpositions, 6);
                    }
                }
                if (programInUse.WordsListFile.ToLower() != "false")
                {
                    labelText = StrList.readListFile(defaultFolderPath + "/Lst/" + programInUse.WordsListFile);
                }
                
                await showInstructions(programInUse, cts.Token); // Apresenta instruções se houver

                outputContent = new List<string>();
                
                while (true)
                {

                    changeBackgroundColor(programInUse, true); // muda cor de fundo se houver parametro
                    imgPictureBox.BackColor = BackColor;

                    elapsedTime = 0; // zera tempo em milissegundos decorrido
                    j = 0; subtitleCounter = 0;
                    arrayCounter = 0;
                    var audioCounter = 0;
                    
                    await Task.Delay(programInUse.IntervalTime, cts.Token);
                    string printCount = "";
                    // beginAudio
                    if (programInUse.AudioCapture) { startRecordingAudio(); } // inicia gravação áudio
                    // endAudio

                    if (programInUse.ExpositionType == "imgtxt")
                    {
                        for (int counter = 0; counter < programInUse.NumExpositions; counter++) // AQUI ver estimulo -> palavra ou imagem como um só e ter intervalo separado
                        {
                            if(counter < 10)// contador p/ arquivo de audio
                            {
                                printCount = "0" + counter.ToString();
                            }
                            else
                            {
                                printCount = counter.ToString();
                            }
                            

                            imgPictureBox.Visible = false;
                            wordLabel.Visible = false;
                            subtitleLabel.Visible = false;        
                            await intervalOrFixPoint(programInUse, cts.Token);

                            if (arrayCounter == imageDirs.Count())
                            {
                                arrayCounter = 0;
                            }
                            if(programInUse.RotateImage != 0)
                            {
                                imgPictureBox.Image = RotateImage(imageDirs[arrayCounter], programInUse.RotateImage);
                            }
                            else {
                                imgPictureBox.Image = Image.FromFile(imageDirs[arrayCounter]);
                            }

                            // grava tempo decorrido
                            elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; 

                            SendKeys.SendWait("="); //sending event to neuronspectrum
                            imgPictureBox.Visible = true;

                            if (programInUse.SubtitleShow)
                            {
                                subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                            }

                            wordLabel.Visible = false;
                            actualImagePath = Path.GetFileName(imageDirs[arrayCounter].ToString());
                            arrayCounter++;


                            StroopProgram.writeLineOutputResult(programInUse, actualImagePath, "false", counter + 1, 
                                                                outputContent, elapsedTime, "img", audioDetail, hour, 
                                                                minutes, seconds);
                            
                            await Task.Delay(programInUse.ExpositionTime, cts.Token);
                            
                            imgPictureBox.Visible = false;
                            wordLabel.Visible = false;

                            await Task.Delay(programInUse.DelayTime, cts.Token);


                            // se tiver palavras intercala elas com a imagem
                            if (programInUse.WordsListFile.ToLower() != "false") 
                            {
                                if (j == labelText.Count()-1) { j = 0; }
                                wordLabel.Text = labelText[j];

                                
                                elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
                                SendKeys.SendWait("="); //sending event to neuronspectrum
                                imgPictureBox.Visible = false;
                                subtitleLabel.Visible = false;
                                wordLabel.ForeColor = ColorTranslator.FromHtml(programInUse.WordColor);
                                wordLabel.Visible = true;
                                if (programInUse.SubtitleShow)
                                {
                                    subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                                }
                                actualImagePath = wordLabel.Text;
                                j++;

                                StroopProgram.writeLineOutputResult(programInUse, actualImagePath, "false", counter + 1,
                                                                    outputContent, elapsedTime, "txt", audioDetail, hour, 
                                                                    minutes, seconds);
                                
                                await Task.Delay(programInUse.ExpositionTime, cts.Token);
                            }

                            await Task.Delay(programInUse.IntervalTime, cts.Token);
                        }
                    }
                    else
                    {
                        // AQUI ver estimulo -> palavra ou imagem como um só e ter intervalo separado
                        for (int counter = 0; counter < programInUse.NumExpositions; counter++) 
                        {
                            imgPictureBox.Visible = false;
                            wordLabel.Visible = false;
                            subtitleLabel.Visible = false;
                            await intervalOrFixPoint(programInUse, cts.Token);


                            if (arrayCounter == imageDirs.Count()) {
                                arrayCounter = 0;
                            }
                            if (programInUse.RotateImage != 0) {
                                imgPictureBox.Image = RotateImage(imageDirs[arrayCounter], programInUse.RotateImage);
                            }
                            else {
                                imgPictureBox.Image = Image.FromFile(imageDirs[arrayCounter]);
                            }

                            if (programInUse.AudioListFile.ToLower() != "false" && programInUse.ExpositionType == "imgaud")
                            {
                                if (audioCounter == audioDirs.Length) { audioCounter = 0; }
                                audioDetail = audioDirs[audioCounter];
                                Player.SoundLocation = audioDetail;
                                audioCounter++;
                                Player.Play();
                            }
                            
                            elapsedTime = elapsedTime + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; // grava tempo decorrido
                            SendKeys.SendWait("="); //sending event to neuronspectrum

                            imgPictureBox.Visible = true;

                            if (programInUse.SubtitleShow)
                            {
                                subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                            }

                            StroopProgram.writeLineOutputResult(programInUse, 
                                                                Path.GetFileName(imageDirs[arrayCounter].ToString()), "false",
                                                                counter + 1, outputContent, elapsedTime, 
                                                                programInUse.ExpositionType, 
                                                                Path.GetFileNameWithoutExtension(audioDetail), hour, minutes,
                                                                seconds);
                            
                            arrayCounter++;
                            await Task.Delay(programInUse.ExpositionTime, cts.Token);
                        }
                    }
                    
                    imgPictureBox.Visible = false;
                    wordLabel.Visible = false;
                    subtitleLabel.Visible = false;
                    

                    await Task.Delay(programInUse.IntervalTime, cts.Token);
                    // beginAudio
                    if (programInUse.AudioCapture) {
                        stopRecordingAudio();
                    } 
                    // endAudio
                    changeBackgroundColor(programInUse, false); // retorna à cor de fundo padrão

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
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
                Close();
            }
            catch (TaskCanceledException)
            {
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
                if (programInUse.AudioCapture) {
                    stopRecordingAudio();
                }
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
                    subtitleLabel.Left = (imgPictureBox.Left - (subtitleLabel.Width + 150));
                    subtitleLabel.Top = (this.ClientSize.Height - subtitleLabel.Height) / 2;
                    break;
                case 3: //direita
                    subtitleLabel.Left = (imgPictureBox.Left + imgPictureBox.Width + 150);
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
        
  

        private async Task showInstructions(StroopProgram program, CancellationToken token) // apresenta instruções
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

        private string[] configureSubtitle()
        {
            string[] subtitlesArray = null;
            if (programInUse.SubtitleShow)
            {
                subtitlesArray = StrList.readListFile(defaultFolderPath + "/Lst/" + programInUse.SubtitlesListFile);
                if (programInUse.SubtitleColor.ToLower() != "false")
                {
                    subtitleLabel.ForeColor = ColorTranslator.FromHtml(programInUse.SubtitleColor);
                }
                else
                {
                    subtitleLabel.ForeColor = Color.Black;
                }
                subtitleLabel.Enabled = true;
                subtitleLabel.Left = (this.ClientSize.Width - subtitleLabel.Width) / 2; // centraliza label da palavra
                subtitleLabel.Top = (imgPictureBox.Bottom + 50);
            }
            return subtitlesArray;
        }

        private int showSubtitle(int subtitleCounter, string[] subtitlesArray)
        {
            Random random = new Random();
            subtitleLabel.Text = subtitlesArray[subtitleCounter];
            if (programInUse.RndSubtitlePlace)
                programInUse.SubtitlePlace = random.Next(1,4);
            defineSubPosition(programInUse.SubtitlePlace);
            subtitleLabel.Visible = true;
            if (subtitleCounter == (subtitlesArray.Count() - 1)) subtitleCounter = 0;
            else subtitleCounter++;
            return subtitleCounter;
        }

        // beginAudio
        private void startRecordingAudio()
        {
            audioControl.startRecording();
            
        } // inicia gravação de áudio

        private void stopRecordingAudio()
        {
            string now = programInUse.InitialDate.Day + "." + programInUse.InitialDate.Month + "_" + hour + "h" + minutes + "." + seconds;
            audioControl.saveRecording(outputDataPath + "/audio_" + programInUse.UserName + "_" + programInUse.ProgramName + "_" + now + ".wav");
        } // para gravação de áudio

        
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
            audioControl.saveRecording(outputDataPath + "/audio_" + programInUse.UserName + "_" + programInUse.ProgramName 
                                        + "_" + now + ".wav");
            if(cts != null)
                cts.Cancel();
        }
    }
}
