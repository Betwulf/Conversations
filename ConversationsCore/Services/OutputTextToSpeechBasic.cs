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
using System.IO;
using ConversationsCore.Repository;

namespace ConversationsCore.Services
{
    public class OutputTextToSpeechBasic : IOutputTextToSpeechService
    {
        public event EventHandler<ConversationsErrorArgs> TextToSpeechErrorEvent = delegate { };
        public event EventHandler<Character> TextToSpeechPlayCompleteEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };

        public Character CurrentCharacter { get; set; }


        public bool StartPlayingResponseAudioAsync(ConversationsRepository Rep, IntentResponse aResponse, Character aCharacter)
        {
            var dir = aResponse.GetResponseDirectory(Rep, aCharacter, aCharacter.CurrentState);
            MessageEvent(this, $"Found a match: {aResponse.Id}");
            // Randomly select a file in the directory
            var files = Directory.EnumerateFiles(dir);
            var rnd = new Random(DateTime.Now.Millisecond);
            var aWaveFilename = files.ElementAt(rnd.Next(0, files.Count()));


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
                TextToSpeechErrorEvent(this, new ConversationsErrorArgs(ex, aCharacter));
            }
            return false;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            TextToSpeechPlayCompleteEvent(this, CurrentCharacter);
        }
    }
}
