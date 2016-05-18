/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using NAudio.Wave;

namespace StroopTest
{
    class AudioRecorder
    {
        private WaveIn waveSource = null;
        public WaveFileWriter waveFile = null;
        private string path;
        private string user;
        private string program;

        public AudioRecorder(string usrName, string prgName, string dataFolderPath)
        {
            path = dataFolderPath;
            user = usrName;
            program = prgName;

            startRecordingAudio();
        }

        public void startRecordingAudio()
        {
            string now = DateTime.Now.ToString("h:mm:ss");
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);
            waveFile = new WaveFileWriter(path + "/audio_" + user + "_" + program + "_" + now + ".wav", waveSource.WaveFormat);
            waveSource.StartRecording();
        }

        public void stopRecordingAudio()
        {
            waveSource.StopRecording();
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }
            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }
        
    }
}
