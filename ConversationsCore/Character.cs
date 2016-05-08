using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore
{
    public class Character
    {
        public int RelationshipStrength { get; set; }

        public Dictionary<string, bool> ContextFlags { get; set; }

        public List<State> StateList { get; set; }

        public State CurrentState { get; set; }


    }
}
