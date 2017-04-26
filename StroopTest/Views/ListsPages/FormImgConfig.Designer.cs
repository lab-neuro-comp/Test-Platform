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
            this.components = new System.ComponentModel.Container();
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
            this.btnOpen.CausesValidation = false;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpen.Location = new System.Drawing.Point(25, 107);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(181, 28);
            this.btnOpen.TabIndex = 20;
            this.btnOpen.Text = "Abrir";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(236, 57);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(463, 270);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteItemButton.Location = new System.Drawing.Point(25, 159);
            this.deleteItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(181, 28);
            this.deleteItemButton.TabIndex = 21;
            this.deleteItemButton.Text = "Apagar (Delete)";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteRow_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(25, 747);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(600, 747);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
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
            this.imgPathDataGridView.Location = new System.Drawing.Point(29, 335);
            this.imgPathDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.imgPathDataGridView.MultiSelect = false;
            this.imgPathDataGridView.Name = "imgPathDataGridView";
            this.imgPathDataGridView.ReadOnly = true;
            this.imgPathDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.imgPathDataGridView.RowHeadersVisible = false;
            this.imgPathDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.imgPathDataGridView.Size = new System.Drawing.Size(671, 404);
            this.imgPathDataGridView.TabIndex = 10;
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
            this.moveUpButton.Location = new System.Drawing.Point(25, 210);
            this.moveUpButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(181, 28);
            this.moveUpButton.TabIndex = 22;
            this.moveUpButton.Text = "Acima (Ctrl + ->)";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveDownButton.Location = new System.Drawing.Point(25, 246);
            this.moveDownButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(181, 28);
            this.moveDownButton.TabIndex = 23;
            this.moveDownButton.Text = "Abaixo (Ctrl + <-)";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // moveRowLabel
            // 
            this.moveRowLabel.AutoSize = true;
            this.moveRowLabel.Location = new System.Drawing.Point(25, 191);
            this.moveRowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moveRowLabel.Name = "moveRowLabel";
            this.moveRowLabel.Size = new System.Drawing.Size(81, 17);
            this.moveRowLabel.TabIndex = 38;
            this.moveRowLabel.Text = "Mover item:";
            // 
            // imagesLabel
            // 
            this.imagesLabel.AutoSize = true;
            this.imagesLabel.Location = new System.Drawing.Point(25, 87);
            this.imagesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.imagesLabel.Name = "imagesLabel";
            this.imagesLabel.Size = new System.Drawing.Size(65, 17);
            this.imagesLabel.TabIndex = 39;
            this.imagesLabel.Text = "Imagens:";
            // 
            // deleteItemLabel
            // 
            this.deleteItemLabel.AutoSize = true;
            this.deleteItemLabel.Location = new System.Drawing.Point(25, 139);
            this.deleteItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.deleteItemLabel.Name = "deleteItemLabel";
            this.deleteItemLabel.Size = new System.Drawing.Size(88, 17);
            this.deleteItemLabel.TabIndex = 40;
            this.deleteItemLabel.Text = "Apagar Item:";
            // 
            // imgListNameTextBox
            // 
            this.imgListNameTextBox.Location = new System.Drawing.Point(25, 54);
            this.imgListNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.imgListNameTextBox.Name = "imgListNameTextBox";
            this.imgListNameTextBox.Size = new System.Drawing.Size(180, 22);
            this.imgListNameTextBox.TabIndex = 19;
            this.imgListNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.listName_Validating);
            this.imgListNameTextBox.Validated += new System.EventHandler(this.listName_Validated);
            // 
            // imgListNameLabel
            // 
            this.imgListNameLabel.AutoSize = true;
            this.imgListNameLabel.Location = new System.Drawing.Point(25, 34);
            this.imgListNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.imgListNameLabel.Name = "imgListNameLabel";
            this.imgListNameLabel.Size = new System.Drawing.Size(103, 17);
            this.imgListNameLabel.TabIndex = 42;
            this.imgListNameLabel.Text = "Nome da Lista:";
            // 
            // numberFilesLabel
            // 
            this.numberFilesLabel.AutoSize = true;
            this.numberFilesLabel.Location = new System.Drawing.Point(29, 306);
            this.numberFilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberFilesLabel.Name = "numberFilesLabel";
            this.numberFilesLabel.Size = new System.Drawing.Size(117, 17);
            this.numberFilesLabel.TabIndex = 43;
            this.numberFilesLabel.Text = "Arquivos na Lista";
            // 
            // numberFiles
            // 
            this.numberFiles.AutoSize = true;
            this.numberFiles.Location = new System.Drawing.Point(155, 306);
            this.numberFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberFiles.Name = "numberFiles";
            this.numberFiles.Size = new System.Drawing.Size(16, 17);
            this.numberFiles.TabIndex = 44;
            this.numberFiles.Text = "0";
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.Location = new System.Drawing.Point(665, 19);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 32);
            this.helpButton.TabIndex = 82;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelEmpty
            // 
            this.labelEmpty.AutoSize = true;
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Location = new System.Drawing.Point(28, 287);
            this.labelEmpty.Name = "labelEmpty";
            this.labelEmpty.Size = new System.Drawing.Size(77, 17);
            this.labelEmpty.TabIndex = 83;
            this.labelEmpty.Text = "labelEmpty";
            // 
            // FormImgConfig
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(594, 666);
            this.Name = "FormImgConfig";
            this.Size = new System.Drawing.Size(725, 785);
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