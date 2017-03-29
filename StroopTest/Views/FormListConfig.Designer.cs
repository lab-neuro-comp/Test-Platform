namespace StroopTest
{
    partial class FormListConfig
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
            this.buttonColorPallette = new System.Windows.Forms.Button();
            this.hexColorTextBox = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.hexColorsList = new System.Windows.Forms.ListView();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.checkWords = new System.Windows.Forms.CheckBox();
            this.checkColors = new System.Windows.Forms.CheckBox();
            this.wordsColoredList = new System.Windows.Forms.ListView();
            this.colorListLabel = new System.Windows.Forms.Label();
            this.wordListLabel = new System.Windows.Forms.Label();
            this.listNameTextBox = new System.Windows.Forms.TextBox();
            this.listNameLabel = new System.Windows.Forms.Label();
            this.wordsListLabel = new System.Windows.Forms.Label();
            this.colorsListLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelEmpty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonColorPallette
            // 
            this.buttonColorPallette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonColorPallette.Location = new System.Drawing.Point(12, 217);
            this.buttonColorPallette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonColorPallette.Name = "buttonColorPallette";
            this.buttonColorPallette.Size = new System.Drawing.Size(171, 23);
            this.buttonColorPallette.TabIndex = 3;
            this.buttonColorPallette.Text = " cores";
            this.buttonColorPallette.UseVisualStyleBackColor = true;
            this.buttonColorPallette.Click += new System.EventHandler(this.buttonColors_Click);
            // 
            // hexColorTextBox
            // 
            this.hexColorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.hexColorTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hexColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexColorTextBox.Location = new System.Drawing.Point(12, 167);
            this.hexColorTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hexColorTextBox.MaxLength = 7;
            this.hexColorTextBox.Name = "hexColorTextBox";
            this.hexColorTextBox.Size = new System.Drawing.Size(169, 45);
            this.hexColorTextBox.TabIndex = 2;
            this.hexColorTextBox.Text = "#000000";
            this.hexColorTextBox.TextChanged += new System.EventHandler(this.colorTextBox_TextChanged);
            this.hexColorTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.colorName_Validating);
            this.hexColorTextBox.Validated += new System.EventHandler(this.colorName_Validated);
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(100, 245);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(83, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.TabStop = false;
            this.buttonRemove.Text = "-";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.Location = new System.Drawing.Point(12, 245);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(83, 23);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.TabStop = false;
            this.buttonInsert.Text = "+";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            this.buttonInsert.Validating += new System.ComponentModel.CancelEventHandler(this.colorName_Validating);
            this.buttonInsert.Validated += new System.EventHandler(this.colorName_Validated);
            // 
            // hexColorsList
            // 
            this.hexColorsList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.hexColorsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hexColorsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexColorsList.FullRowSelect = true;
            this.hexColorsList.LabelEdit = true;
            this.hexColorsList.Location = new System.Drawing.Point(213, 32);
            this.hexColorsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hexColorsList.Name = "hexColorsList";
            this.hexColorsList.Size = new System.Drawing.Size(212, 491);
            this.hexColorsList.TabIndex = 17;
            this.hexColorsList.TabStop = false;
            this.hexColorsList.TileSize = new System.Drawing.Size(120, 40);
            this.hexColorsList.UseCompatibleStateImageBehavior = false;
            this.hexColorsList.View = System.Windows.Forms.View.Tile;
            this.hexColorsList.Validating += new System.ComponentModel.CancelEventHandler(this.hexColorList_Validating);
            this.hexColorsList.Validated += new System.EventHandler(this.listLength_Validated);
            // 
            // wordTextBox
            // 
            this.wordTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.wordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordTextBox.Location = new System.Drawing.Point(12, 90);
            this.wordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(169, 45);
            this.wordTextBox.TabIndex = 1;
            // 
            // checkWords
            // 
            this.checkWords.AutoSize = true;
            this.checkWords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkWords.Location = new System.Drawing.Point(12, 64);
            this.checkWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkWords.Name = "checkWords";
            this.checkWords.Size = new System.Drawing.Size(136, 21);
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
            this.checkColors.Location = new System.Drawing.Point(12, 142);
            this.checkColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkColors.Name = "checkColors";
            this.checkColors.Size = new System.Drawing.Size(118, 21);
            this.checkColors.TabIndex = 21;
            this.checkColors.TabStop = false;
            this.checkColors.Text = "Lista de Cores";
            this.checkColors.UseVisualStyleBackColor = true;
            this.checkColors.CheckedChanged += new System.EventHandler(this.colorsCheck_CheckedChanged);
            // 
            // wordsColoredList
            // 
            this.wordsColoredList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.wordsColoredList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wordsColoredList.AutoArrange = false;
            this.wordsColoredList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordsColoredList.FullRowSelect = true;
            this.wordsColoredList.LabelEdit = true;
            this.wordsColoredList.Location = new System.Drawing.Point(432, 32);
            this.wordsColoredList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wordsColoredList.Name = "wordsColoredList";
            this.wordsColoredList.Size = new System.Drawing.Size(212, 491);
            this.wordsColoredList.TabIndex = 22;
            this.wordsColoredList.TabStop = false;
            this.wordsColoredList.TileSize = new System.Drawing.Size(120, 40);
            this.wordsColoredList.UseCompatibleStateImageBehavior = false;
            this.wordsColoredList.View = System.Windows.Forms.View.Tile;
            this.wordsColoredList.Validating += new System.ComponentModel.CancelEventHandler(this.wordList_Validating);
            this.wordsColoredList.Validated += new System.EventHandler(this.listLength_Validated);
            // 
            // colorListLabel
            // 
            this.colorListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorListLabel.AutoSize = true;
            this.colorListLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.colorListLabel.Location = new System.Drawing.Point(311, 527);
            this.colorListLabel.Name = "colorListLabel";
            this.colorListLabel.Size = new System.Drawing.Size(99, 17);
            this.colorListLabel.TabIndex = 25;
            this.colorListLabel.Text = "Lista de Cores";
            // 
            // wordListLabel
            // 
            this.wordListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordListLabel.AutoSize = true;
            this.wordListLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.wordListLabel.Location = new System.Drawing.Point(516, 527);
            this.wordListLabel.Name = "wordListLabel";
            this.wordListLabel.Size = new System.Drawing.Size(117, 17);
            this.wordListLabel.TabIndex = 26;
            this.wordListLabel.Text = "Lista de Palavras";
            // 
            // listNameTextBox
            // 
            this.listNameTextBox.Location = new System.Drawing.Point(12, 33);
            this.listNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listNameTextBox.Name = "listNameTextBox";
            this.listNameTextBox.Size = new System.Drawing.Size(169, 22);
            this.listNameTextBox.TabIndex = 27;
            this.listNameTextBox.TextChanged += new System.EventHandler(this.listNameBox_TextChanged);
            this.listNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.listName_Validating);
            this.listNameTextBox.Validated += new System.EventHandler(this.listName_Validated);
            // 
            // listNameLabel
            // 
            this.listNameLabel.AutoSize = true;
            this.listNameLabel.Location = new System.Drawing.Point(12, 12);
            this.listNameLabel.Name = "listNameLabel";
            this.listNameLabel.Size = new System.Drawing.Size(103, 17);
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
            this.wordsListLabel.Location = new System.Drawing.Point(434, 12);
            this.wordsListLabel.Name = "wordsListLabel";
            this.wordsListLabel.Size = new System.Drawing.Size(128, 17);
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
            this.colorsListLabel.Location = new System.Drawing.Point(216, 12);
            this.colorsListLabel.Name = "colorsListLabel";
            this.colorsListLabel.Size = new System.Drawing.Size(110, 17);
            this.colorsListLabel.TabIndex = 30;
            this.colorsListLabel.Text = "nomeListaCores";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(16, 562);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 31;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(591, 562);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.Location = new System.Drawing.Point(656, 12);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 32);
            this.helpButton.TabIndex = 83;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // labelEmpty
            // 
            this.labelEmpty.AutoSize = true;
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Location = new System.Drawing.Point(9, 299);
            this.labelEmpty.Name = "labelEmpty";
            this.labelEmpty.Size = new System.Drawing.Size(77, 17);
            this.labelEmpty.TabIndex = 84;
            this.labelEmpty.Text = "labelEmpty";
            this.labelEmpty.Visible = false;
            // 
            // FormListConfig
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(701, 606);
            this.Controls.Add(this.labelEmpty);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.colorsListLabel);
            this.Controls.Add(this.wordsListLabel);
            this.Controls.Add(this.listNameLabel);
            this.Controls.Add(this.listNameTextBox);
            this.Controls.Add(this.wordListLabel);
            this.Controls.Add(this.colorListLabel);
            this.Controls.Add(this.wordsColoredList);
            this.Controls.Add(this.checkColors);
            this.Controls.Add(this.checkWords);
            this.Controls.Add(this.wordTextBox);
            this.Controls.Add(this.hexColorsList);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.hexColorTextBox);
            this.Controls.Add(this.buttonColorPallette);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormListConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listas - Palavras e Cores";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.Label colorListLabel;
        private System.Windows.Forms.Label wordListLabel;
        private System.Windows.Forms.TextBox listNameTextBox;
        private System.Windows.Forms.Label listNameLabel;
        private System.Windows.Forms.Label wordsListLabel;
        private System.Windows.Forms.Label colorsListLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelEmpty;
    }
}