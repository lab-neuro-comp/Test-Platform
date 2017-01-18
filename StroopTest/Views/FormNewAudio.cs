using System;
using System.Media;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;
using StroopTest.Controllers;
using NAudio.Wave;
using System.Runtime.InteropServices;

namespace StroopTest
{
    public partial class FormNewAudio : Form
    {
        private string instructionsText = HelpData.NewAudioInstructions;
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        private string file = "";
        public FormNewAudio()
        {
            InitializeComponent();
            recordingLabel.Visible = false;

        }

        private void recordingButton_Click(object sender, EventArgs e)
        {
            recordingLabel.Visible = true;
            mciSendString("open new type waveaudio alias Som", null, 0, 0);
            mciSendString("record Som", null, 0, 0);
        }
        
        private void stopRecordingButton_Click(object sender, EventArgs e)
        {
            recordingLabel.Visible = false;
            mciSendString("pause Som", null, 0, 0);
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAVE|*.wav";

            if (save.ShowDialog() == DialogResult.OK) // this is where it needs to be altered
            {
                mciSendString("save Som " + save.FileName, null, 0, 0);
                mciSendString("close Som", null, 0, 0);
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
           OpenFileDialog open = new OpenFileDialog();
           open.Filter = "Wave|*.wav";
           if (open.ShowDialog() == DialogResult.OK) { file = open.FileName; }            
            mciSendString("play " + file, null, 0, 0);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(instructionsText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
