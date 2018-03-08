using System;
using System.Media;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views;
using TestPlatform.Controllers;
using System.Drawing;
using System.Resources;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

namespace TestPlatform
{
    public partial class FormAudioConfig : UserControl
    {
        private bool isListNameValid = false;

        private SoundPlayer player = new SoundPlayer();
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private StrList audioList;
        private static int AUDIO = 1;

        public bool isValid()
        {
            return isListNameValid;
        }

        public FormAudioConfig(bool editList)
        {
            InitializeComponent();
            labelEmpty.Visible = false;
            this.Dock = DockStyle.Fill;
            if (editList)
            {
                openFilesForEdition();
            }
        }

        private void openFilesForEdition()
        {
            FormDefine defineFilePath = new FormDefine(LocRM.GetString("audioList", currentCulture), Global.testFilesPath + Global.listFolderName, "dir", "_audio", true, false);
            var result = defineFilePath.ShowDialog();

            if (result == DialogResult.OK)
            {
                isListNameValid = true;
                string choosenList = defineFilePath.ReturnValue;

                if (choosenList == "")
                {
                    isListNameValid = false;
                    return;
                }
                // removes the _audio identification from file while editing (when its saved it is always added again)
                audioListNameTextBox.Text = choosenList;

                audioList = new StrList(choosenList, AUDIO);

                string[] filePaths = audioList.ListContent.ToArray();
                DGVManipulation.ReadStringListIntoDGV(filePaths, audioPathDataGridView);
                numberFiles.Text = audioPathDataGridView.RowCount.ToString();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openAudioDirectory();
        }

        private void openAudioDirectory()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "WAV Audio (*.WAV)|*.WAV";
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] fileNames = openFileDialog.FileNames;
                    DGVManipulation.ReadStringListIntoDGV(fileNames, audioPathDataGridView);
                    numberFiles.Text = audioPathDataGridView.RowCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            DGVManipulation.DeleteDGVRow(dgv);
            numberFiles.Text = audioPathDataGridView.RowCount.ToString();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            DGVManipulation.MoveDGVRowUp(dgv);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            DGVManipulation.MoveDGVRowDown(dgv);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            DataGridView dgv = audioPathDataGridView;
            try
            {
                DGVManipulation.CloseFormListNotEmpty(dgv);
                this.Parent.Controls.Remove(this);
                ListController.recoverEditingProgram(LocRM.GetString("open",currentCulture));
            }
            catch (Exception ex)
            {
                this.Parent.Controls.Remove(this);
                MessageBox.Show(ex.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool hasValidFiles = true;
            try
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    List<string> content = new List<string>();
                    for (int i = 0; i < audioPathDataGridView.RowCount; i++)
                    {
                        if (!File.Exists(audioPathDataGridView.Rows[i].Cells[1].Value.ToString()))
                        {
                            hasValidFiles = false;
                        }
                        content.Add(audioPathDataGridView.Rows[i].Cells[1].Value.ToString());
                    }
                    
                    audioList = new StrList(content, this.audioListNameTextBox.Text, "_audio");

                    if (audioList.saveContent(hasValidFiles))
                    {
                        MessageBox.Show(LocRM.GetString("list", currentCulture) + this.audioListNameTextBox.Text + "_audio" + LocRM.GetString("listSaveSuccess", currentCulture));
                        this.Parent.Controls.Remove(this);
                        ListController.recoverEditingProgram(this.audioListNameTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show(LocRM.GetString("list", currentCulture) + this.audioListNameTextBox.Text + "_audio'" + LocRM.GetString("notCreated", currentCulture));
                    }
                }                   
                else
                {
                    MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void audioPathDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            playCurrentAudio();
        }

        private void playAudioButton_Click(object sender, EventArgs e)
        {
            playCurrentAudio();
        }

        private void playCurrentAudio()
        {
            player.SoundLocation = audioPathDataGridView.CurrentRow.Cells[1].Value.ToString();
            player.Play();
        }

        private void audioPathDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            if (e.Control && e.KeyCode == Keys.Left)
            {
                try
                {
                    DGVManipulation.MoveDGVRowUp(dgv);
                }
                catch { }
            }
            if (e.Control && e.KeyCode == Keys.Right)
            {
                try
                {
                    DGVManipulation.MoveDGVRowDown(dgv);
                }
                catch { }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("audioConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void audioListNameTextBox_Validating(object sender,
                System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidAudioListName(audioListNameTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(audioListNameTextBox, errorMsg);
            }
        }

        private void audioListNameTextBox_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(audioListNameTextBox, "");
        }

        public bool ValidAudioListName(string listName, out string errorMessage)
        {
            if (Validations.isEmpty(listName))
            {
                errorMessage = LocRM.GetString("emptyListName", currentCulture);
                return false;
            }
            if (!Validations.isAlphanumeric(listName))
            {
                errorMessage = LocRM.GetString("listNotAlphanumeric", currentCulture);
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
                errorMessage = LocRM.GetString("emptyList", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void listLength_Validating(object sender,
                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListLength(audioPathDataGridView.RowCount, out errorMsg))
            {
                e.Cancel = true;
                labelEmpty.Text = errorMsg;
                labelEmpty.Visible = true;
            }
        }
    }
}