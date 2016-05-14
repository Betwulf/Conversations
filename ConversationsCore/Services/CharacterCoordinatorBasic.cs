using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;

namespace ConversationsCore.Services
{
    public class CharacterCoordinatorBasic : ICharacterCoordinatorService
    {
        public IAudioControllerService AudioController { get; set; }

        public event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent;
        public event EventHandler<Character> ConversationEndedEvent;
        public event EventHandler<Character> ConversationStartedEvent;

        public bool StartConversationAsync(Character aCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
