using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestPlatform.Views.ExperimentPages
{
    public partial class ExperimentConfig : UserControl
    {
        private string path;
        private static string stroopProgramPath = "StroopTestFiles/prg/";
        private static string reactionProgramPath = "ReactionTestFiles/prg/";

        public ExperimentConfig()
        {
            Location = new Point(530, 48);
            InitializeComponent();
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }
        private string[] defineTest()
        {
            FormDefineTest defineTest = new FormDefineTest(path, stroopProgramPath, reactionProgramPath);
            try
            {
                var result = defineTest.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return defineTest.returnValues;
                }
                else
                {
                    /*do nothing*/
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private void program1button_Click(object sender, System.EventArgs e)
        {
            string[] result = defineTest();
            if(result != null)
            {
                program1Button.Text = result[0] + ": " + result[1];
            }
            else
            {
                program1Button.Text = "abrir";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
