using System;
using System.IO;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Interfaces
{
    public interface ITextToSpeechService
    {
        event EventHandler<Character> TextToSpeechPlayCompleteEvent;

        event EventHandler<ConversationsErrorArgs> TextToSpeechErrorEvent;

        bool StartPlayingResponseAudioAsync(string aWaveFilename, Character aCharacter);

    }
}
