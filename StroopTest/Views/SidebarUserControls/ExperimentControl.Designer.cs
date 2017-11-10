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
            this.deleteReactButton = new System.Windows.Forms.RadioButton();
            this.editExperimentButton = new System.Windows.Forms.RadioButton();
            this.newExperimentButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteReactButton
            // 
            resources.ApplyResources(this.deleteReactButton, "deleteReactButton");
            this.deleteReactButton.FlatAppearance.BorderSize = 0;
            this.deleteReactButton.Name = "deleteReactButton";
            this.deleteReactButton.UseVisualStyleBackColor = true;
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
            // ExperimentControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteReactButton);
            this.Controls.Add(this.editExperimentButton);
            this.Controls.Add(this.newExperimentButton);
            this.Name = "ExperimentControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton deleteReactButton;
        private System.Windows.Forms.RadioButton editExperimentButton;
        private System.Windows.Forms.RadioButton newExperimentButton;
    }
}
