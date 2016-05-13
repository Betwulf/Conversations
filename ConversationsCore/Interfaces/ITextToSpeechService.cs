using System;
using Microsoft.ProjectOxford.SpeechRecognition;
using System.IO;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Interfaces
{
    public interface ITextToSpeechService
    {
        event EventHandler<Character> TextToSpeechPlayCompleteEvent;

        event EventHandler<ConversationsErrorArgs> TextToSpeechErrorEvent;

        bool StartPlayingResponseAudioAsync(Response aResponse, Character aCharacter);

    }
}
