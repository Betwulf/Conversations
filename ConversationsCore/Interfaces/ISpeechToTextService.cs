using System;
using System.IO;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Interfaces
{
    public interface ISpeechToTextService
    {
        event EventHandler<Meaning> SpeechToTextCompletedEvent;

        event EventHandler<string> SpeechToTextErrorEvent;

        bool StartProcessingAudioAsync(Stream audioStream, Character aCharacter);
    }
}
