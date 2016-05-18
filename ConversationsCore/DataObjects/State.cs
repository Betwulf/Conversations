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

        /// <summary>
        /// Associated LUIS App Id used to map text to intent
        /// </summary>
        public string LUISAppId { get; set; }


        public string LUISSubscriptionKey { get; set; }

        /// <summary>
        /// If No response is valid in this state, try this one next
        /// </summary>
        public string FallbackStateId { get; set; }

        /// <summary>
        /// List used to determine what is the proper response
        /// </summary>
        public List<IntentResponse> IntentResponseList { get; set; }

        public State()
        {
            IntentResponseList = new List<IntentResponse>();
        }

        public override string ToString()
        {
            return Id;
        }

    }
}
