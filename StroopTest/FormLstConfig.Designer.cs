namespace StroopTest
{
    partial class FormLstConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLstConfig));
            this.buttonColorPallette = new System.Windows.Forms.Button();
            this.textHexColor = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.hexColorsList = new System.Windows.Forms.ListView();
            this.textWords = new System.Windows.Forms.TextBox();
            this.checkWords = new System.Windows.Forms.CheckBox();
            this.checkColors = new System.Windows.Forms.CheckBox();
            this.wordsColoredList = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wordsListName = new System.Windows.Forms.Label();
            this.colorsListName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonColorPallette
            // 
            this.buttonColorPallette.Location = new System.Drawing.Point(12, 214);
            this.buttonColorPallette.Name = "buttonColorPallette";
            this.buttonColorPallette.Size = new System.Drawing.Size(170, 23);
            this.buttonColorPallette.TabIndex = 3;
            this.buttonColorPallette.Text = "paleta de cores";
            this.buttonColorPallette.UseVisualStyleBackColor = true;
            this.buttonColorPallette.Click += new System.EventHandler(this.button2_Click);
            // 
            // textHexColor
            // 
            this.textHexColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textHexColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textHexColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textHexColor.Location = new System.Drawing.Point(12, 165);
            this.textHexColor.MaxLength = 7;
            this.textHexColor.Name = "textHexColor";
            this.textHexColor.Size = new System.Drawing.Size(170, 45);
            this.textHexColor.TabIndex = 2;
            this.textHexColor.Text = "#000000";
            this.textHexColor.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(12, 243);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(82, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.TabStop = false;
            this.buttonRemove.Text = "-";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(100, 243);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(82, 23);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.TabStop = false;
            this.buttonInsert.Text = "+";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.button3_Click);
            // 
            // hexColorsList
            // 
            this.hexColorsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexColorsList.LabelEdit = true;
            this.hexColorsList.Location = new System.Drawing.Point(206, 32);
            this.hexColorsList.Name = "hexColorsList";
            this.hexColorsList.Size = new System.Drawing.Size(267, 504);
            this.hexColorsList.TabIndex = 17;
            this.hexColorsList.TabStop = false;
            this.hexColorsList.TileSize = new System.Drawing.Size(200, 60);
            this.hexColorsList.UseCompatibleStateImageBehavior = false;
            this.hexColorsList.View = System.Windows.Forms.View.Tile;
            this.hexColorsList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.hexColorsList_ItemSelectionChanged);
            // 
            // textWords
            // 
            this.textWords.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWords.Location = new System.Drawing.Point(12, 114);
            this.textWords.Name = "textWords";
            this.textWords.Size = new System.Drawing.Size(170, 45);
            this.textWords.TabIndex = 1;
            // 
            // checkWords
            // 
            this.checkWords.AutoSize = true;
            this.checkWords.Location = new System.Drawing.Point(12, 60);
            this.checkWords.Name = "checkWords";
            this.checkWords.Size = new System.Drawing.Size(139, 21);
            this.checkWords.TabIndex = 20;
            this.checkWords.TabStop = false;
            this.checkWords.Text = "Lista de Palavras";
            this.checkWords.UseVisualStyleBackColor = true;
            this.checkWords.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkColors
            // 
            this.checkColors.AutoSize = true;
            this.checkColors.Location = new System.Drawing.Point(12, 87);
            this.checkColors.Name = "checkColors";
            this.checkColors.Size = new System.Drawing.Size(121, 21);
            this.checkColors.TabIndex = 21;
            this.checkColors.TabStop = false;
            this.checkColors.Text = "Lista de Cores";
            this.checkColors.UseVisualStyleBackColor = true;
            this.checkColors.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // wordsColoredList
            // 
            this.wordsColoredList.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordsColoredList.FullRowSelect = true;
            this.wordsColoredList.LabelEdit = true;
            this.wordsColoredList.Location = new System.Drawing.Point(479, 32);
            this.wordsColoredList.Name = "wordsColoredList";
            this.wordsColoredList.Size = new System.Drawing.Size(267, 504);
            this.wordsColoredList.TabIndex = 22;
            this.wordsColoredList.TabStop = false;
            this.wordsColoredList.TileSize = new System.Drawing.Size(200, 60);
            this.wordsColoredList.UseCompatibleStateImageBehavior = false;
            this.wordsColoredList.View = System.Windows.Forms.View.Tile;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Location = new System.Drawing.Point(12, 541);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 24;
            this.button3.TabStop = false;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Location = new System.Drawing.Point(107, 541);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(366, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Lista Cores Hex";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(649, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Lista Palavras";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 22);
            this.textBox1.TabIndex = 27;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Nome Lista(s):";
            // 
            // wordsListName
            // 
            this.wordsListName.AutoSize = true;
            this.wordsListName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.wordsListName.Location = new System.Drawing.Point(476, 12);
            this.wordsListName.Name = "wordsListName";
            this.wordsListName.Size = new System.Drawing.Size(128, 17);
            this.wordsListName.TabIndex = 29;
            this.wordsListName.Text = "nomeListaPalavras";
            // 
            // colorsListName
            // 
            this.colorsListName.AutoSize = true;
            this.colorsListName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.colorsListName.Location = new System.Drawing.Point(203, 12);
            this.colorsListName.Name = "colorsListName";
            this.colorsListName.Size = new System.Drawing.Size(110, 17);
            this.colorsListName.TabIndex = 30;
            this.colorsListName.Text = "nomeListaCores";
            // 
            // FormLstConfig
            // 
            this.AcceptButton = this.buttonInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 575);
            this.Controls.Add(this.colorsListName);
            this.Controls.Add(this.wordsListName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.wordsColoredList);
            this.Controls.Add(this.checkColors);
            this.Controls.Add(this.checkWords);
            this.Controls.Add(this.textWords);
            this.Controls.Add(this.hexColorsList);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.textHexColor);
            this.Controls.Add(this.buttonColorPallette);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLstConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonColorPallette;
        private System.Windows.Forms.TextBox textHexColor;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.ListView hexColorsList;
        private System.Windows.Forms.TextBox textWords;
        private System.Windows.Forms.CheckBox checkWords;
        private System.Windows.Forms.CheckBox checkColors;
        private System.Windows.Forms.ListView wordsColoredList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label wordsListName;
        private System.Windows.Forms.Label colorsListName;
    }
}