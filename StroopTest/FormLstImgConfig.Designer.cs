namespace StroopTest
{
    partial class FormLstImgConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLstImgConfig));
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.imgListView = new System.Windows.Forms.ListView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInsert
            // 
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(9, 46);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(64, 19);
            this.buttonInsert.TabIndex = 29;
            this.buttonInsert.TabStop = false;
            this.buttonInsert.Text = "+";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.selectFiles);
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(77, 46);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(64, 19);
            this.buttonRemove.TabIndex = 31;
            this.buttonRemove.TabStop = false;
            this.buttonRemove.Text = "-";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // imgListView
            // 
            this.imgListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgListView.LabelEdit = true;
            this.imgListView.Location = new System.Drawing.Point(9, 70);
            this.imgListView.Margin = new System.Windows.Forms.Padding(2);
            this.imgListView.Name = "imgListView";
            this.imgListView.ShowItemToolTips = true;
            this.imgListView.Size = new System.Drawing.Size(297, 335);
            this.imgListView.TabIndex = 38;
            this.imgListView.UseCompatibleStateImageBehavior = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Nome da Lista:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(231, 410);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 42;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(9, 410);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 41;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FormLstImgConfig
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(314, 440);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.imgListView);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonRemove);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLstImgConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Imagens";
            this.Load += new System.EventHandler(this.FormLstImgConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListView imgListView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}