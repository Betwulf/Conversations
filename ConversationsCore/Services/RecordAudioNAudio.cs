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
        double desiredVolume = 100;
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
                throw new InvalidOperationException("Can't begin monitoring while we are in this state: " + recordingState.ToString());
            }
            waveIn = new WaveIn();
            waveIn.DeviceNumber = recordingDevice;
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;
            waveIn.WaveFormat = recordingFormat;
            waveIn.StartRecording();
            TryGetVolumeControl();
            IsRecording = true;
        }

        public bool StopRecordingAudioAsync()
        {
            return true;
        }
        
    }
}
