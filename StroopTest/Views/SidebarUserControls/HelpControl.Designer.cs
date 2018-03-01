namespace TestPlatform.Views.SidebarUserControls
{
    partial class HelpControl
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
            this.aboutButton = new System.Windows.Forms.RadioButton();
            this.techInfoButton = new System.Windows.Forms.RadioButton();
            this.helpPageButton = new System.Windows.Forms.RadioButton();
            this.instructionsButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.aboutButton.Location = new System.Drawing.Point(3, 120);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(197, 33);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "Sobre";
            this.aboutButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // techInfoButton
            // 
            this.techInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.techInfoButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.techInfoButton.FlatAppearance.BorderSize = 0;
            this.techInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.techInfoButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.techInfoButton.Location = new System.Drawing.Point(3, 81);
            this.techInfoButton.Name = "techInfoButton";
            this.techInfoButton.Size = new System.Drawing.Size(197, 33);
            this.techInfoButton.TabIndex = 9;
            this.techInfoButton.Text = "Informações Técnicas";
            this.techInfoButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.techInfoButton.UseVisualStyleBackColor = true;
            this.techInfoButton.Click += new System.EventHandler(this.techInfoButton_Click);
            // 
            // helpPageButton
            // 
            this.helpPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPageButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.helpPageButton.FlatAppearance.BorderSize = 0;
            this.helpPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpPageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.helpPageButton.Location = new System.Drawing.Point(3, 42);
            this.helpPageButton.Name = "helpPageButton";
            this.helpPageButton.Size = new System.Drawing.Size(197, 33);
            this.helpPageButton.TabIndex = 7;
            this.helpPageButton.Text = "Página de Ajuda";
            this.helpPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpPageButton.UseVisualStyleBackColor = true;
            this.helpPageButton.Click += new System.EventHandler(this.helpPageButton_Click);
            // 
            // instructionsButton
            // 
            this.instructionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.instructionsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.instructionsButton.FlatAppearance.BorderSize = 0;
            this.instructionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructionsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.instructionsButton.Location = new System.Drawing.Point(3, 3);
            this.instructionsButton.Name = "instructionsButton";
            this.instructionsButton.Size = new System.Drawing.Size(197, 33);
            this.instructionsButton.TabIndex = 6;
            this.instructionsButton.Text = "Instruções";
            this.instructionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionsButton.UseVisualStyleBackColor = true;
            this.instructionsButton.Click += new System.EventHandler(this.instructionsButton_Click);
            // 
            // HelpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.techInfoButton);
            this.Controls.Add(this.helpPageButton);
            this.Controls.Add(this.instructionsButton);
            this.Name = "HelpControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton aboutButton;
        private System.Windows.Forms.RadioButton techInfoButton;
        private System.Windows.Forms.RadioButton helpPageButton;
        private System.Windows.Forms.RadioButton instructionsButton;
    }
}
