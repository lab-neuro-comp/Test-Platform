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
        StroopTest currentTest; // program in current use
        private static float elapsedTime;                // elapsed time during each item exposition
        private string path = FileManipulation._stroopTestFilesPath;

        private List<string> outputContent = new List<string>();            // output file content
        private string outputDataPath = FileManipulation._stroopTestFilesPath + FileManipulation._resultsFolderName;                // output file Path

        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");

        private string now;
        private string outputFile;
        private Audio audioControl = new Audio();
        private SoundPlayer Player = new SoundPlayer();
        private string defaultFolderPath = FileManipulation._testFilesPath;
        private bool runExposition = true;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        private string[] wordList = null;
        private string[] colorList = null;
        private string[] subtitleList = null;
        private string[] audioList = null;
        private string[] imageList = null;

        private string currentColor = "false";
        private string currentStimulus = "false";
        private string currentAudio = "false";
        private int wordCounter = 0, colorCounter = 0, audiocounter = 0, subtitlecounter = 0, imageCounter = 0;

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

            // use parameters to create basic information of current program being used
            currentTest = new StroopTest(prgName);
            currentTest.ParticipantName = usrName;
            currentTest.Mark = mark;
            currentTest.InitialDate = DateTime.Now;


            ExpositionController.formSecondScreen(this);

            configureCurrentTest();
            startExpo();
            this.ShowDialog();
        }

        private void configureCurrentTest()
        {
            // makes sure that program file exists before starting exposition
            currentTest.ProgramInUse.readProgramFile(currentTest.ProgramInUse.ProgramName);
            now = currentTest.InitialDate.Day + "." + currentTest.InitialDate.Month + "_" +
                    hour + "h" + minutes + "." + seconds;
            outputFile = outputDataPath + currentTest.ParticipantName + "_" + currentTest.ProgramInUse.ProgramName + ".txt";

            // if program is incomplete
            if (currentTest.ProgramInUse.NeedsEdition)
            {
                MessageBox.Show(LocRM.GetString("programEdit", currentCulture));
                repairProgram(); // opens prgConfig for program edition
                currentTest.ProgramInUse.readProgramFile(currentTest.ProgramInUse.ProgramName); // reads new program
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                runExposition = false;
                cts.Cancel();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private async void startExpo() // starts Exposition
        {
            if (currentTest.ProgramInUse.Exists(path))
            {
               
                configWordLabel();
                cts = new CancellationTokenSource();

                await showInstructions(currentTest.ProgramInUse, cts.Token);
                changeBackgroundColor(true); // changes background color, if there is one defined
                configureSubtitle();

                await startTypeExposition();

                finishExposition();
            }
            else
            {
                throw new Exception(LocRM.GetString("file", currentCulture) + currentTest.ProgramInUse.ProgramName + ".prg" +
                                    LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(path + "/prg/"));
            }
        }


        // reads lists to string arrays, shuffle them if the exposition is random and call exposition by the type
        private async Task startTypeExposition()
        {
            switch (currentTest.ProgramInUse.ExpositionType)
            {
                case "txt":
                    wordList = currentTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                    colorList = currentTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    if (currentTest.ProgramInUse.ExpositionRandom)
                    {
                        wordList = ExpositionController.ShuffleArray(wordList, currentTest.ProgramInUse.NumExpositions, 1);
                        colorList = ExpositionController.ShuffleArray(colorList, currentTest.ProgramInUse.NumExpositions, 5);
                    }
                    
                    await startWordExposition();
                    break;
                case "txtimg":
                    imageList = currentTest.ProgramInUse.getImageListFile().ListContent.ToArray();
                    wordList = currentTest.ProgramInUse.getWordListFile().ListContent.ToArray();

                    if (currentTest.ProgramInUse.ExpositionRandom)
                    {
                        imageList = ExpositionController.ShuffleArray(imageList, currentTest.ProgramInUse.NumExpositions, 3);
                        wordList = ExpositionController.ShuffleArray(wordList, currentTest.ProgramInUse.NumExpositions, 3);
                    }
                    await startWordImageExposition();
                    break;

                case "imgtxt":
                    imageList = currentTest.ProgramInUse.getImageListFile().ListContent.ToArray(); 
                    wordList = currentTest.ProgramInUse.getWordListFile().ListContent.ToArray();

                    if (currentTest.ProgramInUse.ExpositionRandom)
                    {
                        imageList = ExpositionController.ShuffleArray(imageList, currentTest.ProgramInUse.NumExpositions, 3);
                        wordList = ExpositionController.ShuffleArray(wordList, currentTest.ProgramInUse.NumExpositions, 3);
                    }

                    await startImageWordExposition();
                    break;

                case "img":

                    imageList = currentTest.ProgramInUse.getImageListFile().ListContent.ToArray();

                    if (currentTest.ProgramInUse.ExpositionRandom) 
                    {
                        imageList = ExpositionController.ShuffleArray(imageList, currentTest.ProgramInUse.NumExpositions, 3);
                    }

                    await startImageExposition();
                    break;

                case "txtaud":
                    wordList = currentTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                    colorList = currentTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    audioList = currentTest.ProgramInUse.getAudioListFile().ListContent.ToArray();

                    if (currentTest.ProgramInUse.ExpositionRandom)
                    {
                        wordList = ExpositionController.ShuffleArray(wordList, currentTest.ProgramInUse.NumExpositions, 1);
                        colorList = ExpositionController.ShuffleArray(colorList, currentTest.ProgramInUse.NumExpositions, 5);
                        audioList = ExpositionController.ShuffleArray(audioList, currentTest.ProgramInUse.NumExpositions, 6);
                    }

                    await startWordAudioExposition();
                    break;

                case "imgaud":
                    imageList = currentTest.ProgramInUse.getImageListFile().ListContent.ToArray(); 
                    audioList = currentTest.ProgramInUse.getAudioListFile().ListContent.ToArray();

                    if (currentTest.ProgramInUse.ExpositionRandom)
                    {
                        imageList = ExpositionController.ShuffleArray(imageList, currentTest.ProgramInUse.NumExpositions, 3);
                        audioList = ExpositionController.ShuffleArray(audioList, currentTest.ProgramInUse.NumExpositions, 6);

                    }

                    await startImageExposition();
                    break;

                default:
                    throw new Exception(LocRM.GetString("expoType", currentCulture) + currentTest.ProgramInUse.ExpositionType + LocRM.GetString("invalid", currentCulture));
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
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token); // first interval before exposition begins
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    startRecordingAudio();
                }

                // exposition loop
                for (int counter = 1; counter <= currentTest.ProgramInUse.NumExpositions && runExposition; counter++)
                {
                    subtitleLabel.Visible = false;
                    wordLabel.Visible = false;
                    await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);

                    drawWord();

                    wordLabel.Text = currentStimulus;
                    wordLabel.ForeColor = ColorTranslator.FromHtml(currentColor);

                    elapsedTime = stopwatch.ElapsedMilliseconds; // grava tempo decorrido
                    SendKeys.SendWait(currentTest.Mark.ToString()); //sending event to neuronspectrum

                    showSubtitle();
                    
                    wordLabel.Visible = true;

                    currentTest.writeLineOutputResult( currentStimulus, currentColor, counter,
                        outputContent, elapsedTime, currentAudio
                        );

                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);
                }
 
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }
            }
            catch (TaskCanceledException)
            {
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }
                finishExposition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // starts colored words exposition  that play audios at the same time
        private async Task startWordAudioExposition() 
        {
            cts = new CancellationTokenSource();
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token); // first interval before exposition begins

                // exposition loop
                for (int counter = 1; counter <= currentTest.ProgramInUse.NumExpositions && runExposition; counter++)
                {
                    subtitleLabel.Visible = false;
                    wordLabel.Visible = false;
                    await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);

                    drawWord();

                    wordLabel.Text = currentStimulus;
                    wordLabel.ForeColor = ColorTranslator.FromHtml(currentColor);

                    playAudio();

                    elapsedTime = stopwatch.ElapsedMilliseconds; // grava tempo decorrido
                    SendKeys.SendWait(currentTest.Mark.ToString()); //sending event to neuronspectrum

                    showSubtitle();
                    
                    wordLabel.Visible = true;

                    currentTest.writeLineOutputResult(currentStimulus, currentColor, counter,
                        outputContent, elapsedTime, currentAudio
                        );

                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);
                    Player.Stop();

                }

            }
            catch (TaskCanceledException)
            {
                Player.Stop();
                finishExposition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cts = null;
        }

        private void finishExposition()
        {
            wordLabel.Visible = false;
            subtitleLabel.Visible = false;

            // return background color to default color
            changeBackgroundColor(false);

            StroopProgram.writeOutputFile(outputFile, string.Join("\n", outputContent.ToArray()));
            this.DialogResult = DialogResult.OK;

            // closes form finishing exposition
            Close();

        }

        private void drawWord()
        {
            currentStimulus = wordList[wordCounter];
            currentColor = colorList[colorCounter];
            wordCounter++;

            if (wordCounter == wordList.Length)
            {
                wordCounter = 0;
            }
            colorCounter++;
            if (colorCounter == colorList.Length)
            {
                colorCounter = 0;
            }
        }

        private void playAudio()
        {
            if (audiocounter == audioList.Length)
            {
                audiocounter = 0;
            }
            else
            {
                /* do nothing */
            }
            
            currentAudio = audioList[audiocounter];
            Player = new SoundPlayer(currentAudio);
            Player.Load();
            Player.Play();
            audiocounter++;
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

        private void configureImagePictureBox()
        {
            wordLabel.ForeColor = Color.Red;
            if (currentTest.ProgramInUse.ExpandImage) { imgPictureBox.Dock = DockStyle.Fill; }
            else { imgPictureBox.Dock = DockStyle.None; }
            imgPictureBox.BackColor = Color.White;
        }

        // place current stimulus in imagebox
        private void drawImage()
        {
            if (imageCounter == imageList.Count())
            {
                imageCounter = 0;
            }
            if (currentTest.ProgramInUse.RotateImage != 0)
            {
                imgPictureBox.Image = RotateImage(imageList[imageCounter], currentTest.ProgramInUse.RotateImage);
            }
            else
            {
                imgPictureBox.Image = Image.FromFile(imageList[imageCounter]);
            }
            currentStimulus = StrList.outPutItemName(imageList[imageCounter]);
            imageCounter++;
        }

        private async Task startImageWordExposition()
        {
            cts = new CancellationTokenSource();
            try
            {
                configureImagePictureBox();   
                outputContent = new List<string>();

                // restart elapsed miliseconds
                elapsedTime = 0;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);

                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture) { startRecordingAudio(); } // inicia gravação áudio
                                                                                      // endAudio
                for (int counter = 0; counter < currentTest.ProgramInUse.NumExpositions && runExposition; counter++)
                {
                    imgPictureBox.Visible = false;
                    wordLabel.Visible = false;
                    subtitleLabel.Visible = false;
                    await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);

                    drawImage();

                    elapsedTime = stopwatch.ElapsedMilliseconds;

                    //sending event to program that is running on background, normally neuronspectrum
                    SendKeys.SendWait(currentTest.Mark.ToString());
                    imgPictureBox.Visible = true;

                    showSubtitle();

                    wordLabel.Visible = false;


                    currentTest.writeLineOutputResult(currentStimulus, "false", counter + 1,
                                                        outputContent, elapsedTime, "false");

                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);

                    imgPictureBox.Visible = false;
                    wordLabel.Visible = false;

                    await Task.Delay(currentTest.ProgramInUse.DelayTime, cts.Token);


                    if (wordCounter == wordList.Count() - 1)
                    {
                        wordCounter = 0;
                    }
                    wordLabel.Text = wordList[wordCounter];
                    currentStimulus = wordLabel.Text;
                    wordCounter++;
                    elapsedTime = stopwatch.ElapsedMilliseconds;

                    //sending event to program that is running on background, normally neuronspectrum
                    SendKeys.SendWait(currentTest.Mark.ToString());
                    imgPictureBox.Visible = false;
                    subtitleLabel.Visible = false;
                    wordLabel.ForeColor = ColorTranslator.FromHtml(currentTest.ProgramInUse.WordColor);
                    wordLabel.Visible = true;
                    showSubtitle();

                    currentTest.writeLineOutputResult(currentStimulus, "false", counter + 1,
                                                        outputContent, elapsedTime, "false");
                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);


                    await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                }
                imgPictureBox.Visible = false;
                wordLabel.Visible = false;
                subtitleLabel.Visible = false;


                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }
            }
            catch (TaskCanceledException)
            {
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }
                finishExposition();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cts = null;
        }

        private async Task startWordImageExposition()
        {
            cts = new CancellationTokenSource();
            try
            {
                configureImagePictureBox();
                outputContent = new List<string>();

                // restart elapsed miliseconds
                elapsedTime = 0;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);

                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture) { startRecordingAudio(); } // inicia gravação áudio
                                                                                      // endAudio
                for (int counter = 0; counter < currentTest.ProgramInUse.NumExpositions && runExposition; counter++)
                {
                    imgPictureBox.Visible = false;
                    wordLabel.Visible = false;
                    subtitleLabel.Visible = false;
                    await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);

                    // word exposition
                    if (wordCounter == wordList.Count() - 1)
                    {
                        wordCounter = 0;
                    }
                    wordLabel.Text = wordList[wordCounter];
                    currentStimulus = wordLabel.Text;
                    wordCounter++;
                    elapsedTime = stopwatch.ElapsedMilliseconds;

                    //sending event to program that is running on background, normally neuronspectrum
                    SendKeys.SendWait(currentTest.Mark.ToString());
                    imgPictureBox.Visible = false;
                    subtitleLabel.Visible = false;
                    wordLabel.ForeColor = ColorTranslator.FromHtml(currentTest.ProgramInUse.WordColor);
                    wordLabel.Visible = true;
                    showSubtitle();

                    currentTest.writeLineOutputResult(currentStimulus, "false", counter + 1,
                                                        outputContent, elapsedTime, "false");
                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);

                    await Task.Delay(currentTest.ProgramInUse.DelayTime, cts.Token);

                    //image exposition
                    drawImage();

                    elapsedTime = stopwatch.ElapsedMilliseconds;

                    //sending event to program that is running on background, normally neuronspectrum
                    SendKeys.SendWait(currentTest.Mark.ToString());
                    imgPictureBox.Visible = true;

                    showSubtitle();

                    wordLabel.Visible = false;


                    currentTest.writeLineOutputResult(currentStimulus, "false", counter + 1,
                                                        outputContent, elapsedTime, "false");

                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);

                    imgPictureBox.Visible = false;

                    await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                }
                imgPictureBox.Visible = false;
                wordLabel.Visible = false;
                subtitleLabel.Visible = false;


                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }
            }
            catch (TaskCanceledException)
            {
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }
                finishExposition();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            cts = null;
        }

        private async Task startImageExposition() 
        {
            cts = new CancellationTokenSource();
            try
            {
                configureImagePictureBox();
                outputContent = new List<string>();
                wordLabel.Visible = false;
                // restart elapsed miliseconds
                elapsedTime = 0; 
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);

                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture) { startRecordingAudio(); }

                for (int counter = 0; counter < currentTest.ProgramInUse.NumExpositions && runExposition; counter++)
                {
                    imgPictureBox.Visible = false;
                    subtitleLabel.Visible = false;
                    await intervalOrFixPoint(currentTest.ProgramInUse, cts.Token);

                    drawImage();

                    if (currentTest.ProgramInUse.ExpositionType == "imgaud")
                    {
                        playAudio();
                    }

                    elapsedTime = stopwatch.ElapsedMilliseconds;
                    SendKeys.SendWait(currentTest.Mark.ToString()); //sending event to neuronspectrum

                    imgPictureBox.Visible = true;

                    showSubtitle();


                    currentTest.writeLineOutputResult(currentStimulus, "false",
                                                        counter + 1, outputContent, elapsedTime,
                                                        StrList.outPutItemName(currentAudio));

                    await Task.Delay(currentTest.ProgramInUse.ExpositionTime, cts.Token);
                    Player.Stop();
                }


                imgPictureBox.Visible = false;
                subtitleLabel.Visible = false;


                await Task.Delay(currentTest.ProgramInUse.IntervalTime, cts.Token);
                // beginAudio
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }

            }
            catch (TaskCanceledException)
            {
                Player.Stop();
                if (currentTest.ProgramInUse.AudioCapture)
                {
                    stopRecordingAudio();
                }
                finishExposition();
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
            try
            {
                if (program.InstructionText != null)
                {
                    instructionLabel.Enabled = true; instructionLabel.Visible = true;
                    for (int i = 0; i < program.InstructionText.Count; i++)
                    {
                        instructionLabel.Text = program.InstructionText[i];
                        await Task.Delay(Program.instructionAwaitTime, token);
                    }
                    instructionLabel.Enabled = false; instructionLabel.Visible = false;
                }
            }
            catch (TaskCanceledException)
            {
                this.DialogResult = DialogResult.OK;
                Close();
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

        private void configureSubtitle()
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
            subtitleList = subtitlesArray;
        }

        private void showSubtitle()
        {
            if (currentTest.ProgramInUse.SubtitleShow)
            {
                Random random = new Random();
                subtitleLabel.Text = subtitleList[subtitlecounter];

                if (currentTest.ProgramInUse.RndSubtitlePlace)
                {
                    currentTest.ProgramInUse.SubtitlePlace = random.Next(1, 4);
                }

                defineSubPosition(currentTest.ProgramInUse.SubtitlePlace);
                subtitleLabel.Visible = true;
                if (subtitlecounter == (subtitleList.Count() - 1))
                {
                    subtitlecounter = 0;
                }
                else
                {
                    subtitlecounter++;
                }
            }
            else
            {
                /* do nothing */
            }
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

                if (program.FixPoint == "+" || program.FixPoint == "o")
                {
                    ExpositionController.makingFixPoint(program.FixPoint, program.FixPointColor, this);

                }
                await Task.Delay(intervalTime);
            }

            catch (Exception ex)
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
