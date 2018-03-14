using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Views.ExperimentPages;
using TestPlatform.Views.MainForms;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ExperimentControl : DefaultUserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public ExperimentControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private bool checkSave()
        {
            bool result = false;
            if (Global.GlobalFormMain._contentPanel.Controls[0] is ExperimentConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ExperimentConfig programToSave = (ExperimentConfig)(Global.GlobalFormMain._contentPanel.Controls[0]);
                    result = programToSave.save();
                }
                else
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    return true;
                }
            }
            if (result == false)
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void newExperimentButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            try
            {
                if (Global.GlobalFormMain._contentPanel.Controls.Count > 0)
                {
                    screenTranslationAllowed = checkSave();
                }
                if (screenTranslationAllowed)
                {
                    if (newExperimentButton.Checked)
                    {
                        ExperimentConfig newExperiment = new ExperimentConfig("false");
                        Global.GlobalFormMain._contentPanel.Controls.Add(newExperiment);
                        newExperimentButton.Checked = false;
                    }
                    else
                    {
                        /*do nothing*/
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editExperimentButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;

            if (Global.GlobalFormMain._contentPanel.Controls.Count > 0)
            {
                screenTranslationAllowed = checkSave();
            }
            if (screenTranslationAllowed)
            {
                FormDefine defineProgram;
                DialogResult result;
                string editProgramName = "error";


                defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), Global.experimentTestFilesPath + Global.programFolderName, "prg", "program", false, false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    ExperimentConfig editExperiment = new ExperimentConfig(editProgramName);
                    Global.GlobalFormMain._contentPanel.Controls.Add(editExperiment);
                    editExperimentButton.Checked = false;
                }
                else
                {
                    /*do nothing, user cancelled selection of program*/
                }
            }
        }
        private void deleteExperimentButton_Click(object sender, EventArgs e)
        {
            try {
                bool screenTranslationAllowed = true;

                if (Global.GlobalFormMain._contentPanel.Controls.Count > 0)
                {
                    screenTranslationAllowed = checkSave();
                }
                if (screenTranslationAllowed)
                {
                    if (deleteExperimentButton.Checked)
                    {
                        FileManagment deleteProgram = new FileManagment(Global.experimentTestFilesPath + Global.programFolderName, Global.experimentTestFilesBackupPath, 'd', LocRM.GetString("experiment", currentCulture));
                        Global.GlobalFormMain._contentPanel.Controls.Add(deleteProgram);
                        deleteExperimentButton.Checked = false;
                    }
                    else
                    {
                        /*do nothing*/
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void recoverExperimentButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;

            if (Global.GlobalFormMain._contentPanel.Controls.Count > 0)
            {
                screenTranslationAllowed = checkSave();
            }
            if (screenTranslationAllowed)
            {
                try
                {
                    if (recoverExperimentButton.Checked)
                    {
                        FileManagment recoverProgram = new FileManagment(Global.experimentTestFilesBackupPath, Global.experimentTestFilesPath + Global.programFolderName, 'r', LocRM.GetString("experiment", currentCulture));
                        Global.GlobalFormMain._contentPanel.Controls.Add(recoverProgram);
                        recoverExperimentButton.Checked = false;
                    }
                    else
                    {
                        /*do nothing */
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
