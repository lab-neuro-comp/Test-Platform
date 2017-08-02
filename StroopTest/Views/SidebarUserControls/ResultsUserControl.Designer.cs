namespace TestPlatform.Views.SidebarUserControls
{
    partial class ResultsUserControl
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
            this.StroopButton = new System.Windows.Forms.RadioButton();
            this.reactionButton = new System.Windows.Forms.RadioButton();
            this.experimentButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // StroopButton
            // 
            this.StroopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StroopButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.StroopButton.FlatAppearance.BorderSize = 0;
            this.StroopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StroopButton.Location = new System.Drawing.Point(0, 3);
            this.StroopButton.Name = "StroopButton";
            this.StroopButton.Size = new System.Drawing.Size(260, 33);
            this.StroopButton.TabIndex = 1;
            this.StroopButton.Text = "StroopTest";
            this.StroopButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StroopButton.UseVisualStyleBackColor = true;
            this.StroopButton.Click += new System.EventHandler(this.StroopButton_Click);
            // 
            // reactionButton
            // 
            this.reactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reactionButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.reactionButton.FlatAppearance.BorderSize = 0;
            this.reactionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reactionButton.Location = new System.Drawing.Point(2, 54);
            this.reactionButton.Name = "reactionButton";
            this.reactionButton.Size = new System.Drawing.Size(258, 33);
            this.reactionButton.TabIndex = 2;
            this.reactionButton.Text = "ReactionTest";
            this.reactionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reactionButton.UseVisualStyleBackColor = true;
            this.reactionButton.Click += new System.EventHandler(this.reactionButton_Click);
            // 
            // experimentButton
            // 
            this.experimentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.experimentButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.experimentButton.FlatAppearance.BorderSize = 0;
            this.experimentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.experimentButton.Location = new System.Drawing.Point(2, 106);
            this.experimentButton.Name = "experimentButton";
            this.experimentButton.Size = new System.Drawing.Size(258, 33);
            this.experimentButton.TabIndex = 3;
            this.experimentButton.Text = "Experimento";
            this.experimentButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.experimentButton.UseVisualStyleBackColor = true;
            this.experimentButton.Click += new System.EventHandler(this.experimentButton_Click);
            // 
            // ResultsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.experimentButton);
            this.Controls.Add(this.reactionButton);
            this.Controls.Add(this.StroopButton);
            this.Name = "ResultsUserControl";
            this.Size = new System.Drawing.Size(263, 1257);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton StroopButton;
        private System.Windows.Forms.RadioButton reactionButton;
        private System.Windows.Forms.RadioButton experimentButton;
    }
}
