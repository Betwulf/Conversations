using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.Interfaces;
using NAudio;
using NAudio.Wave;
using NAudio.Mixer;
using ConversationsCore.Audio;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Audio
{
    /// <summary>
    /// As you might expect, this saves wave files.
    /// </summary>
    public class WavefileSaver
    {

        WaveFileWriter writer;
        WaveFormat RecordingFormat { get; set; }

        public event EventHandler<string> MessageEvent = delegate { };



        public WavefileSaver(IRecordAudioService recorder, string aFilename)
        {
            RecordingFormat = new WaveFormat(recorder.RecordingFrequency, 1);
            writer = new WaveFileWriter(aFilename, RecordingFormat);
            recorder.PartialRecordingEvent += OnDataAvailable;
            recorder.FinishedRecordingEvent += OnFinishedRecording;
        }

        private void OnFinishedRecording(object sender, Exception e)
        {
            MessageEvent(this, "WavefileSaver.OnFinishedRecording");
            writer.Close();
            writer.Dispose();

        }

        public void OnDataAvailable(object sender, AudioBuffer buffer)
        {
            MessageEvent(this, $"WavefileSaver.OnDataAvailable: {buffer.BufferSize}");
            long maxFileLength = this.RecordingFormat.AverageBytesPerSecond * 60; // capped at 60 seconds

            var toWrite = (int)Math.Min(maxFileLength - writer.Length, buffer.BufferSize);
            if (toWrite > 0)
            {
                writer.Write(buffer.Buffer, 0, buffer.BufferSize);
            }
        }
    }
}

