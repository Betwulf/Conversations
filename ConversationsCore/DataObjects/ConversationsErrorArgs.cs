using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.DataObjects
{
    public class ConversationsErrorArgs
    {
        public Exception theException { get; set; }

        public string Note { get; set; }

        public Character theCharacter { get; set; }

    }
}
