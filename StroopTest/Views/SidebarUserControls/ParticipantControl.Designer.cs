namespace TestPlatform.Views.SidebarUserControls
{
    partial class ParticipantControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParticipantControl));
            this.editParticipantButton = new System.Windows.Forms.RadioButton();
            this.newParticipantButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // editParticipantButton
            // 
            resources.ApplyResources(this.editParticipantButton, "editParticipantButton");
            this.editParticipantButton.FlatAppearance.BorderSize = 0;
            this.editParticipantButton.Name = "editParticipantButton";
            this.editParticipantButton.UseVisualStyleBackColor = true;
            this.editParticipantButton.Click += new System.EventHandler(this.editParticipantButton_Click);
            // 
            // newParticipantButton
            // 
            resources.ApplyResources(this.newParticipantButton, "newParticipantButton");
            this.newParticipantButton.FlatAppearance.BorderSize = 0;
            this.newParticipantButton.Name = "newParticipantButton";
            this.newParticipantButton.UseVisualStyleBackColor = true;
            this.newParticipantButton.Click += new System.EventHandler(this.newParticipantButton_Click);
            // 
            // ParticipantControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editParticipantButton);
            this.Controls.Add(this.newParticipantButton);
            this.Name = "ParticipantControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton editParticipantButton;
        private System.Windows.Forms.RadioButton newParticipantButton;
    }
}
