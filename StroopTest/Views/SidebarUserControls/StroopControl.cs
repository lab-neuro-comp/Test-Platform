using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views.MainForms;

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



        private bool checkSave()
        {
            bool result = false;
            if (FileManipulation.GlobalFormMain._contentPanel.Controls[0] is FormPrgConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormPrgConfig programToSave = (FormPrgConfig)(FileManipulation.GlobalFormMain._contentPanel.Controls[0]);
                    result = programToSave.save();
                }
                else
                {
                    FileManipulation.GlobalFormMain._contentPanel.Controls.Clear();
                    return true;
                }
            }
            if (result == false)
            {
                FileManipulation.GlobalFormMain._contentPanel.Controls.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void newStroopProgram()
        {
            newStroopButton.Checked = true;
            newStroopButton_CheckedChanged(null, null);
        }
        private void newStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            if (newStroopButton.Checked)
            {
                if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                {
                    screenTranslationAllowed = checkSave();
                }
                if (screenTranslationAllowed)
                {
                    FormPrgConfig configureProgram = new FormPrgConfig("false");
                    FileManipulation.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                    newStroopButton.Checked = false; 
                }
            }
        }

        private void editStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            if (editStroopButton.Checked)
            {
                if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                {
                    screenTranslationAllowed = checkSave();
                }
                if (screenTranslationAllowed)
                {
                    string editProgramName = "error";
                    FormDefine defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), StroopProgram.GetProgramsPath(), "prg", "program", false, false);
                    DialogResult result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        editProgramName = defineProgram.ReturnValue;
                        if (!Validations.isEmpty(editProgramName))
                        {
                            FormPrgConfig configureProgram = new FormPrgConfig(editProgramName);
                            if (!configureProgram.IsDisposed)
                            {
                                FileManipulation.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                            }
                            editStroopButton.Checked = false;
                        }
                    } 
                }
            }
        }
        private void deleteStroopButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            try
            {
                if (deleteStroopButton.Checked)
                {
                    if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                    {
                        screenTranslationAllowed = checkSave();
                    }
                    if (screenTranslationAllowed)
                    {
                        FileManagment deleteProgram = new FileManagment(StroopProgram.GetProgramsPath(), FileManipulation.StroopTestFilesBackupPath, 'd', LocRM.GetString("stroopTest", currentCulture));
                        FileManipulation.GlobalFormMain._contentPanel.Controls.Add(deleteProgram);
                        deleteStroopButton.Checked = false; 
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void recoverStroopButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            try
            {
                if (recoverStroopButton.Checked)
                {
                    if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                    {
                        screenTranslationAllowed = checkSave();
                    }
                    if (screenTranslationAllowed)
                    {
                        FileManagment recoverProgram = new FileManagment(FileManipulation.StroopTestFilesBackupPath, StroopProgram.GetProgramsPath(), 'r', LocRM.GetString("stroopTest", currentCulture));
                        FileManipulation.GlobalFormMain._contentPanel.Controls.Add(recoverProgram);
                        recoverStroopButton.Checked = false; 
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
