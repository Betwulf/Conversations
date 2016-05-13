using System;
using Microsoft.ProjectOxford.SpeechRecognition;
using System.IO;
using ConversationsCore.DataObjects;


namespace ConversationsCore.Interfaces
{
    public interface IResponseFinderService
    {
        event EventHandler<Response> ResponseFoundEvent;

        event EventHandler<ConversationsErrorArgs> ResponseFinderErrorEvent;

        bool StartProcessingIntentAsync(Meaning aMeaning, Character aCharacter);

    }
}
