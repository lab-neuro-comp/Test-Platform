/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormDefine : Form
    {
        public string ReturnValue { get; set; }
        public string[] filePaths;
        private string type;
        private string usrName;
        
        public FormDefine(string formTitle, string dataFolderPath, string fileType)
        {
            InitializeComponent();
            this.Text = formTitle;

            type = fileType;

            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            textBox1.Enabled = false;
            textBox1.Visible = false;

            if (type == "prg" || type == "lst" || type == "txt")
            {
                comboBox1.Enabled = true;
                comboBox1.Visible = true;
                if (Directory.Exists(dataFolderPath))
                {
                    filePaths = Directory.GetFiles(dataFolderPath, ("*." + fileType), SearchOption.AllDirectories);
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        comboBox1.Items.Add(Path.GetFileNameWithoutExtension(filePaths[i]));
                    }
                }
                else
                {
                    Console.WriteLine("{0} é um caminho inválido!.", dataFolderPath);
                }
            }
            else
            {
                textBox1.Enabled = true;
                textBox1.Visible = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == "prg" || type == "lst" || type == "txt")
                {
                    comboBox1.Items.Add(comboBox1.Text);
                    this.ReturnValue = comboBox1.Items[comboBox1.Items.Count - 1].ToString();
                }
                else
                {
                    usrName = textBox1.Text.Replace(" ", "");
                    this.ReturnValue = usrName;
                    if (String.IsNullOrEmpty(textBox1.Text)) throw new Exception("A caixa de texto não pode estar vazia!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.ReturnValue = "padrao";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
