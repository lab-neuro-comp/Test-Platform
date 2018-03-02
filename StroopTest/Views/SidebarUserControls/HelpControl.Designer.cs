namespace TestPlatform.Views.SidebarUserControls
{
    partial class HelpControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpControl));
            this.aboutButton = new System.Windows.Forms.RadioButton();
            this.techInfoButton = new System.Windows.Forms.RadioButton();
            this.helpPageButton = new System.Windows.Forms.RadioButton();
            this.instructionsButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // aboutButton
            // 
            resources.ApplyResources(this.aboutButton, "aboutButton");
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // techInfoButton
            // 
            resources.ApplyResources(this.techInfoButton, "techInfoButton");
            this.techInfoButton.FlatAppearance.BorderSize = 0;
            this.techInfoButton.Name = "techInfoButton";
            this.techInfoButton.UseVisualStyleBackColor = true;
            this.techInfoButton.Click += new System.EventHandler(this.techInfoButton_Click);
            // 
            // helpPageButton
            // 
            resources.ApplyResources(this.helpPageButton, "helpPageButton");
            this.helpPageButton.FlatAppearance.BorderSize = 0;
            this.helpPageButton.Name = "helpPageButton";
            this.helpPageButton.UseVisualStyleBackColor = true;
            this.helpPageButton.Click += new System.EventHandler(this.helpPageButton_Click);
            // 
            // instructionsButton
            // 
            resources.ApplyResources(this.instructionsButton, "instructionsButton");
            this.instructionsButton.FlatAppearance.BorderSize = 0;
            this.instructionsButton.Name = "instructionsButton";
            this.instructionsButton.UseVisualStyleBackColor = true;
            this.instructionsButton.Click += new System.EventHandler(this.instructionsButton_Click);
            // 
            // HelpControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.techInfoButton);
            this.Controls.Add(this.helpPageButton);
            this.Controls.Add(this.instructionsButton);
            this.Name = "HelpControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton aboutButton;
        private System.Windows.Forms.RadioButton techInfoButton;
        private System.Windows.Forms.RadioButton helpPageButton;
        private System.Windows.Forms.RadioButton instructionsButton;
    }
}
