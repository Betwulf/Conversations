using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Audio;

namespace ConversationsCore.Services
{
    public class AudioControllerWavefile : IAudioControllerService
    {
        protected IRecordAudioService RecordAudio { get; set; }
        public SampleAggregator AudioSampler { get; set; }
        bool IsRecording { get; set; }
        bool StartedTalking { get; set; }
        bool StartedSilence { get; set; }
        DateTime SilenceStartTime { get; set; }


        public event EventHandler<float> AudioLevelEvent = delegate { };
        public event EventHandler<bool> FinishedRecordingEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<AudioBuffer> PartialRecordingEvent = delegate { };
        public event EventHandler<int> StartedRecordingEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> AudioControllerErrorEvent = delegate { };


        public AudioControllerWavefile(string aFilename)
        {
            RecordAudio = new RecordAudioButReallyReadFromAWavefile(aFilename);
            RecordAudio.FinishedRecordingEvent += OnRecordStop;
            RecordAudio.StartedRecordingEvent += OnRecordStart;
            RecordAudio.PartialRecordingEvent += RecordAudio_PartialRecordingEvent;
            RecordAudio.RecordAudioErrorEvent += OnAudioError;
            RecordAudio.MessageEvent += RecordAudio_MessageEvent;
            AudioSampler = new SampleAggregator(RecordAudio);
            AudioSampler.SampleEvent += OnSampleEvent;
            StartedTalking = false;
        }

        private void RecordAudio_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void RecordAudio_PartialRecordingEvent(object sender, AudioBuffer e)
        {
            PartialRecordingEvent(this, e);
        }

        private void OnAudioError(object sender, ConversationsErrorArgs e)
        {
            StopRecording();
            AudioControllerErrorEvent(this, e);
        }

        /// <summary>
        /// This code TRIES to figure out when the speaker starts and stops talking, and 
        /// turns the microphone off when it thinks talking has stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSampleEvent(object sender, MaxSampleEventArgs e)
        {
            AudioLevelEvent(this, e.MaxSample);
            if (StartedTalking && e.MaxSample < 0.1)
            {
                if (!StartedSilence)
                {
                    StartedSilence = true;
                    MessageEvent(this, "AudioController - StartedSilence");
                    SilenceStartTime = DateTime.Now;
                }
                else
                {
                    MessageEvent(this, "AudioController - Continued Silence");
                    var TimeSpanOfSilence = DateTime.Now - SilenceStartTime;
                    if (TimeSpanOfSilence.TotalSeconds > 0.3)
                    {
                        MessageEvent(this, "AudioController - StopRecordingAudioAsync");
                        RecordAudio.StopRecordingAudioAsync();
                    }
                }
            }
            if (!StartedTalking && e.MaxSample > 0.5)
            {
                MessageEvent(this, "AudioController - StartedTalking");
                StartedTalking = true;
                StartedSilence = false;
            }
        }

        void OnRecordStart(object sender, int e)
        {
            StartedTalking = false;
            IsRecording = true;
        }

        void OnRecordStop(object sender, bool e)
        {
            FinishedRecordingEvent(sender, e);
            StartedTalking = false;
            IsRecording = false;
        }

        public void StartRecording()
        {
            RecordAudio.StartRecordingAudioAsync();
        }

        public void StopRecording()
        {
            RecordAudio.StopRecordingAudioAsync();
        }
    }
}
