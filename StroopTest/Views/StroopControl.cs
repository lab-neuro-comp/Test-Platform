using System;
using System.Drawing;
using System.Windows.Forms;

namespace StroopTest.Views
{
    public partial class StroopControl : DefaultUserControl
    {
        string testFilesPath;
        public StroopControl()
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

        protected override void OnLoad(EventArgs e)
        {
           
            Location = new Point(121, 49);
            this.BringToFront();
            base.OnLoad(e);
        }


       

        private void newStroopButton_Click(object sender, EventArgs e)
        {
            if (newStroopButton.Checked)
            {
                FormPrgConfig configureProgram = new FormPrgConfig();
                configureProgram.Path = testFilesPath;
                Parent.Controls.Add(configureProgram);
            }
        }

        private void newStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newStroopButton.Checked)
            {
                FormPrgConfig configureProgram = new FormPrgConfig();
                configureProgram.Path = testFilesPath;
                Parent.Controls.Add(configureProgram);
                newStroopButton.Checked = false;
            }
        }
    }
}
