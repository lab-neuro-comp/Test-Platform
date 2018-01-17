/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Controllers;
using System.Collections.Generic;
using TestPlatform.Views;
using System.Linq;
using System.Globalization;
using System.Resources;

namespace TestPlatform
{
    public partial class FormListConfig : Form
    {
        private string path;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public FormListConfig(string dataFolderPath, string lstName)
        {
            InitializeComponent();
            path = dataFolderPath;

            wordsListLabel.Text = "_words.lst";
            colorsListLabel.Text = "_color.lst";

            checkWords.Checked = true;
            checkColors.Checked = true;

            if (lstName.ToLower() != "false")
            {
                editList(lstName);
            }
        }

        private void listNameBox_TextChanged(object sender, EventArgs e)
        {
            wordsListLabel.Text = listNameTextBox.Text + "_words.lst";
            colorsListLabel.Text = listNameTextBox.Text + "_color.lst";
        }

        private void editList(string fileName)
        {
            StroopProgram program = new StroopProgram();
            string wordsFilePath = "", colorsFilePath = "";
            string[] wordsArray = null, colorsArray = null;

            try
            {
                fileName = fileName.Remove(fileName.Length - 6);

                wordsFilePath = this.path + fileName + "_words.lst";
                colorsFilePath = this.path + fileName + "_colors.lst";

                this.listNameTextBox.Text = fileName;

                this.checkWords.Checked = false;
                this.checkColors.Checked = false;

                if (File.Exists(wordsFilePath))
                {
                    wordsArray = StrList.readListFile(wordsFilePath);
                    this.checkWords.Checked = true;
                    foreach (string item in wordsArray)
                    {
                        wordsColoredList.Items.Add(item);
                    }
                }
                if (File.Exists(colorsFilePath))
                {
                    colorsArray = StrList.readListFile(colorsFilePath);
                    checkColors.Checked = true;
                    for (int i = 0; i < colorsArray.Length; i++)
                    {
                        if (Validations.isHexPattern(colorsArray[i]))
                        {
                            hexColorsList.Items.Add(colorsArray[i]);
                            hexColorsList.Items[i].ForeColor = ColorTranslator.FromHtml(colorsArray[i]);
                            if (File.Exists(wordsFilePath)) { wordsColoredList.Items[i].ForeColor = ColorTranslator.FromHtml(colorsArray[i]); }
                        }
                    }
                }

                /*
                wordsListLabel.Text = testFileName(lst) + "_Words";
                colorsListLabel.Text = testFileName(lst) + "_Color";
                listNameTextBox.Text = testFileName(lst);
                
                wordsArray = program.readListFile(path + appendType + ".lst");
                list = program.readListFile(path + appendType + ".lst");

                if (editLstName != "error")
                {
                    list = program.readListFile(path + editLstName + ".lst");
                    if (Regex.IsMatch(list[0], hexPattern))
                    {
                        checkColors.Checked = true;
                        checkWords.Checked = false;
                        for (int i = 0; i < list.Length; i++)
                        {
                            hexColorsList.Items.Add(list[i]);
                            hexColorsList.Items[i].ForeColor = ColorTranslator.FromHtml(list[i]);
                        }
                    }
                    else
                    {
                        checkColors.Checked = false;
                        checkWords.Checked = true;
                        for (int i = 0; i < list.Length; i++)
                        {
                            wordsColoredList.Items.Add(list[i]);
                        }
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void wordsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWords.Checked)
            {
                wordTextBox.Enabled = true;
                wordsColoredList.Enabled = true;
                wordsListLabel.Enabled = true;
                wordsColoredList.Items.Clear();
            }
            else
            {
                if (!hexColorTextBox.Enabled)
                {
                    hexColorTextBox.Enabled = true;
                    hexColorsList.Enabled = true;
                    checkColors.Checked = true;
                    colorsListLabel.Enabled = true;
                }
                wordTextBox.Enabled = false;
                wordTextBox.Text = "";
                wordsColoredList.Enabled = false;
                wordsListLabel.Enabled = false;
                wordsColoredList.Items.Clear();
            }
        }

        private void colorsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (checkColors.Checked)
            {
                hexColorTextBox.Enabled = true;
                hexColorTextBox.Text = "#000000";
                hexColorsList.Enabled = true;
                wordsColoredList.Items.Clear();
            }
            else
            {
                if (!wordTextBox.Enabled)
                {
                    wordTextBox.Enabled = true;
                    wordsColoredList.Enabled = true;
                    checkWords.Checked = true;
                }
                hexColorTextBox.Enabled = false;
                hexColorsList.Enabled = false;
                hexColorsList.Items.Clear();
            }
        }


        private void buttonColors_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            if (colorCode != null)
            {
                hexColorTextBox.ForeColor = ColorTranslator.FromHtml(colorCode);
                hexColorTextBox.Text = colorCode;
            }
        }

        private string pickColor()
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.CustomColors = new int[] {
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#F8E000")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#007BB7")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#7EC845")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#D01C1F"))
                                      };
            Color colorPicked = this.BackColor;
            string hexColor = null;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = MyDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }
            return hexColor;
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {
                var box = (TextBox)sender;
            if (box.Text.Length <= 1)
            {
                box.Text = "#";
                box.SelectionStart = 1;
            }
            else if(hexColorTextBox.TextLength == 7) { 
                hexColorTextBox.ForeColor = ColorTranslator.FromHtml(hexColorTextBox.Text);
            }
            else
            {
                hexColorTextBox.ForeColor = Color.Black;
            }
            
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
                if (checkWords.Checked && checkColors.Checked && !String.IsNullOrEmpty(wordTextBox.Text) && !String.IsNullOrEmpty(hexColorTextBox.Text))
                {
                    if (wordsColoredList.Items.Count != hexColorsList.Items.Count)
                    {
                        wordsColoredList.Items.Clear();
                        hexColorsList.Items.Clear();
                    }
                    wordsColoredList.Items.Add(wordTextBox.Text);
                    hexColorsList.Items.Add(hexColorTextBox.Text);
                }
                if (checkWords.Checked && !checkColors.Checked && !String.IsNullOrEmpty(wordTextBox.Text))
                {
                    wordsColoredList.Items.Add(wordTextBox.Text);
                }
                if (checkColors.Checked && !checkWords.Checked && !String.IsNullOrEmpty(hexColorTextBox.Text))
                {
                    hexColorsList.Items.Add(hexColorTextBox.Text);
                }
                foreach (ListViewItem lvw1 in hexColorsList.Items)
                {
                    lvw1.ForeColor = ColorTranslator.FromHtml(lvw1.Text);
                }
                for (int i = 0; i < wordsColoredList.Items.Count; i++)
                {
                    if (i < hexColorsList.Items.Count)
                    {
                        wordsColoredList.Items[i].ForeColor = ColorTranslator.FromHtml(hexColorsList.Items[i].Text);
                    }
                }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (checkWords.Checked && checkColors.Checked)
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


        private bool saveListFile(List<string> list, string filePath, string fileName, string fileType, string type)
        {
            StrList strlist;
            if ((MessageBox.Show("Deseja salvar o arquivo " + type + " '" + fileName + "' ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK))
            {
                strlist = ListController.CreateList(list, fileName, fileType);
                if (strlist.exists())
                {
                    DialogResult dialogResult = MessageBox.Show("Uma lista com este nome já existe.\nDeseja sobrescrevê-la?", "", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show("A lista não será salva");
                        return false;
                    }
                }
                if (strlist.save())
                {
                    MessageBox.Show("A lista '" + fileName + "' foi salva com sucesso");

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<string> colorList = hexColorsList.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
            List<string> wordList = wordsColoredList.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
            bool valid = true;
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");
            else { 
                if (checkColors.Checked) 
                {
                    valid = saveListFile(colorList, path, listNameTextBox.Text, "_color" + ".lst", "de Cores");
                }

                if (checkWords.Checked) 
                {
                    valid = saveListFile(wordList, path, listNameTextBox.Text, "_words" + ".lst", "de Palavras");
                }
                    Close();
                
            }
        }

        private void listName_Validating(object sender,
                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListName(listNameTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.listNameTextBox, errorMsg);
            }
        }

        private void listName_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.listNameTextBox, "");
        }

        public bool ValidListName(string name, out string errorMessage)
        {
            if (Validations.isEmpty(name))
            {
                errorMessage = "O nome da lista deve ser preenchido";
                return false;
            }
            if (!Validations.isAlphanumeric(name))
            {
                errorMessage = LocRM.GetString("listNotAlphanumeric", currentCulture);
                return false;
            }
            errorMessage = "";
            return true;
        }

        private void colorName_Validating(object sender,
                     System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidColorName(hexColorTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.hexColorTextBox, errorMsg);
            }
        }

        private void colorName_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.hexColorTextBox, "");
        }

        public bool ValidColorName(string name, out string errorMessage)
        {
            if (!Validations.isEmpty(name) && !(Validations.isHexPattern(name) && hexColorTextBox.TextLength == 7))
            {
                errorMessage = "O código de cor deve estar em formato hexadecimal.\nEx: #000000";
                return false;
            }

            errorMessage = "";
            return true;
        }


        private void listLength_Validated(object sender, System.EventArgs e)
        {
            labelEmpty.Visible = false;
        }

        public bool ValidListLength(int number, out string errorMessage)
        {
            if (number == 0)
            {
                errorMessage = "A lista não possui \n nenhum item!";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void hexColorList_Validating(object sender,
                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (checkColors.Checked && !ValidListLength(hexColorsList.Items.Count, out errorMsg))
            {
                e.Cancel = true;
                labelEmpty.Text = errorMsg;
                labelEmpty.Visible = true;
            }
        }

        private void wordList_Validating(object sender,
                     System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (checkWords.Checked && !ValidListLength(wordsColoredList.Items.Count, out errorMsg))
            {
                e.Cancel = true;
                labelEmpty.Text = errorMsg;
                labelEmpty.Visible = true;
            }
        }
        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            Close();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("wordColorConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }

}
