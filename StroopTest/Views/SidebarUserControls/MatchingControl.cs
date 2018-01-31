using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Views.ExperimentPages;
using System.Resources;
using System.Globalization;
using TestPlatform.Views.MainForms;
using TestPlatform.Views.MatchingPages;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class MatchingControl : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public MatchingControl()
        {
            InitializeComponent();
        }


        private bool checkSave()
        {

            bool result = false;
            if (Global.GlobalFormMain._contentPanel.Controls[0] is FormMatchConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormMatchConfig programToSave = (FormMatchConfig)(Global.GlobalFormMain._contentPanel.Controls[0]);
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

        private void newMatchButton_Click(object sender, EventArgs e)
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
                    if (newMatchButton.Checked)
                    {
                        FormMatchConfig newExperiment = new FormMatchConfig(false);
                        Global.GlobalFormMain._contentPanel.Controls.Add(newExperiment);
                        newMatchButton.Checked = false;
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

        private void editMatchButton_Click(object sender, EventArgs e)
        {
            if (this.editMatchButton.Checked)
            {

            }
        }

        private void deleteMatchButton_Click(object sender, EventArgs e)
        {
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
                        if (deleteMatchButton.Checked)
                        {
                            FileManagment deleteProgram = new FileManagment(Global.matchingTestFilesPath + Global.programFolderName, Global.matchingTestFilesBackupPath, 'd', "program");
                            Global.GlobalFormMain._contentPanel.Controls.Add(deleteProgram);
                            deleteMatchButton.Checked = false;
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

        private void recoverMatchButton_Click(object sender, EventArgs e)
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
                    if (recoverMatchButton.Checked)
                    {
                        FileManagment recoverProgram = new FileManagment(Global.matchingTestFilesBackupPath, Global.matchingTestFilesPath + Global.programFolderName, 'r', "program");
                        Global.GlobalFormMain._contentPanel.Controls.Add(recoverProgram);
                        recoverMatchButton.Checked = false;
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
