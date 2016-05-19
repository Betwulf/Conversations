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
using ConversationsCore.Repository;
using System.Threading;

namespace Conversations
{
    public partial class Form1 : Form
    {
        private readonly SynchronizationContext synchronizationContext;


        CharacterCoordinatorBasic Coordinator;
        Character DefaultCharacter { get; set; }
        ConversationsRepository Rep { get; set; }


        //RecordAudioNAudio audio;
        //SampleAggregator sampler;
        public Form1()
        {
            synchronizationContext = SynchronizationContext.Current;
            InitializeComponent();
            Rep = new ConversationsRepository();

            /*
            audio = new RecordAudioNAudio();
            audio.FinishedRecordingEvent += OnStopRecording;
            audio.StartedRecordingEvent += OnStartedRecording;
            audio.PartialRecordingEvent += OnPartialRecording;
            audio.RecordAudioErrorEvent += OnAudioError;
            audio.MessageEvent += OnMessage;
            sampler = new SampleAggregator(audio);
            sampler.SampleEvent += OnSampleEvent;
            */
            Coordinator = new CharacterCoordinatorBasic();
            Coordinator.CharacterCoordinatorErrorEvent += Coordinator_CharacterCoordinatorErrorEvent;
            Coordinator.ConversationStartedEvent += Coordinator_ConversationStartedEvent;
            Coordinator.ConversationEndedEvent += Coordinator_ConversationEndedEvent;
            Coordinator.MessageEvent += OnMessage;
            DefaultCharacter = Rep.CharacterDB.GetById("Bartender");
        }

        private void Coordinator_ConversationEndedEvent(object sender, Character e)
        {
            throw new NotImplementedException();
        }

        private void Coordinator_ConversationStartedEvent(object sender, Character e)
        {
            throw new NotImplementedException();
        }

        private void Coordinator_CharacterCoordinatorErrorEvent(object sender, ConversationsErrorArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSampleEvent(object sender, MaxSampleEventArgs e)
        {
            lblSample.Text = $"Sample: {e.MaxSample}";
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
                Coordinator.StartConversationAsync(DefaultCharacter);
                //audio.StartRecordingAudioAsync();
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
            //audio.StopRecordingAudioAsync();
        }


        private void Message(string aMessage)
        {
            synchronizationContext.Post(new SendOrPostCallback(p =>
            {
                Console.WriteLine(aMessage);
                txtOutput.Text += p.ToString() + Environment.NewLine;
            }), aMessage);
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Coordinator.Dispose();
        }
    }
}
