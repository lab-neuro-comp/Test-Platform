/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Collections.Generic;
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
using TestPlatform.Views;

namespace TestPlatform
{
    public partial class FormExposition : Form
    {
        CancellationTokenSource cts;
        StroopTest currentTest = new StroopTest(); // program in current use
        private static float elapsedTime;                // elapsed time during each item exposition
        private string path = Global.stroopTestFilesPath;                           
        private List<string> outputContent;            // output file content
        private string outputDataPath = Global.stroopTestFilesPath + Global.resultsFolderName;                // output file Path
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string now;
        private string outputFile;
        private Audio audioControl = new Audio();
        private SoundPlayer Player = new SoundPlayer();
        private string defaultFolderPath = Global.testFilesPath;
        private bool runExposition = true;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        /// <summary>
        /// This is the constructor method for stroop test exposition form.</summary>
        /// <param name="prgName"> Program name is the name of the current StroopProgram that wil be executed.</param>
        /// <param name="mark"> Mark is the char that will be send as signal to the program running background, normally neuronspectrum</param>
        /// <param name="usrName"> Username is the test participant name</param>
        public FormExposition(string prgName, string usrName, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            currentTest.ProgramInUse = new StroopProgram();
            currentTest.ProgramInUse.ProgramName = prgName;
            currentTest.ParticipantName = usrName;
            currentTest.Mark = mark;
            currentTest.InitialDate = DateTime.Now;
            startExpo();
            this.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                runExposition = false;
                cts.Cancel();

                this.Close();
                this.Dispose();
                this.DialogResult = DialogResult.Cancel;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private async void startExpo() // starts Exposition
        {
            if (currentTest.ProgramInUse.Exists(path))
            {
                // makes sure that program file exists before starting exposition
                currentTest.ProgramInUse.readProgramFile(path + "/prg/" + currentTest.ProgramInUse.ProgramName + ".prg");
                now = currentTest.InitialDate.Day + "." + currentTest.InitialDate.Month + "_" +
                        hour + "h" + minutes + "." + seconds;
                outputFile = outputDataPath + currentTest.ParticipantName + "_" + currentTest.ProgramInUse.ProgramName + ".txt";

                // if program is incomplete
                if (currentTest.ProgramInUse.NeedsEdition)
                {
                    MessageBox.Show(LocRM.GetString("programEdit", currentCulture));
                    repairProgram(); // opens prgConfig for program edition
                    currentTest.ProgramInUse.readProgramFile(path + "/prg/" + currentTest.ProgramInUse.ProgramName + ".prg"); // reads new program
                }
                configWordLabel();

                switch (currentTest.ProgramInUse.ExpositionType)
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
                        throw new Exception(LocRM.GetString("expoType", currentCulture) + currentTest.ProgramInUse.ExpositionType + LocRM.GetString("invalid", currentCulture));
                }
            }
            else
            {
                throw new Exception(LocRM.GetString("file", currentCulture) + currentTest.ProgramInUse.ProgramName + ".prg" +
                                    LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(path + "/prg/"));
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
            wordLabel.Font = new Font(wordLabel.Font.FontFamily, Single.Parse(currentTest.ProgramInUse.FontWordLabel));
            BackColor = Color.White;
        }

        private void repairProgram()
        {
            try
            {
                FormPrgConfig configureProgram = new FormPrgConfig(currentTest.ProgramInUse.ProgramName);
                this.Controls.Add(configureProgram);
            }
            catch (Exception ex) {
                throw new Exception(LocRM.GetString("notEdit", currentCulture) + ex.Message);
            }
        }

        private async Task startWordExposition() // starts colored words exposition - classic Stroop
        {
            cts = new CancellationTokenSource();
            string audioDetail = "false";
            int textArrayCounter = 0, colorArrayCounter = 0, audioCounter = 0, subtitleCounter = 0;
            List<string> outputContent = new List<string>();

            
            try
            {
                // reading list files                
                // string array receives lists itens from lists file
                string[] labelText = currentTest.ProgramInUse.getWordListFile().ListContent.ToArray(); 
                string[] labelColor = currentTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                 
                string[] subtitlesArray = configureSubtitle();
                string[] audioDirs = null;

                // if there is an audioFile to be played, string array receives audioList itens from list file
                if (currentTest.ProgramInUse.getAudioListFile() != null) 
                {
                    audioDirs = currentTest.ProgramInUse.getAudioListFile().ListContent.ToArray();
                }

                // if the presentation is random, shuffles arrays
                if (currentTest.ProgramInUse.ExpositionRandom) 
                {
                    labelText = ExpositionController.ShuffleArray(labelText, currentTest.ProgramInUse.NumExpositions, 1);
                    labelColor = ExpositionController.ShuffleArray(labelColor, currentTest.ProgramInUse.NumExpositions, 5);
                    if (audioDirs != null)
                    {
                        audioDirs = ExpositionController.ShuffleArray(audioDirs, currentTest.ProgramInUse.NumExpositions, 6);
                    }
                }
                
                    
                if(!Validations.allHexPattern(labelColor))
                {
                    throw new Exception(LocRM.GetString("list", currentCulture) + currentTest.ProgramInUse.getColorListFile().ListName + LocRM.GetString("validColor", currentCulture));
                }
                
                // presenting test instructions:
                await showInstructions(currentTest.ProgramInUse, cts.Token);

                textArrayCounter = 0; // counters to zero
                colorArrayCounter = 0;
                elapsedTime = 0; // elapsed time to zero
                subtitleCounter = 0;
                changeBackgroundColor(true); // changes background color, if there is one defined
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token); // first interval before exposition begins
                if (currentTest.ProgramInUse.AudioCapture && currentTest.ProgramInUse.ExpositionType != "txtaud") {
                    startRecordingAudio();
                }
                
                // exposition loop
                for (int counter = 1; counter <= currentTest.ProgramInUse.NumExpositions && runExposition; counter++) 
                {
                    subtitleLabel.Visible = false;
                    wordLabel.Visible = false;
                    await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);
                    
                    string textCurrent = labelText[textArrayCounter];
                    string colorCurrent = labelColor[colorArrayCounter];
                        
                    if (textArrayCounter == labelText.Count()-1) {
                        textArrayCounter = 0;
                    }
                    else
                    {
                        textArrayCounter++;
                    }

                    if (colorArrayCounter == labelColor.Count() - 1)
                    {
                        colorArrayCounter = 0;
                    }
                    else
                    {
                        colorArrayCounter++;
                    }

                    wordLabel.Text = textCurrent;
                    wordLabel.ForeColor = ColorTranslator.FromHtml(colorCurrent);
                        
                    if (currentTest.ProgramInUse.getAudioListFile() != null && 
                        currentTest.ProgramInUse.ExpositionType == "txtaud") // reproduz audio
                    {
                        if (audioCounter == audioDirs.Length)
                        {
                            audioCounter = 0;
                        }
                        else
                        {
                            /* do nothing */
                        }
                        audioDetail = audioDirs[audioCounter];
                        Player.SoundLocation = audioDetail;
                        audioCounter++;
                        Player.Play();
                    }
                    else
                    {
                        /* do nothing */
                    }

                    elapsedTime = stopwatch.ElapsedMilliseconds; // grava tempo decorrido
                    SendKeys.SendWait(currentTest.Mark.ToString()); //sending event to neuronspectrum

                    if (currentTest.ProgramInUse.SubtitleShow)
                    {
                        subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                    }
                    wordLabel.Visible = true;
                   
                    currentTest.writeLineOutputResult(currentTest.ProgramInUse, textCurrent, colorCurrent, counter, 
                        outputContent, elapsedTime, currentTest.ProgramInUse.ExpositionType, audioDetail
                        );
                        
                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);
                }
                wordLabel.Visible = false;
                subtitleLabel.Visible = false;
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture && currentTest.ProgramInUse.ExpositionType != "txtaud" && currentTest.ProgramInUse.ExpositionType != "imgaud")
                {
                    stopRecordingAudio();
                } 
                // endAudio
                changeBackgroundColor(false); // retorna à cor de fundo padrão
            
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
                this.DialogResult = DialogResult.OK;
                Close(); // finaliza exposição após execução
            }
            catch(TaskCanceledException)
            {
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
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

                
                if (currentTest.ProgramInUse.ExpandImage) { imgPictureBox.Dock = DockStyle.Fill; }
                else { imgPictureBox.Dock = DockStyle.None; }

                imageDirs = currentTest.ProgramInUse.getImageListFile().ListContent.ToArray(); // auxiliar recebe o vetor original

                if (currentTest.ProgramInUse.ExpositionRandom) // se exposição aleatória, randomiza itens de acordo com o numero de estimulos
                {
                    imageDirs = ExpositionController.ShuffleArray(imageDirs, currentTest.ProgramInUse.NumExpositions, 3);
                }

                subtitlesArray = configureSubtitle();


                if (currentTest.ProgramInUse.getAudioListFile() != null)
                {
                    audioDirs = currentTest.ProgramInUse.getAudioListFile().ListContent.ToArray();
                    if (currentTest.ProgramInUse.ExpositionRandom)
                    {
                        audioDirs = ExpositionController.ShuffleArray(audioDirs, currentTest.ProgramInUse.NumExpositions, 6);
                    }
                }
                if (currentTest.ProgramInUse.getWordListFile() != null)
                {
                    labelText = currentTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                }
                
                // shows program instructions to participant if there are any
                await showInstructions(currentTest.ProgramInUse, cts.Token); 

                outputContent = new List<string>();
                
                // changes background if user select one
                changeBackgroundColor(true); 
                imgPictureBox.BackColor = BackColor;

                // restart elapsed miliseconds
                elapsedTime = 0; 
                j = 0; subtitleCounter = 0;
                arrayCounter = 0;
                var audioCounter = 0;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);

                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture) { startRecordingAudio(); } // inicia gravação áudio
                // endAudio

                if (currentTest.ProgramInUse.ExpositionType == "imgtxt")
                {
                    
                    for (int counter = 0; counter < currentTest.ProgramInUse.NumExpositions && runExposition; counter++) 
                    {
                        imgPictureBox.Visible = false;
                        wordLabel.Visible = false;
                        subtitleLabel.Visible = false;        
                        await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);

                        if (arrayCounter == imageDirs.Count())
                        {
                            arrayCounter = 0;
                        }
                        if(currentTest.ProgramInUse.RotateImage != 0)
                        {
                            imgPictureBox.Image = RotateImage(imageDirs[arrayCounter], currentTest.ProgramInUse.RotateImage);
                        }
                        else
                        {
                            imgPictureBox.Image = Image.FromFile(imageDirs[arrayCounter]);
                        }

                        // grava tempo decorrido
                        elapsedTime = stopwatch.ElapsedMilliseconds;

                        //sending event to program that is running on background, normally neuronspectrum
                        SendKeys.SendWait(currentTest.Mark.ToString());
                        imgPictureBox.Visible = true;

                        if (currentTest.ProgramInUse.SubtitleShow)
                        {
                            subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                        }

                        wordLabel.Visible = false;
                        actualImagePath = StrList.outPutItemName(imageDirs[arrayCounter]);
                        arrayCounter++;


                        currentTest.writeLineOutputResult(currentTest.ProgramInUse, actualImagePath, "false", counter + 1,
                                                            outputContent, elapsedTime, "img", StrList.outPutItemName(audioDetail));

                        await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);

                        imgPictureBox.Visible = false;
                        wordLabel.Visible = false;

                        await Task.Delay(currentTest.ProgramInUse.DelayTime, cts.Token);


                        // if there are images interweaves them
                        if (currentTest.ProgramInUse.getWordListFile() != null)
                        {
                            if (j == labelText.Count() - 1) { j = 0; }
                            wordLabel.Text = labelText[j];


                            elapsedTime = stopwatch.ElapsedMilliseconds;
                            //sending event to program that is running on background, normally neuronspectrum
                            SendKeys.SendWait(currentTest.Mark.ToString());
                            imgPictureBox.Visible = false;
                            subtitleLabel.Visible = false;
                            wordLabel.ForeColor = ColorTranslator.FromHtml(currentTest.ProgramInUse.WordColor);
                            wordLabel.Visible = true;
                            if (currentTest.ProgramInUse.SubtitleShow)
                            {
                                subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                            }
                            actualImagePath = wordLabel.Text;
                            j++;

                            currentTest.writeLineOutputResult(currentTest.ProgramInUse, actualImagePath, "false", counter + 1,
                                                                outputContent, elapsedTime, "txt", StrList.outPutItemName(audioDetail));

                            await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);
                        }

                        await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                    }
                }
                    else
                    {
                        // AQUI ver estimulo -> palavra ou imagem como um só e ter intervalo separado
                        for (int counter = 0; counter < currentTest.ProgramInUse.NumExpositions && runExposition; counter++) 
                        {
                            imgPictureBox.Visible = false;
                            wordLabel.Visible = false;
                            subtitleLabel.Visible = false;
                            await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);
                        

                            if (arrayCounter == imageDirs.Count()) {
                                arrayCounter = 0;
                            }
                            if (currentTest.ProgramInUse.RotateImage != 0) {
                                imgPictureBox.Image = RotateImage(imageDirs[arrayCounter], currentTest.ProgramInUse.RotateImage);
                            }
                            else {
                                imgPictureBox.Image = Image.FromFile(imageDirs[arrayCounter]);
                            }

                            if (currentTest.ProgramInUse.getAudioListFile() != null && currentTest.ProgramInUse.ExpositionType == "imgaud")
                            {
                                if (audioCounter == audioDirs.Length) { audioCounter = 0; }
                                audioDetail = audioDirs[audioCounter];
                                Player.SoundLocation = audioDetail;
                                audioCounter++;
                                Player.Play();
                            }
                            
                            elapsedTime = stopwatch.ElapsedMilliseconds;
                            SendKeys.SendWait(currentTest.Mark.ToString()); //sending event to neuronspectrum

                            imgPictureBox.Visible = true;

                            if (currentTest.ProgramInUse.SubtitleShow)
                            {
                                subtitleCounter = showSubtitle(subtitleCounter, subtitlesArray);
                            }

                            currentTest.writeLineOutputResult(currentTest.ProgramInUse,
                                                                StrList.outPutItemName(imageDirs[arrayCounter]), "false",
                                                                counter + 1, outputContent, elapsedTime, 
                                                                currentTest.ProgramInUse.ExpositionType,
                                                                StrList.outPutItemName(audioDetail));
                            
                            arrayCounter++;
                            await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);
                        }
                    }
                    
                    imgPictureBox.Visible = false;
                    wordLabel.Visible = false;
                    subtitleLabel.Visible = false;
                    

                    await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                    // beginAudio
                    if (currentTest.ProgramInUse.AudioCapture && currentTest.ProgramInUse.ExpositionType != "txtaud" && currentTest.ProgramInUse.ExpositionType != "imgaud") {

                        stopRecordingAudio();
                    } 
                    // endAudio
                    changeBackgroundColor(false); // retorna à cor de fundo padrão

                    
                imgPictureBox.Dock = DockStyle.None;
                wordLabel.Font = new Font(wordLabel.Font.FontFamily, 160);
                wordLabel.ForeColor = Color.Black;
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (TaskCanceledException)
            {
                StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
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
        
  

        private async Task showInstructions(StroopProgram program, CancellationToken token) 
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

        private void changeBackgroundColor(bool flag) // muda cor de fundo
        {
            if (flag && currentTest.ProgramInUse.BackgroundColor.ToLower() != "false")
            { 
                    this.BackColor = ColorTranslator.FromHtml(currentTest.ProgramInUse.BackgroundColor);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private string[] configureSubtitle()
        {
            string[] subtitlesArray = null;
            if (currentTest.ProgramInUse.SubtitleShow)
            {
                subtitlesArray = StrList.readListFile(defaultFolderPath + "/Lst/" + currentTest.ProgramInUse.SubtitlesListFile);
                if (currentTest.ProgramInUse.SubtitleColor.ToLower() != "false")
                {
                    subtitleLabel.ForeColor = ColorTranslator.FromHtml(currentTest.ProgramInUse.SubtitleColor);
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
            if (currentTest.ProgramInUse.RndSubtitlePlace)
                currentTest.ProgramInUse.SubtitlePlace = random.Next(1,4);
            defineSubPosition(currentTest.ProgramInUse.SubtitlePlace);
            subtitleLabel.Visible = true;
            if (subtitleCounter == (subtitlesArray.Count() - 1)) subtitleCounter = 0;
            else subtitleCounter++;
            return subtitleCounter;
        }

        // beginAudio
        private void startRecordingAudio()
        {
            audioControl.StartRecording(outputDataPath + "/audio_" + currentTest.ParticipantName + "_" + currentTest.ProgramInUse.ProgramName + "_" + now + ".wav");
            
        } 

        // stop recording and saves audio file
        private void stopRecordingAudio()
        {
            string now = currentTest.InitialDate.Day + "." + currentTest.InitialDate.Month + "_" + hour + "h" + 
                minutes + "." + seconds;
            audioControl.SaveRecording();

        }


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
                            float xCross1 = (float) (ClientSize.Width) / 2 - 25;
                            float yCross1 = (float) ClientSize.Height / 2 - 4;
                            float xCross2 = (float) ClientSize.Width / 2 - 4;
                            float yCross2 = (float) ClientSize.Height / 2 - 25;
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
                            float xEllipse = (float) ClientSize.Width / 2 - 25;
                            float yEllipse = (float) ClientSize.Height / 2 - 25;
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
                
        }
    }
}
