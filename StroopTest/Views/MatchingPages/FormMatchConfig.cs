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
            try
            {
                editProgram.readProgramFile(path + Global.programFolderName + editPrgName + ".prg");
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(LocRM.GetString("cantEdìtProgramMissingFiles", currentCulture) + e.Message);
                return;
            }

            if (editProgram.getImageListFile() != null)
            {
                openImgListButton.Text = editProgram.getImageListFile().ListName;
                this.stimuluType.SelectedIndex = 0;
            }
            else if (editProgram.getColorListFile() != null)
            {
                openColorListButton.Text = editProgram.getColorListFile().ListName;
                openWordListButton.Text = editProgram.getWordListFile().ListName;
                this.stimuluType.SelectedIndex = 2;
            }
            else
            {
                openWordListButton.Text = editProgram.getWordListFile().ListName;
                this.stimuluType.SelectedIndex = 1;
            }
            if (editProgram.WordColor != "false")
            {
                wordSingleColor.Text = editProgram.WordColor;
                WordColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.WordColor);
            }
            programName.Text = editProgram.ProgramName;
            stimuluNumber.Value = editProgram.StimuluNumber;
            attemptNumber.Value = editProgram.AttemptsNumber;
            expositionSize.Value = editProgram.StimuluSize;
            randomStimuluPosition.Checked = editProgram.RandomStimulusPosition;
            randomModelPosition.Checked = editProgram.RandomModelPosition;
            closeExpoAWithClick.Checked = editProgram.EndExpositionWithClick;
            stimulusInterval.Value = editProgram.IntervalTime;
            randomAttemptTime.Checked = editProgram.IntervalTimeRandom;
            stimulusExpoTime.Value = editProgram.ExpositionTime;
            modelExpoTime.Value = editProgram.ModelExpositionTime;
            omissionAudioResponse.Checked = editProgram.OmissionAudioResponse;
            commissionAudioFeedback.Checked = editProgram.CommissionAudioResponse;
            attemptInterval.Value = editProgram.AttemptsIntervalTime;
            randomOrder.Checked = editProgram.ExpositionRandom;
            DMTSBackgroundColor.Text = editProgram.BackgroundColor;
            DNMTSBackgroundColor.Text = editProgram.DNMTSBackground;
            DMTSColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.BackgroundColor);
            DNMTSColorPanel.BackColor = ColorTranslator.FromHtml(editProgram.DNMTSBackground);
            feedbackAudioResponse.Checked = editProgram.FeedbackAudioResponse;
            expositonAudioResponse.Checked = editProgram.ExpositionAudioResponse;
            randomModelStimulusTime.Checked = editProgram.RandomIntervalModelStimulus;
            if (editProgram.getExpositionType() == "DMTS")
            {
                this.expositionType.SelectedIndex = 0;
            }
            else if (editProgram.getExpositionType() == "DNMTS")
            {
                this.expositionType.SelectedIndex = 1;
            }
            else if (editProgram.getExpositionType() == LocRM.GetString("alternatingDMTS_DNMTS", currentCulture))
            {
                this.expositionType.SelectedIndex = 2;
            }
            else
            {
                this.expositionType.SelectedIndex = 3;
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
            switch (stimuluType.SelectedIndex)
            {
                case 1:
                    if (openImgListButton.Text != LocRM.GetString("open", currentCulture))
                    {
                        StrList imagesListFile = new StrList(openImgListButton.Text, 0);
                        if (imagesListFile.ListContent.Count < stimuluNumber.Value)
                        {
                            errorProvider1.SetError(openImgListButton, LocRM.GetString("impossibleUseListWarn", currentCulture));
                            errorProvider2.Clear();
                            saveButton.Enabled = false;
                        }
                        else if (imagesListFile.ListContent.Count < attemptNumber.Value * stimuluNumber.Value)
                        {
                            errorProvider2.SetError(openImgListButton, LocRM.GetString("smallImageList", currentCulture));
                            saveButton.Enabled = true;
                        }
                        else
                        {
                            saveButton.Enabled = true;
                        }
                    }
                    break;
                case 2:
                case 3:
                    StrList wordListFile = new StrList(openWordListButton.Text, 2);
                    if (wordListFile.ListContent.Count < stimuluNumber.Value)
                    {
                        errorProvider1.SetError(openWordListButton, LocRM.GetString("impossibleUseListWarn", currentCulture));
                        errorProvider2.Clear();
                        saveButton.Enabled = false;
                    }
                    else if (wordListFile.ListContent.Count < attemptNumber.Value * stimuluNumber.Value)
                    {
                        errorProvider2.SetError(openWordListButton, LocRM.GetString("smallImageList", currentCulture));
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        saveButton.Enabled = true;
                    }
                    break;
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
            return new MatchingProgram(programName.Text, expositionType.Text, Convert.ToInt32(stimuluNumber.Value),
                                        Convert.ToInt32(attemptNumber.Value), Convert.ToInt32(expositionSize.Value), randomModelPosition.Checked,
                                        closeExpoAWithClick.Checked, openImgListButton.Text, Convert.ToInt32(stimulusInterval.Value),
                                        randomAttemptTime.Checked, Convert.ToInt32(stimulusExpoTime.Value), Convert.ToInt32(modelExpoTime.Value),
                                        Convert.ToInt32(attemptInterval.Value), DMTSBackgroundColor.Text, DNMTSBackgroundColor.Text, randomOrder.Checked,
                                        this.randomModelStimulusTime.Checked, randomStimuluPosition.Checked, openWordListButton.Text,
                                        openColorListButton.Text, wordSingleColor.Text, expositonAudioResponse.Checked, 
                                        feedbackAudioResponse.Checked, omissionAudioResponse.Checked, commissionAudioFeedback.Checked);
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
            else
            {
                /*do nothing*/
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
            if(this.expositionType.SelectedIndex >= 0 && this.expositionType.SelectedIndex < 4)
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
            this.errorProvider1.Clear();
            this.errorProvider2.Clear();
            if(this.expositionType.SelectedIndex > 3)
            {
                this.errorProvider1.SetError(this.expositionType, LocRM.GetString("unavailableExpo", currentCulture));
            }
            else
            {
                this.errorProvider1.SetError(this.expositionType, "");
            }
            if (this.expositionType.SelectedIndex == 0)
            {
                DMTSBackgroundLabel.Enabled = true;
                DMTSColorPanel.Enabled = true;
                DMTSBackgroundColor.Enabled = true;
                DMTSBackground.Enabled = true;
                DNMTSBackgroundLabel.Enabled = false;
                DNMTSColorPanel.Enabled = false;
                DNMTSBackgroundColor.Enabled = false;
                DNMTSBackground.Enabled = false;
            }
            else if (this.expositionType.SelectedIndex == 1)
            {
                DMTSBackgroundLabel.Enabled = false;
                DMTSColorPanel.Enabled = false;
                DMTSBackgroundColor.Enabled = false;
                DMTSBackground.Enabled = false;
                DNMTSBackgroundLabel.Enabled = true;
                DNMTSColorPanel.Enabled = true;
                DNMTSBackgroundColor.Enabled = true;
                DNMTSBackground.Enabled = true;
            }
            else if (this.expositionType.SelectedIndex == 2 || this.expositionType.SelectedIndex == 3)
            {
                DMTSBackgroundLabel.Enabled = true;
                DMTSColorPanel.Enabled = true;
                DMTSBackgroundColor.Enabled = true;
                DMTSBackground.Enabled = true;
                DNMTSBackgroundLabel.Enabled = true;
                DNMTSColorPanel.Enabled = true;
                DNMTSBackgroundColor.Enabled = true;
                DNMTSBackground.Enabled = true;
            }
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

        private bool ValidWordList(string buttonText, out string errorMessage)
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
        private bool ValidColorList(string buttonText, out string errorMessage)
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
        private bool ValidImgList(string buttonText, out string errorMessage)
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
        private bool ValidAudioList(string buttonText, out string errorMessage)
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

        private void attemptAndNumExpo_ValueChanged(object sender, EventArgs e)
        {
            checkNewValue();
        }

        public static Icon ResizeWarningIcon(Icon icon, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(icon.ToBitmap(), new Rectangle(Point.Empty, size));
            }
            return Icon.FromHandle(bitmap.GetHicon());
        }

        private void checkNewValue()
        {
            Button button = null;
            int type = -1;
            if (openImgListButton.Text != LocRM.GetString("open", currentCulture) || openWordListButton.Text != LocRM.GetString("open", currentCulture))
            {
                if (openImgListButton.Text != LocRM.GetString("open", currentCulture))
                {
                    button = openImgListButton;
                    type = StrList.IMAGE;
                }
                else
                {
                    button = openWordListButton;
                    type = StrList.WORD;
                }
                if(button == null)
                {
                    return;
                }
                StrList listFile = new StrList(button.Text, type);
                if (listFile.ListContent.Count < stimuluNumber.Value)
                {
                    errorProvider1.SetError(button, LocRM.GetString("impossibleUseListWarn", currentCulture));
                    errorProvider2.Clear();
                    saveButton.Enabled = false;
                }
                else if (listFile.ListContent.Count < attemptNumber.Value * stimuluNumber.Value)
                {
                    errorProvider2.SetError(button, LocRM.GetString("smallImageList", currentCulture));
                    saveButton.Enabled = true;
                }
                else
                {
                    errorProvider1.SetError(button, "");
                    errorProvider2.SetError(button, "");
                    saveButton.Enabled = true;
                }
            }
            else if (button != null)
            {
                errorProvider1.SetError(button, "");
                errorProvider2.SetError(button, "");
                saveButton.Enabled = true;
            }
        }

        private void randomModelStimulusTime_CheckedChanged(object sender, EventArgs e)
        {
            if (randomModelStimulusTime.Checked)
            {
                this.stimulusInterval.Minimum = 400;
                if(this.stimulusInterval.Value < 400)
                {
                    this.stimulusInterval.Value = 400;
                }
            }
            else
            {
                this.stimulusInterval.Minimum = 100;
            }
        }

        private void randomAttemptTime_CheckedChanged(object sender, EventArgs e)
        {
            if (randomAttemptTime.Checked)
            {
                this.attemptInterval.Minimum = 400;
                if (this.attemptInterval.Value < 400)
                {
                    this.attemptInterval.Value = 400;
                }
            }
            else
            {
                this.attemptInterval.Minimum = 100;
            }
        }

        private void stimuluType_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.stimuluType, "");
        }

        private bool validStimuluType(int selectedIndex, out string errorMessage)
        {
            if (selectedIndex >= 0 && selectedIndex <= 2)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = LocRM.GetString("unavailableExpo", currentCulture);
                return false;
            }
        }

        private void stimuluType_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (validStimuluType(stimuluType.SelectedIndex, out errorMsg))
            {
                //do nothing
            }
            else
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.stimuluType, errorMsg);
            }
        }

        private void stimuluType_SelectedIndexChanged(object sender, EventArgs e)
        {
        ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        CultureInfo currentCulture = CultureInfo.CurrentUICulture;
            if (stimuluType.SelectedIndex == 0) /* image exposition*/
            {
                openWordListButton.Enabled = false;
                openColorListButton.Enabled = false;
                openImgListButton.Enabled = true;
                openWordListButton.Text = LocRM.GetString("open", currentCulture);
                openColorListButton.Text = LocRM.GetString("open", currentCulture);
                wordSingleColorLabel.Enabled = false;
                wordSingleColorButton.Enabled = false;
                WordColorPanel.Enabled = false;
                wordSingleColor.Enabled = false;
                expositionSize.Maximum = 500;
                expositionSize.Value = 250;
            }
            else if (stimuluType.SelectedIndex == 1) /* word exposition*/
            {
                openWordListButton.Enabled = true;
                openColorListButton.Enabled = false;
                openImgListButton.Enabled = false;
                openColorListButton.Text = LocRM.GetString("open", currentCulture);
                openImgListButton.Text = LocRM.GetString("open", currentCulture);
                wordSingleColorLabel.Enabled = true;
                wordSingleColorButton.Enabled = true;
                WordColorPanel.Enabled = true;
                wordSingleColor.Enabled = true;
                expositionSize.Maximum = 50;
                expositionSize.Value = 18;
            }
            else if (stimuluType.SelectedIndex == 2) /* word and color exposition */
            {
                openWordListButton.Enabled = true;
                openColorListButton.Enabled = true;
                openImgListButton.Enabled = false;
                openImgListButton.Text = LocRM.GetString("open", currentCulture);
                wordSingleColorLabel.Enabled = false;
                wordSingleColorButton.Enabled = false;
                WordColorPanel.Enabled = false;
                wordSingleColor.Enabled = false;
                expositionSize.Maximum = 50;
                expositionSize.Value = 18;
            }
        }

        private void wordSingleColorButton_Click(object sender, EventArgs e)
        {
            string colorCode = ListController.PickColor(this);
            WordColorPanel.BackColor = ColorTranslator.FromHtml(colorCode);
            wordSingleColor.Text = colorCode;
        }

        private void openImgListButton_TextChanged(object sender, EventArgs e)
        {
            showWarningMessage(openImgListButton);
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
                else if (button.Name == "openWordsList")
                {
                    ListFile = new StrList(button.Text, 2);
                }
                if (ListFile != null && ListFile.ListContent.Count < stimuluNumber.Value)
                {
                    saveButton.Enabled = false;
                    errorProvider1.SetError(button, LocRM.GetString("impossibleUseListWarn", currentCulture));
                    errorProvider2.Clear();
                }
                else if (ListFile != null && ListFile.ListContent.Count < attemptNumber.Value * stimuluNumber.Value)
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

        private void openWordListButton_TextChanged(object sender, EventArgs e)
        {
            showWarningMessage(openWordListButton);
        }

        private void closeExpoAWithClick_CheckedChanged(object sender, EventArgs e)
        {
            if (this.closeExpoAWithClick.Checked)
            {
                this.commissionAudioFeedback.Enabled = false;
                this.commissionAudioFeedback.Checked = false;
            }
            else
            {
                this.commissionAudioFeedback.Enabled = true;
            }
        }
    }
}
