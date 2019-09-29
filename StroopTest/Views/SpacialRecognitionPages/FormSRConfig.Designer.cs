namespace TestPlatform.Views.SpecialRecognitionPages
{
    partial class FormSRConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSRConfig));
            this.prgNameTextBox = new System.Windows.Forms.TextBox();
            this.prgNameLabel = new System.Windows.Forms.Label();
            this.expositionGroupBox = new System.Windows.Forms.GroupBox();
            this.testTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wordSingleColor = new System.Windows.Forms.Label();
            this.WordColorPanel = new System.Windows.Forms.Panel();
            this.wordSingleColorButton = new System.Windows.Forms.Button();
            this.wordSingleColorLabel = new System.Windows.Forms.Label();
            this.lblNroEstimulos = new System.Windows.Forms.Label();
            this.stimuluQuantity = new System.Windows.Forms.NumericUpDown();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.fontSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.randomOrderLabel = new System.Windows.Forms.Label();
            this.isRandomExposition = new System.Windows.Forms.CheckBox();
            this.expoTypeLabel = new System.Windows.Forms.Label();
            this.chooseExpoType = new System.Windows.Forms.ComboBox();
            this.numExpoLabel = new System.Windows.Forms.Label();
            this.numExpo = new System.Windows.Forms.NumericUpDown();
            this.stimulusSizeLabel = new System.Windows.Forms.Label();
            this.stimuluSize = new System.Windows.Forms.NumericUpDown();
            this.listGroupBox = new System.Windows.Forms.GroupBox();
            this.openImgListButton = new System.Windows.Forms.Button();
            this.openColorListButton = new System.Windows.Forms.Button();
            this.openWordListButton = new System.Windows.Forms.Button();
            this.imageLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.stimulusInterval = new System.Windows.Forms.NumericUpDown();
            this.stimulusExpoTime = new System.Windows.Forms.NumericUpDown();
            this.randomStimulusTime = new System.Windows.Forms.CheckBox();
            this.randomAttemptTime = new System.Windows.Forms.CheckBox();
            this.attemptInterval = new System.Windows.Forms.NumericUpDown();
            this.modelStimuluIntervalLabel = new System.Windows.Forms.Label();
            this.stimuluExpositionLabel = new System.Windows.Forms.Label();
            this.attemptIntervalLabel = new System.Windows.Forms.Label();
            this.auditorySignalingGroupBox = new System.Windows.Forms.GroupBox();
            this.clickAudioResponse = new System.Windows.Forms.CheckBox();
            this.omissionAudioResponse = new System.Windows.Forms.CheckBox();
            this.expositonAudioResponse = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.instructionsBox = new System.Windows.Forms.TextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.expositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimuluQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stimuluSize)).BeginInit();
            this.listGroupBox.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusExpoTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attemptInterval)).BeginInit();
            this.auditorySignalingGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // prgNameTextBox
            // 
            resources.ApplyResources(this.prgNameTextBox, "prgNameTextBox");
            this.prgNameTextBox.Name = "prgNameTextBox";
            this.prgNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.prgNameTextBox_Validating);
            this.prgNameTextBox.Validated += new System.EventHandler(this.prgNameTextBox_Validated);
            // 
            // prgNameLabel
            // 
            resources.ApplyResources(this.prgNameLabel, "prgNameLabel");
            this.prgNameLabel.Name = "prgNameLabel";
            // 
            // expositionGroupBox
            // 
            this.expositionGroupBox.Controls.Add(this.testTypeComboBox);
            this.expositionGroupBox.Controls.Add(this.label1);
            this.expositionGroupBox.Controls.Add(this.wordSingleColor);
            this.expositionGroupBox.Controls.Add(this.WordColorPanel);
            this.expositionGroupBox.Controls.Add(this.wordSingleColorButton);
            this.expositionGroupBox.Controls.Add(this.wordSingleColorLabel);
            this.expositionGroupBox.Controls.Add(this.lblNroEstimulos);
            this.expositionGroupBox.Controls.Add(this.stimuluQuantity);
            this.expositionGroupBox.Controls.Add(this.fontSizeLabel);
            this.expositionGroupBox.Controls.Add(this.fontSizeUpDown);
            this.expositionGroupBox.Controls.Add(this.randomOrderLabel);
            this.expositionGroupBox.Controls.Add(this.isRandomExposition);
            this.expositionGroupBox.Controls.Add(this.expoTypeLabel);
            this.expositionGroupBox.Controls.Add(this.chooseExpoType);
            this.expositionGroupBox.Controls.Add(this.numExpoLabel);
            this.expositionGroupBox.Controls.Add(this.numExpo);
            this.expositionGroupBox.Controls.Add(this.stimulusSizeLabel);
            this.expositionGroupBox.Controls.Add(this.stimuluSize);
            resources.ApplyResources(this.expositionGroupBox, "expositionGroupBox");
            this.expositionGroupBox.Name = "expositionGroupBox";
            this.expositionGroupBox.TabStop = false;
            // 
            // testTypeComboBox
            // 
            this.testTypeComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.testTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testTypeComboBox.FormattingEnabled = true;
            this.testTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("testTypeComboBox.Items"),
            resources.GetString("testTypeComboBox.Items1"),
            resources.GetString("testTypeComboBox.Items2")});
            resources.ApplyResources(this.testTypeComboBox, "testTypeComboBox");
            this.testTypeComboBox.Name = "testTypeComboBox";
            this.testTypeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TestTypeComboBox_Validating);
            this.testTypeComboBox.Validated += new System.EventHandler(this.TestTypeComboBox_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // wordSingleColor
            // 
            resources.ApplyResources(this.wordSingleColor, "wordSingleColor");
            this.wordSingleColor.Name = "wordSingleColor";
            // 
            // WordColorPanel
            // 
            this.WordColorPanel.BackColor = System.Drawing.Color.Black;
            this.WordColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.WordColorPanel, "WordColorPanel");
            this.WordColorPanel.Name = "WordColorPanel";
            // 
            // wordSingleColorButton
            // 
            resources.ApplyResources(this.wordSingleColorButton, "wordSingleColorButton");
            this.wordSingleColorButton.Name = "wordSingleColorButton";
            this.wordSingleColorButton.UseVisualStyleBackColor = true;
            this.wordSingleColorButton.Click += new System.EventHandler(this.wordSingleColorButton_Click);
            // 
            // wordSingleColorLabel
            // 
            resources.ApplyResources(this.wordSingleColorLabel, "wordSingleColorLabel");
            this.wordSingleColorLabel.Name = "wordSingleColorLabel";
            // 
            // lblNroEstimulos
            // 
            resources.ApplyResources(this.lblNroEstimulos, "lblNroEstimulos");
            this.lblNroEstimulos.Name = "lblNroEstimulos";
            // 
            // stimuluQuantity
            // 
            resources.ApplyResources(this.stimuluQuantity, "stimuluQuantity");
            this.stimuluQuantity.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.stimuluQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stimuluQuantity.Name = "stimuluQuantity";
            this.stimuluQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stimuluQuantity.ValueChanged += new System.EventHandler(this.numExpo_ValueChanged);
            // 
            // fontSizeLabel
            // 
            resources.ApplyResources(this.fontSizeLabel, "fontSizeLabel");
            this.fontSizeLabel.Name = "fontSizeLabel";
            // 
            // fontSizeUpDown
            // 
            this.fontSizeUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            resources.ApplyResources(this.fontSizeUpDown, "fontSizeUpDown");
            this.fontSizeUpDown.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.fontSizeUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fontSizeUpDown.Name = "fontSizeUpDown";
            this.fontSizeUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // randomOrderLabel
            // 
            resources.ApplyResources(this.randomOrderLabel, "randomOrderLabel");
            this.randomOrderLabel.Name = "randomOrderLabel";
            // 
            // isRandomExposition
            // 
            resources.ApplyResources(this.isRandomExposition, "isRandomExposition");
            this.isRandomExposition.Name = "isRandomExposition";
            this.isRandomExposition.TabStop = false;
            this.isRandomExposition.UseVisualStyleBackColor = true;
            // 
            // expoTypeLabel
            // 
            resources.ApplyResources(this.expoTypeLabel, "expoTypeLabel");
            this.expoTypeLabel.Name = "expoTypeLabel";
            // 
            // chooseExpoType
            // 
            this.chooseExpoType.BackColor = System.Drawing.SystemColors.ControlLight;
            this.chooseExpoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseExpoType.FormattingEnabled = true;
            this.chooseExpoType.Items.AddRange(new object[] {
            resources.GetString("chooseExpoType.Items"),
            resources.GetString("chooseExpoType.Items1"),
            resources.GetString("chooseExpoType.Items2")});
            resources.ApplyResources(this.chooseExpoType, "chooseExpoType");
            this.chooseExpoType.Name = "chooseExpoType";
            this.chooseExpoType.Tag = "";
            this.chooseExpoType.SelectedIndexChanged += new System.EventHandler(this.chooseExpoType_SelectedIndexChanged);
            this.chooseExpoType.Validating += new System.ComponentModel.CancelEventHandler(this.chooseExpoType_Validating);
            this.chooseExpoType.Validated += new System.EventHandler(this.chooseExpoType_Validated);
            // 
            // numExpoLabel
            // 
            resources.ApplyResources(this.numExpoLabel, "numExpoLabel");
            this.numExpoLabel.Name = "numExpoLabel";
            // 
            // numExpo
            // 
            resources.ApplyResources(this.numExpo, "numExpo");
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
            this.numExpo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numExpo.ValueChanged += new System.EventHandler(this.numExpo_ValueChanged);
            // 
            // stimulusSizeLabel
            // 
            resources.ApplyResources(this.stimulusSizeLabel, "stimulusSizeLabel");
            this.stimulusSizeLabel.Name = "stimulusSizeLabel";
            // 
            // stimuluSize
            // 
            this.stimuluSize.DecimalPlaces = 2;
            this.stimuluSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            resources.ApplyResources(this.stimuluSize, "stimuluSize");
            this.stimuluSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.stimuluSize.Name = "stimuluSize";
            this.stimuluSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // listGroupBox
            // 
            this.listGroupBox.Controls.Add(this.openImgListButton);
            this.listGroupBox.Controls.Add(this.openColorListButton);
            this.listGroupBox.Controls.Add(this.openWordListButton);
            this.listGroupBox.Controls.Add(this.imageLabel);
            this.listGroupBox.Controls.Add(this.colorLabel);
            this.listGroupBox.Controls.Add(this.wordLabel);
            resources.ApplyResources(this.listGroupBox, "listGroupBox");
            this.listGroupBox.Name = "listGroupBox";
            this.listGroupBox.TabStop = false;
            // 
            // openImgListButton
            // 
            resources.ApplyResources(this.openImgListButton, "openImgListButton");
            this.openImgListButton.Name = "openImgListButton";
            this.openImgListButton.UseVisualStyleBackColor = true;
            this.openImgListButton.TextChanged += new System.EventHandler(this.openListButton_TextChanged);
            this.openImgListButton.Click += new System.EventHandler(this.openImagesList_Click);
            this.openImgListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openListButton_Validating);
            this.openImgListButton.Validated += new System.EventHandler(this.openListButton_Validated);
            // 
            // openColorListButton
            // 
            resources.ApplyResources(this.openColorListButton, "openColorListButton");
            this.openColorListButton.Name = "openColorListButton";
            this.openColorListButton.UseVisualStyleBackColor = true;
            this.openColorListButton.TextChanged += new System.EventHandler(this.openListButton_TextChanged);
            this.openColorListButton.Click += new System.EventHandler(this.openColorsList_Click);
            this.openColorListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openListButton_Validating);
            this.openColorListButton.Validated += new System.EventHandler(this.openListButton_Validated);
            // 
            // openWordListButton
            // 
            this.openWordListButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.openWordListButton, "openWordListButton");
            this.openWordListButton.Name = "openWordListButton";
            this.openWordListButton.UseVisualStyleBackColor = false;
            this.openWordListButton.TextChanged += new System.EventHandler(this.openListButton_TextChanged);
            this.openWordListButton.Click += new System.EventHandler(this.openWordListButton_Click);
            this.openWordListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openListButton_Validating);
            this.openWordListButton.Validated += new System.EventHandler(this.openListButton_Validated);
            // 
            // imageLabel
            // 
            resources.ApplyResources(this.imageLabel, "imageLabel");
            this.imageLabel.Name = "imageLabel";
            // 
            // colorLabel
            // 
            resources.ApplyResources(this.colorLabel, "colorLabel");
            this.colorLabel.Name = "colorLabel";
            // 
            // wordLabel
            // 
            resources.ApplyResources(this.wordLabel, "wordLabel");
            this.wordLabel.Name = "wordLabel";
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.stimulusInterval);
            this.timeGroupBox.Controls.Add(this.stimulusExpoTime);
            this.timeGroupBox.Controls.Add(this.randomStimulusTime);
            this.timeGroupBox.Controls.Add(this.randomAttemptTime);
            this.timeGroupBox.Controls.Add(this.attemptInterval);
            this.timeGroupBox.Controls.Add(this.modelStimuluIntervalLabel);
            this.timeGroupBox.Controls.Add(this.stimuluExpositionLabel);
            this.timeGroupBox.Controls.Add(this.attemptIntervalLabel);
            resources.ApplyResources(this.timeGroupBox, "timeGroupBox");
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.TabStop = false;
            // 
            // stimulusInterval
            // 
            this.stimulusInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.stimulusInterval, "stimulusInterval");
            this.stimulusInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.stimulusInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.stimulusInterval.Name = "stimulusInterval";
            this.stimulusInterval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // stimulusExpoTime
            // 
            this.stimulusExpoTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.stimulusExpoTime, "stimulusExpoTime");
            this.stimulusExpoTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.stimulusExpoTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.stimulusExpoTime.Name = "stimulusExpoTime";
            this.stimulusExpoTime.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // randomStimulusTime
            // 
            resources.ApplyResources(this.randomStimulusTime, "randomStimulusTime");
            this.randomStimulusTime.Name = "randomStimulusTime";
            this.randomStimulusTime.UseVisualStyleBackColor = true;
            // 
            // randomAttemptTime
            // 
            resources.ApplyResources(this.randomAttemptTime, "randomAttemptTime");
            this.randomAttemptTime.Name = "randomAttemptTime";
            this.randomAttemptTime.UseVisualStyleBackColor = true;
            // 
            // attemptInterval
            // 
            this.attemptInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.attemptInterval, "attemptInterval");
            this.attemptInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.attemptInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.attemptInterval.Name = "attemptInterval";
            this.attemptInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // modelStimuluIntervalLabel
            // 
            resources.ApplyResources(this.modelStimuluIntervalLabel, "modelStimuluIntervalLabel");
            this.modelStimuluIntervalLabel.Name = "modelStimuluIntervalLabel";
            // 
            // stimuluExpositionLabel
            // 
            resources.ApplyResources(this.stimuluExpositionLabel, "stimuluExpositionLabel");
            this.stimuluExpositionLabel.Name = "stimuluExpositionLabel";
            // 
            // attemptIntervalLabel
            // 
            resources.ApplyResources(this.attemptIntervalLabel, "attemptIntervalLabel");
            this.attemptIntervalLabel.Name = "attemptIntervalLabel";
            // 
            // auditorySignalingGroupBox
            // 
            this.auditorySignalingGroupBox.Controls.Add(this.clickAudioResponse);
            this.auditorySignalingGroupBox.Controls.Add(this.omissionAudioResponse);
            this.auditorySignalingGroupBox.Controls.Add(this.expositonAudioResponse);
            resources.ApplyResources(this.auditorySignalingGroupBox, "auditorySignalingGroupBox");
            this.auditorySignalingGroupBox.Name = "auditorySignalingGroupBox";
            this.auditorySignalingGroupBox.TabStop = false;
            // 
            // clickAudioResponse
            // 
            resources.ApplyResources(this.clickAudioResponse, "clickAudioResponse");
            this.clickAudioResponse.Name = "clickAudioResponse";
            this.clickAudioResponse.UseVisualStyleBackColor = true;
            // 
            // omissionAudioResponse
            // 
            resources.ApplyResources(this.omissionAudioResponse, "omissionAudioResponse");
            this.omissionAudioResponse.Name = "omissionAudioResponse";
            this.omissionAudioResponse.UseVisualStyleBackColor = true;
            // 
            // expositonAudioResponse
            // 
            resources.ApplyResources(this.expositonAudioResponse, "expositonAudioResponse");
            this.expositonAudioResponse.Name = "expositonAudioResponse";
            this.expositonAudioResponse.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.instructionsBox);
            this.groupBox1.Controls.Add(this.instructionsLabel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // instructionsBox
            // 
            this.instructionsBox.AcceptsReturn = true;
            this.instructionsBox.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.instructionsBox, "instructionsBox");
            this.instructionsBox.Name = "instructionsBox";
            // 
            // instructionsLabel
            // 
            resources.ApplyResources(this.instructionsLabel, "instructionsLabel");
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.instructionsLabel.Name = "instructionsLabel";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.TabStop = false;
            this.helpButton.UseVisualStyleBackColor = false;
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider2.ContainerControl = this;
            resources.ApplyResources(this.errorProvider2, "errorProvider2");
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // FormSRConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.auditorySignalingGroupBox);
            this.Controls.Add(this.timeGroupBox);
            this.Controls.Add(this.listGroupBox);
            this.Controls.Add(this.expositionGroupBox);
            this.Controls.Add(this.prgNameTextBox);
            this.Controls.Add(this.prgNameLabel);
            this.Name = "FormSRConfig";
            this.expositionGroupBox.ResumeLayout(false);
            this.expositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimuluQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stimuluSize)).EndInit();
            this.listGroupBox.ResumeLayout(false);
            this.listGroupBox.PerformLayout();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusExpoTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attemptInterval)).EndInit();
            this.auditorySignalingGroupBox.ResumeLayout(false);
            this.auditorySignalingGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox prgNameTextBox;
        private System.Windows.Forms.Label prgNameLabel;
        private System.Windows.Forms.GroupBox expositionGroupBox;
        private System.Windows.Forms.Label lblNroEstimulos;
        private System.Windows.Forms.NumericUpDown stimuluQuantity;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.NumericUpDown fontSizeUpDown;
        private System.Windows.Forms.Label randomOrderLabel;
        private System.Windows.Forms.CheckBox isRandomExposition;
        private System.Windows.Forms.Label expoTypeLabel;
        private System.Windows.Forms.ComboBox chooseExpoType;
        private System.Windows.Forms.Label numExpoLabel;
        private System.Windows.Forms.NumericUpDown numExpo;
        private System.Windows.Forms.Label stimulusSizeLabel;
        private System.Windows.Forms.NumericUpDown stimuluSize;
        private System.Windows.Forms.GroupBox listGroupBox;
        private System.Windows.Forms.Button openImgListButton;
        private System.Windows.Forms.Button openColorListButton;
        private System.Windows.Forms.Button openWordListButton;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.NumericUpDown stimulusInterval;
        private System.Windows.Forms.NumericUpDown stimulusExpoTime;
        private System.Windows.Forms.CheckBox randomStimulusTime;
        private System.Windows.Forms.CheckBox randomAttemptTime;
        private System.Windows.Forms.NumericUpDown attemptInterval;
        private System.Windows.Forms.Label modelStimuluIntervalLabel;
        private System.Windows.Forms.Label stimuluExpositionLabel;
        private System.Windows.Forms.Label attemptIntervalLabel;
        private System.Windows.Forms.Label wordSingleColor;
        private System.Windows.Forms.Panel WordColorPanel;
        private System.Windows.Forms.Button wordSingleColorButton;
        private System.Windows.Forms.Label wordSingleColorLabel;
        private System.Windows.Forms.GroupBox auditorySignalingGroupBox;
        private System.Windows.Forms.CheckBox omissionAudioResponse;
        private System.Windows.Forms.CheckBox expositonAudioResponse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox instructionsBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox clickAudioResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox testTypeComboBox;
    }
}
