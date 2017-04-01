using System;
using System.Windows.Forms;
using TestPlatform.Models;
using System.IO;
using StroopTest.Models;
using System.Drawing;

namespace TestPlatform.Views
{
    public partial class FormTRConfig : UserControl
    {
        private String path;

        protected override void OnLoad(EventArgs e)
        {
            
            if (Validations.isEmpty(path))
            {
                throw new ArgumentException("O caminho do arquivo deve ser especificado.");
            }
            base.OnLoad(e);
        }
        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public FormTRConfig()
        {
            Location = new Point(530, 38);
            InitializeComponent();
        }

        private string fixPointValue()
        {
            string fixPoint = "false";
            if (fixPointCircle.Checked)
            {
                fixPoint = "o";
            }
            else if (fixPointCross.Checked)
            {
                fixPoint = "+";
            }
            return fixPoint;
        }

        private bool configureNewProgram()
        {
            ReactionProgram newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value), 
                                                             Convert.ToInt32(numExpo.Value), Convert.ToInt32(stimuluSize.Value),
                                                             Convert.ToInt32(intervalTime.Value), 
                                                             Convert.ToInt32(stimulusDistance.Value), beepingCheckbox.Checked, 
                                                             Convert.ToInt32(beepDuration.Value), stimulusColor.Text,
                                                             Convert.ToInt32(delayTime.Value), fixPointValue(), 
                                                             bgColorButton.Text, fixPointColorButton.Text);



            if (File.Exists(Path + "prg/" + prgNameTextBox.Text + ".tr"))
            {
                DialogResult dialogResult = MessageBox.Show("O programa já existe, deseja sobrescrevê-lo?", "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.Cancel)
                {
                    throw new Exception("O programa não será salvo!");
                }
            }
            if (newProgram.saveProgramFile(Path, instructionsBox.Text))
            {
                MessageBox.Show("O programa foi salvo com sucesso");
            }
            this.Parent.Controls.Remove(this);
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
        }
    }
}
