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
            this.wordColorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newWordColorButton = new System.Windows.Forms.RadioButton();
            this.editWordColorButton = new System.Windows.Forms.RadioButton();
            this.deleteWordColorButton = new System.Windows.Forms.RadioButton();
            this.backWordColorButton = new System.Windows.Forms.RadioButton();
            this.recordAudioButton = new System.Windows.Forms.RadioButton();
            this.newAudioListButton = new System.Windows.Forms.RadioButton();
            this.editAudioListButton = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.backAudioButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.audioPanel.SuspendLayout();
            this.wordColorPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.colorWordButton.Click += new System.EventHandler(this.colorWordButton_Click);
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
            this.audioPanel.Size = new System.Drawing.Size(267, 366);
            this.audioPanel.TabIndex = 4;
            this.audioPanel.Visible = false;
            // 
            // wordColorPanel
            // 
            this.wordColorPanel.Controls.Add(this.newWordColorButton);
            this.wordColorPanel.Controls.Add(this.editWordColorButton);
            this.wordColorPanel.Controls.Add(this.deleteWordColorButton);
            this.wordColorPanel.Controls.Add(this.backWordColorButton);
            this.wordColorPanel.Location = new System.Drawing.Point(0, 42);
            this.wordColorPanel.Name = "wordColorPanel";
            this.wordColorPanel.Size = new System.Drawing.Size(260, 156);
            this.wordColorPanel.TabIndex = 7;
            this.wordColorPanel.Visible = false;
            // 
            // newWordColorButton
            // 
            this.newWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newWordColorButton.FlatAppearance.BorderSize = 0;
            this.newWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newWordColorButton.Location = new System.Drawing.Point(3, 3);
            this.newWordColorButton.Name = "newWordColorButton";
            this.newWordColorButton.Size = new System.Drawing.Size(260, 33);
            this.newWordColorButton.TabIndex = 3;
            this.newWordColorButton.Text = "Nova Lista";
            this.newWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newWordColorButton.UseVisualStyleBackColor = true;
            this.newWordColorButton.Click += new System.EventHandler(this.newWordColorButton_Click);
            // 
            // editWordColorButton
            // 
            this.editWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editWordColorButton.FlatAppearance.BorderSize = 0;
            this.editWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editWordColorButton.Location = new System.Drawing.Point(3, 42);
            this.editWordColorButton.Name = "editWordColorButton";
            this.editWordColorButton.Size = new System.Drawing.Size(260, 33);
            this.editWordColorButton.TabIndex = 4;
            this.editWordColorButton.Text = "Editar Lista";
            this.editWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editWordColorButton.UseVisualStyleBackColor = true;
            this.editWordColorButton.Click += new System.EventHandler(this.editWordColorButton_Click);
            // 
            // deleteWordColorButton
            // 
            this.deleteWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.deleteWordColorButton.FlatAppearance.BorderSize = 0;
            this.deleteWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteWordColorButton.Location = new System.Drawing.Point(3, 81);
            this.deleteWordColorButton.Name = "deleteWordColorButton";
            this.deleteWordColorButton.Size = new System.Drawing.Size(260, 33);
            this.deleteWordColorButton.TabIndex = 5;
            this.deleteWordColorButton.Text = "Excluir Lista";
            this.deleteWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteWordColorButton.UseVisualStyleBackColor = true;
            // 
            // backWordColorButton
            // 
            this.backWordColorButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.backWordColorButton.FlatAppearance.BorderSize = 0;
            this.backWordColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backWordColorButton.Location = new System.Drawing.Point(3, 120);
            this.backWordColorButton.Name = "backWordColorButton";
            this.backWordColorButton.Size = new System.Drawing.Size(260, 33);
            this.backWordColorButton.TabIndex = 6;
            this.backWordColorButton.Text = "Voltar";
            this.backWordColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backWordColorButton.UseVisualStyleBackColor = true;
            this.backWordColorButton.Click += new System.EventHandler(this.backWordColorButton_CheckedChanged);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Controls.Add(this.radioButton3);
            this.flowLayoutPanel1.Controls.Add(this.radioButton5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 372);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 156);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.FlatAppearance.BorderSize = 0;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(260, 33);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Nova Lista";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.FlatAppearance.BorderSize = 0;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(3, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(260, 33);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Editar Lista";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.FlatAppearance.BorderSize = 0;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(3, 81);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(260, 33);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "Excluir Lista";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton5.FlatAppearance.BorderSize = 0;
            this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton5.Location = new System.Drawing.Point(3, 120);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(260, 33);
            this.radioButton5.TabIndex = 6;
            this.radioButton5.Text = "Voltar";
            this.radioButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // ListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wordColorPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.audioButton);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.colorWordButton);
            this.Controls.Add(this.audioPanel);
            this.Name = "ListUserControl";
            this.audioPanel.ResumeLayout(false);
            this.wordColorPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel wordColorPanel;
        private System.Windows.Forms.RadioButton newWordColorButton;
        private System.Windows.Forms.RadioButton editWordColorButton;
        private System.Windows.Forms.RadioButton deleteWordColorButton;
        private System.Windows.Forms.RadioButton backWordColorButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton5;
    }
}
