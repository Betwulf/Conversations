using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.DataObjects
{
    public class Meaning
    {
        public string Title { get; set; }

        /// <summary>
        /// Type and keyword associated with this intent
        /// </summary>
        public Dictionary<string, string> EntityDictionary { get; set; }

    }
}
