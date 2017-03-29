using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroopTest.Views.SidebarControls
{
    public partial class ListUserControl : DefaultUserControl
    {
        private string testFilesPath;

        public string TestFilesPath
        {
            set
            {
                testFilesPath = value;
            }
        }

        public ListUserControl()
        {
            InitializeComponent();
        }

        private void audioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (audioButton.Checked)
            {
                colorWordButton.Visible = false;
                imageButton.Visible = false;
                audioButton.Location = new Point(-3, 3);
                audioPanel.Visible = true;
            }
        }

        private void recordAudioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (recordAudioButton.Checked)
            {
                FormNewAudio newAudio = new FormNewAudio();                
                Parent.Controls.Add(newAudio);
            }
        }

        private void newAudioListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newAudioListButton.Checked)
            {
                FormAudioConfig configureAudioList = new FormAudioConfig(testFilesPath + "/lst/", false);
                try
                {
                    Parent.Controls.Add(configureAudioList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void editAudioListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (editAudioListButton.Checked)
            {
                FormAudioConfig configureAudioList = new FormAudioConfig(testFilesPath + "/lst/", true);
                try
                {
                    Parent.Controls.Add(configureAudioList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void backAudioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (backAudioButton.Checked)
            {
                audioButton.Location = new Point(-3, 81);
                audioPanel.Visible = false;
                colorWordButton.Visible = true;
                imageButton.Visible = true;
            }
        }
    }
}
