namespace StroopTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImgConfig));
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.imgPathDataGridView = new System.Windows.Forms.DataGridView();
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thumbnailColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.filePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveRowLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgListNameTextBox = new System.Windows.Forms.TextBox();
            this.imgListNameLabel = new System.Windows.Forms.Label();
            this.numberFilesLabel = new System.Windows.Forms.Label();
            this.numberFiles = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPathDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpen.Location = new System.Drawing.Point(19, 87);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(136, 23);
            this.btnOpen.TabIndex = 20;
            this.btnOpen.Text = "Abrir";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(171, 42);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(279, 220);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(19, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Apagar (Delete)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.deleteRow_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(375, 515);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(22, 515);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 30;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // imgPathDataGridView
            // 
            this.imgPathDataGridView.AllowUserToAddRows = false;
            this.imgPathDataGridView.AllowUserToOrderColumns = true;
            this.imgPathDataGridView.AllowUserToResizeRows = false;
            this.imgPathDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPathDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.imgPathDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.imgPathDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameColumn,
            this.thumbnailColumn,
            this.filePathColumn});
            this.imgPathDataGridView.Location = new System.Drawing.Point(22, 272);
            this.imgPathDataGridView.MultiSelect = false;
            this.imgPathDataGridView.Name = "imgPathDataGridView";
            this.imgPathDataGridView.ReadOnly = true;
            this.imgPathDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.imgPathDataGridView.RowHeadersVisible = false;
            this.imgPathDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.imgPathDataGridView.Size = new System.Drawing.Size(428, 237);
            this.imgPathDataGridView.TabIndex = 10;
            this.imgPathDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.imgPathDataGridView_CellContentClick);
            this.imgPathDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.imgPathDataGridView_CellMouseClick);
            this.imgPathDataGridView.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.imgPathDataGridView_CellStateChanged);
            this.imgPathDataGridView.SelectionChanged += new System.EventHandler(this.imgPathDataGridView_SelectionChanged);
            this.imgPathDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imgPathDataGridView_KeyDown);
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fileNameColumn.FillWeight = 187.013F;
            this.fileNameColumn.HeaderText = "Nome do Arquivo";
            this.fileNameColumn.Name = "fileNameColumn";
            this.fileNameColumn.ReadOnly = true;
            this.fileNameColumn.Width = 120;
            // 
            // thumbnailColumn
            // 
            this.thumbnailColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.thumbnailColumn.HeaderText = "Imagem";
            this.thumbnailColumn.Name = "thumbnailColumn";
            this.thumbnailColumn.ReadOnly = true;
            this.thumbnailColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.thumbnailColumn.Width = 120;
            // 
            // filePathColumn
            // 
            this.filePathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filePathColumn.FillWeight = 12.98701F;
            this.filePathColumn.HeaderText = "Localização";
            this.filePathColumn.Name = "filePathColumn";
            this.filePathColumn.ReadOnly = true;
            // 
            // moveUpButton
            // 
            this.moveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveUpButton.Location = new System.Drawing.Point(19, 171);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(136, 23);
            this.moveUpButton.TabIndex = 22;
            this.moveUpButton.Text = "Acima (Ctrl + ->)";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveDownButton.Location = new System.Drawing.Point(19, 200);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(136, 23);
            this.moveDownButton.TabIndex = 23;
            this.moveDownButton.Text = "Abaixo (Ctrl + <-)";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // moveRowLabel
            // 
            this.moveRowLabel.AutoSize = true;
            this.moveRowLabel.Location = new System.Drawing.Point(19, 155);
            this.moveRowLabel.Name = "moveRowLabel";
            this.moveRowLabel.Size = new System.Drawing.Size(62, 13);
            this.moveRowLabel.TabIndex = 38;
            this.moveRowLabel.Text = "Mover item:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Imagens:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Apagar Item:";
            // 
            // imgListNameTextBox
            // 
            this.imgListNameTextBox.Location = new System.Drawing.Point(19, 44);
            this.imgListNameTextBox.Name = "imgListNameTextBox";
            this.imgListNameTextBox.Size = new System.Drawing.Size(136, 20);
            this.imgListNameTextBox.TabIndex = 19;
            // 
            // imgListNameLabel
            // 
            this.imgListNameLabel.AutoSize = true;
            this.imgListNameLabel.Location = new System.Drawing.Point(19, 28);
            this.imgListNameLabel.Name = "imgListNameLabel";
            this.imgListNameLabel.Size = new System.Drawing.Size(78, 13);
            this.imgListNameLabel.TabIndex = 42;
            this.imgListNameLabel.Text = "Nome da Lista:";
            // 
            // numberFilesLabel
            // 
            this.numberFilesLabel.AutoSize = true;
            this.numberFilesLabel.Location = new System.Drawing.Point(22, 249);
            this.numberFilesLabel.Name = "numberFilesLabel";
            this.numberFilesLabel.Size = new System.Drawing.Size(88, 13);
            this.numberFilesLabel.TabIndex = 43;
            this.numberFilesLabel.Text = "Arquivos na Lista";
            // 
            // numberFiles
            // 
            this.numberFiles.AutoSize = true;
            this.numberFiles.Location = new System.Drawing.Point(116, 249);
            this.numberFiles.Name = "numberFiles";
            this.numberFiles.Size = new System.Drawing.Size(13, 13);
            this.numberFiles.TabIndex = 44;
            this.numberFiles.Text = "0";
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::StroopTest.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.Location = new System.Drawing.Point(424, 11);
            this.helpButton.Margin = new System.Windows.Forms.Padding(2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(26, 26);
            this.helpButton.TabIndex = 82;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // FormImgConfig
            // 
            this.AcceptButton = this.saveButton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(469, 547);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.numberFiles);
            this.Controls.Add(this.numberFilesLabel);
            this.Controls.Add(this.imgListNameLabel);
            this.Controls.Add(this.imgListNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveRowLabel);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.imgPathDataGridView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 550);
            this.Name = "FormImgConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista - Imagens";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPathDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView imgPathDataGridView;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Label moveRowLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox imgListNameTextBox;
        private System.Windows.Forms.Label imgListNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameColumn;
        private System.Windows.Forms.DataGridViewImageColumn thumbnailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathColumn;
        private System.Windows.Forms.Label numberFilesLabel;
        private System.Windows.Forms.Label numberFiles;
        private System.Windows.Forms.Button helpButton;
    }
}