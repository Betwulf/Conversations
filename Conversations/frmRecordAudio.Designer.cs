namespace Conversations
{
    partial class frmRecordAudio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecordAudio));
            this.prgResponseDetails = new System.Windows.Forms.PropertyGrid();
            this.barVolume = new System.Windows.Forms.ProgressBar();
            this.lblLight = new System.Windows.Forms.Label();
            this.btnStopConversation = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstStates = new System.Windows.Forms.ListBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtCharacterName = new System.Windows.Forms.TextBox();
            this.lstResponses = new System.Windows.Forms.ListBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // prgResponseDetails
            // 
            this.prgResponseDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgResponseDetails.Location = new System.Drawing.Point(13, 456);
            this.prgResponseDetails.Name = "prgResponseDetails";
            this.prgResponseDetails.Size = new System.Drawing.Size(374, 266);
            this.prgResponseDetails.TabIndex = 0;
            // 
            // barVolume
            // 
            this.barVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.barVolume.ForeColor = System.Drawing.Color.Red;
            this.barVolume.Location = new System.Drawing.Point(525, 167);
            this.barVolume.Name = "barVolume";
            this.barVolume.Size = new System.Drawing.Size(118, 23);
            this.barVolume.TabIndex = 9;
            // 
            // lblLight
            // 
            this.lblLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLight.AutoSize = true;
            this.lblLight.BackColor = System.Drawing.Color.Red;
            this.lblLight.Location = new System.Drawing.Point(576, 113);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(10, 13);
            this.lblLight.TabIndex = 8;
            this.lblLight.Text = " ";
            this.lblLight.Visible = false;
            // 
            // btnStopConversation
            // 
            this.btnStopConversation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopConversation.Location = new System.Drawing.Point(524, 137);
            this.btnStopConversation.Name = "btnStopConversation";
            this.btnStopConversation.Size = new System.Drawing.Size(119, 23);
            this.btnStopConversation.TabIndex = 7;
            this.btnStopConversation.Text = "End Conversation";
            this.btnStopConversation.UseVisualStyleBackColor = true;
            this.btnStopConversation.Click += new System.EventHandler(this.btnStopConversation_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(525, 74);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start Conversation";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstStates
            // 
            this.lstStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStates.FormattingEnabled = true;
            this.lstStates.Location = new System.Drawing.Point(13, 13);
            this.lstStates.Name = "lstStates";
            this.lstStates.Size = new System.Drawing.Size(374, 186);
            this.lstStates.TabIndex = 10;
            this.lstStates.SelectedValueChanged += new System.EventHandler(this.lstStates_SelectedValueChanged);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFile.Location = new System.Drawing.Point(525, 13);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(118, 23);
            this.btnLoadFile.TabIndex = 11;
            this.btnLoadFile.Text = "Load";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCharacterName.Location = new System.Drawing.Point(525, 43);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(118, 20);
            this.txtCharacterName.TabIndex = 12;
            this.txtCharacterName.Text = "Bartender";
            // 
            // lstResponses
            // 
            this.lstResponses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResponses.FormattingEnabled = true;
            this.lstResponses.Location = new System.Drawing.Point(12, 205);
            this.lstResponses.Name = "lstResponses";
            this.lstResponses.Size = new System.Drawing.Size(374, 238);
            this.lstResponses.TabIndex = 13;
            this.lstResponses.SelectedValueChanged += new System.EventHandler(this.lstResponses_SelectedValueChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(393, 206);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(250, 516);
            this.txtOutput.TabIndex = 14;
            // 
            // frmRecordAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 734);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lstResponses);
            this.Controls.Add(this.txtCharacterName);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.lstStates);
            this.Controls.Add(this.barVolume);
            this.Controls.Add(this.lblLight);
            this.Controls.Add(this.btnStopConversation);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.prgResponseDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecordAudio";
            this.Text = "frmRecordAudio";
            this.Load += new System.EventHandler(this.frmRecordAudio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid prgResponseDetails;
        private System.Windows.Forms.ProgressBar barVolume;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.Button btnStopConversation;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstStates;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtCharacterName;
        private System.Windows.Forms.ListBox lstResponses;
        private System.Windows.Forms.TextBox txtOutput;
    }
}