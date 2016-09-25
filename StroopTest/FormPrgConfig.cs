/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormPrgConfig : Form
    {
        private string path;
        private string instructionBoxText = "Escreva cada uma das intruções em linhas separadas.";
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private List<Button> subDirectionList = new List<Button>();
        private int subDirectionNumber = 1;
        private string fontSize = "160";
        private string editPrgName = "error";
        private string prgConfigInstructionsText = "\n- Nome do Arquivo onde o programa será salvo\n" +
                                                 "\n- Tipo de Estímulo: Texto; Imagem; Imagem e Texto; Texto e Áudio; Imagem e Áudio\n" +
                                                 "\n- Aleatoriedade na apresentação; as exposições ocorrerão de forma aleatória\n" +
                                                 "\n- Número de Estímulos (quantidade de estímulos a serem expostos)\n" +
                                                 "\n- Dimensão da letra em estímulos do tipo texto\n" +
                                                 "\n- Cor das palavras que serão revezadas com imagens (Imagem com Palavra)\n" +
                                                 "\n- Arquivo de Lista de palavras (um estímulo palavra por linha, arquivo .lst)\n" +
                                                 "\n- Arquivo de Lista de cores (um código hexadecimal de cor por linha, arquivo .lst)\n" +
                                                 "\n- Arquivo de Lista de imagens (um caminho de imagem por linha, arquivo .lst)\n" +
                                                 "\n- Arquivo de Lista de áudio (um caminho de arquivos de áudi por linha, arquivo .lst)\n" +
                                                 "\n- Tempo de exposição para cada estímulo (quanto tempo uma palavra, imagem permanece exposta)\n" +
                                                 "\n- Tempo de intervalo entre estímulos (quanto tempo de pausa faz-se entre duas exposições de estímulo)\n" +
                                                 "\n- Aleatoriedade no tempo de intervalo entre estímulos\n" +
                                                 "\n- Tipo de ponto de fixação: cruz ou círculo (ponto de fixação surge durante o intervalo)\n" +
                                                 "\n- Cor do ponto de fixação\n" +
                                                 "\n- Ativa legenda para estímulos do tipo imagem - selecione uma lista com as legendas\n" +
                                                 "\n- Posicionamento da legenda em relação aos estímulos\n" +
                                                 "\n- Cor da legenda apresentada\n" +
                                                 "\n- Ativa captura de áudio durante a execução do teste\n" +
                                                 "\n- Cor de fundo durante a apresentação dos estímulos\n" +
                                                 "\n- Expande estímulos de imagem até as bordas da tela - não pode ocorrer simultaneamente à apresentação de legenda\n" +
                                                 "\n- Instruções apresentadas no início do programa - será apresentada um tela para cada linha escrita abaixo\n";

        public FormPrgConfig(string dataFolderPath, string prgName)
        {
            InitializeComponent();
            path = dataFolderPath;
            chooseExpoType.SelectedIndex = 0;
            subDirectionList.Add(subsDownButton);
            subDirectionList.Add(subsLeftButton);
            subDirectionList.Add(subsRightButton);
            subDirectionList.Add(subsUpButton);
            subDirectionList.Add(subsCenterButton);

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
            helpToolTip.SetToolTip(saveButton, "Salva o programa configurado");
            helpToolTip.SetToolTip(helpButton, "Ajuda");
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void activateSubtitles_CheckedChanged(object sender, EventArgs e)
        {
            if (expandImgCheck.Checked && activateSubsCheck.Checked)
                expandImgCheck.Checked = !activateSubsCheck.Checked;

            enableSubsItens(activateSubsCheck.Checked);
        }
        /*
        private void subtitlesCheckConfig()
        {
            if (activateSubsCheck.Checked)
            {
                foreach (Button b in subDirectionList)
                {
                    b.Enabled = true;
                    b.BackColor = Color.Transparent;
                }
                activateSubsButton.Enabled = true;
                subColorButton.Enabled = true;

                subColorPanel.Enabled = true;

                subColorPanel.BackColor = Color.Transparent;
                subsCenterButton.BackColor = Color.Transparent; // habilitar botões de posicao legenda

                expandImgCheck.Enabled = false;
                expandImgCheck.Checked = false;

            }
            else
            {
                activateSubsButton.Visible = false; activateSubsButton.Enabled = false;
                foreach (Button b in subDirectionList)
                {
                    b.Enabled = false;
                    b.BackColor = Color.LightGray;
                }
                subColorButton.Enabled = false;;
                subColorPanel.Enabled = false; subColorPanel.BackColor = Color.LightGray;
                expandImgCheck.Enabled = true;
            }
        }
        */
        private void chooseExpositionTypeComboBox(object sender, EventArgs e)
        {
            configurePrgItens(chooseExpoType.SelectedIndex);
        }

        private void configurePrgItens(int expoType)
        {
            numExpo.Enabled = true; numExpoLabel.Enabled = true;
            rndExpoLabel.Enabled = true; rndExpoCheck.Enabled = true;

            switch (expoType)
            {
                case 0: // txt
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

        private void enableSubsItens (bool subsEnabledBool)
        {
            activateSubsButton.Enabled = subsEnabledBool;
            subLocationLabel.Enabled = subsEnabledBool;
            foreach (Button button in subDirectionList)
            {
                subDirectionNumber = 1;
                button.Enabled = subsEnabledBool;
                if (subsEnabledBool) button.BackColor = Color.LightGray;
                else button.BackColor = Color.White;
            }
            subColorLabel.Enabled = subsEnabledBool; subColorPanel.Enabled = subsEnabledBool; subColorButton.Enabled = subsEnabledBool;
        }

        private void chooseBGColor(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            bgColorButton.Text = colorCode;
            bgColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void chooseSubsColor(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            subColorButton.Text = colorCode;
            subColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void openWordsList_Click(object sender, EventArgs e)
        {
            openWordListButton.Text = openListFile();
        }

        private void openColorsList_Click(object sender, EventArgs e)
        {
            openColorListButton.Text = openListFile();
        }

        private void openImagesList_Click(object sender, EventArgs e)
        {
            openImgListButton.Text = openListFile();
        }
        
        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = openListFile();
        }
        
        private void openSubsList_Click(object sender, EventArgs e)
        {
            activateSubsButton.Text = openListFile();
        }

        private void writeInstructionsBox_Click(object sender, EventArgs e)
        {
            if (instructionsBox.Text == instructionBoxText)
            {
                instructionsBox.Text = "";
            }
            instructionsBox.ForeColor = Color.Black;
        }

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

        private void chooseFixPointColor_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            fixPointColorButton.Text = colorCode;
            fixPointColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void wordSizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            fontSize = wordSizeNumeric.Value.ToString();
        }

        private void expandImageOn_CheckedChanged(object sender, EventArgs e)
        {
            if (expandImgCheck.Checked && activateSubsCheck.Checked)
                activateSubsCheck.Checked = !expandImgCheck.Checked;

            enableSubsItens(activateSubsCheck.Checked);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            showPrgConfigInstructions();
        }

        private void showPrgConfigInstructions()
        {
            FormInstructions infoBox = new FormInstructions((path + "prgConfigHelp.txt"), prgConfigInstructionsText);
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message);/*MessageBox.Show(ex.Message);*/ }
        }

        private void chooseWordColor_Click_1(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            wordColorButton.Text = colorCode;
            wordColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void configureNewProgram(object sender, EventArgs e)
        {

            StroopProgram programWrite = new StroopProgram();

            try
            {
                programWrite.ProgramName = prgNameTextBox.Text;
                programWrite.NumExpositions = Convert.ToInt32(numExpo.Value);
                programWrite.ExpositionRandom = rndExpoCheck.Checked;
                programWrite.FontWordLabel = wordSizeNumeric.Value.ToString();
                programWrite.ExpositionTime = Convert.ToInt32(expoTime.Value);
                programWrite.IntervalTime = Convert.ToInt32(intervalTime.Value);
                programWrite.IntervalTimeRandom = rndIntervalCheck.Checked;
                
                switch (chooseExpoType.SelectedIndex)
                {
                    case 0: //txt
                        if (openWordListButton.Text != "abrir") { programWrite.WordsListFile = openWordListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras!"); }
                        if (openColorListButton.Text != "abrir") { programWrite.ColorsListFile = openColorListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de cores!"); }
                        programWrite.ImagesListFile = "false"; programWrite.AudioListFile = "false";
                        break;
                    case 1: //img
                        programWrite.WordsListFile = "false"; programWrite.ColorsListFile = "false";
                        if (openImgListButton.Text != "abrir") { programWrite.ImagesListFile = openImgListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de imagens!"); }
                        programWrite.AudioListFile = "false";
                        break;
                    case 2: //txtimg
                        programWrite.ColorsListFile = "false";
                        if (openWordListButton.Text != "abrir") { programWrite.WordsListFile = openWordListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras!"); }
                        if (openImgListButton.Text != "abrir") { programWrite.ImagesListFile = openImgListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de imagens!"); }
                        programWrite.AudioListFile = "false";
                        break;
                    case 3: //txtaud
                        if (openWordListButton.Text != "abrir") { programWrite.WordsListFile = openWordListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras!"); }
                        if (openColorListButton.Text != "abrir") { programWrite.ColorsListFile = openColorListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de cores!"); }
                        programWrite.ImagesListFile = "false";
                        if (openAudioListButton.Text != "abrir") { programWrite.AudioListFile = openAudioListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de audio!"); }
                        break;
                    case 4: //imgaud
                        programWrite.WordsListFile = "false"; programWrite.ColorsListFile = "false";
                        if (openImgListButton.Text != "abrir") { programWrite.ImagesListFile = openImgListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de imagens!"); }
                        if (openAudioListButton.Text != "abrir") { programWrite.AudioListFile = openAudioListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de audio!"); }
                        break;
                }

                if (Regex.IsMatch(bgColorButton.Text, hexPattern)) { programWrite.BackgroundColor = bgColorButton.Text; }
                else programWrite.BackgroundColor = "false";

                programWrite.AudioCapture = audioCaptureCheck.Checked;
                programWrite.SubtitleShow = activateSubsCheck.Checked;

                programWrite.SubtitlePlace = subDirectionNumber;

                if (activateSubsCheck.Checked)
                {
                    if (Regex.IsMatch(subColorButton.Text, hexPattern)) programWrite.SubtitleColor = subColorButton.Text;
                    else programWrite.SubtitleColor = "false";

                    programWrite.SubtitlesListFile = activateSubsButton.Text;
                }
                else
                {
                    programWrite.SubtitleColor = "false";
                    programWrite.SubtitlesListFile = "false";
                }

                switch (chooseExpoType.SelectedIndex)
                {
                    case 0:
                        programWrite.ExpositionType = "txt";
                        break;
                    case 1:
                        programWrite.ExpositionType = "img";
                        break;
                    case 2:
                        programWrite.ExpositionType = "imgtxt";
                        break;
                    case 3:
                        programWrite.ExpositionType = "txtaud";
                        break;
                    case 4:
                        programWrite.ExpositionType = "imgaud";
                        break;
                }

                if (openImgListButton.Enabled) { programWrite.ImagesListFile = openImgListButton.Text; }
                else { programWrite.ImagesListFile = "false"; }
                
                if (fixPointCross.Checked)
                {
                    programWrite.FixPoint = "+";
                }
                else
                {
                    if (fixPointCircle.Checked)
                    {
                        programWrite.FixPoint = "o";
                    }
                    if (!fixPointCross.Checked && !fixPointCircle.Checked)
                    {
                        programWrite.FixPoint = "false";
                    }
                }

                if (Regex.IsMatch(fixPointColorButton.Text, hexPattern)) programWrite.FixPointColor = fixPointColorButton.Text;
                else programWrite.SubtitleColor = "false";

                if (openAudioListButton.Enabled) { programWrite.AudioListFile = openAudioListButton.Text; }
                else { programWrite.AudioListFile = "false"; }

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

                string text = programWrite.ProgramName + " " +
                                 programWrite.NumExpositions.ToString() + " " +
                                 programWrite.ExpositionTime.ToString() + " " +
                                 programWrite.ExpositionRandom.ToString() + " " +
                                 programWrite.IntervalTime.ToString() + " " +
                                 programWrite.IntervalTimeRandom.ToString() + " " +
                                 programWrite.WordsListFile + " " +
                                 programWrite.ColorsListFile + " " +
                                 programWrite.BackgroundColor.ToUpper() + " " +
                                 programWrite.AudioCapture.ToString() + " " +
                                 programWrite.SubtitleShow.ToString() + " " +
                                 programWrite.SubtitlePlace.ToString() + " " +
                                 programWrite.SubtitleColor.ToUpper() + " " +
                                 programWrite.ExpositionType.ToLower() + " " +
                                 programWrite.ImagesListFile + " " +
                                 programWrite.FixPoint + " " +
                                 programWrite.FontWordLabel + " " +
                                 programWrite.ExpandImage + " " +
                                 programWrite.AudioListFile + " " +
                                 programWrite.SubtitlesListFile
                                 ;


                saveProgramFile(text, programWrite.InstructionText);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);;
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
                    if ((Regex.IsMatch(program.BackgroundColor, hexPattern)))
                    {
                        bgColorButton.Text = program.BackgroundColor;
                        bgColorPanel.BackColor = ColorTranslator.FromHtml(program.BackgroundColor);
                    }
                }
                /*
                if (program.FixPointColor.ToLower() == "false")
                {
                    panelFixPointColorPanel.BackColor = ColorTranslator.FromHtml("#D01C1F");
                    fixPointColor.Text = "#D01C1F";
                }
                else
                {
                    if ((Regex.IsMatch(program.FixPointColor, hexPattern)))
                    {
                        fixPointColor.Text = program.FixPointColor;
                        panelFixPointColorPanel.BackColor = ColorTranslator.FromHtml(program.FixPointColor);
                    }
                    else { throw new Exception("Deu errado no match"); }
                }
                */
                
                if (program.SubtitleShow)
                {
                    activateSubsCheck.Checked = true;
                    enableSubsItens(true);

                    subDirectionNumber = program.SubtitlePlace;
                    if(program.SubtitlesListFile.ToLower() != "false")
                    {
                        activateSubsButton.Text = program.SubtitlesListFile;
                    }
                    if (Regex.IsMatch(program.SubtitleColor, hexPattern))
                    {
                        subColorButton.Text = program.SubtitleColor;
                        subColorPanel.BackColor = ColorTranslator.FromHtml(program.SubtitleColor);
                    }
                    else
                    {
                        subColorButton.Text = "escolher";
                        subColorPanel.BackColor = Color.White;
                    }

                    subDirectionNumber = program.SubtitlePlace;

                }
                else
                {
                    activateSubsCheck.Checked = false;
                    enableSubsItens(false);
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

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);/*MessageBox.Show(ex.Message);*/
                //Close();
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
            MessageBox.Show("O programa " + prgNameTextBox.Text + ".prg foi salvo com sucesso!");
            this.Close();
        }

        private string openListFile()
        {
            string progName = "abrir";

            FormDefine defineProgram = new FormDefine("Lista: ", path + "/lst/", "lst");
            var result = defineProgram.ShowDialog();

            if (result == DialogResult.OK)
            {
                progName = defineProgram.ReturnValue + ".lst";
            }

            return progName;
        }

        string pickColor()
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
                
            return  hexColor;
        }
    }
}
