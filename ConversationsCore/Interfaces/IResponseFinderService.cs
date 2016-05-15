using System;
using System.IO;
using ConversationsCore.DataObjects;
using ConversationsCore.Repository;


namespace ConversationsCore.Interfaces
{
    public interface IResponseFinderService
    {
        event EventHandler<IntentResponse> ResponseFoundEvent;

        event EventHandler<ConversationsErrorArgs> ResponseFinderErrorEvent;

        /// <summary>
        /// Starts processing the right response, which will trigger eith er a response found event, or an error event
        /// </summary>
        /// <param name="SpeechIntentPayload">The Payload property of the SpeechIntentEventArgs class</param>
        /// <param name="aCharacter"></param>
        /// <returns></returns>
        bool StartProcessingIntentAsync(string SpeechIntentPayload, Character aCharacter);
    }
}
