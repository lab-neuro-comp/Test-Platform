namespace TestPlatform.Views.SidebarUserControls
{
    partial class SpacialRecognitionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpacialRecognitionControl));
            this.newSpacialRecognitionButton = new System.Windows.Forms.RadioButton();
            this.editSpacialRecognitionButton = new System.Windows.Forms.RadioButton();
            this.deleteSpacialRecognitionButton = new System.Windows.Forms.RadioButton();
            this.recoverSpacialRecognitionButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // newSpacialRecognitionButton
            // 
            resources.ApplyResources(this.newSpacialRecognitionButton, "newSpacialRecognitionButton");
            this.newSpacialRecognitionButton.FlatAppearance.BorderSize = 0;
            this.newSpacialRecognitionButton.Name = "newSpacialRecognitionButton";
            this.newSpacialRecognitionButton.UseVisualStyleBackColor = true;
            this.newSpacialRecognitionButton.Click += new System.EventHandler(this.newSpacialRecognitionButton_Click);
            // 
            // editSpacialRecognitionButton
            // 
            resources.ApplyResources(this.editSpacialRecognitionButton, "editSpacialRecognitionButton");
            this.editSpacialRecognitionButton.FlatAppearance.BorderSize = 0;
            this.editSpacialRecognitionButton.Name = "editSpacialRecognitionButton";
            this.editSpacialRecognitionButton.UseVisualStyleBackColor = true;
            this.editSpacialRecognitionButton.Click += new System.EventHandler(this.editSpacialRecognitionButton_Click);
            // 
            // deleteSpacialRecognitionButton
            // 
            resources.ApplyResources(this.deleteSpacialRecognitionButton, "deleteSpacialRecognitionButton");
            this.deleteSpacialRecognitionButton.FlatAppearance.BorderSize = 0;
            this.deleteSpacialRecognitionButton.Name = "deleteSpacialRecognitionButton";
            this.deleteSpacialRecognitionButton.UseVisualStyleBackColor = true;
            // 
            // recoverSpacialRecognitionButton
            // 
            resources.ApplyResources(this.recoverSpacialRecognitionButton, "recoverSpacialRecognitionButton");
            this.recoverSpacialRecognitionButton.FlatAppearance.BorderSize = 0;
            this.recoverSpacialRecognitionButton.Name = "recoverSpacialRecognitionButton";
            this.recoverSpacialRecognitionButton.UseVisualStyleBackColor = true;
            // 
            // SpacialRecognitionControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.recoverSpacialRecognitionButton);
            this.Controls.Add(this.deleteSpacialRecognitionButton);
            this.Controls.Add(this.editSpacialRecognitionButton);
            this.Controls.Add(this.newSpacialRecognitionButton);
            this.Name = "SpacialRecognitionControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton newSpacialRecognitionButton;
        private System.Windows.Forms.RadioButton editSpacialRecognitionButton;
        private System.Windows.Forms.RadioButton deleteSpacialRecognitionButton;
        private System.Windows.Forms.RadioButton recoverSpacialRecognitionButton;
    }
}
