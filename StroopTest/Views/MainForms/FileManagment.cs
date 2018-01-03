using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Globalization;

namespace TestPlatform.Views.MainForms
{
    public partial class FileManagment : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        private bool hasConflict = false;

        private string originPath, destinationPath;

        public FileManagment(string originPath, string destinationPath, char mode)
        {
            InitializeComponent();
            this.originPath = originPath;
            this.destinationPath = destinationPath;
            if (mode == 'r') //recover mode
            {
                sendButton.Text = LocRM.GetString("recover", currentCulture);
                originListLabel.Text = LocRM.GetString("deletedPrograms", currentCulture);
                destinationListLabel.Text = LocRM.GetString("toRecoverPrograms", currentCulture);
                warningMessage.Text = LocRM.GetString("warningRecover", currentCulture);
            }
            else if (mode == 'd') //delete mode
            {
                sendButton.Text = LocRM.GetString("delete", currentCulture);
                originListLabel.Text = LocRM.GetString("existingPrograms", currentCulture);
                destinationListLabel.Text = LocRM.GetString("toDeletePrograms", currentCulture);
                warningMessage.Text = LocRM.GetString("warningDelete", currentCulture);
            }
            else
            {
                throw new ArgumentException();
            }
            loadOriginList();
        }

        private void originFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush redSolidBrush = new SolidBrush(Color.Red);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < originFilesList.Items.Count)
            {
                string text = originFilesList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else if (File.Exists(destinationPath + text + ".prg") == true)
                {
                    backgroundBrush = redSolidBrush;
                }
                else
                {
                    backgroundBrush = whiteSolidBrush;
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, originFilesList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        private void destinationFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush redSolidBrush = new SolidBrush(Color.Red);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < destinationFilesList.Items.Count)
            {
                string text = destinationFilesList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else if (File.Exists(destinationPath + text + ".prg") == true)
                {
                    backgroundBrush = redSolidBrush;
                }
                else
                {
                    backgroundBrush = whiteSolidBrush;
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, destinationFilesList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
        }

        private void addToDestinationList_Click(object sender, EventArgs e)
        {
            string programName;
            if (originFilesList.SelectedItem != null)
            {
                programName = originFilesList.SelectedItem.ToString();
                originFilesList.Items.Remove(programName);
                destinationFilesList.Items.Add(programName);
            }
            else
            {
                /*do nothing*/
            }
        }

        private void addToOriginList_Click(object sender, EventArgs e)
        {
            string programName;
            if (destinationFilesList.SelectedItem != null)
            {
                programName = destinationFilesList.SelectedItem.ToString();
                destinationFilesList.Items.Remove(programName);
                originFilesList.Items.Add(programName);
            }
            else
            {
                /*do nothing*/
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string[] programs = new string[destinationFilesList.Items.Count];
            if (destinationFilesList.Items.Count > 0)
            {
                for (int count = 0; count < destinationFilesList.Items.Count; count++)
                {
                    programs[count] = destinationFilesList.Items[count].ToString();
                }
                for (int count = 0; count < programs.Length; count++)
                {
                    try
                    {
                        File.Move(originPath + programs[count] + ".prg", destinationPath + programs[count] + ".prg");
                        destinationFilesList.Items.Remove(programs[count]);
                    }
                    catch (IOException)
                    {
                        File.Delete(destinationPath + programs[count] + ".prg");
                        File.Move(originPath + programs[count] + ".prg", destinationPath + programs[count] + ".prg");
                        destinationFilesList.Items.Remove(programs[count]);
                    }
                }
                if (sendButton.Text == LocRM.GetString("recover", currentCulture))
                {
                    MessageBox.Show(LocRM.GetString("recoveredSucessful", currentCulture));
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("deletedSucessful", currentCulture));
                }
                loadOriginList();
            }
            else
            {
                /* do nothing*/
            }
        }

        private void warningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (warningCheckBox.Checked)
            {
                sendButton.Enabled = true;
            }
            else
            {
                sendButton.Enabled = false;
            }
        }

        private void loadOriginList()
        {
            string[] filePaths;
            string programName;
            originFilesList.Items.Clear();
            filePaths = Directory.GetFiles(originPath, ("*.prg"), SearchOption.AllDirectories);
            foreach (string file in filePaths)
            {
                programName = Path.GetFileNameWithoutExtension(file);
                originFilesList.Items.Add(programName);
                if (File.Exists(destinationPath + programName + ".prg"))
                {
                    hasConflict = true;
                }
            }
            if (hasConflict)
            {
                warningCheckBox.Visible = true;
                warningMessage.Visible = true;
                sendButton.Enabled = false;
            }
            else
            {
                warningMessage.Visible = false;
                warningCheckBox.Visible = false;
                sendButton.Enabled = true;
            }
        }
    }
}
