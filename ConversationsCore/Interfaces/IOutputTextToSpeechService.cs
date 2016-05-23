using System;
using System.IO;
using ConversationsCore.DataObjects;
using ConversationsCore.Repository;

namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Resopnsible for playing the character's audio responses
    /// </summary>
    public interface IOutputTextToSpeechService
    {
        event EventHandler<Character> TextToSpeechPlayCompleteEvent;
        event EventHandler<string> MessageEvent;
        event EventHandler<ConversationsErrorArgs> TextToSpeechErrorEvent;

        bool StartPlayingResponseAudioAsync(ConversationsRepository Rep, IntentResponse aResponse, Character aCharacter);

    }
}
