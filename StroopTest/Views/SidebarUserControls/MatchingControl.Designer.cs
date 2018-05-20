namespace TestPlatform.Views.SidebarUserControls
{
    partial class MatchingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchingControl));
            this.recoverMatchButton = new System.Windows.Forms.RadioButton();
            this.deleteMatchButton = new System.Windows.Forms.RadioButton();
            this.editMatchButton = new System.Windows.Forms.RadioButton();
            this.newMatchButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // recoverMatchButton
            // 
            resources.ApplyResources(this.recoverMatchButton, "recoverMatchButton");
            this.recoverMatchButton.FlatAppearance.BorderSize = 0;
            this.recoverMatchButton.Name = "recoverMatchButton";
            this.recoverMatchButton.UseVisualStyleBackColor = true;
            this.recoverMatchButton.Click += new System.EventHandler(this.recoverMatchButton_Click);
            // 
            // deleteMatchButton
            // 
            resources.ApplyResources(this.deleteMatchButton, "deleteMatchButton");
            this.deleteMatchButton.FlatAppearance.BorderSize = 0;
            this.deleteMatchButton.Name = "deleteMatchButton";
            this.deleteMatchButton.UseVisualStyleBackColor = true;
            this.deleteMatchButton.Click += new System.EventHandler(this.deleteMatchButton_Click);
            // 
            // editMatchButton
            // 
            resources.ApplyResources(this.editMatchButton, "editMatchButton");
            this.editMatchButton.FlatAppearance.BorderSize = 0;
            this.editMatchButton.Name = "editMatchButton";
            this.editMatchButton.UseVisualStyleBackColor = true;
            this.editMatchButton.CheckedChanged += new System.EventHandler(this.editMatchButton_CheckedChanged);
            this.editMatchButton.Click += new System.EventHandler(this.editMatchButton_Click);
            // 
            // newMatchButton
            // 
            resources.ApplyResources(this.newMatchButton, "newMatchButton");
            this.newMatchButton.FlatAppearance.BorderSize = 0;
            this.newMatchButton.Name = "newMatchButton";
            this.newMatchButton.UseVisualStyleBackColor = true;
            this.newMatchButton.Click += new System.EventHandler(this.newMatchButton_Click);
            // 
            // MatchingControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.recoverMatchButton);
            this.Controls.Add(this.deleteMatchButton);
            this.Controls.Add(this.editMatchButton);
            this.Controls.Add(this.newMatchButton);
            this.Name = "MatchingControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton recoverMatchButton;
        private System.Windows.Forms.RadioButton deleteMatchButton;
        private System.Windows.Forms.RadioButton editMatchButton;
        private System.Windows.Forms.RadioButton newMatchButton;
    }
}
