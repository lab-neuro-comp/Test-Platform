namespace TestPlatform.Views.ExperimentPages
{
    partial class ExperimentConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentConfig));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.experimentConfigPanel = new System.Windows.Forms.Panel();
            this.helpButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.intervalTimeLabel = new System.Windows.Forms.Label();
            this.intervalTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trainingButton = new System.Windows.Forms.Button();
            this.labelEmpty = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteItemLabel = new System.Windows.Forms.Label();
            this.programDataGridView = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typePrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programSelectButton = new System.Windows.Forms.Button();
            this.instructionsBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.randomOrderCheckbox = new System.Windows.Forms.CheckBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.experimentNameTextBox = new System.Windows.Forms.TextBox();
            this.experimentNameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.experimentConfigPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTime)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // experimentConfigPanel
            // 
            this.experimentConfigPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.experimentConfigPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.experimentConfigPanel.Controls.Add(this.helpButton);
            this.experimentConfigPanel.Controls.Add(this.groupBox3);
            this.experimentConfigPanel.Controls.Add(this.groupBox2);
            this.experimentConfigPanel.Controls.Add(this.instructionsBox);
            this.experimentConfigPanel.Controls.Add(this.groupBox1);
            this.experimentConfigPanel.Controls.Add(this.instructionsLabel);
            this.experimentConfigPanel.Controls.Add(this.experimentNameTextBox);
            this.experimentConfigPanel.Controls.Add(this.experimentNameLabel);
            resources.ApplyResources(this.experimentConfigPanel, "experimentConfigPanel");
            this.experimentConfigPanel.Name = "experimentConfigPanel";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.intervalTimeLabel);
            this.groupBox3.Controls.Add(this.intervalTime);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // intervalTimeLabel
            // 
            resources.ApplyResources(this.intervalTimeLabel, "intervalTimeLabel");
            this.intervalTimeLabel.Name = "intervalTimeLabel";
            // 
            // intervalTime
            // 
            this.intervalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.intervalTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.intervalTime, "intervalTime");
            this.intervalTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.intervalTime.Name = "intervalTime";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trainingButton);
            this.groupBox2.Controls.Add(this.labelEmpty);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.deleteItemLabel);
            this.groupBox2.Controls.Add(this.programDataGridView);
            this.groupBox2.Controls.Add(this.programSelectButton);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // trainingButton
            // 
            resources.ApplyResources(this.trainingButton, "trainingButton");
            this.trainingButton.Name = "trainingButton";
            this.trainingButton.UseVisualStyleBackColor = true;
            this.trainingButton.Click += new System.EventHandler(this.trainingButton_Click);
            // 
            // labelEmpty
            // 
            resources.ApplyResources(this.labelEmpty, "labelEmpty");
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Name = "labelEmpty";
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteItemLabel
            // 
            resources.ApplyResources(this.deleteItemLabel, "deleteItemLabel");
            this.deleteItemLabel.Name = "deleteItemLabel";
            // 
            // programDataGridView
            // 
            this.programDataGridView.AllowUserToAddRows = false;
            this.programDataGridView.AllowUserToDeleteRows = false;
            this.programDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.programDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.programDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.programDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.programDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.programName,
            this.typePrograma});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.programDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.programDataGridView, "programDataGridView");
            this.programDataGridView.Name = "programDataGridView";
            this.programDataGridView.ReadOnly = true;
            this.programDataGridView.RowHeadersVisible = false;
            this.programDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programDataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.listLength_Validating);
            this.programDataGridView.Validated += new System.EventHandler(this.listLength_Validated);
            // 
            // Order
            // 
            resources.ApplyResources(this.Order, "Order");
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            // 
            // programName
            // 
            this.programName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.programName, "programName");
            this.programName.Name = "programName";
            this.programName.ReadOnly = true;
            // 
            // typePrograma
            // 
            this.typePrograma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.typePrograma, "typePrograma");
            this.typePrograma.Name = "typePrograma";
            this.typePrograma.ReadOnly = true;
            // 
            // programSelectButton
            // 
            resources.ApplyResources(this.programSelectButton, "programSelectButton");
            this.programSelectButton.Name = "programSelectButton";
            this.programSelectButton.UseVisualStyleBackColor = true;
            this.programSelectButton.Click += new System.EventHandler(this.addProgramButton_Click);
            // 
            // instructionsBox
            // 
            this.instructionsBox.AcceptsReturn = true;
            this.instructionsBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.instructionsBox, "instructionsBox");
            this.instructionsBox.Name = "instructionsBox";
            this.instructionsBox.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.randomOrderCheckbox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // randomOrderCheckbox
            // 
            resources.ApplyResources(this.randomOrderCheckbox, "randomOrderCheckbox");
            this.randomOrderCheckbox.Name = "randomOrderCheckbox";
            this.randomOrderCheckbox.TabStop = false;
            this.randomOrderCheckbox.UseVisualStyleBackColor = true;
            this.randomOrderCheckbox.CheckedChanged += new System.EventHandler(this.randomOrderCheckbox_CheckedChanged);
            // 
            // instructionsLabel
            // 
            resources.ApplyResources(this.instructionsLabel, "instructionsLabel");
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.instructionsLabel.Name = "instructionsLabel";
            // 
            // experimentNameTextBox
            // 
            resources.ApplyResources(this.experimentNameTextBox, "experimentNameTextBox");
            this.experimentNameTextBox.Name = "experimentNameTextBox";
            this.experimentNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.prgNameTextBox_Validating);
            this.experimentNameTextBox.Validated += new System.EventHandler(this.experimentNameTextBox_Validated);
            // 
            // experimentNameLabel
            // 
            resources.ApplyResources(this.experimentNameLabel, "experimentNameLabel");
            this.experimentNameLabel.Name = "experimentNameLabel";
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
            this.saveButton.CausesValidation = false;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ExperimentConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.experimentConfigPanel);
            this.Name = "ExperimentConfig";
            this.experimentConfigPanel.ResumeLayout(false);
            this.experimentConfigPanel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel experimentConfigPanel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label intervalTimeLabel;
        private System.Windows.Forms.NumericUpDown intervalTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button programSelectButton;
        private System.Windows.Forms.TextBox instructionsBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.TextBox experimentNameTextBox;
        private System.Windows.Forms.Label experimentNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox randomOrderCheckbox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView programDataGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label deleteItemLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelEmpty;
        private System.Windows.Forms.Button trainingButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn programName;
        private System.Windows.Forms.DataGridViewTextBoxColumn typePrograma;
    }
}
