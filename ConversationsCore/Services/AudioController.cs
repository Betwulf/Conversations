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
        public IRecordAudioService RecordAudio { get; set; }
        public SampleAggregator AudioSampler { get; set; }
        bool IsRecording { get; set; }


        public event EventHandler<float> AudioLevelEvent;
        public event EventHandler CompletedEvent;
        public event EventHandler<bool> RecordOnEvent;
        public event EventHandler<bool> RecordOffEvent;

        public AudioController()
        {
            RecordAudio = new RecordAudioNAudio();
            AudioSampler = new SampleAggregator(RecordAudio);
            AudioSampler.SampleEvent += OnSampleEvent;
        }

        private void OnSampleEvent(object sender, MaxSampleEventArgs e)
        {
            if (e.MaxSample < 100)
            { RecordAudio.StopRecordingAudioAsync(); }
        }

         void OnRecordStart()
        {
            IsRecording = true;
            throw new NotImplementedException();
        }

         void OnRecordStop()
        {
            IsRecording = false;
            throw new NotImplementedException();
        }

        public void StartRecording()
        {
            throw new NotImplementedException();
        }

        public void StopRecording()
        {
            throw new NotImplementedException();
        }
    }
}
