namespace TestPlatform.Views.StroopPages
{
    partial class RecoverStroop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoverStroop));
            this.agreeCheckBox = new System.Windows.Forms.CheckBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.programRecoveredLabel = new System.Windows.Forms.Label();
            this.programDeletedLabel = new System.Windows.Forms.Label();
            this.addToDeletedList = new System.Windows.Forms.Button();
            this.addToRecoverList = new System.Windows.Forms.Button();
            this.toRecoverListBox = new System.Windows.Forms.ListBox();
            this.deletedListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.recoverButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // agreeCheckBox
            // 
            resources.ApplyResources(this.agreeCheckBox, "agreeCheckBox");
            this.agreeCheckBox.Name = "agreeCheckBox";
            this.agreeCheckBox.UseVisualStyleBackColor = true;
            // 
            // warningLabel
            // 
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.warningLabel, "warningLabel");
            this.warningLabel.Name = "warningLabel";
            // 
            // programRecoveredLabel
            // 
            resources.ApplyResources(this.programRecoveredLabel, "programRecoveredLabel");
            this.programRecoveredLabel.Name = "programRecoveredLabel";
            // 
            // programDeletedLabel
            // 
            resources.ApplyResources(this.programDeletedLabel, "programDeletedLabel");
            this.programDeletedLabel.Name = "programDeletedLabel";
            // 
            // addToDeletedList
            // 
            resources.ApplyResources(this.addToDeletedList, "addToDeletedList");
            this.addToDeletedList.Name = "addToDeletedList";
            this.addToDeletedList.UseVisualStyleBackColor = true;
            // 
            // addToRecoverList
            // 
            resources.ApplyResources(this.addToRecoverList, "addToRecoverList");
            this.addToRecoverList.Name = "addToRecoverList";
            this.addToRecoverList.UseVisualStyleBackColor = true;
            // 
            // toRecoverListBox
            // 
            this.toRecoverListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.toRecoverListBox.FormattingEnabled = true;
            resources.ApplyResources(this.toRecoverListBox, "toRecoverListBox");
            this.toRecoverListBox.Name = "toRecoverListBox";
            // 
            // deletedListBox
            // 
            this.deletedListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.deletedListBox.FormattingEnabled = true;
            resources.ApplyResources(this.deletedListBox, "deletedListBox");
            this.deletedListBox.Name = "deletedListBox";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // recoverButton
            // 
            resources.ApplyResources(this.recoverButton, "recoverButton");
            this.recoverButton.Name = "recoverButton";
            this.recoverButton.UseVisualStyleBackColor = true;
            // 
            // RecoverStroop
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.agreeCheckBox);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.programRecoveredLabel);
            this.Controls.Add(this.programDeletedLabel);
            this.Controls.Add(this.addToDeletedList);
            this.Controls.Add(this.addToRecoverList);
            this.Controls.Add(this.toRecoverListBox);
            this.Controls.Add(this.deletedListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.recoverButton);
            this.Name = "RecoverStroop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox agreeCheckBox;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label programRecoveredLabel;
        private System.Windows.Forms.Label programDeletedLabel;
        private System.Windows.Forms.Button addToDeletedList;
        private System.Windows.Forms.Button addToRecoverList;
        private System.Windows.Forms.ListBox toRecoverListBox;
        private System.Windows.Forms.ListBox deletedListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button recoverButton;
    }
}
