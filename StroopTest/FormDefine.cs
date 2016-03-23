using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormDefine : Form
    {
        public string ReturnValue { get; set; }
        public string[] filePaths;

        public FormDefine(string defineTarget, string dataFolderPath, string fileType)
        {
            InitializeComponent();
            this.Text = "Definir " + defineTarget;
        
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
                Console.WriteLine("{0} é um diretório inválido!.", dataFolderPath);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.ReturnValue = "padrao";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(comboBox1.Text);
            this.ReturnValue = comboBox1.Items[comboBox1.Items.Count-1].ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
