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
            this.editExperimentButton = new System.Windows.Forms.RadioButton();
            this.newExperimentButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteReactButton
            // 
            this.deleteReactButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteReactButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.deleteReactButton.Enabled = false;
            this.deleteReactButton.FlatAppearance.BorderSize = 0;
            this.deleteReactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteReactButton.Location = new System.Drawing.Point(0, 81);
            this.deleteReactButton.Name = "deleteReactButton";
            this.deleteReactButton.Size = new System.Drawing.Size(264, 33);
            this.deleteReactButton.TabIndex = 8;
            this.deleteReactButton.Text = "Excluir Experimento";
            this.deleteReactButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteReactButton.UseVisualStyleBackColor = true;
            // 
            // editExperimentButton
            // 
            this.editExperimentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editExperimentButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editExperimentButton.FlatAppearance.BorderSize = 0;
            this.editExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editExperimentButton.Location = new System.Drawing.Point(0, 42);
            this.editExperimentButton.Name = "editExperimentButton";
            this.editExperimentButton.Size = new System.Drawing.Size(264, 33);
            this.editExperimentButton.TabIndex = 7;
            this.editExperimentButton.Text = "Editar Experimento";
            this.editExperimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editExperimentButton.UseVisualStyleBackColor = true;
            this.editExperimentButton.Click += new System.EventHandler(this.editExperimentButton_Click);
            // 
            // newExperimentButton
            // 
            this.newExperimentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newExperimentButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newExperimentButton.FlatAppearance.BorderSize = 0;
            this.newExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newExperimentButton.Location = new System.Drawing.Point(0, 3);
            this.newExperimentButton.Name = "newExperimentButton";
            this.newExperimentButton.Size = new System.Drawing.Size(264, 33);
            this.newExperimentButton.TabIndex = 6;
            this.newExperimentButton.Text = "Novo Experimento";
            this.newExperimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newExperimentButton.UseVisualStyleBackColor = true;
            this.newExperimentButton.Click += new System.EventHandler(this.newExperimentButton_Click);
            // 
            // ExperimentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteReactButton);
            this.Controls.Add(this.editExperimentButton);
            this.Controls.Add(this.newExperimentButton);
            this.Name = "ExperimentControl";
            this.Size = new System.Drawing.Size(263, 1353);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton deleteReactButton;
        private System.Windows.Forms.RadioButton editExperimentButton;
        private System.Windows.Forms.RadioButton newExperimentButton;
    }
}
