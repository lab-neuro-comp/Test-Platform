namespace StroopTest.Views
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
            this.newExperimentButton = new System.Windows.Forms.Button();
            this.editExperimentButton = new System.Windows.Forms.Button();
            this.deleteExperimentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newExperimentButton
            // 
            this.newExperimentButton.FlatAppearance.BorderSize = 0;
            this.newExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newExperimentButton.Location = new System.Drawing.Point(0, 2);
            this.newExperimentButton.Name = "newExperimentButton";
            this.newExperimentButton.Size = new System.Drawing.Size(260, 33);
            this.newExperimentButton.TabIndex = 0;
            this.newExperimentButton.Text = "Novo Experimento";
            this.newExperimentButton.UseVisualStyleBackColor = true;
            // 
            // editExperimentButton
            // 
            this.editExperimentButton.FlatAppearance.BorderSize = 0;
            this.editExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editExperimentButton.Location = new System.Drawing.Point(0, 41);
            this.editExperimentButton.Name = "editExperimentButton";
            this.editExperimentButton.Size = new System.Drawing.Size(260, 33);
            this.editExperimentButton.TabIndex = 1;
            this.editExperimentButton.Text = "Editar Experimento";
            this.editExperimentButton.UseVisualStyleBackColor = true;
            // 
            // deleteExperimentButton
            // 
            this.deleteExperimentButton.FlatAppearance.BorderSize = 0;
            this.deleteExperimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteExperimentButton.Location = new System.Drawing.Point(0, 80);
            this.deleteExperimentButton.Name = "deleteExperimentButton";
            this.deleteExperimentButton.Size = new System.Drawing.Size(260, 33);
            this.deleteExperimentButton.TabIndex = 2;
            this.deleteExperimentButton.Text = "Excluir Experimento";
            this.deleteExperimentButton.UseVisualStyleBackColor = true;
            // 
            // ExperimentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.deleteExperimentButton);
            this.Controls.Add(this.editExperimentButton);
            this.Controls.Add(this.newExperimentButton);
            this.Name = "ExperimentControl";
            this.Size = new System.Drawing.Size(260, 466);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newExperimentButton;
        private System.Windows.Forms.Button editExperimentButton;
        private System.Windows.Forms.Button deleteExperimentButton;
    }
}
