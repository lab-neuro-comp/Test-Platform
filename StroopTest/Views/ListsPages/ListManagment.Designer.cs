namespace TestPlatform.Views.ListsPages
{
    partial class ListManagment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListManagment));
            this.existingList = new System.Windows.Forms.ListBox();
            this.deletingList = new System.Windows.Forms.ListBox();
            this.toDelete = new System.Windows.Forms.Button();
            this.toExisting = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.existingLabel = new System.Windows.Forms.Label();
            this.deletingLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.excludedLists = new System.Windows.Forms.Label();
            this.recoveringLists = new System.Windows.Forms.Label();
            this.existingListWarning = new System.Windows.Forms.Label();
            this.recoverButton = new System.Windows.Forms.Button();
            this.existingListCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // existingList
            // 
            this.existingList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.existingList.FormattingEnabled = true;
            resources.ApplyResources(this.existingList, "existingList");
            this.existingList.Name = "existingList";
            this.existingList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.existingList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.originFilesList_DrawItem);
            // 
            // deletingList
            // 
            this.deletingList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.deletingList.FormattingEnabled = true;
            resources.ApplyResources(this.deletingList, "deletingList");
            this.deletingList.Name = "deletingList";
            this.deletingList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.deletingList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.destinationFilesList_DrawItem);
            // 
            // toDelete
            // 
            resources.ApplyResources(this.toDelete, "toDelete");
            this.toDelete.Name = "toDelete";
            this.toDelete.UseVisualStyleBackColor = true;
            this.toDelete.Click += new System.EventHandler(this.toDelete_Click);
            // 
            // toExisting
            // 
            resources.ApplyResources(this.toExisting, "toExisting");
            this.toExisting.Name = "toExisting";
            this.toExisting.UseVisualStyleBackColor = true;
            this.toExisting.Click += new System.EventHandler(this.toExisting_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // existingLabel
            // 
            resources.ApplyResources(this.existingLabel, "existingLabel");
            this.existingLabel.Name = "existingLabel";
            // 
            // deletingLabel
            // 
            resources.ApplyResources(this.deletingLabel, "deletingLabel");
            this.deletingLabel.Name = "deletingLabel";
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
            // excludedLists
            // 
            resources.ApplyResources(this.excludedLists, "excludedLists");
            this.excludedLists.Name = "excludedLists";
            // 
            // recoveringLists
            // 
            resources.ApplyResources(this.recoveringLists, "recoveringLists");
            this.recoveringLists.Name = "recoveringLists";
            // 
            // existingListWarning
            // 
            resources.ApplyResources(this.existingListWarning, "existingListWarning");
            this.existingListWarning.ForeColor = System.Drawing.Color.Red;
            this.existingListWarning.Name = "existingListWarning";
            // 
            // recoverButton
            // 
            resources.ApplyResources(this.recoverButton, "recoverButton");
            this.recoverButton.Name = "recoverButton";
            this.recoverButton.UseVisualStyleBackColor = true;
            this.recoverButton.Click += new System.EventHandler(this.recoverButton_Click);
            // 
            // existingListCheckBox
            // 
            resources.ApplyResources(this.existingListCheckBox, "existingListCheckBox");
            this.existingListCheckBox.ForeColor = System.Drawing.Color.Red;
            this.existingListCheckBox.Name = "existingListCheckBox";
            this.existingListCheckBox.UseVisualStyleBackColor = true;
            this.existingListCheckBox.CheckedChanged += new System.EventHandler(this.existingListCheckBox_CheckedChanged);
            // 
            // ListManagment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.existingListCheckBox);
            this.Controls.Add(this.recoverButton);
            this.Controls.Add(this.existingListWarning);
            this.Controls.Add(this.recoveringLists);
            this.Controls.Add(this.excludedLists);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.deletingLabel);
            this.Controls.Add(this.existingLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.toExisting);
            this.Controls.Add(this.toDelete);
            this.Controls.Add(this.deletingList);
            this.Controls.Add(this.existingList);
            this.Name = "ListManagment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox existingList;
        private System.Windows.Forms.ListBox deletingList;
        private System.Windows.Forms.Button toDelete;
        private System.Windows.Forms.Button toExisting;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label existingLabel;
        private System.Windows.Forms.Label deletingLabel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label excludedLists;
        private System.Windows.Forms.Label recoveringLists;
        private System.Windows.Forms.Label existingListWarning;
        private System.Windows.Forms.Button recoverButton;
        private System.Windows.Forms.CheckBox existingListCheckBox;
    }
}
