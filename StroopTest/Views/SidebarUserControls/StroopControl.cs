using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Views.StroopPages;

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
            try
            {
                if (deleteStroopButton.Checked)
                {
                    StroopManagment recoverProgram = new StroopManagment(Global.stroopTestFilesPath + Global.programFolderName, Global.stroopTestFilesBackupPath, 'd');
                    Global.GlobalFormMain._contentPanel.Controls.Add(recoverProgram);
                    deleteStroopButton.Checked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void recoverStroopButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (recoverStroopButton.Checked)
                {
                    StroopManagment recoverProgram = new StroopManagment(Global.stroopTestFilesBackupPath, Global.stroopTestFilesPath + Global.programFolderName, 'r');
                    Global.GlobalFormMain._contentPanel.Controls.Add(recoverProgram);
                    recoverStroopButton.Checked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
