using System;
using System.Windows.Forms;
using TestPlatform.Models;
using System.IO;
using System.Drawing;
using TestPlatform.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Globalization;

namespace TestPlatform.Views
{
    public partial class FormTRConfig : UserControl
    {
        private String path = Global.reactionTestFilesPath;
        private String instructionBoxText;
        private String editPrgName = "false";
        private String prgName = "false";
        private String defaultColor = "#400040";
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public FormTRConfig(string prgName)
        {
            instructionBoxText = LocRM.GetString("instructionBox",currentCulture);
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
            try
            {
                editProgram.readProgramFile(path + Global.programFolderName + editPrgName + ".prg");
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(LocRM.GetString("cantEdìtProgramMissingFiles", currentCulture) + e.Message);
                return;
            }
                        
            prgNameTextBox.Text = editProgram.ProgramName;
            numExpo.Value = editProgram.NumExpositions;
            expoTime.Value = editProgram.ExpositionTime;
            intervalTime.Value = editProgram.IntervalTime;
            beepingCheckbox.Checked = editProgram.IsBeeping;
            beepDuration.Value = editProgram.BeepDuration;
            stimuluSize.Value = (decimal) editProgram.StimuluSize;
            fontSizeUpDown.Value = editProgram.FontSize;
            positionsBox.SelectedIndex = editProgram.NumberPositions - 1;
            expandImageCheck.Checked = editProgram.ExpandImage;

            if (editProgram.getHasColorList())
            {
                UniqueColorOption.Checked = false;
                ColorListOption.Checked = true;
                openColorListButton.Enabled = true;
                stimulusColor.Enabled = false;
            }
            if (editProgram.ExpositionRandom)
            {
                isRandomExposition.Checked = true;
            }

            if (editProgram.BeepingRandom)
            {
                randomBeepCheck.Checked = true;
            }

            if(editProgram.StimulusColor != "false")
            {
                stimulusColor.Text = editProgram.StimulusColor;
                stimulusColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.StimulusColor);
            }
            else
            {
                stimulusColor.Enabled = false;
                stimulusColorPanel.BackColor = Color.White;
            }
            editProgramShapes(editProgram);
            if (editProgram.ResponseType == "space")
            {
                responseTypeBox.SelectedIndex = 0;
            }
            else if (editProgram.ResponseType == "arrows")
            {
                responseTypeBox.SelectedIndex = 1;
            }

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
                bgColorButton.Text = LocRM.GetString("choose", currentCulture);
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

            // reads program instructions to instruction box if there are any
            if (editProgram.InstructionText != null) 
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
                case "shapes":
                    chooseExpoType.SelectedIndex = 0;
                    break;
                case "words":
                    chooseExpoType.SelectedIndex = 1;
                    break;
                case "images":
                    chooseExpoType.SelectedIndex = 2;
                    break;
                case "imageAndWord":
                    chooseExpoType.SelectedIndex = 3;
                    break;
                case "wordWithAudio":
                    chooseExpoType.SelectedIndex = 4;
                    break;
                case "imageWithAudio":
                    chooseExpoType.SelectedIndex = 5;
                    break;
                default:
                    throw new Exception(LocRM.GetString("expoType", currentCulture) + editProgram.ExpositionType + LocRM.GetString("invalid", currentCulture));
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
            if (fixPointColorButton.Text.Equals(LocRM.GetString("choose", currentCulture)))
            {
                return defaultColor;
            }
            else
            {
                return fixPointColorButton.Text;
            }
        }

        private string typeValue()
        {
            switch (chooseExpoType.SelectedIndex)
            {
                case 0:
                   return "shapes";
                case 1:
                    return "words";
                case 2:
                    return "images";
                case 3:
                    return "imageAndWord";
                case 4:
                    return "wordWithAudio";
                case 5:
                    return "imageWithAudio";
                default:
                    throw new Exception(LocRM.GetString("invalidExpoType", currentCulture));
            }
        }

        private string responseType()
        {
            switch (responseTypeBox.SelectedIndex)
            {
                case 0:
                    return "space";
                case 1:
                    return "arrows";
                default:
                    throw new Exception(LocRM.GetString("responseTypeError", currentCulture));
            }
        }


        private string stimulusColorCheck()
        {
            if (stimulusColor.Text.Equals(LocRM.GetString("choose", currentCulture)))
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
            if (bgColorButton.Text.Equals(LocRM.GetString("choose", currentCulture)))
            {
                bgColorButton.Text = "false";
            }
            ReactionProgram newProgram = new ReactionProgram();
            switch (chooseExpoType.SelectedIndex)
            {
                // Program type "shapes"
                case 0:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                    Convert.ToInt32(numExpo.Value), Convert.ToDouble(stimuluSize.Value),
                                                    Convert.ToInt32(intervalTime.Value),
                                                    beepingCheckbox.Checked,
                                                    Convert.ToInt32(beepDuration.Value), stimulusColorCheck(),
                                                    fixPointValue(), bgColorButton.Text, fixPointColor(),
                                                    rndIntervalCheck.Checked, shapeValue(), randomBeepCheck.Checked, 
                                                    Convert.ToInt32(positionsBox.Text), responseType(), openColorListButton.Text, ColorListOption.Checked, sstCheckBox.Checked);
                    break;
                // Program type "words"
                case 1:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value),
                                                    Convert.ToInt32(numExpo.Value), Convert.ToInt32(fontSizeUpDown.Value),
                                                    Convert.ToInt32(intervalTime.Value),
                                                    beepingCheckbox.Checked,
                                                    Convert.ToInt32(beepDuration.Value), stimulusColorCheck(),
                                                    fixPointValue(), bgColorButton.Text, fixPointColor(),
                                                    rndIntervalCheck.Checked, randomBeepCheck.Checked,
                                                    Convert.ToInt32(positionsBox.Text), responseType(), openWordListButton.Text, isRandomExposition.Checked, 
                                                    openColorListButton.Text, ColorListOption.Checked, Convert.ToInt32(fontSizeUpDown.Value), sstCheckBox.Checked);
                    break;
                
                // Program type "images"
                case 2:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value), Convert.ToInt32(numExpo.Value), Convert.ToDouble(stimuluSize.Value), 
                                                     Convert.ToInt32(intervalTime.Value), beepingCheckbox.Checked, Convert.ToInt32(beepDuration.Value),
                                                     fixPointValue(), bgColorButton.Text, fixPointColor(), rndIntervalCheck.Checked, openImgListButton.Text, 
                                                     randomBeepCheck.Checked, Convert.ToInt32(positionsBox.Text), responseType(), isRandomExposition.Checked, 
                                                     expandImageCheck.Checked, sstCheckBox.Checked);
                    break;
                
                // Program type "imageAndWord"
                case 3:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value), Convert.ToInt32(numExpo.Value), Convert.ToDouble(stimuluSize.Value),
                                                     Convert.ToInt32(intervalTime.Value), beepingCheckbox.Checked, Convert.ToInt32(beepDuration.Value),
                                                     fixPointValue(), bgColorButton.Text, fixPointColor(), rndIntervalCheck.Checked,
                                                     openImgListButton.Text, openWordListButton.Text, openColorListButton.Text, randomBeepCheck.Checked,
                                                     Convert.ToInt32(positionsBox.Text), ColorListOption.Checked,  responseType(), isRandomExposition.Checked, 
                                                     stimulusColorCheck(), Convert.ToInt32(fontSizeUpDown.Value), expandImageCheck.Checked, sstCheckBox.Checked);
                    break;
                
                // Program type "wordWithAudio"
                case 4:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value), Convert.ToInt32(numExpo.Value), Convert.ToInt32(intervalTime.Value),
                                                    stimulusColorCheck(), fixPointValue(), bgColorButton.Text, fixPointColor(), rndIntervalCheck.Checked, 
                                                    Convert.ToInt32(positionsBox.Text), responseType(), openColorListButton.Text, ColorListOption.Checked, 
                                                    isRandomExposition.Checked, Convert.ToInt32(fontSizeUpDown.Value), openAudioListButton.Text, openWordListButton.Text, 
                                                    sstCheckBox.Checked);

                    break;
                
                // Program type "imageWithAudio"
                case 5:
                    newProgram = new ReactionProgram(prgNameTextBox.Text, Convert.ToInt32(expoTime.Value), Convert.ToInt32(numExpo.Value), Convert.ToInt32(intervalTime.Value),
                                                    fixPointValue(), bgColorButton.Text, fixPointColor(), rndIntervalCheck.Checked, Convert.ToInt32(positionsBox.Text),
                                                    responseType(), Convert.ToDouble(stimuluSize.Value), isRandomExposition.Checked, openAudioListButton.Text, 
                                                    openImgListButton.Text, expandImageCheck.Checked, sstCheckBox.Checked);
                    break;
                
                // invalid type was choosen
                default:
                    throw new Exception(LocRM.GetString("invalidExpoType", currentCulture));
            }
            // read instructions and pass them to the new program created
            string textLines = "";
            if (instructionsBox.Lines.Length > 0)
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

        public bool save()
        {
            saveButton_Click(this, null);
            foreach (Control c in this.errorProvider1.ContainerControl.Controls)
            {
                if (errorProvider1.GetError(c) != "")
                {
                    return false;
                }
            }
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool hasToSave = true;
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                ReactionProgram newProgram = configureNewProgram();
                
                if (File.Exists(path + Global.programFolderName + prgNameTextBox.Text + ".prg"))
                {
                    DialogResult dialogResult = MessageBox.Show(LocRM.GetString("programExists", currentCulture), "", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        hasToSave = false;
                        MessageBox.Show(LocRM.GetString("programNotSave", currentCulture));
                    }
                }
                if (hasToSave && newProgram.saveProgramFile(path + Global.programFolderName, instructionsBox.Text))
                {
                    MessageBox.Show(LocRM.GetString("programSave", currentCulture));
                }
                this.Parent.Controls.Remove(this);
            }
                
            else
            {
                MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
        }

        private void chooseBGColor(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            bgColorButton.Text = colorCode;
            bgColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }


        private void openWordsList_Click(object sender, EventArgs e)
        {
            openWordListButton.Text = ListController.OpenListFile("_words", openWordListButton.Text, "lst");
        }

        private void openColorsList_Click(object sender, EventArgs e)
        {
            openColorListButton.Text = ListController.OpenListFile("_color", openColorListButton.Text, "lst");
        }

        private void openImagesList_Click(object sender, EventArgs e)
        {
            openImgListButton.Text = ListController.OpenListFile("_image", openImgListButton.Text, "dir");
        }

        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = ListController.OpenListFile("_audio", openAudioListButton.Text, "dir");
        }

        private void fixPointColorButton_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            fixPointColorButton.Text = colorCode;
            fixPointColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        private void stimulusColor_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
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
                errorMessage = LocRM.GetString("programNotFilled", currentCulture);
                return false;
            }
            if (!Validations.isAlphanumeric(pgrName))
            {
                errorMessage = LocRM.GetString("programNotAlphanumeric", currentCulture);
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
                errorMessage = LocRM.GetString("expoTime", currentCulture);
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
                errorMessage = LocRM.GetString("intervalTime", currentCulture);
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
                errorMessage = LocRM.GetString("expoNumber", currentCulture);
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
                randomBeepCheck.Enabled = true;
            }
            else
            {
                beepDuration.Value = 0;
                beepDuration.Enabled = false;
                randomBeepCheck.Checked = false;
                randomBeepCheck.Enabled = false;
            }
        }

        private void beepDuration_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidBeepDuration(beepDuration.Value, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.beepDuration, errorMsg);
            }
        }

        public bool ValidBeepDuration(decimal duration, out string errorMessage)
        {
            if (duration <= 0)
            {
                errorMessage = LocRM.GetString("beepDuration", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void beepDuration_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.beepDuration, "");
        }

        private void chooseExpoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (chooseExpoType.SelectedIndex) {
                //Shapes exposition
                case 0:
                    errorProvider1.Clear();
                    shapesGroupBox.Enabled = true;
                    openColorListButton.Enabled = true;
                    ColorListOption.Enabled = true;
                    UniqueColorOption.Enabled = true;
                    fontSizeUpDown.Enabled = false;
                    if(ColorListOption.Checked)
                    {
                        stimulusColor.Enabled = false;
                        openColorListButton.Enabled = true;
                    }
                    else
                    {
                        stimulusColor.Enabled = true;
                        openColorListButton.Enabled = false;
                    }
                    beepDuration.Enabled = false;
                    randomBeepCheck.Enabled = false;
                    beepingCheckbox.Enabled = true;
                    beepingCheckbox.Checked = false;

                    //disable unused buttons
                    openImgListButton.Enabled = false;
                    openAudioListButton.Enabled = false;
                    openAudioListButton.Text = LocRM.GetString("open", currentCulture);
                    openImgListButton.Text = LocRM.GetString("open", currentCulture);
                    openWordListButton.Enabled = false;
                    openWordListButton.Text = LocRM.GetString("open", currentCulture);
                    expandImageCheck.Enabled = false;
                    break;
                //Words exposition
                case 1:
                    errorProvider1.Clear();
                    shapesGroupBox.Enabled = false;
                    fontSizeUpDown.Enabled = true;
                    stimuluSize.Enabled = false;
                    openWordListButton.Enabled = true;
                    ColorListOption.Enabled = true;
                    UniqueColorOption.Enabled = true;
                    if (ColorListOption.Checked)
                    {
                        stimulusColor.Enabled = false;
                        openColorListButton.Enabled = true;
                    }
                    else
                    {
                        stimulusColor.Enabled = true;
                        openColorListButton.Enabled = false;
                    }
                    beepDuration.Enabled = false;
                    randomBeepCheck.Enabled = false;
                    beepingCheckbox.Enabled = true;
                    beepingCheckbox.Checked = false;

                    //disable unused buttons
                    openImgListButton.Enabled = false;
                    openAudioListButton.Enabled = false;
                    LocRM.GetString("open", currentCulture);
                    openImgListButton.Text = LocRM.GetString("open", currentCulture);
                    expandImageCheck.Enabled = false;
                    break;
                //Images exposition
                case 2:
                    fontSizeUpDown.Enabled = false;
                    stimuluSize.Enabled = true;
                    errorProvider1.Clear();
                    openImgListButton.Enabled = true;
                    stimulusColorPanel.BackColor = Color.White;
                    shapesGroupBox.Enabled = false;
                    openColorListButton.Enabled = false;
                    ColorListOption.Enabled = false;
                    UniqueColorOption.Enabled = false;
                    //disable unused buttons
                    openColorListButton.Text = LocRM.GetString("open", currentCulture);
                    openWordListButton.Enabled = false;
                    openColorListButton.Text = LocRM.GetString("open", currentCulture);
                    stimulusColor.Enabled = false;
                    stimulusColor.Text = LocRM.GetString("choose", currentCulture);
                    openAudioListButton.Enabled = false;
                    LocRM.GetString("open", currentCulture);
                    beepDuration.Enabled = false;
                    randomBeepCheck.Enabled = false;
                    beepingCheckbox.Enabled = true;
                    beepingCheckbox.Checked = false;
                    expandImageCheck.Enabled = true;

                    break;
                //Images and word expositions
                case 3:
                    errorProvider1.Clear();
                    fontSizeUpDown.Enabled = true;
                    shapesGroupBox.Enabled = false;
                    openWordListButton.Enabled = true;
                    ColorListOption.Enabled = true;
                    stimuluSize.Enabled = true;
                    UniqueColorOption.Enabled = true;
                    if (ColorListOption.Checked)
                    {
                        stimulusColor.Enabled = false;
                        openColorListButton.Enabled = true;
                    }
                    else
                    {
                        stimulusColor.Enabled = true;
                        openColorListButton.Enabled = false;
                    }
                    openImgListButton.Enabled = true;
                    openAudioListButton.Enabled = false;
                    beepDuration.Enabled = false;
                    randomBeepCheck.Enabled = false;
                    beepingCheckbox.Enabled = true;
                    beepingCheckbox.Checked = false;
                    expandImageCheck.Enabled = true;

                    LocRM.GetString("open", currentCulture);
                    break;
                // word with audio exposition
                case 4:
                    errorProvider1.Clear();
                    fontSizeUpDown.Enabled = true;
                    shapesGroupBox.Enabled = false;
                    stimuluSize.Enabled = false;
                    openWordListButton.Enabled = true;
                    ColorListOption.Enabled = true;
                    UniqueColorOption.Enabled = true;
                    openAudioListButton.Enabled = true;
                    if (ColorListOption.Checked)
                    {
                        stimulusColor.Enabled = false;
                        openColorListButton.Enabled = true;
                    }
                    else
                    {
                        stimulusColor.Enabled = true;
                        openColorListButton.Enabled = false;
                    }
                    beepDuration.Enabled = false;
                    randomBeepCheck.Enabled = false;
                    randomBeepCheck.Checked = false;
                    beepingCheckbox.Enabled = false;
                    beepingCheckbox.Checked = false;
                    openImgListButton.Enabled = false;
                    expandImageCheck.Enabled = false;

                    break;
                // image with audio exposition
                case 5:
                    errorProvider1.Clear();
                    stimuluSize.Enabled = true;
                    openAudioListButton.Enabled = true;
                    openImgListButton.Enabled = true;
                    expandImageCheck.Enabled = true;

                    beepDuration.Enabled = false;
                    randomBeepCheck.Enabled = false;
                    randomBeepCheck.Checked = false;
                    beepingCheckbox.Enabled = false;
                    openWordListButton.Enabled = false;
                    ColorListOption.Enabled = false;
                    UniqueColorOption.Enabled = false;
                    beepingCheckbox.Checked = false;
                    fontSizeUpDown.Enabled = false;
                    shapesGroupBox.Enabled = false;
                    stimulusColor.Enabled = false;
                    break;
                default:
                    errorProvider1.SetError(chooseExpoType, LocRM.GetString("unavailableExpo", currentCulture));
                    break;
            }
                
        }

        private void openImgListButton_Validating(object sender,
                                     System.ComponentModel.CancelEventArgs e)
        {
            if (openImgListButton.Enabled)
            {
                listValidating(openImgListButton, sender, e);
            }
        }

        private void openImgListButton_Validated(object sender, System.EventArgs e)
        {
            errorProvider1.SetError(this.openImgListButton, "");
        }

        public bool ValidList(string buttonText, out string errorMessage)
        {
            if ( buttonText.Length != 0 && buttonText != LocRM.GetString("open", currentCulture))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("listError", currentCulture);
                return false;
            }
        }

        private void openWordListButton_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (openWordListButton.Enabled)
            {
                listValidating(openWordListButton, sender, e);
            }
        }

        public void listValidating(Button listButton, object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listButton.Enabled)
            {
                string errorMsg;
                if (ValidList(listButton.Text, out errorMsg))
                {
                    //do nothing
                }
                else
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError(listButton, errorMsg);
                }
            }
        }

        private void openWordListButton_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.openWordListButton, "");
        }

        private void openColorListButton_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.openColorListButton, "");
        }

        private void openColorListButton_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (openColorListButton.Enabled)
            {
                listValidating(openColorListButton, sender, e);
            }
        }

        private void openAudioListButton_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (openAudioListButton.Enabled)
            {
                listValidating(openAudioListButton, sender, e);
            }
        }

        private void openAudioListButton_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.openAudioListButton, "");
        }

        private void ColorListOption_CheckedChanged(object sender, EventArgs e)
        {
            stimulusColor.Enabled = false;
            stimulusColorPanel.BackColor = Color.White;
            openColorListButton.Enabled = true;
            stimulusColor.Text = LocRM.GetString("choose", currentCulture);
        }

        private void UniqueColorOption_CheckedChanged(object sender, EventArgs e)
        {
            stimulusColor.Enabled = true;
            openColorListButton.Enabled = false;
            openColorListButton.Text = LocRM.GetString("open", currentCulture);
        }

        private void chooseExpoType_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(chooseExpoType, "");
        }

        private bool validExpoType(int index, out string errorMessage)
        {
            if (index >= 0 && index <= 5)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("expoTypeError", currentCulture);
                return false;
            }
        }

        private void chooseExpoType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!validExpoType(chooseExpoType.SelectedIndex, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.chooseExpoType, errorMsg);
            }
        }

        private void positionsBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(positionsBox, "");
            errorProvider1.SetError(expandImageCheck,"");
        }

        private void positionsBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (expandImageCheck.Checked && positionsBox.SelectedIndex > 0)
            {
                this.errorProvider1.SetError(this.positionsBox, LocRM.GetString("expandImageInvalid", currentCulture));
                this.errorProvider1.SetError(this.expandImageCheck, LocRM.GetString("expandImageInvalid", currentCulture));
                e.Cancel = true;

            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("TRConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void sstCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rndIntervalCheck.Checked && sstCheckBox.Checked)
            {
                rndIntervalCheck.Checked = false;
            }
        }

        private void expandImageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (expandImageCheck.Checked)
            {
                stimuluSize.Enabled = false;
                positionsBox.SelectedIndex = 0;
            }
            else
            {
                stimuluSize.Enabled = true;
            }
        }

        private void rndIntervalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (rndIntervalCheck.Checked)
            {
                sstCheckBox.Checked = false;
            }
        }


    }
}
