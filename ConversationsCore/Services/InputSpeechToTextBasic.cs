using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using Microsoft.ProjectOxford.SpeechRecognition;
using System.Reflection;
using ConversationsCore.Repository;

namespace ConversationsCore.Services
{
    public class InputSpeechToTextBasic : IInputSpeechToTextService
    {
        // The Payload property of the SpeechIntentEventArgs class
        public event EventHandler<string> SpeechToTextCompletedEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> SpeechToTextErrorEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        DataRecognitionClient DataClient { get; set; }
        private string DefaultLocale
        {
            get { return "en-US"; }
        }
        private SpeechRecognitionMode Mode
        {
            get { return SpeechRecognitionMode.ShortPhrase; }
        }

        Character TheCharacter;

        public bool StartProcessingAudioAsync(ConversationsRepository aRep, Character aCharacter)
        {
            TheCharacter = aCharacter;
            if (DataClient == null)
            {
                DataClient = SpeechRecognitionServiceFactory.CreateDataClientWithIntent(
                    DefaultLocale,
                    aCharacter.SpeechRecognitionSubscriptionKey,
                    aCharacter.SpeechRecognitionSubscriptionKey,
                    aCharacter.CurrentState.LUISAppId,
                    aCharacter.CurrentState.LUISSubscriptionKey);
                DataClient.OnConversationError += DataClient_OnConversationError;
                DataClient.OnPartialResponseReceived += DataClient_OnPartialResponseReceived;
                DataClient.OnResponseReceived += DataClient_OnResponseReceived;
                DataClient.OnIntent += DataClient_OnIntent;
            }
            return true;
        }

        private void DataClient_OnIntent(object sender, SpeechIntentEventArgs e)
        {
            MessageEvent(this, $"SpeechToTextBasic - DataClient_OnIntent {e.Payload}");
            SpeechToTextCompletedEvent(this, e.Payload);
        }

        private void DataClient_OnResponseReceived(object sender, SpeechResponseEventArgs e)
        {
            MessageEvent(this, $"SpeechToTextBasic - DataClient_OnResponseReceived {e.PhraseResponse}");
        }

        private void DataClient_OnPartialResponseReceived(object sender, PartialSpeechResponseEventArgs e)
        {
            MessageEvent(this, $"SpeechToTextBasic - DataClient_OnResponseReceived {e.PartialResult}");
        }

        private void DataClient_OnConversationError(object sender, SpeechErrorEventArgs e)
        {
            SpeechToTextErrorEvent(this, new ConversationsErrorArgs(new Exception(e.SpeechErrorText), TheCharacter, $"{MethodBase.GetCurrentMethod().DeclaringType}.{MethodBase.GetCurrentMethod().Name}"));
        }
        



        public void FinishedProcessing()
        {
            MessageEvent(this, "SpeechToTextBasic - FinishedProcessing");
            DataClient.EndAudio();

        }

        public void MoreAudio(AudioBuffer aBuffer)
        {
            DataClient.SendAudio(aBuffer.Buffer, aBuffer.BufferSize);
        }

        public void Dispose()
        {
            if (null != DataClient)
            {
                DataClient.Dispose();
            }
        }
    }

}
