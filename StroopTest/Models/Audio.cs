
using System.Runtime.InteropServices;
using CSCore.SoundIn;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;
using System;

namespace TestPlatform.Models
{
    class Audio
    {
        WasapiCapture capture;
        WaveWriter writer;


        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        

        public bool startRecording(string path)
        {
            capture = new WasapiCapture();
            capture.Initialize();
            writer = new WaveWriter(path, capture.WaveFormat);
            capture.DataAvailable += (s, e) =>
            {
                //save the recorded audio
                writer.Write(e.Data, e.Offset, e.ByteCount);
            };
            capture.Start();
            return true;
        }
        public bool pauseRecording()
        {
            capture.Stop();
            return true;
        }

        public bool saveRecording()
        {
            if(capture != null)
            {
                capture.Stop();
                capture.Dispose();
                writer.Dispose();
            }
            
            return true;
        }

        public void playAudio(string file)
        {
            mciSendString("play " + file, null, 0, 0);
        }
    }
}
