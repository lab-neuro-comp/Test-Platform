using System;
using TestPlatform.Controllers;
using System.Windows.Forms;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class HelpControl : DefaultUserControl
    {
        private Control currentControl = null;

        public HelpControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {
            if (instructionsButton.Checked)
            {
                HelpPagesController.showInstructions();
                instructionsButton.Checked = false;
            }
        }

        private void helpPageButton_Click(object sender, EventArgs e)
        {
            if (helpPageButton.Checked)
            {
                if (currentControl != null)
                {
                    Global.GlobalFormMain._contentPanel.Controls.Remove(currentControl);

                }
                currentControl = HelpPagesController.showHelp();
                helpPageButton.Checked = false;
            }
        }

        private void techInfoButton_Click(object sender, EventArgs e)
        {
            if (techInfoButton.Checked)
            {
                if (currentControl != null)
                {
                    Global.GlobalFormMain._contentPanel.Controls.Remove(currentControl);

                }                
                currentControl = HelpPagesController.showTechInfo();
                techInfoButton.Checked = false;
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            if (aboutButton.Checked)
            {
                HelpPagesController.showAboutBox();
                aboutButton.Checked = false;
            }
        }
    }
}
