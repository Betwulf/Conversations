using ConversationsCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.DataObjects
{
    public class Character : IRepositoryObject
    {
        /// <summary>
        /// Strength of Zero means I don't know you. Positive numbers are good, negative is bad, abs max is 10
        /// </summary>
        public int RelationshipStrength { get; set; }

        /// <summary>
        /// The presence of a string means that the item has been discussed or mentioned
        /// </summary>
        public Dictionary<string, bool> ContextFlags { get; set; }

        /// <summary>
        /// StateList - order matters, the first State is the first one used
        /// </summary>
        public List<State> StateList { get; set; }

        public State CurrentState { get; set; }

        public string SpeechRecognitionSubscriptionKey { get; set; }

        public string Id { get; set; }

        public Character()
        {
            ContextFlags = new Dictionary<string, bool>();
            StateList = new List<State>();
        }
    }
}
