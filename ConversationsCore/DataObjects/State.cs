using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.Interfaces;

namespace ConversationsCore.DataObjects
{
    public class State : IRepositoryObject
    {
        public string Id { get; set; }

        public string LUISAppId { get; set; }

        public string FallbackStateId { get; set; }

        public List<IntentResponse> IntentMap { get; set; }

        public State()
        {
            IntentMap = new List<IntentResponse>();
        }
    }
}
