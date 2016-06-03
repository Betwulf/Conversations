using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Repository;

namespace ConversationsCore.Services
{
    /// <summary>
    /// Coordinates all other services in order to execute a full conversation with the character
    /// </summary>
    public class CharacterCoordinatorBasic : ICharacterCoordinatorService
    {
        public IInputControllerService InputController { get; set; }
        public IResponseFinderService ResponseFinder { get; set; }
        public IOutputTextToSpeechService TextToSpeech { get; set; }

        public ConversationsRepository Rep { get; set; }
        public Character CurrentCharacter { get; set; }

        public event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent = delegate { };
        public event EventHandler<Character> ConversationEndedEvent = delegate { };
        public event EventHandler<Character> ConversationStartedEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        public CharacterCoordinatorBasic()
        {
        }

        public bool StartConversationAsync(ConversationsRepository aRep, Character aCharacter)
        {
            Rep = aRep;
            if (InputController == null) InputController = new InputControllerBasic();
            ResponseFinder = new ResponseFinderBasic();
            TextToSpeech = new OutputTextToTextBasic();

            CurrentCharacter = aCharacter;
            // Start with the first state - should be default
            if (CurrentCharacter.CurrentState == null)
            {
                CurrentCharacter.CurrentState = CurrentCharacter.StateList.First();
            }
            InputController.InputControllerCompletedEvent += InputController_InputControllerCompletedEvent;
            InputController.MessageEvent += InputController_MessageEvent;
            InputController.InputControllerErrorEvent += InputController_InputControllerErrorEvent;
            ResponseFinder.ResponseFoundEvent += ResponseFinder_ResponseFoundEvent;
            ResponseFinder.ResponseFinderErrorEvent += ResponseFinder_ResponseFinderErrorEvent;
            ResponseFinder.MessageEvent += ResponseFinder_MessageEvent;
            TextToSpeech.TextToSpeechErrorEvent += TextToSpeech_TextToSpeechErrorEvent;
            TextToSpeech.TextToSpeechPlayCompleteEvent += TextToSpeech_TextToSpeechPlayCompleteEvent;
            TextToSpeech.MessageEvent += TextToSpeech_MessageEvent;

            InputController.StartGettingInput(Rep, CurrentCharacter, null);
            return true;
        }

        private void InputController_InputControllerErrorEvent(object sender, ConversationsErrorArgs e)
        {
            MessageEvent(this, $"InputControllerErrorEvent: {e.theException.Message}");
        }

        private void InputController_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void InputController_InputControllerCompletedEvent(object sender, string e)
        {
            MessageEvent(this, e);
            ResponseFinder.StartProcessingIntentAsync(e, CurrentCharacter);
        }

        private void TextToSpeech_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void TextToSpeech_TextToSpeechPlayCompleteEvent(object sender, Character e)
        {
            MessageEvent(this, "TextToSpeechPlayCompleteEvent");
            InputController.StartGettingInput(Rep, CurrentCharacter, null);
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

        private void ResponseFinder_ResponseFoundEvent(object sender, IntentResponse e)
        {
            MessageEvent(this, $"ResponseFoundEvent: {e.Id}");
            TextToSpeech.StartPlayingResponseAudioAsync(Rep, e, CurrentCharacter);
        }



        


        public bool StopConversationAsync(Character aCharacter)
        {
            MessageEvent(this, "CharacterCoordinatorBasic - StopConversation");
            InputController.InputControllerCompletedEvent -= InputController_InputControllerCompletedEvent;
            InputController.MessageEvent -= InputController_MessageEvent;
            InputController.InputControllerErrorEvent -= InputController_InputControllerErrorEvent;
            ResponseFinder.ResponseFoundEvent -= ResponseFinder_ResponseFoundEvent;
            ResponseFinder.ResponseFinderErrorEvent -= ResponseFinder_ResponseFinderErrorEvent;
            ResponseFinder.MessageEvent -= ResponseFinder_MessageEvent;
            TextToSpeech.TextToSpeechErrorEvent -= TextToSpeech_TextToSpeechErrorEvent;
            TextToSpeech.TextToSpeechPlayCompleteEvent -= TextToSpeech_TextToSpeechPlayCompleteEvent;
            TextToSpeech.MessageEvent -= TextToSpeech_MessageEvent;
            
            return true;
        }

        public void Dispose()
        {
            if (InputController != null)
            {
                InputController.Dispose();
                InputController = null;
            }
        }
    }
}
