using System.Windows.Forms;

namespace TestPlatform.Views.MainForms
{
    public partial class HelpPagesUserControl : UserControl
    {
        public HelpPagesUserControl(string htmlText)
        {
            InitializeComponent();
            helpBrowser.DocumentText = htmlText;
        }
    }
}
