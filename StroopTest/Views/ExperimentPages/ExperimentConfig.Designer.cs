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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.experimentConfigPanel = new System.Windows.Forms.Panel();
            this.helpButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.intervalTimeLabel = new System.Windows.Forms.Label();
            this.intervalTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelEmpty = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteItemLabel = new System.Windows.Forms.Label();
            this.programDataGridView = new System.Windows.Forms.DataGridView();
            this.programName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typePrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programSelectButton = new System.Windows.Forms.Button();
            this.instructionsBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.beepingCheckbox = new System.Windows.Forms.CheckBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.experimentNameTextBox = new System.Windows.Forms.TextBox();
            this.experimentNameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.practiceProgramLabel = new System.Windows.Forms.Label();
            this.trainingProgramCheckBox = new System.Windows.Forms.CheckBox();
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
            this.experimentConfigPanel.Location = new System.Drawing.Point(22, 12);
            this.experimentConfigPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.experimentConfigPanel.Name = "experimentConfigPanel";
            this.experimentConfigPanel.Size = new System.Drawing.Size(693, 672);
            this.experimentConfigPanel.TabIndex = 2;
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.Location = new System.Drawing.Point(651, 2);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 32);
            this.helpButton.TabIndex = 81;
            this.helpButton.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.intervalTimeLabel);
            this.groupBox3.Controls.Add(this.intervalTime);
            this.groupBox3.Location = new System.Drawing.Point(404, 40);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(269, 59);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tempo";
            // 
            // intervalTimeLabel
            // 
            this.intervalTimeLabel.AutoSize = true;
            this.intervalTimeLabel.Location = new System.Drawing.Point(15, 22);
            this.intervalTimeLabel.Name = "intervalTimeLabel";
            this.intervalTimeLabel.Size = new System.Drawing.Size(98, 17);
            this.intervalTimeLabel.TabIndex = 38;
            this.intervalTimeLabel.Text = "Intervalo (ms):";
            // 
            // intervalTime
            // 
            this.intervalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.intervalTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.intervalTime.Location = new System.Drawing.Point(142, 22);
            this.intervalTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.intervalTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.intervalTime.Name = "intervalTime";
            this.intervalTime.Size = new System.Drawing.Size(80, 22);
            this.intervalTime.TabIndex = 31;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trainingProgramCheckBox);
            this.groupBox2.Controls.Add(this.practiceProgramLabel);
            this.groupBox2.Controls.Add(this.labelEmpty);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.deleteItemLabel);
            this.groupBox2.Controls.Add(this.programDataGridView);
            this.groupBox2.Controls.Add(this.programSelectButton);
            this.groupBox2.Location = new System.Drawing.Point(19, 103);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(654, 392);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programas";
            // 
            // labelEmpty
            // 
            this.labelEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEmpty.AutoSize = true;
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Location = new System.Drawing.Point(7, 177);
            this.labelEmpty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmpty.Name = "labelEmpty";
            this.labelEmpty.Size = new System.Drawing.Size(77, 17);
            this.labelEmpty.TabIndex = 84;
            this.labelEmpty.Text = "labelEmpty";
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(9, 128);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(99, 27);
            this.deleteButton.TabIndex = 62;
            this.deleteButton.Text = "Apagar";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteItemLabel
            // 
            this.deleteItemLabel.AutoSize = true;
            this.deleteItemLabel.Location = new System.Drawing.Point(7, 109);
            this.deleteItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.deleteItemLabel.Name = "deleteItemLabel";
            this.deleteItemLabel.Size = new System.Drawing.Size(88, 17);
            this.deleteItemLabel.TabIndex = 61;
            this.deleteItemLabel.Text = "Apagar Item:";
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
            this.programDataGridView.Location = new System.Drawing.Point(112, 51);
            this.programDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.programDataGridView.Name = "programDataGridView";
            this.programDataGridView.ReadOnly = true;
            this.programDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.programDataGridView.RowHeadersVisible = false;
            this.programDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programDataGridView.Size = new System.Drawing.Size(520, 335);
            this.programDataGridView.TabIndex = 1;
            this.programDataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.listLength_Validating);
            this.programDataGridView.Validated += new System.EventHandler(this.listLength_Validated);
            // 
            // programName
            // 
            this.programName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.programName.HeaderText = "Nome do Programa";
            this.programName.Name = "programName";
            this.programName.ReadOnly = true;
            // 
            // typePrograma
            // 
            this.typePrograma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.typePrograma.HeaderText = "Tipo do Programa";
            this.typePrograma.Name = "typePrograma";
            this.typePrograma.ReadOnly = true;
            this.typePrograma.Width = 200;
            // 
            // programSelectButton
            // 
            this.programSelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programSelectButton.Location = new System.Drawing.Point(9, 51);
            this.programSelectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.programSelectButton.Name = "programSelectButton";
            this.programSelectButton.Size = new System.Drawing.Size(99, 28);
            this.programSelectButton.TabIndex = 20;
            this.programSelectButton.Text = "Adicionar";
            this.programSelectButton.UseVisualStyleBackColor = true;
            this.programSelectButton.Click += new System.EventHandler(this.addProgramButton_Click);
            // 
            // instructionsBox
            // 
            this.instructionsBox.AcceptsReturn = true;
            this.instructionsBox.AccessibleDescription = "";
            this.instructionsBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.instructionsBox.Location = new System.Drawing.Point(16, 527);
            this.instructionsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.instructionsBox.Multiline = true;
            this.instructionsBox.Name = "instructionsBox";
            this.instructionsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instructionsBox.Size = new System.Drawing.Size(657, 136);
            this.instructionsBox.TabIndex = 70;
            this.instructionsBox.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.beepingCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(19, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(367, 58);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exposição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 161;
            this.label1.Text = "Ordem Aleatória:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // beepingCheckbox
            // 
            this.beepingCheckbox.AutoSize = true;
            this.beepingCheckbox.Location = new System.Drawing.Point(135, 28);
            this.beepingCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.beepingCheckbox.Name = "beepingCheckbox";
            this.beepingCheckbox.Size = new System.Drawing.Size(18, 17);
            this.beepingCheckbox.TabIndex = 160;
            this.beepingCheckbox.TabStop = false;
            this.beepingCheckbox.UseVisualStyleBackColor = true;
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.instructionsLabel.Location = new System.Drawing.Point(16, 504);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(77, 17);
            this.instructionsLabel.TabIndex = 59;
            this.instructionsLabel.Text = "Instruções:";
            // 
            // experimentNameTextBox
            // 
            this.experimentNameTextBox.Location = new System.Drawing.Point(170, 12);
            this.experimentNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.experimentNameTextBox.MaxLength = 300;
            this.experimentNameTextBox.Name = "experimentNameTextBox";
            this.experimentNameTextBox.Size = new System.Drawing.Size(262, 22);
            this.experimentNameTextBox.TabIndex = 1;
            this.experimentNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.prgNameTextBox_Validating);
            this.experimentNameTextBox.Validated += new System.EventHandler(this.experimentNameTextBox_Validated);
            // 
            // experimentNameLabel
            // 
            this.experimentNameLabel.AutoSize = true;
            this.experimentNameLabel.Location = new System.Drawing.Point(13, 12);
            this.experimentNameLabel.Name = "experimentNameLabel";
            this.experimentNameLabel.Size = new System.Drawing.Size(151, 17);
            this.experimentNameLabel.TabIndex = 34;
            this.experimentNameLabel.Text = "Nome do Experimento:";
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(22, 702);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 87;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = true;
            this.saveButton.CausesValidation = false;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(615, 702);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 86;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // practiceProgramLabel
            // 
            this.practiceProgramLabel.AutoSize = true;
            this.practiceProgramLabel.Location = new System.Drawing.Point(115, 20);
            this.practiceProgramLabel.Name = "practiceProgramLabel";
            this.practiceProgramLabel.Size = new System.Drawing.Size(134, 17);
            this.practiceProgramLabel.TabIndex = 85;
            this.practiceProgramLabel.Text = "Programa de treino:";
            // 
            // trainingProgramCheckBox
            // 
            this.trainingProgramCheckBox.AutoSize = true;
            this.trainingProgramCheckBox.Location = new System.Drawing.Point(255, 21);
            this.trainingProgramCheckBox.Name = "trainingProgramCheckBox";
            this.trainingProgramCheckBox.Size = new System.Drawing.Size(18, 17);
            this.trainingProgramCheckBox.TabIndex = 86;
            this.trainingProgramCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExperimentConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.experimentConfigPanel);
            this.Name = "ExperimentConfig";
            this.Size = new System.Drawing.Size(740, 786);
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
        private System.Windows.Forms.CheckBox beepingCheckbox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView programDataGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label deleteItemLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn programName;
        private System.Windows.Forms.DataGridViewTextBoxColumn typePrograma;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelEmpty;
        private System.Windows.Forms.CheckBox trainingProgramCheckBox;
        private System.Windows.Forms.Label practiceProgramLabel;
    }
}
