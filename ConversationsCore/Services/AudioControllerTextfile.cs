using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Audio;

namespace ConversationsCore.Services
{
    public class AudioControllerTextfile : IAudioControllerService
    {
        public IRecordAudioService RecordAudio { get; set; }

        public event EventHandler<float> AudioLevelEvent = delegate { };
        public event EventHandler<Exception> CompletedEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<bool> RecordOffEvent = delegate { };
        public event EventHandler<bool> RecordOnEvent = delegate { };

        public void StartRecording()
        {
            throw new NotImplementedException();
        }

        public void StopRecording()
        {
            throw new NotImplementedException();
        }
    }
}
