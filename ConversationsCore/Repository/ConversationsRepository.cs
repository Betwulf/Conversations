using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.Interfaces;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Repository
{
    public class ConversationsRepository
    {

        public ConversationsClassRepository<Character> CharacterDB { get; set; }

        public ConversationsClassRepository<Keys> KeysDB { get; set; }

        public ConversationsRepository()
        {
            CharacterDB = new ConversationsClassRepository<Character>();
            KeysDB = new ConversationsClassRepository<Keys>();
        }

    }
}
