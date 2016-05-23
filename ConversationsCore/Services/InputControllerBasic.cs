using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Audio;
using ConversationsCore.Repository;

namespace ConversationsCore.Services
{
    public class InputControllerBasic : IInputControllerService
    {
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<string> InputControllerCompletedEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> InputControllerErrorEvent = delegate { };

        IAudioControllerService AudioController;
        IInputSpeechToTextService SpeechToText;
        Character TheCharacter;
        ConversationsRepository Rep;

        
        private void SpeechToText_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void SpeechToText_SpeechToTextErrorEvent(object sender, ConversationsErrorArgs e)
        {
            InputControllerErrorEvent(this, e);
        }

        private void SpeechToText_SpeechToTextCompletedEvent(object sender, string e)
        {
            InputControllerCompletedEvent(this, e);
        }

        private void AudioController_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void RecordAudio_StartedRecordingEvent(object sender, int e)
        {
            throw new NotImplementedException();
        }

        private void RecordAudio_FinishedRecordingEvent(object sender, Exception e)
        {
            MessageEvent(this, "InputController - OnFinishedRecordingEvent");
            SpeechToText.FinishedProcessing();
        }

        private void RecordAudio_RecordAudioErrorEvent(object sender, ConversationsErrorArgs e)
        {
            throw new NotImplementedException();
        }

        private void RecordAudio_PartialRecordingEvent(object sender, AudioBuffer e)
        {
            SpeechToText.MoreAudio(e);
        }

        private void RecordAudio_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        public void StartGettingInput(ConversationsRepository aRep, Character aCharacter)
        {
            // Save params
            TheCharacter = aCharacter;
            Rep = aRep;

            // New only one AudioController
            if (AudioController == null) AudioController = new AudioControllerWavefile("test.wav");
            SpeechToText = new InputSpeechToTextBasic();

            AudioController.RecordAudio.MessageEvent += RecordAudio_MessageEvent;
            AudioController.RecordAudio.PartialRecordingEvent += RecordAudio_PartialRecordingEvent;
            AudioController.RecordAudio.RecordAudioErrorEvent += RecordAudio_RecordAudioErrorEvent;
            AudioController.RecordAudio.FinishedRecordingEvent += RecordAudio_FinishedRecordingEvent;
            AudioController.RecordAudio.StartedRecordingEvent += RecordAudio_StartedRecordingEvent;
            AudioController.MessageEvent += AudioController_MessageEvent;
            SpeechToText.SpeechToTextCompletedEvent += SpeechToText_SpeechToTextCompletedEvent;
            SpeechToText.SpeechToTextErrorEvent += SpeechToText_SpeechToTextErrorEvent;
            SpeechToText.MessageEvent += SpeechToText_MessageEvent;

            // GO
            AudioController.StartRecording();

        }
    }
}
