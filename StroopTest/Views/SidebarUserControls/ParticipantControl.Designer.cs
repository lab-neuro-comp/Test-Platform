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
            this.editParticipantButton = new System.Windows.Forms.RadioButton();
            this.newParticipantButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // editParticipantButton
            // 
            this.editParticipantButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editParticipantButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editParticipantButton.FlatAppearance.BorderSize = 0;
            this.editParticipantButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editParticipantButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.editParticipantButton.Location = new System.Drawing.Point(3, 42);
            this.editParticipantButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editParticipantButton.Name = "editParticipantButton";
            this.editParticipantButton.Size = new System.Drawing.Size(257, 33);
            this.editParticipantButton.TabIndex = 6;
            this.editParticipantButton.Text = "Editar Participante";
            this.editParticipantButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editParticipantButton.UseVisualStyleBackColor = true;
            this.editParticipantButton.Click += new System.EventHandler(this.editParticipantButton_Click);
            // 
            // newParticipantButton
            // 
            this.newParticipantButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newParticipantButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newParticipantButton.FlatAppearance.BorderSize = 0;
            this.newParticipantButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newParticipantButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.newParticipantButton.Location = new System.Drawing.Point(3, 2);
            this.newParticipantButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newParticipantButton.Name = "newParticipantButton";
            this.newParticipantButton.Size = new System.Drawing.Size(257, 33);
            this.newParticipantButton.TabIndex = 5;
            this.newParticipantButton.Text = "Novo Participante";
            this.newParticipantButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newParticipantButton.UseVisualStyleBackColor = true;
            this.newParticipantButton.Click += new System.EventHandler(this.newParticipantButton_Click);
            // 
            // ParticipantControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editParticipantButton);
            this.Controls.Add(this.newParticipantButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ParticipantControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton editParticipantButton;
        private System.Windows.Forms.RadioButton newParticipantButton;
    }
}
