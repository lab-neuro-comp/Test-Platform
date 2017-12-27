using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Views.ExperimentPages;

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
        

        private void newExperimentButton_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editExperimentButton_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";


                defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), Global.experimentTestFilesPath + Global.programFolderName, "prg", "program", false);
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
        private void deleteExperimentButton_Click(object sender, EventArgs e)
        {
            if (deleteExperimentButton.Checked)
            {
                FormDefine defineProgram;
                DialogResult result;
                string deleteProgramName = "error";

                try
                {
                    defineProgram = new FormDefine(LocRM.GetString("deleteProgram", currentCulture), Global.experimentTestFilesPath + Global.programFolderName, "prg", "program", false);
                    result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        deleteProgramName = defineProgram.ReturnValue;
                        File.Move(Global.experimentTestFilesPath + Global.programFolderName + deleteProgramName + ".prg", Global.experimentTestFilesBackupPath + deleteProgramName + ".prg");
                        MessageBox.Show(deleteProgramName + " " + LocRM.GetString("programDeleted", currentCulture));
                        deleteExperimentButton.Checked = false;
                    }
                    else
                    {
                        /*do nothing, user cancelled selection of program*/
                    }
                }
                catch (IOException)
                {
                    DialogResult dialogResult = MessageBox.Show(LocRM.GetString("programExistsInBackup", currentCulture), "", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show(LocRM.GetString("programNotDeleted", currentCulture));
                    }
                    else
                    {
                        File.Delete(Global.experimentTestFilesPath + deleteProgramName + ".prg");
                        File.Move(Global.experimentTestFilesPath + Global.programFolderName + deleteProgramName + ".prg", Global.experimentTestFilesBackupPath + deleteProgramName + ".prg");
                        MessageBox.Show(deleteProgramName + " " + LocRM.GetString("programDeleted", currentCulture));
                    }
                    deleteExperimentButton.Checked = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                /*do nothing*/
            }
        }
    }
}
