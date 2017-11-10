namespace TestPlatform
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
            resources.ApplyResources(this.wordsDataGridView, "wordsDataGridView");
            this.wordsDataGridView.Name = "wordsDataGridView";
            this.wordsDataGridView.ReadOnly = true;
            this.wordsDataGridView.RowHeadersVisible = false;
            this.wordsDataGridView.Validating += new System.ComponentModel.CancelEventHandler(this.listLength_Validating);
            this.wordsDataGridView.Validated += new System.EventHandler(this.listLength_Validated);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // listNameTextBox
            // 
            resources.ApplyResources(this.listNameTextBox, "listNameTextBox");
            this.listNameTextBox.Name = "listNameTextBox";
            this.listNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.listName_Validating);
            this.listNameTextBox.Validated += new System.EventHandler(this.listName_Validated);
            // 
            // listNameLabel
            // 
            resources.ApplyResources(this.listNameLabel, "listNameLabel");
            this.listNameLabel.Name = "listNameLabel";
            // 
            // wordsListCheckBox
            // 
            resources.ApplyResources(this.wordsListCheckBox, "wordsListCheckBox");
            this.wordsListCheckBox.Name = "wordsListCheckBox";
            this.wordsListCheckBox.UseVisualStyleBackColor = true;
            this.wordsListCheckBox.CheckedChanged += new System.EventHandler(this.wordsListCheckBox_CheckedChanged);
            // 
            // colorsListCheckBox
            // 
            resources.ApplyResources(this.colorsListCheckBox, "colorsListCheckBox");
            this.colorsListCheckBox.Name = "colorsListCheckBox";
            this.colorsListCheckBox.UseVisualStyleBackColor = true;
            this.colorsListCheckBox.CheckedChanged += new System.EventHandler(this.colorsListCheckBox_CheckedChanged);
            // 
            // newItemButton
            // 
            resources.ApplyResources(this.newItemButton, "newItemButton");
            this.newItemButton.CausesValidation = false;
            this.newItemButton.Name = "newItemButton";
            this.newItemButton.UseVisualStyleBackColor = true;
            this.newItemButton.Click += new System.EventHandler(this.newItemButton_Click);
            // 
            // deleteItemLabel
            // 
            resources.ApplyResources(this.deleteItemLabel, "deleteItemLabel");
            this.deleteItemLabel.Name = "deleteItemLabel";
            // 
            // moveRowLabel
            // 
            resources.ApplyResources(this.moveRowLabel, "moveRowLabel");
            this.moveRowLabel.Name = "moveRowLabel";
            // 
            // moveDownButton
            // 
            resources.ApplyResources(this.moveDownButton, "moveDownButton");
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            resources.ApplyResources(this.moveUpButton, "moveUpButton");
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // numberItens
            // 
            resources.ApplyResources(this.numberItens, "numberItens");
            this.numberItens.Name = "numberItens";
            // 
            // numberItensLabel
            // 
            resources.ApplyResources(this.numberItensLabel, "numberItensLabel");
            this.numberItensLabel.Name = "numberItensLabel";
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // helpButton
            // 
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.helpButton.BackgroundImage = global::TestPlatform.Properties.Resources.helpButton;
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // labelEmpty
            // 
            resources.ApplyResources(this.labelEmpty, "labelEmpty");
            this.labelEmpty.ForeColor = System.Drawing.Color.Red;
            this.labelEmpty.Name = "labelEmpty";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // FormWordColorConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
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
            this.Name = "FormWordColorConfig";
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