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
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 23);
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
            this.txtOutput.Location = new System.Drawing.Point(155, 12);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(270, 486);
            this.txtOutput.TabIndex = 1;
            // 
            // btnStopConversation
            // 
            this.btnStopConversation.Location = new System.Drawing.Point(12, 85);
            this.btnStopConversation.Name = "btnStopConversation";
            this.btnStopConversation.Size = new System.Drawing.Size(118, 23);
            this.btnStopConversation.TabIndex = 2;
            this.btnStopConversation.Text = "End Conversation";
            this.btnStopConversation.UseVisualStyleBackColor = true;
            this.btnStopConversation.Click += new System.EventHandler(this.btnStopConversation_Click);
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.BackColor = System.Drawing.Color.Red;
            this.lblLight.Location = new System.Drawing.Point(63, 51);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(10, 13);
            this.lblLight.TabIndex = 3;
            this.lblLight.Text = " ";
            this.lblLight.Visible = false;
            // 
            // btnEditData
            // 
            this.btnEditData.Location = new System.Drawing.Point(12, 475);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(118, 23);
            this.btnEditData.TabIndex = 4;
            this.btnEditData.Text = "Edit Data...";
            this.btnEditData.UseVisualStyleBackColor = true;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 510);
            this.Controls.Add(this.btnEditData);
            this.Controls.Add(this.lblLight);
            this.Controls.Add(this.btnStopConversation);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Conversations";
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
    }
}

