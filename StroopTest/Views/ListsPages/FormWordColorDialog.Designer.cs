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
            this.wordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordTextBox.Location = new System.Drawing.Point(11, 29);
            this.wordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(128, 38);
            this.wordTextBox.TabIndex = 3;
            // 
            // hexColorTextBox
            // 
            this.hexColorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hexColorTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hexColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexColorTextBox.Location = new System.Drawing.Point(155, 29);
            this.hexColorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.hexColorTextBox.MaxLength = 7;
            this.hexColorTextBox.Name = "hexColorTextBox";
            this.hexColorTextBox.Size = new System.Drawing.Size(128, 38);
            this.hexColorTextBox.TabIndex = 4;
            this.hexColorTextBox.Text = "#000000";
            this.hexColorTextBox.Click += new System.EventHandler(this.hexColorTextBox_Click);
            this.hexColorTextBox.TextChanged += new System.EventHandler(this.hexColorTextBox_TextChanged);
            // 
            // wordInputLabel
            // 
            this.wordInputLabel.AutoSize = true;
            this.wordInputLabel.Location = new System.Drawing.Point(11, 11);
            this.wordInputLabel.Name = "wordInputLabel";
            this.wordInputLabel.Size = new System.Drawing.Size(46, 13);
            this.wordInputLabel.TabIndex = 5;
            this.wordInputLabel.Text = "Palavra:";
            // 
            // colorInputLabel
            // 
            this.colorInputLabel.AutoSize = true;
            this.colorInputLabel.Location = new System.Drawing.Point(158, 11);
            this.colorInputLabel.Name = "colorInputLabel";
            this.colorInputLabel.Size = new System.Drawing.Size(77, 13);
            this.colorInputLabel.TabIndex = 6;
            this.colorInputLabel.Text = "Código da Cor:";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(11, 78);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 33;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(208, 78);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 35;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormWordColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 117);
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