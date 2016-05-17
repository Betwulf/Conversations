using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Determines when to turn the microphone on and off depending on levels of silence
    /// Used by the Character Coordinator to know when to listen for the next human repsonse
    /// </summary>
    public interface IAudioControllerService
    {
        IRecordAudioService RecordAudio { get; set; }

        void OnRecordStart();

        void OnRecordStop();

        event EventHandler<float> AudioLevelEvent;

        event EventHandler<bool> MicrophoneOnEvent;

        event EventHandler<bool> MicrophoneOffEvent;

        event EventHandler CompletedEvent;

    }
}
