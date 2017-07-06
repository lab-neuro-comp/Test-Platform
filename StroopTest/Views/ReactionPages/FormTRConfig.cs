using System;
using System.Windows.Forms;
using TestPlatform.Models;
using System.IO;
using System.Drawing;
using TestPlatform.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace TestPlatform.Views
{
    public partial class FormTRConfig : UserControl
    {
        private String path;
        private String instructionBoxText = "Escreva cada uma das intruções em linhas separadas.";
        private String editPrgName = "false";
        private String prgName = "false";
        private String defaultColor = "#400040";

        public FormTRConfig(string prgName)
        {
            this.prgName = prgName;
            Location = new Point(530, 48);
            InitializeComponent();
            positionsBox.SelectedIndex = 2;
            responseTypeBox.SelectedIndex = 0;
            if (PrgName != "false")
            {
                editPrgName = PrgName;
                editProgram();
            }
        }

        private void editProgram()
        {
            ReactionProgram editProgram = new ReactionProgram();
            editProgram.readProgramFile(path + "TestFiles/ReactionTestFiles/prg/" + editPrgName + ".prg");

            prgNameTextBox.Text = editProgram.ProgramName;
            numExpo.Value = editProgram.NumExpositions;
            expoTime.Value = editProgram.ExpositionTime;
            intervalTime.Value = editProgram.IntervalTime;
            beepingCheckbox.Checked = editProgram.IsBeeping;
            beepDuration.Value = editProgram.BeepDuration;
            stimulusDistance.Value = editProgram.StimulusDistance;
            stimuluSize.Value = editProgram.StimuluSize;

            stimulusColor.Text = editProgram.StimulusColor;
            stimulusColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.StimulusColor);
            editProgramShapes(editProgram);

            if (editProgram.WordsListFile.ToLower() == "false")
            {
                openWordListButton.Enabled = false;
            }
            else
            {
                openWordListButton.Enabled = true;
                openWordListButton.Text = editProgram.WordsListFile;
            }

            if (editProgram.ColorsListFile.ToLower() == "false")
            {
                openColorListButton.Enabled = false;
            }
            else
            {
                openColorListButton.Enabled = true;
                openColorListButton.Text = editProgram.ColorsListFile;
            }

            if (editProgram.ImagesListFile.ToLower() == "false")
            {
                openImgListButton.Enabled = false;
            }
            else
            {
                openImgListButton.Enabled = true;
                openImgListButton.Text = editProgram.ImagesListFile;
            }

            if (editProgram.AudioListFile.ToLower() == "false")
            {
                openAudioListButton.Enabled = false;
            }
            else
            {
                openAudioListButton.Enabled = true;
                openAudioListButton.Text = editProgram.AudioListFile;
            }

            if (editProgram.BackgroundColor.ToLower() == "false")
            {
                bgColorPanel.BackColor = Color.White;
                bgColorButton.Text = "escolher";
            }

            else
            {
                if ((Validations.isHexPattern(editProgram.BackgroundColor)))
                {
                    bgColorButton.Text = editProgram.BackgroundColor;
                    bgColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.BackgroundColor);
                }
            }

            if (editProgram.FixPoint == "+")
            {
                fixPointCross.Checked = true;
                fixPointCircle.Checked = false;
                fixPointColorButton.Text = editProgram.FixPointColor;
                fixPointColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.FixPointColor);
            }
            else if (editProgram.FixPoint == "o")
            {
                fixPointCross.Checked = false;
                fixPointCircle.Checked = true;
                fixPointColorButton.Text = editProgram.FixPointColor;
                fixPointColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.FixPointColor);
            }
            else
            {
                fixPointCross.Checked = false;
                fixPointCircle.Checked = false;
            }

            if (editProgram.InstructionText != null) // lê instrução se houver
            {
                instructionsBox.ForeColor = Color.Black;
                instructionsBox.Text = editProgram.InstructionText[0];
                for (int i = 1; i < editProgram.InstructionText.Count; i++)
                {
                    instructionsBox.AppendText(Environment.NewLine + editProgram.InstructionText[i]);
                }
            }
            else
            {
                instructionsBox.Text = instructionBoxText;
            }

            switch (editProgram.ExpositionType)
            {
                case "Formas":
                    chooseExpoType.SelectedIndex = 0;
                    break;
                case "Palavra":
                    chooseExpoType.SelectedIndex = 1;
                    break;
                case "Imagem":
                    chooseExpoType.SelectedIndex = 2;
                    break;
                case "Imagem e Palavra":
                    chooseExpoType.SelectedIndex = 3;
                    break;
                case "Palavra com Áudio":
                    chooseExpoType.SelectedIndex = 4;
                    break;
                case "Imagem com Áudio":
                    chooseExpoType.SelectedIndex = 5;
                    break;
                default:
                    throw new Exception("Tipo de Exposição: " + editProgram.ExpositionType + " inválido!");
            }

        }
        

        // preparing shapes checkbox according to shapes in the program that will be edited
        private void editProgramShapes(ReactionProgram editProgram)
        {
            List<string> shapes = editProgram.StimuluShape.Split(',').ToList();
            foreach (string shape in shapes)
            {
                switch (shape)
                {
                    case "fullSquare":
                        fullSquareCheckBox.Checked = true;
                        break;
                    case "fullCircle":
                        fullCircleCheckBox.Checked = true;
                        break;
                    case "fullTriangle":
                        fullTriangleCheckBox.Checked = true;
                        break;
                    case "square":
                        squareCheckBox.Checked = true;
                        break;
                    case "circle":
                        circleCheckBox.Checked = true;
                        break;
                    case "triangle":
                        triangleCheckBox.Checked = true;
                        break;
                }
            }

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

        public string PrgName
        {
            get
            {
                return prgName;
            }

            set
            {
                prgName = value;
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


        private string shapeValue()
        {
            List<string> shapes = new List<string>();

            if (fullCircleCheckBox.Checked)
            {
                shapes.Add("fullCircle");
            }
            if (fullSquareCheckBox.Checked)
            {
                shapes.Add("fullSquare");
            }
            if (fullTriangleCheckBox.Checked)
            {
                shapes.Add("fullTriangle");
            }
            if (squareCheckBox.Checked)
            {
                shapes.Add("square");
            }
            if (circleCheckBox.Checked)
            {
                shapes.Add("circle");
            }
            if (triangleCheckBox.Checked)
            {
                shapes.Add("triangle");
            }

            string result = null;

            for (int i = 0; i < shapes.Count; i++)
            {
                result += shapes[i] + ",";
            }
            return result;
        }

        private string fixPointColor()
        {
            if (fixPointColorButton.Text.Equals("escolher"))
            {
                return defaultColor;
            }
            else
            {
                return fixPointColorButton.Text;
            }
        }


        private string stimulusColorCheck()
        {
            if (stimulusColor.Text.Equals("escolher"))
            {
                return defaultColor;
            }
            else
            {
                return stimulusColor.Text;
            }
        }

        private ReactionProgram configureNewProgram()
        {
            if(bgColorButton.Text.Equals("escolher"))
            {
                bgColorButton.Text = "false";
            }
            ReactionProgram newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                             Convert.ToInt32(numExpo.Value), Convert.ToInt32(stimuluSize.Value),
                                                             Convert.ToInt32(intervalTime.Value),
                                                             Convert.ToInt32(stimulusDistance.Value), beepingCheckbox.Checked,
                                                             Convert.ToInt32(beepDuration.Value), stimulusColorCheck(), 
                                                             fixPointValue(), bgColorButton.Text, fixPointColor(), 
                                                             rndIntervalCheck.Checked, shapeValue(), chooseExpoType.Text, 
                                                             randomBeepCheck.Checked, Convert.ToInt32(positionsBox.Text
                                                             ), responseTypeBox.Text);


            // read instructions and pass them to the new program created
            string textLines = "";
            if (instructionsBox.Lines.Length > 0 && instructionsBox.Text != instructionBoxText)
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
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");
            else
            {
                ReactionProgram newProgram = configureNewProgram();
            
            try
            {
                if (File.Exists(Path +"ReactionTestFiles/prg/" + prgNameTextBox.Text + ".prg"))
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

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
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


        private void prgNameTextBox_Validating(object sender,
                 System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidProgramName(prgNameTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(prgNameTextBox, errorMsg);
            }
        }

        private void prgNameTextBox_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(prgNameTextBox, "");
        }

        public bool ValidProgramName(string pgrName, out string errorMessage)
        {
            if (pgrName.Length == 0)
            {
                errorMessage = "O nome do programa deve ser preenchido.";
                return false;
            }
            if (!Validations.isAlphanumeric(pgrName))
            {
                errorMessage = "Nome do programa deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'MeuPrograma'";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void expoTimeNumericUpDown_Validating(object sender,
         System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidExpoTime(Convert.ToInt32(this.expoTime.Value), out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.expoTime, errorMsg);
            }
        }

        private void expoTimeNumericUpDown_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(expoTime, "");
        }

        public bool ValidExpoTime(int expoTime, out string errorMessage)
        {
            if (!Validations.isExpositionTimeValid(expoTime))
            {
                errorMessage = "O tempo de exposição deve ser maior do que zero.";
                return false;
            }

            errorMessage = "";
            return true;
        }


        private void intervalTime_Validating(object sender,
                                                      System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidIntervalTime(Convert.ToInt32(this.intervalTime.Value), out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.intervalTime, errorMsg);
            }
        }

        private void intervalTime_Validated(object sender, System.EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(intervalTime, "");
        }

        public bool ValidIntervalTime(int intervalTime, out string errorMessage)
        {
            if (!Validations.isIntervalTimeValid(intervalTime))
            {
                errorMessage = "Tempo de intervalo deve ser maior que zero (em milissegundos)";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void numExpo_Validating(object sender,
         System.ComponentModel.CancelEventArgs e)
        {

        }

        private void numExpo_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(numExpo, "");
        }

        public bool ValidnumExpo(int numExpo, out string errorMessage)
        {
            if (!Validations.isExpositionTimeValid(numExpo))
            {
                errorMessage = "O número de exposições deve ser maior do que zero.";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void beepingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (beepingCheckbox.Checked)
            {
                beepDuration.Enabled = true;
            }
            else
            {
                beepDuration.Value = 0;
                beepDuration.Enabled = false;
            }
        }
    }
}
