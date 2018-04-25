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

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ParticipantControl : DefaultUserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public ParticipantControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private bool checkSave()
        {

            bool result = false;
            if (Global.GlobalFormMain._contentPanel.Controls[0] is FormParticipantConfig)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("savePending", currentCulture), LocRM.GetString("savePendingTitle", currentCulture), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
               //     FormParticipantConfig programToSave = (FormParticipantConfig)(Global.GlobalFormMain._contentPanel.Controls[0]);
                 //   result = programToSave.save();
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

        }

        private void editParticipantButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
