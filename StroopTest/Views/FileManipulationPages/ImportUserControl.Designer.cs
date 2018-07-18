namespace TestPlatform.Views.MainForms
{
    partial class ImportUserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportUserControl));
            this.importButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.warningCheckBox = new System.Windows.Forms.CheckBox();
            this.warningMessage = new System.Windows.Forms.Label();
            this.originDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addToOriginList = new System.Windows.Forms.Button();
            this.addToDestinationList = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.importAllCheckbox = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // importButton
            // 
            resources.ApplyResources(this.importButton, "importButton");
            this.importButton.Name = "importButton";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // warningCheckBox
            // 
            resources.ApplyResources(this.warningCheckBox, "warningCheckBox");
            this.warningCheckBox.Name = "warningCheckBox";
            this.warningCheckBox.UseVisualStyleBackColor = true;
            this.warningCheckBox.Validating += new System.ComponentModel.CancelEventHandler(this.warningCheckBox_Validating);
            this.warningCheckBox.Validated += new System.EventHandler(this.warningCheckBox_Validated);
            // 
            // warningMessage
            // 
            this.warningMessage.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.warningMessage, "warningMessage");
            this.warningMessage.Name = "warningMessage";
            // 
            // originDataGridView
            // 
            this.originDataGridView.AllowUserToAddRows = false;
            this.originDataGridView.AllowUserToDeleteRows = false;
            this.originDataGridView.AllowUserToOrderColumns = true;
            this.originDataGridView.AllowUserToResizeRows = false;
            this.originDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.originDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.originDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            resources.ApplyResources(this.originDataGridView, "originDataGridView");
            this.originDataGridView.MultiSelect = false;
            this.originDataGridView.Name = "originDataGridView";
            this.originDataGridView.ReadOnly = true;
            this.originDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.originDataGridView.RowHeadersVisible = false;
            this.originDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 187.013F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // importDataGridView
            // 
            this.importDataGridView.AllowUserToAddRows = false;
            this.importDataGridView.AllowUserToOrderColumns = true;
            this.importDataGridView.AllowUserToResizeRows = false;
            this.importDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.importDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.importDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            resources.ApplyResources(this.importDataGridView, "importDataGridView");
            this.importDataGridView.MultiSelect = false;
            this.importDataGridView.Name = "importDataGridView";
            this.importDataGridView.ReadOnly = true;
            this.importDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.importDataGridView.RowHeadersVisible = false;
            this.importDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.importDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.importDataGridView_CellContentClick);
            this.importDataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.importDataGridView_Validating);
            this.importDataGridView.Validated += new System.EventHandler(this.importDataGridView_Validated);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 187.013F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // addToOriginList
            // 
            resources.ApplyResources(this.addToOriginList, "addToOriginList");
            this.addToOriginList.Name = "addToOriginList";
            this.addToOriginList.UseVisualStyleBackColor = true;
            this.addToOriginList.Click += new System.EventHandler(this.addToOriginList_Click);
            // 
            // addToDestinationList
            // 
            resources.ApplyResources(this.addToDestinationList, "addToDestinationList");
            this.addToDestinationList.Name = "addToDestinationList";
            this.addToDestinationList.UseVisualStyleBackColor = true;
            this.addToDestinationList.Click += new System.EventHandler(this.addToDestinationList_Click);
            // 
            // fileLabel
            // 
            resources.ApplyResources(this.fileLabel, "fileLabel");
            this.fileLabel.Name = "fileLabel";
            // 
            // fileTextBox
            // 
            resources.ApplyResources(this.fileTextBox, "fileTextBox");
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.fileTextBox_Validating);
            this.fileTextBox.Validated += new System.EventHandler(this.fileTextBox_Validated);
            // 
            // openButton
            // 
            resources.ApplyResources(this.openButton, "openButton");
            this.openButton.Name = "openButton";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // importAllCheckbox
            // 
            resources.ApplyResources(this.importAllCheckbox, "importAllCheckbox");
            this.importAllCheckbox.Name = "importAllCheckbox";
            this.importAllCheckbox.UseVisualStyleBackColor = true;
            this.importAllCheckbox.CheckedChanged += new System.EventHandler(this.importAllCheckbox_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
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
            // ImportUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.importAllCheckbox);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.warningCheckBox);
            this.Controls.Add(this.warningMessage);
            this.Controls.Add(this.originDataGridView);
            this.Controls.Add(this.importDataGridView);
            this.Controls.Add(this.addToOriginList);
            this.Controls.Add(this.addToDestinationList);
            this.Name = "ImportUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.originDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox warningCheckBox;
        private System.Windows.Forms.Label warningMessage;
        private System.Windows.Forms.DataGridView originDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView importDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button addToOriginList;
        private System.Windows.Forms.Button addToDestinationList;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.CheckBox importAllCheckbox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button helpButton;
    }
}
