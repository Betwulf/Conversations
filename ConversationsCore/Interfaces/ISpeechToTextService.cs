using System;
using Microsoft.ProjectOxford.SpeechRecognition;
using System.IO;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Interfaces
{
    public interface ISpeechToTextService
    {
        event EventHandler<Meaning> SpeechToTextCompletedEvent;

        event EventHandler<SpeechErrorEventArgs> SpeechToTextErrorEvent;

        bool StartProcessingAudioAsync(Stream audioStream, Character aCharacter);
    }
}
