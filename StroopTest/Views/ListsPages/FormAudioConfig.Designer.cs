namespace TestPlatform
{
    partial class FormAudioConfig
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAudioConfig));
            this.audioListNameLabel = new System.Windows.Forms.Label();
            this.audioListNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteItemlabel = new System.Windows.Forms.Label();
            this.audioLabel = new System.Windows.Forms.Label();
            this.moveRowLabel = new System.Windows.Forms.Label();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.audioPathDataGridView = new System.Windows.Forms.DataGridView();
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.playAudioButton = new System.Windows.Forms.Button();
            this.numberFilesLabel = new System.Windows.Forms.Label();
            this.numberFiles = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelEmpty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.audioPathDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // audioListNameLabel
            // 
            resources.ApplyResources(this.audioListNameLabel, "audioListNameLabel");
            this.audioListNameLabel.Name = "audioListNameLabel";
            // 
            // audioListNameTextBox
            // 
            resources.ApplyResources(this.audioListNameTextBox, "audioListNameTextBox");
            this.audioListNameTextBox.Name = "audioListNameTextBox";
            this.audioListNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.audioListNameTextBox_Validating);
            this.audioListNameTextBox.Validated += new System.EventHandler(this.audioListNameTextBox_Validated);
            // 
            // deleteItemlabel
            // 
            resources.ApplyResources(this.deleteItemlabel, "deleteItemlabel");
            this.deleteItemlabel.Name = "deleteItemlabel";
            // 
            // audioLabel
            // 
            resources.ApplyResources(this.audioLabel, "audioLabel");
            this.audioLabel.Name = "audioLabel";
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
            this.audioPathDataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.listLength_Validating);
            this.audioPathDataGridView.Validated += new System.EventHandler(this.listLength_Validated);
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
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // openButton
            // 
            resources.ApplyResources(this.openButton, "openButton");
            this.openButton.CausesValidation = false;
            this.openButton.Name = "openButton";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
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
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // labelEmpty
            // 
            resources.ApplyResources(this.labelEmpty, "labelEmpty");
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Name = "labelEmpty";
            // 
            // FormAudioConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.labelEmpty);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.numberFiles);
            this.Controls.Add(this.numberFilesLabel);
            this.Controls.Add(this.playAudioButton);
            this.Controls.Add(this.audioListNameLabel);
            this.Controls.Add(this.audioListNameTextBox);
            this.Controls.Add(this.deleteItemlabel);
            this.Controls.Add(this.audioLabel);
            this.Controls.Add(this.moveRowLabel);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.audioPathDataGridView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.openButton);
            this.Name = "FormAudioConfig";
            ((System.ComponentModel.ISupportInitialize)(this.audioPathDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label audioListNameLabel;
        private System.Windows.Forms.TextBox audioListNameTextBox;
        private System.Windows.Forms.Label deleteItemlabel;
        private System.Windows.Forms.Label audioLabel;
        private System.Windows.Forms.Label moveRowLabel;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.DataGridView audioPathDataGridView;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button playAudioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathColumn;
        private System.Windows.Forms.Label numberFilesLabel;
        private System.Windows.Forms.Label numberFiles;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelEmpty;
    }
}