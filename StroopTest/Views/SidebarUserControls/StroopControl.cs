using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace TestPlatform.Views
{
    public partial class StroopControl : DefaultUserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public StroopControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void newStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newStroopButton.Checked)
            {
                FormPrgConfig configureProgram = new FormPrgConfig("false");
                Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                newStroopButton.Checked = false;
            }
        }

        private void editStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (editStroopButton.Checked)
            {
                string editProgramName = "error";
                FormDefine defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), Global.stroopTestFilesPath + Global.programFolderName, "prg", "program", false);
                DialogResult result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    FormPrgConfig configureProgram = new FormPrgConfig(editProgramName);
                    if (!configureProgram.IsDisposed)
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                    }
                    editStroopButton.Checked = false;
                }
            }
        }
        private void deleteStroopButton_Click(object sender, EventArgs e)
        {
            if (deleteStroopButton.Checked)
            {
                FormDefine defineProgram;
                DialogResult result;
                string deleteProgramName = "error";

                try
                {
                    defineProgram = new FormDefine(LocRM.GetString("deleteProgram", currentCulture), Global.stroopTestFilesPath + Global.programFolderName, "prg", "program", false);
                    result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        deleteProgramName = defineProgram.ReturnValue;
                        File.Move(Global.stroopTestFilesPath + Global.programFolderName + deleteProgramName + ".prg", Global.stroopTestFilesBackupPath + deleteProgramName + ".prg");
                        MessageBox.Show(deleteProgramName + " " + LocRM.GetString("programDeleted", currentCulture));
                        deleteStroopButton.Checked = false;
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
                        File.Delete(Global.stroopTestFilesPath + deleteProgramName + ".prg");
                        File.Move(Global.stroopTestFilesPath + Global.programFolderName + deleteProgramName + ".prg", Global.stroopTestFilesBackupPath + deleteProgramName + ".prg");
                        MessageBox.Show(deleteProgramName + " " + LocRM.GetString("programDeleted", currentCulture));
                    }
                    deleteStroopButton.Checked = false;
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
