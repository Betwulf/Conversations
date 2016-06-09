using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.DataObjects
{
    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }


    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }

    }

    public class ResponseJson
    {
        public string query { get; set; }

        public List<Intent> intents { get; set; }

        public List<Entity> entities { get; set; }

        public ResponseJson()
        {
            intents = new List<Intent>();
            entities = new List<Entity>();
        }
    }
}
