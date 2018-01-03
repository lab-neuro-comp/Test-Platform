namespace TestPlatform.Views.SidebarUserControls
{
    partial class ExperimentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentControl));
            this.deleteExperimentButton = new System.Windows.Forms.RadioButton();
            this.editExperimentButton = new System.Windows.Forms.RadioButton();
            this.newExperimentButton = new System.Windows.Forms.RadioButton();
            this.recoverExperimentButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteExperimentButton
            // 
            resources.ApplyResources(this.deleteExperimentButton, "deleteExperimentButton");
            this.deleteExperimentButton.FlatAppearance.BorderSize = 0;
            this.deleteExperimentButton.Name = "deleteExperimentButton";
            this.deleteExperimentButton.UseVisualStyleBackColor = true;
            this.deleteExperimentButton.Click += new System.EventHandler(this.deleteExperimentButton_Click);
            // 
            // editExperimentButton
            // 
            resources.ApplyResources(this.editExperimentButton, "editExperimentButton");
            this.editExperimentButton.FlatAppearance.BorderSize = 0;
            this.editExperimentButton.Name = "editExperimentButton";
            this.editExperimentButton.UseVisualStyleBackColor = true;
            this.editExperimentButton.Click += new System.EventHandler(this.editExperimentButton_Click);
            // 
            // newExperimentButton
            // 
            resources.ApplyResources(this.newExperimentButton, "newExperimentButton");
            this.newExperimentButton.FlatAppearance.BorderSize = 0;
            this.newExperimentButton.Name = "newExperimentButton";
            this.newExperimentButton.UseVisualStyleBackColor = true;
            this.newExperimentButton.Click += new System.EventHandler(this.newExperimentButton_Click);
            // 
            // recoverExperimentButton
            // 
            resources.ApplyResources(this.recoverExperimentButton, "recoverExperimentButton");
            this.recoverExperimentButton.FlatAppearance.BorderSize = 0;
            this.recoverExperimentButton.Name = "recoverExperimentButton";
            this.recoverExperimentButton.TabStop = true;
            this.recoverExperimentButton.UseVisualStyleBackColor = true;
            this.recoverExperimentButton.Click += new System.EventHandler(this.recoverExperimentButton_Click);
            // 
            // ExperimentControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recoverExperimentButton);
            this.Controls.Add(this.deleteExperimentButton);
            this.Controls.Add(this.editExperimentButton);
            this.Controls.Add(this.newExperimentButton);
            this.Name = "ExperimentControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton deleteExperimentButton;
        private System.Windows.Forms.RadioButton editExperimentButton;
        private System.Windows.Forms.RadioButton newExperimentButton;
        private System.Windows.Forms.RadioButton recoverExperimentButton;
    }
}
