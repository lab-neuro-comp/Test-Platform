using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormAudioConfig : Form
    {
        private List<string> pathList = new List<string>();
        private string path;
        private SoundPlayer Player = new SoundPlayer();

        public FormAudioConfig(string audioFolderPath)
        {
            InitializeComponent();
            path = audioFolderPath;
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
                    foreach (string file in openFileDialog.FileNames)
                    {
                        try
                        {
                            pathList.Add(Path.GetFullPath(file));
                            audioPathDataGridView.Rows.Add(Path.GetFileNameWithoutExtension(file), Path.GetFullPath(file));
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não pode reproduzir audio: " + file.Substring(file.LastIndexOf('/'))
                                            + ". Você pode não ter permissão para ler este arquivo ou ele pode estar corrompido.\n" + ex.Message);
                        }
                    }
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
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            DGVManipulation.saveColumnToListFile(dgv, 1, path, audioListNameTextBox.Text + "_aud");
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
    }
}
