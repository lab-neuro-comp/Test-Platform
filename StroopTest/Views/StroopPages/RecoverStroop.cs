using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using System.Globalization;

namespace TestPlatform.Views.StroopPages
{
    public partial class RecoverStroop : UserControl
    {

        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        //global brushes with ordinary/selected colors
        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.Red);
        private bool hasConflict = false;

        //custom method to draw the items, don't forget to set DrawMode of the ListBox to OwnerDrawFixed
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
                else if (File.Exists(Global.stroopTestFilesPath + Global.programFolderName + text + ".prg") == true)
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
                else if (File.Exists(Global.stroopTestFilesPath + Global.programFolderName + text + ".prg") == true)
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

        public RecoverStroop()
        {
            InitializeComponent();
            loadDeletedList();
        }

        private void loadDeletedList()
        {
            string[] filePaths;
            string programName;
            deletedListBox.Items.Clear();
            MessageBox.Show(Global.stroopTestFilesBackupPath);
            filePaths = Directory.GetFiles(Global.stroopTestFilesBackupPath, ("*.prg"), SearchOption.AllDirectories);
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
                recoverButton.Enabled = false;
            }
            else
            {
                agreeCheckBox.Visible = false;
                warningLabel.Visible = false;
                recoverButton.Enabled = true;
            }
        }

        private void checkConflict()
        {
            for (int count = 0; count < deletedListBox.Items.Count; count++)
            {
                if (File.Exists(Global.stroopTestFilesPath + Global.programFolderName + deletedListBox.Items[count].ToString() + ".prg"))
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
                        File.Move(Global.stroopTestFilesBackupPath + programs[count] + ".prg", Global.stroopTestFilesPath + Global.programFolderName + programs[count] + ".prg");
                        toRecoverListBox.Items.Remove(programs[count]);
                    }
                    catch (IOException)
                    {
                        File.Delete(Global.stroopTestFilesPath + Global.programFolderName + programs[count] + ".prg");
                        File.Move(Global.stroopTestFilesBackupPath + programs[count] + ".prg", Global.stroopTestFilesPath + Global.programFolderName + programs[count] + ".prg");
                        toRecoverListBox.Items.Remove(programs[count]);
                    }
                }
                MessageBox.Show(LocRM.GetString("recoveredSucessful", currentCulture));
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
                recoverButton.Enabled = true;
            }
            else
            {
                recoverButton.Enabled = false;
            }
        }
    }
}
