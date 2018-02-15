using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using TestPlatform.Models;
using TestPlatform.Controllers;
using System.IO;

namespace TestPlatform.Views.MatchingPages
{
    public partial class FormMatchConfig : UserControl
    {
        private String instructionBoxText;

        private String path = Global.matchingTestFilesPath;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private String editPrgName = "false";
        private String prgName = "false";
        public FormMatchConfig(string prgName)
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

        private void editProgram()
        {
            MatchingProgram editProgram = new MatchingProgram();
            editProgram.readProgramFile(path + Global.programFolderName + editPrgName + ".prg");

            programName.Text = editProgram.ProgramName;
            numExpo.Value = editProgram.NumExpositions;
            attemptNumber.Value = editProgram.AttemptsNumber;
            expositionSize.Value = editProgram.StimuluSize;
            randomPosition.Checked = editProgram.RandomPosition;
            closeExpoAWithClick.Checked = editProgram.EndExpositionWithClick;
            openImgListButton.Text = editProgram.getImageListFile().ListName;
            stimulusInterval.Value = editProgram.IntervalTime;
            randomAttemptTime.Checked = editProgram.IntervalTimeRandom;
            stimulusExpoTime.Value = editProgram.ExpositionTime;
            modelExpoTime.Value = editProgram.ModelExpositionTime;
            attemptInterval.Value = editProgram.AttemptsIntervalTime;
            DMTSBackgroundColor.Text = editProgram.BackgroundColor;
            randomOrder.Checked = editProgram.ExpositionRandom;
            DNMTSBackgroundColor.Text = editProgram.DNMTSBackground;
            DMTSColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.BackgroundColor);
            DNMTSColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.DNMTSBackground);
            switch (editProgram.getExpositionType())
            {
                case "DMTS":
                    this.expositionType.SelectedIndex = 0;
                    break;
                case "DNMTS":
                    this.expositionType.SelectedIndex = 1;
                    break;
                case "DMTS / DNMTS":
                    this.expositionType.SelectedIndex = 2;
                    break;
            }
            switch (editProgram.Disposition){
                case "padrao":
                case "default":
                    ExpoDisposition.SelectedIndex = 0;
                    break;
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
                instructionsBox.Text = "";
            }

            switch (editProgram.getExpositionType())
            {
                case "DMTS":
                    expositionType.SelectedIndex = 0;
                    break;
                case "DNMTS":
                    expositionType.SelectedIndex = 1;
                    break;
                case "DMTS/DNMTS":
                    expositionType.SelectedIndex = 2;
                    break;
                default:
                    throw new Exception(LocRM.GetString("expoType", currentCulture) + editProgram.getExpositionType() + LocRM.GetString("invalid", currentCulture));
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("MatchConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void programName_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(programName, "");
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

        private void programName_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidProgramName(programName.Text, out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(programName, errorMsg);
            }
        }

        MatchingProgram configureNewProgram()
        {
            return new MatchingProgram(programName.Text, expositionType.Text, ExpoDisposition.Text, Convert.ToInt32(numExpo.Value),
                                        Convert.ToInt32(attemptNumber.Value), Convert.ToInt32(expositionSize.Value), randomPosition.Checked,
                                        closeExpoAWithClick.Checked, openImgListButton.Text, Convert.ToInt32(stimulusInterval.Value), 
                                        randomAttemptTime.Checked, Convert.ToInt32(stimulusExpoTime.Value), Convert.ToInt32(modelExpoTime.Value),
                                        Convert.ToInt32(attemptInterval.Value), DMTSBackgroundColor.Text, DNMTSBackgroundColor.Text, randomOrder.Checked, 0, 0);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                bool hasToSave = true;
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    MatchingProgram newProgram = configureNewProgram();

                    if (File.Exists(path + Global.programFolderName + programName.Text + ".prg"))
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
            }
            else
            {
                MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
            }
        }

        private void expositionType_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!validExpositionType(out errorMsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(expositionType, errorMsg);
            }
        }

        private bool validExpositionType(out string errorMessage)
        {
            if(this.expositionType.SelectedIndex >= 0 && this.expositionType.SelectedIndex < 1)
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

        private void expositionType_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(expositionType, "");
        }

        private void expositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.expositionType.SelectedIndex > 0)
            {
                this.errorProvider1.SetError(this.expositionType, LocRM.GetString("unavailableExpo", currentCulture));
            }
            else
            {
                this.errorProvider1.SetError(this.expositionType, "");
            }
        }

        private void ExpoDisposition_Validating(object sender, CancelEventArgs e)
        {
            if(this.ExpoDisposition.SelectedIndex == -1)
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.ExpoDisposition, LocRM.GetString("dispositionError", currentCulture));
            }
        }

        private void ExpoDisposition_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.ExpoDisposition, "");
        }

        private void DMTSBackground_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            DMTSColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
            DMTSBackgroundColor.Text = colorCode;
        }

        private void DMNTSBackground_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            DNMTSColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
            DNMTSBackgroundColor.Text = colorCode;
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
            if (openImgListButton.Text != LocRM.GetString("open", currentCulture))
            {
                StrList imagesListFile = new StrList(openImgListButton.Text, 0);
                if (imagesListFile.ListContent.Count < attemptNumber.Value * numExpo.Value)
                {
                    label10.Visible = true;
                }
                else
                {
                    label10.Visible = false;
                }
            }
            else
            {
                label10.Visible = false;
            }
        }

        private void openAudioList_Click(object sender, EventArgs e)
        {
            openAudioListButton.Text = ListController.OpenListFile("_audio", openAudioListButton.Text, "dir");
        }

        private void listGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void openWordListButton_Validating(object sender, CancelEventArgs e)
        {
            if (openWordListButton.Enabled)
            {
                string errorMsg;
                if (ValidWordList(openWordListButton.Text, out errorMsg))
                {
                    //do nothing
                }
                else
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError(this.openWordListButton, errorMsg);
                }
            }
        }

        public bool ValidWordList(string buttonText, out string errorMessage)
        {
            if (buttonText.Length != 0 && buttonText != LocRM.GetString("open", currentCulture))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("wordListError", currentCulture);
                return false;
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

        private void openImgListButton_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.openImgListButton, "");
        }

        private void openAudioListButton_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.openAudioListButton, "");
        }

        private void openColorListButton_Validating(object sender, CancelEventArgs e)
        {
            if (openColorListButton.Enabled)
            {
                string errorMsg;
                if (ValidColorList(openColorListButton.Text, out errorMsg))
                {
                    //do nothing
                }
                else
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError(this.openColorListButton, errorMsg);
                }
            }
        }
        public bool ValidColorList(string buttonText, out string errorMessage)
        {
            if (buttonText.Length != 0 && buttonText != LocRM.GetString("open", currentCulture))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("colorListError", currentCulture);
                return false;
            }
        }
        public bool ValidImgList(string buttonText, out string errorMessage)
        {
            if (buttonText.Length != 0 && buttonText != LocRM.GetString("open", currentCulture))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("imgListError", currentCulture);
                return false;
            }
        }
        public bool ValidAudioList(string buttonText, out string errorMessage)
        {
            if (buttonText.Length != 0 && buttonText != LocRM.GetString("open", currentCulture))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("colorListError", currentCulture);
                return false;
            }
        }

        private void openImgListButton_Validating(object sender, CancelEventArgs e)
        {
            if (openImgListButton.Enabled)
            {
                string errorMsg;
                if (ValidImgList(openImgListButton.Text, out errorMsg))
                {
                    //do nothing
                }
                else
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError(this.openImgListButton, errorMsg);
                }
            }
        }

        private void openAudioListButton_Validating(object sender, CancelEventArgs e)
        {
            if (openAudioListButton.Enabled)
            {
                string errorMsg;
                if (ValidAudioList(openAudioListButton.Text, out errorMsg))
                {
                    //do nothing
                }
                else
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError(this.openAudioListButton, errorMsg);
                }
            }
        }

        private void numExpo_ValueChanged(object sender, EventArgs e)
        {
            if (openImgListButton.Text != LocRM.GetString("open", currentCulture))
            {
                StrList imagesListFile = new StrList(openImgListButton.Text, 0);
                if (imagesListFile.ListContent.Count < attemptNumber.Value * numExpo.Value)
                {
                    label10.Visible = true;
                }
                else
                {
                    label10.Visible = false;
                }
            }
            else
            {
                label10.Visible = false;
            }
        }

        private void attemptNumber_ValueChanged(object sender, EventArgs e)
        {
            if (openImgListButton.Text != LocRM.GetString("open", currentCulture))
            {
                StrList imagesListFile = new StrList(openImgListButton.Text, 0);
                if (imagesListFile.ListContent.Count < attemptNumber.Value * numExpo.Value)
                {
                    label10.Visible = true;
                }
                else
                {
                    label10.Visible = false;
                }
            }
            else
            {
                label10.Visible = false;
            }
        }
    }
}
