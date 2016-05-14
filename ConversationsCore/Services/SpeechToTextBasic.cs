﻿using System;
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
        public event EventHandler<Meaning> SpeechToTextCompletedEvent;
        public event EventHandler<string> SpeechToTextErrorEvent;

        public bool StartProcessingAudioAsync(Stream audioStream, Character aCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
