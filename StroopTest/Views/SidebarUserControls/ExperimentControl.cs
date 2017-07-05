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
        private string testFilesPath;
        public ExperimentControl()
        {
            InitializeComponent();
        }

        public string TestFilesPath
        {
            get
            {
                return testFilesPath;
            }

            set
            {
                testFilesPath = value;
            }
        }

        private void newExperimentButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (newExperimentButton.Checked)
                {
                    ExperimentConfig newExperiment = new ExperimentConfig();
                    newExperiment.Path = TestFilesPath;
                    Parent.Controls.Add(newExperiment);
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
