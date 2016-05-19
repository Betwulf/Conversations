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
        public IRecordAudioService RecordAudio { get; set; }
        public SampleAggregator AudioSampler { get; set; }
        bool IsRecording { get; set; }
        bool StartedTalking { get; set; }
        bool StartedSilence { get; set; }
        DateTime SilenceStartTime { get; set; }


        public event EventHandler<float> AudioLevelEvent = delegate { };
        public event EventHandler<Exception> CompletedEvent = delegate { };
        public event EventHandler<bool> RecordOnEvent = delegate { };
        public event EventHandler<bool> RecordOffEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        public AudioControllerWavefile(string aFilename)
        {
            RecordAudio = new RecordAudioButReallyReadFromAWavefile(aFilename);
            RecordAudio.FinishedRecordingEvent += OnRecordStop;
            RecordAudio.StartedRecordingEvent += OnRecordStart;
            //RecordAudio.PartialRecordingEvent += OnRecordingData;
            RecordAudio.RecordAudioErrorEvent += OnAudioError;
            //RecordAudio.MessageEvent += OnMessage;
            AudioSampler = new SampleAggregator(RecordAudio);
            AudioSampler.SampleEvent += OnSampleEvent;
            StartedTalking = false;
        }

        private void OnAudioError(object sender, ConversationsErrorArgs e)
        {
            StopRecording();
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

        void OnRecordStop(object sender, Exception e)
        {
            CompletedEvent(sender, e);
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
