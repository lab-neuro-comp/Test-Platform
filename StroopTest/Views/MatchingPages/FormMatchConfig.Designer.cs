using System.Drawing;

namespace TestPlatform.Views.MatchingPages
{
    partial class FormMatchConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMatchConfig));
            this.panel1 = new System.Windows.Forms.Panel();
            this.auditorySignalingGroupBox = new System.Windows.Forms.GroupBox();
            this.omissionAudioResponse = new System.Windows.Forms.CheckBox();
            this.commissionAudioFeedback = new System.Windows.Forms.CheckBox();
            this.feedbackAudioResponse = new System.Windows.Forms.CheckBox();
            this.expositonAudioResponse = new System.Windows.Forms.CheckBox();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.wordSingleColor = new System.Windows.Forms.Label();
            this.WordColorPanel = new System.Windows.Forms.Panel();
            this.wordSingleColorButton = new System.Windows.Forms.Button();
            this.wordSingleColorLabel = new System.Windows.Forms.Label();
            this.DNMTSColorPanel = new System.Windows.Forms.Panel();
            this.DMTSColorPanel = new System.Windows.Forms.Panel();
            this.DMTSBackgroundColor = new System.Windows.Forms.Label();
            this.DNMTSBackgroundColor = new System.Windows.Forms.Label();
            this.DNMTSBackground = new System.Windows.Forms.Button();
            this.DMTSBackground = new System.Windows.Forms.Button();
            this.DNMTSBackgroundLabel = new System.Windows.Forms.Label();
            this.DMTSBackgroundLabel = new System.Windows.Forms.Label();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.stimulusInterval = new System.Windows.Forms.NumericUpDown();
            this.stimulusExpoTime = new System.Windows.Forms.NumericUpDown();
            this.randomModelStimulusTime = new System.Windows.Forms.CheckBox();
            this.randomAttemptTime = new System.Windows.Forms.CheckBox();
            this.attemptInterval = new System.Windows.Forms.NumericUpDown();
            this.modelExpoTime = new System.Windows.Forms.NumericUpDown();
            this.modelStimuluIntervalLabel = new System.Windows.Forms.Label();
            this.stimuluExpositionLabel = new System.Windows.Forms.Label();
            this.attemptIntervalLabel = new System.Windows.Forms.Label();
            this.modelExpositionLabel = new System.Windows.Forms.Label();
            this.listGroupBox = new System.Windows.Forms.GroupBox();
            this.openAudioListButton = new System.Windows.Forms.Button();
            this.openImgListButton = new System.Windows.Forms.Button();
            this.openColorListButton = new System.Windows.Forms.Button();
            this.openWordListButton = new System.Windows.Forms.Button();
            this.audioLabel = new System.Windows.Forms.Label();
            this.imageLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.wordLabel = new System.Windows.Forms.Label();
            this.expositionGroupBox = new System.Windows.Forms.GroupBox();
            this.stimuluType = new System.Windows.Forms.ComboBox();
            this.stimuluTypeLabel = new System.Windows.Forms.Label();
            this.randomModelPosition = new System.Windows.Forms.CheckBox();
            this.randomPositionLabel = new System.Windows.Forms.Label();
            this.randomOrder = new System.Windows.Forms.CheckBox();
            this.expositionType = new System.Windows.Forms.ComboBox();
            this.expositionTypeLabel = new System.Windows.Forms.Label();
            this.closeExpoAWithClick = new System.Windows.Forms.CheckBox();
            this.numExpoLabel = new System.Windows.Forms.Label();
            this.randomStimuluPosition = new System.Windows.Forms.CheckBox();
            this.expoSizeLabel = new System.Windows.Forms.Label();
            this.stimuluNumber = new System.Windows.Forms.NumericUpDown();
            this.expositionSize = new System.Windows.Forms.NumericUpDown();
            this.stimulusNumberLabel = new System.Windows.Forms.Label();
            this.attemptNumber = new System.Windows.Forms.NumericUpDown();
            this.programName = new System.Windows.Forms.TextBox();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.instructionsBox = new System.Windows.Forms.TextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.auditorySignalingGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusExpoTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attemptInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelExpoTime)).BeginInit();
            this.listGroupBox.SuspendLayout();
            this.expositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimuluNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expositionSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attemptNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.auditorySignalingGroupBox);
            this.panel1.Controls.Add(this.colorGroupBox);
            this.panel1.Controls.Add(this.timeGroupBox);
            this.panel1.Controls.Add(this.listGroupBox);
            this.panel1.Controls.Add(this.expositionGroupBox);
            this.panel1.Controls.Add(this.programName);
            this.panel1.Controls.Add(this.programNameLabel);
            this.panel1.Controls.Add(this.helpButton);
            this.panel1.Controls.Add(this.instructionsBox);
            this.panel1.Controls.Add(this.instructionsLabel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // auditorySignalingGroupBox
            // 
            this.auditorySignalingGroupBox.Controls.Add(this.omissionAudioResponse);
            this.auditorySignalingGroupBox.Controls.Add(this.commissionAudioFeedback);
            this.auditorySignalingGroupBox.Controls.Add(this.feedbackAudioResponse);
            this.auditorySignalingGroupBox.Controls.Add(this.expositonAudioResponse);
            resources.ApplyResources(this.auditorySignalingGroupBox, "auditorySignalingGroupBox");
            this.auditorySignalingGroupBox.Name = "auditorySignalingGroupBox";
            this.auditorySignalingGroupBox.TabStop = false;
            // 
            // omissionAudioResponse
            // 
            resources.ApplyResources(this.omissionAudioResponse, "omissionAudioResponse");
            this.omissionAudioResponse.Name = "omissionAudioResponse";
            this.omissionAudioResponse.UseVisualStyleBackColor = true;
            // 
            // commissionAudioFeedback
            // 
            resources.ApplyResources(this.commissionAudioFeedback, "commissionAudioFeedback");
            this.commissionAudioFeedback.Name = "commissionAudioFeedback";
            this.commissionAudioFeedback.UseVisualStyleBackColor = true;
            // 
            // feedbackAudioResponse
            // 
            resources.ApplyResources(this.feedbackAudioResponse, "feedbackAudioResponse");
            this.feedbackAudioResponse.Name = "feedbackAudioResponse";
            this.feedbackAudioResponse.UseVisualStyleBackColor = true;
            // 
            // expositonAudioResponse
            // 
            resources.ApplyResources(this.expositonAudioResponse, "expositonAudioResponse");
            this.expositonAudioResponse.Name = "expositonAudioResponse";
            this.expositonAudioResponse.UseVisualStyleBackColor = true;
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.wordSingleColor);
            this.colorGroupBox.Controls.Add(this.WordColorPanel);
            this.colorGroupBox.Controls.Add(this.wordSingleColorButton);
            this.colorGroupBox.Controls.Add(this.wordSingleColorLabel);
            this.colorGroupBox.Controls.Add(this.DNMTSColorPanel);
            this.colorGroupBox.Controls.Add(this.DMTSColorPanel);
            this.colorGroupBox.Controls.Add(this.DMTSBackgroundColor);
            this.colorGroupBox.Controls.Add(this.DNMTSBackgroundColor);
            this.colorGroupBox.Controls.Add(this.DNMTSBackground);
            this.colorGroupBox.Controls.Add(this.DMTSBackground);
            this.colorGroupBox.Controls.Add(this.DNMTSBackgroundLabel);
            this.colorGroupBox.Controls.Add(this.DMTSBackgroundLabel);
            resources.ApplyResources(this.colorGroupBox, "colorGroupBox");
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.TabStop = false;
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
            // DNMTSColorPanel
            // 
            this.DNMTSColorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DNMTSColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.DNMTSColorPanel, "DNMTSColorPanel");
            this.DNMTSColorPanel.Name = "DNMTSColorPanel";
            // 
            // DMTSColorPanel
            // 
            this.DMTSColorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.DMTSColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.DMTSColorPanel, "DMTSColorPanel");
            this.DMTSColorPanel.Name = "DMTSColorPanel";
            // 
            // DMTSBackgroundColor
            // 
            resources.ApplyResources(this.DMTSBackgroundColor, "DMTSBackgroundColor");
            this.DMTSBackgroundColor.Name = "DMTSBackgroundColor";
            // 
            // DNMTSBackgroundColor
            // 
            resources.ApplyResources(this.DNMTSBackgroundColor, "DNMTSBackgroundColor");
            this.DNMTSBackgroundColor.Name = "DNMTSBackgroundColor";
            // 
            // DNMTSBackground
            // 
            this.DNMTSBackground.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.DNMTSBackground, "DNMTSBackground");
            this.DNMTSBackground.Name = "DNMTSBackground";
            this.DNMTSBackground.UseVisualStyleBackColor = false;
            this.DNMTSBackground.Click += new System.EventHandler(this.DMNTSBackground_Click);
            // 
            // DMTSBackground
            // 
            this.DMTSBackground.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.DMTSBackground, "DMTSBackground");
            this.DMTSBackground.Name = "DMTSBackground";
            this.DMTSBackground.UseVisualStyleBackColor = false;
            this.DMTSBackground.Click += new System.EventHandler(this.DMTSBackground_Click);
            // 
            // DNMTSBackgroundLabel
            // 
            resources.ApplyResources(this.DNMTSBackgroundLabel, "DNMTSBackgroundLabel");
            this.DNMTSBackgroundLabel.Name = "DNMTSBackgroundLabel";
            // 
            // DMTSBackgroundLabel
            // 
            resources.ApplyResources(this.DMTSBackgroundLabel, "DMTSBackgroundLabel");
            this.DMTSBackgroundLabel.Name = "DMTSBackgroundLabel";
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.stimulusInterval);
            this.timeGroupBox.Controls.Add(this.stimulusExpoTime);
            this.timeGroupBox.Controls.Add(this.randomModelStimulusTime);
            this.timeGroupBox.Controls.Add(this.randomAttemptTime);
            this.timeGroupBox.Controls.Add(this.attemptInterval);
            this.timeGroupBox.Controls.Add(this.modelExpoTime);
            this.timeGroupBox.Controls.Add(this.modelStimuluIntervalLabel);
            this.timeGroupBox.Controls.Add(this.stimuluExpositionLabel);
            this.timeGroupBox.Controls.Add(this.attemptIntervalLabel);
            this.timeGroupBox.Controls.Add(this.modelExpositionLabel);
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
            // randomModelStimulusTime
            // 
            resources.ApplyResources(this.randomModelStimulusTime, "randomModelStimulusTime");
            this.randomModelStimulusTime.Name = "randomModelStimulusTime";
            this.randomModelStimulusTime.UseVisualStyleBackColor = true;
            this.randomModelStimulusTime.CheckedChanged += new System.EventHandler(this.randomModelStimulusTime_CheckedChanged);
            // 
            // randomAttemptTime
            // 
            resources.ApplyResources(this.randomAttemptTime, "randomAttemptTime");
            this.randomAttemptTime.Name = "randomAttemptTime";
            this.randomAttemptTime.UseVisualStyleBackColor = true;
            this.randomAttemptTime.CheckedChanged += new System.EventHandler(this.randomAttemptTime_CheckedChanged);
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
            // modelExpoTime
            // 
            this.modelExpoTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.modelExpoTime, "modelExpoTime");
            this.modelExpoTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.modelExpoTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.modelExpoTime.Name = "modelExpoTime";
            this.modelExpoTime.Value = new decimal(new int[] {
            3000,
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
            // modelExpositionLabel
            // 
            resources.ApplyResources(this.modelExpositionLabel, "modelExpositionLabel");
            this.modelExpositionLabel.Name = "modelExpositionLabel";
            // 
            // listGroupBox
            // 
            this.listGroupBox.Controls.Add(this.openAudioListButton);
            this.listGroupBox.Controls.Add(this.openImgListButton);
            this.listGroupBox.Controls.Add(this.openColorListButton);
            this.listGroupBox.Controls.Add(this.openWordListButton);
            this.listGroupBox.Controls.Add(this.audioLabel);
            this.listGroupBox.Controls.Add(this.imageLabel);
            this.listGroupBox.Controls.Add(this.colorLabel);
            this.listGroupBox.Controls.Add(this.wordLabel);
            resources.ApplyResources(this.listGroupBox, "listGroupBox");
            this.listGroupBox.Name = "listGroupBox";
            this.listGroupBox.TabStop = false;
            this.listGroupBox.Enter += new System.EventHandler(this.listGroupBox_Enter);
            // 
            // openAudioListButton
            // 
            resources.ApplyResources(this.openAudioListButton, "openAudioListButton");
            this.openAudioListButton.Name = "openAudioListButton";
            this.openAudioListButton.UseVisualStyleBackColor = true;
            this.openAudioListButton.Click += new System.EventHandler(this.openAudioList_Click);
            this.openAudioListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openAudioListButton_Validating);
            this.openAudioListButton.Validated += new System.EventHandler(this.openAudioListButton_Validated);
            // 
            // openImgListButton
            // 
            resources.ApplyResources(this.openImgListButton, "openImgListButton");
            this.openImgListButton.Name = "openImgListButton";
            this.openImgListButton.UseVisualStyleBackColor = true;
            this.openImgListButton.TextChanged += new System.EventHandler(this.openImgListButton_TextChanged);
            this.openImgListButton.Click += new System.EventHandler(this.openImagesList_Click);
            this.openImgListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openImgListButton_Validating);
            this.openImgListButton.Validated += new System.EventHandler(this.openImgListButton_Validated);
            // 
            // openColorListButton
            // 
            resources.ApplyResources(this.openColorListButton, "openColorListButton");
            this.openColorListButton.Name = "openColorListButton";
            this.openColorListButton.UseVisualStyleBackColor = true;
            this.openColorListButton.Click += new System.EventHandler(this.openColorsList_Click);
            this.openColorListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openColorListButton_Validating);
            this.openColorListButton.Validated += new System.EventHandler(this.openColorListButton_Validated);
            // 
            // openWordListButton
            // 
            this.openWordListButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.openWordListButton, "openWordListButton");
            this.openWordListButton.Name = "openWordListButton";
            this.openWordListButton.UseVisualStyleBackColor = false;
            this.openWordListButton.TextChanged += new System.EventHandler(this.openWordListButton_TextChanged);
            this.openWordListButton.Click += new System.EventHandler(this.openWordsList_Click);
            this.openWordListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openWordListButton_Validating);
            this.openWordListButton.Validated += new System.EventHandler(this.openWordListButton_Validated);
            // 
            // audioLabel
            // 
            resources.ApplyResources(this.audioLabel, "audioLabel");
            this.audioLabel.Name = "audioLabel";
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
            // expositionGroupBox
            // 
            this.expositionGroupBox.Controls.Add(this.stimuluType);
            this.expositionGroupBox.Controls.Add(this.stimuluTypeLabel);
            this.expositionGroupBox.Controls.Add(this.randomModelPosition);
            this.expositionGroupBox.Controls.Add(this.randomPositionLabel);
            this.expositionGroupBox.Controls.Add(this.randomOrder);
            this.expositionGroupBox.Controls.Add(this.expositionType);
            this.expositionGroupBox.Controls.Add(this.expositionTypeLabel);
            this.expositionGroupBox.Controls.Add(this.closeExpoAWithClick);
            this.expositionGroupBox.Controls.Add(this.numExpoLabel);
            this.expositionGroupBox.Controls.Add(this.randomStimuluPosition);
            this.expositionGroupBox.Controls.Add(this.expoSizeLabel);
            this.expositionGroupBox.Controls.Add(this.stimuluNumber);
            this.expositionGroupBox.Controls.Add(this.expositionSize);
            this.expositionGroupBox.Controls.Add(this.stimulusNumberLabel);
            this.expositionGroupBox.Controls.Add(this.attemptNumber);
            resources.ApplyResources(this.expositionGroupBox, "expositionGroupBox");
            this.expositionGroupBox.Name = "expositionGroupBox";
            this.expositionGroupBox.TabStop = false;
            // 
            // stimuluType
            // 
            this.stimuluType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stimuluType.FormattingEnabled = true;
            this.stimuluType.Items.AddRange(new object[] {
            resources.GetString("stimuluType.Items"),
            resources.GetString("stimuluType.Items1"),
            resources.GetString("stimuluType.Items2")});
            resources.ApplyResources(this.stimuluType, "stimuluType");
            this.stimuluType.Name = "stimuluType";
            this.stimuluType.SelectedIndexChanged += new System.EventHandler(this.stimuluType_SelectedIndexChanged);
            this.stimuluType.Validating += new System.ComponentModel.CancelEventHandler(this.stimuluType_Validating);
            this.stimuluType.Validated += new System.EventHandler(this.stimuluType_Validated);
            // 
            // stimuluTypeLabel
            // 
            resources.ApplyResources(this.stimuluTypeLabel, "stimuluTypeLabel");
            this.stimuluTypeLabel.Name = "stimuluTypeLabel";
            // 
            // randomModelPosition
            // 
            resources.ApplyResources(this.randomModelPosition, "randomModelPosition");
            this.randomModelPosition.Name = "randomModelPosition";
            this.randomModelPosition.UseVisualStyleBackColor = true;
            // 
            // randomPositionLabel
            // 
            resources.ApplyResources(this.randomPositionLabel, "randomPositionLabel");
            this.randomPositionLabel.Name = "randomPositionLabel";
            // 
            // randomOrder
            // 
            resources.ApplyResources(this.randomOrder, "randomOrder");
            this.randomOrder.Name = "randomOrder";
            this.randomOrder.UseVisualStyleBackColor = true;
            // 
            // expositionType
            // 
            this.expositionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expositionType.FormattingEnabled = true;
            this.expositionType.Items.AddRange(new object[] {
            resources.GetString("expositionType.Items"),
            resources.GetString("expositionType.Items1"),
            resources.GetString("expositionType.Items2"),
            resources.GetString("expositionType.Items3")});
            resources.ApplyResources(this.expositionType, "expositionType");
            this.expositionType.Name = "expositionType";
            this.expositionType.SelectedIndexChanged += new System.EventHandler(this.expositionType_SelectedIndexChanged);
            this.expositionType.Validating += new System.ComponentModel.CancelEventHandler(this.expositionType_Validating);
            this.expositionType.Validated += new System.EventHandler(this.expositionType_Validated);
            // 
            // expositionTypeLabel
            // 
            resources.ApplyResources(this.expositionTypeLabel, "expositionTypeLabel");
            this.expositionTypeLabel.Name = "expositionTypeLabel";
            // 
            // closeExpoAWithClick
            // 
            resources.ApplyResources(this.closeExpoAWithClick, "closeExpoAWithClick");
            this.closeExpoAWithClick.Name = "closeExpoAWithClick";
            this.closeExpoAWithClick.UseVisualStyleBackColor = true;
            this.closeExpoAWithClick.CheckedChanged += new System.EventHandler(this.closeExpoAWithClick_CheckedChanged);
            // 
            // numExpoLabel
            // 
            resources.ApplyResources(this.numExpoLabel, "numExpoLabel");
            this.numExpoLabel.Name = "numExpoLabel";
            // 
            // randomStimuluPosition
            // 
            resources.ApplyResources(this.randomStimuluPosition, "randomStimuluPosition");
            this.randomStimuluPosition.Name = "randomStimuluPosition";
            this.randomStimuluPosition.UseVisualStyleBackColor = true;
            // 
            // expoSizeLabel
            // 
            resources.ApplyResources(this.expoSizeLabel, "expoSizeLabel");
            this.expoSizeLabel.Name = "expoSizeLabel";
            // 
            // stimuluNumber
            // 
            resources.ApplyResources(this.stimuluNumber, "stimuluNumber");
            this.stimuluNumber.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.stimuluNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.stimuluNumber.Name = "stimuluNumber";
            this.stimuluNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.stimuluNumber.ValueChanged += new System.EventHandler(this.attemptAndNumExpo_ValueChanged);
            // 
            // expositionSize
            // 
            resources.ApplyResources(this.expositionSize, "expositionSize");
            this.expositionSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.expositionSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.expositionSize.Name = "expositionSize";
            this.expositionSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // stimulusNumberLabel
            // 
            resources.ApplyResources(this.stimulusNumberLabel, "stimulusNumberLabel");
            this.stimulusNumberLabel.Name = "stimulusNumberLabel";
            // 
            // attemptNumber
            // 
            resources.ApplyResources(this.attemptNumber, "attemptNumber");
            this.attemptNumber.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.attemptNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.attemptNumber.Name = "attemptNumber";
            this.attemptNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.attemptNumber.ValueChanged += new System.EventHandler(this.attemptAndNumExpo_ValueChanged);
            // 
            // programName
            // 
            resources.ApplyResources(this.programName, "programName");
            this.programName.Name = "programName";
            this.programName.Validating += new System.ComponentModel.CancelEventHandler(this.programName_Validating);
            this.programName.Validated += new System.EventHandler(this.programName_Validated);
            // 
            // programNameLabel
            // 
            resources.ApplyResources(this.programNameLabel, "programNameLabel");
            this.programNameLabel.Name = "programNameLabel";
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.TabStop = false;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
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
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider2.ContainerControl = this;
            resources.ApplyResources(this.errorProvider2, "errorProvider2");
            // 
            // FormMatchConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.panel1);
            this.Name = "FormMatchConfig";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.auditorySignalingGroupBox.ResumeLayout(false);
            this.auditorySignalingGroupBox.PerformLayout();
            this.colorGroupBox.ResumeLayout(false);
            this.colorGroupBox.PerformLayout();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stimulusExpoTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attemptInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelExpoTime)).EndInit();
            this.listGroupBox.ResumeLayout(false);
            this.listGroupBox.PerformLayout();
            this.expositionGroupBox.ResumeLayout(false);
            this.expositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stimuluNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expositionSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attemptNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox instructionsBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.TextBox programName;
        private System.Windows.Forms.Label programNameLabel;
        private System.Windows.Forms.GroupBox expositionGroupBox;
        private System.Windows.Forms.ComboBox expositionType;
        private System.Windows.Forms.Label expositionTypeLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown stimuluNumber;
        private System.Windows.Forms.Label stimulusNumberLabel;
        private System.Windows.Forms.NumericUpDown expositionSize;
        private System.Windows.Forms.Label expoSizeLabel;
        private System.Windows.Forms.Label numExpoLabel;
        private System.Windows.Forms.NumericUpDown attemptNumber;
        private System.Windows.Forms.CheckBox randomStimuluPosition;
        private System.Windows.Forms.CheckBox randomOrder;
        private System.Windows.Forms.GroupBox listGroupBox;
        private System.Windows.Forms.Button openAudioListButton;
        private System.Windows.Forms.Button openImgListButton;
        private System.Windows.Forms.Button openColorListButton;
        private System.Windows.Forms.Button openWordListButton;
        private System.Windows.Forms.Label audioLabel;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.NumericUpDown stimulusInterval;
        private System.Windows.Forms.NumericUpDown stimulusExpoTime;
        private System.Windows.Forms.NumericUpDown attemptInterval;
        private System.Windows.Forms.NumericUpDown modelExpoTime;
        private System.Windows.Forms.Label modelStimuluIntervalLabel;
        private System.Windows.Forms.Label stimuluExpositionLabel;
        private System.Windows.Forms.Label attemptIntervalLabel;
        private System.Windows.Forms.Label modelExpositionLabel;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Label DNMTSBackgroundLabel;
        private System.Windows.Forms.Label DMTSBackgroundLabel;
        private System.Windows.Forms.Button DNMTSBackground;
        private System.Windows.Forms.Button DMTSBackground;
        private System.Windows.Forms.Label DMTSBackgroundColor;
        private System.Windows.Forms.Label DNMTSBackgroundColor;
        private System.Windows.Forms.Panel DNMTSColorPanel;
        private System.Windows.Forms.Panel DMTSColorPanel;
        private System.Windows.Forms.CheckBox randomAttemptTime;
        private System.Windows.Forms.GroupBox auditorySignalingGroupBox;
        private System.Windows.Forms.CheckBox closeExpoAWithClick;
        private System.Windows.Forms.CheckBox randomModelStimulusTime;
        private System.Windows.Forms.CheckBox randomModelPosition;
        private System.Windows.Forms.Label randomPositionLabel;
        private System.Windows.Forms.ComboBox stimuluType;
        private System.Windows.Forms.Label stimuluTypeLabel;
        private System.Windows.Forms.Label wordSingleColor;
        private System.Windows.Forms.Panel WordColorPanel;
        private System.Windows.Forms.Button wordSingleColorButton;
        private System.Windows.Forms.Label wordSingleColorLabel;
        private System.Windows.Forms.CheckBox feedbackAudioResponse;
        private System.Windows.Forms.CheckBox expositonAudioResponse;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.CheckBox omissionAudioResponse;
        private System.Windows.Forms.CheckBox commissionAudioFeedback;
    }
}
