using System;
using System.IO;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Resopnsible for playing the character's audio responses
    /// </summary>
    public interface ITextToSpeechService
    {
        event EventHandler<Character> TextToSpeechPlayCompleteEvent;

        event EventHandler<ConversationsErrorArgs> TextToSpeechErrorEvent;

        bool StartPlayingResponseAudioAsync(string aWaveFilename, Character aCharacter);

    }
}
