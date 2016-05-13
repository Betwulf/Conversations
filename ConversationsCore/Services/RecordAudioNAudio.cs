using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using NAudio;
using NAudio.Wave;

namespace ConversationsCore.Services
{
    public class RecordAudioNAudio : IRecordAudioService
    {
        public event EventHandler<Stream> FinishedRecordingEvent;
        public event EventHandler<ConversationsErrorArgs> RecordAudioErrorEvent;
        public event EventHandler<Stream> StartedRecordingEvent;

        WaveIn waveSource = null;
        WaveFileWriter waveFile = null;


        public bool StartRecordingAudioAsync(Character aCharacter)
        {
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(OnDataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(OnRecordingStopped);
            waveFile = new WaveFileWriter(@"C:\Temp\Test0001.wav", waveSource.WaveFormat);

            waveSource.StartRecording();

            return true;
        }


        private void OnDataAvailable(object sender, WaveInEventArgs args)
        {
            if (waveFile != null)
            {
                waveFile.Write(args.Buffer, 0, args.BytesRecorded);
                waveFile.Flush();
            }

        }


        private void OnRecordingStopped(object sender, StoppedEventArgs args)
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
