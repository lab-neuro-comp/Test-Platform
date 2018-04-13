namespace TestPlatform.Views.ParticipantPages
{
    partial class FormParticipantConfig
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.helpButton = new System.Windows.Forms.Button();
            this.instructionsBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.prgNameTextBox = new System.Windows.Forms.TextBox();
            this.participantNameLabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.sexPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.femaleRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.sexLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.middleSchoolButton = new System.Windows.Forms.RadioButton();
            this.highSchoolradioButton = new System.Windows.Forms.RadioButton();
            this.scholarLabel = new System.Windows.Forms.Label();
            this.higherEducationradioButton = new System.Windows.Forms.RadioButton();
            this.higher1radioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.sexPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.helpButton);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.instructionsBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.instructionsLabel);
            this.panel1.Controls.Add(this.prgNameTextBox);
            this.panel1.Controls.Add(this.participantNameLabel);
            this.panel1.Location = new System.Drawing.Point(9, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 689);
            this.panel1.TabIndex = 1;
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.helpButton.Location = new System.Drawing.Point(743, 2);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 32);
            this.helpButton.TabIndex = 81;
            this.helpButton.TabStop = false;
            this.helpButton.UseVisualStyleBackColor = false;
            // 
            // instructionsBox
            // 
            this.instructionsBox.AcceptsReturn = true;
            this.instructionsBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.instructionsBox.Location = new System.Drawing.Point(13, 607);
            this.instructionsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.instructionsBox.Multiline = true;
            this.instructionsBox.Name = "instructionsBox";
            this.instructionsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instructionsBox.Size = new System.Drawing.Size(763, 72);
            this.instructionsBox.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.ageLabel);
            this.groupBox1.Controls.Add(this.scholarLabel);
            this.groupBox1.Controls.Add(this.sexLabel);
            this.groupBox1.Controls.Add(this.sexPanel);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.birthDateLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(763, 542);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.AutoSize = true;
            this.birthDateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.birthDateLabel.Location = new System.Drawing.Point(324, 26);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new System.Drawing.Size(138, 17);
            this.birthDateLabel.TabIndex = 56;
            this.birthDateLabel.Text = "Data de nascimento:";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.instructionsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.instructionsLabel.Location = new System.Drawing.Point(16, 586);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(96, 17);
            this.instructionsLabel.TabIndex = 59;
            this.instructionsLabel.Text = "Observações:";
            // 
            // prgNameTextBox
            // 
            this.prgNameTextBox.Location = new System.Drawing.Point(170, 16);
            this.prgNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prgNameTextBox.MaxLength = 300;
            this.prgNameTextBox.Name = "prgNameTextBox";
            this.prgNameTextBox.Size = new System.Drawing.Size(225, 22);
            this.prgNameTextBox.TabIndex = 1;
            // 
            // participantNameLabel
            // 
            this.participantNameLabel.AutoSize = true;
            this.participantNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.participantNameLabel.Location = new System.Drawing.Point(13, 18);
            this.participantNameLabel.Name = "participantNameLabel";
            this.participantNameLabel.Size = new System.Drawing.Size(148, 17);
            this.participantNameLabel.TabIndex = 34;
            this.participantNameLabel.Text = "Nome do Participante:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(466, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 64;
            // 
            // sexPanel
            // 
            this.sexPanel.Controls.Add(this.femaleRadioButton);
            this.sexPanel.Controls.Add(this.radioButton2);
            this.sexPanel.Location = new System.Drawing.Point(68, 50);
            this.sexPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sexPanel.Name = "sexPanel";
            this.sexPanel.Size = new System.Drawing.Size(194, 31);
            this.sexPanel.TabIndex = 65;
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AutoSize = true;
            this.femaleRadioButton.Location = new System.Drawing.Point(3, 3);
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.Size = new System.Drawing.Size(86, 21);
            this.femaleRadioButton.TabIndex = 0;
            this.femaleRadioButton.TabStop = true;
            this.femaleRadioButton.Text = "Feminino";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(95, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Masculino";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sexLabel.Location = new System.Drawing.Point(19, 60);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(43, 17);
            this.sexLabel.TabIndex = 66;
            this.sexLabel.Text = "Sexo:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.middleSchoolButton);
            this.flowLayoutPanel1.Controls.Add(this.highSchoolradioButton);
            this.flowLayoutPanel1.Controls.Add(this.higherEducationradioButton);
            this.flowLayoutPanel1.Controls.Add(this.higher1radioButton);
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(174, 101);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(184, 137);
            this.flowLayoutPanel1.TabIndex = 66;
            // 
            // middleSchoolButton
            // 
            this.middleSchoolButton.AutoSize = true;
            this.middleSchoolButton.Location = new System.Drawing.Point(3, 3);
            this.middleSchoolButton.Name = "middleSchoolButton";
            this.middleSchoolButton.Size = new System.Drawing.Size(168, 21);
            this.middleSchoolButton.TabIndex = 0;
            this.middleSchoolButton.TabStop = true;
            this.middleSchoolButton.Text = "Fundamental (9 anos)";
            this.middleSchoolButton.UseVisualStyleBackColor = true;
            // 
            // highSchoolradioButton
            // 
            this.highSchoolradioButton.AutoSize = true;
            this.highSchoolradioButton.Location = new System.Drawing.Point(3, 30);
            this.highSchoolradioButton.Name = "highSchoolradioButton";
            this.highSchoolradioButton.Size = new System.Drawing.Size(124, 21);
            this.highSchoolradioButton.TabIndex = 1;
            this.highSchoolradioButton.TabStop = true;
            this.highSchoolradioButton.Text = "Médio (3 anos)";
            this.highSchoolradioButton.UseVisualStyleBackColor = true;
            // 
            // scholarLabel
            // 
            this.scholarLabel.AutoSize = true;
            this.scholarLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.scholarLabel.Location = new System.Drawing.Point(19, 101);
            this.scholarLabel.Name = "scholarLabel";
            this.scholarLabel.Size = new System.Drawing.Size(149, 17);
            this.scholarLabel.TabIndex = 67;
            this.scholarLabel.Text = "Grau de escolaridade:";
            // 
            // higherEducationradioButton
            // 
            this.higherEducationradioButton.AutoSize = true;
            this.higherEducationradioButton.Location = new System.Drawing.Point(3, 57);
            this.higherEducationradioButton.Name = "higherEducationradioButton";
            this.higherEducationradioButton.Size = new System.Drawing.Size(181, 21);
            this.higherEducationradioButton.TabIndex = 2;
            this.higherEducationradioButton.TabStop = true;
            this.higherEducationradioButton.Text = "Superior em andamento";
            this.higherEducationradioButton.UseVisualStyleBackColor = true;
            // 
            // higher1radioButton
            // 
            this.higher1radioButton.AutoSize = true;
            this.higher1radioButton.Location = new System.Drawing.Point(3, 84);
            this.higher1radioButton.Name = "higher1radioButton";
            this.higher1radioButton.Size = new System.Drawing.Size(144, 21);
            this.higher1radioButton.TabIndex = 3;
            this.higher1radioButton.TabStop = true;
            this.higher1radioButton.Text = "Superior completo";
            this.higher1radioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 111);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(125, 21);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Pós graduação";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(528, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.MaxLength = 300;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 22);
            this.textBox1.TabIndex = 82;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.idLabel.Location = new System.Drawing.Point(425, 18);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(97, 17);
            this.idLabel.TabIndex = 83;
            this.idLabel.Text = "# de Registro:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ageLabel.Location = new System.Drawing.Point(19, 24);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(47, 17);
            this.ageLabel.TabIndex = 68;
            this.ageLabel.Text = "Idade:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(68, 22);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 22);
            this.numericUpDown1.TabIndex = 69;
            // 
            // FormParticipantConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FormParticipantConfig";
            this.Size = new System.Drawing.Size(800, 738);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.sexPanel.ResumeLayout(false);
            this.sexPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.TextBox instructionsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.TextBox prgNameTextBox;
        private System.Windows.Forms.Label participantNameLabel;
        private System.Windows.Forms.FlowLayoutPanel sexPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label scholarLabel;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.RadioButton femaleRadioButton;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton middleSchoolButton;
        private System.Windows.Forms.RadioButton highSchoolradioButton;
        private System.Windows.Forms.RadioButton higherEducationradioButton;
        private System.Windows.Forms.RadioButton higher1radioButton;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
