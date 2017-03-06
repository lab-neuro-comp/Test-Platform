using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;
using StroopTest.Controllers;

namespace StroopTest
{
    public partial class FormWordColorConfig : Form
    {
        List<string> wordsList = new List<string>(), colorsList = new List<string>();
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private string path;
        private string instructionsText = HelpData.WordColorConfigInstructions;

        public FormWordColorConfig(string listsPath, bool editFile)
        {
            path = listsPath;
            InitializeComponent();
            if (editFile)
            {
                openFilesForEdition(listsPath);
            }
            else
            {
                wordsListCheckBox.Checked = true;
                colorsListCheckBox.Checked = true;
                numberItens.Text = wordsDataGridView.RowCount.ToString();
                checkTypeOfList();
            }
        }
        

        private void openFilesForEdition(string filePath)
        {
            try
            {
                FormDefine defineFilePath = new FormDefine("Listas de Palavras: ", filePath, "lst", "_words_color", true);
                var result = defineFilePath.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string fileName = defineFilePath.ReturnValue;
                    fileName = fileName.Remove(fileName.Length - 6);
                    listNameTextBox.Text = fileName;

                    string wFile = filePath + "/" + fileName + "_words.lst";
                    string cFile = filePath + "/" + fileName + "_color.lst";
                    
                    if (File.Exists(wFile))
                    {
                        string[] wordsArray = StrList.readListFile(wFile);
                        foreach(string word in wordsArray)
                        {
                            wordsList.Add(word);
                        }
                        wordsListCheckBox.Checked = true;
                    }
                    if (File.Exists(cFile))
                    {
                        string[] colorsArray = StrList.readListFile(cFile);
                        foreach(string color in colorsArray)
                        {
                            colorsList.Add(color);
                        }
                        colorsListCheckBox.Checked = true;
                    }
                    checkTypeOfList();
                    numberItens.Text = wordsDataGridView.RowCount.ToString();
                }
                else
                {
                    wordsListCheckBox.Checked = true;
                    colorsListCheckBox.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void newItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                FormWordColorDialog dialog = new FormWordColorDialog();
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string[] tokens = dialog.ReturnValue.Split(' ');
                    wordsList.Add(tokens[0]);
                    colorsList.Add(tokens[1]);
                    clearDGV(wordsDataGridView);
                    readColoredWordsIntoDGV(wordsList, colorsList, wordsDataGridView);
                }
                numberItens.Text = wordsDataGridView.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wordsListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!wordsListCheckBox.Checked && !colorsListCheckBox.Checked)
            {
                colorsListCheckBox.Checked = !wordsListCheckBox.Checked;
            }
            checkTypeOfList();
        }

        private void colorsListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!wordsListCheckBox.Checked && !colorsListCheckBox.Checked)
            {
                wordsListCheckBox.Checked = !colorsListCheckBox.Checked;
            }
            checkTypeOfList();
        }

        private void checkTypeOfList()
        {
            try
            {
                clearDGV(wordsDataGridView);
                if (wordsListCheckBox.Checked && colorsListCheckBox.Checked)
                {
                    wordsDataGridView.Columns[0].HeaderText = "Lista de Palavras com Cores";
                    readColoredWordsIntoDGV(wordsList, colorsList, wordsDataGridView);
                }
                if (wordsListCheckBox.Checked && !colorsListCheckBox.Checked)
                {
                    wordsDataGridView.Columns[0].HeaderText = "Lista de Palavras";
                    readWordsIntoDGV(wordsList, wordsDataGridView);
                }
                if (!wordsListCheckBox.Checked && colorsListCheckBox.Checked)
                {
                    wordsDataGridView.Columns[0].HeaderText = "Lista de Cores";
                    readColorsIntoDGV(colorsList, wordsDataGridView);
                }
                numberItens.Text = wordsDataGridView.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readWordsIntoDGV(List<string> words, DataGridView dataGridView)
        {
            try
            {
                for (int i = 0; i < words.Count; i++)
                {
                    dataGridView.Rows.Add(words[i]);
                    dataGridView.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void readColorsIntoDGV(List<string> colors, DataGridView dataGridView)
        {
            try
            {
                for (int i = 0; i < colors.Count; i++)
                {
                    dataGridView.Rows.Add(colors[i]);
                    if (Regex.IsMatch(colors[i], hexPattern))
                    {
                        dataGridView.Rows[i].Cells[0].Style.ForeColor = ColorTranslator.FromHtml(colors[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void readColoredWordsIntoDGV(List<string> words, List<string> colors, DataGridView dataGridView)
        {
            try
            {
                for (int i = 0; i < words.Count; i++)
                {
                    dataGridView.Rows.Add(words[i]);
                }
                for (int i = 0; i < colors.Count; i++)
                {
                    if (Regex.IsMatch(colors[i], hexPattern))
                    {
                        dataGridView.Rows[i].Cells[0].Style.ForeColor = ColorTranslator.FromHtml(colors[i]);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void clearDGV(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (wordsDataGridView.RowCount > 0)
                {
                    int rowIndex = wordsDataGridView.SelectedCells[0].OwningRow.Index;
                    string item = wordsList[rowIndex];
                    if (wordsList.Count > 0)
                    {
                        wordsList.RemoveAt(rowIndex);
                    }
                    if (colorsList.Count > 0)
                    {
                        colorsList.RemoveAt(rowIndex);
                    }
                    checkTypeOfList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if (wordsDataGridView.RowCount == 0)
                return;
            DGVManipulation.moveDGVRowUp(wordsDataGridView);
            int rowIndex = wordsDataGridView.SelectedCells[0].OwningRow.Index;
            moveUpItem(wordsList, rowIndex);
            moveUpItem(colorsList, rowIndex);
        }

        private void moveUpItem(List<string> list, int index)
        {
            try
            {
                if (index == 0)
                    return;
                string item = list[index];
                list.RemoveAt(index);
                list.Insert(index - 1, item);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if (wordsDataGridView.RowCount == 0)
                return;
            DGVManipulation.moveDGVRowDown(wordsDataGridView);
            int rowIndex = wordsDataGridView.SelectedCells[0].OwningRow.Index;
            moveDownItem(wordsList, rowIndex);
            moveDownItem(colorsList, rowIndex);
        }

        private void moveDownItem(List<string> list, int index)
        {
            try
            {
                if (index == list.Count-1)
                    return;
                string item = list[index];
                list.RemoveAt(index);
                list.Insert(index + 1, item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool saveListFile(List<string> list, string filePath, string fileName, string fileType, string type)
        {
            string file;
            StrList strlist;
            if ((MessageBox.Show("Deseja salvar o arquivo " + type + " '" + fileName + "' ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK))
            {
                strlist = ListController.createList(list, fileName);
                if (strlist.exists(filePath + fileName + fileType))
                {
                    DialogResult dialogResult = MessageBox.Show("Uma lista com este nome já existe.\nDeseja sobrescrevê-la?", "", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show("A lista não será salva");
                        return false;
                    }
                }
                file = filePath + fileName + fileType;
                if (strlist.save(file))
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
            bool valid = true;
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");
            else
            {
                if (wordsListCheckBox.Checked)
                    valid = saveListFile(wordsList, path, listNameTextBox.Text, "_words" + ".lst", "de Palavras");
                if (colorsListCheckBox.Checked)
                    valid = saveListFile(colorsList, path, listNameTextBox.Text, "_color" + ".lst", "de Cores");                
                if (valid)
                    Close();
                else
                    MessageBox.Show("Lista não cadastrada");
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

        private void listLength_Validating(object sender,
                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListLength(wordsDataGridView.RowCount, out errorMsg))
            {
                e.Cancel = true;
                labelEmpty.Text = errorMsg;
                labelEmpty.Visible = true;
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(instructionsText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            Close();
        }
    }
}
