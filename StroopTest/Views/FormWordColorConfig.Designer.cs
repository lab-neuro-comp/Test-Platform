namespace StroopTest
{
    partial class FormWordColorConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWordColorConfig));
            this.wordsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listNameTextBox = new System.Windows.Forms.TextBox();
            this.listNameLabel = new System.Windows.Forms.Label();
            this.wordsListCheckBox = new System.Windows.Forms.CheckBox();
            this.colorsListCheckBox = new System.Windows.Forms.CheckBox();
            this.newItemButton = new System.Windows.Forms.Button();
            this.deleteItemLabel = new System.Windows.Forms.Label();
            this.moveRowLabel = new System.Windows.Forms.Label();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.numberItens = new System.Windows.Forms.Label();
            this.numberItensLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.labelEmpty = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // wordsDataGridView
            // 
            this.wordsDataGridView.AllowUserToAddRows = false;
            this.wordsDataGridView.AllowUserToDeleteRows = false;
            this.wordsDataGridView.AllowUserToResizeColumns = false;
            this.wordsDataGridView.AllowUserToResizeRows = false;
            this.wordsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.wordsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.wordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.wordsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.wordsDataGridView.Location = new System.Drawing.Point(201, 52);
            this.wordsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.wordsDataGridView.Name = "wordsDataGridView";
            this.wordsDataGridView.ReadOnly = true;
            this.wordsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.wordsDataGridView.RowHeadersVisible = false;
            this.wordsDataGridView.Size = new System.Drawing.Size(457, 519);
            this.wordsDataGridView.TabIndex = 0;
            this.wordsDataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.listLength_Validating);
            this.wordsDataGridView.Validated += new System.EventHandler(this.listLength_Validated);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Lista de Estímulos";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // listNameTextBox
            // 
            this.listNameTextBox.Location = new System.Drawing.Point(120, 15);
            this.listNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.listNameTextBox.Name = "listNameTextBox";
            this.listNameTextBox.Size = new System.Drawing.Size(180, 22);
            this.listNameTextBox.TabIndex = 5;
            this.listNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.listName_Validating);
            this.listNameTextBox.Validated += new System.EventHandler(this.listName_Validated);
            // 
            // listNameLabel
            // 
            this.listNameLabel.AutoSize = true;
            this.listNameLabel.Location = new System.Drawing.Point(8, 18);
            this.listNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.listNameLabel.Name = "listNameLabel";
            this.listNameLabel.Size = new System.Drawing.Size(103, 17);
            this.listNameLabel.TabIndex = 6;
            this.listNameLabel.Text = "Nome da Lista:";
            // 
            // wordsListCheckBox
            // 
            this.wordsListCheckBox.AutoSize = true;
            this.wordsListCheckBox.Location = new System.Drawing.Point(327, 17);
            this.wordsListCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.wordsListCheckBox.Name = "wordsListCheckBox";
            this.wordsListCheckBox.Size = new System.Drawing.Size(139, 21);
            this.wordsListCheckBox.TabIndex = 7;
            this.wordsListCheckBox.Text = "Lista de Palavras";
            this.wordsListCheckBox.UseVisualStyleBackColor = true;
            this.wordsListCheckBox.CheckedChanged += new System.EventHandler(this.wordsListCheckBox_CheckedChanged);
            // 
            // colorsListCheckBox
            // 
            this.colorsListCheckBox.AutoSize = true;
            this.colorsListCheckBox.Location = new System.Drawing.Point(492, 17);
            this.colorsListCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.colorsListCheckBox.Name = "colorsListCheckBox";
            this.colorsListCheckBox.Size = new System.Drawing.Size(121, 21);
            this.colorsListCheckBox.TabIndex = 9;
            this.colorsListCheckBox.Text = "Lista de Cores";
            this.colorsListCheckBox.UseVisualStyleBackColor = true;
            this.colorsListCheckBox.CheckedChanged += new System.EventHandler(this.colorsListCheckBox_CheckedChanged);
            // 
            // newItemButton
            // 
            this.newItemButton.CausesValidation = false;
            this.newItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newItemButton.Location = new System.Drawing.Point(12, 52);
            this.newItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.newItemButton.Name = "newItemButton";
            this.newItemButton.Size = new System.Drawing.Size(181, 28);
            this.newItemButton.TabIndex = 10;
            this.newItemButton.Text = "Novo Item";
            this.newItemButton.UseVisualStyleBackColor = true;
            this.newItemButton.Click += new System.EventHandler(this.newItemButton_Click);
            // 
            // deleteItemLabel
            // 
            this.deleteItemLabel.AutoSize = true;
            this.deleteItemLabel.Location = new System.Drawing.Point(12, 84);
            this.deleteItemLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.deleteItemLabel.Name = "deleteItemLabel";
            this.deleteItemLabel.Size = new System.Drawing.Size(88, 17);
            this.deleteItemLabel.TabIndex = 59;
            this.deleteItemLabel.Text = "Apagar Item:";
            // 
            // moveRowLabel
            // 
            this.moveRowLabel.AutoSize = true;
            this.moveRowLabel.Location = new System.Drawing.Point(12, 135);
            this.moveRowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moveRowLabel.Name = "moveRowLabel";
            this.moveRowLabel.Size = new System.Drawing.Size(81, 17);
            this.moveRowLabel.TabIndex = 58;
            this.moveRowLabel.Text = "Mover item:";
            // 
            // moveDownButton
            // 
            this.moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveDownButton.Location = new System.Drawing.Point(12, 191);
            this.moveDownButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(181, 28);
            this.moveDownButton.TabIndex = 57;
            this.moveDownButton.Text = "Abaixo";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveUpButton.Location = new System.Drawing.Point(12, 155);
            this.moveUpButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(181, 28);
            this.moveUpButton.TabIndex = 56;
            this.moveUpButton.Text = "Acima";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteButton.Location = new System.Drawing.Point(12, 103);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(181, 28);
            this.deleteButton.TabIndex = 55;
            this.deleteButton.Text = "Apagar";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // numberItens
            // 
            this.numberItens.AutoSize = true;
            this.numberItens.Location = new System.Drawing.Point(173, 234);
            this.numberItens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberItens.Name = "numberItens";
            this.numberItens.Size = new System.Drawing.Size(16, 17);
            this.numberItens.TabIndex = 61;
            this.numberItens.Text = "0";
            // 
            // numberItensLabel
            // 
            this.numberItensLabel.AutoSize = true;
            this.numberItensLabel.Location = new System.Drawing.Point(16, 234);
            this.numberItensLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberItensLabel.Name = "numberItensLabel";
            this.numberItensLabel.Size = new System.Drawing.Size(96, 17);
            this.numberItensLabel.TabIndex = 60;
            this.numberItensLabel.Text = "Itens na Lista:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(559, 581);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 63;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Location = new System.Drawing.Point(16, 581);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 62;
            this.saveButton.Text = "salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::StroopTest.Properties.Resources.helpButton;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.helpButton.Location = new System.Drawing.Point(623, 14);
            this.helpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 32);
            this.helpButton.TabIndex = 82;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // labelEmpty
            // 
            this.labelEmpty.AutoSize = true;
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Location = new System.Drawing.Point(6, 267);
            this.labelEmpty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmpty.Name = "labelEmpty";
            this.labelEmpty.Size = new System.Drawing.Size(0, 17);
            this.labelEmpty.TabIndex = 83;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormWordColorConfig
            // 
            this.AcceptButton = this.newItemButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 624);
            this.Controls.Add(this.labelEmpty);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.numberItens);
            this.Controls.Add(this.numberItensLabel);
            this.Controls.Add(this.deleteItemLabel);
            this.Controls.Add(this.moveRowLabel);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newItemButton);
            this.Controls.Add(this.colorsListCheckBox);
            this.Controls.Add(this.wordsListCheckBox);
            this.Controls.Add(this.listNameLabel);
            this.Controls.Add(this.listNameTextBox);
            this.Controls.Add(this.wordsDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormWordColorConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista - Palavras e Cores";
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView wordsDataGridView;
        private System.Windows.Forms.TextBox listNameTextBox;
        private System.Windows.Forms.Label listNameLabel;
        private System.Windows.Forms.CheckBox wordsListCheckBox;
        private System.Windows.Forms.CheckBox colorsListCheckBox;
        private System.Windows.Forms.Button newItemButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label deleteItemLabel;
        private System.Windows.Forms.Label moveRowLabel;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label numberItens;
        private System.Windows.Forms.Label numberItensLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label labelEmpty;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}