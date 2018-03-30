using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views;
using TestPlatform.Controllers;
using System.Resources;
using System.Globalization;

namespace TestPlatform
{
    public partial class FormWordColorConfig : UserControl
    {
        private bool isListNameValid = false;

        List<string> wordsList = new List<string>(), colorsList = new List<string>();
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public bool isValid()
        {
            return isListNameValid;
        }

        public FormWordColorConfig(bool editFile)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            if (editFile)
            {
                openFilesForEdition();
            }
            else
            {
                wordsListCheckBox.Checked = true;
                colorsListCheckBox.Checked = true;
            }
            colorListEmpty.Visible = false;
            wordListEmpty.Visible = false;
            updateListsCounters();
            checkTypeOfList();
        }
        
        private void updateListsCounters()
        {
            numberItensWord.Text = wordListView.Items.Count.ToString();
            numberItensColor.Text = colorListView.Items.Count.ToString();
        }

        private void openFilesForEdition()
        {
            try
            {
                FormDefine defineFilePath = new FormDefine(LocRM.GetString("wordList", currentCulture), Global.testFilesPath + Global.listFolderName, "lst", "_words_color", true, false);
                var result = defineFilePath.ShowDialog();

                if (result == DialogResult.OK)
                {
                    isListNameValid = true;
                    string fileName = defineFilePath.ReturnValue;

                    if(fileName == "")
                    {
                        isListNameValid = false;
                        return;
                    }

                    fileName = fileName.Remove(fileName.Length - 6);
                    listNameTextBox.Text = fileName;

                    string wFile = Global.testFilesPath + Global.listFolderName + "/" + fileName + "_words.lst";
                    string cFile = Global.testFilesPath + Global.listFolderName + "/" + fileName + "_color.lst";
                    if(!File.Exists(wFile) && !File.Exists(cFile))
                    {
                        return;
                    }
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
                    addItems();
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

        private void addItems()
        {
            int count = this.colorListView.Items.Count;
            foreach (string color in colorsList)
            {
                if (Validations.isHexPattern(color))
                {
                    ListViewItem newItem = colorListView.Items.Add(color);
                    newItem.ForeColor = ColorTranslator.FromHtml(color);
                }
            }
            foreach(string word in wordsList)
            {
                wordListView.Items.Add(word);
            }
        }


        private void newWordItemButton_Click(object sender, EventArgs e)
        {
            try
            {
               if (wordItemTextBox.TextLength > 0)
                {
                    wordsList.Add(wordItemTextBox.Text);
                    wordListView.Items.Add(wordItemTextBox.Text);
                    wordItemTextBox.Text = "";
                    this.errorProvider1.SetError(this.wordItemTextBox, "");
                }
               else
                {
                    this.errorProvider1.SetError(this.wordItemTextBox, LocRM.GetString("emptyBox", currentCulture));
                }
                
                updateListsCounters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void newColorButton_Click(object sender, EventArgs e)
        {
            try
            {
                string color = colorItemTextBox.Text;
                if (Validations.isHexPattern(color))
                {
                    colorsList.Add(color);
                    ListViewItem newItem = colorListView.Items.Add(color);
                    newItem.ForeColor = ColorTranslator.FromHtml(color);
                    colorItemTextBox.Text = "";
                    this.errorProvider1.SetError(this.colorItemTextBox, "");
                }
                else
                {
                    this.errorProvider1.SetError(this.colorItemTextBox, LocRM.GetString("colorMatch", currentCulture));
                }

                updateListsCounters();
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
                string listName = listNameTextBox.Text;
                if (wordsListCheckBox.Checked && colorsListCheckBox.Checked)
                {
                    wordGroupBox.Text = listName + "_words";
                    colorListGroupBox.Text = listName + "_color";
                    wordGroupBox.Enabled = true;
                    colorListGroupBox.Enabled = true;
                }
                else if (wordsListCheckBox.Checked && !colorsListCheckBox.Checked)
                {
                    wordGroupBox.Text = listName + "_words";
                    colorListGroupBox.Text = "-";

                    wordGroupBox.Enabled = true;
                    colorListGroupBox.Enabled = false;
                }
                else if (!wordsListCheckBox.Checked && colorsListCheckBox.Checked)
                {
                    wordGroupBox.Text = "-";
                    colorListGroupBox.Text = listName + "_color";

                    wordGroupBox.Enabled = false;
                    colorListGroupBox.Enabled = true;
                }

                updateListsCounters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void upWordItem_Click(object sender, EventArgs e)
        {
            MoveListViewItems(wordListView, MoveDirection.Up, wordsList);
        }

        private void upColorItem_Click(object sender, EventArgs e)
        {
            MoveListViewItems(colorListView, MoveDirection.Up, colorsList);
        }

        private void downWordItem_Click(object sender, EventArgs e)
        {
            MoveListViewItems(wordListView, MoveDirection.Down, wordsList);
        }

        private void downColorItem_Click(object sender, EventArgs e)
        {
            MoveListViewItems(colorListView, MoveDirection.Down, colorsList);
        }

        private enum MoveDirection { Up = -1, Down = 1 };

        private void MoveListViewItems(ListView sender, MoveDirection direction, List<string> list)
        {

            bool valid = sender.SelectedItems.Count > 0 &&
                            ((direction == MoveDirection.Down && (sender.SelectedItems[0].Index < sender.Items.Count - 1))
                        || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

            if (valid)
            {
                ListViewItem item = sender.SelectedItems[0];
                if (direction == MoveDirection.Up)
                {
                    moveUpItem(list, item.Index);
                }
                else if (direction == MoveDirection.Down)
                {
                    moveDownItem(list, item.Index);
                }

                int dir = (int)direction;
                int index = item.Index + dir;

                sender.Items.Remove(item);
                sender.Items.Insert(index, item);
                sender.Clear();
                foreach (string it in list)
                {
                    if (Validations.isHexPattern(it))
                    {
                        ListViewItem newItem = sender.Items.Add(it);
                        newItem.ForeColor = ColorTranslator.FromHtml(it);
                    }
                    else
                    {
                        sender.Items.Add(it);
                    }
                }
            }
        }

        private static void moveUpItem(List<string> list, int index)
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

        private static void moveDownItem(List<string> list, int index)
        {
            try
            {
                if (index == list.Count - 1)
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

        private bool saveListFile(List<string> list, string fileName, string fileType, string type)
        {
            if ((MessageBox.Show(LocRM.GetString("wishToSave", currentCulture) + type + " '" + fileName + "' ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK))
            {
                StrList strlist = ListController.CreateList(list, fileName, fileType);

                if (strlist.exists())
                {
                    DialogResult dialogResult = MessageBox.Show(LocRM.GetString("listExists", currentCulture), "", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show(LocRM.GetString("listNotSaved", currentCulture));
                        return false;
                    }
                }
                if (strlist.save())
                {
                    MessageBox.Show(LocRM.GetString("list", currentCulture) + fileName + LocRM.GetString("listSaveSuccess", currentCulture));
                    
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
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                bool valid = true;
                if (wordsListCheckBox.Checked)
                {
                    valid = saveListFile(wordsList, listNameTextBox.Text, "_words", LocRM.GetString("words", currentCulture));
                }
                if (colorsListCheckBox.Checked)
                {
                    valid = saveListFile(colorsList, listNameTextBox.Text, "_color", LocRM.GetString("colors", currentCulture));
                }
                if (valid)
                {
                    this.Parent.Controls.Remove(this);
                    ListController.recoverEditingProgram(listNameTextBox.Text);
                }
                else
                    MessageBox.Show(LocRM.GetString("listNotSaved", currentCulture));
            }
            else
            {
                MessageBox.Show(LocRM.GetString("notFilledProperlyMessage", currentCulture));
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
                errorMessage = LocRM.GetString("emptyListName", currentCulture);
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

        public bool ValidListLength(int number, out string errorMessage)
        {
            if (number == 0)
            {
                errorMessage = LocRM.GetString("emptyList", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("wordColorConfigInstructions", currentCulture));
            try
            {
                infoBox.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chooseColorButton_Click(object sender, EventArgs e)
        {
            string colorCode = pickColor();
            if (colorCode != null)
            {
                colorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
                colorsList.Add(colorCode);
                ListViewItem newItem = colorListView.Items.Add(colorCode);
                newItem.ForeColor = ColorTranslator.FromHtml(colorCode);
                colorItemTextBox.Text = "";
                this.errorProvider1.SetError(this.colorItemTextBox, "");
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

        private void deleteWordItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (wordListView.Items.Count > 0 && wordListView.SelectedItems.Count > 0)
                {
                    int rowIndex = wordListView.SelectedItems[0].Index;
                    wordListView.Items.RemoveAt(rowIndex);

                    if (wordsList.Count > 0)
                    {
                        wordsList.RemoveAt(rowIndex);
                    }
                    updateListsCounters();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteColorItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorListView.Items.Count > 0 && colorListView.SelectedItems.Count > 0)
                {
                    int rowIndex = colorListView.SelectedItems[0].Index;
                    colorListView.Items.RemoveAt(rowIndex);
                    if (colorsList.Count > 0)
                    {
                        colorsList.RemoveAt(rowIndex);
                    }
                    updateListsCounters();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string listName = listNameTextBox.Text;
            if (wordsListCheckBox.Checked)
            {
                wordGroupBox.Text = listName + "_words";
            }
            if (colorsListCheckBox.Checked)
            {
                colorListGroupBox.Text = listName + "_color";
            }
        }

        private void wordsListLength_Validated(object sender, EventArgs e)
        {
            wordListEmpty.Visible = false;
        }

        private void wordsListLength_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListLength(wordListView.Items.Count, out errorMsg))
            {
                e.Cancel = true;
                wordListEmpty.Text = errorMsg;
                wordListEmpty.Visible = true;
            }
        }

        private void colorsListLength_Validated(object sender, EventArgs e)
        {
            colorListEmpty.Visible = false;
        }

        private void colorsListLength_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListLength(colorListView.Items.Count, out errorMsg))
            {
                e.Cancel = true;
                colorListEmpty.Text = errorMsg;
                colorListEmpty.Visible = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
            ListController.recoverEditingProgram(LocRM.GetString("open", currentCulture));
        }
    }
}
