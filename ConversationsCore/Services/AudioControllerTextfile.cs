using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Audio;
using System.Reflection;

namespace ConversationsCore.Services
{
    public class AudioControllerTextfile : IAudioControllerService
    {
        public IRecordAudioService RecordAudio { get; set; }

        public event EventHandler<float> AudioLevelEvent = delegate { };
        public event EventHandler<bool> FinishedRecordingEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<AudioBuffer> PartialRecordingEvent = delegate { };
        public event EventHandler<int> StartedRecordingEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> AudioControllerErrorEvent = delegate { };

        
        public void StartRecording()
        {
            AudioLevelEvent(this, 1.0f);
            StartedRecordingEvent(this, 1);
            MessageEvent(this, $"{MethodBase.GetCurrentMethod().DeclaringType}.{MethodBase.GetCurrentMethod().Name}");
            Task.Run(() =>
            {
                MessageEvent(this, $"{MethodBase.GetCurrentMethod().DeclaringType}.{MethodBase.GetCurrentMethod().Name} - start");
                Task.Delay(2000);
                MessageEvent(this, $"{MethodBase.GetCurrentMethod().DeclaringType}.{MethodBase.GetCurrentMethod().Name} - end");
                FinishedRecordingEvent(this, true);
            });
        }

        public void StopRecording()
        {
        }
    }
}
