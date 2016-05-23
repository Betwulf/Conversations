using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.DataObjects;
using ConversationsCore.Interfaces;
using System.IO;

namespace ConversationsCore.Services
{
    public class RecordAudioButReallyReadFromAWavefile : IRecordAudioService
    {
        public bool IsRecording { get; set; }

        public int RecordingFrequency { get { return 44100; } }

        public event EventHandler<Exception> FinishedRecordingEvent = delegate { };
        public event EventHandler<string> MessageEvent = delegate { };
        public event EventHandler<AudioBuffer> PartialRecordingEvent = delegate { };
        public event EventHandler<ConversationsErrorArgs> RecordAudioErrorEvent = delegate { };
        public event EventHandler<int> StartedRecordingEvent = delegate { };

        public string WaveFilename { get; set; }

        public RecordAudioButReallyReadFromAWavefile(string aFilename)
        {
            WaveFilename = aFilename;
        }

        public bool StartRecordingAudioAsync()
        {
            StartedRecordingEvent(this, RecordingFrequency);
            using (FileStream fileStream = new FileStream(WaveFilename, FileMode.Open, FileAccess.Read))
            {
                // Note for wave files, we can just send data from the file right to the server.
                // In the case you are not an audio file in wave format, and instead you have just
                // raw data (for example audio coming over bluetooth), then before sending up any 
                // audio data, you must first send up an SpeechAudioFormat descriptor to describe 
                // the layout and format of your raw audio data via DataRecognitionClient's sendAudioFormat() method.
                int bytesRead = 0;
                byte[] buffer = new byte[1024];

                try
                {
                    do
                    {
                        var buf = new AudioBuffer();
                        // Get more Audio data to send into byte buffer.
                        buf.Buffer = buffer;
                        buf.BufferSize = fileStream.Read(buffer, 0, buffer.Length);
                        bytesRead = buf.BufferSize;

                        // Send of audio data to service. 
                        PartialRecordingEvent(this, buf);
                    }
                    while (bytesRead > 0);
                }
                catch (Exception ex)
                {
                    RecordAudioErrorEvent(this, new ConversationsErrorArgs(ex, null));
                }
                finally
                {
                    // We are done sending audio.  Final recognition results will arrive in OnResponseReceived event call.
                    FinishedRecordingEvent(this, null);
                }
            }
            return true;
        }

        public bool StopRecordingAudioAsync()
        {
            return true;
        }
    }
}
