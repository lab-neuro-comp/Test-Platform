namespace TestPlatform.Views.SidebarControls
{
    partial class ListUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListUserControl));
            this.imageButton = new System.Windows.Forms.RadioButton();
            this.colorWordButton = new System.Windows.Forms.RadioButton();
            this.audioButton = new System.Windows.Forms.RadioButton();
            this.audioPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newAudioListButton = new System.Windows.Forms.RadioButton();
            this.recordAudioButton = new System.Windows.Forms.RadioButton();
            this.editAudioListButton = new System.Windows.Forms.RadioButton();
            this.deleteAudioListButton = new System.Windows.Forms.RadioButton();
            this.recoverAudioListButton = new System.Windows.Forms.RadioButton();
            this.backAudioButton = new System.Windows.Forms.RadioButton();
            this.wordColorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newWordColorButton = new System.Windows.Forms.RadioButton();
            this.editWordColorButton = new System.Windows.Forms.RadioButton();
            this.deleteWordColorButton = new System.Windows.Forms.RadioButton();
            this.recoverWordColorButton = new System.Windows.Forms.RadioButton();
            this.backWordColorButton = new System.Windows.Forms.RadioButton();
            this.imagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.editImageListButton = new System.Windows.Forms.RadioButton();
            this.newImageListButton = new System.Windows.Forms.RadioButton();
            this.deleteImageListButton = new System.Windows.Forms.RadioButton();
            this.recoverImageListButton = new System.Windows.Forms.RadioButton();
            this.backImageButton = new System.Windows.Forms.RadioButton();
            this.audioPanel.SuspendLayout();
            this.wordColorPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageButton
            // 
            resources.ApplyResources(this.imageButton, "imageButton");
            this.imageButton.FlatAppearance.BorderSize = 0;
            this.imageButton.Name = "imageButton";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // colorWordButton
            // 
            resources.ApplyResources(this.colorWordButton, "colorWordButton");
            this.colorWordButton.FlatAppearance.BorderSize = 0;
            this.colorWordButton.Name = "colorWordButton";
            this.colorWordButton.UseVisualStyleBackColor = true;
            this.colorWordButton.Click += new System.EventHandler(this.colorWordButton_Click);
            // 
            // audioButton
            // 
            resources.ApplyResources(this.audioButton, "audioButton");
            this.audioButton.FlatAppearance.BorderSize = 0;
            this.audioButton.Name = "audioButton";
            this.audioButton.UseVisualStyleBackColor = true;
            this.audioButton.Click += new System.EventHandler(this.audioButton_CheckedChanged);
            // 
            // audioPanel
            // 
            resources.ApplyResources(this.audioPanel, "audioPanel");
            this.audioPanel.Controls.Add(this.newAudioListButton);
            this.audioPanel.Controls.Add(this.recordAudioButton);
            this.audioPanel.Controls.Add(this.editAudioListButton);
            this.audioPanel.Controls.Add(this.deleteAudioListButton);
            this.audioPanel.Controls.Add(this.recoverAudioListButton);
            this.audioPanel.Controls.Add(this.backAudioButton);
            this.audioPanel.Name = "audioPanel";
            // 
            // newAudioListButton
            // 
            resources.ApplyResources(this.newAudioListButton, "newAudioListButton");
            this.newAudioListButton.FlatAppearance.BorderSize = 0;
            this.newAudioListButton.Name = "newAudioListButton";
            this.newAudioListButton.UseVisualStyleBackColor = true;
            this.newAudioListButton.CheckedChanged += new System.EventHandler(this.newAudioListButton_CheckedChanged);
            // 
            // recordAudioButton
            // 
            resources.ApplyResources(this.recordAudioButton, "recordAudioButton");
            this.recordAudioButton.FlatAppearance.BorderSize = 0;
            this.recordAudioButton.Name = "recordAudioButton";
            this.recordAudioButton.UseVisualStyleBackColor = true;
            this.recordAudioButton.CheckedChanged += new System.EventHandler(this.recordAudioButton_CheckedChanged);
            // 
            // editAudioListButton
            // 
            resources.ApplyResources(this.editAudioListButton, "editAudioListButton");
            this.editAudioListButton.FlatAppearance.BorderSize = 0;
            this.editAudioListButton.Name = "editAudioListButton";
            this.editAudioListButton.UseVisualStyleBackColor = true;
            this.editAudioListButton.CheckedChanged += new System.EventHandler(this.editAudioListButton_CheckedChanged);
            // 
            // deleteAudioListButton
            // 
            resources.ApplyResources(this.deleteAudioListButton, "deleteAudioListButton");
            this.deleteAudioListButton.FlatAppearance.BorderSize = 0;
            this.deleteAudioListButton.Name = "deleteAudioListButton";
            this.deleteAudioListButton.UseVisualStyleBackColor = true;
            this.deleteAudioListButton.Click += new System.EventHandler(this.deleteAudioListButton_Click);
            // 
            // recoverAudioListButton
            // 
            resources.ApplyResources(this.recoverAudioListButton, "recoverAudioListButton");
            this.recoverAudioListButton.FlatAppearance.BorderSize = 0;
            this.recoverAudioListButton.Name = "recoverAudioListButton";
            this.recoverAudioListButton.TabStop = true;
            this.recoverAudioListButton.UseVisualStyleBackColor = true;
            this.recoverAudioListButton.CheckedChanged += new System.EventHandler(this.recoverAudioListButton_CheckedChanged);
            // 
            // backAudioButton
            // 
            resources.ApplyResources(this.backAudioButton, "backAudioButton");
            this.backAudioButton.FlatAppearance.BorderSize = 0;
            this.backAudioButton.Name = "backAudioButton";
            this.backAudioButton.UseVisualStyleBackColor = true;
            this.backAudioButton.Click += new System.EventHandler(this.backAudioButton_CheckedChanged);
            // 
            // wordColorPanel
            // 
            resources.ApplyResources(this.wordColorPanel, "wordColorPanel");
            this.wordColorPanel.Controls.Add(this.newWordColorButton);
            this.wordColorPanel.Controls.Add(this.editWordColorButton);
            this.wordColorPanel.Controls.Add(this.deleteWordColorButton);
            this.wordColorPanel.Controls.Add(this.recoverWordColorButton);
            this.wordColorPanel.Controls.Add(this.backWordColorButton);
            this.wordColorPanel.Name = "wordColorPanel";
            // 
            // newWordColorButton
            // 
            resources.ApplyResources(this.newWordColorButton, "newWordColorButton");
            this.newWordColorButton.FlatAppearance.BorderSize = 0;
            this.newWordColorButton.Name = "newWordColorButton";
            this.newWordColorButton.UseVisualStyleBackColor = true;
            this.newWordColorButton.Click += new System.EventHandler(this.newWordColorButton_Click);
            // 
            // editWordColorButton
            // 
            resources.ApplyResources(this.editWordColorButton, "editWordColorButton");
            this.editWordColorButton.FlatAppearance.BorderSize = 0;
            this.editWordColorButton.Name = "editWordColorButton";
            this.editWordColorButton.UseVisualStyleBackColor = true;
            this.editWordColorButton.Click += new System.EventHandler(this.editWordColorButton_Click);
            // 
            // deleteWordColorButton
            // 
            resources.ApplyResources(this.deleteWordColorButton, "deleteWordColorButton");
            this.deleteWordColorButton.FlatAppearance.BorderSize = 0;
            this.deleteWordColorButton.Name = "deleteWordColorButton";
            this.deleteWordColorButton.UseVisualStyleBackColor = true;
            this.deleteWordColorButton.Click += new System.EventHandler(this.deleteWordColorButton_Click);
            // 
            // recoverWordColorButton
            // 
            resources.ApplyResources(this.recoverWordColorButton, "recoverWordColorButton");
            this.recoverWordColorButton.FlatAppearance.BorderSize = 0;
            this.recoverWordColorButton.Name = "recoverWordColorButton";
            this.recoverWordColorButton.TabStop = true;
            this.recoverWordColorButton.UseVisualStyleBackColor = true;
            this.recoverWordColorButton.CheckedChanged += new System.EventHandler(this.recoverWordColorButton_CheckedChanged);
            // 
            // backWordColorButton
            // 
            resources.ApplyResources(this.backWordColorButton, "backWordColorButton");
            this.backWordColorButton.FlatAppearance.BorderSize = 0;
            this.backWordColorButton.Name = "backWordColorButton";
            this.backWordColorButton.UseVisualStyleBackColor = true;
            this.backWordColorButton.Click += new System.EventHandler(this.backWordColorButton_CheckedChanged);
            // 
            // imagePanel
            // 
            resources.ApplyResources(this.imagePanel, "imagePanel");
            this.imagePanel.Controls.Add(this.editImageListButton);
            this.imagePanel.Controls.Add(this.newImageListButton);
            this.imagePanel.Controls.Add(this.deleteImageListButton);
            this.imagePanel.Controls.Add(this.recoverImageListButton);
            this.imagePanel.Controls.Add(this.backImageButton);
            this.imagePanel.Name = "imagePanel";
            // 
            // editImageListButton
            // 
            resources.ApplyResources(this.editImageListButton, "editImageListButton");
            this.editImageListButton.FlatAppearance.BorderSize = 0;
            this.editImageListButton.Name = "editImageListButton";
            this.editImageListButton.UseVisualStyleBackColor = true;
            this.editImageListButton.Click += new System.EventHandler(this.editImageListButton_Click);
            // 
            // newImageListButton
            // 
            resources.ApplyResources(this.newImageListButton, "newImageListButton");
            this.newImageListButton.FlatAppearance.BorderSize = 0;
            this.newImageListButton.Name = "newImageListButton";
            this.newImageListButton.UseVisualStyleBackColor = true;
            this.newImageListButton.Click += new System.EventHandler(this.newImageListButton_Click);
            // 
            // deleteImageListButton
            // 
            resources.ApplyResources(this.deleteImageListButton, "deleteImageListButton");
            this.deleteImageListButton.FlatAppearance.BorderSize = 0;
            this.deleteImageListButton.Name = "deleteImageListButton";
            this.deleteImageListButton.UseVisualStyleBackColor = true;
            this.deleteImageListButton.Click += new System.EventHandler(this.deleteImageListButton_Click);
            // 
            // recoverImageListButton
            // 
            resources.ApplyResources(this.recoverImageListButton, "recoverImageListButton");
            this.recoverImageListButton.FlatAppearance.BorderSize = 0;
            this.recoverImageListButton.Name = "recoverImageListButton";
            this.recoverImageListButton.TabStop = true;
            this.recoverImageListButton.UseVisualStyleBackColor = true;
            this.recoverImageListButton.CheckedChanged += new System.EventHandler(this.recoverImageListButton_CheckedChanged);
            // 
            // backImageButton
            // 
            resources.ApplyResources(this.backImageButton, "backImageButton");
            this.backImageButton.FlatAppearance.BorderSize = 0;
            this.backImageButton.Name = "backImageButton";
            this.backImageButton.UseVisualStyleBackColor = true;
            this.backImageButton.Click += new System.EventHandler(this.backImageButton_Click);
            // 
            // ListUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioPanel);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.audioButton);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.colorWordButton);
            this.Controls.Add(this.wordColorPanel);
            this.Name = "ListUserControl";
            this.audioPanel.ResumeLayout(false);
            this.wordColorPanel.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton colorWordButton;
        private System.Windows.Forms.RadioButton imageButton;
        private System.Windows.Forms.RadioButton audioButton;
        private System.Windows.Forms.FlowLayoutPanel audioPanel;
        private System.Windows.Forms.RadioButton recordAudioButton;
        private System.Windows.Forms.RadioButton newAudioListButton;
        private System.Windows.Forms.RadioButton editAudioListButton;
        private System.Windows.Forms.RadioButton deleteAudioListButton;
        private System.Windows.Forms.RadioButton backAudioButton;
        private System.Windows.Forms.FlowLayoutPanel wordColorPanel;
        private System.Windows.Forms.RadioButton newWordColorButton;
        private System.Windows.Forms.RadioButton editWordColorButton;
        private System.Windows.Forms.RadioButton deleteWordColorButton;
        private System.Windows.Forms.RadioButton backWordColorButton;
        private System.Windows.Forms.FlowLayoutPanel imagePanel;
        private System.Windows.Forms.RadioButton newImageListButton;
        private System.Windows.Forms.RadioButton editImageListButton;
        private System.Windows.Forms.RadioButton deleteImageListButton;
        private System.Windows.Forms.RadioButton backImageButton;
        private System.Windows.Forms.RadioButton recoverImageListButton;
        private System.Windows.Forms.RadioButton recoverAudioListButton;
        private System.Windows.Forms.RadioButton recoverWordColorButton;
    }
}
