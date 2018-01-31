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
using static System.Windows.Forms.ListBox;
using System.Resources;
using System.Globalization;
using TestPlatform.Models;

namespace TestPlatform.Views.ListsPages
{
    public partial class ListManagment : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        string listPath = Global.testFilesPath + Global.listFolderName, suffix;
        string[] filePaths;
        bool shouldPaintOrange = false;
        public ListManagment(string suffix)
        {
            InitializeComponent();
            this.suffix = suffix;
            loadExistingList();
        }

        private void originFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush orangeSolidBrush = new SolidBrush(Color.Orange);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < existingList.Items.Count)
            {
                string text = existingList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else if (text.Contains("   "))
                {
                    if (shouldPaintOrange)
                    {
                        backgroundBrush = orangeSolidBrush;
                    }
                    else
                    {
                        backgroundBrush = whiteSolidBrush;
                    }
                }
                else
                {
                    if (isListUsed(text, suffix))
                    {
                        warningLabel.Visible = true;
                        backgroundBrush = orangeSolidBrush;
                        shouldPaintOrange = true;
                    }
                    else
                    {
                        backgroundBrush = whiteSolidBrush;
                        shouldPaintOrange = false;
                    }
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, existingList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        private void destinationFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush orangeSolidBrush = new SolidBrush(Color.Orange);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < deletingList.Items.Count)
            {
                string text = deletingList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else if (text.Contains("   "))
                {
                    if (shouldPaintOrange)
                    {
                        backgroundBrush = orangeSolidBrush;
                    }
                    else
                    {
                        backgroundBrush = whiteSolidBrush;
                    }
                }
                else
                {
                    if (isListUsed(text, suffix))
                    {
                        warningLabel.Visible = true;
                        backgroundBrush = orangeSolidBrush;
                        shouldPaintOrange = true;
                    }
                    else
                    {
                        backgroundBrush = whiteSolidBrush;
                        shouldPaintOrange = false;
                    }
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, deletingList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        private void existingList_Click(object sender, EventArgs e)
        {
            if (suffix == "_audio" || suffix == "_image")
            {
                int index = existingList.SelectedIndex;
                existingList.ClearSelected();
                if (index != -1)
                {
                    string selected = existingList.Items[index].ToString();
                    if (selected.Contains("   "))
                    {
                        while (existingList.Items[index].ToString().Contains("   "))
                        {
                            index--;
                        }
                    }
                    do
                    {
                        existingList.SetSelected(index++, true);
                    } while (index < existingList.Items.Count && existingList.Items[index].ToString().Contains("   "));
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void deletingList_Click(object sender, EventArgs e)
        {
            if (suffix == "_audio" || suffix == "_image")
            {
                int index = deletingList.SelectedIndex;
                deletingList.ClearSelected();
                if (index != -1)
                {
                    string selected = deletingList.Items[index].ToString();
                    if (selected.Contains("   "))
                    {
                        while (deletingList.Items[index].ToString().Contains("   "))
                        {
                            index--;
                        }
                    }
                    do
                    {
                        deletingList.SetSelected(index++, true);
                    } while (index < deletingList.Items.Count && deletingList.Items[index].ToString().Contains("   "));
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void toDelete_Click(object sender, EventArgs e)
        {
            bool isFirstItem = true;
            int count = 0, limit ;
            SelectedObjectCollection selected = existingList.SelectedItems;
            limit = selected.Count;
            while (count != limit)
            {
                if (isFirstItem)
                {
                    isFirstItem = false;
                    if (selected[0].ToString().Contains("   "))
                    {
                        return;
                    }
                }
                if (isListUsed(selected[0].ToString(), suffix))
                {
                    return;
                }
                else
                {
                    deletingList.Items.Add(selected[0].ToString());
                    existingList.Items.Remove(selected[0]);
                }
                count++;
            }
            deletingList.ClearSelected();
        }

        private void toExisting_Click(object sender, EventArgs e)
        {
            SelectedObjectCollection selected = deletingList.SelectedItems;
            while (selected.Count != 0)
            {
                existingList.Items.Add(selected[0].ToString());
                deletingList.Items.Remove(selected[0]);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private bool isListUsed(string listName, string suffix)
        {
            string[] TRPrograms = Directory.GetFiles(Global.reactionTestFilesPath + Global.programFolderName);
            string[] StroopPrograms = Directory.GetFiles(Global.stroopTestFilesPath + Global.programFolderName);
            foreach (string file in TRPrograms)
            {
                ReactionProgram program = new ReactionProgram();
                program.readProgramFile(file);
                if (suffix == "_image" && program.getImageListFile() != null && program.getImageListFile().ListName == listName)
                {
                    return true;
                }
                else if (suffix == "_audio" && program.getAudioListFile() != null && program.getAudioListFile().ListName == listName)
                {
                    return true;
                }
                else if (suffix == "_words_color")
                {
                    if (program.getWordListFile() != null && ((program.getWordListFile().ListName + "_words") == listName))
                    {
                        return true;
                    } 
                    else if (program.getColorListFile() != null && ((program.getColorListFile().ListName + "_color") == listName))
                    {
                        return true;
                    }
                }
            }
            foreach (string file in StroopPrograms)
            { 
                StroopProgram program = new StroopProgram();
                program.readProgramFile(file);
                if (suffix == "_image" && program.getImageListFile() != null && program.getImageListFile().ListName == listName)
                {
                    return true;
                }
                else if (suffix == "_audio" && program.getAudioListFile() != null && program.getAudioListFile().ListName == listName)
                {
                    return true;
                }
                else if (suffix == "_words_color")
                {
                    if (program.getWordListFile() != null && ((program.getWordListFile().ListName + "_words") == listName))
                    {
                        return true;
                    }
                    else if (program.getColorListFile() != null && ((program.getColorListFile().ListName + "_color") == listName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            Directory.Delete(target_dir, false);
        }

        private void deleteLists()
        {
            if (suffix == "_audio" || suffix == "_image")
            {

                if (deletingList.Items.Count > 0)
                {
                    int count = 0;
                    string currentDirectory = "";
                    do
                    {
                        if (!deletingList.Items[count].ToString().Contains("   "))
                        {
                            if (!isListUsed(deletingList.Items[count].ToString(), suffix))
                            {
                                currentDirectory = listPath + deletingList.Items[count++].ToString() + suffix;
                                DeleteDirectory(currentDirectory);
                            }
                            else
                            {
                                /*do nothing*/
                            }
                        }
                        else
                        {
                            count++;
                        }
                    } while (count < deletingList.Items.Count);
                    count = 0;
                }
            }
            else
            {
                if (deletingList.Items.Count > 0)
                {
                    for (int count = 0; count < deletingList.Items.Count; count++)
                    {
                        try
                        {
                            if (!isListUsed(deletingList.Items[count].ToString(), suffix))
                            {
                                File.Delete(listPath + deletingList.Items[count].ToString() + ".lst");
                            }
                            else
                            {
                                /*do nothing*/
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            loadExistingList();
            deletingList.Items.Clear();
            MessageBox.Show(LocRM.GetString("listsDeleted", currentCulture));
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (deletingList.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("deleteList", currentCulture), LocRM.GetString("delete", currentCulture), MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    deleteLists();
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("listsNotDeleted", currentCulture));
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("listDeleteInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void existingList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deletingList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadExistingList()
        {
            existingList.Items.Clear();
            if (suffix == "_audio" || suffix == "_image")
            {
                if (Directory.Exists(listPath))
                {
                    filePaths = Directory.GetDirectories(listPath, ("*" + suffix));
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        var option = Path.GetFileName(filePaths[i]).Split('_');
                        existingList.Items.Add(option[0]);
                        string[] files = Directory.GetFiles(filePaths[i]);
                        for (int j = 0; j < files.Length; j++)
                        {
                            string fileName = String.Format("   {0}", Path.GetFileName(files[j]));
                            existingList.Items.Add(fileName);
                        }
                    }
                }
            }
            else if (suffix == "_words_color")
            {
                filePaths = Directory.GetFiles(listPath, ("*_words.lst"), SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    var option = Path.GetFileNameWithoutExtension(filePaths[i]).Split('_');
                    existingList.Items.Add(option[0] + "_words");
                    if (File.Exists(listPath + option[0] + "_color.lst"))
                    {
                        existingList.Items.Add(option[0] + "_color");
                    }
                }

                filePaths = Directory.GetFiles(listPath, ("*_color.lst"), SearchOption.AllDirectories);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    var option = Path.GetFileNameWithoutExtension(filePaths[i]).Split('_');
                    if (!existingList.Items.Contains(option[0] + "_color"))
                    {
                        existingList.Items.Add(option[0] + "_color");
                    }
                }
            }
            else
            {
                MessageBox.Show(new ArgumentException().ToString());
                this.Parent.Controls.Remove(this);
            }
        }
        
    }
}
