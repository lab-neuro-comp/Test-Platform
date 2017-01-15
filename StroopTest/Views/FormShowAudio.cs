using System;
using System.Media;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;
using StroopTest.Controllers;
using System.IO;

namespace StroopTest
{
    public partial class FormShowAudio : Form
    {
        private string path;
        private SoundPlayer player = new SoundPlayer();
        private string instructionsText = HelpData.ShowAudioInstructions;

        public FormShowAudio(string dataFolderPath)
        {
            InitializeComponent();
            path = dataFolderPath;
            string[] filePaths = null;

            if (Directory.Exists(dataFolderPath)) // Preenche dgv com arquivos do tipo .wav no diretório dado
            {
                filePaths = Directory.GetFiles(path, "*.WAV", SearchOption.AllDirectories);
                DGVManipulation.readStringListIntoDGV(filePaths, audioPathDataGridView);
                numberFiles.Text = audioPathDataGridView.RowCount.ToString();
            }
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            Close();
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

        private void stopAudio_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
    }
}
