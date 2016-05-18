using System;
using System.IO;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Listens to the streamed audio output and real-time directs to Speech Recognition + LUIS
    /// </summary>
    public interface ISpeechToTextService
    {
        event EventHandler<string> SpeechToTextCompletedEvent;
        event EventHandler<string> SpeechToTextErrorEvent;
        event EventHandler<string> MessageEvent;

        bool StartProcessingAudioAsync(Character aCharacter);

        void MoreAudio(AudioBuffer aBuffer);
        void FinishedProcessing();
    }
}
