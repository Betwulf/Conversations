using ConversationsCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using ConversationsCore.Helpers;
using ConversationsCore.Repository;

namespace ConversationsCore.Services
{
    public class InputTextfileToText : IInputSpeechToTextService
    {
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<string> SpeechToTextCompletedEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> SpeechToTextErrorEvent = delegate { };


        public ConversationsRepository Rep { get; set; }

        public int NextInputIndex { get; set; }

        public string ConversationId { get; set; }


        ConversationPartsList SimulationInputList;

        public InputTextfileToText(string aConversationId)
        {
            ConversationId = aConversationId;
            NextInputIndex = 0;
        }

        private async Task<ResponseJson> SimulateNextInput()
        {
            return await Task.Run(() =>
            {
                NextInputIndex = NextInputIndex % SimulationInputList.ConversationParts.Count;
                Task.Delay(2000);
                MessageEvent(this, $"{MethodBase.GetCurrentMethod().DeclaringType}.{MethodBase.GetCurrentMethod().Name}");
                var stringResponse = JsonConvert.SerializeObject(SimulationInputList.ConversationParts[NextInputIndex++]);
                SpeechToTextCompletedEvent(this, stringResponse);
                return SimulationInputList.ConversationParts[NextInputIndex];
            });
        }


        public void Dispose()
        {
            
        }

        public void FinishedProcessing()
        {
            
        }

        public void MoreAudio(AudioBuffer aBuffer)
        {
            
        }

        public bool StartProcessingAudioAsync(ConversationsRepository aRep, Character aCharacter)
        {
            Rep = aRep;
            SimulationInputList = Rep.ConversationPartsDB.GetById(ConversationId);
            SimulateNextInput();
            return true; 
        }
    }
}
