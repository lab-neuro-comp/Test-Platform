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
        public FormNewAudio()
        {
            InitializeComponent();
            recordingLabel.Visible = false;

        }

        private void recordingButton_Click(object sender, EventArgs e)
        {
            recordingLabel.Visible = true;
            audioRecorder.startRecording();
        }
        
        private void stopRecordingButton_Click(object sender, EventArgs e)
        {
            recordingLabel.Visible = false;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAVE|*.wav";

            if (save.ShowDialog() == DialogResult.OK) // this is where it needs to be altered
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
