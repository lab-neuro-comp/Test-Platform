using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Views.ParticipantPages;
using System.Resources;
using System.Globalization;
using TestPlatform.Views.MainForms;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ParticipantControl : DefaultUserControl
    {
        static private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        static private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public ParticipantControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public static bool checkSave()
        {

            bool result = false;
            if (Global.GlobalFormMain._contentPanel.Controls[0] is FormParticipantConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormParticipantConfig programToSave = (FormParticipantConfig)(Global.GlobalFormMain._contentPanel.Controls[0]);
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

        private void newParticipantButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            if (Global.GlobalFormMain._contentPanel.Controls.Count > 0)
            {
                screenTranslationAllowed = checkSave();
            }
            if (screenTranslationAllowed)
            {
                if (newParticipantButton.Checked)
                {
                    FormParticipantConfig newParticipant = new FormParticipantConfig("false");
                    Global.GlobalFormMain._contentPanel.Controls.Add(newParticipant);
                    newParticipantButton.Checked = false;
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void editParticipantButton_Click(object sender, EventArgs e)
        {
            bool screenTranslationAllowed = true;
            if (editParticipantButton.Checked)
            {
                if (Global.GlobalFormMain._contentPanel.Controls.Count > 0)
                {
                    screenTranslationAllowed = checkSave();
                }
                if (screenTranslationAllowed)
                {
                    FormDefine defineParticipant;
                    DialogResult result;
                    string editParticipantName = "error";

                    try
                    {
                        defineParticipant = new FormDefine(LocRM.GetString("editParticipant", currentCulture), Global.testFilesPath + Global.partcipantDataPath, "data", "participant", false, false);
                        result = defineParticipant.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            editParticipantName = defineParticipant.ReturnValue;
                            FormParticipantConfig configureProgram = new FormParticipantConfig(editParticipantName);
                            Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                            editParticipantButton.Checked = false;
                        }
                        else
                        {
                            /*do nothing, user cancelled selection of participant*/
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
    }
}
