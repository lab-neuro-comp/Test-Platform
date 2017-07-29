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

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ExperimentControl : DefaultUserControl
    {
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
                    ExperimentConfig newExperiment = new ExperimentConfig();
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
    }
}
