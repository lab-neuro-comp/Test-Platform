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
        private WaveIn waveSource = null; // entrada de áudio
        public WaveFileWriter waveFile = null; // arquivo salvar áudio
        private string path;
        private string user;
        private string program;
        
        private void startRecordingAudio(StroopProgram program)
        {
            int waveInDevices = WaveIn.DeviceCount;
            if (waveInDevices != 0)
            {
                string now = program.InitialDate.Day + "." + program.InitialDate.Month + "_" + DateTime.Now.Hour.ToString() + "h" + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString();

                waveSource = new WaveIn();
                waveSource.WaveFormat = new WaveFormat(44100, 1);

                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

                waveFile = new WaveFileWriter(path + "/data" + "/audio_" + program.UserName + "_" + program.ProgramName + "_" + now + ".wav", waveSource.WaveFormat);

                waveSource.StartRecording();
            }
        } // inicia gravação de áudio

        private void stopRecordingAudio()
        {
            waveSource.StopRecording();
        } // para gravação de áudio

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
