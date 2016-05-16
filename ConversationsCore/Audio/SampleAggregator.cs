using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.Interfaces;
using NAudio;
using NAudio.Wave;
using NAudio.Mixer;
using ConversationsCore.Audio;
using ConversationsCore.DataObjects;

namespace ConversationsCore.Audio
{
    public class SampleAggregator
    {
        public event EventHandler<MaxSampleEventArgs> SampleEvent = delegate { };
        public int NotificationCount { get; set; }

        int count;
        private float maxValue;
        private float minValue;

        public SampleAggregator(IRecordAudioService recorder)
        {
            NotificationCount = recorder.RecordingFrequency / 10;
            recorder.PartialRecordingEvent += OnDataAvailable;
        }

        private void OnDataAvailable(object sender, AudioBuffer e)
        {
            for (int index = 0; index < e.BufferSize; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                Add(sample32);
            }
        }

        public void Add(float value)
        {
            maxValue = Math.Max(maxValue, value);
            minValue = Math.Min(minValue, value);
            count++;
            if (count >= NotificationCount && NotificationCount > 0)
            {
                SampleEvent(this, new MaxSampleEventArgs(minValue, maxValue));
                count = 0;
                maxValue = minValue = 0;
            }
        }
    }

    public class MaxSampleEventArgs : EventArgs
    {
        public MaxSampleEventArgs(float minValue, float maxValue)
        {
            MaxSample = maxValue;
            MinSample = minValue;
        }
        public float MaxSample { get; private set; }
        public float MinSample { get; private set; }
    }
}
