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

        public FormPrgConfig(string dataFolderPath)
        {
            path = dataFolderPath;
            InitializeComponent();
            chooseExpoType.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(showSubsOn.Checked)
            {
                choosePositionSubs.Enabled = true; chooseColorSubs.Enabled = true; panel3.Enabled = true;
            }
            else
            {
                choosePositionSubs.Enabled = false; chooseColorSubs.Enabled = false; panel3.Enabled = false;
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
                    programWrite.WordsListFile = "False";
                }

                if (openColorsList.Enabled && openWordList.Text != "error") { programWrite.ColorsListFile = openColorsList.Text; }
                else
                {
                    if (openWordList.Text == "error") { throw new Exception("Selecione o arquivo de lista de cores!"); }
                    programWrite.ColorsListFile = "fAlse";
                }

                programWrite.BackgroundColor = chooseBackGColor.Text;
                programWrite.AudioCapture = captAudioOn.Checked;
                programWrite.SubtitleShow = showSubsOn.Checked;

                if(programWrite.SubtitleShow)
                {
                    programWrite.SubtitlePlace = 0;
                    programWrite.SubtitleColor = chooseColorSubs.Text;
                }
                else
                {
                    programWrite.SubtitlePlace = 0;
                    programWrite.SubtitleColor = "faLse";
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
                else { programWrite.ImagesListFile = "falSe"; }


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
                    else
                    {
                        programWrite.FixPoint = "falsE";
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

                List<String> text = new List<String>();

                text.Add(programWrite.ProgramName.ToLower());
                text.Add(programWrite.NumExpositions.ToString());
                text.Add(programWrite.ExpositionTime.ToString());
                text.Add(programWrite.ExpositionRandom.ToString());
                text.Add(programWrite.IntervalTime.ToString());
                text.Add(programWrite.IntervalTimeRandom.ToString());
                text.Add(programWrite.WordsListFile);
                text.Add(programWrite.ColorsListFile);
                text.Add(programWrite.BackgroundColor.ToUpper());
                text.Add(programWrite.AudioCapture.ToString());
                text.Add(programWrite.SubtitleShow.ToString());
                text.Add(programWrite.SubtitlePlace.ToString());
                text.Add(programWrite.SubtitleColor.ToUpper());
                text.Add(programWrite.ImagesListFile);
                text.Add(programWrite.FixPoint);

                //saveProgramFile(text, programWrite.InstructionText);
                var message = string.Join(Environment.NewLine, text);
                MessageBox.Show(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void saveProgramFile(string programText, List<string> instructions)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.InitialDirectory = path;
            save.FileName = progName.Text.ToLower() + ".prg";
            save.Filter = "Arquivo Programa (*.prg)|*.prg";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.WriteLine(programText);
                if(instructions != null)
                {
                    for (int i = 0; i < instructions.Count; i++)
                    {
                        writer.WriteLine(instructions[i]);
                    }
                }
                writer.Dispose();
                writer.Close();
                this.Close();
            }
        }

        private string openListFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            StroopProgram programOpened = new StroopProgram();
            string nameListFile = "error";

            openFileDialog1.InitialDirectory = path + "/lst/";//"c:\\";
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
    }
}
