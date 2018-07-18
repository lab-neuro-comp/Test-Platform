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
            this.errorMessage = new System.Windows.Forms.Label();
            this.warningCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.addToDestinationList = new System.Windows.Forms.Button();
            this.addToOriginList = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // originFilesList
            // 
            this.originFilesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.originFilesList.FormattingEnabled = true;
            resources.ApplyResources(this.originFilesList, "originFilesList");
            this.originFilesList.Name = "originFilesList";
            this.originFilesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.originFilesList_DrawItem);
            this.originFilesList.SelectedIndexChanged += new System.EventHandler(this.originFilesList_SelectedIndexChanged);
            // 
            // destinationFilesList
            // 
            this.destinationFilesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.destinationFilesList.FormattingEnabled = true;
            resources.ApplyResources(this.destinationFilesList, "destinationFilesList");
            this.destinationFilesList.Name = "destinationFilesList";
            this.destinationFilesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.destinationFilesList_DrawItem);
            this.destinationFilesList.SelectedIndexChanged += new System.EventHandler(this.destinationFilesList_SelectedIndexChanged);
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
            // errorMessage
            // 
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.errorMessage, "errorMessage");
            this.errorMessage.Name = "errorMessage";
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
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // warningLabel
            // 
            resources.ApplyResources(this.warningLabel, "warningLabel");
            this.warningLabel.ForeColor = System.Drawing.Color.Orange;
            this.warningLabel.Name = "warningLabel";
            // 
            // FileManagment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.addToOriginList);
            this.Controls.Add(this.addToDestinationList);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.warningCheckBox);
            this.Controls.Add(this.errorMessage);
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
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.CheckBox warningCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button addToDestinationList;
        private System.Windows.Forms.Button addToOriginList;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label warningLabel;
    }
}
