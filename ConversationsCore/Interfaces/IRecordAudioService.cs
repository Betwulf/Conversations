using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using System.IO;

namespace ConversationsCore.Interfaces
{
    public interface IRecordAudioService
    {
        event EventHandler<Stream> StartedRecordingEvent;

        event EventHandler<Stream> FinishedRecordingEvent;

        event EventHandler<ConversationsErrorArgs> RecordAudioErrorEvent;

        bool StartRecordingAudioAsync(Character aCharacter);

    }
}
