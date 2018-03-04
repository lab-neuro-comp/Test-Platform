using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Views.ListsPages;

namespace TestPlatform.Views.SidebarControls
{
    public partial class ListUserControl : DefaultUserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        private bool isAllowedToChangeScreen()
        {
            if (Global.GlobalFormMain._contentPanel.Controls.Count > 0)
            {
                if(Global.GlobalFormMain._contentPanel.Controls[0] is FormAudioConfig ||
                    Global.GlobalFormMain._contentPanel.Controls[0] is FormImgConfig ||
                    Global.GlobalFormMain._contentPanel.Controls[0] is FormWordColorConfig)
                {
                    DialogResult dialogResult = MessageBox.Show(LocRM.GetString("unsavedLists", currentCulture), LocRM.GetString("unsavedListsTitle", currentCulture), MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public ListUserControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void audioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (audioButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    colorWordButton.Visible = false;
                    imageButton.Visible = false;
                    audioButton.Location = new Point(-3, 3);
                    audioPanel.Visible = true;
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void recordAudioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (recordAudioButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    FormShowAudio newAudio = new FormShowAudio();
                    Global.GlobalFormMain._contentPanel.Controls.Add(newAudio);
                }
                else
                {
                    /*do nothing*/
                }

            }
        }

        private void newAudioListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newAudioListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    FormAudioConfig configureAudioList = new FormAudioConfig(false);
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(configureAudioList);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void editAudioListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (editAudioListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    FormAudioConfig configureAudioList = new FormAudioConfig(true);
                    try
                    {
                        if (configureAudioList.isValid())
                        {
                            Global.GlobalFormMain._contentPanel.Controls.Add(configureAudioList);
                        }
                        else
                        {
                            editAudioListButton.Checked = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void backAudioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (backAudioButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    audioButton.Location = new Point(-3, 65);
                    audioPanel.Visible = false;
                    colorWordButton.Visible = true;
                    imageButton.Visible = true;
                }
                else
                {
                    /*do nothing*/
                }
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
            if (isAllowedToChangeScreen())
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear();
                audioButton.Visible = true;
                imageButton.Visible = true;
                wordColorPanel.Visible = false;
            }
            else
            {
                /*do nothing*/
            }

        }

        private void newWordColorButton_Click(object sender, EventArgs e)
        {
            if (newWordColorButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    FormWordColorConfig configureList = new FormWordColorConfig(false);
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(configureList);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void editWordColorButton_Click(object sender, EventArgs e)
        {
            if (editWordColorButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    FormWordColorConfig configureList = new FormWordColorConfig(true);
                    try
                    {
                        if (configureList.isValid())
                        {
                            Global.GlobalFormMain._contentPanel.Controls.Add(configureList);
                        }
                        else
                        {
                            editWordColorButton.Checked = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            if (imageButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    colorWordButton.Visible = false;
                    audioButton.Visible = false;
                    imageButton.Location = new Point(-3, 3);
                    imagePanel.Visible = true;
                }
                else
                {
                    /*do nothing*/
                }
            }

        }

        private void newImageListButton_Click(object sender, EventArgs e)
        {
            if (newImageListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    FormImgConfig configureImagesList = new FormImgConfig("false");
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(configureImagesList);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void editImageListButton_Click(object sender, EventArgs e)
        {
            if (editImageListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    FormImgConfig configureImagesList = new FormImgConfig("");
                    try
                    {
                        if (configureImagesList.isValid())
                        {
                            Global.GlobalFormMain._contentPanel.Controls.Add(configureImagesList);
                        }
                        else
                        {
                            editImageListButton.Checked = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void backImageButton_Click(object sender, EventArgs e)
        {
            if (isAllowedToChangeScreen())
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear();
                if (backImageButton.Checked)
                {
                    imageButton.Location = new Point(-3, 32);
                    imagePanel.Visible = false;
                    colorWordButton.Visible = true;
                    audioButton.Visible = true;

                }
            }
            else
            {
                /*do nothing*/
            }
        }

        private void deleteImageListButton_Click(object sender, EventArgs e)
        {
            if (deleteImageListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    ListManagment ManageList = new ListManagment("_image", 'd');
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(ManageList);
                        deleteImageListButton.Checked = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }
        private void deleteWordColorButton_Click(object sender, EventArgs e)
        {
            if (deleteWordColorButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    ListManagment ManageList = new ListManagment("_words_color", 'd');
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(ManageList);
                        deleteImageListButton.Checked = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }
        private void deleteAudioListButton_Click(object sender, EventArgs e)
        {
            if (deleteAudioListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    ListManagment ManageList = new ListManagment("_audio", 'd');
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(ManageList);
                        deleteImageListButton.Checked = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void recoverImageListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (recoverImageListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    ListManagment ManageList = new ListManagment("_image", 'r');
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(ManageList);
                        deleteImageListButton.Checked = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void recoverAudioListButton_CheckedChanged(object sender, EventArgs e)
        {
            if (recoverAudioListButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    ListManagment ManageList = new ListManagment("_audio", 'r');
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(ManageList);
                        deleteImageListButton.Checked = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void recoverWordColorButton_CheckedChanged(object sender, EventArgs e)
        {
            if (recoverWordColorButton.Checked)
            {
                if (isAllowedToChangeScreen())
                {
                    Global.GlobalFormMain._contentPanel.Controls.Clear();
                    ListManagment ManageList = new ListManagment("_words_color", 'r');
                    try
                    {
                        Global.GlobalFormMain._contentPanel.Controls.Add(ManageList);
                        deleteImageListButton.Checked = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                {
                    /*do nothing*/
                }
            }
        }
    }
}
