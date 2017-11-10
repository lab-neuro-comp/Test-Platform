namespace TestPlatform
{
    partial class FormImgConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImgConfig));
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.imgPathDataGridView = new System.Windows.Forms.DataGridView();
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thumbnailColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.filePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveRowLabel = new System.Windows.Forms.Label();
            this.imagesLabel = new System.Windows.Forms.Label();
            this.deleteItemLabel = new System.Windows.Forms.Label();
            this.imgListNameTextBox = new System.Windows.Forms.TextBox();
            this.imgListNameLabel = new System.Windows.Forms.Label();
            this.numberFilesLabel = new System.Windows.Forms.Label();
            this.numberFiles = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelEmpty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPathDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.CausesValidation = false;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // deleteItemButton
            // 
            resources.ApplyResources(this.deleteItemButton, "deleteItemButton");
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteRow_Click);
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
            // imgPathDataGridView
            // 
            this.imgPathDataGridView.AllowUserToAddRows = false;
            this.imgPathDataGridView.AllowUserToOrderColumns = true;
            this.imgPathDataGridView.AllowUserToResizeRows = false;
            this.imgPathDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.imgPathDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.imgPathDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameColumn,
            this.thumbnailColumn,
            this.filePathColumn});
            resources.ApplyResources(this.imgPathDataGridView, "imgPathDataGridView");
            this.imgPathDataGridView.MultiSelect = false;
            this.imgPathDataGridView.Name = "imgPathDataGridView";
            this.imgPathDataGridView.ReadOnly = true;
            this.imgPathDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.imgPathDataGridView.RowHeadersVisible = false;
            this.imgPathDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.imgPathDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.imgPathDataGridView_CellContentClick);
            this.imgPathDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.imgPathDataGridView_CellMouseClick);
            this.imgPathDataGridView.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.imgPathDataGridView_CellStateChanged);
            this.imgPathDataGridView.SelectionChanged += new System.EventHandler(this.imgPathDataGridView_SelectionChanged);
            this.imgPathDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imgPathDataGridView_KeyDown);
            this.imgPathDataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.listLength_Validating);
            this.imgPathDataGridView.Validated += new System.EventHandler(this.listLength_Validated);
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fileNameColumn.FillWeight = 187.013F;
            resources.ApplyResources(this.fileNameColumn, "fileNameColumn");
            this.fileNameColumn.Name = "fileNameColumn";
            this.fileNameColumn.ReadOnly = true;
            // 
            // thumbnailColumn
            // 
            this.thumbnailColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.thumbnailColumn, "thumbnailColumn");
            this.thumbnailColumn.Name = "thumbnailColumn";
            this.thumbnailColumn.ReadOnly = true;
            this.thumbnailColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // filePathColumn
            // 
            this.filePathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filePathColumn.FillWeight = 12.98701F;
            resources.ApplyResources(this.filePathColumn, "filePathColumn");
            this.filePathColumn.Name = "filePathColumn";
            this.filePathColumn.ReadOnly = true;
            // 
            // moveUpButton
            // 
            resources.ApplyResources(this.moveUpButton, "moveUpButton");
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // moveDownButton
            // 
            resources.ApplyResources(this.moveDownButton, "moveDownButton");
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // moveRowLabel
            // 
            resources.ApplyResources(this.moveRowLabel, "moveRowLabel");
            this.moveRowLabel.Name = "moveRowLabel";
            // 
            // imagesLabel
            // 
            resources.ApplyResources(this.imagesLabel, "imagesLabel");
            this.imagesLabel.Name = "imagesLabel";
            // 
            // deleteItemLabel
            // 
            resources.ApplyResources(this.deleteItemLabel, "deleteItemLabel");
            this.deleteItemLabel.Name = "deleteItemLabel";
            // 
            // imgListNameTextBox
            // 
            resources.ApplyResources(this.imgListNameTextBox, "imgListNameTextBox");
            this.imgListNameTextBox.Name = "imgListNameTextBox";
            this.imgListNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.listName_Validating);
            this.imgListNameTextBox.Validated += new System.EventHandler(this.listName_Validated);
            // 
            // imgListNameLabel
            // 
            resources.ApplyResources(this.imgListNameLabel, "imgListNameLabel");
            this.imgListNameLabel.Name = "imgListNameLabel";
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
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelEmpty
            // 
            resources.ApplyResources(this.labelEmpty, "labelEmpty");
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Name = "labelEmpty";
            // 
            // FormImgConfig
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.labelEmpty);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.numberFiles);
            this.Controls.Add(this.numberFilesLabel);
            this.Controls.Add(this.imgListNameLabel);
            this.Controls.Add(this.imgListNameTextBox);
            this.Controls.Add(this.deleteItemLabel);
            this.Controls.Add(this.imagesLabel);
            this.Controls.Add(this.moveRowLabel);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.imgPathDataGridView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnOpen);
            this.Name = "FormImgConfig";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPathDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button deleteItemButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView imgPathDataGridView;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Label moveRowLabel;
        private System.Windows.Forms.Label imagesLabel;
        private System.Windows.Forms.Label deleteItemLabel;
        private System.Windows.Forms.TextBox imgListNameTextBox;
        private System.Windows.Forms.Label imgListNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameColumn;
        private System.Windows.Forms.DataGridViewImageColumn thumbnailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathColumn;
        private System.Windows.Forms.Label numberFilesLabel;
        private System.Windows.Forms.Label numberFiles;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelEmpty;
    }
}