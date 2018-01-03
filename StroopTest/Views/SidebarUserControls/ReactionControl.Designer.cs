namespace TestPlatform.Views.SidebarUserControls
{
    partial class ReactionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReactionControl));
            this.deleteReactButton = new System.Windows.Forms.RadioButton();
            this.editReactButton = new System.Windows.Forms.RadioButton();
            this.newReactButton = new System.Windows.Forms.RadioButton();
            this.recoverReactButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteReactButton
            // 
            resources.ApplyResources(this.deleteReactButton, "deleteReactButton");
            this.deleteReactButton.FlatAppearance.BorderSize = 0;
            this.deleteReactButton.Name = "deleteReactButton";
            this.deleteReactButton.UseVisualStyleBackColor = true;
            this.deleteReactButton.Click += new System.EventHandler(this.deleteReactButton_Click);
            // 
            // editReactButton
            // 
            resources.ApplyResources(this.editReactButton, "editReactButton");
            this.editReactButton.FlatAppearance.BorderSize = 0;
            this.editReactButton.Name = "editReactButton";
            this.editReactButton.UseVisualStyleBackColor = true;
            this.editReactButton.Click += new System.EventHandler(this.editReactButton_Click);
            // 
            // newReactButton
            // 
            resources.ApplyResources(this.newReactButton, "newReactButton");
            this.newReactButton.FlatAppearance.BorderSize = 0;
            this.newReactButton.Name = "newReactButton";
            this.newReactButton.UseVisualStyleBackColor = true;
            this.newReactButton.Click += new System.EventHandler(this.newReactButton_Click);
            // 
            // recoverReactButton
            // 
            resources.ApplyResources(this.recoverReactButton, "recoverReactButton");
            this.recoverReactButton.FlatAppearance.BorderSize = 0;
            this.recoverReactButton.Name = "recoverReactButton";
            this.recoverReactButton.UseVisualStyleBackColor = true;
            this.recoverReactButton.Click += new System.EventHandler(this.recoverReactButton_Click);
            // 
            // ReactionControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recoverReactButton);
            this.Controls.Add(this.deleteReactButton);
            this.Controls.Add(this.editReactButton);
            this.Controls.Add(this.newReactButton);
            this.Name = "ReactionControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton deleteReactButton;
        private System.Windows.Forms.RadioButton editReactButton;
        private System.Windows.Forms.RadioButton newReactButton;
        private System.Windows.Forms.RadioButton recoverReactButton;
    }
}
