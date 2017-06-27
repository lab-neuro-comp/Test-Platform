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
            this.moveRowLabel = new System.Windows.Forms.Label();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.audioPathDataGridView = new System.Windows.Forms.DataGridView();
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
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.audioPathDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // moveRowLabel
            // 
            this.moveRowLabel.AutoSize = true;
            this.moveRowLabel.Location = new System.Drawing.Point(16, 366);
            this.moveRowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moveRowLabel.Name = "moveRowLabel";
            this.moveRowLabel.Size = new System.Drawing.Size(81, 17);
            this.moveRowLabel.TabIndex = 52;
            this.moveRowLabel.Text = "Mover item:";
            // 
            // moveDownButton
            // 
            this.moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveDownButton.Location = new System.Drawing.Point(16, 422);
            this.moveDownButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(181, 28);
            this.moveDownButton.TabIndex = 49;
            this.moveDownButton.Text = "Abaixo";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveUpButton.Location = new System.Drawing.Point(16, 386);
            this.moveUpButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(181, 28);
            this.moveUpButton.TabIndex = 48;
            this.moveUpButton.Text = "Acima";
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
            this.audioPathDataGridView.Location = new System.Drawing.Point(220, 210);
            this.audioPathDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.audioPathDataGridView.MultiSelect = false;
            this.audioPathDataGridView.Name = "audioPathDataGridView";
            this.audioPathDataGridView.ReadOnly = true;
            this.audioPathDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.audioPathDataGridView.RowHeadersVisible = false;
            this.audioPathDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.audioPathDataGridView.Size = new System.Drawing.Size(693, 537);
            this.audioPathDataGridView.TabIndex = 44;
            this.audioPathDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.audioPathDataGridView_CellContentDoubleClick);
            this.audioPathDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.audioPathDataGridView_KeyDown);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeButton.Location = new System.Drawing.Point(19, 755);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 28);
            this.closeButton.TabIndex = 51;
            this.closeButton.Text = "fechar";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // playAudioButton
            // 
            this.playAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playAudioButton.Location = new System.Drawing.Point(16, 282);
            this.playAudioButton.Margin = new System.Windows.Forms.Padding(4);
            this.playAudioButton.Name = "playAudioButton";
            this.playAudioButton.Size = new System.Drawing.Size(181, 28);
            this.playAudioButton.TabIndex = 56;
            this.playAudioButton.Text = "Reproduzir Áudio";
            this.playAudioButton.UseVisualStyleBackColor = true;
            this.playAudioButton.Click += new System.EventHandler(this.playAudioButton_Click);
            // 
            // numberFilesLabel
            // 
            this.numberFilesLabel.AutoSize = true;
            this.numberFilesLabel.Location = new System.Drawing.Point(217, 755);
            this.numberFilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberFilesLabel.Name = "numberFilesLabel";
            this.numberFilesLabel.Size = new System.Drawing.Size(164, 17);
            this.numberFilesLabel.TabIndex = 58;
            this.numberFilesLabel.Text = "Quantidade de arquivos:";
            // 
            // numberFiles
            // 
            this.numberFiles.AutoSize = true;
            this.numberFiles.Location = new System.Drawing.Point(403, 755);
            this.numberFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberFiles.Name = "numberFiles";
            this.numberFiles.Size = new System.Drawing.Size(16, 17);
            this.numberFiles.TabIndex = 59;
            this.numberFiles.Text = "0";
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.Location = new System.Drawing.Point(878, 35);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 32);
            this.helpButton.TabIndex = 82;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // stopAudio
            // 
            this.stopAudio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopAudio.Location = new System.Drawing.Point(16, 318);
            this.stopAudio.Margin = new System.Windows.Forms.Padding(4);
            this.stopAudio.Name = "stopAudio";
            this.stopAudio.Size = new System.Drawing.Size(181, 28);
            this.stopAudio.TabIndex = 83;
            this.stopAudio.Text = "Parar Reprodução";
            this.stopAudio.UseVisualStyleBackColor = true;
            this.stopAudio.Click += new System.EventHandler(this.stopAudio_Click);
            // 
            // currentFolderLabel
            // 
            this.currentFolderLabel.AutoSize = true;
            this.currentFolderLabel.Location = new System.Drawing.Point(217, 183);
            this.currentFolderLabel.Name = "currentFolderLabel";
            this.currentFolderLabel.Size = new System.Drawing.Size(101, 17);
            this.currentFolderLabel.TabIndex = 84;
            this.currentFolderLabel.Text = "Diretório atual:";
            // 
            // directoryButton
            // 
            this.directoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.directoryButton.Location = new System.Drawing.Point(13, 240);
            this.directoryButton.Margin = new System.Windows.Forms.Padding(4);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(181, 28);
            this.directoryButton.TabIndex = 85;
            this.directoryButton.Text = "Alterar diretório";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // currenFolderLabel
            // 
            this.currenFolderLabel.AutoSize = true;
            this.currenFolderLabel.Location = new System.Drawing.Point(318, 183);
            this.currenFolderLabel.Name = "currenFolderLabel";
            this.currenFolderLabel.Size = new System.Drawing.Size(0, 17);
            this.currenFolderLabel.TabIndex = 86;
            // 
            // currentElapsedTimeDisplay
            // 
            this.currentElapsedTimeDisplay.AutoSize = true;
            this.currentElapsedTimeDisplay.ForeColor = System.Drawing.Color.Red;
            this.currentElapsedTimeDisplay.Location = new System.Drawing.Point(234, 63);
            this.currentElapsedTimeDisplay.Name = "currentElapsedTimeDisplay";
            this.currentElapsedTimeDisplay.Size = new System.Drawing.Size(24, 17);
            this.currentElapsedTimeDisplay.TabIndex = 90;
            this.currentElapsedTimeDisplay.Text = "00";
            // 
            // recordingLabel
            // 
            this.recordingLabel.AutoSize = true;
            this.recordingLabel.ForeColor = System.Drawing.Color.Red;
            this.recordingLabel.Location = new System.Drawing.Point(287, 63);
            this.recordingLabel.Name = "recordingLabel";
            this.recordingLabel.Size = new System.Drawing.Size(71, 17);
            this.recordingLabel.TabIndex = 89;
            this.recordingLabel.Text = "Gravando";
            // 
            // stopRecordingButton
            // 
            this.stopRecordingButton.FlatAppearance.BorderSize = 0;
            this.stopRecordingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopRecordingButton.Location = new System.Drawing.Point(398, 91);
            this.stopRecordingButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopRecordingButton.Name = "stopRecordingButton";
            this.stopRecordingButton.Size = new System.Drawing.Size(144, 28);
            this.stopRecordingButton.TabIndex = 88;
            this.stopRecordingButton.Text = "Parar gravação";
            this.stopRecordingButton.UseVisualStyleBackColor = true;
            this.stopRecordingButton.Click += new System.EventHandler(this.stopRecordingButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.FlatAppearance.BorderSize = 0;
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recordButton.Location = new System.Drawing.Point(237, 91);
            this.recordButton.Margin = new System.Windows.Forms.Padding(4);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(121, 28);
            this.recordButton.TabIndex = 87;
            this.recordButton.Text = "Gravar Aúdio";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordingButton_Click);
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fileNameColumn.FillWeight = 187.013F;
            this.fileNameColumn.HeaderText = "Nome do Arquivo";
            this.fileNameColumn.Name = "fileNameColumn";
            this.fileNameColumn.ReadOnly = true;
            this.fileNameColumn.Width = 200;
            // 
            // filePathColumn
            // 
            this.filePathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filePathColumn.FillWeight = 12.98701F;
            this.filePathColumn.HeaderText = "Localização";
            this.filePathColumn.Name = "filePathColumn";
            this.filePathColumn.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(220, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 99);
            this.panel1.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Novo Aúdio";
            // 
            // FormShowAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentElapsedTimeDisplay);
            this.Controls.Add(this.recordingLabel);
            this.Controls.Add(this.stopRecordingButton);
            this.Controls.Add(this.recordButton);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShowAudio";
            this.Size = new System.Drawing.Size(928, 810);
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
    }
}