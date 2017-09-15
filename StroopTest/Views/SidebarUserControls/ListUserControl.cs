using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestPlatform.Views.SidebarControls
{
    public partial class ListUserControl : DefaultUserControl
    {

        public ListUserControl()
        {
            this.Dock = DockStyle.Fill;
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
                FormShowAudio newAudio = new FormShowAudio();
                Global.GlobalFormMain._contentPanel.Controls.Add(newAudio);
            }
        }

        private void newAudioListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newAudioListButton.Checked)
            {
                FormAudioConfig configureAudioList = new FormAudioConfig(false);
                try
                {
                    Global.GlobalFormMain._contentPanel.Controls.Add(configureAudioList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void editAudioListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (editAudioListButton.Checked)
            {
                FormAudioConfig configureAudioList = new FormAudioConfig(true);
                try
                {
                    Global.GlobalFormMain._contentPanel.Controls.Add(configureAudioList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void backAudioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (backAudioButton.Checked)
            {
                audioButton.Location = new Point(-3, 65);
                audioPanel.Visible = false;
                colorWordButton.Visible = true;
                imageButton.Visible = true;
            }
        }

        private void colorWordButton_Click(object sender, EventArgs e)
        {
            if (colorWordButton.Checked)
            {
                audioButton.Visible = false;
                imageButton.Visible = false;
                wordColorPanel.Visible = true;
            }

        }

        private void backWordColorButton_CheckedChanged(object sender, EventArgs e)
        {
            audioButton.Visible = true;
            imageButton.Visible = true;
            wordColorPanel.Visible = false;

        }

        private void newWordColorButton_Click(object sender, EventArgs e)
        {
            if (newWordColorButton.Checked)
            {
                FormWordColorConfig configureList = new FormWordColorConfig(false);
                try
                {
                    Global.GlobalFormMain._contentPanel.Controls.Add(configureList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void editWordColorButton_Click(object sender, EventArgs e)
        {
            if (editWordColorButton.Checked)
            {
                FormWordColorConfig configureList = new FormWordColorConfig(true);
                try
                {
                    Global.GlobalFormMain._contentPanel.Controls.Add(configureList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            if (imageButton.Checked)
            {
                colorWordButton.Visible = false;
                audioButton.Visible = false;
                imageButton.Location = new Point(-3, 3);
                imagePanel.Visible = true;
            }

        }

        private void newImageListButton_Click(object sender, EventArgs e)
        {
            if (newImageListButton.Checked)
            {
                FormImgConfig configureImagesList = new FormImgConfig("false");
                try
                {
                    Global.GlobalFormMain._contentPanel.Controls.Add(configureImagesList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void editImageListButton_Click(object sender, EventArgs e)
        {
            if (editImageListButton.Checked)
            {
                FormImgConfig configureImagesList = new FormImgConfig("");
                try
                {
                    Global.GlobalFormMain._contentPanel.Controls.Add(configureImagesList);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void backImageButton_Click(object sender, EventArgs e)
        {
            if (backImageButton.Checked)
            {
                imageButton.Location = new Point(-3, 32);
                imagePanel.Visible = false;
                colorWordButton.Visible = true;
                audioButton.Visible = true;

            }
        }
    }
}
