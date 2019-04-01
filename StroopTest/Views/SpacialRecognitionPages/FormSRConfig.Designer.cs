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
            this.prgNameTextBox.Location = new System.Drawing.Point(115, 8);
            this.prgNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.prgNameTextBox.MaxLength = 300;
            this.prgNameTextBox.Name = "prgNameTextBox";
            this.prgNameTextBox.Size = new System.Drawing.Size(171, 20);
            this.prgNameTextBox.TabIndex = 35;
            this.prgNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.prgNameTextBox_Validating);
            this.prgNameTextBox.Validated += new System.EventHandler(this.prgNameTextBox_Validated);
            // 
            // prgNameLabel
            // 
            this.prgNameLabel.AutoSize = true;
            this.prgNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.prgNameLabel.Location = new System.Drawing.Point(10, 10);
            this.prgNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.prgNameLabel.Name = "prgNameLabel";
            this.prgNameLabel.Size = new System.Drawing.Size(101, 13);
            this.prgNameLabel.TabIndex = 36;
            this.prgNameLabel.Text = "Nome do Programa:";
            // 
            // expositionGroupBox
            // 
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
            this.expositionGroupBox.Location = new System.Drawing.Point(11, 32);
            this.expositionGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.expositionGroupBox.Name = "expositionGroupBox";
            this.expositionGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.expositionGroupBox.Size = new System.Drawing.Size(275, 189);
            this.expositionGroupBox.TabIndex = 37;
            this.expositionGroupBox.TabStop = false;
            this.expositionGroupBox.Text = "Exposição";
            // 
            // wordSingleColor
            // 
            this.wordSingleColor.AutoSize = true;
            this.wordSingleColor.Enabled = false;
            this.wordSingleColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wordSingleColor.Location = new System.Drawing.Point(196, 158);
            this.wordSingleColor.Name = "wordSingleColor";
            this.wordSingleColor.Size = new System.Drawing.Size(50, 13);
            this.wordSingleColor.TabIndex = 188;
            this.wordSingleColor.Text = "#000000";
            // 
            // WordColorPanel
            // 
            this.WordColorPanel.BackColor = System.Drawing.Color.Black;
            this.WordColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WordColorPanel.Enabled = false;
            this.WordColorPanel.Location = new System.Drawing.Point(173, 154);
            this.WordColorPanel.Name = "WordColorPanel";
            this.WordColorPanel.Size = new System.Drawing.Size(17, 18);
            this.WordColorPanel.TabIndex = 187;
            // 
            // wordSingleColorButton
            // 
            this.wordSingleColorButton.Enabled = false;
            this.wordSingleColorButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wordSingleColorButton.Location = new System.Drawing.Point(99, 153);
            this.wordSingleColorButton.Name = "wordSingleColorButton";
            this.wordSingleColorButton.Size = new System.Drawing.Size(68, 23);
            this.wordSingleColorButton.TabIndex = 185;
            this.wordSingleColorButton.Text = "escolher";
            this.wordSingleColorButton.UseVisualStyleBackColor = true;
            this.wordSingleColorButton.Click += new System.EventHandler(this.wordSingleColorButton_Click);
            // 
            // wordSingleColorLabel
            // 
            this.wordSingleColorLabel.AutoSize = true;
            this.wordSingleColorLabel.Enabled = false;
            this.wordSingleColorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wordSingleColorLabel.Location = new System.Drawing.Point(10, 158);
            this.wordSingleColorLabel.Name = "wordSingleColorLabel";
            this.wordSingleColorLabel.Size = new System.Drawing.Size(89, 13);
            this.wordSingleColorLabel.TabIndex = 186;
            this.wordSingleColorLabel.Text = "Cor das palavras:";
            // 
            // lblNroEstimulos
            // 
            this.lblNroEstimulos.AutoSize = true;
            this.lblNroEstimulos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNroEstimulos.Location = new System.Drawing.Point(8, 114);
            this.lblNroEstimulos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNroEstimulos.Name = "lblNroEstimulos";
            this.lblNroEstimulos.Size = new System.Drawing.Size(106, 13);
            this.lblNroEstimulos.TabIndex = 184;
            this.lblNroEstimulos.Text = "Número de Estimulos";
            // 
            // stimuluQuantity
            // 
            this.stimuluQuantity.Location = new System.Drawing.Point(124, 112);
            this.stimuluQuantity.Margin = new System.Windows.Forms.Padding(2);
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
            this.stimuluQuantity.Size = new System.Drawing.Size(60, 20);
            this.stimuluQuantity.TabIndex = 183;
            this.stimuluQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stimuluQuantity.ValueChanged += new System.EventHandler(this.numExpo_ValueChanged);
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fontSizeLabel.Location = new System.Drawing.Point(8, 68);
            this.fontSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(100, 13);
            this.fontSizeLabel.TabIndex = 182;
            this.fontSizeLabel.Text = "Tamanho da Fonte:";
            // 
            // fontSizeUpDown
            // 
            this.fontSizeUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.fontSizeUpDown.Location = new System.Drawing.Point(148, 66);
            this.fontSizeUpDown.Margin = new System.Windows.Forms.Padding(2);
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
            this.fontSizeUpDown.Size = new System.Drawing.Size(60, 20);
            this.fontSizeUpDown.TabIndex = 4;
            this.fontSizeUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // randomOrderLabel
            // 
            this.randomOrderLabel.AutoSize = true;
            this.randomOrderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.randomOrderLabel.Location = new System.Drawing.Point(8, 137);
            this.randomOrderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.randomOrderLabel.Name = "randomOrderLabel";
            this.randomOrderLabel.Size = new System.Drawing.Size(84, 13);
            this.randomOrderLabel.TabIndex = 177;
            this.randomOrderLabel.Text = "Ordem aleatória:";
            this.randomOrderLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // isRandomExposition
            // 
            this.isRandomExposition.AutoSize = true;
            this.isRandomExposition.Enabled = false;
            this.isRandomExposition.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.isRandomExposition.Location = new System.Drawing.Point(99, 137);
            this.isRandomExposition.Margin = new System.Windows.Forms.Padding(2);
            this.isRandomExposition.Name = "isRandomExposition";
            this.isRandomExposition.Size = new System.Drawing.Size(15, 14);
            this.isRandomExposition.TabIndex = 8;
            this.isRandomExposition.TabStop = false;
            this.isRandomExposition.UseVisualStyleBackColor = true;
            // 
            // expoTypeLabel
            // 
            this.expoTypeLabel.AutoSize = true;
            this.expoTypeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.expoTypeLabel.Location = new System.Drawing.Point(8, 21);
            this.expoTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.expoTypeLabel.Name = "expoTypeLabel";
            this.expoTypeLabel.Size = new System.Drawing.Size(90, 13);
            this.expoTypeLabel.TabIndex = 168;
            this.expoTypeLabel.Text = "Tipo de Estímulo:";
            // 
            // chooseExpoType
            // 
            this.chooseExpoType.BackColor = System.Drawing.SystemColors.ControlLight;
            this.chooseExpoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseExpoType.FormattingEnabled = true;
            this.chooseExpoType.Items.AddRange(new object[] {
            "Imagem",
            "Palavra",
            "Palavra e Cor"});
            this.chooseExpoType.Location = new System.Drawing.Point(101, 18);
            this.chooseExpoType.Margin = new System.Windows.Forms.Padding(2);
            this.chooseExpoType.Name = "chooseExpoType";
            this.chooseExpoType.Size = new System.Drawing.Size(140, 21);
            this.chooseExpoType.TabIndex = 2;
            this.chooseExpoType.Tag = "";
            this.chooseExpoType.SelectedIndexChanged += new System.EventHandler(this.chooseExpoType_SelectedIndexChanged);
            this.chooseExpoType.Validating += new System.ComponentModel.CancelEventHandler(this.chooseExpoType_Validating);
            this.chooseExpoType.Validated += new System.EventHandler(this.chooseExpoType_Validated);
            // 
            // numExpoLabel
            // 
            this.numExpoLabel.AutoSize = true;
            this.numExpoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numExpoLabel.Location = new System.Drawing.Point(8, 90);
            this.numExpoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numExpoLabel.Name = "numExpoLabel";
            this.numExpoLabel.Size = new System.Drawing.Size(115, 13);
            this.numExpoLabel.TabIndex = 35;
            this.numExpoLabel.Text = "Número de Tentativas:";
            // 
            // numExpo
            // 
            this.numExpo.Location = new System.Drawing.Point(124, 88);
            this.numExpo.Margin = new System.Windows.Forms.Padding(2);
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
            this.numExpo.Size = new System.Drawing.Size(60, 20);
            this.numExpo.TabIndex = 7;
            this.numExpo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numExpo.ValueChanged += new System.EventHandler(this.numExpo_ValueChanged);
            // 
            // stimulusSizeLabel
            // 
            this.stimulusSizeLabel.AutoSize = true;
            this.stimulusSizeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.stimulusSizeLabel.Location = new System.Drawing.Point(8, 45);
            this.stimulusSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stimulusSizeLabel.Name = "stimulusSizeLabel";
            this.stimulusSizeLabel.Size = new System.Drawing.Size(114, 13);
            this.stimulusSizeLabel.TabIndex = 159;
            this.stimulusSizeLabel.Text = "Tamanho do Estímulo:";
            // 
            // stimuluSize
            // 
            this.stimuluSize.DecimalPlaces = 2;
            this.stimuluSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.stimuluSize.Location = new System.Drawing.Point(149, 42);
            this.stimuluSize.Margin = new System.Windows.Forms.Padding(2);
            this.stimuluSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.stimuluSize.Name = "stimuluSize";
            this.stimuluSize.Size = new System.Drawing.Size(60, 20);
            this.stimuluSize.TabIndex = 3;
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
            this.listGroupBox.Location = new System.Drawing.Point(11, 226);
            this.listGroupBox.Name = "listGroupBox";
            this.listGroupBox.Size = new System.Drawing.Size(275, 108);
            this.listGroupBox.TabIndex = 38;
            this.listGroupBox.TabStop = false;
            this.listGroupBox.Text = "Listas";
            // 
            // openImgListButton
            // 
            this.openImgListButton.Enabled = false;
            this.openImgListButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.openImgListButton.Location = new System.Drawing.Point(72, 77);
            this.openImgListButton.Name = "openImgListButton";
            this.openImgListButton.Size = new System.Drawing.Size(110, 23);
            this.openImgListButton.TabIndex = 12;
            this.openImgListButton.Text = "abrir";
            this.openImgListButton.UseVisualStyleBackColor = true;
            this.openImgListButton.TextChanged += new System.EventHandler(this.openListButton_TextChanged);
            this.openImgListButton.Click += new System.EventHandler(this.openImagesList_Click);
            this.openImgListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openListButton_Validating);
            this.openImgListButton.Validated += new System.EventHandler(this.openListButton_Validated);
            // 
            // openColorListButton
            // 
            this.openColorListButton.Enabled = false;
            this.openColorListButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.openColorListButton.Location = new System.Drawing.Point(72, 48);
            this.openColorListButton.Name = "openColorListButton";
            this.openColorListButton.Size = new System.Drawing.Size(110, 23);
            this.openColorListButton.TabIndex = 11;
            this.openColorListButton.Text = "abrir";
            this.openColorListButton.UseVisualStyleBackColor = true;
            this.openColorListButton.TextChanged += new System.EventHandler(this.openListButton_TextChanged);
            this.openColorListButton.Click += new System.EventHandler(this.openColorsList_Click);
            this.openColorListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openListButton_Validating);
            this.openColorListButton.Validated += new System.EventHandler(this.openListButton_Validated);
            // 
            // openWordListButton
            // 
            this.openWordListButton.BackColor = System.Drawing.Color.Transparent;
            this.openWordListButton.Enabled = false;
            this.openWordListButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.openWordListButton.Location = new System.Drawing.Point(72, 19);
            this.openWordListButton.Name = "openWordListButton";
            this.openWordListButton.Size = new System.Drawing.Size(110, 23);
            this.openWordListButton.TabIndex = 10;
            this.openWordListButton.Text = "abrir";
            this.openWordListButton.UseVisualStyleBackColor = false;
            this.openWordListButton.TextChanged += new System.EventHandler(this.openListButton_TextChanged);
            this.openWordListButton.Click += new System.EventHandler(this.openWordListButton_Click);
            this.openWordListButton.Validating += new System.ComponentModel.CancelEventHandler(this.openListButton_Validating);
            this.openWordListButton.Validated += new System.EventHandler(this.openListButton_Validated);
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.imageLabel.Location = new System.Drawing.Point(16, 82);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(50, 13);
            this.imageLabel.TabIndex = 2;
            this.imageLabel.Text = "Imagens:";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorLabel.Location = new System.Drawing.Point(29, 53);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(37, 13);
            this.colorLabel.TabIndex = 1;
            this.colorLabel.Text = "Cores:";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.wordLabel.Location = new System.Drawing.Point(15, 24);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(51, 13);
            this.wordLabel.TabIndex = 0;
            this.wordLabel.Text = "Palavras:";
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
            this.timeGroupBox.Location = new System.Drawing.Point(306, 32);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(278, 139);
            this.timeGroupBox.TabIndex = 87;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "Tempo";
            // 
            // stimulusInterval
            // 
            this.stimulusInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.stimulusInterval.Location = new System.Drawing.Point(148, 42);
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
            this.stimulusInterval.Size = new System.Drawing.Size(57, 20);
            this.stimulusInterval.TabIndex = 17;
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
            this.stimulusExpoTime.Location = new System.Drawing.Point(159, 18);
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
            this.stimulusExpoTime.Size = new System.Drawing.Size(57, 20);
            this.stimulusExpoTime.TabIndex = 16;
            this.stimulusExpoTime.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // randomStimulusTime
            // 
            this.randomStimulusTime.AutoSize = true;
            this.randomStimulusTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.randomStimulusTime.Location = new System.Drawing.Point(10, 92);
            this.randomStimulusTime.Name = "randomStimulusTime";
            this.randomStimulusTime.Size = new System.Drawing.Size(171, 17);
            this.randomStimulusTime.TabIndex = 19;
            this.randomStimulusTime.Text = "Atraso entre estímulos variável";
            this.randomStimulusTime.UseVisualStyleBackColor = true;
            // 
            // randomAttemptTime
            // 
            this.randomAttemptTime.AutoSize = true;
            this.randomAttemptTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.randomAttemptTime.Location = new System.Drawing.Point(10, 115);
            this.randomAttemptTime.Name = "randomAttemptTime";
            this.randomAttemptTime.Size = new System.Drawing.Size(172, 17);
            this.randomAttemptTime.TabIndex = 20;
            this.randomAttemptTime.Text = "Atraso entre tentativas variável";
            this.randomAttemptTime.UseVisualStyleBackColor = true;
            // 
            // attemptInterval
            // 
            this.attemptInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.attemptInterval.Location = new System.Drawing.Point(151, 66);
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
            this.attemptInterval.Size = new System.Drawing.Size(57, 20);
            this.attemptInterval.TabIndex = 18;
            this.attemptInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // modelStimuluIntervalLabel
            // 
            this.modelStimuluIntervalLabel.AutoSize = true;
            this.modelStimuluIntervalLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.modelStimuluIntervalLabel.Location = new System.Drawing.Point(7, 45);
            this.modelStimuluIntervalLabel.Name = "modelStimuluIntervalLabel";
            this.modelStimuluIntervalLabel.Size = new System.Drawing.Size(135, 13);
            this.modelStimuluIntervalLabel.TabIndex = 3;
            this.modelStimuluIntervalLabel.Text = "Atraso entre estimulos (ms):";
            // 
            // stimuluExpositionLabel
            // 
            this.stimuluExpositionLabel.AutoSize = true;
            this.stimuluExpositionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.stimuluExpositionLabel.Location = new System.Drawing.Point(6, 21);
            this.stimuluExpositionLabel.Name = "stimuluExpositionLabel";
            this.stimuluExpositionLabel.Size = new System.Drawing.Size(147, 13);
            this.stimuluExpositionLabel.TabIndex = 2;
            this.stimuluExpositionLabel.Text = "Exposição dos estimulos (ms):";
            // 
            // attemptIntervalLabel
            // 
            this.attemptIntervalLabel.AutoSize = true;
            this.attemptIntervalLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.attemptIntervalLabel.Location = new System.Drawing.Point(7, 68);
            this.attemptIntervalLabel.Name = "attemptIntervalLabel";
            this.attemptIntervalLabel.Size = new System.Drawing.Size(138, 13);
            this.attemptIntervalLabel.TabIndex = 1;
            this.attemptIntervalLabel.Text = "Atraso entre tentativas (ms):";
            // 
            // auditorySignalingGroupBox
            // 
            this.auditorySignalingGroupBox.Controls.Add(this.clickAudioResponse);
            this.auditorySignalingGroupBox.Controls.Add(this.omissionAudioResponse);
            this.auditorySignalingGroupBox.Controls.Add(this.expositonAudioResponse);
            this.auditorySignalingGroupBox.Location = new System.Drawing.Point(306, 177);
            this.auditorySignalingGroupBox.Name = "auditorySignalingGroupBox";
            this.auditorySignalingGroupBox.Size = new System.Drawing.Size(281, 59);
            this.auditorySignalingGroupBox.TabIndex = 88;
            this.auditorySignalingGroupBox.TabStop = false;
            this.auditorySignalingGroupBox.Text = "Sinalização auditiva";
            // 
            // clickAudioResponse
            // 
            this.clickAudioResponse.AutoSize = true;
            this.clickAudioResponse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clickAudioResponse.Location = new System.Drawing.Point(107, 16);
            this.clickAudioResponse.Name = "clickAudioResponse";
            this.clickAudioResponse.Size = new System.Drawing.Size(81, 17);
            this.clickAudioResponse.TabIndex = 28;
            this.clickAudioResponse.Text = "Acerto/Erro";
            this.clickAudioResponse.UseVisualStyleBackColor = true;
            // 
            // omissionAudioResponse
            // 
            this.omissionAudioResponse.AutoSize = true;
            this.omissionAudioResponse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.omissionAudioResponse.Location = new System.Drawing.Point(6, 39);
            this.omissionAudioResponse.Name = "omissionAudioResponse";
            this.omissionAudioResponse.Size = new System.Drawing.Size(66, 17);
            this.omissionAudioResponse.TabIndex = 27;
            this.omissionAudioResponse.Text = "Omissão";
            this.omissionAudioResponse.UseVisualStyleBackColor = true;
            // 
            // expositonAudioResponse
            // 
            this.expositonAudioResponse.AutoSize = true;
            this.expositonAudioResponse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.expositonAudioResponse.Location = new System.Drawing.Point(6, 16);
            this.expositonAudioResponse.Name = "expositonAudioResponse";
            this.expositonAudioResponse.Size = new System.Drawing.Size(75, 17);
            this.expositonAudioResponse.TabIndex = 24;
            this.expositonAudioResponse.Text = "Exposição";
            this.expositonAudioResponse.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.instructionsBox);
            this.groupBox1.Controls.Add(this.instructionsLabel);
            this.groupBox1.Location = new System.Drawing.Point(306, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 89);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instruções";
            // 
            // instructionsBox
            // 
            this.instructionsBox.AcceptsReturn = true;
            this.instructionsBox.ForeColor = System.Drawing.Color.Black;
            this.instructionsBox.Location = new System.Drawing.Point(6, 18);
            this.instructionsBox.Margin = new System.Windows.Forms.Padding(2);
            this.instructionsBox.Multiline = true;
            this.instructionsBox.Name = "instructionsBox";
            this.instructionsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instructionsBox.Size = new System.Drawing.Size(270, 66);
            this.instructionsBox.TabIndex = 72;
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.instructionsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.instructionsLabel.Location = new System.Drawing.Point(-135, -10);
            this.instructionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(59, 13);
            this.instructionsLabel.TabIndex = 73;
            this.instructionsLabel.Text = "Instruções:";
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveButton.Location = new System.Drawing.Point(503, 341);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 91;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(12, 341);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 90;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.helpButton.Location = new System.Drawing.Point(556, 4);
            this.helpButton.Margin = new System.Windows.Forms.Padding(2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(26, 26);
            this.helpButton.TabIndex = 92;
            this.helpButton.TabStop = false;
            this.helpButton.UseVisualStyleBackColor = false;
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider2.Icon")));
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // FormSRConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
            this.Location = new System.Drawing.Point(2, 3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSRConfig";
            this.Size = new System.Drawing.Size(596, 375);
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
    }
}
