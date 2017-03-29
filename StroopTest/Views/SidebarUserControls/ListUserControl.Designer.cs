namespace StroopTest.Views.SidebarControls
{
    partial class ListUserControl
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
            this.imageButton = new System.Windows.Forms.RadioButton();
            this.colorWordButton = new System.Windows.Forms.RadioButton();
            this.audioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // imageButton
            // 
            this.imageButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.imageButton.FlatAppearance.BorderSize = 0;
            this.imageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton.Location = new System.Drawing.Point(-3, 42);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(260, 33);
            this.imageButton.TabIndex = 2;
            this.imageButton.Text = "Imagens";
            this.imageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.imageButton.UseVisualStyleBackColor = true;
            // 
            // colorWordButton
            // 
            this.colorWordButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.colorWordButton.FlatAppearance.BorderSize = 0;
            this.colorWordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorWordButton.Location = new System.Drawing.Point(-3, 3);
            this.colorWordButton.Name = "colorWordButton";
            this.colorWordButton.Size = new System.Drawing.Size(260, 33);
            this.colorWordButton.TabIndex = 1;
            this.colorWordButton.Text = "Palavras e Cores";
            this.colorWordButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colorWordButton.UseVisualStyleBackColor = true;
            // 
            // audioButton
            // 
            this.audioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.audioButton.FlatAppearance.BorderSize = 0;
            this.audioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioButton.Location = new System.Drawing.Point(-3, 81);
            this.audioButton.Name = "audioButton";
            this.audioButton.Size = new System.Drawing.Size(260, 33);
            this.audioButton.TabIndex = 3;
            this.audioButton.Text = "Aúdios";
            this.audioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.audioButton.UseVisualStyleBackColor = true;
            // 
            // ListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioButton);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.colorWordButton);
            this.Name = "ListUserControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton colorWordButton;
        private System.Windows.Forms.RadioButton imageButton;
        private System.Windows.Forms.RadioButton audioButton;
    }
}
