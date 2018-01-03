namespace TestPlatform.Views
{
    partial class StroopControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StroopControl));
            this.deleteStroopButton = new System.Windows.Forms.RadioButton();
            this.editStroopButton = new System.Windows.Forms.RadioButton();
            this.newStroopButton = new System.Windows.Forms.RadioButton();
            this.recoverStroopButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteStroopButton
            // 
            resources.ApplyResources(this.deleteStroopButton, "deleteStroopButton");
            this.deleteStroopButton.FlatAppearance.BorderSize = 0;
            this.deleteStroopButton.Name = "deleteStroopButton";
            this.deleteStroopButton.UseVisualStyleBackColor = true;
            this.deleteStroopButton.Click += new System.EventHandler(this.deleteStroopButton_Click);
            // 
            // editStroopButton
            // 
            resources.ApplyResources(this.editStroopButton, "editStroopButton");
            this.editStroopButton.FlatAppearance.BorderSize = 0;
            this.editStroopButton.Name = "editStroopButton";
            this.editStroopButton.UseVisualStyleBackColor = true;
            this.editStroopButton.Click += new System.EventHandler(this.editStroopButton_CheckedChanged);
            // 
            // newStroopButton
            // 
            resources.ApplyResources(this.newStroopButton, "newStroopButton");
            this.newStroopButton.FlatAppearance.BorderSize = 0;
            this.newStroopButton.Name = "newStroopButton";
            this.newStroopButton.UseVisualStyleBackColor = true;
            this.newStroopButton.Click += new System.EventHandler(this.newStroopButton_CheckedChanged);
            // 
            // recoverStroopButton
            // 
            resources.ApplyResources(this.recoverStroopButton, "recoverStroopButton");
            this.recoverStroopButton.FlatAppearance.BorderSize = 0;
            this.recoverStroopButton.Name = "recoverStroopButton";
            this.recoverStroopButton.UseVisualStyleBackColor = true;
            this.recoverStroopButton.Click += new System.EventHandler(this.recoverStroopButton_Click);
            // 
            // StroopControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.recoverStroopButton);
            this.Controls.Add(this.deleteStroopButton);
            this.Controls.Add(this.editStroopButton);
            this.Controls.Add(this.newStroopButton);
            this.Name = "StroopControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton newStroopButton;
        private System.Windows.Forms.RadioButton editStroopButton;
        private System.Windows.Forms.RadioButton deleteStroopButton;
        private System.Windows.Forms.RadioButton recoverStroopButton;
    }
}
