using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.DataObjects
{
    public class ConversationsErrorArgs
    {
        public ConversationsErrorArgs(Exception ex, Character aChar, string aNote = "")
        {
            theException = ex;
            theCharacter = aChar;
            theNote = aNote;
        }

        public Exception theException { get; set; }

        public string theNote { get; set; }

        public Character theCharacter { get; set; }

    }
}
