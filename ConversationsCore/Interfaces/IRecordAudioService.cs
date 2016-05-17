using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using System.IO;

namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Basic interface for recording audio
    /// </summary>
    public interface IRecordAudioService
    {
        event EventHandler<int> StartedRecordingEvent;

        event EventHandler<AudioBuffer> PartialRecordingEvent;

        event EventHandler<Exception> FinishedRecordingEvent;

        event EventHandler<ConversationsErrorArgs> RecordAudioErrorEvent;

        event EventHandler<string> MessageEvent;

        int RecordingFrequency { get; }

        bool IsRecording { get; set; }

        bool StartRecordingAudioAsync();

        bool StopRecordingAudioAsync();

    }
}
