

using System;
using System.Windows;
using TestPlatform.Views.ExperimentPages;

namespace TestPlatform.Views
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

        private void newExperimentButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExperimentConfig newExperiment = new ExperimentConfig();
                newExperiment.Path = TestFilesPath;
                Parent.Controls.Add(newExperiment);
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
