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
            this.imageButton = new System.Windows.Forms.RadioButton();
            this.colorWordButton = new System.Windows.Forms.RadioButton();
            this.audioButton = new System.Windows.Forms.RadioButton();
            this.audioPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.recordAudioButton = new System.Windows.Forms.RadioButton();
            this.newAudioListButton = new System.Windows.Forms.RadioButton();
            this.editAudioListButton = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.backAudioButton = new System.Windows.Forms.RadioButton();
            this.wordColorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newWordColorButton = new System.Windows.Forms.RadioButton();
            this.editWordColorButton = new System.Windows.Forms.RadioButton();
            this.deleteWordColorButton = new System.Windows.Forms.RadioButton();
            this.backWordColorButton = new System.Windows.Forms.RadioButton();
            this.imagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newImageListButton = new System.Windows.Forms.RadioButton();
            this.editImageListButton = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.backImageButton = new System.Windows.Forms.RadioButton();
            this.audioPanel.SuspendLayout();
            this.wordColorPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageButton
            // 
            this.imageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.imageButton.FlatAppearance.BorderSize = 0;
            this.imageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton.Location = new System.Drawing.Point(-3, 42);
            this.imageButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(272, 33);
            this.imageButton.TabIndex = 2;
            this.imageButton.Text = "Imagens";
            this.imageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // colorWordButton
            // 
            this.colorWordButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorWordButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.colorWordButton.FlatAppearance.BorderSize = 0;
            this.colorWordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorWordButton.Location = new System.Drawing.Point(-3, 3);
            this.colorWordButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.colorWordButton.Name = "colorWordButton";
            this.colorWordButton.Size = new System.Drawing.Size(272, 33);
            this.colorWordButton.TabIndex = 1;
            this.colorWordButton.Text = "Palavras e Cores";
            this.colorWordButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colorWordButton.UseVisualStyleBackColor = true;
            this.colorWordButton.Click += new System.EventHandler(this.colorWordButton_Click);
            // 
            // audioButton
            // 
            this.audioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.audioButton.FlatAppearance.BorderSize = 0;
            this.audioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioButton.Location = new System.Drawing.Point(-3, 81);
            this.audioButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.audioButton.Name = "audioButton";
            this.audioButton.Size = new System.Drawing.Size(272, 33);
            this.audioButton.TabIndex = 3;
            this.audioButton.Text = "Aúdios";
            this.audioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.audioButton.UseVisualStyleBackColor = true;
            this.audioButton.Click += new System.EventHandler(this.audioButton_CheckedChanged);
            // 
            // audioPanel
            // 
            this.audioPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioPanel.AutoSize = true;
            this.audioPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.audioPanel.Controls.Add(this.recordAudioButton);
            this.audioPanel.Controls.Add(this.newAudioListButton);
            this.audioPanel.Controls.Add(this.editAudioListButton);
            this.audioPanel.Controls.Add(this.radioButton4);
            this.audioPanel.Controls.Add(this.backAudioButton);
            this.audioPanel.Location = new System.Drawing.Point(0, 42);
            this.audioPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.audioPanel.Name = "audioPanel";
            this.audioPanel.Size = new System.Drawing.Size(272, 195);
            this.audioPanel.TabIndex = 4;
            this.audioPanel.Visible = false;
            // 
            // recordAudioButton
            // 
            this.recordAudioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordAudioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.recordAudioButton.FlatAppearance.BorderSize = 0;
            this.recordAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordAudioButton.Location = new System.Drawing.Point(0, 3);
            this.recordAudioButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.recordAudioButton.Name = "recordAudioButton";
            this.recordAudioButton.Size = new System.Drawing.Size(272, 33);
            this.recordAudioButton.TabIndex = 2;
            this.recordAudioButton.Text = "Gravar Aúdio";
            this.recordAudioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.recordAudioButton.UseVisualStyleBackColor = true;
            this.recordAudioButton.CheckedChanged += new System.EventHandler(this.recordAudioButton_CheckedChanged);
            // 
            // newAudioListButton
            // 
            this.newAudioListButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newAudioListButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newAudioListButton.FlatAppearance.BorderSize = 0;
            this.newAudioListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAudioListButton.Location = new System.Drawing.Point(0, 42);
            this.newAudioListButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.newAudioListButton.Name = "newAudioListButton";
            this.newAudioListButton.Size = new System.Drawing.Size(272, 33);
            this.newAudioListButton.TabIndex = 3;
            this.newAudioListButton.Text = "Nova Lista";
            this.newAudioListButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newAudioListButton.UseVisualStyleBackColor = true;
            this.newAudioListButton.CheckedChanged += new System.EventHandler(this.newAudioListButton_CheckedChanged);
            // 
            // editAudioListButton
            // 
            this.editAudioListButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editAudioListButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editAudioListButton.FlatAppearance.BorderSize = 0;
            this.editAudioListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editAudioListButton.Location = new System.Drawing.Point(0, 81);
            this.editAudioListButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.editAudioListButton.Name = "editAudioListButton";
            this.editAudioListButton.Size = new System.Drawing.Size(272, 33);
            this.editAudioListButton.TabIndex = 4;
            this.editAudioListButton.Text = "Editar Lista";
            this.editAudioListButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editAudioListButton.UseVisualStyleBackColor = true;
            this.editAudioListButton.CheckedChanged += new System.EventHandler(this.editAudioListButton_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.Enabled = false;
            this.radioButton4.FlatAppearance.BorderSize = 0;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton4.Location = new System.Drawing.Point(0, 120);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(272, 33);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.Text = "Excluir Lista";
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // backAudioButton
            // 
            this.backAudioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backAudioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.backAudioButton.FlatAppearance.BorderSize = 0;
            this.backAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backAudioButton.Location = new System.Drawing.Point(0, 159);
            this.backAudioButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.backAudioButton.Name = "backAudioButton";
            this.backAudioButton.Size = new System.Drawing.Size(272, 33);
            this.backAudioButton.TabIndex = 6;
            this.backAudioButton.Text = "Voltar";
            this.backAudioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backAudioButton.UseVisualStyleBackColor = true;
            this.backAudioButton.Click += new System.EventHandler(this.backAudioButton_CheckedChanged);
            // 
            // wordColorPanel
            // 
            this.wordColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordColorPanel.Controls.Add(this.newWordColorButton);
            this.wordColorPanel.Controls.Add(this.editWordColorButton);
            this.wordColorPanel.Controls.Add(this.deleteWordColorButton);
            this.wordColorPanel.Controls.Add(this.backWordColorButton);
            this.wordColorPanel.Location = new System.Drawing.Point(0, 42);
            this.wordColorPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.wordColorPanel.Name = "wordColorPanel";
            this.wordColorPanel.Size = new System.Drawing.Size(272, 156);
            this.wordColorPanel.TabIndex = 7;
            this.wordColorPanel.Visible = false;
            // 
            // newWordColorButton
            // 
            this.newWordColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newWordColorButton.FlatAppearance.BorderSize = 0;
            this.newWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newWordColorButton.Location = new System.Drawing.Point(0, 3);
            this.newWordColorButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.newWordColorButton.Name = "newWordColorButton";
            this.newWordColorButton.Size = new System.Drawing.Size(272, 33);
            this.newWordColorButton.TabIndex = 3;
            this.newWordColorButton.Text = "Nova Lista";
            this.newWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newWordColorButton.UseVisualStyleBackColor = true;
            this.newWordColorButton.Click += new System.EventHandler(this.newWordColorButton_Click);
            // 
            // editWordColorButton
            // 
            this.editWordColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editWordColorButton.FlatAppearance.BorderSize = 0;
            this.editWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editWordColorButton.Location = new System.Drawing.Point(0, 42);
            this.editWordColorButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.editWordColorButton.Name = "editWordColorButton";
            this.editWordColorButton.Size = new System.Drawing.Size(272, 33);
            this.editWordColorButton.TabIndex = 4;
            this.editWordColorButton.Text = "Editar Lista";
            this.editWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editWordColorButton.UseVisualStyleBackColor = true;
            this.editWordColorButton.Click += new System.EventHandler(this.editWordColorButton_Click);
            // 
            // deleteWordColorButton
            // 
            this.deleteWordColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.deleteWordColorButton.FlatAppearance.BorderSize = 0;
            this.deleteWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteWordColorButton.Location = new System.Drawing.Point(0, 81);
            this.deleteWordColorButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.deleteWordColorButton.Name = "deleteWordColorButton";
            this.deleteWordColorButton.Size = new System.Drawing.Size(272, 33);
            this.deleteWordColorButton.TabIndex = 5;
            this.deleteWordColorButton.Text = "Excluir Lista";
            this.deleteWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteWordColorButton.UseVisualStyleBackColor = true;
            // 
            // backWordColorButton
            // 
            this.backWordColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.backWordColorButton.FlatAppearance.BorderSize = 0;
            this.backWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backWordColorButton.Location = new System.Drawing.Point(0, 120);
            this.backWordColorButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.backWordColorButton.Name = "backWordColorButton";
            this.backWordColorButton.Size = new System.Drawing.Size(272, 33);
            this.backWordColorButton.TabIndex = 6;
            this.backWordColorButton.Text = "Voltar";
            this.backWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backWordColorButton.UseVisualStyleBackColor = true;
            this.backWordColorButton.Click += new System.EventHandler(this.backWordColorButton_CheckedChanged);
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.Controls.Add(this.newImageListButton);
            this.imagePanel.Controls.Add(this.editImageListButton);
            this.imagePanel.Controls.Add(this.radioButton3);
            this.imagePanel.Controls.Add(this.backImageButton);
            this.imagePanel.Location = new System.Drawing.Point(0, 39);
            this.imagePanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(272, 156);
            this.imagePanel.TabIndex = 8;
            this.imagePanel.Visible = false;
            // 
            // newImageListButton
            // 
            this.newImageListButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newImageListButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newImageListButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newImageListButton.FlatAppearance.BorderSize = 0;
            this.newImageListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newImageListButton.Location = new System.Drawing.Point(0, 3);
            this.newImageListButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.newImageListButton.Name = "newImageListButton";
            this.newImageListButton.Size = new System.Drawing.Size(279, 33);
            this.newImageListButton.TabIndex = 3;
            this.newImageListButton.Text = "Nova Lista";
            this.newImageListButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newImageListButton.UseVisualStyleBackColor = true;
            this.newImageListButton.Click += new System.EventHandler(this.newImageListButton_Click);
            // 
            // editImageListButton
            // 
            this.editImageListButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editImageListButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editImageListButton.FlatAppearance.BorderSize = 0;
            this.editImageListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editImageListButton.Location = new System.Drawing.Point(0, 42);
            this.editImageListButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.editImageListButton.Name = "editImageListButton";
            this.editImageListButton.Size = new System.Drawing.Size(272, 33);
            this.editImageListButton.TabIndex = 4;
            this.editImageListButton.Text = "Editar Lista";
            this.editImageListButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editImageListButton.UseVisualStyleBackColor = true;
            this.editImageListButton.Click += new System.EventHandler(this.editImageListButton_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.Enabled = false;
            this.radioButton3.FlatAppearance.BorderSize = 0;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(0, 81);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(272, 33);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "Excluir Lista";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // backImageButton
            // 
            this.backImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backImageButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.backImageButton.FlatAppearance.BorderSize = 0;
            this.backImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backImageButton.Location = new System.Drawing.Point(0, 120);
            this.backImageButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.backImageButton.Name = "backImageButton";
            this.backImageButton.Size = new System.Drawing.Size(272, 33);
            this.backImageButton.TabIndex = 6;
            this.backImageButton.Text = "Voltar";
            this.backImageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backImageButton.UseVisualStyleBackColor = true;
            this.backImageButton.Click += new System.EventHandler(this.backImageButton_Click);
            // 
            // ListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.audioButton);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.colorWordButton);
            this.Controls.Add(this.wordColorPanel);
            this.Controls.Add(this.audioPanel);
            this.Name = "ListUserControl";
            this.Size = new System.Drawing.Size(279, 1309);
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
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton backAudioButton;
        private System.Windows.Forms.FlowLayoutPanel wordColorPanel;
        private System.Windows.Forms.RadioButton newWordColorButton;
        private System.Windows.Forms.RadioButton editWordColorButton;
        private System.Windows.Forms.RadioButton deleteWordColorButton;
        private System.Windows.Forms.RadioButton backWordColorButton;
        private System.Windows.Forms.FlowLayoutPanel imagePanel;
        private System.Windows.Forms.RadioButton newImageListButton;
        private System.Windows.Forms.RadioButton editImageListButton;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton backImageButton;
    }
}
