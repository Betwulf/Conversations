using ConversationsCore.Audio;
using ConversationsCore.DataObjects;
using ConversationsCore.Repository;
using ConversationsCore.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace Conversations
{
    public partial class frmRecordAudio : Form
    {
        public Character chr { get; set; }
        private ConversationsRepository Rep { get; set; }

        RecordAudioNAudio audio;
        WavefileSaver wavefilesaver;
        SampleAggregator sampler;

        public IntentResponse SelectedIntentResponse { get; set; }
        public State SelectedState { get; set; }


        public frmRecordAudio()
        {
            InitializeComponent();
            SelectedIntentResponse = null;
            SelectedState = null;
            Rep = new ConversationsRepository();
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
            barVolume.Value = (int)(Math.Max(e.MaxSample, Math.Abs(e.MinSample)) * 100);
        }


        private void Message(string aMessage)
        {
            Console.WriteLine(aMessage);
            txtOutput.Text += aMessage + Environment.NewLine;
        }


        private void frmRecordAudio_Load(object sender, EventArgs e)
        {

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


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedIntentResponse != null)
                {
                    string randomFilename = Path.GetRandomFileName();
                    string aDirectoryName = $"{Rep.CharacterDB.ClassDirectory}\\{SelectedState.Id}\\{SelectedIntentResponse.Id}";
                    Directory.CreateDirectory(aDirectoryName);
                    string aFilename = $"{aDirectoryName}\\{randomFilename}.wav";
                    Message($"Recording to file: {aFilename}");
                    var fi = new FileInfo(aFilename); // will throw an error if not a valid filename
                    wavefilesaver = new WavefileSaver(audio, aFilename);
                    lblLight.Visible = true;
                    btnStart.Enabled = false;
                    audio.StartRecordingAudioAsync();
                }
                else
                {
                    Message("Can't Record until you select a response.");
                }
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

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            lstStates.Items.Clear();
            SelectedState = null;
            lstResponses.Items.Clear();
            SelectedIntentResponse = null;
            chr = Rep.CharacterDB.GetById(txtCharacterName.Text);
            foreach (var item in chr.StateList)
            {
                lstStates.Items.Add(item);
            }
        }

        private void lstStates_SelectedValueChanged(object sender, EventArgs e)
        {
            lstResponses.Items.Clear();
            SelectedIntentResponse = null;
            if (lstStates.SelectedItem != null)
            {
                SelectedState = (State)lstStates.SelectedItem;
                foreach (var item in SelectedState.IntentResponseList)
                {
                    lstResponses.Items.Add(item);
                }
            }
        }

        private void lstResponses_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstResponses.SelectedItem != null)
            {
                SelectedIntentResponse = (IntentResponse)lstResponses.SelectedItem;
                prgResponseDetails.SelectedObject = SelectedIntentResponse;
            }
        }
    }
}
