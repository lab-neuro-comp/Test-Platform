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

namespace TestPlatform.Views.ExperimentPages
{
    public partial class ExperimentManagment : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        private string sourcePath, destPath;

        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.Red);
        private bool hasConflict = false;
        private void deletedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < deletedListBox.Items.Count)
            {
                string text = deletedListBox.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = reportsBackgroundBrushSelected;
                }
                else if (File.Exists(destPath + text + ".prg") == true)
                {
                    backgroundBrush = reportsBackgroundBrush1;
                }
                else
                {
                    backgroundBrush = reportsForegroundBrushSelected;
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
                g.DrawString(text, e.Font, foregroundBrush, deletedListBox.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        private void toRecoverListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < toRecoverListBox.Items.Count)
            {
                string text = toRecoverListBox.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = reportsBackgroundBrushSelected;
                }
                else if (File.Exists(destPath + text + ".prg") == true)
                {
                    backgroundBrush = reportsBackgroundBrush1;
                }
                else
                {
                    backgroundBrush = reportsForegroundBrushSelected;
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
                g.DrawString(text, e.Font, foregroundBrush, toRecoverListBox.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }
        public ExperimentManagment(string sourcePath, string destPath, char mode)
        {
            this.sourcePath = sourcePath;
            this.destPath = destPath;
            InitializeComponent();
            loadDeletedList();
            if (mode == 'r') //recover mode
            {
                sendButton.Text = LocRM.GetString("recover", currentCulture);
                programDeletedLabel.Text = LocRM.GetString("deletedPrograms", currentCulture);
                programRecoveredLabel.Text = LocRM.GetString("toRecoverPrograms", currentCulture);
                warningLabel.Text = LocRM.GetString("warningRecover", currentCulture);
            }
            else if (mode == 'd') //delete mode
            {
                sendButton.Text = LocRM.GetString("delete", currentCulture);
                programDeletedLabel.Text = LocRM.GetString("existingPrograms", currentCulture);
                programRecoveredLabel.Text = LocRM.GetString("toDeletePrograms", currentCulture);
                warningLabel.Text = LocRM.GetString("warningDelete", currentCulture);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void loadDeletedList()
        {
            string[] filePaths;
            string programName;
            deletedListBox.Items.Clear();
            filePaths = Directory.GetFiles(sourcePath, ("*.prg"), SearchOption.AllDirectories);
            foreach (string file in filePaths)
            {
                programName = Path.GetFileNameWithoutExtension(file);
                deletedListBox.Items.Add(programName);
            }
            checkConflict();
            if (hasConflict)
            {
                agreeCheckBox.Visible = true;
                warningLabel.Visible = true;
                sendButton.Enabled = false;
            }
            else
            {
                agreeCheckBox.Visible = false;
                warningLabel.Visible = false;
                sendButton.Enabled = true;
            }
        }

        private void checkConflict()
        {
            for (int count = 0; count < deletedListBox.Items.Count; count++)
            {
                if (File.Exists(destPath + deletedListBox.Items[count].ToString() + ".prg"))
                {
                    hasConflict = true;
                    return;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
        }

        private void addToRecoverList_Click(object sender, EventArgs e)
        {
            string programName;
            if (deletedListBox.SelectedItem != null)
            {
                programName = deletedListBox.SelectedItem.ToString();
                deletedListBox.Items.Remove(programName);
                toRecoverListBox.Items.Add(programName);
            }
            else
            {
                /*do nothing*/
            }
        }

        private void addToDeletedList_Click(object sender, EventArgs e)
        {
            string programName;
            if (toRecoverListBox.SelectedItem != null)
            {
                programName = toRecoverListBox.SelectedItem.ToString();
                toRecoverListBox.Items.Remove(programName);
                deletedListBox.Items.Add(programName);
            }
            else
            {
                /*do nothing*/
            }
        }

        private void recoverButton_Click(object sender, EventArgs e)
        {
            string[] programs = new string[toRecoverListBox.Items.Count];
            if (toRecoverListBox.Items.Count > 0)
            {
                for (int count = 0; count < toRecoverListBox.Items.Count; count++)
                {
                    programs[count] = toRecoverListBox.Items[count].ToString();
                }
                for (int count = 0; count < programs.Length; count++)
                {
                    try
                    {
                        File.Move(sourcePath + programs[count] + ".prg", destPath + programs[count] + ".prg");
                        toRecoverListBox.Items.Remove(programs[count]);
                    }
                    catch (IOException)
                    {
                        File.Delete(destPath + programs[count] + ".prg");
                        File.Move(sourcePath + programs[count] + ".prg", destPath + programs[count] + ".prg");
                        toRecoverListBox.Items.Remove(programs[count]);
                    }
                }
                if(sendButton.Text == LocRM.GetString("recover", currentCulture))
                {
                    MessageBox.Show(LocRM.GetString("recoveredSucessful", currentCulture));
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("deletedSucessful", currentCulture)); 
                }
                loadDeletedList();
            }
            else
            {
                /* do nothing*/
            }
        }

        private void agreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (agreeCheckBox.Checked)
            {
                sendButton.Enabled = true;
            }
            else
            {
                sendButton.Enabled = false;
            }
        }

    }
}
