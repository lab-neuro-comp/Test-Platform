namespace StroopTest
{
    partial class FormNewAudio
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.recordingLabel = new System.Windows.Forms.Label();
            this.currentElapsedTimeDisplay = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.stopRecordingButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(34, 134);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 51;
            this.cancelButton.Text = "fechar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // recordingLabel
            // 
            this.recordingLabel.AutoSize = true;
            this.recordingLabel.ForeColor = System.Drawing.Color.Red;
            this.recordingLabel.Location = new System.Drawing.Point(124, 46);
            this.recordingLabel.Name = "recordingLabel";
            this.recordingLabel.Size = new System.Drawing.Size(71, 17);
            this.recordingLabel.TabIndex = 83;
            this.recordingLabel.Text = "Gravando";
            // 
            // currentElapsedTimeDisplay
            // 
            this.currentElapsedTimeDisplay.AutoSize = true;
            this.currentElapsedTimeDisplay.ForeColor = System.Drawing.Color.Red;
            this.currentElapsedTimeDisplay.Location = new System.Drawing.Point(31, 90);
            this.currentElapsedTimeDisplay.Name = "currentElapsedTimeDisplay";
            this.currentElapsedTimeDisplay.Size = new System.Drawing.Size(24, 17);
            this.currentElapsedTimeDisplay.TabIndex = 85;
            this.currentElapsedTimeDisplay.Text = "00";
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.Location = new System.Drawing.Point(233, 38);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 32);
            this.helpButton.TabIndex = 82;
            this.helpButton.Text = "s";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // stopRecordingButton
            // 
            this.stopRecordingButton.FlatAppearance.BorderSize = 0;
            this.stopRecordingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopRecordingButton.Image = global::TestPlatform.Properties.Resources.stopButton;
            this.stopRecordingButton.Location = new System.Drawing.Point(73, 35);
            this.stopRecordingButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopRecordingButton.Name = "stopRecordingButton";
            this.stopRecordingButton.Size = new System.Drawing.Size(35, 28);
            this.stopRecordingButton.TabIndex = 49;
            this.stopRecordingButton.UseVisualStyleBackColor = true;
            this.stopRecordingButton.Click += new System.EventHandler(this.stopRecordingButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.FlatAppearance.BorderSize = 0;
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordButton.Image = global::TestPlatform.Properties.Resources.icon_audio;
            this.recordButton.Location = new System.Drawing.Point(24, 35);
            this.recordButton.Margin = new System.Windows.Forms.Padding(4);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(31, 28);
            this.recordButton.TabIndex = 48;
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordingButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(275, 151);
            this.flowLayoutPanel1.TabIndex = 86;
            // 
            // FormNewAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.currentElapsedTimeDisplay);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.recordingLabel);
            this.Controls.Add(this.stopRecordingButton);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormNewAudio";
            this.Size = new System.Drawing.Size(725, 785);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stopRecordingButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label recordingLabel;
        private System.Windows.Forms.Label currentElapsedTimeDisplay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}