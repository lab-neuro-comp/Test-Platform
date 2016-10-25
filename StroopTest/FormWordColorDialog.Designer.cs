namespace StroopTest
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
            this.defineWordLabel = new System.Windows.Forms.Label();
            this.defineColorLabel = new System.Windows.Forms.Label();
            this.addItemButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordTextBox
            // 
            this.wordTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.wordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordTextBox.Location = new System.Drawing.Point(93, 11);
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
            this.hexColorTextBox.Location = new System.Drawing.Point(298, 11);
            this.hexColorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.hexColorTextBox.MaxLength = 7;
            this.hexColorTextBox.Name = "hexColorTextBox";
            this.hexColorTextBox.Size = new System.Drawing.Size(128, 38);
            this.hexColorTextBox.TabIndex = 4;
            this.hexColorTextBox.Text = "#000000";
            this.hexColorTextBox.Click += new System.EventHandler(this.hexColorTextBox_Click);
            // 
            // defineWordLabel
            // 
            this.defineWordLabel.AutoSize = true;
            this.defineWordLabel.Location = new System.Drawing.Point(11, 23);
            this.defineWordLabel.Name = "defineWordLabel";
            this.defineWordLabel.Size = new System.Drawing.Size(75, 13);
            this.defineWordLabel.TabIndex = 5;
            this.defineWordLabel.Text = "Nova Palavra:";
            // 
            // defineColorLabel
            // 
            this.defineColorLabel.AutoSize = true;
            this.defineColorLabel.Location = new System.Drawing.Point(236, 23);
            this.defineColorLabel.Name = "defineColorLabel";
            this.defineColorLabel.Size = new System.Drawing.Size(55, 13);
            this.defineColorLabel.TabIndex = 6;
            this.defineColorLabel.Text = "Nova Cor:";
            // 
            // addItemButton
            // 
            this.addItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addItemButton.Location = new System.Drawing.Point(14, 65);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(75, 23);
            this.addItemButton.TabIndex = 7;
            this.addItemButton.Text = "Adicionar";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(354, 65);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormWordColorDialog
            // 
            this.AcceptButton = this.addItemButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(441, 100);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.defineColorLabel);
            this.Controls.Add(this.defineWordLabel);
            this.Controls.Add(this.wordTextBox);
            this.Controls.Add(this.hexColorTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormWordColorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormWordColorDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.TextBox hexColorTextBox;
        private System.Windows.Forms.Label defineWordLabel;
        private System.Windows.Forms.Label defineColorLabel;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Button cancelButton;
    }
}