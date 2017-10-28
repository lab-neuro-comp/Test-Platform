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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportUserControl));
            this.exportDataGridView = new System.Windows.Forms.DataGridView();
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteItemLabel = new System.Windows.Forms.Label();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.exportDataGridView)).BeginInit();
            this.SuspendLayout();
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
            resources.ApplyResources(this.exportDataGridView, "exportDataGridView");
            this.exportDataGridView.MultiSelect = false;
            this.exportDataGridView.Name = "exportDataGridView";
            this.exportDataGridView.ReadOnly = true;
            this.exportDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.exportDataGridView.RowHeadersVisible = false;
            this.exportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileNameColumn.FillWeight = 187.013F;
            resources.ApplyResources(this.fileNameColumn, "fileNameColumn");
            this.fileNameColumn.Name = "fileNameColumn";
            this.fileNameColumn.ReadOnly = true;
            // 
            // typeColumn
            // 
            this.typeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.typeColumn, "typeColumn");
            this.typeColumn.Name = "typeColumn";
            this.typeColumn.ReadOnly = true;
            // 
            // locationColumn
            // 
            resources.ApplyResources(this.locationColumn, "locationColumn");
            this.locationColumn.Name = "locationColumn";
            this.locationColumn.ReadOnly = true;
            // 
            // deleteItemLabel
            // 
            resources.ApplyResources(this.deleteItemLabel, "deleteItemLabel");
            this.deleteItemLabel.Name = "deleteItemLabel";
            // 
            // deleteItemButton
            // 
            resources.ApplyResources(this.deleteItemButton, "deleteItemButton");
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            resources.GetString("typeComboBox.Items"),
            resources.GetString("typeComboBox.Items1"),
            resources.GetString("typeComboBox.Items2"),
            resources.GetString("typeComboBox.Items3")});
            resources.ApplyResources(this.typeComboBox, "typeComboBox");
            this.typeComboBox.Name = "typeComboBox";
            // 
            // btnChoose
            // 
            resources.ApplyResources(this.btnChoose, "btnChoose");
            this.btnChoose.CausesValidation = false;
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // exportButton
            // 
            resources.ApplyResources(this.exportButton, "exportButton");
            this.exportButton.Name = "exportButton";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // ExportUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.deleteItemLabel);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.exportDataGridView);
            this.Name = "ExportUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.exportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
