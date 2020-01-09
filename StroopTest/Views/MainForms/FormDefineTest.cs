using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Models.Tests.SpacialRecognition;

namespace TestPlatform.Views
{
    public partial class FormDefineTest : Form
    {

        //primeira posição guarda o tipo, segunda guarda o nome do arquivo
        public string[] returnValues = new string[2];
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture;

        public FormDefineTest(CultureInfo currentCulture, string testName)
        {
            this.currentCulture = currentCulture;
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
            addOptionsComboBox(StroopProgram.GetProgramsPath());
            if(testName == LocRM.GetString("stroopTest", currentCulture))
            {
                stroopButton.Checked = true;
            }
            else if(testName == LocRM.GetString("reactionTest", currentCulture))
            {
                reactionButton.Checked = true;
            }
            else if(testName == LocRM.GetString("matchingTest", currentCulture))
            {
                matchingButton.Checked = true;
            }
            else if(testName == LocRM.GetString("spacialRecognitionTest", currentCulture))
            {
                spacialRecognitionButton.Checked = true;
            }
            else
            {
                experimentButton.Checked = true;
            }
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
                MessageBox.Show("{0}" + LocRM.GetString("invalidPath", currentCulture), testFilePath);
            }
        }

        private void removeOptionsComboBox()
        {
            comboBox1.Items.Clear();
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.returnValues[1] = LocRM.GetString("default", currentCulture);
            this.returnValues[0] = LocRM.GetString("stroopTest", currentCulture);
            this.DialogResult = DialogResult.Cancel;
            AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren(ValidationConstraints.Enabled))
                MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
            else
            {
                int selectedValue;
                if (stroopButton.Checked) selectedValue = 0;
                else if (reactionButton.Checked) selectedValue = 1;
                else if (matchingButton.Checked) selectedValue = 2;
                else if (spacialRecognitionButton.Checked) selectedValue = 3;
                else selectedValue = 4;
                comboBox1.Items.Add(comboBox1.Text);
                this.returnValues[1] = comboBox1.Items[comboBox1.Items.Count - 1].ToString();
                switch (selectedValue)
                {
                    case 0:
                        returnValues[0] = LocRM.GetString("stroopTest", currentCulture);
                        break;
                    case 1:
                        returnValues[0] = LocRM.GetString("reactionTest", currentCulture);
                        break;
                    case 2:
                        returnValues[0] = LocRM.GetString("matchingTest", currentCulture);
                        break;
                    case 3:
                        returnValues[0] = LocRM.GetString("spacialRecognitionTest", currentCulture);
                        break;
                    default:
                        returnValues[0] = LocRM.GetString("experiment", currentCulture);
                        break;
                }
      
                Console.WriteLine(currentCulture.EnglishName);
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
                errorMessage = LocRM.GetString("emptyBox", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            int selectedValue;
            if (stroopButton.Checked) selectedValue = 0;
            else if (reactionButton.Checked) selectedValue = 1;
            else if (matchingButton.Checked) selectedValue = 2;
            else if (spacialRecognitionButton.Checked) selectedValue = 3;
            else selectedValue = 4;
            switch (selectedValue)
            {
                case 0:
                    comboBox1.SelectedItem = null;
                    removeOptionsComboBox();
                    addOptionsComboBox(StroopProgram.GetProgramsPath());
                    break;
                case 1:
                    comboBox1.SelectedItem = null;
                    removeOptionsComboBox();
                    addOptionsComboBox(ReactionProgram.GetProgramsPath());
                    break;
                case 2:
                    comboBox1.SelectedItem = null;
                    removeOptionsComboBox();
                    addOptionsComboBox(MatchingProgram.GetProgramsPath());
                    break;
                case 3:
                    comboBox1.SelectedItem = null;
                    removeOptionsComboBox();
                    addOptionsComboBox(SpacialRecognitionProgram.GetProgramsPath());
                    break;
                default:
                    comboBox1.SelectedItem = null;
                    removeOptionsComboBox();
                    addOptionsComboBox(ExperimentProgram.GetProgramsPath());
                    break;
            }
        }
        
    }
}
