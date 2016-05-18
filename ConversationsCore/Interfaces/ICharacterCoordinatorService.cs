using System;
using System.IO;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Coordinates all other services in order to execute a full conversation with the character
    /// </summary>
    public interface ICharacterCoordinatorService
    {
        IAudioControllerService AudioController { get; set; }

        event EventHandler<Character> ConversationStartedEvent;

        event EventHandler<Character> ConversationEndedEvent;

        event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent;

        event EventHandler<string> MessageEvent;

        bool StartConversationAsync(Character aCharacter);

        bool StopConversationAsync(Character aCharacter);

    }
}
