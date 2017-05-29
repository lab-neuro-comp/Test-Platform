using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Views;
using TestPlatform;
using TestPlatform.Views.ReactionPages;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ResultsUserControl : DefaultUserControl
    {
        private string testFilesPath;
        private string stroopResultsPath;
        private string reactionResultsPath;

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

        public string StroopResultsPath
        {
            get
            {
                return stroopResultsPath;
            }

            set
            {
                stroopResultsPath = value;
            }
        }

        public string ReactionResultsPath
        {
            get
            {
                return reactionResultsPath;
            }

            set
            {
                reactionResultsPath = value;
            }
        }

        public ResultsUserControl()
        {
            InitializeComponent();
        }

        private void StroopButton_Click(object sender, EventArgs e)
        {
            FormShowData showData;
            try
            {
                showData = new FormShowData(TestFilesPath + StroopResultsPath);
                Parent.Controls.Add(showData);
                StroopButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reactionButton_Click(object sender, EventArgs e)
        {
            ReactionResultUserControl showData;
            try
            {
                showData = new ReactionResultUserControl(TestFilesPath + ReactionResultsPath);
                Parent.Controls.Add(showData);
                reactionButton.Checked = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
