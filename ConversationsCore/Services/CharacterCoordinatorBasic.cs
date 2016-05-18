using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;

namespace ConversationsCore.Services
{
    /// <summary>
    /// Coordinates all other services in order to execute a full conversation with the character
    /// </summary>
    public class CharacterCoordinatorBasic : ICharacterCoordinatorService
    {
        public IAudioControllerService AudioController { get; set; }
        public ISpeechToTextService SpeechToText { get; set; }
        public Character CurrentCharacter { get; set; }

        public event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent = delegate { };
        public event EventHandler<Character> ConversationEndedEvent = delegate { };
        public event EventHandler<Character> ConversationStartedEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        public CharacterCoordinatorBasic()
        {
            AudioController = new AudioController();
            SpeechToText = new SpeechToTextBasic();
        }

        public bool StartConversationAsync(Character aCharacter)
        {
            CurrentCharacter = aCharacter;
            // Start with the first state - should be default
            if (CurrentCharacter.CurrentState == null)
            {
                CurrentCharacter.CurrentState = CurrentCharacter.StateList.First();
            }
            AudioController.RecordAudio.MessageEvent += RecordAudio_MessageEvent;
            AudioController.RecordAudio.PartialRecordingEvent += OnPartialRecordingEvent;
            AudioController.RecordAudio.RecordAudioErrorEvent += OnErrorEvent;
            AudioController.RecordAudio.FinishedRecordingEvent += OnFinishedRecordingEvent;
            AudioController.MessageEvent += AudioController_MessageEvent;
            SpeechToText.SpeechToTextCompletedEvent += OnSpeechToTextEvent;
            SpeechToText.SpeechToTextErrorEvent += SpeechToTextErrorEvent;
            SpeechToText.MessageEvent += SpeechToText_MessageEvent;
            SpeechToText.StartProcessingAudioAsync(aCharacter);
            AudioController.StartRecording();
            return true;
        }

        private void RecordAudio_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void AudioController_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void SpeechToText_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void OnSpeechToTextEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void SpeechToTextErrorEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void OnFinishedRecordingEvent(object sender, Exception e)
        {
            MessageEvent(this, "CharacterCoordinatorBasic - OnFinishedRecordingEvent");
            SpeechToText.FinishedProcessing();
        }

        private void OnErrorEvent(object sender, ConversationsErrorArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnPartialRecordingEvent(object sender, AudioBuffer e)
        {
            MessageEvent(this, "CharacterCoordinatorBasic - OnPartialRecordingEvent");
            SpeechToText.MoreAudio(e);
        }

        public bool StopConversationAsync(Character aCharacter)
        {
            MessageEvent(this, "CharacterCoordinatorBasic - StopConversation");
            AudioController.StopRecording();
            return true;
        }
    }
}
