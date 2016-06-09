namespace Conversations
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnStopConversation = new System.Windows.Forms.Button();
            this.lblLight = new System.Windows.Forms.Label();
            this.btnEditData = new System.Windows.Forms.Button();
            this.barVolume = new System.Windows.Forms.ProgressBar();
            this.btnRecordAudio = new System.Windows.Forms.Button();
            this.lblSample = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 18);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(177, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Conversation";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(232, 18);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(718, 533);
            this.txtOutput.TabIndex = 1;
            // 
            // btnStopConversation
            // 
            this.btnStopConversation.Location = new System.Drawing.Point(18, 131);
            this.btnStopConversation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStopConversation.Name = "btnStopConversation";
            this.btnStopConversation.Size = new System.Drawing.Size(177, 35);
            this.btnStopConversation.TabIndex = 2;
            this.btnStopConversation.Text = "End Conversation";
            this.btnStopConversation.UseVisualStyleBackColor = true;
            this.btnStopConversation.Click += new System.EventHandler(this.btnStopConversation_Click);
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.BackColor = System.Drawing.Color.Red;
            this.lblLight.Location = new System.Drawing.Point(94, 78);
            this.lblLight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(13, 20);
            this.lblLight.TabIndex = 3;
            this.lblLight.Text = " ";
            this.lblLight.Visible = false;
            // 
            // btnEditData
            // 
            this.btnEditData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditData.Location = new System.Drawing.Point(18, 522);
            this.btnEditData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(177, 35);
            this.btnEditData.TabIndex = 4;
            this.btnEditData.Text = "Edit Data...";
            this.btnEditData.UseVisualStyleBackColor = true;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // barVolume
            // 
            this.barVolume.ForeColor = System.Drawing.Color.Red;
            this.barVolume.Location = new System.Drawing.Point(20, 177);
            this.barVolume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barVolume.Name = "barVolume";
            this.barVolume.Size = new System.Drawing.Size(176, 35);
            this.barVolume.TabIndex = 5;
            // 
            // btnRecordAudio
            // 
            this.btnRecordAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecordAudio.Location = new System.Drawing.Point(18, 477);
            this.btnRecordAudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecordAudio.Name = "btnRecordAudio";
            this.btnRecordAudio.Size = new System.Drawing.Size(177, 35);
            this.btnRecordAudio.TabIndex = 6;
            this.btnRecordAudio.Text = "Make Recordings...";
            this.btnRecordAudio.UseVisualStyleBackColor = true;
            this.btnRecordAudio.Click += new System.EventHandler(this.btnRecordAudio_Click);
            // 
            // lblSample
            // 
            this.lblSample.AutoSize = true;
            this.lblSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSample.Location = new System.Drawing.Point(18, 234);
            this.lblSample.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(84, 24);
            this.lblSample.TabIndex = 7;
            this.lblSample.Text = "Sample: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 572);
            this.Controls.Add(this.lblSample);
            this.Controls.Add(this.btnRecordAudio);
            this.Controls.Add(this.barVolume);
            this.Controls.Add(this.btnEditData);
            this.Controls.Add(this.lblLight);
            this.Controls.Add(this.btnStopConversation);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Conversations";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnStopConversation;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.ProgressBar barVolume;
        private System.Windows.Forms.Button btnRecordAudio;
        private System.Windows.Forms.Label lblSample;
    }
}

