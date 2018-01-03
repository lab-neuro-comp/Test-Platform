namespace TestPlatform.Views.MainForms
{
    partial class FileManagment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagment));
            this.originFilesList = new System.Windows.Forms.ListBox();
            this.destinationFilesList = new System.Windows.Forms.ListBox();
            this.originListLabel = new System.Windows.Forms.Label();
            this.destinationListLabel = new System.Windows.Forms.Label();
            this.warningMessage = new System.Windows.Forms.Label();
            this.warningCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.addToDestinationList = new System.Windows.Forms.Button();
            this.addToOriginList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // originFilesList
            // 
            this.originFilesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.originFilesList.FormattingEnabled = true;
            resources.ApplyResources(this.originFilesList, "originFilesList");
            this.originFilesList.Name = "originFilesList";
            this.originFilesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.originFilesList_DrawItem);
            // 
            // destinationFilesList
            // 
            this.destinationFilesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.destinationFilesList.FormattingEnabled = true;
            resources.ApplyResources(this.destinationFilesList, "destinationFilesList");
            this.destinationFilesList.Name = "destinationFilesList";
            this.destinationFilesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.destinationFilesList_DrawItem);
            // 
            // originListLabel
            // 
            resources.ApplyResources(this.originListLabel, "originListLabel");
            this.originListLabel.Name = "originListLabel";
            // 
            // destinationListLabel
            // 
            resources.ApplyResources(this.destinationListLabel, "destinationListLabel");
            this.destinationListLabel.Name = "destinationListLabel";
            // 
            // warningMessage
            // 
            this.warningMessage.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.warningMessage, "warningMessage");
            this.warningMessage.Name = "warningMessage";
            // 
            // warningCheckBox
            // 
            resources.ApplyResources(this.warningCheckBox, "warningCheckBox");
            this.warningCheckBox.Name = "warningCheckBox";
            this.warningCheckBox.UseVisualStyleBackColor = true;
            this.warningCheckBox.CheckedChanged += new System.EventHandler(this.warningCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // sendButton
            // 
            resources.ApplyResources(this.sendButton, "sendButton");
            this.sendButton.Name = "sendButton";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // addToDestinationList
            // 
            resources.ApplyResources(this.addToDestinationList, "addToDestinationList");
            this.addToDestinationList.Name = "addToDestinationList";
            this.addToDestinationList.UseVisualStyleBackColor = true;
            this.addToDestinationList.Click += new System.EventHandler(this.addToDestinationList_Click);
            // 
            // addToOriginList
            // 
            resources.ApplyResources(this.addToOriginList, "addToOriginList");
            this.addToOriginList.Name = "addToOriginList";
            this.addToOriginList.UseVisualStyleBackColor = true;
            this.addToOriginList.Click += new System.EventHandler(this.addToOriginList_Click);
            // 
            // FileManagment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addToOriginList);
            this.Controls.Add(this.addToDestinationList);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.warningCheckBox);
            this.Controls.Add(this.warningMessage);
            this.Controls.Add(this.destinationListLabel);
            this.Controls.Add(this.originListLabel);
            this.Controls.Add(this.destinationFilesList);
            this.Controls.Add(this.originFilesList);
            this.Name = "FileManagment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox originFilesList;
        private System.Windows.Forms.ListBox destinationFilesList;
        private System.Windows.Forms.Label originListLabel;
        private System.Windows.Forms.Label destinationListLabel;
        private System.Windows.Forms.Label warningMessage;
        private System.Windows.Forms.CheckBox warningCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button addToDestinationList;
        private System.Windows.Forms.Button addToOriginList;
    }
}
