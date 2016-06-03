using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using ConversationsCore.Audio;
using ConversationsCore.Repository;

namespace ConversationsCore.Services
{
    public class InputControllerBasic : IInputControllerService
    {
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<string> InputControllerCompletedEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> InputControllerErrorEvent = delegate { };

        IAudioControllerService audioController;
        IInputSpeechToTextService speechToText;
        Character theCharacter;
        ConversationsRepository Rep;

        
        private void SpeechToText_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void SpeechToText_SpeechToTextErrorEvent(object sender, ConversationsErrorArgs e)
        {
            InputControllerErrorEvent(this, e);
        }

        private void SpeechToText_SpeechToTextCompletedEvent(object sender, string e)
        {
            InputControllerCompletedEvent(this, e);
        }

        private void AudioController_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        private void RecordAudio_StartedRecordingEvent(object sender, int e)
        {
            speechToText.StartProcessingAudioAsync(theCharacter);
        }

        private void RecordAudio_FinishedRecordingEvent(object sender, bool e)
        {
            audioController.StopRecording();
            speechToText.Dispose();
            // ResponseFinder.STOP TODO: Make stops? Do we need to?
            MessageEvent(this, "InputController - OnFinishedRecordingEvent");
            speechToText.FinishedProcessing();
        }

        private void RecordAudio_RecordAudioErrorEvent(object sender, ConversationsErrorArgs e)
        {
            InputControllerErrorEvent(this, e);
        }

        private void RecordAudio_PartialRecordingEvent(object sender, AudioBuffer e)
        {
            speechToText.MoreAudio(e);
        }

        private void RecordAudio_MessageEvent(object sender, string e)
        {
            MessageEvent(this, e);
        }

        public void StartGettingInput(ConversationsRepository aRep, Character aCharacter, IAudioControllerService anAudioController = null)
        {
            // Save params
            theCharacter = aCharacter;
            Rep = aRep;

            // New only one AudioController, resources may be locked in
            audioController = anAudioController;
            if (audioController == null)
            {
                audioController = anAudioController == null ? new AudioControllerTextfile() : anAudioController;
            }
                
            speechToText = new InputTextfileToText();

            audioController.AudioControllerErrorEvent += RecordAudio_RecordAudioErrorEvent;
            audioController.AudioLevelEvent += AudioController_AudioLevelEvent;
            audioController.FinishedRecordingEvent += RecordAudio_FinishedRecordingEvent;
            audioController.PartialRecordingEvent += RecordAudio_PartialRecordingEvent;
            audioController.MessageEvent += RecordAudio_MessageEvent;
            audioController.StartedRecordingEvent += RecordAudio_StartedRecordingEvent;
            audioController.MessageEvent += AudioController_MessageEvent;
            speechToText.SpeechToTextCompletedEvent += SpeechToText_SpeechToTextCompletedEvent;
            speechToText.SpeechToTextErrorEvent += SpeechToText_SpeechToTextErrorEvent;
            speechToText.MessageEvent += SpeechToText_MessageEvent;

            // GO
            audioController.StartRecording();

        }

        private void AudioController_AudioLevelEvent(object sender, float e)
        {
            MessageEvent(this, $"AudioLevel: {e}");
        }

        public void Dispose()
        {
            if (speechToText != null)
            {
                speechToText.Dispose();
                speechToText = null;
            }
        }
    }
}
