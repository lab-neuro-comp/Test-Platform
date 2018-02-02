namespace TestPlatform.Views.SidebarUserControls
{
    partial class ResultsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsUserControl));
            this.StroopButton = new System.Windows.Forms.RadioButton();
            this.reactionButton = new System.Windows.Forms.RadioButton();
            this.experimentButton = new System.Windows.Forms.RadioButton();
            this.matchingButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // StroopButton
            // 
            resources.ApplyResources(this.StroopButton, "StroopButton");
            this.StroopButton.FlatAppearance.BorderSize = 0;
            this.StroopButton.Name = "StroopButton";
            this.StroopButton.UseVisualStyleBackColor = true;
            this.StroopButton.Click += new System.EventHandler(this.StroopButton_Click);
            // 
            // reactionButton
            // 
            resources.ApplyResources(this.reactionButton, "reactionButton");
            this.reactionButton.FlatAppearance.BorderSize = 0;
            this.reactionButton.Name = "reactionButton";
            this.reactionButton.UseVisualStyleBackColor = true;
            this.reactionButton.Click += new System.EventHandler(this.reactionButton_Click);
            // 
            // experimentButton
            // 
            resources.ApplyResources(this.experimentButton, "experimentButton");
            this.experimentButton.FlatAppearance.BorderSize = 0;
            this.experimentButton.Name = "experimentButton";
            this.experimentButton.UseVisualStyleBackColor = true;
            this.experimentButton.Click += new System.EventHandler(this.experimentButton_Click);
            // 
            // matchingButton
            // 
            resources.ApplyResources(this.matchingButton, "matchingButton");
            this.matchingButton.FlatAppearance.BorderSize = 0;
            this.matchingButton.Name = "matchingButton";
            this.matchingButton.TabStop = true;
            this.matchingButton.UseVisualStyleBackColor = true;
            this.matchingButton.Click += new System.EventHandler(this.matchingButton_Click);
            // 
            // ResultsUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.matchingButton);
            this.Controls.Add(this.experimentButton);
            this.Controls.Add(this.reactionButton);
            this.Controls.Add(this.StroopButton);
            this.Name = "ResultsUserControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton StroopButton;
        private System.Windows.Forms.RadioButton reactionButton;
        private System.Windows.Forms.RadioButton experimentButton;
        private System.Windows.Forms.RadioButton matchingButton;
    }
}
