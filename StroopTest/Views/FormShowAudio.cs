using System;
using System.Media;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views;
using TestPlatform.Controllers;
using System.IO;
using System.Drawing;

namespace TestPlatform
{
    public partial class FormShowAudio : UserControl
    {
        private string path;
        private SoundPlayer player = new SoundPlayer();
        private string instructionsText = HelpData.ShowAudioInstructions + HelpData.NewAudioInstructions;
        Audio audioRecorder = new Audio();
        private string file = "";
        private Timer timer;
        private DateTime startTime = DateTime.MinValue;
        private TimeSpan currentElapsedTime = TimeSpan.Zero;
        private bool timerRunning = false;
        private string pathText = null;
        private bool recording = false;

        public FormShowAudio(string dataFolderPath)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            recordingLabel.Visible = false;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            currentElapsedTimeDisplay.Visible = false;
            
            path = dataFolderPath;
            loadingAudioFilesToDataGrid();
        }

        private void loadingAudioFilesToDataGrid()
        {

            if (Directory.Exists(path)) // Preenche dgv com arquivos do tipo .wav no diretório dado
            {
                audioPathDataGridView.Rows.Clear();
                audioPathDataGridView.Refresh();
                currenFolderLabel.Text = path;
                string[] filePaths = null;
                filePaths = Directory.GetFiles(path, "*.WAV", SearchOption.AllDirectories);
                DGVManipulation.readStringListIntoDGV(filePaths, audioPathDataGridView);
                numberFiles.Text = audioPathDataGridView.RowCount.ToString();
            }
            else
            {
                /*path doesnt exist*/
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
            this.Parent.Controls.Remove(this);
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

        void timer_Tick(object sender, EventArgs e)
        {
            var timeSinceStartTime = DateTime.Now - startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Seconds);
            currentElapsedTime = timeSinceStartTime;
            currentElapsedTimeDisplay.Text = timeSinceStartTime.ToString();

        }
        private void recordingButton_Click(object sender, EventArgs e)
        {
            

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAVE|*.wav";
            if (save.ShowDialog() == DialogResult.OK)
            {
                selectedDirectory.Text = save.FileName;
            }
            
            
        }

        private void stopRecordingButton_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                recording = false;
                recordingLabel.Visible = false;
                timer.Stop();
                timerRunning = false;
                currentElapsedTime = TimeSpan.Zero;
                audioRecorder.saveRecording();
                MessageBox.Show("Aúdio gravado com sucesso!");
                loadingAudioFilesToDataGrid();
            }            
            
            
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

        private void directoryButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                    loadingAudioFilesToDataGrid();
                }
                else
                {
                    /*do nothing*/
                }
            }
            
        }

        private void recordButton1_Click(object sender, EventArgs e)
        {
            if(selectedDirectory.Text != "Nenhum")
            {
                if(recording != true)
                {
                    recording = true;
                    audioRecorder.startRecording(selectedDirectory.Text);
                    recordingLabel.Visible = true;
                    currentElapsedTimeDisplay.Visible = true;
                    if (!timerRunning)
                    {
                        startTime = DateTime.Now;

                        timer.Start();
                        timerRunning = true;
                    }
                }
                
            }
            else
            {
                DialogResult dr = MessageBox.Show("É necessário selecionar o local do arquivo antes de gravar.", "", MessageBoxButtons.OK);
            }
            
        }
    }
}
