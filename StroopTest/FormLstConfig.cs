using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormLstConfig : Form
    {
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private string path;
        private bool onlyColorLst = false;
        private bool onlyWordLst = false;
        private bool colorWordLst = true;

        public FormLstConfig(string dataFolderPath)
        {
            path = dataFolderPath + "/lst/";
            InitializeComponent();

            wordsListName.Text = "_Words.lst";
            colorsListName.Text = "_Colors.lst";

            checkWords.Checked = true;
            checkColors.Checked = true;
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWords.Checked)
            {
                textWords.Enabled = true;
                wordsColoredList.Enabled = true;
                wordsListName.Enabled = true;
                wordsColoredList.Items.Clear();
            }
            else
            {
                if (!textHexColor.Enabled)
                {
                    textHexColor.Enabled = true;
                    hexColorsList.Enabled = true;
                    checkColors.Checked = true;
                    colorsListName.Enabled = true;
                }
                textWords.Enabled = false;
                textWords.Text = "";
                wordsColoredList.Enabled = false;
                wordsListName.Enabled = false;
                wordsColoredList.Items.Clear();
            }
        }
        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkColors.Checked)
            {
                textHexColor.Enabled = true;
                textHexColor.Text = "#000000";
                hexColorsList.Enabled = true;
                wordsColoredList.Items.Clear();
            }
            else
            {
                if (!textWords.Enabled)
                {
                    textWords.Enabled = true;
                    wordsColoredList.Enabled = true;
                    checkWords.Checked = true;
                }
                textHexColor.Enabled = false;
                hexColorsList.Enabled = false;
                hexColorsList.Items.Clear();
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            if (colorCode != null)
            {
                textHexColor.ForeColor = ColorTranslator.FromHtml(colorCode);
                textHexColor.Text = colorCode;
            }
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
            string hexColor = null;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = MyDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }
            return hexColor;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var box = (TextBox)sender;
                if (box.Text.Length <= 1)
                {
                    box.Text = "#";
                    box.SelectionStart = 1;
                }

                if (box.Text.Length == 7 && !Regex.IsMatch(box.Text, hexPattern))
                {
                    throw new Exception("O código de cor deve estar em formato hexadecimal.\nEx: #000000");
                }


                if (Regex.IsMatch(textHexColor.Text, hexPattern) && textHexColor.TextLength == 7)
                {
                    textHexColor.ForeColor = ColorTranslator.FromHtml(textHexColor.Text);
                }
                else
                {
                    textHexColor.ForeColor = Color.Black;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Regex.IsMatch(textHexColor.Text, hexPattern) && textHexColor.TextLength == 7)
            {
                if(checkWords.Checked && checkColors.Checked && !String.IsNullOrEmpty(textWords.Text) && !String.IsNullOrEmpty(textHexColor.Text))
                {
                    if(wordsColoredList.Items.Count != hexColorsList.Items.Count)
                    {
                        wordsColoredList.Items.Clear();
                        hexColorsList.Items.Clear();
                    }
                    wordsColoredList.Items.Add(textWords.Text);
                    hexColorsList.Items.Add(textHexColor.Text);
                }
                if(checkWords.Checked && !checkColors.Checked && !String.IsNullOrEmpty(textWords.Text))
                {
                    wordsColoredList.Items.Add(textWords.Text);
                }
                if (checkColors.Checked && !checkWords.Checked && !String.IsNullOrEmpty(textHexColor.Text))
                {
                    hexColorsList.Items.Add(textHexColor.Text);
                }

                foreach (ListViewItem lvw1 in hexColorsList.Items)
                {
                    lvw1.ForeColor = ColorTranslator.FromHtml(lvw1.Text);
                }

                for (int i = 0; i < wordsColoredList.Items.Count; i++)
                {
                    if(i < hexColorsList.Items.Count)
                    {
                        wordsColoredList.Items[i].ForeColor = ColorTranslator.FromHtml(hexColorsList.Items[i].Text);
                    }
                }
                
            }
            else
            { 
                MessageBox.Show("A cor deve estar no formato hexadecimal padrão;\nExemplo: #000000");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkWords.Checked && checkColors.Checked)
            {
                if (hexColorsList.Items.Count > 0 && wordsColoredList.Items.Count > 0)
                {
                    if (hexColorsList.SelectedItems.Count == 0)
                    {
                        hexColorsList.Items.RemoveAt(hexColorsList.Items.Count - 1);
                        wordsColoredList.Items.RemoveAt(wordsColoredList.Items.Count - 1);
                    }
                    else
                    {
                        for (int i = 0; i < hexColorsList.Items.Count; i++)
                        {
                            if (hexColorsList.Items[i].Selected || wordsColoredList.Items[i].Selected)
                            {
                                hexColorsList.Items[i].Remove();
                                wordsColoredList.Items[i].Remove();
                                i--;
                            }
                        }
                    }
                }
            }
            if (checkWords.Checked && !checkColors.Checked)
            {
                if (wordsColoredList.Items.Count > 0)
                {
                    if (wordsColoredList.SelectedItems.Count == 0)
                        wordsColoredList.Items.RemoveAt(wordsColoredList.Items.Count - 1);
                    else
                        foreach (ListViewItem eachItem in wordsColoredList.SelectedItems)
                            wordsColoredList.Items.Remove(eachItem);
                }
            }

            if (checkColors.Checked && !checkWords.Checked)
            {
                if (hexColorsList.Items.Count > 0)
                {
                    if (hexColorsList.SelectedItems.Count == 0)
                        hexColorsList.Items.RemoveAt(hexColorsList.Items.Count - 1);
                    else
                        foreach (ListViewItem eachItem in hexColorsList.SelectedItems)
                            hexColorsList.Items.Remove(eachItem);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    throw new Exception("Nome do(s) arquivo(s) deve ser preenchido");
                }

                /*
                SaveFileDialog saveColorsList = new SaveFileDialog();
                saveColorsList.InitialDirectory = (Path.GetDirectoryName(Application.ExecutablePath) + "/data/lst/");
                saveColorsList.Filter = "Lista de Cores (*.lst)|*.lst";

                SaveFileDialog saveWordsList = new SaveFileDialog();
                saveWordsList.InitialDirectory = (Path.GetDirectoryName(Application.ExecutablePath) + "/data/lst/");
                saveWordsList.Filter = "Lista de Palavras (*.lst)|*.lst";
                */
                
                if (/*saveColorsList.ShowDialog() == DialogResult.OK && */checkColors.Enabled) // lê instrução se houver
                {
                    if(hexColorsList.Items.Count > 0 && (MessageBox.Show("Deseja salvar o arquivo " + textBox1.Text + "_Colors.lst?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK))
                    {
                        StreamWriter writer1 = new StreamWriter(path + textBox1.Text + "_Colors.lst" /*saveColorsList.OpenFile()*/);

                        for (int i = 0; i < hexColorsList.Items.Count; i++)
                        {
                            writer1.Write(hexColorsList.Items[i].Text + "\t");
                        }

                        writer1.Dispose();
                        writer1.Close();
                        MessageBox.Show("A lista " + textBox1.Text + "_Colors.lst foi salva com sucesso.");
                    }
                    else
                    {
                        throw new Exception("A lista de cores não foi salva!");
                    }
                    
                }

                if (/*saveWordsList.ShowDialog() == DialogResult.OK && */ checkWords.Enabled) // lê instrução se houver
                {
                    if(wordsColoredList.Items.Count > 0 && (MessageBox.Show("Deseja salvar o arquivo " + textBox1.Text + "_Words.lst?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK))
                    {
                        StreamWriter writer2 = new StreamWriter(path + textBox1.Text + "_Words.lst" /*saveWordsList.OpenFile()*/);

                        for (int i = 0; i < wordsColoredList.Items.Count; i++)
                        {
                            writer2.Write(wordsColoredList.Items[i].Text + "\t");
                        }

                        writer2.Dispose();
                        writer2.Close();
                        MessageBox.Show("A lista " + textBox1.Text + "_Words.lst foi salva com sucesso.");
                    }
                    else
                    {
                        throw new Exception("A lista de palavras não foi salva!");
                    }
                }
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hexColorsList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            if (!Regex.IsMatch(textHexColor.Text, hexPattern) || !(textHexColor.TextLength == 7))
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            wordsListName.Text = textBox1.Text + "_Words.lst";
            colorsListName.Text = textBox1.Text + "_Colors.lst";
        }
    }
    
}
