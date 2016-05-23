using System;
using System.IO;
using ConversationsCore.DataObjects;
using Microsoft.ProjectOxford.SpeechRecognition;

namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Listens to the streamed audio output and real-time directs to Speech Recognition + LUIS
    /// </summary>
    public interface IInputSpeechToTextService : IDisposable
    {
        event EventHandler<string> SpeechToTextCompletedEvent;
        event EventHandler<ConversationsErrorArgs> SpeechToTextErrorEvent;
        event EventHandler<string> MessageEvent;

        bool StartProcessingAudioAsync(Character aCharacter);

        void MoreAudio(AudioBuffer aBuffer);
        void FinishedProcessing();
    }
}
