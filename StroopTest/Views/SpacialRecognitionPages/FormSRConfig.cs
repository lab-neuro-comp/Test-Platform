using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Models.Tests.SpacialRecognition;
using System.Resources;
using System.Globalization;
using TestPlatform.Controllers;
using TestPlatform.Models;

namespace TestPlatform.Views.SpecialRecognitionPages
{
    public partial class FormSRConfig : UserControl
    {
        private String instructionBoxText;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private String editPrgName = "false";
        private String prgName = "false";
        public String PrgName
        {
            set
            {
                this.prgName = value;
            }
        }
        public FormSRConfig(string prgName)
        {
            this.prgName = prgName;
            instructionBoxText = LocRM.GetString("instructionBox", currentCulture);
            InitializeComponent();

            if (prgName != "false")
            {
                editPrgName = prgName;
                editProgram();
            }
        }

        private void editProgram()
        {
            SpacialRecognitionProgram editProgram = new SpacialRecognitionProgram(editPrgName);
            prgNameTextBox.Text = editProgram.ProgramName;
            numExpo.Value = editProgram.NumExpositions;
            isRandomExposition.Checked = editProgram.ExpositionRandom;
            if (editProgram.getWordListFile() != null) openWordListButton.Text = editProgram.getWordListFile().ListName;
            if (editProgram.getColorListFile() != null) openColorListButton.Text = editProgram.getColorListFile().ListName;
            if (editProgram.getImageListFile() != null) openImgListButton.Text = editProgram.getImageListFile().ListName;
            stimulusExpoTime.Value = editProgram.ExpositionTime;
            attemptInterval.Value = editProgram.IntervalTime;
            randomAttemptTime.Checked = editProgram.IntervalTimeRandom;
            chooseExpoType.SelectedIndex = editProgram.StimuluType;
            stimuluSize.Value = (decimal)editProgram.StimuluSize;
            fontSizeUpDown.Value = editProgram.FontSize;
            stimuluQuantity.Value = editProgram.StimuluCount;
            if(editProgram.StimuluSingleColor != "false")
            {
                wordSingleColor.Text = editProgram.StimuluSingleColor;
                WordColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.StimuluSingleColor);
            }
            stimulusInterval.Value = editProgram.StimuluDelay;
            randomStimulusTime.Checked = editProgram.StimuluDelayRandom;
            expositonAudioResponse.Checked = editProgram.PlayExpositionSound;
            omissionAudioResponse.Checked = editProgram.PlayOmissionSound;
            clickAudioResponse.Checked = editProgram.PlayClickSound;
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
                instructionsBox.Text = "";
            }
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


        private void chooseExpoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((sender as ComboBox).SelectedIndex == 0) /* Image */
            {
                openColorListButton.Enabled = false;
                openColorListButton.Text = LocRM.GetString("open", currentCulture);
                openImgListButton.Enabled = true;
                openWordListButton.Enabled = false;
                openWordListButton.Text = LocRM.GetString("open", currentCulture);
                stimuluSize.Enabled = true;
                fontSizeUpDown.Enabled = false;
                wordSingleColorButton.Enabled = false;
                wordSingleColor.Enabled = false;
                wordSingleColorLabel.Enabled = false;
            }
            else if ((sender as ComboBox).SelectedIndex == 1)
            { /* Word */
                openColorListButton.Enabled = false;
                openColorListButton.Text = LocRM.GetString("open", currentCulture);
                openImgListButton.Enabled = false;
                openImgListButton.Text = LocRM.GetString("open", currentCulture);
                openWordListButton.Enabled = true;
                stimuluSize.Enabled = false;
                fontSizeUpDown.Enabled = true;
                wordSingleColorButton.Enabled = true;
                wordSingleColor.Enabled = true;
                wordSingleColorLabel.Enabled = true;
            }
            else
            { /* Word and color */
                openColorListButton.Enabled = true;
                openImgListButton.Enabled = false;
                openImgListButton.Text = LocRM.GetString("open", currentCulture);
                openWordListButton.Enabled = true;
                stimuluSize.Enabled = false;
                fontSizeUpDown.Enabled = true;
                wordSingleColorButton.Enabled = false;
                wordSingleColor.Enabled = false;
                wordSingleColorLabel.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        void showWarningMessage(Button button)
        {
            StrList ListFile = null;
            if (button.Text != LocRM.GetString("open", currentCulture) && button.Text != LocRM.GetString("createNewList", currentCulture))
            {
                if (button.Name == "openImgListButton")
                {
                    ListFile = new StrList(button.Text, 0);
                }
                else if (button.Name == "openWordListButton")
                {
                    ListFile = new StrList(button.Text, 2);
                }
                if (ListFile != null && ListFile.ListContent.Count < this.numExpo.Value * this.stimuluQuantity.Value)
                {
                    errorProvider2.SetError(button, LocRM.GetString("smallImageList", currentCulture));
                    saveButton.Enabled = true;
                }
                else
                {
                    errorProvider2.SetError(button, "");
                    saveButton.Enabled = true;
                }
            }
            else
            {
                errorProvider2.SetError(button, "");
                saveButton.Enabled = true;
            }
        }

        SpacialRecognitionProgram configureNewProgram()
        {
            return new SpacialRecognitionProgram(
                    this.prgNameTextBox.Text, (int)this.numExpo.Value, this.isRandomExposition.Checked,
                    openWordListButton.Text, openColorListButton.Text, openImgListButton.Text,
                    (int)this.stimulusExpoTime.Value, (int)this.attemptInterval.Value, this.randomAttemptTime.Checked,
                    this.chooseExpoType.SelectedIndex, (float)this.stimuluSize.Value, (int)this.fontSizeUpDown.Value,
                    (int)this.stimuluQuantity.Value, this.wordSingleColor.Text, (int)this.stimulusInterval.Value,
                    this.randomStimulusTime.Checked, this.expositonAudioResponse.Checked,
                    this.omissionAudioResponse.Checked, this.clickAudioResponse.Checked);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveButton.Enabled)
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    bool hasToSave = true;
                    if (this.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        SpacialRecognitionProgram newProgram = configureNewProgram();

                        if (SpacialRecognitionProgram.ProgramExists(prgNameTextBox.Text))
                        {
                            DialogResult dialogResult = MessageBox.Show(LocRM.GetString("programExists", currentCulture), "", MessageBoxButtons.OKCancel);
                            if (dialogResult == DialogResult.Cancel)
                            {
                                hasToSave = false;
                                MessageBox.Show(LocRM.GetString("programNotSave", currentCulture));
                            }
                        }
                        if (hasToSave && newProgram.saveProgramFile(instructionsBox.Text))
                        {
                            MessageBox.Show(LocRM.GetString("programSave", currentCulture));
                        }
                        this.Parent.Controls.Remove(this);
                    }
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
                }
            }
            else
            {
                /*do nothing*/
            }
        }

        private void chooseExpoType_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(chooseExpoType, "");
        }

        private void chooseExpoType_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validExpositionType(out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(chooseExpoType, errorMsg);
            }
        }

        private void wordSingleColorButton_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            WordColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
            wordSingleColor.Text = colorCode;
        }

        private bool validExpositionType(out string errorMessage)
        {
            if (this.chooseExpoType.SelectedIndex >= 0 && this.chooseExpoType.SelectedIndex < 3)
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

        private void openListButton_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, "");
        }

        private bool ValidList(string buttonText, out string errorMessage)
        {
            if (buttonText.Length != 0 && buttonText != LocRM.GetString("open", currentCulture))
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

        private void openListButton_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as Control).Enabled)
            {
                string errorMsg;
                if (ValidList((sender as Control).Text, out errorMsg))
                {
                    //do nothing
                }
                else
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError((sender as Control), errorMsg);
                }
            }
        }

        private void openWordListButton_Click(object sender, EventArgs e)
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

        private void prgNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidProgramName(prgNameTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(prgNameTextBox, errorMsg);
            }
        }

        private bool ValidProgramName(string pgrName, out string errorMessage)
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

        private void prgNameTextBox_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(prgNameTextBox, "");
        }

        private void openListButton_TextChanged(object sender, EventArgs e)
        {
            showWarningMessage(sender as Button);
        }

        private void numExpo_ValueChanged(object sender, EventArgs e)
        {
            showWarningMessage(openWordListButton);
            showWarningMessage(openImgListButton);
        }
    }
}
