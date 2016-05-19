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
        public event EventHandler<string> ResponseFoundEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        private ConversationsRepository Rep { get; set; }

        public ResponseFinderBasic()
        {
            Rep = new ConversationsRepository();
        }
        public bool StartProcessingIntentAsync(string SpeechIntentPayload, Character aCharacter)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<ResponseJson>(SpeechIntentPayload);
                // Look for top RelationshipStrength that is under or equal to current value, matching intent and needed context flags
                // Assumes the first intent in the json object is the highest scored intent
                var responses = from item in aCharacter.CurrentState.IntentResponseList
                                where item.RelationshipStrength <= aCharacter.RelationshipStrength
                                where aCharacter.ContextFlags.All(x => item.ContextNeeded.Contains(x))
                                where item.Intent == json.intents.First().intent
                                group item by item.Intent into grp
                                select new
                                {
                                    Intent = grp.Key,
                                    Item = from top in grp
                                           where top.RelationshipStrength == grp.Max(x => x.RelationshipStrength)
                                           select top
                                };
                var intent = responses.First().Item.FirstOrDefault();
                if (intent == null)
                {
                    // Data Error, either it should be here or we need to use the fallback state
                    // TODO: Fallback, for now error
                    throw new Exception($"Can't find a matching IntentResponse, CurrentState: {aCharacter.CurrentState}, Payload: {SpeechIntentPayload}");
                }
                var dir = intent.GetResponseDirectory(Rep, aCharacter, aCharacter.CurrentState);
                MessageEvent(this, $"Found a match: {intent.Id}, looking in dir: {dir}");
                // Randomly select a file in the directory
                var files = Directory.EnumerateFiles(dir);
                var rnd = new Random(DateTime.Now.Millisecond);
                var filename = files.ElementAt(rnd.Next(0, files.Count()));
                ResponseFoundEvent(this, filename);
            }
            catch (Exception ex)
            {
                ResponseFinderErrorEvent(this, ex);
            }
            return true;
        }
    }
}
