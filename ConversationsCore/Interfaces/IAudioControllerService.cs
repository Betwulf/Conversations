using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Interfaces
{
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
