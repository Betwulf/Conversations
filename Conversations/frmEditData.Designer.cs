namespace Conversations
{
    partial class frmEditData
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
            this.btnNewCharacter = new System.Windows.Forms.Button();
            this.prgEdit = new System.Windows.Forms.PropertyGrid();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnNewParts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewCharacter
            // 
            this.btnNewCharacter.Location = new System.Drawing.Point(18, 38);
            this.btnNewCharacter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewCharacter.Name = "btnNewCharacter";
            this.btnNewCharacter.Size = new System.Drawing.Size(159, 35);
            this.btnNewCharacter.TabIndex = 0;
            this.btnNewCharacter.Text = "New Character";
            this.btnNewCharacter.UseVisualStyleBackColor = true;
            this.btnNewCharacter.Click += new System.EventHandler(this.btnNewCharacter_Click);
            // 
            // prgEdit
            // 
            this.prgEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgEdit.Location = new System.Drawing.Point(444, 18);
            this.prgEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prgEdit.Name = "prgEdit";
            this.prgEdit.Size = new System.Drawing.Size(462, 543);
            this.prgEdit.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(18, 526);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(159, 35);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(186, 526);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(159, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtId.Location = new System.Drawing.Point(56, 483);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(288, 26);
            this.txtId.TabIndex = 6;
            this.txtId.Text = "Bartender";
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(18, 487);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 20);
            this.lblId.TabIndex = 7;
            this.lblId.Text = "Id:";
            // 
            // btnNewParts
            // 
            this.btnNewParts.Location = new System.Drawing.Point(18, 83);
            this.btnNewParts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewParts.Name = "btnNewParts";
            this.btnNewParts.Size = new System.Drawing.Size(159, 35);
            this.btnNewParts.TabIndex = 8;
            this.btnNewParts.Text = "New Conv Parts";
            this.btnNewParts.UseVisualStyleBackColor = true;
            this.btnNewParts.Click += new System.EventHandler(this.btnNewParts_Click);
            // 
            // frmEditData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 580);
            this.Controls.Add(this.btnNewParts);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.prgEdit);
            this.Controls.Add(this.btnNewCharacter);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmEditData";
            this.Text = "frmEditData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewCharacter;
        private System.Windows.Forms.PropertyGrid prgEdit;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnNewParts;
    }
}