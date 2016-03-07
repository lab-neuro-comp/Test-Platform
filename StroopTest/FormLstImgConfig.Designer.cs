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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkColors = new System.Windows.Forms.CheckBox();
            this.checkWords = new System.Windows.Forms.CheckBox();
            this.textWords = new System.Windows.Forms.TextBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.imgListView = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(653, 538);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Lista Imagens";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Location = new System.Drawing.Point(14, 540);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 36;
            this.button3.TabStop = false;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Location = new System.Drawing.Point(109, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.TabStop = false;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // checkColors
            // 
            this.checkColors.AutoSize = true;
            this.checkColors.Location = new System.Drawing.Point(14, 39);
            this.checkColors.Name = "checkColors";
            this.checkColors.Size = new System.Drawing.Size(137, 21);
            this.checkColors.TabIndex = 35;
            this.checkColors.TabStop = false;
            this.checkColors.Text = "Lista de Imagens";
            this.checkColors.UseVisualStyleBackColor = true;
            // 
            // checkWords
            // 
            this.checkWords.AutoSize = true;
            this.checkWords.Location = new System.Drawing.Point(14, 11);
            this.checkWords.Name = "checkWords";
            this.checkWords.Size = new System.Drawing.Size(139, 21);
            this.checkWords.TabIndex = 34;
            this.checkWords.TabStop = false;
            this.checkWords.Text = "Lista de Palavras";
            this.checkWords.UseVisualStyleBackColor = true;
            // 
            // textWords
            // 
            this.textWords.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWords.Location = new System.Drawing.Point(14, 66);
            this.textWords.Name = "textWords";
            this.textWords.Size = new System.Drawing.Size(170, 45);
            this.textWords.TabIndex = 27;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(99, 168);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(85, 23);
            this.buttonInsert.TabIndex = 29;
            this.buttonInsert.TabStop = false;
            this.buttonInsert.Text = "+";
            this.buttonInsert.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(14, 168);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(85, 23);
            this.buttonRemove.TabIndex = 31;
            this.buttonRemove.TabStop = false;
            this.buttonRemove.Text = "-";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // imgListView
            // 
            this.imgListView.Location = new System.Drawing.Point(190, 11);
            this.imgListView.Name = "imgListView";
            this.imgListView.Size = new System.Drawing.Size(230, 525);
            this.imgListView.TabIndex = 38;
            this.imgListView.UseCompatibleStateImageBehavior = false;
            this.imgListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imgListView_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(426, 10);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(230, 525);
            this.listView1.TabIndex = 39;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FormLstImgConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 575);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.imgListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkColors);
            this.Controls.Add(this.checkWords);
            this.Controls.Add(this.textWords);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonRemove);
            this.Name = "FormLstImgConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLstImgConfig";
            this.Load += new System.EventHandler(this.FormLstImgConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkColors;
        private System.Windows.Forms.CheckBox checkWords;
        private System.Windows.Forms.TextBox textWords;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListView imgListView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList2;
    }
}