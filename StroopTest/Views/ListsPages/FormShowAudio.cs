using System;
using System.Media;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views;
using TestPlatform.Controllers;
using System.IO;
using System.Drawing;
using System.Resources;
using System.Globalization;

namespace TestPlatform
{
    public partial class FormShowAudio : UserControl, IDisposable 
    {
        private string path = Global.stroopTestFilesPath + Global.resultsFolderName;
        private SoundPlayer player = new SoundPlayer();
        Audio audioRecorder = new Audio();
        private Timer timer;
        private DateTime startTime = DateTime.MinValue;
        private TimeSpan currentElapsedTime = TimeSpan.Zero;
        private bool timerRunning = false;
        private bool recording = false;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        
        public FormShowAudio()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            recordingLabel.Visible = false;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            currentElapsedTimeDisplay.Visible = false;
            
            loadingAudioFilesToDataGrid();
        }

        private void loadingAudioFilesToDataGrid()
        {
            // Fills data grid view with .wav files from data directory
            if (Directory.Exists(path)) 
            {
                audioPathDataGridView.Rows.Clear();
                audioPathDataGridView.Refresh();
                currenFolderLabel.Text = path;
                string[] filePaths = null;
                filePaths = Directory.GetFiles(path, "*.WAV", SearchOption.AllDirectories);
                DGVManipulation.ReadStringListIntoDGV(filePaths, audioPathDataGridView);
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
            DGVManipulation.MoveDGVRowUp(dgv);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            DataGridView dgv = audioPathDataGridView;
            DGVManipulation.MoveDGVRowDown(dgv);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            player.Dispose();
            if (recording)
            {
                audioRecorder.PauseRecording();
            }

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
            timeSinceStartTime = new TimeSpan((long)timeSinceStartTime.TotalSeconds);
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
                recordingLabel.Visible = false;
                timer.Stop();
                timerRunning = false;
                currentElapsedTime = TimeSpan.Zero;
                audioRecorder.SaveRecording();
                if (File.Exists(selectedDirectory.Text))
                {
                    long fileLength = new FileInfo(selectedDirectory.Text).Length;
                    if (fileLength != 0)
                    {
                        MessageBox.Show(LocRM.GetString("audioRecordSuccess", currentCulture));
                    }
                    else
                    {
                        MessageBox.Show(LocRM.GetString("audioRecordFailed", currentCulture));
                    }
                    loadingAudioFilesToDataGrid();
                    recording = false;
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("fileNotFound", currentCulture) + selectedDirectory.Text);
                }

            }            
            
            
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
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("showAudioInstructions", currentCulture) + LocRM.GetString("newAudioInstructions", currentCulture));
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
            try
            {
                if (selectedDirectory.Text != LocRM.GetString("none", currentCulture))
                {
                    if (recording != true)
                    {
                        audioRecorder.StartRecording(selectedDirectory.Text);
                        recordingLabel.Visible = true;
                        currentElapsedTimeDisplay.Visible = true;
                        if (!timerRunning)
                        {
                            startTime = DateTime.Now;

                            timer.Start();
                            timerRunning = true;
                        }
                        recording = true;
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show(LocRM.GetString("selectPlace", currentCulture), "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
