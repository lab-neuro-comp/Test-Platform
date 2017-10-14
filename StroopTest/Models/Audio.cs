namespace TestPlatform.Models
{
    using System.Runtime.InteropServices;
    using CSCore.Codecs.WAV;
    using CSCore.SoundIn;

    public class Audio
    {
        private WasapiCapture capture;
        private WaveWriter writer;
        
        public bool StartRecording(string path)
        {
            this.capture = new WasapiCapture();
            this.capture.Initialize();
            this.writer = new WaveWriter(path, this.capture.WaveFormat);
            this.capture.DataAvailable += (s, e) =>
            {
                // save the recorded audio
                this.writer.Write(e.Data, e.Offset, e.ByteCount);
            };
            this.capture.Start();
            return true;
        }

        public bool PauseRecording()
        {
            this.capture.Stop();
            return true;
        }

        public bool SaveRecording()
        {
            if (this.capture != null)
            {
                this.capture.Stop();
                this.capture.Dispose();
                this.writer.Dispose();
            }
                        
            return true;
        }

        public void PlayAudio(string file)
        {
            MciSendString("play " + file, null, 0, 0);
        }

        [DllImport("winmm.dll")]
        private static extern int MciSendString(string mciComando, string mciRetorno, int mciRetornoLeng, int callBack);
    }
}
