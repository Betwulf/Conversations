using ConversationsCore.Helpers;
using ConversationsCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.DataObjects
{
    public class ConversationPartsList : IRepositoryObject
    {

        public List<ResponseJson> ConversationParts { get; set; }

        public string Id { get; set; }

        public ConversationPartsList()
        {
            ConversationParts = new List<ResponseJson>();
        }

    }
}
