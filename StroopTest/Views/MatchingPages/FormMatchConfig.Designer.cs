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
            this.expositionGroupBox = new System.Windows.Forms.GroupBox();
            this.expositionType = new System.Windows.Forms.ComboBox();
            this.expositionTypeLabel = new System.Windows.Forms.Label();
            this.programName = new System.Windows.Forms.TextBox();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.instructionsBox = new System.Windows.Forms.TextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.stimulusNumberLabel = new System.Windows.Forms.Label();
            this.positionsNumber = new System.Windows.Forms.NumericUpDown();
            this.expoSizeLabel = new System.Windows.Forms.Label();
            this.expositionSize = new System.Windows.Forms.NumericUpDown();
            this.numExpo = new System.Windows.Forms.NumericUpDown();
            this.numExpoLabel = new System.Windows.Forms.Label();
            this.randomPosition = new System.Windows.Forms.CheckBox();
            this.closeExpoAWithClick = new System.Windows.Forms.CheckBox();
            this.ExpoDisposition = new System.Windows.Forms.ComboBox();
            this.dispositionLabel = new System.Windows.Forms.Label();
            this.randomOrder = new System.Windows.Forms.CheckBox();
            this.listGroupBox = new System.Windows.Forms.GroupBox();
            this.wordLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wordListButton = new System.Windows.Forms.Button();
            this.colorListButton = new System.Windows.Forms.Button();
            this.imageListButton = new System.Windows.Forms.Button();
            this.audioListButton = new System.Windows.Forms.Button();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DMTSBackgroundPreview = new System.Windows.Forms.Panel();
            this.DNMTSBackgroundPreview = new System.Windows.Forms.Panel();
            this.DMTSBackground = new System.Windows.Forms.Button();
            this.DMNTSBackground = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.expositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expositionSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpo)).BeginInit();
            this.listGroupBox.SuspendLayout();
            this.timeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.colorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // expositionGroupBox
            // 
            this.expositionGroupBox.Controls.Add(this.randomOrder);
            this.expositionGroupBox.Controls.Add(this.dispositionLabel);
            this.expositionGroupBox.Controls.Add(this.ExpoDisposition);
            this.expositionGroupBox.Controls.Add(this.expositionType);
            this.expositionGroupBox.Controls.Add(this.expositionTypeLabel);
            this.expositionGroupBox.Controls.Add(this.closeExpoAWithClick);
            this.expositionGroupBox.Controls.Add(this.numExpoLabel);
            this.expositionGroupBox.Controls.Add(this.randomPosition);
            this.expositionGroupBox.Controls.Add(this.expoSizeLabel);
            this.expositionGroupBox.Controls.Add(this.positionsNumber);
            this.expositionGroupBox.Controls.Add(this.expositionSize);
            this.expositionGroupBox.Controls.Add(this.stimulusNumberLabel);
            this.expositionGroupBox.Controls.Add(this.numExpo);
            resources.ApplyResources(this.expositionGroupBox, "expositionGroupBox");
            this.expositionGroupBox.Name = "expositionGroupBox";
            this.expositionGroupBox.TabStop = false;
            // 
            // expositionType
            // 
            this.expositionType.FormattingEnabled = true;
            this.expositionType.Items.AddRange(new object[] {
            resources.GetString("expositionType.Items"),
            resources.GetString("expositionType.Items1"),
            resources.GetString("expositionType.Items2")});
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
            // stimulusNumberLabel
            // 
            resources.ApplyResources(this.stimulusNumberLabel, "stimulusNumberLabel");
            this.stimulusNumberLabel.Name = "stimulusNumberLabel";
            // 
            // positionsNumber
            // 
            resources.ApplyResources(this.positionsNumber, "positionsNumber");
            this.positionsNumber.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.positionsNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.positionsNumber.Name = "positionsNumber";
            this.positionsNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // expoSizeLabel
            // 
            resources.ApplyResources(this.expoSizeLabel, "expoSizeLabel");
            this.expoSizeLabel.Name = "expoSizeLabel";
            // 
            // expositionSize
            // 
            resources.ApplyResources(this.expositionSize, "expositionSize");
            this.expositionSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.expositionSize.Name = "expositionSize";
            this.expositionSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
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
            // 
            // numExpoLabel
            // 
            resources.ApplyResources(this.numExpoLabel, "numExpoLabel");
            this.numExpoLabel.Name = "numExpoLabel";
            // 
            // randomPosition
            // 
            resources.ApplyResources(this.randomPosition, "randomPosition");
            this.randomPosition.Name = "randomPosition";
            this.randomPosition.UseVisualStyleBackColor = true;
            // 
            // closeExpoAWithClick
            // 
            resources.ApplyResources(this.closeExpoAWithClick, "closeExpoAWithClick");
            this.closeExpoAWithClick.Name = "closeExpoAWithClick";
            this.closeExpoAWithClick.UseVisualStyleBackColor = true;
            // 
            // ExpoDisposition
            // 
            this.ExpoDisposition.FormattingEnabled = true;
            this.ExpoDisposition.Items.AddRange(new object[] {
            resources.GetString("ExpoDisposition.Items"),
            resources.GetString("ExpoDisposition.Items1")});
            resources.ApplyResources(this.ExpoDisposition, "ExpoDisposition");
            this.ExpoDisposition.Name = "ExpoDisposition";
            this.ExpoDisposition.Validating += new System.ComponentModel.CancelEventHandler(this.ExpoDisposition_Validating);
            this.ExpoDisposition.Validated += new System.EventHandler(this.ExpoDisposition_Validated);
            // 
            // dispositionLabel
            // 
            resources.ApplyResources(this.dispositionLabel, "dispositionLabel");
            this.dispositionLabel.Name = "dispositionLabel";
            // 
            // randomOrder
            // 
            resources.ApplyResources(this.randomOrder, "randomOrder");
            this.randomOrder.Name = "randomOrder";
            this.randomOrder.UseVisualStyleBackColor = true;
            // 
            // listGroupBox
            // 
            this.listGroupBox.Controls.Add(this.audioListButton);
            this.listGroupBox.Controls.Add(this.imageListButton);
            this.listGroupBox.Controls.Add(this.colorListButton);
            this.listGroupBox.Controls.Add(this.wordListButton);
            this.listGroupBox.Controls.Add(this.label4);
            this.listGroupBox.Controls.Add(this.label3);
            this.listGroupBox.Controls.Add(this.label2);
            this.listGroupBox.Controls.Add(this.wordLabel);
            resources.ApplyResources(this.listGroupBox, "listGroupBox");
            this.listGroupBox.Name = "listGroupBox";
            this.listGroupBox.TabStop = false;
            // 
            // wordLabel
            // 
            resources.ApplyResources(this.wordLabel, "wordLabel");
            this.wordLabel.Name = "wordLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // wordListButton
            // 
            resources.ApplyResources(this.wordListButton, "wordListButton");
            this.wordListButton.Name = "wordListButton";
            this.wordListButton.UseVisualStyleBackColor = true;
            // 
            // colorListButton
            // 
            resources.ApplyResources(this.colorListButton, "colorListButton");
            this.colorListButton.Name = "colorListButton";
            this.colorListButton.UseVisualStyleBackColor = true;
            // 
            // imageListButton
            // 
            resources.ApplyResources(this.imageListButton, "imageListButton");
            this.imageListButton.Name = "imageListButton";
            this.imageListButton.UseVisualStyleBackColor = true;
            // 
            // audioListButton
            // 
            resources.ApplyResources(this.audioListButton, "audioListButton");
            this.audioListButton.Name = "audioListButton";
            this.audioListButton.UseVisualStyleBackColor = true;
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.numericUpDown2);
            this.timeGroupBox.Controls.Add(this.numericUpDown3);
            this.timeGroupBox.Controls.Add(this.numericUpDown4);
            this.timeGroupBox.Controls.Add(this.numericUpDown1);
            this.timeGroupBox.Controls.Add(this.label7);
            this.timeGroupBox.Controls.Add(this.label6);
            this.timeGroupBox.Controls.Add(this.label5);
            this.timeGroupBox.Controls.Add(this.label1);
            resources.ApplyResources(this.timeGroupBox, "timeGroupBox");
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.numericUpDown2, "numericUpDown2");
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.numericUpDown3, "numericUpDown3");
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.numericUpDown4, "numericUpDown4");
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.DMNTSBackground);
            this.colorGroupBox.Controls.Add(this.DMTSBackground);
            this.colorGroupBox.Controls.Add(this.DNMTSBackgroundPreview);
            this.colorGroupBox.Controls.Add(this.DMTSBackgroundPreview);
            this.colorGroupBox.Controls.Add(this.label9);
            this.colorGroupBox.Controls.Add(this.label8);
            resources.ApplyResources(this.colorGroupBox, "colorGroupBox");
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // DMTSBackgroundPreview
            // 
            this.DMTSBackgroundPreview.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.DMTSBackgroundPreview, "DMTSBackgroundPreview");
            this.DMTSBackgroundPreview.Name = "DMTSBackgroundPreview";
            // 
            // DNMTSBackgroundPreview
            // 
            this.DNMTSBackgroundPreview.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.DNMTSBackgroundPreview, "DNMTSBackgroundPreview");
            this.DNMTSBackgroundPreview.Name = "DNMTSBackgroundPreview";
            // 
            // DMTSBackground
            // 
            this.DMTSBackground.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.DMTSBackground, "DMTSBackground");
            this.DMTSBackground.Name = "DMTSBackground";
            this.DMTSBackground.UseVisualStyleBackColor = false;
            // 
            // DMNTSBackground
            // 
            this.DMNTSBackground.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.DMNTSBackground, "DMNTSBackground");
            this.DMNTSBackground.Name = "DMNTSBackground";
            this.DMNTSBackground.UseVisualStyleBackColor = false;
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
            this.expositionGroupBox.ResumeLayout(false);
            this.expositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expositionSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpo)).EndInit();
            this.listGroupBox.ResumeLayout(false);
            this.listGroupBox.PerformLayout();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.colorGroupBox.ResumeLayout(false);
            this.colorGroupBox.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown positionsNumber;
        private System.Windows.Forms.Label stimulusNumberLabel;
        private System.Windows.Forms.NumericUpDown expositionSize;
        private System.Windows.Forms.Label expoSizeLabel;
        private System.Windows.Forms.Label numExpoLabel;
        private System.Windows.Forms.NumericUpDown numExpo;
        private System.Windows.Forms.Label dispositionLabel;
        private System.Windows.Forms.ComboBox ExpoDisposition;
        private System.Windows.Forms.CheckBox closeExpoAWithClick;
        private System.Windows.Forms.CheckBox randomPosition;
        private System.Windows.Forms.CheckBox randomOrder;
        private System.Windows.Forms.GroupBox listGroupBox;
        private System.Windows.Forms.Button audioListButton;
        private System.Windows.Forms.Button imageListButton;
        private System.Windows.Forms.Button colorListButton;
        private System.Windows.Forms.Button wordListButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button DMNTSBackground;
        private System.Windows.Forms.Button DMTSBackground;
        private System.Windows.Forms.Panel DNMTSBackgroundPreview;
        private System.Windows.Forms.Panel DMTSBackgroundPreview;
    }
}
