using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.DataObjects
{
    public class State
    {
        public int id { get; set; }

        public string LUISAppId { get; set; }

        public Stack<State> FallbackStateStack { get; set; }

        public Dictionary<Meaning, Response> IntentMap { get; set; }

    }
}
