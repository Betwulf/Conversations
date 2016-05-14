using ConversationsCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConversationsCore.DataObjects;

namespace Conversations
{
    public partial class Form1 : Form
    {

        RecordAudioNAudio audio;
        public Form1()
        {
            InitializeComponent();
            audio = new RecordAudioNAudio();
            audio.FinishedRecordingEvent += OnStop;
            audio.StartedRecordingEvent += OnStartedRecording;
            audio.PartialRecordingEvent += OnPartialRecording;
            audio.RecordAudioErrorEvent += OnAudioError;
            audio.MessageEvent += OnMessage;
        }

        private void OnMessage(object sender, string e)
        {
            Message($"OnMessage: {e}");
        }

        private void OnAudioError(object sender, ConversationsErrorArgs e)
        {
            Message($"OnAudioError: {e.theException.Message}");
        }

        private void OnPartialRecording(object sender, Stream e)
        {
            Message("OnPartialRecording");
        }

        private void OnStartedRecording(object sender, Stream e)
        {
            Message("OnStartedRecording");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblLight.Visible = true;
            btnStart.Enabled = false;
            audio.StartRecordingAudioAsync();
        }

        private void btnStopConversation_Click(object sender, EventArgs e)
        {
            audio.StopRecordingAudioAsync();
        }

        private void OnStop(object sender, Stream e)
        {
            Message("OnStop");
            lblLight.Visible = false;
            btnStart.Enabled = true;
        }

        private void Message(string aMessage)
        {
            Console.WriteLine(aMessage);
            txtOutput.Text += aMessage + Environment.NewLine;
        }
    }
}
