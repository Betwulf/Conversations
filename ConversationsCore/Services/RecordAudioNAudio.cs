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
        public event EventHandler<bool> FinishedRecordingEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> RecordAudioErrorEvent = delegate { };
        public event EventHandler<int> StartedRecordingEvent = delegate { };
        public event EventHandler<AudioBuffer> PartialRecordingEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        WaveIn waveIn;
        UnsignedMixerControl volumeControl;
        double MicrophoneLevel = 100;

        public bool IsRecording { get; set; }
        public WaveFormat RecordingFormat { get; set; }

        public int RecordingFrequency { get { return RecordingFormat.SampleRate; } }


        public RecordAudioNAudio(int sampleRate = 44100, int channels = 1)
        {
            RecordingFormat = new WaveFormat(sampleRate, channels);
        }


        public bool StartRecordingAudioAsync()
        {
            if (IsRecording)
            {
                throw new InvalidOperationException("FAIL - Already recording");
            }
            
            if (WaveIn.DeviceCount < 1)
            {
                throw new InvalidOperationException("Cant find a device...");
            }
            MessageEvent(this, $"DeviceCount: {WaveIn.DeviceCount}");
            MessageEvent(this, $"Audio Device: {WaveIn.GetCapabilities(0).ProductName}");
            waveIn = new WaveIn();
            waveIn.WaveFormat = RecordingFormat;
            waveIn.DeviceNumber = 0;
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;
            waveIn.StartRecording();
            TryGetVolumeControl();
            IsRecording = true;
            StartedRecordingEvent(this, RecordingFormat.SampleRate);
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


        /// <summary>
        /// TODO: What does this do exactly? :) 
        /// </summary>
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
            //MessageEvent(this, $"OnDataAvailable: {e.BytesRecorded} - IsRecording: {IsRecording}");
            if (e.BytesRecorded == 0) { StopRecordingAudioAsync(); }
            var abuffer = new AudioBuffer() { Buffer = e.Buffer, BufferSize = e.BytesRecorded };
            PartialRecordingEvent(this, abuffer);
        }
        



        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            IsRecording = false;
            if (e.Exception == null)
            {
                FinishedRecordingEvent(this, true);
            }
            else
            {
                RecordAudioErrorEvent(this, new ConversationsErrorArgs(e.Exception, null, "OnRecordingStopped"));
                FinishedRecordingEvent(this, false);
            }
        }


    }
}
