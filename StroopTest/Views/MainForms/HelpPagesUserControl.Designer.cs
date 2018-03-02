namespace TestPlatform.Views.MainForms
{
    partial class HelpPagesUserControl
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
            this.helpBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // helpBrowser
            // 
            this.helpBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpBrowser.Location = new System.Drawing.Point(0, 0);
            this.helpBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.helpBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.helpBrowser.Name = "helpBrowser";
            this.helpBrowser.Size = new System.Drawing.Size(1067, 738);
            this.helpBrowser.TabIndex = 3;
            // 
            // HelpPagesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.helpBrowser);
            this.Name = "HelpPagesUserControl";
            this.Size = new System.Drawing.Size(1067, 738);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser helpBrowser;
    }
}
