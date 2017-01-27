
using System.Runtime.InteropServices;

namespace StroopTest.Models
{
    class Audio
    {

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);

        public bool startRecording()
        {
            mciSendString("open new type waveaudio alias audio", null, 0, 0);
            mciSendString("record audio", null, 0, 0);
            return true;
        }
        public bool pauseRecording()
        {
            mciSendString("pause audio", null, 0, 0);
            return true;
        }
        public bool saveRecording(string path)
        {
            mciSendString("save audio " + path, null, 0, 0);
            mciSendString("close audio", null, 0, 0);
            return true;
        }
        public void playAudio(string file)
        {
            mciSendString("play " + file, null, 0, 0);
        }
    }
}
