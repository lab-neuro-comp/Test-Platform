namespace TestPlatform.Models
{
    using System.Runtime.InteropServices;
    using CSCore.Codecs.WAV;
    using CSCore.SoundIn;
    using CSCore.CoreAudioAPI;
    using System;
    using System.Globalization;
    using System.Windows.Forms;
    using CSCore.Win32;
    using CSCore;
    using System.Collections.Generic;
    using System.Resources;

    public class Audio
    {
        private WasapiCapture capture;
        private WaveWriter writer;
        private const CaptureMode CaptureMode = Models.CaptureMode.Capture;

        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public bool StartRecording(string path)
        {
            if (isDeviceAvailable())
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
            else
            {
                throw new Exception(LocRM.GetString("audioDeviceNotAvailable",currentCulture));
            }
        }

        public bool PauseRecording()
        {
            this.capture.Stop();
            return true;
        }

        public bool SaveRecording()
        {
            if (this.capture != null && this.capture.RecordingState == RecordingState.Recording)
            {
                this.capture.Stop();
                this.capture.Dispose();
                this.writer.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlayAudio(string file)
        {
            MciSendString("play " + file, null, 0, 0);
        }

        private bool isDeviceAvailable()
        {
            List<object> deviceList = new List<object>();
            using (var deviceEnumerator = new MMDeviceEnumerator())
            using (var deviceCollection = deviceEnumerator.EnumAudioEndpoints(
                CaptureMode == CaptureMode.Capture ? DataFlow.Capture : DataFlow.Render, DeviceState.Active))
            {
                foreach (var device in deviceCollection)
                {
                    var deviceFormat = WaveFormatFromBlob(device.PropertyStore[
                        new PropertyKey(new Guid(0xf19f064d, 0x82c, 0x4e27, 0xbc, 0x73, 0x68, 0x82, 0xa1, 0xbb, 0x8e, 0x4c), 0)].BlobValue);

                    var item = new ListViewItem(device.FriendlyName) { Tag = device };
                    item.SubItems.Add(deviceFormat.Channels.ToString(CultureInfo.InvariantCulture));

                    deviceList.Add(item);
                }
            }
            if (deviceList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static WaveFormat WaveFormatFromBlob(Blob blob)
        {
            if (blob.Length == 40)
                return (WaveFormat)Marshal.PtrToStructure(blob.Data, typeof(WaveFormatExtensible));
            return (WaveFormat)Marshal.PtrToStructure(blob.Data, typeof(WaveFormat));
        }



        [DllImport("winmm.dll")]
        private static extern int MciSendString(string mciComando, string mciRetorno, int mciRetornoLeng, int callBack);

    
    }
    public enum CaptureMode
    {
        Capture,
        LoopbackCapture
    }
}
