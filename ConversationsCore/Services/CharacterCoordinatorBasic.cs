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
        public IResponseFinderService ResponseFinder { get; set; }
        public ITextToSpeechService TextToSpeech { get; set; }

        public Character CurrentCharacter { get; set; }

        public event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent = delegate { };
        public event EventHandler<Character> ConversationEndedEvent = delegate { };
        public event EventHandler<Character> ConversationStartedEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        public CharacterCoordinatorBasic()
        {
        }

        public bool StartConversationAsync(Character aCharacter)
        {
            if (AudioController == null) AudioController = new AudioControllerWavefile("test.wav");
            SpeechToText = new SpeechToTextBasic();
            ResponseFinder = new ResponseFinderBasic();
            TextToSpeech = new TextToSpeechBasic();

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
            AudioController.RecordAudio.StartedRecordingEvent += OnStartedRecordingEvent;
            AudioController.MessageEvent += AudioController_MessageEvent;
            SpeechToText.SpeechToTextCompletedEvent += OnSpeechToTextEvent;
            SpeechToText.SpeechToTextErrorEvent += SpeechToTextErrorEvent;
            SpeechToText.MessageEvent += SpeechToText_MessageEvent;
            ResponseFinder.ResponseFoundEvent += ResponseFinder_ResponseFoundEvent;
            ResponseFinder.ResponseFinderErrorEvent += ResponseFinder_ResponseFinderErrorEvent;
            ResponseFinder.MessageEvent += ResponseFinder_MessageEvent;
            TextToSpeech.TextToSpeechErrorEvent += TextToSpeech_TextToSpeechErrorEvent;
            TextToSpeech.TextToSpeechPlayCompleteEvent += TextToSpeech_TextToSpeechPlayCompleteEvent;


            AudioController.StartRecording();
            return true;
        }


        private void TextToSpeech_TextToSpeechPlayCompleteEvent(object sender, Character e)
        {
            MessageEvent(this, "TextToSpeechPlayCompleteEvent");
            AudioController.StartRecording();
        }

        private void TextToSpeech_TextToSpeechErrorEvent(object sender, ConversationsErrorArgs e)
        {
            MessageEvent(this, $"TextToSpeechErrorEvent: {e.theException.Message}");
        }

        private void ResponseFinder_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void ResponseFinder_ResponseFinderErrorEvent(object sender, Exception e)
        {
            MessageEvent(this, $"ResponseFinderErrorEvent: {e.Message}");
        }

        private void ResponseFinder_ResponseFoundEvent(object sender, string e)
        {
            MessageEvent(this, e);
            TextToSpeech.StartPlayingResponseAudioAsync(e, CurrentCharacter);
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
            ResponseFinder.StartProcessingIntentAsync(e, CurrentCharacter);
        }

        private void SpeechToTextErrorEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }


        private void OnStartedRecordingEvent(object sender, int e)
        {
            SpeechToText.StartProcessingAudioAsync(CurrentCharacter);
        }

        private void OnFinishedRecordingEvent(object sender, Exception e)
        {
            MessageEvent(this, "CharacterCoordinatorBasic - OnFinishedRecordingEvent");
            SpeechToText.FinishedProcessing();
        }

        private void OnErrorEvent(object sender, ConversationsErrorArgs e)
        {
            MessageEvent(this, e.theException.Message);
        }

        private void OnPartialRecordingEvent(object sender, AudioBuffer e)
        {
            SpeechToText.MoreAudio(e);
        }

        public bool StopConversationAsync(Character aCharacter)
        {
            MessageEvent(this, "CharacterCoordinatorBasic - StopConversation");
            AudioController.RecordAudio.MessageEvent -= RecordAudio_MessageEvent;
            AudioController.RecordAudio.PartialRecordingEvent -= OnPartialRecordingEvent;
            AudioController.RecordAudio.RecordAudioErrorEvent -= OnErrorEvent;
            AudioController.RecordAudio.FinishedRecordingEvent -= OnFinishedRecordingEvent;
            AudioController.MessageEvent -= AudioController_MessageEvent;
            SpeechToText.SpeechToTextCompletedEvent -= OnSpeechToTextEvent;
            SpeechToText.SpeechToTextErrorEvent -= SpeechToTextErrorEvent;
            SpeechToText.MessageEvent -= SpeechToText_MessageEvent;
            ResponseFinder.ResponseFoundEvent -= ResponseFinder_ResponseFoundEvent;
            ResponseFinder.ResponseFinderErrorEvent -= ResponseFinder_ResponseFinderErrorEvent;
            ResponseFinder.MessageEvent -= ResponseFinder_MessageEvent;
            TextToSpeech.TextToSpeechErrorEvent -= TextToSpeech_TextToSpeechErrorEvent;
            TextToSpeech.TextToSpeechPlayCompleteEvent -= TextToSpeech_TextToSpeechPlayCompleteEvent;
            AudioController.StopRecording();
            SpeechToText.Dispose();
            // ResponseFinder.STOP TODO: Make stops? Do we need to?
            return true;
        }

        public void Dispose()
        {
            SpeechToText.Dispose();
        }
    }
}
