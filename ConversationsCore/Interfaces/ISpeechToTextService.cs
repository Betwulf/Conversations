using System;
using System.IO;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Interfaces
{
    public interface ISpeechToTextService
    {
        event EventHandler<string> SpeechToTextCompletedEvent;

        event EventHandler<string> SpeechToTextErrorEvent;

        bool StartProcessingAudioAsync(Character aCharacter);

        void OnMoreAudio(byte[] aBuffer);
    }
}
