
using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Views.ReactionPages;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ReactionControl : DefaultUserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public ReactionControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void newReactButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (newReactButton.Checked)
                {
                    FormTRConfig configureProgram = new FormTRConfig("false");
                    Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                    newReactButton.Checked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void editReactButton_Click(object sender, EventArgs e)
        {
            if (editReactButton.Checked)
            {
                FormDefine defineProgram;
                DialogResult result;
                string editProgramName = "error";

                try
                {
                    defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), Global.reactionTestFilesPath + Global.programFolderName, "prg", "program", false);
                    result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        editProgramName = defineProgram.ReturnValue;
                        FormTRConfig configureProgram = new FormTRConfig(editProgramName);
                        configureProgram.PrgName = editProgramName;
                        Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                        editReactButton.Checked = false;
                    }
                    else
                    {
                        /*do nothing, user cancelled selection of program*/
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                /*do nothing*/
            }
            
        }

        private void deleteReactButton_Click(object sender, EventArgs e)
        {
            if (deleteReactButton.Checked)
            {
                FormDefine defineProgram;
                DialogResult result;
                string deleteProgramName = "error";

                try
                {
                    defineProgram = new FormDefine(LocRM.GetString("deleteProgram", currentCulture), Global.reactionTestFilesPath + Global.programFolderName, "prg", "program", false);
                    result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        deleteProgramName = defineProgram.ReturnValue;
                        File.Move(Global.reactionTestFilesPath + Global.programFolderName + deleteProgramName + ".prg", Global.reactionTestFilesBackupPath + deleteProgramName + ".prg");
                        MessageBox.Show(deleteProgramName + " " + LocRM.GetString("programDeleted", currentCulture));
                        deleteReactButton.Checked = false;
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
                        File.Delete(Global.experimentTestFilesBackupPath + deleteProgramName + ".prg");
                        File.Move(Global.reactionTestFilesPath + Global.programFolderName + deleteProgramName + ".prg", Global.reactionTestFilesBackupPath + deleteProgramName + ".prg");
                        MessageBox.Show(deleteProgramName +" "+ LocRM.GetString("programDeleted", currentCulture));
                    }
                    deleteReactButton.Checked = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                /*do nothing*/
            }

        }

        private void recoverReactButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (recoverReactButton.Checked)
                {
                    RecoverTR recoverProgram = new RecoverTR();
                    Global.GlobalFormMain._contentPanel.Controls.Add(recoverProgram);
                    recoverReactButton.Checked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
