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
using NAudio.Mixer;
using ConversationsCore.Audio;

namespace ConversationsCore.Services
{
    public class RecordAudioNAudio : IRecordAudioService
    {
        public event EventHandler<Stream> FinishedRecordingEvent;
        public event EventHandler<ConversationsErrorArgs> RecordAudioErrorEvent;
        public event EventHandler<Stream> StartedRecordingEvent;
        public event EventHandler<Stream> PartialRecordingEvent;



        WaveIn waveIn;
        readonly SampleAggregator sampleAggregator;
        UnsignedMixerControl volumeControl;
        double MicrophoneLevel = 100;
        WaveFileWriter writer;

        public bool IsRecording { get; set; }
        public WaveFormat RecordingFormat { get; set; }

        public RecordAudioNAudio()
        {
            sampleAggregator = new SampleAggregator();
            RecordingFormat = new WaveFormat(44100, 1);
        }


        public bool StartRecordingAudioAsync()
        {
            if (IsRecording)
            {
                throw new InvalidOperationException("FAIL - Already recording");
            }
            waveIn = new WaveIn();
            
            if (WaveIn.DeviceCount < 1)
            {
                throw new InvalidOperationException("Cant find a device...");
            }
            Console.WriteLine($"Audio: {WaveIn.GetCapabilities(0).ProductName}");
            waveIn.DeviceNumber = 0;
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;
            waveIn.WaveFormat = RecordingFormat;
            waveIn.StartRecording();
            TryGetVolumeControl();
            IsRecording = true;

            return true;
        }

        public bool StopRecordingAudioAsync()
        {
            if (IsRecording)
            {
                IsRecording = false;
                waveIn.StopRecording();
            }
            return true;
        }



        private void TryGetVolumeControl()
        {
            int waveInDeviceNumber = waveIn.DeviceNumber;
            if (Environment.OSVersion.Version.Major >= 6) // Vista and over
            {
                var mixerLine = waveIn.GetMixerLine();
                //new MixerLine((IntPtr)waveInDeviceNumber, 0, MixerFlags.WaveIn);
                foreach (var control in mixerLine.Controls)
                {
                    if (control.ControlType == MixerControlType.Volume)
                    {
                        this.volumeControl = control as UnsignedMixerControl;
                        volumeControl.Percent = MicrophoneLevel;
                        break;
                    }
                }
            }
            else
            {
                var mixer = new Mixer(waveInDeviceNumber);
                foreach (var destination in mixer.Destinations
                    .Where(d => d.ComponentType == MixerLineComponentType.DestinationWaveIn))
                {
                    foreach (var source in destination.Sources
                        .Where(source => source.ComponentType == MixerLineComponentType.SourceMicrophone))
                    {
                        foreach (var control in source.Controls
                            .Where(control => control.ControlType == MixerControlType.Volume))
                        {
                            volumeControl = control as UnsignedMixerControl;
                            volumeControl.Percent = MicrophoneLevel;
                            break;
                        }
                    }
                }
            }
        }



        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] buffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;
            WriteToFile(buffer, bytesRecorded);

            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((buffer[index + 1] << 8) |
                                        buffer[index + 0]);
                float sample32 = sample / 32768f;
                sampleAggregator.Add(sample32);
            }
        }

        private void WriteToFile(byte[] buffer, int bytesRecorded)
        {
            long maxFileLength = this.RecordingFormat.AverageBytesPerSecond * 60;

            if (!IsRecording)
            {
                var toWrite = (int)Math.Min(maxFileLength - writer.Length, bytesRecorded);
                if (toWrite > 0)
                {
                    writer.Write(buffer, 0, bytesRecorded);
                }
                else
                {
                    StopRecordingAudioAsync();
                }
            }
        }



        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            IsRecording = false;
            writer.Dispose();
            FinishedRecordingEvent(this, null);
        }


    }
}
