using System;
using Microsoft.ProjectOxford.SpeechRecognition;
using System.IO;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Interfaces
{
    public interface ICharacterCoordinatorService
    {
        IAudioControllerService AudioController { get; set; }

        event EventHandler<Character> ConversationStartedEvent;

        event EventHandler<Character> ConversationEndedEvent;

        event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent;

        bool StartConversationAsync(Character aCharacter);

    }
}
