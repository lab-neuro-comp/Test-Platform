using System;
using System.IO;
using System.Windows.Forms;

namespace TestPlatform.Views
{
    public partial class FormDefineTest : Form
    {

        //primeira posição guarda o tipo, segunda guarda o nome do arquivo
        public string[] returnValues = new string[2]; 

        public FormDefineTest()
        {
            InitializeComponent();
        }


        private void addOptionsComboBox(string testFilePath)
        {
            if (Directory.Exists(testFilePath))
            { 
                string[] filePaths;

                filePaths = Directory.GetFiles(testFilePath, ("*.prg"), SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    comboBox1.Items.Add(Path.GetFileNameWithoutExtension(filePaths[i]));
                }
            }
            else
            {
                Console.WriteLine("{0} é um caminho inválido!.", testFilePath);
            }
        }

        private void removeOptionsComboBox()
        {
            comboBox1.Items.Clear();
        }


        private void stroopButton_Click(object sender, EventArgs e)
        {
            if (stroopButton.Checked)
            {
                comboBox1.SelectedItem = null;
                removeOptionsComboBox();
                addOptionsComboBox(Global.stroopTestFilesPath + Global.programFolderName);
            }
        }

        private void reactionButton_Click(object sender, EventArgs e)
        {
            if (reactionButton.Checked)
            {
                comboBox1.SelectedItem = null;
                removeOptionsComboBox();
                addOptionsComboBox(Global.reactionTestFilesPath + Global.programFolderName);
            }
        }

        private void experimentRadioButon_Click(object sender, EventArgs e)
        {
            if (experimentRadioButon.Checked)
            {
                comboBox1.SelectedItem = null;
                removeOptionsComboBox();
                addOptionsComboBox(Global.experimentTestFilesPath + Global.programFolderName);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.returnValues[1] = "padrao";
            this.returnValues[0] = "StroopTest";
            this.DialogResult = DialogResult.Cancel;
            AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren(ValidationConstraints.Enabled))
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");
            else
            {
                comboBox1.Items.Add(comboBox1.Text);
                this.returnValues[1] = comboBox1.Items[comboBox1.Items.Count - 1].ToString();

                if (stroopButton.Checked)
                {
                    returnValues[0] = "StroopTest";
                }
                else if (reactionButton.Checked)
                {
                    returnValues[0] = "ReactionTest";
                }
                else if(experimentRadioButon.Checked)
                {
                    returnValues[0] = "Experimento";
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void comboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidComboSelect(out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(comboBox1, errorMsg);
            }
        }

        public bool ValidComboSelect(out string errorMessage)
        {
            if (comboBox1.SelectedItem == null)
            {
                errorMessage = "Deve-se selecionar um teste.";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
        }


    }
}
