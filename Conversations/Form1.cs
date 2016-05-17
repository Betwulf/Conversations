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
using ConversationsCore.Audio;

namespace Conversations
{
    public partial class Form1 : Form
    {

        RecordAudioNAudio audio;
        SampleAggregator sampler;
        public Form1()
        {
            InitializeComponent();
            audio = new RecordAudioNAudio();
            audio.FinishedRecordingEvent += OnStopRecording;
            audio.StartedRecordingEvent += OnStartedRecording;
            audio.PartialRecordingEvent += OnPartialRecording;
            audio.RecordAudioErrorEvent += OnAudioError;
            audio.MessageEvent += OnMessage;
            sampler = new SampleAggregator(audio);
            sampler.SampleEvent += OnSampleEvent;
        }

        private void OnSampleEvent(object sender, MaxSampleEventArgs e)
        {
            barVolume.Value = (int)(Math.Max(e.MaxSample, Math.Abs(e.MinSample))*100);
        }

        private void OnMessage(object sender, string e)
        {
            Message($"OnMessage: {e}");
        }

        private void OnAudioError(object sender, ConversationsErrorArgs e)
        {
            Message($"OnAudioError: {e.theException.Message}");
        }

        private void OnPartialRecording(object sender, AudioBuffer abuffer)
        {
            Message("OnPartialRecording");
        }

        private void OnStartedRecording(object sender, int e)
        {
            Message("OnStartedRecording");
        }

        private void OnStopRecording(object sender, Exception e)
        {
            Message("OnStop");
            lblLight.Visible = false;
            btnStart.Enabled = true;
            barVolume.Value = 0;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                lblLight.Visible = true;
                btnStart.Enabled = false;
                audio.StartRecordingAudioAsync();
            }
            catch (Exception ex)
            {
                lblLight.Visible = false;
                btnStart.Enabled = true;
                Message(ex.Message);
            }
        }

        private void btnStopConversation_Click(object sender, EventArgs e)
        {
            audio.StopRecordingAudioAsync();
        }


        private void Message(string aMessage)
        {
            Console.WriteLine(aMessage);
            txtOutput.Text += aMessage + Environment.NewLine;
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            var form = new frmEditData();
            form.ShowDialog();
            
        }

        private void btnRecordAudio_Click(object sender, EventArgs e)
        {
            var form = new frmRecordAudio();
            form.ShowDialog();
        }
    }
}
