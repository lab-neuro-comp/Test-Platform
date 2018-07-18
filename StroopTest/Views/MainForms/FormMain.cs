/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */
namespace TestPlatform
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Resources;
    using System.Windows.Forms;
    using TestPlatform.Controllers;
    using TestPlatform.Models;
    using TestPlatform.Models.General;
    using TestPlatform.Views;
    using TestPlatform.Views.ExperimentPages;
    using TestPlatform.Views.ParticipantPages;
    using TestPlatform.Views.ReactionPages;
    using TestPlatform.Views.SidebarControls;
    using TestPlatform.Views.SidebarUserControls;
    using Views.MainForms;

    public partial class FormMain : Form
    {

        public Panel _contentPanel;
        /* Variables
         */
        //holds current panel in exact execution time
        private Control currentPanelContent;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

        /**
         * Constructor method, creates directories for program, in case they dont exist
         * */
        public FormMain()
        {
            InitializeComponent();
            FileManipulation.Instance(this);
            initializeParticipants();
 
            _contentPanel = contentPanel;
        }

        public void initializeParticipants()
        {
            string[] filePaths = Participant.GetAllParticipants();
            participantComboBox.Items.Clear();
            foreach (string file in filePaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                participantComboBox.Items.Add(fileName);
            }
            participantComboBox.Items.Add(LocRM.GetString("createNewParticipant", currentCulture));
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R) // Ctrl+R - roda teste
            {
                ExpositionController.BeginStroopTest(executingNameLabel.Text, participantComboBox.Text, markTextBox.Text[0], this);
            }
            if (e.Control && e.KeyCode == Keys.D) // Ctrl+D - define programa
            {
                defineTest();
            }
            if (e.Control && e.KeyCode == Keys.N) // Ctrl+N - novo programa
            {
                newProgram();
            }
            if (e.Control && e.KeyCode == Keys.H) // Ctrl+H - intruções / ajuda
            {
                HelpPagesController.showInstructions();
            }
        }



        private void newTextColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWordColorConfig configureList = new FormWordColorConfig(false);
            try
            {
                this.contentPanel.Controls.Add(configureList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpPagesController.showAboutBox();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpPagesController.showInstructions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void defineProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defineTest();
        }
        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImgConfig configureImagesList = new FormImgConfig("false");
            try
            {
                this.contentPanel.Controls.Add(configureImagesList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void editProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editTextColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWordColorConfig configureList = new FormWordColorConfig(true);
            try
            {
                this.contentPanel.Controls.Add(configureList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void startTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpositionController.BeginStroopTest(executingNameLabel.Text, participantComboBox.Text, markTextBox.Text[0], this);
        }


        private void defineTest()
        {
            FormDefineTest defineTest = new FormDefineTest(CultureInfo.CurrentUICulture);
            try
            {
                var result = defineTest.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string progName = defineTest.returnValues[1];
                    executingNameLabel.Text = progName;
                    executingTypeLabel.Text = defineTest.returnValues[0];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void newProgram()
        {

            FormPrgConfig configureProgram = new FormPrgConfig("false");
            this.Controls.Add(configureProgram);
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData showData;
            try
            {
                showData = new FormShowData();
                this.contentPanel.Controls.Add(showData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImgConfig configureImagesList = new FormImgConfig("");
            try { this.contentPanel.Controls.Add(configureImagesList); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudioConfig configureAudioList = new FormAudioConfig(false);
            try
            {
                this.contentPanel.Controls.Add(configureAudioList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void techInfoButto_ToolStrip_Click(object sender, EventArgs e)
        {
            HelpPagesController.showTechInfo();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpPagesController.showHelp();
        }

        private void editAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudioConfig configureAudioList = new FormAudioConfig(true);
            try
            {
                this.contentPanel.Controls.Add(configureAudioList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void openShowAudioForm()
        {
            FormShowAudio showAudio;
            try
            {
                showAudio = new FormShowAudio();
                this.Controls.Add(showAudio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayAudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openShowAudioForm();
        }

        private void newAudioToolStripMenu_Click(object sender, EventArgs e)
        {
            openShowAudioForm();
        }

        private void experimentButton_CheckedChanged(object sender, EventArgs e)
        {
            if (experimentButton.Checked)
            {
                // removing second side bar from view, if there is one, and removing its context too
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();

                ExperimentControl experimentControl = new ExperimentControl();
                this.sideBarPanel.Controls.Add(experimentControl);
                currentPanelContent = experimentControl;
            }
        }

        private void buttonStroop_Click(object sender, EventArgs e)
        {

            if (buttonStroop.Checked)
            {
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();

                StroopControl stroopControl = new StroopControl();
                this.sideBarPanel.Controls.Add(stroopControl);
                currentPanelContent = stroopControl;
            }
        }

        private void buttonReaction_Click(object sender, EventArgs e)
        {
            if (buttonReaction.Checked)
            {
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();

                ReactionControl reactControl = new ReactionControl();
                this.sideBarPanel.Controls.Add(reactControl);
                currentPanelContent = reactControl;
            }

        }

        private void buttonList_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonList.Checked)
            {
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();

                ListUserControl listControl = new ListUserControl();
                this.sideBarPanel.Controls.Add(listControl);
                currentPanelContent = listControl;
            }
        }

        private void resultButton_CheckedChanged(object sender, EventArgs e)
        {
            if (resultButton.Checked)
            {
                // removing second side bar from view, if there is one, and removing its context too
                if (sideBarPanel.Controls.Count > 0)
                {
                    sideBarPanel.Controls.Remove(currentPanelContent);
                    contentPanel.Controls.Clear();
                }
                else
                {
                    /*do nothing*/
                }
                ResultsUserControl resultsControl = new ResultsUserControl();
                this.sideBarPanel.Controls.Add(resultsControl);
                currentPanelContent = resultsControl;
            }
        }


        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            List<Control> controls = new List<Control>();

            if (e.Control.GetType().BaseType == typeof(UserControl))
            {
                int count = 0;
                foreach (Control c in Controls)
                {
                    if (!(c.Equals(currentPanelContent)) && c is UserControl)
                    {
                        controls.Add(c);
                        count++;
                    }
                }
                if (count > 1)
                {
                    Controls.Remove(controls[0]);

                }
            }
        }

        private void stroopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrgConfig configureProgram = new FormPrgConfig("false");
            this.contentPanel.Controls.Add(configureProgram);
        }

        private void reactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTRConfig configureProgram = new FormTRConfig("false");
            this.contentPanel.Controls.Add(configureProgram);
        }

        private void stroopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";

            try
            {
                defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), 
                    StroopProgram.GetProgramsPath(), "prg", "program", false, false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    FormPrgConfig configureProgram = new FormPrgConfig(editProgramName);
                    this.Controls.Add(configureProgram);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";
            
                defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), ReactionProgram.GetProgramsPath(), "prg", "program", false, false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    FormTRConfig configureProgram = new FormTRConfig(editProgramName);
                    configureProgram.PrgName = editProgramName;
                    this.Controls.Add(configureProgram);
                }


        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (FileManipulation.GlobalFormMain.contentPanel.Controls.Count > 0)
            {
                checkSave();
            }
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                if (executingTypeLabel.Text.Equals(LocRM.GetString("stroopTest", currentCulture)))
                {
                    ExpositionController.BeginStroopTest(executingNameLabel.Text, participantComboBox.Text, markTextBox.Text[0], this);
                }

                else if (executingTypeLabel.Text.Equals(LocRM.GetString("reactionTest", currentCulture)))
                {
                    ExpositionController.BeginReactionTest(executingNameLabel.Text, participantComboBox.Text, markTextBox.Text[0], this);
                }
                else if (executingTypeLabel.Text.Equals(LocRM.GetString("experiment", currentCulture)))
                {
                    ExpositionController.BeginExperimentTest(executingNameLabel.Text, participantComboBox.Text, markTextBox.Text[0], this);
                }
                else if (executingTypeLabel.Text.Equals(LocRM.GetString("matchingTest", currentCulture)))
                {
                    ExpositionController.BeginMatchingTest(executingNameLabel.Text, participantComboBox.Text, markTextBox.Text[0], this);
                }
                else
                {
                    /* do nothing*/
                }
            }
        }

        private void checkSave()
        {
            if (FileManipulation.GlobalFormMain.contentPanel.Controls[0] is FormTRConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormTRConfig toSave = (FormTRConfig)(FileManipulation.GlobalFormMain.contentPanel.Controls[0]);
                    toSave.save();
                }
                else
                {
                    /*do nothing*/
                }
            }
            else if (FileManipulation.GlobalFormMain.contentPanel.Controls[0] is ExperimentConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ExperimentConfig toSave = (ExperimentConfig)(FileManipulation.GlobalFormMain.contentPanel.Controls[0]);
                    toSave.save();
                }
                else
                {
                    /*do nothing*/
                }
            }
            else if (FileManipulation.GlobalFormMain.contentPanel.Controls[0] is FormPrgConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormPrgConfig toSave = (FormPrgConfig)(FileManipulation.GlobalFormMain.contentPanel.Controls[0]);
                    toSave.save();
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            defineTest();
        }

        private void participantTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(participantComboBox, "");
        }

        public bool ValidParticipantName(string participantName, out string errorMessage)
        {
            if (participantName.Length == 0)
            {
                errorMessage = LocRM.GetString("participantNameLengthError", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void participantTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (ValidParticipantName(participantComboBox.Text, out errorMsg))
            {
                /* field is valid */
            }
            else
            {
                e.Cancel = true;
                this.errorProvider1.SetError(participantComboBox, errorMsg);
            }
        }

        private void markTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(markTextBox, "");
        }

        public bool ValidMark(string mark, out string errorMessage)
        {
            if (mark.Length == 0)
            {
                errorMessage = LocRM.GetString("markLengthError", currentCulture);
                return false;
            }
            if (mark.Length > 1)
            {
                errorMessage = LocRM.GetString("markLengthError2", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void markTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (ValidMark(markTextBox.Text, out errorMsg))
            {
                /* field is valid */
            }
            else
            {
                e.Cancel = true;
                this.errorProvider1.SetError(markTextBox, errorMsg);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void menuPanel_Click(object sender, EventArgs e)
        {
            sideBarPanel.Controls.Clear();
            contentPanel.Controls.Clear();
        }

        private void reactionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReactionResultUserControl showData;
            try
            {
                showData = new ReactionResultUserControl();
                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(showData);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void experimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExperimentResultUserControl showData = new ExperimentResultUserControl();
                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(showData);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void portuguêsBrasilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (englishUnitedStatesToolStripMenuItem.Checked || spanishSpainToolStripMenuItem.Checked)
            {
                currentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
                englishUnitedStatesToolStripMenuItem.Checked = false;
                System.Threading.Thread.CurrentThread.CurrentUICulture = currentCulture;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMain));
                resources.ApplyResources(this, "$this");
                ApplyResources(resources, this.Controls);
            }
            portuguêsBrasilToolStripMenuItem.Checked = true;
        }

        private void englishUnitedStatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (portuguêsBrasilToolStripMenuItem.Checked || spanishSpainToolStripMenuItem.Checked)
            {
                currentCulture = CultureInfo.CreateSpecificCulture("en-US");
                portuguêsBrasilToolStripMenuItem.Checked = false;
                System.Threading.Thread.CurrentThread.CurrentUICulture = currentCulture;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMain));
                resources.ApplyResources(this, "$this");
                ApplyResources(resources, this.Controls);
                ApplyToolStripResources(resources, mainMenuStrip.Items);
            }
            englishUnitedStatesToolStripMenuItem.Checked = true;
        }

        private void spanishSpainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (portuguêsBrasilToolStripMenuItem.Checked || englishUnitedStatesToolStripMenuItem.Checked)
            {
                currentCulture = CultureInfo.CreateSpecificCulture("es-ES");
                portuguêsBrasilToolStripMenuItem.Checked = false;
                System.Threading.Thread.CurrentThread.CurrentUICulture = currentCulture;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMain));
                resources.ApplyResources(this, "$this");
                ApplyResources(resources, this.Controls);
                ApplyToolStripResources(resources, mainMenuStrip.Items);
            }
        }

        private void ApplyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                ApplyResources(resources, ctl.Controls);
            }
        }

        private void ApplyToolStripResources(ComponentResourceManager resources, ToolStripItemCollection toolStrip)
        {
            foreach (ToolStripItem item in toolStrip)
            //for each object.
            {
                ToolStripMenuItem subMenu = item as ToolStripMenuItem;
                resources.ApplyResources(item, item.Name);
                //Try cast to ToolStripMenuItem as it could be toolstrip separator as well.

                if (subMenu != null)
                //if we get the desired object type.
                {
                    resources.ApplyResources(item, item.Name);
                    // if subMenu has children call recursive method
                    if (subMenu.HasDropDownItems)
                    {
                        ApplyToolStripResources(resources, subMenu.DropDownItems);
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (exportButton.Checked)
            {
                // clearing up main page and making sure that export page won't be opened again when closed
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();
                exportButton.Checked = false;

                // creating new exporting page instance
                ExportUserControl exportView = new ExportUserControl();
                this._contentPanel.Controls.Add(exportView);
            }

        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (importButton.Checked)
            {
                try
                {
                    this.sideBarPanel.Controls.Clear();
                    this._contentPanel.Controls.Clear();
                    importButton.Checked = false;

                    // creating new importing page instance
                    ImportUserControl importView = new ImportUserControl();
                    this._contentPanel.Controls.Add(importView);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonMatching_Click(object sender, EventArgs e)
        {
            if (buttonMatching.Checked)
            {
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();

                MatchingControl matchingControl = new MatchingControl();
                this.sideBarPanel.Controls.Add(matchingControl);
                currentPanelContent = matchingControl;
            }

        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            if (helpButton.Checked)
            {
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();

                HelpControl helpControl = new HelpControl();
                this.sideBarPanel.Controls.Add(helpControl);
                currentPanelContent = helpControl;
            }
        }

        private void participantButton_Click(object sender, EventArgs e)
        {
            if (participantButton.Checked)
            {
                this.sideBarPanel.Controls.Clear();
                this._contentPanel.Controls.Clear();

                ParticipantControl participantControl = new ParticipantControl();
                this.sideBarPanel.Controls.Add(participantControl);
                currentPanelContent = participantControl;
            }
        }



        private void participantComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (participantComboBox.SelectedIndex == participantComboBox.Items.Count - 1)
            {
                bool screenTranslationAllowed = true;
                if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                {
                    screenTranslationAllowed = false;
                }
                if (screenTranslationAllowed)
                {
                    FormParticipantConfig newParticipant = new FormParticipantConfig("false");
                    FileManipulation.GlobalFormMain._contentPanel.Controls.Add(newParticipant);
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("shouldCloseOpenedForm", currentCulture));
                }
            }
        }

    }
}
