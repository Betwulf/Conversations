using System;
using Microsoft.ProjectOxford.SpeechRecognition;
using System.IO;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Interfaces
{
    public interface ICharacterCoordinatorService
    {
        event EventHandler<Character> ConversationStartedEvent;

        event EventHandler<Character> ConversationEndedEvent;

        event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent;

        bool StartConversationAsync(Character aCharacter);

    }
}
