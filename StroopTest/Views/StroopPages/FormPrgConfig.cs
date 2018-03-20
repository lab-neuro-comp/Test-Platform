/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Controllers;
using TestPlatform.Models;
using TestPlatform.Views;

namespace TestPlatform
{
    public partial class FormPrgConfig : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private String path = Global.stroopTestFilesPath + Global.programFolderName;
        private String instructionBoxText;
        private List<Button> subDirectionList = new List<Button>();
        private Int32 subDirectionNumber = 1;
        private String fontSize = "160";
        private String editPrgName = "error";
        private String prgName = "false";

        public string PrgName
        {
            get
            {
                return prgName;
            }

            set
            {
                prgName = value;
            }
        }

        public FormPrgConfig(string programName)
        {
            instructionBoxText = LocRM.GetString("instructionBox", currentCulture);
            InitializeComponent();
            chooseExpoType.SelectedIndex = 0;
            rotateImgComboBox.SelectedIndex = 0;
            subDirectionList.Add(subsDownButton);
            subDirectionList.Add(subsLeftButton);
            subDirectionList.Add(subsRightButton);
            subDirectionList.Add(subsUpButton);
            subDirectionList.Add(subsCenterButton);
            enableSubsItens(false);

            toolTipsConfig();
            this.Dock = DockStyle.Fill;
            if (programName != "false")
            {
                editPrgName = programName;
                editProgram();
            }
        }

        private void toolTipsConfig()
        {

            var helpToolTip = new ToolTip();

            helpToolTip.ToolTipIcon = ToolTipIcon.Info;
            helpToolTip.IsBalloon = true;
            helpToolTip.ShowAlways = true;


            // putting tip to each field so that user can se details if they stop mouse over the field name
            helpToolTip.SetToolTip(prgNameLabel, LocRM.GetString("testName", currentCulture));
            helpToolTip.SetToolTip(expoTypeLabel, LocRM.GetString("typeStimulus", currentCulture));
            helpToolTip.SetToolTip(rndExpoLabel, LocRM.GetString("expoRandomize", currentCulture));
            helpToolTip.SetToolTip(numExpoLabel, LocRM.GetString("numberExpositions", currentCulture));
            helpToolTip.SetToolTip(wordSizeLabel, LocRM.GetString("fontSize", currentCulture));
            helpToolTip.SetToolTip(wordColorLabel, LocRM.GetString("colorWords", currentCulture));
            helpToolTip.SetToolTip(wordListLabel, LocRM.GetString("wordFile", currentCulture));
            helpToolTip.SetToolTip(colorListLabel, LocRM.GetString("colorFile", currentCulture));
            helpToolTip.SetToolTip(imgListLabel, LocRM.GetString("imageFile", currentCulture));
            helpToolTip.SetToolTip(audioListLabel, LocRM.GetString("audioFile", currentCulture));
            helpToolTip.SetToolTip(expoTimeLabel, LocRM.GetString("expositionDuration", currentCulture));
            helpToolTip.SetToolTip(intervalTimeLabel, LocRM.GetString("intervalsTime", currentCulture));
            helpToolTip.SetToolTip(rndIntervalLabel, LocRM.GetString("intervalsTimeRandom", currentCulture));
            helpToolTip.SetToolTip(fixPointTypeLabel, LocRM.GetString("fixpointEx", currentCulture));
            helpToolTip.SetToolTip(fixPointColorLabel, LocRM.GetString("fixpointColor", currentCulture));
            helpToolTip.SetToolTip(activateSubsLabel, LocRM.GetString("subtitleActive", currentCulture));
            helpToolTip.SetToolTip(subLocationLabel, LocRM.GetString("subtitlePosition", currentCulture));
            helpToolTip.SetToolTip(subColorLabel, LocRM.GetString("subtitleColor", currentCulture));
            helpToolTip.SetToolTip(audioCaptureLabel, LocRM.GetString("activeAudio", currentCulture));
            helpToolTip.SetToolTip(bgColorLabel, LocRM.GetString("backgroundColor", currentCulture));
            helpToolTip.SetToolTip(expandImgLabel, LocRM.GetString("expandImages", currentCulture));
            helpToolTip.SetToolTip(instructionsLabel, LocRM.GetString("instructionsI", currentCulture));
            helpToolTip.SetToolTip(helpButton, LocRM.GetString("help", currentCulture));
        }
        
        private void configurePrgItens(int expoType)
        {
            numExpo.Enabled = true; numExpoLabel.Enabled = true;
            rndExpoLabel.Enabled = true; rndExpoCheck.Enabled = true;

            switch (expoType)
            {
                case 0: // txt
                    errorProvider1.Clear();
                    //box1
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    wordColorLabel.Enabled = false; wordColorPanel.Enabled = false; wordColorButton.Enabled = false;
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    expandImgLabel.Enabled = false; expandImgCheck.Enabled = false;
                    //box2
                    wordListLabel.Enabled = true; openWordListButton.Enabled = true;
                    colorListLabel.Enabled = true; openColorListButton.Enabled = true;
                    imgListLabel.Enabled = false; openImgListButton.Enabled = false;
                    audioListLabel.Enabled = false; openAudioListButton.Enabled = false;
                    
                    break;
                case 1: // img
                    errorProvider1.Clear();
                    //box1
                    wordSizeLabel.Enabled = false; wordSizeNumeric.Enabled = false;
                    wordColorLabel.Enabled = false; wordColorPanel.Enabled = false; wordColorButton.Enabled = false;
                    wordSizeLabel.Enabled = false; wordSizeNumeric.Enabled = false;
                    expandImgLabel.Enabled = true; expandImgCheck.Enabled = true; 
                    //box2
                    wordListLabel.Enabled = false; openWordListButton.Enabled = false;
                    colorListLabel.Enabled = false; openColorListButton.Enabled = false;
                    imgListLabel.Enabled = true; openImgListButton.Enabled = true;
                    audioListLabel.Enabled = false; openAudioListButton.Enabled = false;
                    
                    break;
                case 2: // imgtxt
                    errorProvider1.Clear();
                    //box1
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    wordColorLabel.Enabled = true; wordColorPanel.Enabled = true; wordColorButton.Enabled = true;
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    expandImgLabel.Enabled = true; expandImgCheck.Enabled = true;
                    //box2
                    wordListLabel.Enabled = true; openWordListButton.Enabled = true;
                    colorListLabel.Enabled = false; openColorListButton.Enabled = false;
                    imgListLabel.Enabled = true; openImgListButton.Enabled = true;
                    audioListLabel.Enabled = false; openAudioListButton.Enabled = false;
                    
                    break;
                case 3: // txtaud
                    errorProvider1.Clear();
                    //box1
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    wordColorLabel.Enabled = false; wordColorPanel.Enabled = false; wordColorButton.Enabled = false;
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    expandImgLabel.Enabled = false; expandImgCheck.Enabled = false;
                    //box2
                    wordListLabel.Enabled = true; openWordListButton.Enabled = true;
                    colorListLabel.Enabled = true; openColorListButton.Enabled = true;
                    imgListLabel.Enabled = false; openImgListButton.Enabled = false;
                    audioListLabel.Enabled = true; openAudioListButton.Enabled = true;
                    
                    break;
                case 4: // imgaud
                    errorProvider1.Clear();
                    //box1
                    wordSizeLabel.Enabled = false; wordSizeNumeric.Enabled = false;
                    wordColorLabel.Enabled = false; wordColorPanel.Enabled = false; wordColorButton.Enabled = false;
                    wordSizeLabel.Enabled = false; wordSizeNumeric.Enabled = false;
                    expandImgLabel.Enabled = true; expandImgCheck.Enabled = true;
                    //box2
                    wordListLabel.Enabled = false; openWordListButton.Enabled = false; 
                    colorListLabel.Enabled = false; openColorListButton.Enabled = false;
                    imgListLabel.Enabled = true; openImgListButton.Enabled = true;
                    audioListLabel.Enabled = true; openAudioListButton.Enabled = true;
                    break;

                case 5: // txtimg
                    errorProvider1.Clear();
                    //box1
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    wordColorLabel.Enabled = true; wordColorPanel.Enabled = true; wordColorButton.Enabled = true;
                    wordSizeLabel.Enabled = true; wordSizeNumeric.Enabled = true;
                    expandImgLabel.Enabled = true; expandImgCheck.Enabled = true;
                    //box2
                    wordListLabel.Enabled = true; openWordListButton.Enabled = true;
                    colorListLabel.Enabled = false; openColorListButton.Enabled = false;
                    imgListLabel.Enabled = true; openImgListButton.Enabled = true;
                    audioListLabel.Enabled = false; openAudioListButton.Enabled = false;

                    break;
            }

            //box3
            expoTimeLabel.Enabled = true; expoTime.Enabled = true;
            intervalTimeLabel.Enabled = true; intervalTime.Enabled = true;
            rndExpoLabel.Enabled = true; rndExpoCheck.Enabled = true;

            //box4
            fixPointTypeLabel.Enabled = true; fixPointCross.Enabled = true; fixPointCircle.Enabled = true;
            fixPointColorLabel.Enabled = false; fixPointColorPanel.Enabled = false; fixPointColorButton.Enabled = false;
            chooseFixPointType();

            //box5
            activateSubsLabel.Enabled = true; activateSubsCheck.Enabled = true;
            enableSubsItens(activateSubsCheck.Checked);
           
            //box6
            bgColorLabel.Enabled = true; bgColorPanel.Enabled = true; bgColorButton.Enabled = true;
            bool audioCaptureBool = !openAudioListButton.Enabled;
            audioCaptureLabel.Enabled = audioCaptureBool; audioCaptureCheck.Enabled = audioCaptureBool; audioCaptureCheck.Checked = audioCaptureBool;
            
            //instructionsBox
            instructionsLabel.Enabled = true; instructionsBox.Enabled = true;
        }

        //BOX1

        private void chooseExpositionTypeComboBox(object sender, EventArgs e)
        {
            configurePrgItens(chooseExpoType.SelectedIndex);
        }

        private void chooseWordColor_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            wordColorButton.Text = colorCode;
            wordColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void expandImageOn_CheckedChanged(object sender, EventArgs e)
        {
            if (expandImgCheck.Checked && activateSubsCheck.Checked)
                activateSubsCheck.Checked = !expandImgCheck.Checked;

            enableSubsItens(activateSubsCheck.Checked);
        }

        private void wordSizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            fontSize = wordSizeNumeric.Value.ToString();
        }

        //BOX2

        private void openWordsList_Click(object sender, EventArgs e)
        {
            openWordListButton.Text = ListController.OpenListFile("_words", openWordListButton.Text, "lst");
        }

        private void openColorsList_Click(object sender, EventArgs e)
        {
            openColorListButton.Text = ListController.OpenListFile("_color", openColorListButton.Text, "lst");
        }

        private void openImagesList_Click(object sender, EventArgs e)
        {
            openImgListButton.Text = ListController.OpenListFile("_image", openImgListButton.Text, "dir");
        }

        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = ListController.OpenListFile("_audio", openAudioListButton.Text, "dir");
        }
        
        //BOX4

        private void checkFixPointCross_CheckedChanged(object sender, EventArgs e)
        {
            if (fixPointCross.Checked && fixPointCircle.Checked)
                fixPointCircle.Checked = !fixPointCross.Checked;
            chooseFixPointType();
        }

        private void checkFixPointCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (fixPointCross.Checked && fixPointCircle.Checked)
                fixPointCross.Checked = !fixPointCircle.Checked;
            chooseFixPointType();
        }

        private void chooseFixPointType()
        {
            if (fixPointCross.Checked || fixPointCircle.Checked)
            {
                fixPointColorLabel.Enabled = true; fixPointColorPanel.Enabled = true; fixPointColorButton.Enabled = true;
            }
            if (!fixPointCross.Checked && !fixPointCircle.Checked)
            {
                fixPointColorLabel.Enabled = false; fixPointColorPanel.Enabled = false; fixPointColorButton.Enabled = false;
            }
        }

        private void chooseFixPointColor_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            fixPointColorButton.Text = colorCode;
            fixPointColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        //BOX5

        private void activateSubtitles_CheckedChanged(object sender, EventArgs e)
        {
            if (expandImgCheck.Checked && activateSubsCheck.Checked)
                expandImgCheck.Checked = !activateSubsCheck.Checked;

            enableSubsItens(activateSubsCheck.Checked);
        }

        private void enableSubsItens (bool subsEnabledBool)
        {
            
            openSubsListButton.Enabled = subsEnabledBool;
            subLocationLabel.Enabled = subsEnabledBool;
            foreach (Button button in subDirectionList)
            {
                subDirectionNumber = 1;
                button.Enabled = subsEnabledBool;
                if (subsEnabledBool) button.BackColor = Color.LightGray;
                else button.BackColor = Color.White;
            }
            subColorLabel.Enabled = subsEnabledBool; subColorPanel.Enabled = subsEnabledBool; subColorButton.Enabled = subsEnabledBool;
            subsRndCheckBox.Enabled = subsEnabledBool;

            if (subsEnabledBool == false)
            {
                subsRndCheckBox.Enabled = false;
                subsRndCheckBox.Checked = false;
            }
        }

        private void openSubsList_Click(object sender, EventArgs e)
        {
            openSubsListButton.Text = ListController.OpenListFile("_words", openSubsListButton.Text, "lst");
        }

        private void subLocationDown_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(1);
        }

        private void subLocationLeft_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(2);
        }

        private void subLocationRight_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(3);
        }

        private void subLocationUp_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(4);
        }

        private void subLocationCenter_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(5);
        }
        
        private void selectSubDirectionNumber(int number)
        {
            for (int i = 0; i < subDirectionList.Count; i++) // Loop with for.
            {
                subDirectionList[i].BackColor = Color.LightGray;
            }
            subDirectionList[number-1].BackColor = Color.Transparent;
            subDirectionNumber = number;
        }

        private void chooseSubsColor(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            subColorButton.Text = colorCode;
            subColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        //BOX6

        private void chooseBGColor(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            bgColorButton.Text = colorCode;
            bgColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        //BOX7
        
        private void writeInstructionsBox_Click(object sender, EventArgs e)
        {
            if (instructionsBox.Text == instructionBoxText)
            {
                instructionsBox.Text = "";
            }
            instructionsBox.ForeColor = Color.Black;
        }

        


        //WINDOW ITENS

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("stroopConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        
        //SAVE

        private void configureNewProgram()
        {

            StroopProgram programWrite = new StroopProgram();
            try
            {
                switch (chooseExpoType.SelectedIndex)
                {
                    case 0: //txt
                        programWrite.setTxtType(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                                  Convert.ToInt32(numExpo.Value), rndExpoCheck.Checked,
                                                                  wordSizeNumeric.Value.ToString(), Convert.ToInt32(intervalTime.Value),
                                                                  rndIntervalCheck.Checked, openWordListButton.Text,
                                                                  openColorListButton.Text);

                        break;
                    case 1: //img
                        programWrite.setImageType(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                                  Convert.ToInt32(numExpo.Value), rndExpoCheck.Checked,
                                                                  wordSizeNumeric.Value.ToString(), Convert.ToInt32(intervalTime.Value),
                                                                  rndIntervalCheck.Checked, openImgListButton.Text);

                        break;
                    case 2: //imgtxt
                        programWrite.setImgTxtType(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                                  Convert.ToInt32(numExpo.Value), rndExpoCheck.Checked,
                                                                  wordSizeNumeric.Value.ToString(), Convert.ToInt32(intervalTime.Value),
                                                                  openWordListButton.Text, openImgListButton.Text, rndIntervalCheck.Checked);

                        break;
                    case 3: //txtaud
                        programWrite.setTxtAudType(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                                  Convert.ToInt32(numExpo.Value), rndExpoCheck.Checked,
                                                                  wordSizeNumeric.Value.ToString(), Convert.ToInt32(intervalTime.Value),
                                                                  rndIntervalCheck.Checked, openWordListButton.Text,
                                                                  openColorListButton.Text, openAudioListButton.Text);

                        break;
                    case 4: //imgaud
                        programWrite.setImgAudioType(openImgListButton.Text, openAudioListButton.Text, prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                      Convert.ToInt32(numExpo.Value), rndExpoCheck.Checked,
                                      wordSizeNumeric.Value.ToString(), Convert.ToInt32(intervalTime.Value),
                                      rndIntervalCheck.Checked);
                        break;
                    case 5: //txtimg
                        programWrite.setTxtImgType(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                                      Convert.ToInt32(numExpo.Value), rndExpoCheck.Checked,
                                                                      wordSizeNumeric.Value.ToString(), Convert.ToInt32(intervalTime.Value),
                                                                      openWordListButton.Text, openImgListButton.Text, rndIntervalCheck.Checked);
                        break;
                }

                if (Validations.isHexPattern(bgColorButton.Text)) { programWrite.BackgroundColor = bgColorButton.Text; }

                programWrite.AudioCapture = audioCaptureCheck.Checked;
                programWrite.SubtitleShow = activateSubsCheck.Checked;

                if (activateSubsCheck.Checked)
                {
                    if (Validations.isHexPattern(subColorButton.Text)) { programWrite.SubtitleColor = subColorButton.Text; }
                    if (openSubsListButton.Text != "abrir") { programWrite.SubtitlesListFile = openSubsListButton.Text; }
                    programWrite.SubtitlePlace = subDirectionNumber;
                }
                if (fixPointCross.Checked)
                {
                    programWrite.FixPoint = "+";
                }
                if (fixPointCircle.Checked)
                {
                    programWrite.FixPoint = "o";
                }
                if (Validations.isHexPattern(fixPointColorButton.Text))
                {
                    programWrite.FixPointColor = fixPointColorButton.Text;
                }

                if (Validations.isHexPattern(wordColorButton.Text))
                    programWrite.WordColor = wordColorButton.Text;
                else
                    programWrite.WordColor = "false";

                programWrite.DelayTime = Convert.ToInt32(delayTime.Value);
                switch (rotateImgComboBox.SelectedIndex)
                {
                    case 0:
                        programWrite.RotateImage  = 0;
                        break;
                    case 1:
                        programWrite.RotateImage = 45;
                        break;
                    case 2:
                        programWrite.RotateImage = 90;
                        break;
                    case 3:
                        programWrite.RotateImage = 135;
                        break;
                    case 4:
                        programWrite.RotateImage = 180;
                        break;
                    case 5:
                        programWrite.RotateImage = 225;
                        break;
                    case 6:
                        programWrite.RotateImage = 270;
                        break;
                    case 7:
                        programWrite.RotateImage = 315;
                        break;
                }


                string textLines = "";
                if (instructionsBox.Lines.Length > 0 && instructionsBox.Text != instructionBoxText) // lê instrução se houver
                {
                    for (int i = 0; i < instructionsBox.Lines.Length; i++)
                    {
                        programWrite.InstructionText.Add(instructionsBox.Lines[i]);
                        textLines = textLines + "\n" + instructionsBox.Lines[i];
                    }
                }
                else
                {
                    programWrite.InstructionText = null;
                }
                programWrite.RndSubtitlePlace = subsRndCheckBox.Checked;
                programWrite.FontWordLabel = wordSizeNumeric.Value.ToString();
                programWrite.ExpandImage = expandImgCheck.Checked;
                saveProgramFile(programWrite);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void editProgram()
        {
            StroopProgram program = new StroopProgram();
            try
            {
                program.readProgramFile(path + editPrgName + ".prg");
            }
            catch(FileNotFoundException e)
            {
                MessageBox.Show(LocRM.GetString("cantEdìtProgramMissingFiles", currentCulture) + e.Message);
                return;
            }
            prgNameTextBox.Text = program.ProgramName;
            numExpo.Value = program.NumExpositions;
            expoTime.Value = program.ExpositionTime;
            rndExpoCheck.Checked = program.ExpositionRandom;
            intervalTime.Value = program.IntervalTime;
            rndIntervalCheck.Checked = program.IntervalTimeRandom;
            audioCaptureCheck.Checked = program.AudioCapture;
            wordSizeNumeric.Value = Convert.ToInt32(program.FontWordLabel);
            expandImgCheck.Checked = program.ExpandImage;
            subsRndCheckBox.Checked = program.RndSubtitlePlace;

            if (program.getWordListFile() != null)
            {
                openWordListButton.Enabled = true;
                openWordListButton.Text = program.getWordListFile().ListName;

            }
            else
            {
                openWordListButton.Enabled = false;
            }

            if (program.getColorListFile() != null)
            {
                openColorListButton.Enabled = true;
                openColorListButton.Text = program.getColorListFile().ListName;
            }
            else
            {
                openColorListButton.Enabled = false;
            }

            if (program.getImageListFile() != null)
            {
                openImgListButton.Enabled = true;
                openImgListButton.Text = program.getImageListFile().ListName;
            }
            else
            {
                openImgListButton.Enabled = false;
            }

            if (program.getAudioListFile() != null)
            {
                openAudioListButton.Enabled = true;
                openAudioListButton.Text = program.getAudioListFile().ListName;
            }
            else
            {
                openAudioListButton.Enabled = false;

            }

            if (program.BackgroundColor.ToLower() == "false")
            {
                bgColorPanel.BackColor = Color.White;
                bgColorButton.Text = "escolher";
            }
            else
            {
                if ((Validations.isHexPattern(program.BackgroundColor)))
                {
                    bgColorButton.Text = program.BackgroundColor;
                    bgColorPanel.BackColor = ColorTranslator.FromHtml(program.BackgroundColor);
                }
            }

            if (program.FixPointColor.ToLower() == "false")
            {
                fixPointColorPanel.BackColor = ColorTranslator.FromHtml("#D01C1F");
                fixPointColorButton.Text = "#D01C1F";
            }
            else
            {
                if ((Validations.isHexPattern(program.FixPointColor)))
                {
                    fixPointColorButton.Text = program.FixPointColor;
                    fixPointColorPanel.BackColor = ColorTranslator.FromHtml(program.FixPointColor);
                }
                else
                {
                    throw new Exception(LocRM.GetString("colorMatch", currentCulture));
                }
            }


            delayTime.Value = program.DelayTime;

            switch (program.RotateImage)
            {
                case 45:
                    rotateImgComboBox.SelectedIndex = 1;
                    break;
                case 90:
                    rotateImgComboBox.SelectedIndex = 2;
                    break;
                case 135:
                    rotateImgComboBox.SelectedIndex = 3;
                    break;
                case 180:
                    rotateImgComboBox.SelectedIndex = 4;
                    break;
                case 225:
                    rotateImgComboBox.SelectedIndex = 5;
                    break;
                case 270:
                    rotateImgComboBox.SelectedIndex = 6;
                    break;
                case 315:
                    rotateImgComboBox.SelectedIndex = 7;
                    break;
                default:
                    rotateImgComboBox.SelectedIndex = 0;
                    break;
            }

            if (program.FixPoint == "+")
            {
                fixPointCross.Checked = true;
                fixPointCircle.Checked = false;
            }
            else
            {
                if (program.FixPoint == "o")
                {
                    fixPointCross.Checked = false;
                    fixPointCircle.Checked = true;
                }
                else
                {
                    fixPointCross.Checked = false;
                    fixPointCircle.Checked = false;
                }
            }
            chooseFixPointType();

            // reads instructions if there are any to instruction box text
            if (program.InstructionText != null)
            {
                instructionsBox.ForeColor = Color.Black;
                instructionsBox.Text = program.InstructionText[0];
                for (int i = 1; i < program.InstructionText.Count; i++)
                {
                    instructionsBox.AppendText(Environment.NewLine + program.InstructionText[i]);
                }
            }
            else
            {
                instructionsBox.Text = instructionBoxText;
            }

            switch (program.ExpositionType)
            {
                case "txt":
                    chooseExpoType.SelectedIndex = 0;
                    openWordListButton.Enabled = true;
                    openColorListButton.Enabled = true;
                    openImgListButton.Enabled = false;
                    openAudioListButton.Enabled = false;
                    break;
                case "img":
                    chooseExpoType.SelectedIndex = 1;
                    openWordListButton.Enabled = false;
                    openColorListButton.Enabled = false;
                    openImgListButton.Enabled = true;
                    openAudioListButton.Enabled = false;
                    break;
                case "imgtxt":
                    chooseExpoType.SelectedIndex = 2;
                    openWordListButton.Enabled = true;
                    openColorListButton.Enabled = false;
                    openImgListButton.Enabled = true;
                    openAudioListButton.Enabled = false;
                    break;
                case "txtaud":
                    chooseExpoType.SelectedIndex = 3;
                    openWordListButton.Enabled = true;
                    openColorListButton.Enabled = true;
                    openImgListButton.Enabled = false;
                    openAudioListButton.Enabled = true;
                    break;
                case "imgaud":
                    chooseExpoType.SelectedIndex = 4;
                    openWordListButton.Enabled = false;
                    openColorListButton.Enabled = false;
                    openImgListButton.Enabled = true;
                    openAudioListButton.Enabled = true;
                    break;
            }

            if (program.SubtitleShow)
            {
                activateSubsCheck.Checked = true;
                enableSubsItens(true);
                selectSubDirectionNumber(program.SubtitlePlace);

                if (program.SubtitlesListFile.ToLower() != "false")
                {
                    openSubsListButton.Text = program.SubtitlesListFile;
                }
                else
                {
                    openSubsListButton.Text = LocRM.GetString("choose", currentCulture);
                }

                if (Validations.isHexPattern(program.SubtitleColor))
                {
                    subColorButton.Text = program.SubtitleColor;
                    subColorPanel.BackColor = ColorTranslator.FromHtml(program.SubtitleColor);
                }
                else
                {
                    subColorButton.Text = LocRM.GetString("choose", currentCulture);
                    subColorPanel.BackColor = Color.White;
                }
            }
            else
            {
                activateSubsCheck.Checked = false;
                enableSubsItens(false);
            }

            wordColorButton.Text = program.WordColor;
            wordColorPanel.BackColor = ColorTranslator.FromHtml(program.WordColor);

        }

        private void saveProgramFile(StroopProgram newProgram)
        {
            if (File.Exists(path + prgNameTextBox.Text + ".prg"))
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("programExists", currentCulture), "", MessageBoxButtons.OKCancel);
                if (dialogResult != DialogResult.Cancel)
                {
                    if (newProgram.saveProgramFile(path, instructionBoxText))
                    {
                        MessageBox.Show(LocRM.GetString("programSave", currentCulture));
                    }
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("programNotSave", currentCulture));
                }
            }
            else
            {
                if (newProgram.saveProgramFile(path, instructionBoxText))
                {
                    MessageBox.Show(LocRM.GetString("programSave", currentCulture));
                }
                this.Parent.Controls.Remove(this);
            }            
        }

        public bool save()
        {
            saveButton_Click(this, null);
            foreach (Control c in this.errorProvider.ContainerControl.Controls)
            { 
                if (errorProvider.GetError(c) != "")
                {
                    return false;
                }
            }
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                configureNewProgram();
            }
            else
            {
                MessageBox.Show(LocRM.GetString("notFilledProperlyMessage", currentCulture));
            }
        }

        private void prgNameTextBox_Validating(object sender,
                 System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidProgramName(prgNameTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider.SetError(prgNameTextBox, errorMsg);
            }
        }

        private void prgNameTextBox_Validated(object sender, System.EventArgs e)
        {
            errorProvider.SetError(prgNameTextBox, "");
        }

        public bool ValidProgramName(string pgrName, out string errorMessage)
        {
            if (pgrName.Length == 0)
            {
                errorMessage = LocRM.GetString("programNotFilled", currentCulture);
                return false;
            }
            if (!Validations.isAlphanumeric(pgrName))
            {
                errorMessage = LocRM.GetString("programNotAlphanumeric", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void expoTimeNumericUpDown_Validating(object sender,
         System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidExpoTime(Convert.ToInt32(this.expoTime.Value), out errorMsg))
            {
                e.Cancel = true; 
                this.errorProvider1.SetError(this.expoTime, errorMsg);
            }
        }

        private void expoTimeNumericUpDown_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(expoTime, "");
        }

        public bool ValidExpoTime(int expoTime, out string errorMessage)
        {
            if (!Validations.isExpositionTimeValid(expoTime))
            {
                errorMessage = LocRM.GetString("expoTime", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }


        private void intervalTime_Validating(object sender,
                                                      System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidIntervalTime(Convert.ToInt32(this.intervalTime.Value), out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.intervalTime, errorMsg);
            }
        }

        private void intervalTime_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(intervalTime, "");
        }

        public bool ValidIntervalTime(int intervalTime, out string errorMessage)
        {
            if (!Validations.isIntervalTimeValid(intervalTime))
            {
                errorMessage = LocRM.GetString("intervalTime", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void numExpo_Validating(object sender,
         System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidnumExpo(Convert.ToInt32(this.numExpo.Value), out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.numExpo, errorMsg);
            }
        }

        private void numExpo_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(numExpo, "");
        }

        public bool ValidnumExpo(int numExpo, out string errorMessage)
        {
            if (!Validations.isExpositionTimeValid(numExpo))
            {
                errorMessage = LocRM.GetString("expoNumber", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }


        private void openWordList_Validating(object sender,
         System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenWordList(openWordListButton.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openWordListButton, errorMsg);
            }
        }

        private void openWordList_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openWordListButton, "");
        }

        public bool ValidopenWordList(string text, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openWordListButton) && !Validations.isLengthValid(text))
            {
                errorMessage = LocRM.GetString("selectWord", currentCulture);
                return false;
            }
            errorMessage = "";
            return true;
        }

        private void openColorListButton_Validating(object sender,
                                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenColorListButton(openColorListButton.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openColorListButton, errorMsg);
            }
        }

        private void openColorListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openColorListButton, "");
        }

        public bool ValidopenColorListButton(string text, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openColorListButton) && !Validations.isLengthValid(text))
            {
                errorMessage = LocRM.GetString("selectColor", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void openImgListButton_Validating(object sender,
                                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenImgListButton(openImgListButton.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openImgListButton, errorMsg);
            }
        }

        private void openImgListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openImgListButton, "");
        }

        public bool ValidopenImgListButton(string text, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openImgListButton) && !Validations.isLengthValid(text))
            {
                errorMessage = LocRM.GetString("selectImage", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }



        private void openAudioListButton_Validating(object sender,
                                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenAudioListButton(openAudioListButton.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openAudioListButton, errorMsg);
            }
        }

        private void openAudioListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openAudioListButton, "");
        }

        public bool ValidopenAudioListButton(string text, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openAudioListButton) && !Validations.isLengthValid(text))
            {
                errorMessage = LocRM.GetString("selectImage", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control.GetType() == typeof(FormPrgConfig))
            {
                int count = 0;
                foreach (Control control in Controls)
                {
                    if (control is FormPrgConfig)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    Controls.Remove(e.Control);
                }
            }
        }

        private bool validExpoType(int index, out string errorMessage)
        {
            if (index >= 0 && index <= 5)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("expoTypeError", currentCulture);
                return false;
            }
        }

        private void chooseExpoType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!validExpoType(chooseExpoType.SelectedIndex, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.chooseExpoType, errorMsg);
            }
        }

        private void chooseExpoType_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(chooseExpoType, "");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void expoTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void intervalTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void delayTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void activateSubsLabel_Click(object sender, EventArgs e)
        {

        }

        private void subLocationLabel_Click(object sender, EventArgs e)
        {

        }

        private void subsRndCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void subColorLabel_Click(object sender, EventArgs e)
        {

        }

        private void fixPointTypeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
