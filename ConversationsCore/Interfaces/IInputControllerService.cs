using ConversationsCore.DataObjects;
using ConversationsCore.Repository;
using ConversationsCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Handles potentially multiple services to get input from the client into a string
    /// </summary>
    public interface IInputControllerService : IDisposable
    {
        event EventHandler<string> InputControllerCompletedEvent;
        event EventHandler<ConversationsErrorArgs> InputControllerErrorEvent;
        event EventHandler<string> MessageEvent;


        void StartGettingInput(ConversationsRepository aRep, Character aCharacter, IAudioControllerService anAudioController, IInputSpeechToTextService aTextConversionService);

    }
}
