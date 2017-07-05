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
            this.panel1 = new System.Windows.Forms.Panel();
            this.helpButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rndIntervalCheck = new System.Windows.Forms.CheckBox();
            this.rndIntervalLabel = new System.Windows.Forms.Label();
            this.intervalTimeLabel = new System.Windows.Forms.Label();
            this.intervalTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.program1Label = new System.Windows.Forms.Label();
            this.audioListLabel = new System.Windows.Forms.Label();
            this.openAudioListButton = new System.Windows.Forms.Button();
            this.program2Label = new System.Windows.Forms.Label();
            this.program3Label = new System.Windows.Forms.Label();
            this.program1Button = new System.Windows.Forms.Button();
            this.openColorListButton = new System.Windows.Forms.Button();
            this.openImgListButton = new System.Windows.Forms.Button();
            this.instructionsBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.beepingCheckbox = new System.Windows.Forms.CheckBox();
            this.numExpoLabel = new System.Windows.Forms.Label();
            this.numExpo = new System.Windows.Forms.NumericUpDown();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.experimentNameTextBox = new System.Windows.Forms.TextBox();
            this.experimentNameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTime)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExpo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.helpButton);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.instructionsBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.instructionsLabel);
            this.panel1.Controls.Add(this.experimentNameTextBox);
            this.panel1.Controls.Add(this.experimentNameLabel);
            this.panel1.Location = new System.Drawing.Point(22, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 672);
            this.panel1.TabIndex = 2;
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
            this.groupBox3.Controls.Add(this.rndIntervalCheck);
            this.groupBox3.Controls.Add(this.rndIntervalLabel);
            this.groupBox3.Controls.Add(this.intervalTimeLabel);
            this.groupBox3.Controls.Add(this.intervalTime);
            this.groupBox3.Location = new System.Drawing.Point(404, 40);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(269, 91);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tempo";
            // 
            // rndIntervalCheck
            // 
            this.rndIntervalCheck.AutoSize = true;
            this.rndIntervalCheck.Checked = true;
            this.rndIntervalCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rndIntervalCheck.Location = new System.Drawing.Point(224, 57);
            this.rndIntervalCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rndIntervalCheck.Name = "rndIntervalCheck";
            this.rndIntervalCheck.Size = new System.Drawing.Size(18, 17);
            this.rndIntervalCheck.TabIndex = 62;
            this.rndIntervalCheck.UseVisualStyleBackColor = true;
            // 
            // rndIntervalLabel
            // 
            this.rndIntervalLabel.AutoSize = true;
            this.rndIntervalLabel.Location = new System.Drawing.Point(24, 57);
            this.rndIntervalLabel.Name = "rndIntervalLabel";
            this.rndIntervalLabel.Size = new System.Drawing.Size(189, 17);
            this.rndIntervalLabel.TabIndex = 63;
            this.rndIntervalLabel.Text = "Tempo de Intervalo Variável:";
            this.rndIntervalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // intervalTimeLabel
            // 
            this.intervalTimeLabel.AutoSize = true;
            this.intervalTimeLabel.Location = new System.Drawing.Point(56, 25);
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
            this.intervalTime.Location = new System.Drawing.Point(156, 22);
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
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.program1Label);
            this.groupBox2.Controls.Add(this.audioListLabel);
            this.groupBox2.Controls.Add(this.openAudioListButton);
            this.groupBox2.Controls.Add(this.program2Label);
            this.groupBox2.Controls.Add(this.program3Label);
            this.groupBox2.Controls.Add(this.program1Button);
            this.groupBox2.Controls.Add(this.openColorListButton);
            this.groupBox2.Controls.Add(this.openImgListButton);
            this.groupBox2.Location = new System.Drawing.Point(19, 182);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(361, 313);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 172;
            this.label4.Text = "Programa 8:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(112, 262);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(243, 23);
            this.button3.TabIndex = 170;
            this.button3.Text = "abrir";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 171;
            this.label5.Text = "Programa 7:";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(112, 229);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(243, 23);
            this.button4.TabIndex = 169;
            this.button4.Text = "abrir";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 168;
            this.label2.Text = "Programa 6:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(112, 192);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 23);
            this.button1.TabIndex = 166;
            this.button1.Text = "abrir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 167;
            this.label3.Text = "Programa 5:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(112, 159);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 23);
            this.button2.TabIndex = 165;
            this.button2.Text = "abrir";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // program1Label
            // 
            this.program1Label.AutoSize = true;
            this.program1Label.Location = new System.Drawing.Point(6, 27);
            this.program1Label.Name = "program1Label";
            this.program1Label.Size = new System.Drawing.Size(86, 17);
            this.program1Label.TabIndex = 40;
            this.program1Label.Text = "Programa 1:";
            // 
            // audioListLabel
            // 
            this.audioListLabel.AutoSize = true;
            this.audioListLabel.Location = new System.Drawing.Point(6, 127);
            this.audioListLabel.Name = "audioListLabel";
            this.audioListLabel.Size = new System.Drawing.Size(86, 17);
            this.audioListLabel.TabIndex = 164;
            this.audioListLabel.Text = "Programa 4:";
            this.audioListLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // openAudioListButton
            // 
            this.openAudioListButton.Enabled = false;
            this.openAudioListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openAudioListButton.Location = new System.Drawing.Point(112, 127);
            this.openAudioListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openAudioListButton.Name = "openAudioListButton";
            this.openAudioListButton.Size = new System.Drawing.Size(243, 23);
            this.openAudioListButton.TabIndex = 23;
            this.openAudioListButton.Text = "abrir";
            this.openAudioListButton.UseVisualStyleBackColor = true;
            // 
            // program2Label
            // 
            this.program2Label.AutoSize = true;
            this.program2Label.Location = new System.Drawing.Point(6, 60);
            this.program2Label.Name = "program2Label";
            this.program2Label.Size = new System.Drawing.Size(86, 17);
            this.program2Label.TabIndex = 41;
            this.program2Label.Text = "Programa 2:";
            // 
            // program3Label
            // 
            this.program3Label.AutoSize = true;
            this.program3Label.Location = new System.Drawing.Point(6, 94);
            this.program3Label.Name = "program3Label";
            this.program3Label.Size = new System.Drawing.Size(86, 17);
            this.program3Label.TabIndex = 57;
            this.program3Label.Text = "Programa 3:";
            // 
            // program1Button
            // 
            this.program1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.program1Button.Location = new System.Drawing.Point(112, 27);
            this.program1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.program1Button.Name = "program1Button";
            this.program1Button.Size = new System.Drawing.Size(243, 23);
            this.program1Button.TabIndex = 20;
            this.program1Button.Text = "abrir";
            this.program1Button.UseVisualStyleBackColor = true;
            this.program1Button.Click += new System.EventHandler(this.program1button_Click);
            // 
            // openColorListButton
            // 
            this.openColorListButton.Enabled = false;
            this.openColorListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openColorListButton.Location = new System.Drawing.Point(112, 60);
            this.openColorListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openColorListButton.Name = "openColorListButton";
            this.openColorListButton.Size = new System.Drawing.Size(243, 23);
            this.openColorListButton.TabIndex = 21;
            this.openColorListButton.Text = "abrir";
            this.openColorListButton.UseVisualStyleBackColor = true;
            // 
            // openImgListButton
            // 
            this.openImgListButton.Enabled = false;
            this.openImgListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openImgListButton.Location = new System.Drawing.Point(112, 94);
            this.openImgListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openImgListButton.Name = "openImgListButton";
            this.openImgListButton.Size = new System.Drawing.Size(243, 23);
            this.openImgListButton.TabIndex = 22;
            this.openImgListButton.Text = "abrir";
            this.openImgListButton.UseVisualStyleBackColor = true;
            // 
            // instructionsBox
            // 
            this.instructionsBox.AcceptsReturn = true;
            this.instructionsBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.instructionsBox.Location = new System.Drawing.Point(13, 527);
            this.instructionsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.instructionsBox.Multiline = true;
            this.instructionsBox.Name = "instructionsBox";
            this.instructionsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instructionsBox.Size = new System.Drawing.Size(659, 136);
            this.instructionsBox.TabIndex = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.beepingCheckbox);
            this.groupBox1.Controls.Add(this.numExpoLabel);
            this.groupBox1.Controls.Add(this.numExpo);
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(367, 137);
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
            // numExpoLabel
            // 
            this.numExpoLabel.AutoSize = true;
            this.numExpoLabel.Location = new System.Drawing.Point(12, 58);
            this.numExpoLabel.Name = "numExpoLabel";
            this.numExpoLabel.Size = new System.Drawing.Size(155, 17);
            this.numExpoLabel.TabIndex = 35;
            this.numExpoLabel.Text = "Número de Programas:";
            // 
            // numExpo
            // 
            this.numExpo.Location = new System.Drawing.Point(173, 58);
            this.numExpo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numExpo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numExpo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numExpo.Name = "numExpo";
            this.numExpo.Size = new System.Drawing.Size(80, 22);
            this.numExpo.TabIndex = 11;
            this.numExpo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(22, 744);
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
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(615, 744);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 86;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // ExperimentConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Name = "ExperimentConfig";
            this.Size = new System.Drawing.Size(740, 786);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExpo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox rndIntervalCheck;
        private System.Windows.Forms.Label rndIntervalLabel;
        private System.Windows.Forms.Label intervalTimeLabel;
        private System.Windows.Forms.NumericUpDown intervalTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label program1Label;
        private System.Windows.Forms.Label audioListLabel;
        private System.Windows.Forms.Button openAudioListButton;
        private System.Windows.Forms.Label program2Label;
        private System.Windows.Forms.Label program3Label;
        private System.Windows.Forms.Button program1Button;
        private System.Windows.Forms.Button openColorListButton;
        private System.Windows.Forms.Button openImgListButton;
        private System.Windows.Forms.TextBox instructionsBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.TextBox experimentNameTextBox;
        private System.Windows.Forms.Label experimentNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox beepingCheckbox;
        private System.Windows.Forms.Label numExpoLabel;
        private System.Windows.Forms.NumericUpDown numExpo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}
