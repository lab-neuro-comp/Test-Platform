using System;
using System.Windows.Forms;
using TestPlatform.Models;
using System.IO;
using StroopTest.Models;
using System.Drawing;
using StroopTest.Controllers;
using StroopTest.Views;

namespace TestPlatform.Views
{
    public partial class FormTRConfig : UserControl
    {
        private String path;
        private String instructionBoxText = "Escreva cada uma das intruções em linhas separadas.";
        private String instructionsText = HelpData.ProgramConfigInstructions;

        public FormTRConfig()
        {
            Location = new Point(530, 38);
            InitializeComponent();
        }

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

        private ReactionProgram configureNewProgram()
        {
            ReactionProgram newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                             Convert.ToInt32(numExpo.Value), Convert.ToInt32(stimuluSize.Value),
                                                             Convert.ToInt32(intervalTime.Value),
                                                             Convert.ToInt32(stimulusDistance.Value), beepingCheckbox.Checked,
                                                             Convert.ToInt32(beepDuration.Value), stimulusColor.Text,
                                                             Convert.ToInt32(delayTime.Value), fixPointValue(),
                                                             bgColorButton.Text, fixPointColorButton.Text);

            string textLines = "";
            if (instructionsBox.Lines.Length > 0 && instructionsBox.Text != instructionBoxText) // lê instrução se houver
            {
                for (int i = 0; i < instructionsBox.Lines.Length; i++)
                {
                    newProgram.InstructionText.Add(instructionsBox.Lines[i]);
                    textLines = textLines + "\n" + instructionsBox.Lines[i];
                }
            }
            else
            {
                newProgram.InstructionText = null;
            }
            return newProgram;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ReactionProgram newProgram = configureNewProgram();
            try
            {
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            this.Parent.Controls.Remove(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
        }

        private void chooseBGColor(object sender, EventArgs e)
        {
            string colorCode = ListController.pickColor(this);
            bgColorButton.Text = colorCode;
            bgColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }


        private void openWordsList_Click(object sender, EventArgs e)
        {
            openWordListButton.Text = ListController.openListFile("_words", path);
        }

        private void openColorsList_Click(object sender, EventArgs e)
        {
            openColorListButton.Text = ListController.openListFile("_color", path);
        }

        private void openImagesList_Click(object sender, EventArgs e)
        {
            openImgListButton.Text = ListController.openListFile("_image", path);
        }

        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = ListController.openListFile("_audio", path);
        }

        private void fixPointColorButton_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.pickColor(this);
            fixPointColorButton.Text = colorCode;
            fixPointColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void stimulusColor_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.pickColor(this);
            stimulusColor.Text = colorCode;
            stimulusColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }


        private void checkFixPointCross_CheckedChanged(object sender, EventArgs e)
        {
            if (fixPointCross.Checked && fixPointCircle.Checked)
                fixPointCircle.Checked = !fixPointCross.Checked;
            chooseFixPointType();
        }

        private void checkFixPointCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (fixPointCross.Checked && fixPointCircle.Checked)
                fixPointCross.Checked = !fixPointCircle.Checked;
            chooseFixPointType();
        }


        private void chooseFixPointType()
        {
            if (fixPointCross.Checked || fixPointCircle.Checked)
            {
                fixPointColorLabel.Enabled = true; fixPointColorPanel.Enabled = true; fixPointColorButton.Enabled = true;
            }
            if (!fixPointCross.Checked && !fixPointCircle.Checked)
            {
                fixPointColorLabel.Enabled = false; fixPointColorPanel.Enabled = false; fixPointColorButton.Enabled = false;
            }
        }

        private void instructionsBox_TextChanged(object sender, EventArgs e)
        {
            if (instructionsBox.Text == instructionBoxText)
            {
                instructionsBox.Text = "";
            }
            instructionsBox.ForeColor = Color.Black;
        
        }

    }
}
