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
        bool stopLoading = false;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        string listPath = Global.testFilesPath + Global.listFolderName, suffix;
        string[] filePaths;
        char mode;
        public ListManagment(string suffix, char mode)
        {
            if(mode != 'r' && mode != 'd') //r = recover, d = delete, none = invalid.
            {
                throw new ArgumentException();
            }
            InitializeComponent();
            this.suffix = suffix;
            this.mode = mode;
            setUpMessages();
            loadExistingList();
        }

        private void setUpMessages()
        {
            if(mode == 'r') //recover
            {
                excludedLists.Visible = true;
                recoverButton.Visible = true;
                deleteButton.Visible = false;
                recoveringLists.Visible = true;
            }
            else //delete
            {
                existingLabel.Visible = true;
                deletingLabel.Visible = true;
                recoverButton.Visible = false;
                deleteButton.Visible = true;
            }

        }

        private void originFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush orangeSolidBrush = new SolidBrush(Color.Orange);
            SolidBrush redSolidBrush = new SolidBrush(Color.Red);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (!stopLoading && index >= 0 && index < existingList.Items.Count)
            {
                string text = existingList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else
                {
                    if (mode == 'd' && isListUsed(text, suffix, out stopLoading))
                    {
                        warningLabel.Visible = true;
                        backgroundBrush = orangeSolidBrush;
                    }
                    else if (listAlreadyExists(text, suffix))
                    {
                        backgroundBrush = redSolidBrush;
                        existingListWarning.Visible = true;
                        existingListCheckBox.Visible = true;
                        recoverButton.Enabled = false;
                        deleteButton.Enabled = false;
                    }
                    else
                    {
                        backgroundBrush = whiteSolidBrush;
                    }
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, existingList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        bool listAlreadyExists(string text, string suffix)
        {
            if (mode == 'd')
            {
                if (suffix == "_image" || suffix == "_audio")
                {
                    if (Directory.Exists(Global.listFilesBackup + text))
                    {
                        return true;
                    }
                }
                else if (File.Exists(Global.listFilesBackup + text + ".lst"))
                {
                    return true;
                }
            }
            else
            {
                if (suffix == "_image" || suffix == "_audio")
                {
                    if (Directory.Exists(Global.testFilesPath + Global.listFolderName + text))
                    {
                        return true;
                    }
                }
                else if (File.Exists(Global.testFilesPath + Global.listFolderName + text + ".lst"))
                {
                    return true;
                }
            }
            return false;
        }

        private void destinationFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush orangeSolidBrush = new SolidBrush(Color.Orange);
            SolidBrush redSolidBrush = new SolidBrush(Color.Red);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (!stopLoading && index >= 0 && index < deletingList.Items.Count)
            {
                string text = deletingList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else
                {
                    if (mode == 'd' && isListUsed(text, suffix, out stopLoading))
                    {
                        warningLabel.Visible = true;
                        backgroundBrush = orangeSolidBrush;
                    }
                    else if (listAlreadyExists(text, suffix))
                    {
                        backgroundBrush = redSolidBrush;
                        existingListWarning.Visible = true;
                        existingListCheckBox.Visible = true;
                        recoverButton.Enabled = false;
                        deleteButton.Enabled = false;
                    }
                    else
                    {
                        backgroundBrush = whiteSolidBrush;
                    }
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, deletingList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        private void toDelete_Click(object sender, EventArgs e)
        {
            int count = 0, limit ;
            SelectedObjectCollection selected = existingList.SelectedItems;
            limit = selected.Count;
            while (count != limit)
            {
                if (mode == 'd' && isListUsed(selected[0].ToString(), suffix, out stopLoading))
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

        private bool isListUsed(string listName, string suffix, out bool stopProcess)
        {
            string currentProgram = "", originPath = "", programName = "", destinationPath = "";
            string[] TRPrograms = Directory.GetFiles(Global.reactionTestFilesPath + Global.programFolderName);
            string[] StroopPrograms = Directory.GetFiles(Global.stroopTestFilesPath + Global.programFolderName);
            string[] MatchingPrograms = Directory.GetFiles(Global.matchingTestFilesPath + Global.programFolderName);
            try
            {
                foreach (string file in TRPrograms)
                {
                    originPath = Global.reactionTestFilesPath + Global.programFolderName;
                    destinationPath = Global.reactionTestFilesBackupPath;
                    programName = Path.GetFileNameWithoutExtension(file);
                    currentProgram = Path.GetFileNameWithoutExtension(file) + " (" + LocRM.GetString("reactionTest", currentCulture) + ")";
                    ReactionProgram program = new ReactionProgram();
                    program.readProgramFile(file);
                    if (suffix == "_image" && program.getImageListFile() != null && program.getImageListFile().ListName == listName)
                    {
                        stopProcess = false;
                        return true;
                    }
                    else if (suffix == "_audio" && program.getAudioListFile() != null && program.getAudioListFile().ListName == listName)
                    {
                        stopProcess = false;
                        return true;
                    }
                    else if (suffix == "_words_color")
                    {
                        if (program.getWordListFile() != null && ((program.getWordListFile().ListName + "_words") == listName))
                        {
                            stopProcess = false;
                            return true;
                        }
                        else if (program.getColorListFile() != null && ((program.getColorListFile().ListName + "_color") == listName))
                        {
                            stopProcess = false;
                            return true;
                        }
                    }
                }
                foreach (string file in StroopPrograms)
                {
                    originPath = Global.stroopTestFilesPath + Global.programFolderName;
                    destinationPath = Global.stroopTestFilesBackupPath;
                    programName = Path.GetFileNameWithoutExtension(file);
                    StroopProgram program = new StroopProgram();
                    currentProgram = Path.GetFileNameWithoutExtension(file) + " (" + LocRM.GetString("stroopTest", currentCulture) + ")";
                    program.readProgramFile(file);
                    if (suffix == "_image" && program.getImageListFile() != null && program.getImageListFile().ListName == listName)
                    {
                        stopProcess = false;
                        return true;
                    }
                    else if (suffix == "_audio" && program.getAudioListFile() != null && program.getAudioListFile().ListName == listName)
                    {
                        stopProcess = false;
                        return true;
                    }
                    else if (suffix == "_words_color")
                    {
                        if (program.getWordListFile() != null && ((program.getWordListFile().ListName + "_words") == listName))
                        {
                            stopProcess = false;
                            return true;
                        }
                        else if (program.getColorListFile() != null && ((program.getColorListFile().ListName + "_color") == listName))
                        {
                            stopProcess = false;
                            return true;
                        }
                    }
                }
                foreach (string file in MatchingPrograms)
                {
                    originPath = Global.matchingTestFilesPath + Global.programFolderName;
                    destinationPath = Global.matchingTestFilesBackupPath;
                    programName = Path.GetFileNameWithoutExtension(file);
                    MatchingProgram program = new MatchingProgram();
                    currentProgram = Path.GetFileNameWithoutExtension(file) + " (" + LocRM.GetString("matchingTest", currentCulture) + ")";
                    program.readProgramFile(file);
                    if (suffix == "_image" && program.getImageListFile() != null && program.getImageListFile().ListName == listName)
                    {
                        stopProcess = false;
                        return true;
                    }
                    else if (suffix == "_audio" && program.getAudioListFile() != null && program.getAudioListFile().ListName == listName)
                    {
                        stopProcess = false;
                        return true;
                    }
                    else if (suffix == "_words_color")
                    {
                        if (program.getWordListFile() != null && ((program.getWordListFile().ListName + "_words") == listName))
                        {
                            stopProcess = false;
                            return true;
                        }
                        else if (program.getColorListFile() != null && ((program.getColorListFile().ListName + "_color") == listName))
                        {
                            stopProcess = false;
                            return true;
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                DialogResult dialogResult =  MessageBox.Show(LocRM.GetString("wanstPossibleToRecoverLists", currentCulture) + "\"" + currentProgram + "\"" +
                    LocRM.GetString("hasMissingLists", currentCulture) + e.Message + "\""
                    + LocRM.GetString("missingListSolution", currentCulture), LocRM.GetString("error", currentCulture), MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    DialogResult shouldDelete = MessageBox.Show(LocRM.GetString("deleteProgram", currentCulture) + currentProgram + "?", LocRM.GetString("delete", currentCulture), MessageBoxButtons.YesNo);
                    if(shouldDelete == DialogResult.Yes)
                    {
                        try
                        {
                            File.Move(originPath + programName + ".prg", destinationPath + programName + ".prg");
                        }
                        catch (IOException)
                        {
                            File.Delete(destinationPath + programName  + ".prg");
                            File.Move(originPath + programName + ".prg", destinationPath + programName + ".prg");
                        }
                        MessageBox.Show(LocRM.GetString("deletedSucessful", currentCulture));
                        this.Parent.Controls.Remove(this);
                        ListManagment newListManagment = new ListManagment(suffix, mode);
                        Global.GlobalFormMain._contentPanel.Controls.Add(newListManagment);
                        stopProcess = true;
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(LocRM.GetString("FilesNotDeleted", currentCulture));
                        this.Parent.Controls.Remove(this);
                        stopProcess = true;
                        return false;
                    }
                }
                else
                {
                    this.Parent.Controls.Remove(this);
                    stopProcess = true;
                    return false;
                }
            }
            stopProcess = false;
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
        
        private void recoverLists()
        {
            if (suffix == "_audio" || suffix == "_image")
            {
                if (deletingList.Items.Count > 0)
                {
                    int count = 0;
                    string currentDirectory = "";
                    do
                    {
                        if (!isListUsed(deletingList.Items[count].ToString(), suffix, out stopLoading))
                        {
                            try
                            {
                                currentDirectory = Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + suffix;
                                Directory.Move(Global.listFilesBackup + deletingList.Items[count].ToString() + suffix, currentDirectory);
                                count++;
                            }
                            catch (IOException)
                            {
                                Directory.Delete(Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + suffix, true);
                                Directory.Move(Global.listFilesBackup + deletingList.Items[count].ToString() + suffix, listPath + deletingList.Items[count].ToString() + suffix);
                                count++;
                            }
                        }
                        else
                        {
                            /*do nothing*/
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
                        if (mode == 'r' || !isListUsed(deletingList.Items[count].ToString(), suffix, out stopLoading))
                        {
                            try
                            {
                                File.Move(Global.listFilesBackup + deletingList.Items[count].ToString() + ".lst", Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + ".lst");
                            }
                            catch (IOException)
                            {
                                File.Delete(Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + ".lst");
                                File.Move(Global.listFilesBackup + deletingList.Items[count].ToString() + ".lst", Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + ".lst");
                            }
                        }
                        else
                        {
                            /*do nothing*/
                        }
                    }
                }
            }
            loadExistingList();
            deletingList.Items.Clear();
            MessageBox.Show(LocRM.GetString("listsRecovered", currentCulture));
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
                        if (mode == 'r' || !isListUsed(deletingList.Items[count].ToString(), suffix, out stopLoading))
                        {
                            try
                            {
                                currentDirectory = Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + suffix;
                                Directory.Move(currentDirectory, Global.listFilesBackup + deletingList.Items[count++].ToString() + suffix);
                            }
                            catch (IOException)
                            {
                                Directory.Delete(Global.listFilesBackup + deletingList.Items[count++].ToString() + suffix, true);
                                Directory.Move(Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + suffix, Global.listFilesBackup + deletingList.Items[count++].ToString() + suffix);
                            }
                        }
                        else
                        {
                            /*do nothing*/
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
                        if (mode == 'r' || !isListUsed(deletingList.Items[count].ToString(), suffix, out stopLoading))
                        {
                            try
                            {
                                File.Move(Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + ".lst", Global.listFilesBackup + deletingList.Items[count].ToString() + ".lst");
                            }
                            catch (IOException)
                            {
                                File.Delete(Global.listFilesBackup + deletingList.Items[count].ToString() + ".lst");
                                File.Move(Global.testFilesPath + Global.listFolderName + deletingList.Items[count].ToString() + ".lst", Global.listFilesBackup + deletingList.Items[count].ToString() + ".lst");
                            }
                        }
                        else
                        {
                            /*do nothing*/
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

        private void recoverButton_Click(object sender, EventArgs e)
        {
            if (deletingList.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("recoverList", currentCulture), LocRM.GetString("recover", currentCulture), MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    recoverLists();
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("listsNotRecovered", currentCulture));
                }
            }
        }

        private void deletingList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void existingListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (existingListCheckBox.Checked)
            {
                recoverButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            else
            {
                recoverButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        private void loadExistingList()
        {
            existingList.Items.Clear();
            if(mode == 'd')
            {
                listPath = Global.testFilesPath + Global.listFolderName;
            }
            else
            {
                listPath = Global.listFilesBackup;
            }
            if (suffix == "_audio" || suffix == "_image")
            {
                if (Directory.Exists(listPath))
                {
                    filePaths = Directory.GetDirectories(listPath, ("*" + suffix));
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        var option = Path.GetFileName(filePaths[i]).Split('_');
                        existingList.Items.Add(option[0]);
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
