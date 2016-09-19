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
        private int subDirectionNumber = 0;
        private string fontSize = "160";
        private string editPrgName = "error";
        private int expoType = 0;
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
            subDirectionList.Add(subsCenterButton); subDirectionList.Add(subsDownButton); subDirectionList.Add(subsLeftButton); subDirectionList.Add(subsRightButton); subDirectionList.Add(subsUpButton);

            toolTipsConfig();

            foreach (Button b in subDirectionList)
            {
                b.Enabled = false;
                b.BackColor = Color.LightGray;
            }
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
            helpToolTip.SetToolTip(rdmExpoLabel, "Exposição dos estímulos em ordem aleatória em relação à lista");
            helpToolTip.SetToolTip(expoNumberLabel, "Número de vezes em que os estímulos serão expostos");
            helpToolTip.SetToolTip(wordSizeLabel, "Tamanho da fonte do texto, para exposição do tipo Palavra, Palavra com áudio, Imagem e palavra");
            helpToolTip.SetToolTip(wordColorLabel, "Cor da palavra, para exposição do tipo Imagem e Palavra");
            helpToolTip.SetToolTip(listWordsLabel, "Arquivo de Lista de palavras");
            helpToolTip.SetToolTip(listColorsLabel, "Arquivo de Lista de cores");
            helpToolTip.SetToolTip(listImagesLabel, "Arquivo de Lista de imagens");
            helpToolTip.SetToolTip(listAudioLabel, "Arquivo de Lista de áudio");
            helpToolTip.SetToolTip(expoTimeLabel, "Duração da exposição de cada estímulo");
            helpToolTip.SetToolTip(intervTimeLabel, "Tempo entre as tentativas");
            helpToolTip.SetToolTip(rdmIntervLabel, "Variação do tempo entre as tentativas");
            helpToolTip.SetToolTip(fixPointTypeLabel, "Tipo de ponto de fixação: cruz ou ponto");
            helpToolTip.SetToolTip(fixPointColorLabel, "Cor do ponto de fixação");
            helpToolTip.SetToolTip(activateSubsLabel, "Ativa legenda para estímulos do tipo imagem");
            helpToolTip.SetToolTip(subLocationLabel, "Posicionamento da legenda em relação aos estímulos");
            helpToolTip.SetToolTip(subColorLabel, "Cor da legenda apresentada");
            helpToolTip.SetToolTip(captAudioLabel, "Ativa captura de áudio durante a execução do teste");
            helpToolTip.SetToolTip(bgColorLabel, "Cor de fundo durante a apresentação dos estímulos");
            helpToolTip.SetToolTip(expandImgLabel, "Expande a imagem até as bordas da tela");
            helpToolTip.SetToolTip(instructionsLabel, "Instruções apresentadas no início do programa - será apresentada um tela para cada linha escrita abaixo");
            helpToolTip.SetToolTip(saveButton, "Salva o programa configurado");
            helpToolTip.SetToolTip(helpButton, "Ajuda");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            subtitlesCheckConfig();
        }

        private void subtitlesCheckConfig()
        {
            if (activateSubsCheck.Checked)
            {
                foreach (Button b in subDirectionList)
                {
                    b.Enabled = true;
                    b.BackColor = Color.Transparent;
                }
                openSubsListButton.Enabled = true;
                chooseColorSubs.Enabled = true;

                panelSubColor.Enabled = true;

                panelSubColor.BackColor = Color.Transparent;
                subsCenterButton.BackColor = Color.Transparent; // habilitar botões de posicao legenda

                expandImageOn.Enabled = false;
                expandImageOn.Checked = false;

            }
            else
            {
                openSubsListButton.Visible = false; openSubsListButton.Enabled = false;
                foreach (Button b in subDirectionList)
                {
                    b.Enabled = false;
                    b.BackColor = Color.LightGray;
                }
                chooseColorSubs.Enabled = false;;
                panelSubColor.Enabled = false; panelSubColor.BackColor = Color.LightGray;
                expandImageOn.Enabled = true;
            }
        }
        
        private void chooseExpositionTypeComboBox(object sender, EventArgs e)
        {
            expoType = chooseExpoType.SelectedIndex;

            switch (expoType)
            {
                case 0: // txt
                    //chooseExpoType.SelectedIndex = 0;
                    wordColorLabel.Enabled = false; wordColorPanel.Enabled = false; wordColorButton.Enabled = false;
                    expandImageOn.Enabled = false;
                    wordSizeNumeric.Enabled = true;

                    openWordListButton.Enabled = true;
                    openColorsListButton.Enabled = true;
                    openImageListButton.Enabled = false;
                    openAudioListButton.Enabled = false;

                    activateSubsCheck.Enabled = false;
                    activateSubsCheck.Checked = false;
                    
                    break;
                case 1: // img
                    openWordListButton.Enabled = false;
                    openColorsListButton.Enabled = false;
                    openImageListButton.Enabled = true;
                    openAudioListButton.Enabled = false;
                    wordSizeNumeric.Enabled = false;
                    expandImageOn.Enabled = true;
                    activateSubsCheck.Enabled = true;
                    break;
                case 2: // imgtxt
                    openWordListButton.Enabled = true;
                    openColorsListButton.Enabled = false;
                    openImageListButton.Enabled = true;
                    openAudioListButton.Enabled = false;
                    wordSizeNumeric.Enabled = true;
                    expandImageOn.Enabled = true;
                    activateSubsCheck.Enabled = true;
                    break;
                case 3: // txtaud
                    openWordListButton.Enabled = true;
                    openColorsListButton.Enabled = true;
                    openImageListButton.Enabled = false;
                    openAudioListButton.Enabled = true;
                    wordSizeNumeric.Enabled = true;
                    expandImageOn.Enabled = false;
                    activateSubsCheck.Enabled = false;
                    activateSubsCheck.Checked = false;
                    break;
                case 4: // imgaud
                    openWordListButton.Enabled = false;
                    openColorsListButton.Enabled = false;
                    openImageListButton.Enabled = true;
                    openAudioListButton.Enabled = true;
                    wordSizeNumeric.Enabled = false;
                    expandImageOn.Enabled = true;
                    activateSubsCheck.Enabled = true;
                    break;
            }
        }

        private void chooseBGColor(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            bgColorButton.Text = colorCode;
            panelBGColor.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void chooseSubsColor(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            chooseColorSubs.Text = colorCode;
            panelSubColor.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void openWordsList_Click(object sender, EventArgs e)
        {
            openWordListButton.Text = openListFile();
        }

        private void openColorsList_Click(object sender, EventArgs e)
        {
            openColorsListButton.Text = openListFile();
        }

        private void openImagesList_Click(object sender, EventArgs e)
        {
            openImageListButton.Text = openListFile();
        }
        
        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = openListFile();
        }
        
        private void openSubsList_Click(object sender, EventArgs e)
        {
            openSubsListButton.Text = openListFile();
        }
        

        private void editProgram()
        {
            StroopProgram program = new StroopProgram();

            try
            {
                program.readProgramFile(path + "/prg/" + editPrgName + ".prg");

                prgNameTextBox.Text = program.ProgramName;
                numExpo.Value = program.NumExpositions;
                timeExpo.Value = program.ExpositionTime;
                randExpoOn.Checked = program.ExpositionRandom;
                timeInterval.Value = program.IntervalTime;
                randIntervalOn.Checked = program.IntervalTimeRandom;
                captAudioOn.Checked = program.AudioCapture;
                wordSizeNumeric.Value = Convert.ToInt32(program.FontWordLabel);
                expandImageOn.Checked = program.ExpandImage;

                if (program.WordsListFile.ToLower() == "false") { openWordListButton.Enabled = false; }
                else { openWordListButton.Enabled = true; openWordListButton.Text = program.WordsListFile; }

                if (program.ColorsListFile.ToLower() == "false") { openColorsListButton.Enabled = false; }
                else { openColorsListButton.Enabled = true; openColorsListButton.Text = program.ColorsListFile; }

                if (program.ImagesListFile.ToLower() == "false") { openImageListButton.Enabled = false; }
                else { openImageListButton.Enabled = true; openImageListButton.Text = program.ImagesListFile; }

                if (program.AudioListFile.ToLower() == "false") { openAudioListButton.Enabled = false; }
                else { openAudioListButton.Enabled = true; openAudioListButton.Text = program.AudioListFile; }
                
                if (program.BackgroundColor.ToLower() == "false")
                {
                    panelBGColor.BackColor = Color.White;
                    bgColorButton.Text = "escolher cor";
                }
                else
                {
                    if ((Regex.IsMatch(program.BackgroundColor, hexPattern)))
                    {
                        bgColorButton.Text = program.BackgroundColor;
                        panelBGColor.BackColor = ColorTranslator.FromHtml(program.BackgroundColor);
                    }
                }
                /*
                if (program.FixPointColor.ToLower() == "false")
                {
                    panelFixPointColor.BackColor = ColorTranslator.FromHtml("#D01C1F");
                    fixPointColor.Text = "#D01C1F";
                }
                else
                {
                    if ((Regex.IsMatch(program.FixPointColor, hexPattern)))
                    {
                        fixPointColor.Text = program.FixPointColor;
                        panelFixPointColor.BackColor = ColorTranslator.FromHtml(program.FixPointColor);
                    }
                    else { throw new Exception("Deu errado no match"); }
                }
                */
                
                if (program.SubtitleShow)
                {
                    activateSubsCheck.Checked = true;
                    
                    subDirectionNumber = program.SubtitlePlace;
                    if(program.SubtitlesListFile.ToLower() != "false")
                    {
                        openSubsListButton.Text = program.SubtitlesListFile;
                    }
                    if (Regex.IsMatch(program.SubtitleColor, hexPattern))
                    {
                        chooseColorSubs.Text = program.SubtitleColor;
                        panelSubColor.Enabled = true;
                        panelSubColor.BackColor = ColorTranslator.FromHtml(program.SubtitleColor);
                    }
                    else
                    {
                        chooseColorSubs.Text = "escolher cor";
                        panelSubColor.BackColor = Color.White;
                    }
                    
                    for (int j = 0; j < subDirectionList.Count; j++)
                    {
                        subDirectionList[j].Enabled = true;
                        subDirectionList[j].Visible = true;
                    }
                    subDirectionNumber = program.SubtitlePlace;

                    subtitlesCheckConfig();
                }
                else
                {
                    activateSubsCheck.Checked = false;
                    for (int k = 0; k < subDirectionList.Count; k++)
                    {
                        subDirectionList[k].Enabled = false;
                        subDirectionList[k].Visible = false;
                    }

                    subtitlesCheckConfig();
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
                
                if (program.InstructionText != null) // lê instrução se houver
                {
                    textBox2.ForeColor = Color.Black;
                    textBox2.Text = program.InstructionText[0];
                    for (int i = 1; i < program.InstructionText.Count; i++)
                    {
                        textBox2.AppendText(Environment.NewLine + program.InstructionText[i]);
                    }
                }
                else
                {
                    textBox2.Text = instructionBoxText;
                }

                switch (program.ExpositionType)
                {
                    case "txt":
                        chooseExpoType.SelectedIndex = 0;
                        openWordListButton.Enabled = true;
                        openColorsListButton.Enabled = true;
                        openImageListButton.Enabled = false;
                        openAudioListButton.Enabled = false;
                        break;
                    case "img":
                        chooseExpoType.SelectedIndex = 1;
                        openWordListButton.Enabled = false;
                        openColorsListButton.Enabled = false;
                        openImageListButton.Enabled = true;
                        openAudioListButton.Enabled = false;
                        break;
                    case "imgtxt":
                        chooseExpoType.SelectedIndex = 2;
                        openWordListButton.Enabled = true;
                        openColorsListButton.Enabled = false;
                        openImageListButton.Enabled = true;
                        openAudioListButton.Enabled = false;
                        break;
                    case "txtaud":
                        chooseExpoType.SelectedIndex = 3;
                        openWordListButton.Enabled = true;
                        openColorsListButton.Enabled = true;
                        openImageListButton.Enabled = false;
                        openAudioListButton.Enabled = true;
                        break;
                    case "imgaud":
                        chooseExpoType.SelectedIndex = 4;
                        openWordListButton.Enabled = false;
                        openColorsListButton.Enabled = false;
                        openImageListButton.Enabled = true;
                        openAudioListButton.Enabled = true;
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }


        private void configureNewProgram(object sender, EventArgs e)
        {

            StroopProgram programWrite = new StroopProgram();

            try
            {
                programWrite.ProgramName = prgNameTextBox.Text;
                programWrite.NumExpositions = Convert.ToInt32(numExpo.Value);
                programWrite.ExpositionTime = Convert.ToInt32(timeExpo.Value);
                programWrite.ExpositionRandom = randExpoOn.Checked;
                programWrite.IntervalTime = Convert.ToInt32(timeInterval.Value);
                programWrite.IntervalTimeRandom = randIntervalOn.Checked;

                /*
                programWrite.WordsListFile = "false";
                programWrite.ColorsListFile = "false";
                programWrite.ImagesListFile = "false";
                */
                switch (expoType)
                {
                    case 0:
                        if (openWordListButton.Text != "error" && openWordListButton.Text != "abrir") { programWrite.WordsListFile = openWordListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras!"); }
                        if (openColorsListButton.Text != "error" && openColorsListButton.Text != "abrir") { programWrite.ColorsListFile = openColorsListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de cores!"); }
                        break;
                    case 1:
                        if (openImageListButton.Text != "error" && openImageListButton.Text != "abrir") { programWrite.ImagesListFile = openImageListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de imagens!"); }
                        break;
                    case 2:
                        if (openWordListButton.Text != "error" && openImageListButton.Text != "error") { programWrite.WordsListFile = openWordListButton.Text; programWrite.ImagesListFile = openImageListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras / imagens!"); }
                        break;
                    case 3:
                        if (openWordListButton.Text != "error" && openAudioListButton.Text != "error" && openColorsListButton.Text != "error") { programWrite.WordsListFile = openWordListButton.Text; programWrite.AudioListFile = openAudioListButton.Text; programWrite.ColorsListFile = openColorsListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras / cor / audio!"); }
                        break;
                    case 4:
                        if (openImageListButton.Text != "error" && openAudioListButton.Text != "error") { programWrite.ImagesListFile = openImageListButton.Text; programWrite.AudioListFile = openAudioListButton.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de imagens / audio!"); }
                        break;
                }

                if (Regex.IsMatch(bgColorButton.Text, hexPattern)) { programWrite.BackgroundColor = bgColorButton.Text; }
                else programWrite.BackgroundColor = "false";

                programWrite.AudioCapture = captAudioOn.Checked;
                programWrite.SubtitleShow = activateSubsCheck.Checked;

                if(programWrite.SubtitleShow)
                {
                    programWrite.SubtitlePlace = subDirectionNumber;
                    if (Regex.IsMatch(chooseColorSubs.Text, hexPattern)) programWrite.SubtitleColor = chooseColorSubs.Text;
                    else programWrite.SubtitleColor = "false";

                    programWrite.SubtitlesListFile = openSubsListButton.Text;
                }
                else
                {
                    programWrite.SubtitlePlace = subDirectionNumber;
                    programWrite.SubtitleColor = "false";
                }

                switch(chooseExpoType.SelectedIndex)
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
                
                if (openImageListButton.Enabled) { programWrite.ImagesListFile = openImageListButton.Text; }
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
                    if(!fixPointCross.Checked && !fixPointCircle.Checked)
                    {
                        programWrite.FixPoint = "false";
                    }
                }

                if (openAudioListButton.Enabled) { programWrite.AudioListFile = openAudioListButton.Text; }
                else { programWrite.AudioListFile = "false"; }

                string textLines = "";
                if (textBox2.Lines.Length > 0 && textBox2.Text != instructionBoxText) // lê instrução se houver
                {
                    for (int i = 0; i < textBox2.Lines.Length; i++)
                    {
                        programWrite.InstructionText.Add(textBox2.Lines[i]);
                        textLines = textLines + "\n" + textBox2.Lines[i];
                    }
                }
                else
                {
                    programWrite.InstructionText = null;
                }

                programWrite.FontWordLabel = wordSizeNumeric.Value.ToString();
                programWrite.ExpandImage = expandImageOn.Checked;

                string text =    programWrite.ProgramName + " " +
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            string progName = "error";

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

        private void textBox2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == instructionBoxText)
            {
                textBox2.Text = "";
            }
            textBox2.ForeColor = Color.Black;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(fixPointCross.Checked && fixPointCircle.Checked)
                fixPointCircle.Checked = !fixPointCross.Checked;
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (fixPointCross.Checked && fixPointCircle.Checked)
                fixPointCross.Checked = !fixPointCircle.Checked;
        }

        private void subDirect1_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(1);
        }

        private void subDirect2_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(2);
        }

        private void subDirect3_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(3);
        }

        private void subDirect4_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(4);
        }

        private void subDirect5_Click(object sender, EventArgs e)
        {
            selectSubDirectionNumber(5);
        }

        private void selectSubDirectionNumber(int number)
        {
            for (int i = 0; i < subDirectionList.Count; i++) // Loop with for.
            {
                subDirectionList[i].BackColor = Color.LightGray;
            }
            subDirectionList[number - 1].BackColor = Color.Transparent;
            subDirectionNumber = number;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            fixPointColor.Text = colorCode;
            panelFixPointColor.BackColor = ColorTranslator.FromHtml(colorCode);
        }
        
        private void wordSizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            fontSize = wordSizeNumeric.Value.ToString();
        }

        private void expandImageOn_CheckedChanged(object sender, EventArgs e)
        {
            if (expandImageOn.Checked)
            {
                activateSubsCheck.Enabled = false;
                activateSubsCheck.Checked = false;
            }
            else
            {
                activateSubsCheck.Enabled = true;
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            showPrgConfigInstructions();
        }

        private void showPrgConfigInstructions()
        {
            FormInstructions infoBox = new FormInstructions((path + "prgConfigHelp.txt"), prgConfigInstructionsText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            wordColorPanel.Text = colorCode;
            wordColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }
    }
}
