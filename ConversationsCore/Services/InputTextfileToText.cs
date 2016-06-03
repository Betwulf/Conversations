using ConversationsCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using System.Reflection;

namespace ConversationsCore.Services
{
    public class InputTextfileToText : IInputSpeechToTextService
    {
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<string> SpeechToTextCompletedEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> SpeechToTextErrorEvent = delegate { };



        public int NextInputIndex { get; set; }


        List<string> SimulationInput;

        public InputTextfileToText()
        {
            SimulationInput = new List<string>(){
                "Hello",
                "A beer please",
                "Fuck off"
            };
            NextInputIndex = 0;
        }

        private async Task<string> SimulateNextInput()
        {
            return await Task.Run(() =>
            {
                NextInputIndex = NextInputIndex % 3; // loop
                Task.Delay(2000);
                MessageEvent(this, $"{MethodBase.GetCurrentMethod().DeclaringType}.{MethodBase.GetCurrentMethod().Name}");
                SpeechToTextCompletedEvent(this, SimulationInput[NextInputIndex++]);
                return SimulationInput[NextInputIndex];
            });
        }


        public void Dispose()
        {
            
        }

        public void FinishedProcessing()
        {
            
        }

        public void MoreAudio(AudioBuffer aBuffer)
        {
            
        }

        public bool StartProcessingAudioAsync(Character aCharacter)
        {
            SimulateNextInput();
            return true; 
        }
    }
}
