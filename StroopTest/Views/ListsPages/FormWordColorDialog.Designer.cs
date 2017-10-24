namespace TestPlatform
{
    partial class FormWordColorDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWordColorDialog));
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.hexColorTextBox = new System.Windows.Forms.TextBox();
            this.wordInputLabel = new System.Windows.Forms.Label();
            this.colorInputLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordTextBox
            // 
            this.wordTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.wordTextBox, "wordTextBox");
            this.wordTextBox.Name = "wordTextBox";
            // 
            // hexColorTextBox
            // 
            this.hexColorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hexColorTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.hexColorTextBox, "hexColorTextBox");
            this.hexColorTextBox.Name = "hexColorTextBox";
            this.hexColorTextBox.Click += new System.EventHandler(this.hexColorTextBox_Click);
            this.hexColorTextBox.TextChanged += new System.EventHandler(this.hexColorTextBox_TextChanged);
            // 
            // wordInputLabel
            // 
            resources.ApplyResources(this.wordInputLabel, "wordInputLabel");
            this.wordInputLabel.Name = "wordInputLabel";
            // 
            // colorInputLabel
            // 
            resources.ApplyResources(this.colorInputLabel, "colorInputLabel");
            this.colorInputLabel.Name = "colorInputLabel";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormWordColorDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.colorInputLabel);
            this.Controls.Add(this.wordInputLabel);
            this.Controls.Add(this.wordTextBox);
            this.Controls.Add(this.hexColorTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormWordColorDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.TextBox hexColorTextBox;
        private System.Windows.Forms.Label wordInputLabel;
        private System.Windows.Forms.Label colorInputLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}