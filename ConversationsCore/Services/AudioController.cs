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
    public class AudioController : IAudioControllerService
    {
        protected IRecordAudioService RecordAudio { get; set; }
        public SampleAggregator AudioSampler { get; set; }
        bool IsRecording { get; set; }
        bool StartedTalking { get; set; }
        bool StartedSilence { get; set; }
        DateTime SilenceStartTime { get; set; }


        public event EventHandler<float> AudioLevelEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<int> StartedRecordingEvent = delegate { };
        public event EventHandler<AudioBuffer> PartialRecordingEvent = delegate { };
        public event EventHandler<bool> FinishedRecordingEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> AudioControllerErrorEvent = delegate { };

        public AudioController()    
        {
            RecordAudio = new RecordAudioNAudio();

            RecordAudio.MessageEvent += RecordAudio_MessageEvent;
            RecordAudio.PartialRecordingEvent += RecordAudio_PartialRecordingEvent;
            RecordAudio.RecordAudioErrorEvent += RecordAudio_RecordAudioErrorEvent;
            RecordAudio.FinishedRecordingEvent += RecordAudio_FinishedRecordingEvent;
            RecordAudio.StartedRecordingEvent += RecordAudio_StartedRecordingEvent;

            AudioSampler = new SampleAggregator(RecordAudio);
            AudioSampler.SampleEvent += OnSampleEvent;
            StartedTalking = false;
        }

        private void RecordAudio_StartedRecordingEvent(object sender, int e)
        {
            StartedTalking = false;
            IsRecording = true;
        }

        private void RecordAudio_RecordAudioErrorEvent(object sender, ConversationsErrorArgs e)
        {
            StopRecording();
            AudioControllerErrorEvent(this, e);
        }

        private void RecordAudio_PartialRecordingEvent(object sender, AudioBuffer e)
        {
            PartialRecordingEvent(this, e);
        }

        private void RecordAudio_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
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
            else
            {
                MessageEvent(this, "AudioController - Waiting for talking...");
            }
        }


         void RecordAudio_FinishedRecordingEvent(object sender, bool e)
        {
            StartedTalking = false;
            IsRecording = false;
            FinishedRecordingEvent(sender, e);
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
