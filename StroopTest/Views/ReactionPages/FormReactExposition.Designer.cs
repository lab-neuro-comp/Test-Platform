namespace TestPlatform.Views
{
    partial class FormReactExposition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReactExposition));
            this.instructionLabel = new System.Windows.Forms.Label();
            this.expositionBW = new System.ComponentModel.BackgroundWorker();
            this.intervalBW = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // instructionLabel
            // 
            this.instructionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.Location = new System.Drawing.Point(449, 280);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(695, 524);
            this.instructionLabel.TabIndex = 12;
            this.instructionLabel.Text = "instruction";
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionLabel.Visible = false;
            // 
            // expositionBW
            // 
            this.expositionBW.WorkerReportsProgress = true;
            this.expositionBW.WorkerSupportsCancellation = true;
            this.expositionBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.expositionBW_DoWork);
            this.expositionBW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.expositionBW_ProgressChanged);
            this.expositionBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.expositionBW_RunWorkerCompleted);
            // 
            // intervalBW
            // 
            this.intervalBW.WorkerReportsProgress = true;
            this.intervalBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.intervalBW_DoWork);
            this.intervalBW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.intervalBW_ProgressChanged);
            this.intervalBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.intervalBW_RunWorkerCompleted);
            // 
            // FormReactExposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 1084);
            this.Controls.Add(this.instructionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormReactExposition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ReactionTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exposition_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label instructionLabel;
        private System.ComponentModel.BackgroundWorker expositionBW;
        private System.ComponentModel.BackgroundWorker intervalBW;
    }
}