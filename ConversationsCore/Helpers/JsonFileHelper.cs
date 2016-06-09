using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.Helpers
{
    public static class JsonFileHelper<T>
    {
        public static T GetFromFile(string aFilename)
        {
            if (File.Exists(aFilename))
            {
                T theDoc = JsonConvert.DeserializeObject<T>(File.ReadAllText(aFilename));
                return theDoc;
            }
            else
            {
                return default(T);
            }
        }
    }
}
