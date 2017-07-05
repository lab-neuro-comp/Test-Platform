namespace TestPlatform.Views
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
            this.deleteExperimentButton = new System.Windows.Forms.RadioButton();
            this.editExperimentButton = new System.Windows.Forms.RadioButton();
            this.newExperimentButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteExperimentButton
            // 
            this.deleteExperimentButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.deleteExperimentButton.FlatAppearance.BorderSize = 0;
            this.deleteExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteExperimentButton.Location = new System.Drawing.Point(0, 81);
            this.deleteExperimentButton.Name = "deleteExperimentButton";
            this.deleteExperimentButton.Size = new System.Drawing.Size(260, 33);
            this.deleteExperimentButton.TabIndex = 5;
            this.deleteExperimentButton.Text = "Excluir Experimento";
            this.deleteExperimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteExperimentButton.UseVisualStyleBackColor = true;
            // 
            // editExperimentButton
            // 
            this.editExperimentButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editExperimentButton.FlatAppearance.BorderSize = 0;
            this.editExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editExperimentButton.Location = new System.Drawing.Point(0, 42);
            this.editExperimentButton.Name = "editExperimentButton";
            this.editExperimentButton.Size = new System.Drawing.Size(260, 33);
            this.editExperimentButton.TabIndex = 4;
            this.editExperimentButton.Text = "Editar Experimento";
            this.editExperimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editExperimentButton.UseVisualStyleBackColor = true;
            // 
            // newExperimentButton
            // 
            this.newExperimentButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newExperimentButton.FlatAppearance.BorderSize = 0;
            this.newExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newExperimentButton.Location = new System.Drawing.Point(0, 3);
            this.newExperimentButton.Name = "newExperimentButton";
            this.newExperimentButton.Size = new System.Drawing.Size(260, 33);
            this.newExperimentButton.TabIndex = 3;
            this.newExperimentButton.Text = "Novo Experimento";
            this.newExperimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newExperimentButton.UseVisualStyleBackColor = true;
            this.newExperimentButton.Click += new System.EventHandler(this.newExperimentButton_Click);
            // 
            // ExperimentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
