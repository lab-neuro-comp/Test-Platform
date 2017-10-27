namespace TestPlatform.Views.MainForms
{
    partial class ExportUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numberFiles = new System.Windows.Forms.Label();
            this.numberFilesLabel = new System.Windows.Forms.Label();
            this.exportDataGridView = new System.Windows.Forms.DataGridView();
            this.deleteItemLabel = new System.Windows.Forms.Label();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // numberFiles
            // 
            this.numberFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numberFiles.AutoSize = true;
            this.numberFiles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numberFiles.Location = new System.Drawing.Point(259, 469);
            this.numberFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberFiles.Name = "numberFiles";
            this.numberFiles.Size = new System.Drawing.Size(16, 17);
            this.numberFiles.TabIndex = 47;
            this.numberFiles.Text = "0";
            // 
            // numberFilesLabel
            // 
            this.numberFilesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numberFilesLabel.AutoSize = true;
            this.numberFilesLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numberFilesLabel.Location = new System.Drawing.Point(134, 469);
            this.numberFilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberFilesLabel.Name = "numberFilesLabel";
            this.numberFilesLabel.Size = new System.Drawing.Size(117, 17);
            this.numberFilesLabel.TabIndex = 46;
            this.numberFilesLabel.Text = "Arquivos na Lista";
            // 
            // exportDataGridView
            // 
            this.exportDataGridView.AllowUserToAddRows = false;
            this.exportDataGridView.AllowUserToOrderColumns = true;
            this.exportDataGridView.AllowUserToResizeRows = false;
            this.exportDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exportDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameColumn,
            this.typeColumn,
            this.locationColumn});
            this.exportDataGridView.Location = new System.Drawing.Point(137, 116);
            this.exportDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.exportDataGridView.MultiSelect = false;
            this.exportDataGridView.Name = "exportDataGridView";
            this.exportDataGridView.ReadOnly = true;
            this.exportDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.exportDataGridView.RowHeadersVisible = false;
            this.exportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.exportDataGridView.Size = new System.Drawing.Size(671, 340);
            this.exportDataGridView.TabIndex = 45;
            // 
            // deleteItemLabel
            // 
            this.deleteItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteItemLabel.AutoSize = true;
            this.deleteItemLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleteItemLabel.Location = new System.Drawing.Point(10, 119);
            this.deleteItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.deleteItemLabel.Name = "deleteItemLabel";
            this.deleteItemLabel.Size = new System.Drawing.Size(88, 17);
            this.deleteItemLabel.TabIndex = 49;
            this.deleteItemLabel.Text = "Apagar Item:";
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteItemButton.AutoSize = true;
            this.deleteItemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteItemButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleteItemButton.Location = new System.Drawing.Point(10, 139);
            this.deleteItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(64, 27);
            this.deleteItemButton.TabIndex = 48;
            this.deleteItemButton.Text = "Apagar";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Lista",
            "Stroop",
            "Tempo de Reação",
            "Experimento"});
            this.typeComboBox.Location = new System.Drawing.Point(137, 52);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(135, 24);
            this.typeComboBox.TabIndex = 50;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChoose.AutoSize = true;
            this.btnChoose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChoose.CausesValidation = false;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChoose.Location = new System.Drawing.Point(304, 50);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(4);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(85, 27);
            this.btnChoose.TabIndex = 51;
            this.btnChoose.Text = "Selecionar";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(733, 478);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 52;
            this.exportButton.Text = "exportar";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileNameColumn.FillWeight = 187.013F;
            this.fileNameColumn.HeaderText = "Nome do Arquivo";
            this.fileNameColumn.Name = "fileNameColumn";
            this.fileNameColumn.ReadOnly = true;
            // 
            // typeColumn
            // 
            this.typeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeColumn.HeaderText = "Tipo";
            this.typeColumn.Name = "typeColumn";
            this.typeColumn.ReadOnly = true;
            // 
            // locationColumn
            // 
            this.locationColumn.HeaderText = "location";
            this.locationColumn.Name = "locationColumn";
            this.locationColumn.ReadOnly = true;
            this.locationColumn.Visible = false;
            // 
            // ExportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.deleteItemLabel);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.numberFiles);
            this.Controls.Add(this.numberFilesLabel);
            this.Controls.Add(this.exportDataGridView);
            this.Name = "ExportUserControl";
            this.Size = new System.Drawing.Size(888, 514);
            ((System.ComponentModel.ISupportInitialize)(this.exportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberFiles;
        private System.Windows.Forms.Label numberFilesLabel;
        private System.Windows.Forms.DataGridView exportDataGridView;
        private System.Windows.Forms.Label deleteItemLabel;
        private System.Windows.Forms.Button deleteItemButton;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationColumn;
    }
}
