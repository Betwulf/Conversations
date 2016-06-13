using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Repository;
using Newtonsoft.Json;
using System.IO;

namespace ConversationsCore.Services
{
    public class ResponseFinderBasic : IResponseFinderService
    {
        public event EventHandler<Exception> ResponseFinderErrorEvent = delegate { };
        public event EventHandler<IntentResponse> ResponseFoundEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        private ConversationsRepository Rep { get; set; }

        public ResponseFinderBasic()
        {
            Rep = new ConversationsRepository();
        }

        public void ModifyCharacterFromIntentResponse(Character aCharacter, IntentResponse aResponse)
        {
            // alter relationshipStrength
            aCharacter.RelationshipStrength += aResponse.RelationshipStrengthToBeAltered;

            // Add conversation context flag
            foreach (var item in aResponse.ContextToBeAdded)
            {
                aCharacter.ContextFlags.Add(item);
            }
            // Assume StateToBeSetNext is "" if no state switching is needed, and assume no state is ""
            var foundState = from state in aCharacter.StateList where state.Id == aResponse.StateToBeSetNext select state;
            if (foundState.Any())
            {
                aCharacter.CurrentState = foundState.First();
            }

        }

        public bool StartProcessingIntentAsync(string SpeechIntentPayload, Character aCharacter)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<ResponseJson>(SpeechIntentPayload);
                // Look for top RelationshipStrength that is under or equal to current value, matching intent and needed context flags
                // Assumes the first intent in the json object is the highest scored intent
                var responses = from item in aCharacter.CurrentState.IntentResponseList
                                where item.RelationshipStrengthNeeded <= aCharacter.RelationshipStrength
                                where aCharacter.ContextFlags.All(x => item.ContextNeeded.Contains(x))
                                where item.Intent == json.intents.First().intent
                                group item by item.Intent into grp
                                select new
                                {
                                    Intent = grp.Key,
                                    Item = from top in grp
                                           where top.RelationshipStrengthNeeded == grp.Max(x => x.RelationshipStrengthNeeded)
                                           select top
                                };
                //TODO: The linq is wrong, should be matching item.ContextNeeded to ContextFlags not the other way around...
                var intent = responses.First().Item.FirstOrDefault();
                if (intent == null)
                {
                    // Data Error, either it should be here or we need to use the fallback state
                    // TODO: Fallback, for now error
                    throw new Exception($"Can't find a matching IntentResponse, CurrentState: {aCharacter.CurrentState}, Payload: {SpeechIntentPayload}");
                }
                ResponseFoundEvent(this, intent);
                ModifyCharacterFromIntentResponse(aCharacter, intent);
            }
            catch (Exception ex)
            {
                ResponseFinderErrorEvent(this, ex);
            }
            return true;
        }
    }
}
