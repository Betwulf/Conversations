using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Repository;
using System;
using System.Reflection;
using System.Threading;

namespace ConversationsCore.Services
{
    public class OutputTextToTextBasic : IOutputTextToSpeechService
    {
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> TextToSpeechErrorEvent = delegate { };
        public event EventHandler<Character> TextToSpeechPlayCompleteEvent = delegate { };

        public bool StartPlayingResponseAudioAsync(ConversationsRepository Rep, IntentResponse aResponse, Character aCharacter)
        {
            try
            {
                Thread.Sleep(2000);
                MessageEvent(this, $"Text Response: {aResponse.ResponseText}");
                TextToSpeechPlayCompleteEvent(this, aCharacter);
            }
            catch (Exception ex)
            {
                TextToSpeechErrorEvent(this, new ConversationsErrorArgs(ex, aCharacter, MethodBase.GetCurrentMethod().Name));
            }
            return true;
        }
    }
}
