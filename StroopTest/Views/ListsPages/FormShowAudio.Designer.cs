namespace TestPlatform
{
    partial class FormShowAudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowAudio));
            this.moveRowLabel = new System.Windows.Forms.Label();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.audioPathDataGridView = new System.Windows.Forms.DataGridView();
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.playAudioButton = new System.Windows.Forms.Button();
            this.numberFilesLabel = new System.Windows.Forms.Label();
            this.numberFiles = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.stopAudio = new System.Windows.Forms.Button();
            this.currentFolderLabel = new System.Windows.Forms.Label();
            this.directoryButton = new System.Windows.Forms.Button();
            this.currenFolderLabel = new System.Windows.Forms.Label();
            this.currentElapsedTimeDisplay = new System.Windows.Forms.Label();
            this.recordingLabel = new System.Windows.Forms.Label();
            this.stopRecordingButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recordButton1 = new System.Windows.Forms.Button();
            this.selectedDirectory = new System.Windows.Forms.Label();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.audioPathDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // moveRowLabel
            // 
            resources.ApplyResources(this.moveRowLabel, "moveRowLabel");
            this.moveRowLabel.Name = "moveRowLabel";
            // 
            // moveDownButton
            // 
            resources.ApplyResources(this.moveDownButton, "moveDownButton");
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            resources.ApplyResources(this.moveUpButton, "moveUpButton");
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // audioPathDataGridView
            // 
            this.audioPathDataGridView.AllowUserToAddRows = false;
            this.audioPathDataGridView.AllowUserToOrderColumns = true;
            this.audioPathDataGridView.AllowUserToResizeRows = false;
            this.audioPathDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.audioPathDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.audioPathDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameColumn,
            this.filePathColumn});
            resources.ApplyResources(this.audioPathDataGridView, "audioPathDataGridView");
            this.audioPathDataGridView.MultiSelect = false;
            this.audioPathDataGridView.Name = "audioPathDataGridView";
            this.audioPathDataGridView.ReadOnly = true;
            this.audioPathDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.audioPathDataGridView.RowHeadersVisible = false;
            this.audioPathDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.audioPathDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.audioPathDataGridView_CellContentDoubleClick);
            this.audioPathDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.audioPathDataGridView_KeyDown);
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fileNameColumn.FillWeight = 187.013F;
            resources.ApplyResources(this.fileNameColumn, "fileNameColumn");
            this.fileNameColumn.Name = "fileNameColumn";
            this.fileNameColumn.ReadOnly = true;
            // 
            // filePathColumn
            // 
            this.filePathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filePathColumn.FillWeight = 12.98701F;
            resources.ApplyResources(this.filePathColumn, "filePathColumn");
            this.filePathColumn.Name = "filePathColumn";
            this.filePathColumn.ReadOnly = true;
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // playAudioButton
            // 
            resources.ApplyResources(this.playAudioButton, "playAudioButton");
            this.playAudioButton.Name = "playAudioButton";
            this.playAudioButton.UseVisualStyleBackColor = true;
            this.playAudioButton.Click += new System.EventHandler(this.playAudioButton_Click);
            // 
            // numberFilesLabel
            // 
            resources.ApplyResources(this.numberFilesLabel, "numberFilesLabel");
            this.numberFilesLabel.Name = "numberFilesLabel";
            // 
            // numberFiles
            // 
            resources.ApplyResources(this.numberFiles, "numberFiles");
            this.numberFiles.Name = "numberFiles";
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // stopAudio
            // 
            resources.ApplyResources(this.stopAudio, "stopAudio");
            this.stopAudio.Name = "stopAudio";
            this.stopAudio.UseVisualStyleBackColor = true;
            this.stopAudio.Click += new System.EventHandler(this.stopAudio_Click);
            // 
            // currentFolderLabel
            // 
            resources.ApplyResources(this.currentFolderLabel, "currentFolderLabel");
            this.currentFolderLabel.Name = "currentFolderLabel";
            // 
            // directoryButton
            // 
            resources.ApplyResources(this.directoryButton, "directoryButton");
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // currenFolderLabel
            // 
            this.currenFolderLabel.AutoEllipsis = true;
            resources.ApplyResources(this.currenFolderLabel, "currenFolderLabel");
            this.currenFolderLabel.Name = "currenFolderLabel";
            // 
            // currentElapsedTimeDisplay
            // 
            resources.ApplyResources(this.currentElapsedTimeDisplay, "currentElapsedTimeDisplay");
            this.currentElapsedTimeDisplay.ForeColor = System.Drawing.Color.Red;
            this.currentElapsedTimeDisplay.Name = "currentElapsedTimeDisplay";
            // 
            // recordingLabel
            // 
            resources.ApplyResources(this.recordingLabel, "recordingLabel");
            this.recordingLabel.ForeColor = System.Drawing.Color.Red;
            this.recordingLabel.Name = "recordingLabel";
            // 
            // stopRecordingButton
            // 
            this.stopRecordingButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.stopRecordingButton, "stopRecordingButton");
            this.stopRecordingButton.Name = "stopRecordingButton";
            this.stopRecordingButton.UseVisualStyleBackColor = true;
            this.stopRecordingButton.Click += new System.EventHandler(this.stopRecordingButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.recordButton, "recordButton");
            this.recordButton.Name = "recordButton";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordingButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.currentElapsedTimeDisplay);
            this.panel1.Controls.Add(this.recordButton1);
            this.panel1.Controls.Add(this.recordButton);
            this.panel1.Controls.Add(this.selectedDirectory);
            this.panel1.Controls.Add(this.directoryLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.stopRecordingButton);
            this.panel1.Controls.Add(this.recordingLabel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // recordButton1
            // 
            this.recordButton1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.recordButton1, "recordButton1");
            this.recordButton1.Name = "recordButton1";
            this.recordButton1.UseVisualStyleBackColor = true;
            this.recordButton1.Click += new System.EventHandler(this.recordButton1_Click);
            // 
            // selectedDirectory
            // 
            resources.ApplyResources(this.selectedDirectory, "selectedDirectory");
            this.selectedDirectory.Name = "selectedDirectory";
            // 
            // directoryLabel
            // 
            resources.ApplyResources(this.directoryLabel, "directoryLabel");
            this.directoryLabel.Name = "directoryLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormShowAudio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currenFolderLabel);
            this.Controls.Add(this.directoryButton);
            this.Controls.Add(this.currentFolderLabel);
            this.Controls.Add(this.stopAudio);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.numberFiles);
            this.Controls.Add(this.numberFilesLabel);
            this.Controls.Add(this.playAudioButton);
            this.Controls.Add(this.moveRowLabel);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.audioPathDataGridView);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel1);
            this.Name = "FormShowAudio";
            ((System.ComponentModel.ISupportInitialize)(this.audioPathDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label moveRowLabel;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.DataGridView audioPathDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button playAudioButton;
        private System.Windows.Forms.Label numberFilesLabel;
        private System.Windows.Forms.Label numberFiles;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button stopAudio;
        private System.Windows.Forms.Label currentFolderLabel;
        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.Label currenFolderLabel;
        private System.Windows.Forms.Label currentElapsedTimeDisplay;
        private System.Windows.Forms.Label recordingLabel;
        private System.Windows.Forms.Button stopRecordingButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectedDirectory;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Button recordButton1;
    }
}