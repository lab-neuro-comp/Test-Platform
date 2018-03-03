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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWordColorConfig));
            this.listNameTextBox = new System.Windows.Forms.TextBox();
            this.listNameLabel = new System.Windows.Forms.Label();
            this.wordsListCheckBox = new System.Windows.Forms.CheckBox();
            this.colorsListCheckBox = new System.Windows.Forms.CheckBox();
            this.newTextButton = new System.Windows.Forms.Button();
            this.numberItensWord = new System.Windows.Forms.Label();
            this.numberItensWordLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.labelEmpty = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorListView = new System.Windows.Forms.ListView();
            this.numberItensColor = new System.Windows.Forms.Label();
            this.numberItensColorLabel = new System.Windows.Forms.Label();
            this.wordItemTextBox = new System.Windows.Forms.TextBox();
            this.newColorButton = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.downColorItem = new System.Windows.Forms.Button();
            this.upColorItem = new System.Windows.Forms.Button();
            this.deleteColorItem = new System.Windows.Forms.Button();
            this.colorItemTextBox = new System.Windows.Forms.TextBox();
            this.wordListView = new System.Windows.Forms.ListView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.downWordItem = new System.Windows.Forms.Button();
            this.upWordItem = new System.Windows.Forms.Button();
            this.deleteWordItem = new System.Windows.Forms.Button();
            this.colorListGroupBox = new System.Windows.Forms.GroupBox();
            this.colorListEmpty = new System.Windows.Forms.Label();
            this.wordGroupBox = new System.Windows.Forms.GroupBox();
            this.wordListEmpty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.colorListGroupBox.SuspendLayout();
            this.wordGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listNameTextBox
            // 
            resources.ApplyResources(this.listNameTextBox, "listNameTextBox");
            this.listNameTextBox.Name = "listNameTextBox";
            this.listNameTextBox.TextChanged += new System.EventHandler(this.listNameTextBox_TextChanged);
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
            // newTextButton
            // 
            resources.ApplyResources(this.newTextButton, "newTextButton");
            this.newTextButton.CausesValidation = false;
            this.newTextButton.Name = "newTextButton";
            this.newTextButton.UseVisualStyleBackColor = true;
            this.newTextButton.Click += new System.EventHandler(this.newWordItemButton_Click);
            // 
            // numberItensWord
            // 
            resources.ApplyResources(this.numberItensWord, "numberItensWord");
            this.numberItensWord.Name = "numberItensWord";
            // 
            // numberItensWordLabel
            // 
            resources.ApplyResources(this.numberItensWordLabel, "numberItensWordLabel");
            this.numberItensWordLabel.Name = "numberItensWordLabel";
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
            // colorListView
            // 
            resources.ApplyResources(this.colorListView, "colorListView");
            this.colorListView.FullRowSelect = true;
            this.colorListView.Name = "colorListView";
            this.colorListView.TabStop = false;
            this.colorListView.TileSize = new System.Drawing.Size(120, 40);
            this.colorListView.UseCompatibleStateImageBehavior = false;
            this.colorListView.View = System.Windows.Forms.View.Tile;
            this.colorListView.Validating += new System.ComponentModel.CancelEventHandler(this.colorsListLength_Validating);
            this.colorListView.Validated += new System.EventHandler(this.colorsListLength_Validated);
            // 
            // numberItensColor
            // 
            resources.ApplyResources(this.numberItensColor, "numberItensColor");
            this.numberItensColor.Name = "numberItensColor";
            // 
            // numberItensColorLabel
            // 
            resources.ApplyResources(this.numberItensColorLabel, "numberItensColorLabel");
            this.numberItensColorLabel.Name = "numberItensColorLabel";
            // 
            // wordItemTextBox
            // 
            resources.ApplyResources(this.wordItemTextBox, "wordItemTextBox");
            this.wordItemTextBox.Name = "wordItemTextBox";
            // 
            // newColorButton
            // 
            resources.ApplyResources(this.newColorButton, "newColorButton");
            this.newColorButton.CausesValidation = false;
            this.newColorButton.Name = "newColorButton";
            this.newColorButton.UseVisualStyleBackColor = true;
            this.newColorButton.Click += new System.EventHandler(this.newColorButton_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.colorPanel, "colorPanel");
            this.colorPanel.Name = "colorPanel";
            // 
            // chooseColorButton
            // 
            resources.ApplyResources(this.chooseColorButton, "chooseColorButton");
            this.chooseColorButton.CausesValidation = false;
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.chooseColorButton_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // downColorItem
            // 
            resources.ApplyResources(this.downColorItem, "downColorItem");
            this.downColorItem.Image = global::TestPlatform.Properties.Resources.arrowDown;
            this.downColorItem.Name = "downColorItem";
            this.downColorItem.UseVisualStyleBackColor = true;
            this.downColorItem.Click += new System.EventHandler(this.downColorItem_Click);
            // 
            // upColorItem
            // 
            resources.ApplyResources(this.upColorItem, "upColorItem");
            this.upColorItem.Image = global::TestPlatform.Properties.Resources.arrowUp;
            this.upColorItem.Name = "upColorItem";
            this.upColorItem.UseVisualStyleBackColor = true;
            this.upColorItem.Click += new System.EventHandler(this.upColorItem_Click);
            // 
            // deleteColorItem
            // 
            resources.ApplyResources(this.deleteColorItem, "deleteColorItem");
            this.deleteColorItem.Name = "deleteColorItem";
            this.deleteColorItem.UseVisualStyleBackColor = true;
            this.deleteColorItem.Click += new System.EventHandler(this.deleteColorItem_Click);
            // 
            // colorItemTextBox
            // 
            resources.ApplyResources(this.colorItemTextBox, "colorItemTextBox");
            this.colorItemTextBox.Name = "colorItemTextBox";
            // 
            // wordListView
            // 
            resources.ApplyResources(this.wordListView, "wordListView");
            this.wordListView.FullRowSelect = true;
            this.wordListView.Name = "wordListView";
            this.wordListView.TabStop = false;
            this.wordListView.TileSize = new System.Drawing.Size(120, 40);
            this.wordListView.UseCompatibleStateImageBehavior = false;
            this.wordListView.View = System.Windows.Forms.View.Tile;
            this.wordListView.Validating += new System.ComponentModel.CancelEventHandler(this.wordsListLength_Validating);
            this.wordListView.Validated += new System.EventHandler(this.wordsListLength_Validated);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // downWordItem
            // 
            resources.ApplyResources(this.downWordItem, "downWordItem");
            this.downWordItem.Image = global::TestPlatform.Properties.Resources.arrowDown;
            this.downWordItem.Name = "downWordItem";
            this.downWordItem.UseVisualStyleBackColor = true;
            this.downWordItem.Click += new System.EventHandler(this.downWordItem_Click);
            // 
            // upWordItem
            // 
            resources.ApplyResources(this.upWordItem, "upWordItem");
            this.upWordItem.Image = global::TestPlatform.Properties.Resources.arrowUp;
            this.upWordItem.Name = "upWordItem";
            this.upWordItem.UseVisualStyleBackColor = true;
            this.upWordItem.Click += new System.EventHandler(this.upWordItem_Click);
            // 
            // deleteWordItem
            // 
            resources.ApplyResources(this.deleteWordItem, "deleteWordItem");
            this.deleteWordItem.Name = "deleteWordItem";
            this.deleteWordItem.UseVisualStyleBackColor = true;
            this.deleteWordItem.Click += new System.EventHandler(this.deleteWordItem_Click);
            // 
            // colorListGroupBox
            // 
            this.colorListGroupBox.Controls.Add(this.colorListEmpty);
            this.colorListGroupBox.Controls.Add(this.colorListView);
            this.colorListGroupBox.Controls.Add(this.numberItensColorLabel);
            this.colorListGroupBox.Controls.Add(this.numberItensColor);
            this.colorListGroupBox.Controls.Add(this.newColorButton);
            this.colorListGroupBox.Controls.Add(this.colorPanel);
            this.colorListGroupBox.Controls.Add(this.chooseColorButton);
            this.colorListGroupBox.Controls.Add(this.colorItemTextBox);
            this.colorListGroupBox.Controls.Add(this.deleteColorItem);
            this.colorListGroupBox.Controls.Add(this.label4);
            this.colorListGroupBox.Controls.Add(this.upColorItem);
            this.colorListGroupBox.Controls.Add(this.downColorItem);
            resources.ApplyResources(this.colorListGroupBox, "colorListGroupBox");
            this.colorListGroupBox.Name = "colorListGroupBox";
            this.colorListGroupBox.TabStop = false;
            // 
            // colorListEmpty
            // 
            resources.ApplyResources(this.colorListEmpty, "colorListEmpty");
            this.colorListEmpty.ForeColor = System.Drawing.Color.Red;
            this.colorListEmpty.Name = "colorListEmpty";
            // 
            // wordGroupBox
            // 
            this.wordGroupBox.Controls.Add(this.wordListEmpty);
            this.wordGroupBox.Controls.Add(this.wordListView);
            this.wordGroupBox.Controls.Add(this.label3);
            this.wordGroupBox.Controls.Add(this.downWordItem);
            this.wordGroupBox.Controls.Add(this.newTextButton);
            this.wordGroupBox.Controls.Add(this.upWordItem);
            this.wordGroupBox.Controls.Add(this.numberItensWordLabel);
            this.wordGroupBox.Controls.Add(this.deleteWordItem);
            this.wordGroupBox.Controls.Add(this.numberItensWord);
            this.wordGroupBox.Controls.Add(this.wordItemTextBox);
            resources.ApplyResources(this.wordGroupBox, "wordGroupBox");
            this.wordGroupBox.Name = "wordGroupBox";
            this.wordGroupBox.TabStop = false;
            // 
            // wordListEmpty
            // 
            resources.ApplyResources(this.wordListEmpty, "wordListEmpty");
            this.wordListEmpty.ForeColor = System.Drawing.Color.Red;
            this.wordListEmpty.Name = "wordListEmpty";
            // 
            // FormWordColorConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.wordGroupBox);
            this.Controls.Add(this.colorsListCheckBox);
            this.Controls.Add(this.colorListGroupBox);
            this.Controls.Add(this.wordsListCheckBox);
            this.Controls.Add(this.labelEmpty);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.listNameLabel);
            this.Controls.Add(this.listNameTextBox);
            this.Name = "FormWordColorConfig";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.colorListGroupBox.ResumeLayout(false);
            this.colorListGroupBox.PerformLayout();
            this.wordGroupBox.ResumeLayout(false);
            this.wordGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox listNameTextBox;
        private System.Windows.Forms.Label listNameLabel;
        private System.Windows.Forms.CheckBox wordsListCheckBox;
        private System.Windows.Forms.CheckBox colorsListCheckBox;
        private System.Windows.Forms.Button newTextButton;
        private System.Windows.Forms.Label numberItensWord;
        private System.Windows.Forms.Label numberItensWordLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label labelEmpty;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label numberItensColor;
        private System.Windows.Forms.Label numberItensColorLabel;
        private System.Windows.Forms.ListView colorListView;
        private System.Windows.Forms.TextBox wordItemTextBox;
        private System.Windows.Forms.Button newColorButton;
        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button downColorItem;
        private System.Windows.Forms.Button upColorItem;
        private System.Windows.Forms.Button deleteColorItem;
        private System.Windows.Forms.TextBox colorItemTextBox;
        private System.Windows.Forms.ListView wordListView;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button downWordItem;
        private System.Windows.Forms.Button upWordItem;
        private System.Windows.Forms.Button deleteWordItem;
        private System.Windows.Forms.GroupBox colorListGroupBox;
        private System.Windows.Forms.GroupBox wordGroupBox;
        private System.Windows.Forms.Label wordListEmpty;
        private System.Windows.Forms.Label colorListEmpty;
    }
}