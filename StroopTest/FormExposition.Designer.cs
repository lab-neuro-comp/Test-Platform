namespace StroopTest
{
    partial class FormExposition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExposition));
            this.wordLabel = new System.Windows.Forms.Label();
            this.imgPictureBox = new System.Windows.Forms.PictureBox();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // wordLabel
            // 
            this.wordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordLabel.AutoEllipsis = true;
            this.wordLabel.BackColor = System.Drawing.Color.Transparent;
            this.wordLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 160F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordLabel.Location = new System.Drawing.Point(6, 129);
            this.wordLabel.Margin = new System.Windows.Forms.Padding(0);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(856, 336);
            this.wordLabel.TabIndex = 1;
            this.wordLabel.Text = "word";
            this.wordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wordLabel.Visible = false;
            // 
            // imgPictureBox
            // 
            this.imgPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgPictureBox.BackColor = System.Drawing.Color.White;
            this.imgPictureBox.Location = new System.Drawing.Point(140, 51);
            this.imgPictureBox.Name = "imgPictureBox";
            this.imgPictureBox.Size = new System.Drawing.Size(536, 568);
            this.imgPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPictureBox.TabIndex = 10;
            this.imgPictureBox.TabStop = false;
            this.imgPictureBox.Visible = false;
            // 
            // instructionLabel
            // 
            this.instructionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.Location = new System.Drawing.Point(9, 9);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(782, 655);
            this.instructionLabel.TabIndex = 11;
            this.instructionLabel.Text = "instruction";
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionLabel.Visible = false;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Enabled = false;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.Location = new System.Drawing.Point(228, 503);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(297, 91);
            this.subtitleLabel.TabIndex = 12;
            this.subtitleLabel.Text = "subtitle";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.subtitleLabel.Visible = false;
            // 
            // FormExposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 677);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.imgPictureBox);
            this.Controls.Add(this.instructionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormExposition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StroopTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormExposition_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.imgPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.PictureBox imgPictureBox;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Label subtitleLabel;
    }
}

