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
        private string instrBoxText = "Escreva cada uma das intruções em linhas separadas.";
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        StroopProgram programWrite;
        private List<Button> subDirectionList;
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
            path = dataFolderPath;
            InitializeComponent();
            chooseExpoType.SelectedIndex = 0;
            subDirectionList = new List<Button>();
            subDirectionList.Add(subDirect1); subDirectionList.Add(subDirect2); subDirectionList.Add(subDirect3); subDirectionList.Add(subDirect4); subDirectionList.Add(subDirect5);

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
            
            helpToolTip.SetToolTip(prgNameLabel, "Nome do Arquivo onde o programa será salvo");
            helpToolTip.SetToolTip(expoTypeLabel, "Tipo de Estímulo: Texto; Imagem; Imagem e Texto; Texto e Áudio; Imagem e Áudio");
            helpToolTip.SetToolTip(rdmExpoLabel , "Aleatoriedade na apresentação; as exposições ocorrerão de forma aleatória");
            helpToolTip.SetToolTip(expoNumberLabel , "Número de Estímulos (quantidade de estímulos a serem expostos)");
            helpToolTip.SetToolTip(wordSizeLabel, "Dimensão da letra em estímulos do tipo texto");
            helpToolTip.SetToolTip(wordColorLabel, "Cor das palavras que serão revezadas com imagens (Imagem com Palavra)");
            helpToolTip.SetToolTip(listWordsLabel , "Arquivo de Lista de palavras (um estímulo palavra por linha, arquivo .lst)");
            helpToolTip.SetToolTip(listColorsLabel, "Arquivo de Lista de cores (um código hexadecimal de cor por linha, arquivo .lst)");
            helpToolTip.SetToolTip(listImagesLabel, "Arquivo de Lista de imagens (um caminho de imagem por linha, arquivo .lst)");
            helpToolTip.SetToolTip(listAudioLabel, "Arquivo de Lista de áudio (um caminho de arquivos de áudi por linha, arquivo .lst)");
            helpToolTip.SetToolTip(expoTimeLabel, "Tempo de exposição para cada estímulo (quanto tempo uma palavra, imagem permanece exposta)");
            helpToolTip.SetToolTip(intervTimeLabel, "Tempo de intervalo entre estímulos (quanto tempo de pausa faz-se entre duas exposições de estímulo)");
            helpToolTip.SetToolTip(rdmIntervLabel, "Aleatoriedade no tempo de intervalo entre estímulos");
            helpToolTip.SetToolTip(fixPointTypeLabel, "Tipo de ponto de fixação: cruz ou círculo (ponto de fixação surge durante o intervalo)");
            helpToolTip.SetToolTip(fixPointColorLabel, "Cor do ponto de fixação");
            helpToolTip.SetToolTip(subActivationLabel, "Ativa legenda para estímulos do tipo imagem - selecione uma lista com as legendas");
            helpToolTip.SetToolTip(subLocationLabel , "Posicionamento da legenda em relação aos estímulos");
            helpToolTip.SetToolTip(subColorLabel, "Cor da legenda apresentada");
            helpToolTip.SetToolTip(captAudioLabel , "Ativa captura de áudio durante a execução do teste");
            helpToolTip.SetToolTip(bgColorLabel, "Cor de fundo durante a apresentação dos estímulos");
            helpToolTip.SetToolTip(expandImgLabel, "Expande estímulos de imagem até as bordas da tela - não pode ocorrer simultaneamente à apresentação de legenda");
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
            if (showSubsOn.Checked)
            {
                foreach (Button b in subDirectionList)
                {
                    b.Enabled = true;
                    b.BackColor = Color.Transparent;
                }
                openSubtitleList.Enabled = true;
                chooseColorSubs.Enabled = true;

                panelSubColor.Enabled = true;

                panelSubColor.BackColor = Color.Transparent;
                subDirect1.BackColor = Color.Transparent; // habilitar botões de posicao legenda

                expandImageOn.Enabled = false;
                expandImageOn.Checked = false;

            }
            else
            {
                openSubtitleList.Visible = false; openSubtitleList.Enabled = false;
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


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            expoType = chooseExpoType.SelectedIndex;

            switch (expoType)
            {
                case 0:
                    openWordList.Enabled = true;
                    openColorsList.Enabled = true;
                    openImgsList.Enabled = false;
                    numericUpDown1.Enabled = true;
                    expandImageOn.Enabled = false;
                    showSubsOn.Enabled = false;
                    showSubsOn.Checked = false;
                    break;
                case 1:
                    openWordList.Enabled = false;
                    openColorsList.Enabled = false;
                    openImgsList.Enabled = true;
                    numericUpDown1.Enabled = false;
                    expandImageOn.Enabled = true;
                    showSubsOn.Enabled = true;
                    break;
                case 2:
                    openWordList.Enabled = true;
                    openColorsList.Enabled = false;
                    openImgsList.Enabled = true;
                    numericUpDown1.Enabled = true;
                    expandImageOn.Enabled = true;
                    showSubsOn.Enabled = true;
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            bgColorButton.Text = colorCode;
            panelBGColor.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            chooseColorSubs.Text = colorCode;
            panelSubColor.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openWordList.Text = openListFile();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openColorsList.Text = openListFile();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openImgsList.Text = openListFile();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            openAudioList.Text = openListFile();
        }
        
        private void openSubtitleList_Click(object sender, EventArgs e)
        {
            openSubtitleList.Text = openListFile();
        }

        private void editProgram()
        {
            StroopProgram program = new StroopProgram();

            try
            {
                program.readProgramFile(path + "/prg/" + editPrgName + ".prg");

                progName.Text = program.ProgramName;
                numExpo.Value = program.NumExpositions;
                timeExpo.Value = program.ExpositionTime;
                if (program.ExpositionRandom) randExpoOn.Checked = true;
                else randExpoOn.Checked = false;
                timeInterval.Value = program.IntervalTime;
                if (program.IntervalTimeRandom) randIntervalOn.Checked = true;
                else randIntervalOn.Checked = false;
                if (program.WordsListFile.ToLower() == "false")
                {
                    openWordList.Enabled = false;
                }
                else
                {
                    openWordList.Enabled = true;
                    openWordList.Text = program.WordsListFile;
                }

                if (program.ColorsListFile.ToLower() == "false")
                {
                    openColorsList.Enabled = false;
                }
                else
                {
                    openColorsList.Enabled = true;
                    openColorsList.Text = program.ColorsListFile;
                }

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


                if (program.AudioCapture) captAudioOn.Checked = true;
                else captAudioOn.Checked = false;
                
                if (program.SubtitleShow)
                {
                    showSubsOn.Checked = true;
                    
                    subDirectionNumber = program.SubtitlePlace;
                    if(program.SubtitlesListFile.ToLower() != "false")
                    {
                        openSubtitleList.Text = program.SubtitlesListFile;
                    }
                    else
                    {
                        openSubtitleList.Text = "abrir";
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
                    showSubsOn.Checked = false;
                    for (int k = 0; k < subDirectionList.Count; k++)
                    {
                        subDirectionList[k].Enabled = false;
                        subDirectionList[k].Visible = false;
                    }

                    subtitlesCheckConfig();
                }

                switch (program.ExpositionType)
                {
                    case "txt":
                        chooseExpoType.SelectedIndex = 0;
                        break;
                    case "img":
                        chooseExpoType.SelectedIndex = 1;
                        break;
                    case "imgtxt":
                        chooseExpoType.SelectedIndex = 2;
                        break;
                    default:
                        chooseExpoType.SelectedIndex = 0;
                        break;
                }

                if (program.ImagesListFile.ToLower() != "false") { openImgsList.Enabled = true; openImgsList.Text = program.ImagesListFile; }
                else { openImgsList.Enabled = false; openImgsList.Text = "false"; }
                
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

                if (program.AudioListFile.ToLower() != "false") { openAudioList.Enabled = true; openAudioList.Text = program.AudioListFile; }
                else { openAudioList.Enabled = false; openAudioList.Text = "false"; }

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
                    textBox2.Text = instrBoxText;
                }

                numericUpDown1.Value = Convert.ToInt32(program.FontWordLabel);
                expandImageOn.Checked = Convert.ToBoolean(program.ExpandImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            programWrite = new StroopProgram();
            try
            {
                programWrite.ProgramName = progName.Text;
                programWrite.NumExpositions = Convert.ToInt32(numExpo.Value);
                programWrite.ExpositionTime = Convert.ToInt32(timeExpo.Value);
                programWrite.ExpositionRandom = randExpoOn.Checked;
                programWrite.IntervalTime = Convert.ToInt32(timeInterval.Value);
                programWrite.IntervalTimeRandom = randIntervalOn.Checked;


                programWrite.WordsListFile = "false";
                programWrite.ColorsListFile = "false";
                programWrite.ImagesListFile = "false";

                switch (expoType)
                {
                    case 0:
                        if (openWordList.Text != "error" && openWordList.Text != "abrir") { programWrite.WordsListFile = openWordList.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras!"); }
                        if (openColorsList.Text != "error" && openColorsList.Text != "abrir") { programWrite.ColorsListFile = openColorsList.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de cores!"); }
                        break;
                    case 1:
                        if (openImgsList.Text != "error" && openImgsList.Text != "abrir") { programWrite.ImagesListFile = openImgsList.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de imagens!"); }
                        break;
                    case 2:
                        if (openWordList.Text != "error" && openImgsList.Text != "error") { programWrite.WordsListFile = openWordList.Text; programWrite.ImagesListFile = openImgsList.Text; }
                        else { throw new Exception("Selecione o arquivo de lista de palavras / imagens!"); }
                        break;
                }

                if (Regex.IsMatch(bgColorButton.Text, hexPattern)) { programWrite.BackgroundColor = bgColorButton.Text; }
                else programWrite.BackgroundColor = "false";

                programWrite.AudioCapture = captAudioOn.Checked;
                programWrite.SubtitleShow = showSubsOn.Checked;

                if(programWrite.SubtitleShow)
                {
                    programWrite.SubtitlePlace = subDirectionNumber;
                    if (Regex.IsMatch(chooseColorSubs.Text, hexPattern)) programWrite.SubtitleColor = chooseColorSubs.Text;
                    else programWrite.SubtitleColor = "false";

                    programWrite.SubtitlesListFile = openSubtitleList.Text;
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
                }
                
                if (openImgsList.Enabled) { programWrite.ImagesListFile = openImgsList.Text; }
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
                
                /*
                if (audioListCheck.Checked) { openAudioList.Enabled = true; programWrite.AudioListFile = openAudioList.Text; }
                else { openAudioList.Enabled = false; programWrite.AudioListFile = "false"; }
                */
                string textLines = "";
                if (textBox2.Lines.Length > 0 && textBox2.Text != instrBoxText) // lê instrução se houver
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

                programWrite.FontWordLabel = numericUpDown1.Value.ToString();
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
            if (File.Exists(path + "prg/" + progName.Text + ".prg"))
            {
                DialogResult dialogResult = MessageBox.Show("O programa já existe, deseja sobrescrevê-lo?", "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    throw new Exception("O programa não será salvo!");
                }
            }

            StreamWriter writer = new StreamWriter(path + "prg/" + progName.Text + ".prg");
            writer.WriteLine(programText);
            if (instructions != null)
            {
                for (int i = 0; i < instructions.Count; i++)
                {
                    writer.WriteLine(instructions[i]);
                }
            }
            //writer.Dispose();
            writer.Close();
            MessageBox.Show("O programa " + progName.Text + ".prg foi salvo com sucesso no diretório\n" + path + "prg/");
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
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fontSize = numericUpDown1.Value.ToString();
        }

        private void expandImageOn_CheckedChanged(object sender, EventArgs e)
        {
            if (expandImageOn.Checked)
            {
                showSubsOn.Enabled = false;
                showSubsOn.Checked = false;
            }
            else
            {
                showSubsOn.Enabled = true;
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
            panelWordColor.Text = colorCode;
            panelWordColor.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void FormPrgConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
