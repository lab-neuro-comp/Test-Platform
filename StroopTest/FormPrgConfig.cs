using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormPrgConfig : Form
    {
        private string path;
        private string instrBoxText = "Escreva cada uma das intruções em linhas separadas.";
        StroopProgram programWrite;
        private List<Button> subDirectionList;
        private int subDirectionNumber = 0;

        public FormPrgConfig(string dataFolderPath)
        {
            path = dataFolderPath;
            InitializeComponent();
            chooseExpoType.SelectedIndex = 0;
            subDirect1.BackColor = Color.LightGray;
            subDirectionList = new List<Button>();
            subDirectionList.Add(subDirect1); subDirectionList.Add(subDirect2); subDirectionList.Add(subDirect3); subDirectionList.Add(subDirect4); subDirectionList.Add(subDirect5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(showSubsOn.Checked)
            {
                chooseColorSubs.Enabled = true; panel3.Enabled = true; // habilitar botões de posicao legenda
            }
            else
            {
                chooseColorSubs.Enabled = false; panel3.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (chooseExpoType.SelectedIndex)
            {
                case 0:
                    openWordList.Enabled = true;
                    openColorsList.Enabled = true;
                    openImgsList.Enabled = false;
                    break;
                case 1:
                    openWordList.Enabled = false;
                    openColorsList.Enabled = false;
                    openImgsList.Enabled = true;
                    break;
                case 2:
                    openWordList.Enabled = true;
                    openColorsList.Enabled = false;
                    openImgsList.Enabled = true;
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            chooseBackGColor.Text = colorCode;
            panel2.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            chooseColorSubs.Text = colorCode;
            panel3.BackColor = ColorTranslator.FromHtml(colorCode);
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
            openColorsList.Text = openListFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            programWrite = new StroopProgram();

            try
            {
                
                programWrite.ProgramName = progName.Text;
                programWrite.NumExpositions = Convert.ToInt32(numExpo.Value);


                programWrite.ProgramName = progName.Text;
                programWrite.NumExpositions = Convert.ToInt32(numExpo.Value);
                programWrite.ExpositionTime = Convert.ToInt32(timeExpo.Value);
                programWrite.ExpositionRandom = randExpoOn.Checked;
                programWrite.IntervalTime = Convert.ToInt32(timeInterval.Value);
                programWrite.IntervalTimeRandom = randIntervalOn.Checked;

                if (openWordList.Enabled && openWordList.Text != "error") { programWrite.WordsListFile = openWordList.Text; }
                else
                {
                    if (openWordList.Text == "error") { throw new Exception("Selecione o arquivo de lista de palavras!"); }
                    programWrite.WordsListFile = "false";
                }

                if (openColorsList.Enabled && openWordList.Text != "error") { programWrite.ColorsListFile = openColorsList.Text; }
                else
                {
                    if (openWordList.Text == "error") { throw new Exception("Selecione o arquivo de lista de cores!"); }
                    programWrite.ColorsListFile = "false";
                }

                programWrite.BackgroundColor = chooseBackGColor.Text;
                programWrite.AudioCapture = captAudioOn.Checked;
                programWrite.SubtitleShow = showSubsOn.Checked;

                if(programWrite.SubtitleShow)
                {
                    programWrite.SubtitlePlace = subDirectionNumber;
                    programWrite.SubtitleColor = chooseColorSubs.Text;
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
                                 programWrite.FixPoint;
                
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
            StreamWriter writer = new StreamWriter(path + "/prg/" + progName.Text + ".prg");
            writer.WriteLine(programText);
            if (instructions != null)
            {
                for (int i = 0; i < instructions.Count; i++)
                {
                    writer.WriteLine(instructions[i]);
                }
            }
            writer.Dispose();
            writer.Close();
            MessageBox.Show("Programa salvo no diretório:\n" + path + "/prg/");
            this.Close();
        }

        private string openListFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            StroopProgram programOpened = new StroopProgram();
            string nameListFile = "error";

            openFileDialog1.InitialDirectory = path + "/lst/";
            openFileDialog1.Filter = "Arquivos de lista (*.lst)|*.lst";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                nameListFile = Path.GetFileName(openFileDialog1.FileName);

            return nameListFile;
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
            if(textBox2.Text == "Escreva cada uma das intruções em linhas separadas.")
                textBox2.Text = "";
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
            for (int i = 0; i < subDirectionList.Count; i++) // Loop with for.
            {
                subDirectionList[i].BackColor = Color.Transparent;
            }
            subDirect1.BackColor = Color.LightGray;
            subDirectionNumber = 1;
        }

        private void subDirect2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subDirectionList.Count; i++) // Loop with for.
            {
                subDirectionList[i].BackColor = Color.Transparent;
            }
            subDirect2.BackColor = Color.LightGray;
            subDirectionNumber = 2;
        }

        private void subDirect3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subDirectionList.Count; i++) // Loop with for.
            {
                subDirectionList[i].BackColor = Color.Transparent;
            }
            subDirect3.BackColor = Color.LightGray;
            subDirectionNumber = 3;
        }

        private void subDirect4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subDirectionList.Count; i++) // Loop with for.
            {
                subDirectionList[i].BackColor = Color.Transparent;
            }
            subDirect4.BackColor = Color.LightGray;
            subDirectionNumber = 4;

        }

        private void subDirect5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subDirectionList.Count; i++) // Loop with for.
            {
                subDirectionList[i].BackColor = Color.Transparent;
            }
            subDirect5.BackColor = Color.LightGray;
            subDirectionNumber = 5;
        }
    }
}
