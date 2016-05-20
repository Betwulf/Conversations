using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using NAudio;
using NAudio.Wave;
using NAudio.Mixer;

namespace ConversationsCore.Services
{
    public class TextToSpeechBasic : ITextToSpeechService
    {
        public event EventHandler<ConversationsErrorArgs> TextToSpeechErrorEvent = delegate { };
        public event EventHandler<Character> TextToSpeechPlayCompleteEvent = delegate { };

        public Character CurrentCharacter { get; set; }

        public bool StartPlayingResponseAudioAsync(string aWaveFilename, Character aCharacter)
        {
            try
            {
                CurrentCharacter = aCharacter;
                WaveOutEvent player = new WaveOutEvent();
                var fileReader = new WaveFileReader(aWaveFilename);
                player.Init(fileReader);
                player.PlaybackStopped += OnPlaybackStopped;
                player.Play();
                return true;
            }
            catch (Exception ex)
            {
                TextToSpeechErrorEvent(this, new ConversationsErrorArgs() { theException = ex, theCharacter = aCharacter });
            }
            return false;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            TextToSpeechPlayCompleteEvent(this, CurrentCharacter);
        }
    }
}
