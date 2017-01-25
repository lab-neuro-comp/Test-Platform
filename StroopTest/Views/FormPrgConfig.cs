/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;

namespace StroopTest
{
    public partial class FormPrgConfig : Form
    {
        private String path;
        private String instructionBoxText = "Escreva cada uma das intruções em linhas separadas.";
        private List<Button> subDirectionList = new List<Button>();
        private Int32 subDirectionNumber = 1;
        private String fontSize = "160";
        private String editPrgName = "error";
        private String instructionsText = HelpData.ProgramConfigInstructions;

        public FormPrgConfig(string dataFolderPath, string prgName)
        {
            InitializeComponent();
            path = dataFolderPath;
            chooseExpoType.SelectedIndex = 0;
            rotateImgComboBox.SelectedIndex = 0;
            subDirectionList.Add(subsDownButton);
            subDirectionList.Add(subsLeftButton);
            subDirectionList.Add(subsRightButton);
            subDirectionList.Add(subsUpButton);
            subDirectionList.Add(subsCenterButton);
            enableSubsItens(false);

            toolTipsConfig();
            
            if (prgName != "false")
            {
                editPrgName = prgName;
                editProgram();
            }
        }

        private void toolTipsConfig()
        {

            var helpToolTip = new ToolTip();

            helpToolTip.ToolTipIcon = ToolTipIcon.Info;
            helpToolTip.IsBalloon = true;
            helpToolTip.ShowAlways = true;


            // colocar em lista e deixar dinâmico

            helpToolTip.SetToolTip(prgNameLabel, "Nome do esquema de apresentação de estímulos");
            helpToolTip.SetToolTip(expoTypeLabel, "Categoria dos estímulos do programa");
            helpToolTip.SetToolTip(rndExpoLabel, "Exposição dos estímulos em ordem aleatória em relação à lista");
            helpToolTip.SetToolTip(numExpoLabel, "Número de vezes em que os estímulos serão expostos");
            helpToolTip.SetToolTip(wordSizeLabel, "Tamanho da fonte do texto, para exposição do tipo Palavra, Palavra com áudio, Imagem e palavra");
            helpToolTip.SetToolTip(wordColorLabel, "Cor da palavra, para exposição do tipo Imagem e Palavra");
            helpToolTip.SetToolTip(wordListLabel, "Arquivo de Lista de palavras");
            helpToolTip.SetToolTip(colorListLabel, "Arquivo de Lista de cores");
            helpToolTip.SetToolTip(imgListLabel, "Arquivo de Lista de imagens");
            helpToolTip.SetToolTip(audioListLabel, "Arquivo de Lista de áudio");
            helpToolTip.SetToolTip(expoTimeLabel, "Duração da exposição de cada estímulo");
            helpToolTip.SetToolTip(intervalTimeLabel, "Tempo entre as tentativas");
            helpToolTip.SetToolTip(rndIntervalLabel, "Variação do tempo entre as tentativas");
            helpToolTip.SetToolTip(fixPointTypeLabel, "Tipo de ponto de fixação: cruz ou ponto");
            helpToolTip.SetToolTip(fixPointColorLabel, "Cor do ponto de fixação");
            helpToolTip.SetToolTip(activateSubsLabel, "Ativa legenda para estímulos do tipo imagem");
            helpToolTip.SetToolTip(subLocationLabel, "Posicionamento da legenda em relação aos estímulos");
            helpToolTip.SetToolTip(subColorLabel, "Cor da legenda apresentada");
            helpToolTip.SetToolTip(audioCaptureLabel, "Ativa captura de áudio durante a execução do teste");
            helpToolTip.SetToolTip(bgColorLabel, "Cor de fundo durante a apresentação dos estímulos");
            helpToolTip.SetToolTip(expandImgLabel, "Expande a imagem até as bordas da tela");
            helpToolTip.SetToolTip(instructionsLabel, "Instruções apresentadas no início do programa - será apresentada um tela para cada linha escrita abaixo");
            helpToolTip.SetToolTip(helpButton, "Ajuda");
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            Close();
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
            string colorCode = pickColor();
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
            openWordListButton.Text = openListFile("_words");
        }

        private void openColorsList_Click(object sender, EventArgs e)
        {
            openColorListButton.Text = openListFile("_color");
        }

        private void openImagesList_Click(object sender, EventArgs e)
        {
            openImgListButton.Text = openListFile("_image");
        }

        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = openListFile("_audio");
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
            string colorCode = pickColor();
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
            openSubsListButton.Text = openListFile("_words");
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
            string colorCode = pickColor();
            subColorButton.Text = colorCode;
            subColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        //BOX6

        private void chooseBGColor(object sender, EventArgs e)
        {
            string colorCode = pickColor();
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

        //AUX FUNCTIONS


        private string openListFile(string itemType)
        {
            string progName = "abrir";

            FormDefine defineProgram = new FormDefine("Lista: ", path + "/lst/", "lst", itemType, false);
            var result = defineProgram.ShowDialog();

            if (result == DialogResult.OK)
            {
                progName = defineProgram.ReturnValue + itemType +".lst";
            }

            return progName;
        }

        private string pickColor()
        {
            ColorDialog MyDialog = new ColorDialog();
            Color colorPicked = new Color();

            MyDialog.CustomColors = new int[] {
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#F8E000")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#007BB7")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#7EC845")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#D01C1F"))
                                      };
            colorPicked = this.BackColor;

            string hexColor = "#FFFFFF";

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = MyDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }

            return hexColor;
        }

        //WINDOW ITENS

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(instructionsText);
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
                    case 2: //txtimg
                            programWrite.setImgTxtType(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                                      Convert.ToInt32(numExpo.Value), rndExpoCheck.Checked,
                                                                      wordSizeNumeric.Value.ToString(), Convert.ToInt32(intervalTime.Value),
                                                                      openWordListButton.Text , openImgListButton.Text, rndIntervalCheck.Checked);
                        
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
                programWrite.FontWordLabel = wordSizeNumeric.Value.ToString();
                programWrite.ExpandImage = expandImgCheck.Checked;
                saveProgramFile(programWrite.data(), programWrite.InstructionText);
                this.Close();
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
                program.readProgramFile(path + "/prg/" + editPrgName + ".prg");
                
                prgNameTextBox.Text = program.ProgramName;
                numExpo.Value = program.NumExpositions;
                expoTime.Value = program.ExpositionTime;
                rndExpoCheck.Checked = program.ExpositionRandom;
                intervalTime.Value = program.IntervalTime;
                rndIntervalCheck.Checked = program.IntervalTimeRandom;
                audioCaptureCheck.Checked = program.AudioCapture;
                wordSizeNumeric.Value = Convert.ToInt32(program.FontWordLabel);
                expandImgCheck.Checked = program.ExpandImage;

                if (program.WordsListFile.ToLower() == "false") { openWordListButton.Enabled = false; }
                else { openWordListButton.Enabled = true; openWordListButton.Text = program.WordsListFile; }

                if (program.ColorsListFile.ToLower() == "false") { openColorListButton.Enabled = false; }
                else { openColorListButton.Enabled = true; openColorListButton.Text = program.ColorsListFile; }

                if (program.ImagesListFile.ToLower() == "false") { openImgListButton.Enabled = false; }
                else { openImgListButton.Enabled = true; openImgListButton.Text = program.ImagesListFile; }

                if (program.AudioListFile.ToLower() == "false") { openAudioListButton.Enabled = false; }
                else { openAudioListButton.Enabled = true; openAudioListButton.Text = program.AudioListFile; }
                
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
                    else { throw new Exception("Deu errado no match"); }
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

                if (program.InstructionText != null) // lê instrução se houver
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
                    if (program.SubtitlesListFile.ToLower() != "false") { openSubsListButton.Text = program.SubtitlesListFile; }
                    else { openSubsListButton.Text = "escolher"; }

                    if (Validations.isHexPattern(program.SubtitleColor))
                    {
                        subColorButton.Text = program.SubtitleColor;
                        subColorPanel.BackColor = ColorTranslator.FromHtml(program.SubtitleColor);
                    }
                    else
                    {
                        subColorButton.Text = "escolher";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dispose();
                Close();
            }
        }
        
        private void saveProgramFile(string programText, List<string> instructions)
        {
            if (File.Exists(path + "prg/" + prgNameTextBox.Text + ".prg"))
            {
                DialogResult dialogResult = MessageBox.Show("O programa já existe, deseja sobrescrevê-lo?", "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    throw new Exception("O programa não será salvo!");
                }
            }

            StreamWriter writer = new StreamWriter(path + "prg/" + prgNameTextBox.Text + ".prg");
            writer.WriteLine(programText);
            if (instructions != null && instructions[0] != instructionBoxText)
            {
                for (int i = 0; i < instructions.Count; i++)
                {
                    writer.WriteLine(instructions[i]);
                }
            }
            writer.Close();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren(ValidationConstraints.Enabled))
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");
            else
                configureNewProgram();
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
                errorMessage = "O nome do programa deve ser preenchido.";
                return false;
            }
            if (!Validations.isAlphanumeric(pgrName))
            {
                errorMessage = "Nome do programa deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'MeuPrograma'";
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
                errorMessage = "O tempo de exposição deve ser maior do que zero.";
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
                errorMessage = "Tempo de intervalo deve ser maior que zero (em milissegundos)";
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
                errorMessage = "O número de exposições deve ser maior do que zero.";
                return false;
            }

            errorMessage = "";
            return true;
        }


        private void openWordList_Validating(object sender,
         System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenWordList(openWordListButton.Text.Length, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openWordListButton, errorMsg);
            }
        }

        private void openWordList_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openWordListButton, "");
        }

        public bool ValidopenWordList(int length, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openWordListButton) && !Validations.isLengthValid(length))
            {
                Console.WriteLine(Validations.isExpoEnabled(openWordListButton));
                errorMessage = "Selecione o arquivo de lista de palavras!";
                return false;
            }
            Validations.isExpoEnabled(openWordListButton);
            errorMessage = "";
            return true;
        }

        private void openColorListButton_Validating(object sender,
                                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenColorListButton(openColorListButton.Text.Length, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openColorListButton, errorMsg);
            }
        }

        private void openColorListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openColorListButton, "");
        }

        public bool ValidopenColorListButton(int length, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openColorListButton) && !Validations.isLengthValid(length))
            {
                errorMessage = "Selecione o arquivo de lista de cores!";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void openImgListButton_Validating(object sender,
                                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenImgListButton(openImgListButton.Text.Length, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openImgListButton, errorMsg);
            }
        }

        private void openImgListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openImgListButton, "");
        }

        public bool ValidopenImgListButton(int length, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openImgListButton) && !Validations.isLengthValid(length))
            {
                errorMessage = "Selecione o arquivo de lista de imagem!";
                return false;
            }

            errorMessage = "";
            return true;
        }



        private void openAudioListButton_Validating(object sender,
                                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenAudioListButton(openAudioListButton.Text.Length, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openAudioListButton, errorMsg);
            }
        }

        private void openAudioListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openAudioListButton, "");
        }

        public bool ValidopenAudioListButton(int length, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openAudioListButton) && !Validations.isLengthValid(length))
            {
                errorMessage = "Selecione o arquivo de lista de audio!";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            Close();
        }

        private void subsRndCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
