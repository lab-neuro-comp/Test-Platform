namespace TestPlatform.Views.SidebarUserControls
{
    partial class ReactionControl
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
            this.deleteReactButton = new System.Windows.Forms.RadioButton();
            this.editReactButton = new System.Windows.Forms.RadioButton();
            this.newReactButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // deleteReactButton
            // 
            this.deleteReactButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.deleteReactButton.FlatAppearance.BorderSize = 0;
            this.deleteReactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteReactButton.Location = new System.Drawing.Point(0, 81);
            this.deleteReactButton.Name = "deleteReactButton";
            this.deleteReactButton.Size = new System.Drawing.Size(260, 33);
            this.deleteReactButton.TabIndex = 5;
            this.deleteReactButton.Text = "Excluir Programa";
            this.deleteReactButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteReactButton.UseVisualStyleBackColor = true;
            // 
            // editReactButton
            // 
            this.editReactButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.editReactButton.FlatAppearance.BorderSize = 0;
            this.editReactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editReactButton.Location = new System.Drawing.Point(0, 42);
            this.editReactButton.Name = "editReactButton";
            this.editReactButton.Size = new System.Drawing.Size(260, 33);
            this.editReactButton.TabIndex = 4;
            this.editReactButton.Text = "Editar Programa";
            this.editReactButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editReactButton.UseVisualStyleBackColor = true;
            this.editReactButton.Click += new System.EventHandler(this.editReactButton_Click);
            // 
            // newReactButton
            // 
            this.newReactButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.newReactButton.FlatAppearance.BorderSize = 0;
            this.newReactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newReactButton.Location = new System.Drawing.Point(0, 3);
            this.newReactButton.Name = "newReactButton";
            this.newReactButton.Size = new System.Drawing.Size(260, 33);
            this.newReactButton.TabIndex = 3;
            this.newReactButton.Text = "Novo Programa";
            this.newReactButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newReactButton.UseVisualStyleBackColor = true;
            this.newReactButton.Click += new System.EventHandler(this.newReactButton_Click);
            // 
            // ReactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteReactButton);
            this.Controls.Add(this.editReactButton);
            this.Controls.Add(this.newReactButton);
            this.Name = "ReactionControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton deleteReactButton;
        private System.Windows.Forms.RadioButton editReactButton;
        private System.Windows.Forms.RadioButton newReactButton;
    }
}
