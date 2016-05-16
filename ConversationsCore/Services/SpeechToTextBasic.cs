using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;

namespace ConversationsCore.Services
{
    public class SpeechToTextBasic : ISpeechToTextService
    {
        // The Payload property of the SpeechIntentEventArgs class
        public event EventHandler<string> SpeechToTextCompletedEvent = delegate { };
        public event EventHandler<string> SpeechToTextErrorEvent = delegate { };

        public void OnMoreAudio(byte[] aBuffer)
        {
            throw new NotImplementedException();
        }

        public bool StartProcessingAudioAsync(Character aCharacter)
        {
            throw new NotImplementedException();
        }


    }
}
