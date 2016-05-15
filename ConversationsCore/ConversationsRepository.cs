using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.Interfaces;
using ConversationsCore.DataObjects;


namespace ConversationsCore
{
    public class ConversationsRepository
    {

        public ConversationsClassRepository<Character> CharacterDB { get; set; }

        public ConversationsClassRepository<Meaning> MeaningDB { get; set; }

        public ConversationsClassRepository<Response> ResponseDB { get; set; }

        public ConversationsClassRepository<State> StateDB { get; set; }

        public ConversationsClassRepository<Keys> KeysDB { get; set; }

    }
}
