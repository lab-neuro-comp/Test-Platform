using System;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;

namespace StroopTest
{
    public partial class FormNewAudio : Form
    {
        private string instructionsText = HelpData.NewAudioInstructions;
        Audio audioRecorder = new Audio();
        private string file = "";
        private Timer timer;
        private DateTime startTime = DateTime.MinValue;
        private TimeSpan currentElapsedTime = TimeSpan.Zero;
        private bool timerRunning = false;

        public FormNewAudio()
        {
            InitializeComponent();
            recordingLabel.Visible = false;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            currentElapsedTimeDisplay.Visible = false;

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
            recordingLabel.Visible = true;
            currentElapsedTimeDisplay.Visible = true;
            audioRecorder.startRecording();
            if (!timerRunning)
            {
                startTime = DateTime.Now;

                timer.Start();
                timerRunning = true;
            }
        }
        
        private void stopRecordingButton_Click(object sender, EventArgs e)
        {
            audioRecorder.pauseRecording();
            recordingLabel.Visible = false;
            timer.Stop();
            timerRunning = false;
            currentElapsedTime = TimeSpan.Zero;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAVE|*.wav";
            if (save.ShowDialog() == DialogResult.OK) 
            {
                audioRecorder.saveRecording(save.FileName);
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
           OpenFileDialog open = new OpenFileDialog();
           open.Filter = "Wave|*.wav";
           if (open.ShowDialog() == DialogResult.OK) { file = open.FileName; }
            audioRecorder.playAudio(file);           
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(instructionsText);
            infoBox.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
