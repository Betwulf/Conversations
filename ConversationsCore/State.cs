using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore
{
    public class State
    {
        public int id { get; set; }

        public string LUISAppId { get; set; }

        public Stack<State> FallbackStateStack { get; set; }

        public Dictionary<Intent, Response> IntentMap { get; set; }

    }
}
