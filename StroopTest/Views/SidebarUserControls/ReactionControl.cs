
using StroopTest;
using StroopTest.Views;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ReactionControl : DefaultUserControl
    {
        string testFilesPath;
        public ReactionControl()
        {
            InitializeComponent();
        }


        public string TestFilesPath
        {
            set
            {
                testFilesPath = value;
            }
        }

        private void newReactButton_Click(object sender, System.EventArgs e)
        {
            if (newReactButton.Checked)
            {
                FormTRConfig configureProgram = new FormTRConfig();
                configureProgram.Path = testFilesPath;
                Parent.Controls.Add(configureProgram);
            }
        }
    }
}
