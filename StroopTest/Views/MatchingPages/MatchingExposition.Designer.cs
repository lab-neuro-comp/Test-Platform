namespace TestPlatform.Views.MatchingPages
{
    partial class MatchingExposition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchingExposition));
            this.instructionLabel = new System.Windows.Forms.Label();
            this.expositionBW = new System.ComponentModel.BackgroundWorker();
            this.expositionControllerBW = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // instructionLabel
            // 
            this.instructionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.instructionLabel.Location = new System.Drawing.Point(337, 228);
            this.instructionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(521, 426);
            this.instructionLabel.TabIndex = 0;
            this.instructionLabel.Text = "instruction";
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionLabel.Visible = false;
            // 
            // expositionBW
            // 
            this.expositionBW.WorkerReportsProgress = true;
            this.expositionBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.expositionBW_DoWork);
            this.expositionBW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.expositionBW_ProgressChanged);
            this.expositionBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.expositionBW_RunWorkerCompleted);
            // 
            // expositionControllerBW
            // 
            this.expositionControllerBW.WorkerReportsProgress = true;
            this.expositionControllerBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.expositionControllerBW_DoWork);
            this.expositionControllerBW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.expositionControllerBW_ProgressChanged);
            this.expositionControllerBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.expositionControllerBW_RunWorkerCompleted);
            // 
            // MatchingExposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 741);
            this.Controls.Add(this.instructionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MatchingExposition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MatchingExposition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MatchingExposition_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label instructionLabel;
        private System.ComponentModel.BackgroundWorker expositionBW;
        private System.ComponentModel.BackgroundWorker expositionControllerBW;
    }
}