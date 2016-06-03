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
        /// <summary>
        /// Periodically send the magnitude of sound incoming. Used to tell if talking is ongoing or stopped.
        /// </summary>
        event EventHandler<float> AudioLevelEvent;

        /// <summary>
        /// Receive a Start recording evet along with the sample rate as an int
        /// </summary>
        event EventHandler<int> StartedRecordingEvent;

        /// <summary>
        /// When the buffer is full, send data in real time to be processed
        /// </summary>
        event EventHandler<AudioBuffer> PartialRecordingEvent;

        /// <summary>
        /// Recording is complete, return true if all is good
        /// </summary>
        event EventHandler<bool> FinishedRecordingEvent;

        /// <summary>
        /// send any event messages
        /// </summary>
        event EventHandler<string> MessageEvent;

        /// <summary>
        /// Failure occurred, stop the presses.q
        /// </summary>
        event EventHandler<ConversationsErrorArgs> AudioControllerErrorEvent;




        void StartRecording();

        void StopRecording();


    }
}
