using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using Microsoft.ProjectOxford.SpeechRecognition;

namespace ConversationsCore.Services
{
    public class SpeechToTextBasic : ISpeechToTextService
    {
        public event EventHandler<Meaning> SpeechToTextCompletedEvent;
        public event EventHandler<SpeechErrorEventArgs> SpeechToTextErrorEvent;

        public bool StartProcessingAudioAsync(Stream audioStream, Character aCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
