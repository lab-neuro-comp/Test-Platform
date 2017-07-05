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
            this.deleteReactButton = new System.Windows.Forms.RadioButton();
            this.editReactButton = new System.Windows.Forms.RadioButton();
            this.newExperimentButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteReactButton
            // 
            this.deleteReactButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.deleteReactButton.FlatAppearance.BorderSize = 0;
            this.deleteReactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteReactButton.Location = new System.Drawing.Point(0, 81);
            this.deleteReactButton.Name = "deleteReactButton";
            this.deleteReactButton.Size = new System.Drawing.Size(260, 33);
            this.deleteReactButton.TabIndex = 8;
            this.deleteReactButton.Text = "Excluir Experimento";
            this.deleteReactButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteReactButton.UseVisualStyleBackColor = true;
            // 
            // editReactButton
            // 
            this.editReactButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editReactButton.FlatAppearance.BorderSize = 0;
            this.editReactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editReactButton.Location = new System.Drawing.Point(0, 42);
            this.editReactButton.Name = "editReactButton";
            this.editReactButton.Size = new System.Drawing.Size(260, 33);
            this.editReactButton.TabIndex = 7;
            this.editReactButton.Text = "Editar Experimento";
            this.editReactButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editReactButton.UseVisualStyleBackColor = true;
            // 
            // newExperimentButton
            // 
            this.newExperimentButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newExperimentButton.FlatAppearance.BorderSize = 0;
            this.newExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newExperimentButton.Location = new System.Drawing.Point(0, 3);
            this.newExperimentButton.Name = "newExperimentButton";
            this.newExperimentButton.Size = new System.Drawing.Size(260, 33);
            this.newExperimentButton.TabIndex = 6;
            this.newExperimentButton.Text = "Novo Experimento";
            this.newExperimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newExperimentButton.UseVisualStyleBackColor = true;
            this.newExperimentButton.Click += new System.EventHandler(this.newExperimentButton_Click);
            // 
            // ExperimentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteReactButton);
            this.Controls.Add(this.editReactButton);
            this.Controls.Add(this.newExperimentButton);
            this.Name = "ExperimentUserControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton deleteReactButton;
        private System.Windows.Forms.RadioButton editReactButton;
        private System.Windows.Forms.RadioButton newExperimentButton;
    }
}
