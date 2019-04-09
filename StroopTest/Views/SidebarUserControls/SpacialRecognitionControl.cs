using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Models;
using System.Resources;
using System.Globalization;
using TestPlatform.Views.SpecialRecognitionPages;
using TestPlatform.Models.Tests.SpacialRecognition;
using TestPlatform.Views.MainForms;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class SpacialRecognitionControl : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public SpacialRecognitionControl()
        {
            InitializeComponent();
        }

        private bool checkSave()
        {
            bool result = false;
            if (FileManipulation.GlobalFormMain._contentPanel.Controls[0] is FormSRConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormSRConfig programToSave = (FormSRConfig)(FileManipulation.GlobalFormMain._contentPanel.Controls[0]);
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

        private void newSpacialRecognitionButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            try
            {
                if (newSpacialRecognitionButton.Checked)
                {
                    if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                    {
                        screenTranslationAllowed = checkSave();
                    }
                    if (screenTranslationAllowed)
                    {
                        FormSRConfig configureProgram = new FormSRConfig("false");
                        FileManipulation.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                        newSpacialRecognitionButton.Checked = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void editSpacialRecognitionButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            if (editSpacialRecognitionButton.Checked)
            {
                if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                {
                    screenTranslationAllowed = checkSave();
                }
                if (screenTranslationAllowed)
                {
                    FormDefine defineProgram;
                    DialogResult result;
                    string editProgramName = "error";

                    try
                    {
                        defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), SpacialRecognitionProgram.GetProgramsPath(), "prg", "program", false, false);
                        result = defineProgram.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            editProgramName = defineProgram.ReturnValue;
                            FormSRConfig configureProgram = new FormSRConfig(editProgramName);
                            configureProgram.PrgName = editProgramName;
                            FileManipulation.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                            editSpacialRecognitionButton.Checked = false;
                        }
                        else
                        {
                            /*do nothing, user cancelled selection of program*/
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            else
            {
                /*do nothing*/
            }
        }

        private void DeleteSpacialRecognitionButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            try
            {
                if (deleteSpacialRecognitionButton.Checked)
                {
                    if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                    {
                        screenTranslationAllowed = checkSave();
                    }
                    if (screenTranslationAllowed)
                    {
                        FileManagment deleteProgram = new FileManagment(SpacialRecognitionProgram.GetProgramsPath(), FileManipulation.SpacialReconitionTestFilesBackupPath, 'd', LocRM.GetString("spacialRecognition", currentCulture));
                        FileManipulation.GlobalFormMain._contentPanel.Controls.Add(deleteProgram);
                        deleteSpacialRecognitionButton.Checked = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RecoverSpacialRecognitionButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            try
            {
                if (recoverSpacialRecognitionButton.Checked)
                {
                    if (FileManipulation.GlobalFormMain._contentPanel.Controls.Count > 0)
                    {
                        screenTranslationAllowed = checkSave();
                    }
                    if (screenTranslationAllowed)
                    {
                        FileManagment recoverProgram = new FileManagment(FileManipulation.SpacialReconitionTestFilesBackupPath, SpacialRecognitionProgram.GetProgramsPath(), 'r', LocRM.GetString("spacialRecognition", currentCulture));
                        FileManipulation.GlobalFormMain._contentPanel.Controls.Add(recoverProgram);
                        recoverSpacialRecognitionButton.Checked = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
