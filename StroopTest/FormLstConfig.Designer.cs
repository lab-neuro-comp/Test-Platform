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
            this.hexColorTextBox = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.hexColorsList = new System.Windows.Forms.ListView();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.checkWords = new System.Windows.Forms.CheckBox();
            this.checkColors = new System.Windows.Forms.CheckBox();
            this.wordsColoredList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listNameTextBox = new System.Windows.Forms.TextBox();
            this.listNameLabel = new System.Windows.Forms.Label();
            this.wordsListLabel = new System.Windows.Forms.Label();
            this.colorsListLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonColorPallette
            // 
            this.buttonColorPallette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonColorPallette.Location = new System.Drawing.Point(9, 176);
            this.buttonColorPallette.Margin = new System.Windows.Forms.Padding(2);
            this.buttonColorPallette.Name = "buttonColorPallette";
            this.buttonColorPallette.Size = new System.Drawing.Size(128, 19);
            this.buttonColorPallette.TabIndex = 3;
            this.buttonColorPallette.Text = " cores";
            this.buttonColorPallette.UseVisualStyleBackColor = true;
            this.buttonColorPallette.Click += new System.EventHandler(this.button2_Click);
            // 
            // hexColorTextBox
            // 
            this.hexColorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hexColorTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hexColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexColorTextBox.Location = new System.Drawing.Point(9, 136);
            this.hexColorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.hexColorTextBox.MaxLength = 7;
            this.hexColorTextBox.Name = "hexColorTextBox";
            this.hexColorTextBox.Size = new System.Drawing.Size(128, 38);
            this.hexColorTextBox.TabIndex = 2;
            this.hexColorTextBox.Text = "#000000";
            this.hexColorTextBox.TextChanged += new System.EventHandler(this.colorTextBox_TextChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(75, 199);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(62, 19);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.TabStop = false;
            this.buttonRemove.Text = "-";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(9, 199);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(62, 19);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.TabStop = false;
            this.buttonInsert.Text = "+";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.button3_Click);
            // 
            // hexColorsList
            // 
            this.hexColorsList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.hexColorsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexColorsList.FullRowSelect = true;
            this.hexColorsList.LabelEdit = true;
            this.hexColorsList.Location = new System.Drawing.Point(154, 26);
            this.hexColorsList.Margin = new System.Windows.Forms.Padding(2);
            this.hexColorsList.Name = "hexColorsList";
            this.hexColorsList.Size = new System.Drawing.Size(160, 400);
            this.hexColorsList.TabIndex = 17;
            this.hexColorsList.TabStop = false;
            this.hexColorsList.TileSize = new System.Drawing.Size(120, 40);
            this.hexColorsList.UseCompatibleStateImageBehavior = false;
            this.hexColorsList.View = System.Windows.Forms.View.Tile;
            this.hexColorsList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.hexColorsList_ItemSelectionChanged);
            // 
            // wordTextBox
            // 
            this.wordTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.wordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordTextBox.Location = new System.Drawing.Point(9, 73);
            this.wordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(128, 38);
            this.wordTextBox.TabIndex = 1;
            // 
            // checkWords
            // 
            this.checkWords.AutoSize = true;
            this.checkWords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkWords.Location = new System.Drawing.Point(9, 52);
            this.checkWords.Margin = new System.Windows.Forms.Padding(2);
            this.checkWords.Name = "checkWords";
            this.checkWords.Size = new System.Drawing.Size(105, 17);
            this.checkWords.TabIndex = 20;
            this.checkWords.TabStop = false;
            this.checkWords.Text = "Lista de Palavras";
            this.checkWords.UseVisualStyleBackColor = true;
            this.checkWords.CheckedChanged += new System.EventHandler(this.wordsCheck_CheckedChanged);
            // 
            // checkColors
            // 
            this.checkColors.AutoSize = true;
            this.checkColors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkColors.Location = new System.Drawing.Point(9, 115);
            this.checkColors.Margin = new System.Windows.Forms.Padding(2);
            this.checkColors.Name = "checkColors";
            this.checkColors.Size = new System.Drawing.Size(91, 17);
            this.checkColors.TabIndex = 21;
            this.checkColors.TabStop = false;
            this.checkColors.Text = "Lista de Cores";
            this.checkColors.UseVisualStyleBackColor = true;
            this.checkColors.CheckedChanged += new System.EventHandler(this.colorsCheck_CheckedChanged);
            // 
            // wordsColoredList
            // 
            this.wordsColoredList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.wordsColoredList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordsColoredList.FullRowSelect = true;
            this.wordsColoredList.LabelEdit = true;
            this.wordsColoredList.Location = new System.Drawing.Point(318, 26);
            this.wordsColoredList.Margin = new System.Windows.Forms.Padding(2);
            this.wordsColoredList.Name = "wordsColoredList";
            this.wordsColoredList.Size = new System.Drawing.Size(160, 400);
            this.wordsColoredList.TabIndex = 22;
            this.wordsColoredList.TabStop = false;
            this.wordsColoredList.TileSize = new System.Drawing.Size(120, 40);
            this.wordsColoredList.UseCompatibleStateImageBehavior = false;
            this.wordsColoredList.View = System.Windows.Forms.View.Tile;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(240, 428);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Lista de Cores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(394, 428);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Lista de Palavras";
            // 
            // listNameTextBox
            // 
            this.listNameTextBox.Location = new System.Drawing.Point(9, 27);
            this.listNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.listNameTextBox.Name = "listNameTextBox";
            this.listNameTextBox.Size = new System.Drawing.Size(128, 20);
            this.listNameTextBox.TabIndex = 27;
            this.listNameTextBox.TextChanged += new System.EventHandler(this.listNameBox_TextChanged);
            // 
            // listNameLabel
            // 
            this.listNameLabel.AutoSize = true;
            this.listNameLabel.Location = new System.Drawing.Point(9, 10);
            this.listNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.listNameLabel.Name = "listNameLabel";
            this.listNameLabel.Size = new System.Drawing.Size(78, 13);
            this.listNameLabel.TabIndex = 28;
            this.listNameLabel.Text = "Nome da Lista:";
            // 
            // wordsListLabel
            // 
            this.wordsListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordsListLabel.AutoSize = true;
            this.wordsListLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.wordsListLabel.Location = new System.Drawing.Point(316, 10);
            this.wordsListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wordsListLabel.Name = "wordsListLabel";
            this.wordsListLabel.Size = new System.Drawing.Size(96, 13);
            this.wordsListLabel.TabIndex = 29;
            this.wordsListLabel.Text = "nomeListaPalavras";
            // 
            // colorsListLabel
            // 
            this.colorsListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorsListLabel.AutoSize = true;
            this.colorsListLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.colorsListLabel.Location = new System.Drawing.Point(152, 10);
            this.colorsListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.colorsListLabel.Name = "colorsListLabel";
            this.colorsListLabel.Size = new System.Drawing.Size(82, 13);
            this.colorsListLabel.TabIndex = 30;
            this.colorsListLabel.Text = "nomeListaCores";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(12, 454);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 31;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(407, 454);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // FormLstConfig
            // 
            this.AcceptButton = this.buttonInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 489);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.colorsListLabel);
            this.Controls.Add(this.wordsListLabel);
            this.Controls.Add(this.listNameLabel);
            this.Controls.Add(this.listNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wordsColoredList);
            this.Controls.Add(this.checkColors);
            this.Controls.Add(this.checkWords);
            this.Controls.Add(this.wordTextBox);
            this.Controls.Add(this.hexColorsList);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.hexColorTextBox);
            this.Controls.Add(this.buttonColorPallette);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormLstConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listas - Palavras e Cores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonColorPallette;
        private System.Windows.Forms.TextBox hexColorTextBox;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.ListView hexColorsList;
        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.CheckBox checkWords;
        private System.Windows.Forms.CheckBox checkColors;
        private System.Windows.Forms.ListView wordsColoredList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox listNameTextBox;
        private System.Windows.Forms.Label listNameLabel;
        private System.Windows.Forms.Label wordsListLabel;
        private System.Windows.Forms.Label colorsListLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}