using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormAudioConfig : Form
    {
        private string path;
        private SoundPlayer Player = new SoundPlayer();
        private string instructionsText = "<h1>Ajuda</h1>";

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
                FormDefine defineFilePath = new FormDefine("Listas de Audio: ", path, "lst");
                var result = defineFilePath.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string dir = defineFilePath.ReturnValue;
                    audioListNameTextBox.Text = dir.Remove(dir.Length - 6); // removes the _img identification from file while editing (when its saved it is always added again)

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
            DataGridView dgv = audioPathDataGridView;
            try
            {
                DGVManipulation.closeFormListNotEmpty(dgv);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(audioListNameTextBox.Text))
                {
                    throw new Exception("Preencha o campo com o nome do arquivo!");
                }
                DataGridView dgv = audioPathDataGridView;
                DGVManipulation.saveColumnToListFile(dgv, 1, path, audioListNameTextBox.Text + "_audio");
                Close();
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
            Player.SoundLocation = audioPathDataGridView.CurrentRow.Cells[1].Value.ToString();
            Player.Play();
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
    }
}
