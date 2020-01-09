namespace TestPlatform.Views
{
    partial class FormDefineTest
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDefineTest));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.stroopButton = new System.Windows.Forms.RadioButton();
            this.reactionButton = new System.Windows.Forms.RadioButton();
            this.matchingButton = new System.Windows.Forms.RadioButton();
            this.spacialRecognitionButton = new System.Windows.Forms.RadioButton();
            this.experimentButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("comboBox1.AutoCompleteCustomSource")});
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            this.comboBox1.Validated += new System.EventHandler(this.comboBox1_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // stroopButton
            // 
            resources.ApplyResources(this.stroopButton, "stroopButton");
            this.stroopButton.Name = "stroopButton";
            this.stroopButton.TabStop = true;
            this.stroopButton.UseVisualStyleBackColor = true;
            this.stroopButton.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // reactionButton
            // 
            resources.ApplyResources(this.reactionButton, "reactionButton");
            this.reactionButton.Name = "reactionButton";
            this.reactionButton.TabStop = true;
            this.reactionButton.UseVisualStyleBackColor = true;
            this.reactionButton.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // matchingButton
            // 
            resources.ApplyResources(this.matchingButton, "matchingButton");
            this.matchingButton.Name = "matchingButton";
            this.matchingButton.TabStop = true;
            this.matchingButton.UseVisualStyleBackColor = true;
            this.matchingButton.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // spacialRecognitionButton
            // 
            resources.ApplyResources(this.spacialRecognitionButton, "spacialRecognitionButton");
            this.spacialRecognitionButton.Name = "spacialRecognitionButton";
            this.spacialRecognitionButton.TabStop = true;
            this.spacialRecognitionButton.UseVisualStyleBackColor = true;
            this.spacialRecognitionButton.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // experimentButton
            // 
            resources.ApplyResources(this.experimentButton, "experimentButton");
            this.experimentButton.Name = "experimentButton";
            this.experimentButton.TabStop = true;
            this.experimentButton.UseVisualStyleBackColor = true;
            this.experimentButton.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // FormDefineTest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.experimentButton);
            this.Controls.Add(this.spacialRecognitionButton);
            this.Controls.Add(this.matchingButton);
            this.Controls.Add(this.reactionButton);
            this.Controls.Add(this.stroopButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.comboBox1);
            this.Name = "FormDefineTest";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton experimentButton;
        private System.Windows.Forms.RadioButton spacialRecognitionButton;
        private System.Windows.Forms.RadioButton matchingButton;
        private System.Windows.Forms.RadioButton reactionButton;
        private System.Windows.Forms.RadioButton stroopButton;
    }
}