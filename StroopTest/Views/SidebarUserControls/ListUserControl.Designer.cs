namespace StroopTest.Views.SidebarControls
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
            this.audioPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageButton
            // 
            this.imageButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.imageButton.FlatAppearance.BorderSize = 0;
            this.imageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton.Location = new System.Drawing.Point(-3, 42);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(260, 33);
            this.imageButton.TabIndex = 2;
            this.imageButton.Text = "Imagens";
            this.imageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.imageButton.UseVisualStyleBackColor = true;
            // 
            // colorWordButton
            // 
            this.colorWordButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.colorWordButton.FlatAppearance.BorderSize = 0;
            this.colorWordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorWordButton.Location = new System.Drawing.Point(-3, 3);
            this.colorWordButton.Name = "colorWordButton";
            this.colorWordButton.Size = new System.Drawing.Size(260, 33);
            this.colorWordButton.TabIndex = 1;
            this.colorWordButton.Text = "Palavras e Cores";
            this.colorWordButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colorWordButton.UseVisualStyleBackColor = true;
            // 
            // audioButton
            // 
            this.audioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.audioButton.FlatAppearance.BorderSize = 0;
            this.audioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioButton.Location = new System.Drawing.Point(-3, 81);
            this.audioButton.Name = "audioButton";
            this.audioButton.Size = new System.Drawing.Size(260, 33);
            this.audioButton.TabIndex = 3;
            this.audioButton.Text = "Aúdios";
            this.audioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.audioButton.UseVisualStyleBackColor = true;
            this.audioButton.Click += new System.EventHandler(this.audioButton_CheckedChanged);
            // 
            // audioPanel
            // 
            this.audioPanel.Controls.Add(this.recordAudioButton);
            this.audioPanel.Controls.Add(this.newAudioListButton);
            this.audioPanel.Controls.Add(this.editAudioListButton);
            this.audioPanel.Controls.Add(this.radioButton4);
            this.audioPanel.Controls.Add(this.backAudioButton);
            this.audioPanel.Location = new System.Drawing.Point(0, 42);
            this.audioPanel.Name = "audioPanel";
            this.audioPanel.Size = new System.Drawing.Size(260, 222);
            this.audioPanel.TabIndex = 4;
            this.audioPanel.Visible = false;
            // 
            // recordAudioButton
            // 
            this.recordAudioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.recordAudioButton.FlatAppearance.BorderSize = 0;
            this.recordAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordAudioButton.Location = new System.Drawing.Point(3, 3);
            this.recordAudioButton.Name = "recordAudioButton";
            this.recordAudioButton.Size = new System.Drawing.Size(260, 33);
            this.recordAudioButton.TabIndex = 2;
            this.recordAudioButton.Text = "Gravar Aúdio";
            this.recordAudioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.recordAudioButton.UseVisualStyleBackColor = true;
            this.recordAudioButton.CheckedChanged += new System.EventHandler(this.recordAudioButton_CheckedChanged);
            // 
            // newAudioListButton
            // 
            this.newAudioListButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newAudioListButton.FlatAppearance.BorderSize = 0;
            this.newAudioListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAudioListButton.Location = new System.Drawing.Point(3, 42);
            this.newAudioListButton.Name = "newAudioListButton";
            this.newAudioListButton.Size = new System.Drawing.Size(260, 33);
            this.newAudioListButton.TabIndex = 3;
            this.newAudioListButton.Text = "Nova Lista";
            this.newAudioListButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newAudioListButton.UseVisualStyleBackColor = true;
            this.newAudioListButton.CheckedChanged += new System.EventHandler(this.newAudioListButton_CheckedChanged);
            // 
            // editAudioListButton
            // 
            this.editAudioListButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editAudioListButton.FlatAppearance.BorderSize = 0;
            this.editAudioListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editAudioListButton.Location = new System.Drawing.Point(3, 81);
            this.editAudioListButton.Name = "editAudioListButton";
            this.editAudioListButton.Size = new System.Drawing.Size(260, 33);
            this.editAudioListButton.TabIndex = 4;
            this.editAudioListButton.Text = "Editar Lista";
            this.editAudioListButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editAudioListButton.UseVisualStyleBackColor = true;
            this.editAudioListButton.CheckedChanged += new System.EventHandler(this.editAudioListButton_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.FlatAppearance.BorderSize = 0;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton4.Location = new System.Drawing.Point(3, 120);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(260, 33);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.Text = "Excluir Lista";
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // backAudioButton
            // 
            this.backAudioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.backAudioButton.FlatAppearance.BorderSize = 0;
            this.backAudioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backAudioButton.Location = new System.Drawing.Point(3, 159);
            this.backAudioButton.Name = "backAudioButton";
            this.backAudioButton.Size = new System.Drawing.Size(260, 33);
            this.backAudioButton.TabIndex = 6;
            this.backAudioButton.Text = "Voltar";
            this.backAudioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backAudioButton.UseVisualStyleBackColor = true;
            this.backAudioButton.Click += new System.EventHandler(this.backAudioButton_CheckedChanged);
            // 
            // ListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioButton);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.colorWordButton);
            this.Controls.Add(this.audioPanel);
            this.Name = "ListUserControl";
            this.audioPanel.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
