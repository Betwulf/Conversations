using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;

namespace ConversationsCore.Services
{
    /// <summary>
    /// Coordinates all other services in order to execute a full conversation with the character
    /// </summary>
    public class CharacterCoordinatorBasic : ICharacterCoordinatorService
    {
        public IAudioControllerService AudioController { get; set; }

        public event EventHandler<ConversationsErrorArgs> CharacterCoordinatorErrorEvent = delegate { };
        public event EventHandler<Character> ConversationEndedEvent = delegate { };
        public event EventHandler<Character> ConversationStartedEvent = delegate { };

        public CharacterCoordinatorBasic()
        {
            AudioController = new AudioController();
        }

        public bool StartConversationAsync(Character aCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
