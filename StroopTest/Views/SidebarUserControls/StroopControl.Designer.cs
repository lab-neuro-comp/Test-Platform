namespace TestPlatform.Views
{
    partial class StroopControl
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
            this.deleteStroopButton = new System.Windows.Forms.RadioButton();
            this.editStroopButton = new System.Windows.Forms.RadioButton();
            this.newStroopButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteStroopButton
            // 
            this.deleteStroopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteStroopButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.deleteStroopButton.Enabled = false;
            this.deleteStroopButton.FlatAppearance.BorderSize = 0;
            this.deleteStroopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteStroopButton.Location = new System.Drawing.Point(0, 80);
            this.deleteStroopButton.Name = "deleteStroopButton";
            this.deleteStroopButton.Size = new System.Drawing.Size(260, 33);
            this.deleteStroopButton.TabIndex = 2;
            this.deleteStroopButton.Text = "Excluir Programa";
            this.deleteStroopButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteStroopButton.UseVisualStyleBackColor = true;
            // 
            // editStroopButton
            // 
            this.editStroopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editStroopButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editStroopButton.FlatAppearance.BorderSize = 0;
            this.editStroopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editStroopButton.Location = new System.Drawing.Point(0, 41);
            this.editStroopButton.Name = "editStroopButton";
            this.editStroopButton.Size = new System.Drawing.Size(260, 33);
            this.editStroopButton.TabIndex = 1;
            this.editStroopButton.Text = "Editar Programa";
            this.editStroopButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editStroopButton.UseVisualStyleBackColor = true;
            this.editStroopButton.Click += new System.EventHandler(this.editStroopButton_CheckedChanged);
            // 
            // newStroopButton
            // 
            this.newStroopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newStroopButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newStroopButton.FlatAppearance.BorderSize = 0;
            this.newStroopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newStroopButton.Location = new System.Drawing.Point(0, 2);
            this.newStroopButton.Name = "newStroopButton";
            this.newStroopButton.Size = new System.Drawing.Size(260, 33);
            this.newStroopButton.TabIndex = 0;
            this.newStroopButton.Text = "Novo Programa";
            this.newStroopButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newStroopButton.UseVisualStyleBackColor = true;
            this.newStroopButton.Click += new System.EventHandler(this.newStroopButton_CheckedChanged);
            // 
            // StroopControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.deleteStroopButton);
            this.Controls.Add(this.editStroopButton);
            this.Controls.Add(this.newStroopButton);
            this.Name = "StroopControl";
            this.Size = new System.Drawing.Size(263, 1225);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton newStroopButton;
        private System.Windows.Forms.RadioButton editStroopButton;
        private System.Windows.Forms.RadioButton deleteStroopButton;
    }
}
