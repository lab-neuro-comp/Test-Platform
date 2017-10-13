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
        private String path = Global.reactionTestFilesPath;
        private String instructionBoxText = "Escreva cada uma das intruções em linhas separadas.";
        private String editPrgName = "false";
        private String prgName = "false";
        private String defaultColor = "#400040";

        public FormTRConfig(string prgName)
        {
            this.prgName = prgName;
            this.Dock = DockStyle.Fill;
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
            editProgram.readProgramFile(path + Global.programFolderName + editPrgName + ".prg");

            prgNameTextBox.Text = editProgram.ProgramName;
            numExpo.Value = editProgram.NumExpositions;
            expoTime.Value = editProgram.ExpositionTime;
            intervalTime.Value = editProgram.IntervalTime;
            beepingCheckbox.Checked = editProgram.IsBeeping;
            beepDuration.Value = editProgram.BeepDuration;
            stimulusDistance.Value = editProgram.StimulusDistance;
            stimuluSize.Value = editProgram.StimuluSize;

            if (editProgram.ExpositionRandom)
            {
                isRandomExposition.Checked = true;
            }

            if(editProgram.StimulusColor != "false")
            {
                stimulusColor.Text = editProgram.StimulusColor;
                stimulusColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.StimulusColor);
            }
            
            editProgramShapes(editProgram);

            if (editProgram.getWordListFile() == null)
            {
                openWordListButton.Enabled = false;
            }
            else
            {
                openWordListButton.Enabled = true;
                openWordListButton.Text = editProgram.getWordListFile().ListName;
            }

            if (editProgram.getColorListFile() == null)
            {
                openColorListButton.Enabled = false;
            }
            else
            {
                openColorListButton.Enabled = true;
                openColorListButton.Text = editProgram.getColorListFile().ListName;
            }

            if (editProgram.getImageListFile() == null)
            {
                openImgListButton.Enabled = false;
            }
            else
            {
                openImgListButton.Enabled = true;
                openImgListButton.Text = editProgram.getImageListFile().ListName;
            }

            if (editProgram.getAudioListFile() == null)
            {
                openAudioListButton.Enabled = false;
            }
            else
            {
                openAudioListButton.Enabled = true;
                openAudioListButton.Text = editProgram.getAudioListFile().ListName;
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
            if (bgColorButton.Text.Equals("escolher"))
            {
                bgColorButton.Text = "false";
            }
            ReactionProgram newProgram = new ReactionProgram();
            switch (chooseExpoType.SelectedIndex)
            {
                // Program type "Formas"
                case 0:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                Convert.ToInt32(numExpo.Value), Convert.ToInt32(stimuluSize.Value),
                                                Convert.ToInt32(intervalTime.Value),
                                                Convert.ToInt32(stimulusDistance.Value), beepingCheckbox.Checked,
                                                Convert.ToInt32(beepDuration.Value), stimulusColorCheck(),
                                                fixPointValue(), bgColorButton.Text, fixPointColor(),
                                                rndIntervalCheck.Checked, shapeValue(), chooseExpoType.Text,
                                                randomBeepCheck.Checked, Convert.ToInt32(positionsBox.Text
                                                ), responseTypeBox.Text);
                    break;
                // Program type "Palavra"
                case 1:
                    // TODO: Add ReactionProgram constructor to "Palavra" type here
                    break;
                
                // Program type "Imagem"
                case 2:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value), Convert.ToInt32(numExpo.Value), Convert.ToInt32(stimuluSize.Value), 
                                                     Convert.ToInt32(intervalTime.Value), Convert.ToInt32(stimulusDistance.Value), beepingCheckbox.Checked, Convert.ToInt32(beepDuration.Value),
                                                     fixPointValue(), bgColorButton.Text, fixPointColor(), rndIntervalCheck.Checked, openImgListButton.Text, randomBeepCheck.Checked, 
                                                     Convert.ToInt32(positionsBox.Text), responseTypeBox.Text, isRandomExposition.Checked);
                    break;
                
                // Program type "Imagem e Palavra"
                case 3:
                    // TODO: Add ReactionProgram constructor to "Imagem e Palavra" type here
                    break;
                
                // Program type "Palavra com Aúdio"
                case 4:
                    // TODO: Add ReactionProgram constructor to "Palavra com aúdio" type here
                    break;
                
                // Program type "Imagem com Aúdio"
                case 5:
                    // TODO: Add ReactionProgram constructor to "Imagem com aúdio" type here
                    break;
                
                // invalid type aws choosen
                default:
                    throw new Exception("O tipo de programa entrado é invalido!");
            }
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
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                ReactionProgram newProgram = configureNewProgram();


                if (File.Exists(path + Global.programFolderName + prgNameTextBox.Text + ".prg"))
                {
                    DialogResult dialogResult = MessageBox.Show("O programa já existe, deseja sobrescrevê-lo?", "", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        throw new Exception("O programa não será salvo!");
                    }
                }
                if (newProgram.saveProgramFile(path + Global.programFolderName, instructionsBox.Text))
                {
                    MessageBox.Show("O programa foi salvo com sucesso");
                }
                this.Parent.Controls.Remove(this);
            }
                
            else
            {
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");
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
            openWordListButton.Text = ListController.openListFile("_words");
        }

        private void openColorsList_Click(object sender, EventArgs e)
        {
            openColorListButton.Text = ListController.openListFile("_color");
        }

        private void openImagesList_Click(object sender, EventArgs e)
        {
            openImgListButton.Text = ListController.openListFile("_image");
        }

        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = ListController.openListFile("_audio");
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

        private void chooseExpoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (chooseExpoType.SelectedIndex) {
                case 0:
                    errorProvider1.Clear();
                    openImgListButton.Enabled = false;
                    stimulusColor.Enabled = true;
                    shapesGroupBox.Enabled = true;
                    isRandomExposition.Enabled = false;
                    break;
                case 2:
                    errorProvider1.Clear();
                    openImgListButton.Enabled = true;
                    stimulusColor.Text = "escolher";
                    stimulusColorPanel.BackColor = Color.White;
                    stimulusColor.Enabled = false;
                    shapesGroupBox.Enabled = false;
                    isRandomExposition.Enabled = true;
                    break;
                default:
                    errorProvider1.SetError(chooseExpoType, "Tipo de exposição ainda não está disponível");
                    break;
            }
                
        }

        private void openImgListButton_Validating(object sender,
                                     System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidopenImgListButton(openImgListButton.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.openImgListButton, errorMsg);
            }
        }

        private void openImgListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openImgListButton, "");
        }

        public bool ValidopenImgListButton(string text, out string errorMessage)
        {
            if (Validations.isExpoEnabled(openImgListButton) && !Validations.isLengthValid(text))
            {
                errorMessage = "Selecione o arquivo de lista de imagem!";
                return false;
            }

            errorMessage = "";
            return true;
        }
    }
}
