using System;
using System.Media;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;
using StroopTest.Controllers;

namespace StroopTest
{
    public partial class FormAudioConfig : Form
    {
        private string path;
        private SoundPlayer player = new SoundPlayer();
        private string instructionsText = HelpData.AudioConfigInstructions;

        public FormAudioConfig(string audioFolderPath, bool editList)
        {
            InitializeComponent();
            path = audioFolderPath;

            if (editList)
            {
                openFilesForEdition();
            }
        }

        private void openFilesForEdition()
        {
            try
            {
                FormDefine defineFilePath = new FormDefine("Listas de Audio: ", path, "lst", "_audio", true);
                var result = defineFilePath.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string dir = defineFilePath.ReturnValue;
                    audioListNameTextBox.Text = dir.Remove(dir.Length - 6); // removes the _audio identification from file while editing (when its saved it is always added again)

                    string[] filePaths = StroopProgram.readDirListFile(path + "/" + dir + ".lst");
                    DGVManipulation.readStringListIntoDGV(filePaths, audioPathDataGridView);
                    numberFiles.Text = audioPathDataGridView.RowCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    DGVManipulation.readStringListIntoDGV(fileNames, audioPathDataGridView);
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
            DGVManipulation.deleteDGVRow(dgv);
            numberFiles.Text = audioPathDataGridView.RowCount.ToString();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            DGVManipulation.moveDGVRowUp(dgv);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            DGVManipulation.moveDGVRowDown(dgv);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            DataGridView dgv = audioPathDataGridView;
            try
            {
                DGVManipulation.closeFormListNotEmpty(dgv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren(ValidationConstraints.Enabled))
                    MessageBox.Show("Algum campo não foi preenchido de forma correta.");
                else
                {
                    DataGridView dgv = audioPathDataGridView;
                    DGVManipulation.saveColumnToListFile(dgv, 1, path, audioListNameTextBox.Text + "_audio");
                    Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                    DGVManipulation.moveDGVRowUp(dgv);
                }
                catch { }
            }
            if (e.Control && e.KeyCode == Keys.Right)
            {
                try
                {
                    DGVManipulation.moveDGVRowDown(dgv);
                }
                catch { }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(instructionsText);
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
                errorMessage = "O nome da lista deve ser preenchido.";
                return false;
            }
            errorMessage = "";
            return true;
        }
    }
}