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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpPagesUserControl));
            this.helpBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // helpBrowser
            // 
            resources.ApplyResources(this.helpBrowser, "helpBrowser");
            this.helpBrowser.Name = "helpBrowser";
            // 
            // HelpPagesUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helpBrowser);
            this.Name = "HelpPagesUserControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser helpBrowser;
    }
}
