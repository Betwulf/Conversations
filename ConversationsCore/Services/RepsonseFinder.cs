using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Repository;

namespace ConversationsCore.Services
{
    class RepsonseFinder : IResponseFinderService
    {
        public event EventHandler<ConversationsErrorArgs> ResponseFinderErrorEvent;
        public event EventHandler<IntentResponse> ResponseFoundEvent;

        public bool StartProcessingIntentAsync(string SpeechIntentPayload, Character aCharacter)
        {
            throw new NotImplementedException();
        }

        public ConversationsRepository Rep { get; set; }

        public RepsonseFinder(ConversationsRepository aRep)
        {
            Rep = aRep;
        }

    }
}
