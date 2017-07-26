
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
        
        private void selectDevice()
        {
            
            using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
            {
                using (MMDeviceCollection devices = enumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
                {
                    MMDevice device = (MMDevice)devices[0];
                    Console.WriteLine(devices[0]);
                    capture = new WasapiCapture();
                    capture.Device = device;

                    capture.Initialize();
                    
                }
            }
        }

        public bool startRecording(string path)
        {
            selectDevice();
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
            capture.Stop();
            writer.Dispose();
            return true;
        }

        public void playAudio(string file)
        {
            mciSendString("play " + file, null, 0, 0);
        }
    }
}
