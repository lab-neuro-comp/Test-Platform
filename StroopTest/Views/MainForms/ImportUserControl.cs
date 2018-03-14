using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Globalization;
using System.Resources;
using TestPlatform.Models;

namespace TestPlatform.Views.MainForms
{
    public partial class ImportUserControl : UserControl
    {
        private string importDirectory = Global.testFilesPath + "/import";

        // properties used to localize strings during runtime
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        // file paths used in methods of this class

    private string listPath = Global.testFilesPath + Global.listFolderName;
        private string reactionPath = Global.reactionTestFilesPath + Global.programFolderName;
        private string matchingPath = Global.matchingTestFilesPath + Global.programFolderName;
        private string stroopPath = Global.stroopTestFilesPath + Global.programFolderName;
        private string experimentPath = Global.experimentTestFilesPath + Global.programFolderName;

        public ImportUserControl()
        {
            InitializeComponent();
        }

        private void importFile(string currentDirectory, string fileName,string targetDirectory)
        {
            string destinationPath = Path.Combine(targetDirectory, fileName);
            string sourcePath = Path.Combine(currentDirectory, fileName);
            File.Copy(sourcePath, destinationPath, true);
        }

        private void addFilesToOriginGrid(string directory, string type, string destination)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                int row = originDataGridView.Rows.Add(Path.GetFileNameWithoutExtension(file.Name), type, directory);
                if (File.Exists(destination + file.Name))
                {
                    warningCheckBox.Visible = true;
                    warningMessage.Visible = true;
                    originDataGridView.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                int row = originDataGridView.Rows.Add(subdir.Name, type, directory);
                if (Directory.Exists(destination + "/" + subdir.Name))
                {
                    warningCheckBox.Visible = true;
                    warningMessage.Visible = true;
                    originDataGridView.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void importListContent(string listName, string listSourcePath)
        {
            DirectoryInfo dir = new DirectoryInfo(listSourcePath + "/" + listName);
            FileInfo[] files = dir.GetFiles();

            // create directory and copy files that are in list to it
            Directory.CreateDirectory(listPath + "/" + listName);
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(listPath + "/" + listName, file.Name);
                file.CopyTo(temppath, true);
            }
        }

        // verifies if an item is in the export list
        private bool isAlreadyThere(string name, string type)
        {
            foreach (DataGridViewRow row in importDataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString() == name && row.Cells[1].Value.ToString() == type)
                {
                    return true;
                }
            }
            return false;
        }

        // remove item from the origin list, used when item is being transfered to export list
        private string[] removeItemOrigin(string itemName, string itemType)
        {
            foreach (DataGridViewRow row in originDataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(itemName) && row.Cells[1].Value.ToString().Equals(itemType))
                {
                    int rowIndex = row.Index;
                    string path = originDataGridView.Rows[rowIndex].Cells[2].Value.ToString();
                    string color = originDataGridView.Rows[rowIndex].DefaultCellStyle.BackColor.Name.ToString();
                    originDataGridView.Rows.RemoveAt(rowIndex);
                    return new string[] { path, color };
                }
            }
            return null;
        }

        // verifies which programs are in an experiment and  add it and its lists to export list in case they aren't already there
        private void addPrograms(string experimentName)
        {
            ExperimentProgram experiment = new ExperimentProgram();
            experiment.ExperimentName = experimentName;
            experiment.ReadProgramFile();
            foreach (Program program in experiment.ProgramList)
            {
                if (program.GetType() == typeof(StroopProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("stroopTest", currentCulture)))
                    {
                        string[] info = removeItemOrigin(program.ProgramName, LocRM.GetString("stroopTest", currentCulture));
                        int index = importDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("stroopTest", currentCulture), info[0]);
                        importDataGridView.Rows[index].DefaultCellStyle.BackColor = Color.FromName(info[1]);
                        addLists(program);
                    }
                }
                else if (program.GetType() == typeof(ReactionProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("reactionTest", currentCulture)))
                    {
                        string[] info = removeItemOrigin(program.ProgramName, LocRM.GetString("reactionTest", currentCulture));
                        int index = importDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("reactionTest", currentCulture), info[0]);
                        importDataGridView.Rows[index].DefaultCellStyle.BackColor = Color.FromName(info[1]);
                        addLists(program);
                    }
                }
                else if (program.GetType() == typeof(MatchingProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("matchingTest", currentCulture)))
                    {
                        string[] info = removeItemOrigin(program.ProgramName, LocRM.GetString("matchingTest", currentCulture));
                        int index = importDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("matchingTest", currentCulture), info[0]);
                        importDataGridView.Rows[index].DefaultCellStyle.BackColor = Color.FromName(info[1]);
                        addLists(program);
                    }
                }
            }
            importDataGridView.Refresh();
        }

        // add lists from a program to export list, in case they aren't already there
        private void addLists(Program newProgram)
        {
            string path = listPath;
            if (newProgram.getAudioListFile() != null)
            {
                string fileName = newProgram.getAudioListFile().ListName + "_audio";

                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    string[] info = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    int index = importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), info[0]);
                    importDataGridView.Rows[index].DefaultCellStyle.BackColor = Color.FromName(info[1]);
                }
            }
            if (newProgram.getColorListFile() != null)
            {
                string fileName = newProgram.getColorListFile().ListName + "_color";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    string[] info = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    int index = importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), info[0]);
                    importDataGridView.Rows[index].DefaultCellStyle.BackColor = Color.FromName(info[1]);
                }
            }
            if (newProgram.getImageListFile() != null)
            {
                string fileName = newProgram.getImageListFile().ListName + "_image";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    string[] info = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    int index = importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), info[0]);
                    importDataGridView.Rows[index].DefaultCellStyle.BackColor = Color.FromName(info[1]);
                }
            }
            if (newProgram.getWordListFile() != null)
            {
                string fileName = newProgram.getWordListFile().ListName + "_words";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    string[] info = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    int index = importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), info[0]);
                    importDataGridView.Rows[index].DefaultCellStyle.BackColor = Color.FromName(info[1]);
                }
            }
            importDataGridView.Refresh();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZIP|*.zip";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(importDirectory);
                originDataGridView.Rows.Clear();
                importDataGridView.Rows.Clear();
                if (Directory.Exists(importDirectory))
                {
                    Directory.Delete(importDirectory, true);
                    
                }
                else
                {
                    /* do nothing */
                }
                ZipFile.ExtractToDirectory(openFileDialog.FileName, importDirectory);
                fileTextBox.Text = openFileDialog.FileName;

                addFilesToOriginGrid(importDirectory + "/StroopProgram/", LocRM.GetString("stroopTest", currentCulture), stroopPath);
                addFilesToOriginGrid(importDirectory + "/ReactionProgram/", LocRM.GetString("reactionTest", currentCulture), reactionPath);
                addFilesToOriginGrid(importDirectory + "/MatchingProgram/", LocRM.GetString("matchingTest", currentCulture), matchingPath);
                addFilesToOriginGrid(importDirectory + "/ExperimentProgram/", LocRM.GetString("experiment", currentCulture), experimentPath);
                addFilesToOriginGrid(importDirectory + "/Lists/", LocRM.GetString("lists", currentCulture), listPath);
            }
            else
            {
                /* do nothing */
            }
        }

        private void importAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (importAllCheckbox.Checked)
            {
                for (int i = 0; i < originDataGridView.Rows.Count; i++)
                {
                    int row = importDataGridView.Rows.Add();
                    importDataGridView.Rows[row].DefaultCellStyle.BackColor = originDataGridView.Rows[i].DefaultCellStyle.BackColor;

                    for (int j = 0; j < originDataGridView.Columns.Count; j++)
                    {
                        importDataGridView.Rows[i].Cells[j].Value = originDataGridView.Rows[i].Cells[j].Value;

                    }
                }
                originDataGridView.Rows.Clear();
            }
            else
            {
                /* do nothing */
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                foreach (DataGridViewRow row in importDataGridView.Rows)
                {
                    if (row.Cells[1].Value.ToString() == LocRM.GetString("lists", currentCulture))
                    {
                        if ((row.Cells[0].Value.ToString().Split('_')[1] == "color") || (row.Cells[0].Value.ToString().Split('_')[1] == "words"))
                        {
                            importFile(row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString() + ".lst", listPath);
                        }
                        else
                        {
                            importListContent(row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString());
                        }
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("reactionTest", currentCulture))
                    {
                        importFile(row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString() + ".prg", reactionPath);
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("matchingTest", currentCulture))
                    {
                        importFile(row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString() + ".prg", matchingPath);
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("stroopTest", currentCulture))
                    {
                        importFile(row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString() + ".prg", stroopPath);
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("experiment", currentCulture))
                    {
                        importFile(row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString() + ".prg", experimentPath);
                    }

                }

                MessageBox.Show(LocRM.GetString("importSuccess", currentCulture));
                Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
            }
        }

        private void addToDestinationList_Click(object sender, EventArgs e)
        {
            // if there is any selected row in origin file, transfer it to import list
            if (originDataGridView.SelectedRows.Count > 0)
            {
                string selectedRowType = originDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                string selectedRowName = originDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                int i = originDataGridView.SelectedRows[0].Index;
                int index = importDataGridView.Rows.Add();
                importDataGridView.Rows[index].Cells[0].Value = (originDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                importDataGridView.Rows[index].Cells[1].Value = (originDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                importDataGridView.Rows[index].Cells[2].Value = (originDataGridView.SelectedRows[0].Cells[2].Value.ToString());
                importDataGridView.Rows[index].DefaultCellStyle.BackColor = originDataGridView.Rows[i].DefaultCellStyle.BackColor;

                originDataGridView.Rows.Remove(originDataGridView.SelectedRows[0]);

                if (selectedRowType == LocRM.GetString("stroopTest", currentCulture))
                {
                    StroopProgram newProgram = new StroopProgram();
                    newProgram.readProgramFile(importDirectory + "/StroopProgram/" + selectedRowName + ".prg");
                    addLists(newProgram);

                }
                else if (selectedRowType == LocRM.GetString("reactionTest", currentCulture))
                {
                    ReactionProgram newReaction = new ReactionProgram(importDirectory + "/ReactionProgram/" + selectedRowName + ".prg");
                    addLists(newReaction);
                }
                else if(selectedRowType == LocRM.GetString("matchingTest", currentCulture))
                {
                    MatchingProgram newProgram = new MatchingProgram(importDirectory + "/MatchingProgram/" + selectedRowName + ".prg");
                    addLists(newProgram);
                }
                else if (selectedRowType == LocRM.GetString("experiment", currentCulture))
                {
                    addPrograms(selectedRowName);
                }
            }
            else
            {

            }

        }

        private void addToOriginList_Click(object sender, EventArgs e)
        {
            if (importDataGridView.SelectedRows.Count > 0)
            {
                int index = originDataGridView.Rows.Add();
                originDataGridView.Rows[index].Cells[0].Value = (importDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                originDataGridView.Rows[index].Cells[1].Value = (importDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                originDataGridView.Rows[index].Cells[2].Value = (importDataGridView.SelectedRows[0].Cells[2].Value.ToString());
                originDataGridView.Rows[index].DefaultCellStyle.BackColor = importDataGridView.SelectedRows[0].DefaultCellStyle.BackColor;

                importDataGridView.Rows.Remove(importDataGridView.SelectedRows[0]);
            }
            else
            {
                /* do nothing */
            }
        }

        private void importDataGridView_Validating(object sender, CancelEventArgs e)
        {
            if (importDataGridView.RowCount == 0)
            {
                errorProvider1.SetError(importDataGridView, LocRM.GetString("fieldNotFilled", currentCulture));
                e.Cancel = true;
            }
        }

        private void importDataGridView_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(importDataGridView, "");
        }

        private void fileTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(fileTextBox, "");
        }

        private void fileTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (fileTextBox.Text.Length == 0)
            {
                errorProvider1.SetError(fileTextBox, LocRM.GetString("fieldNotFilled", currentCulture));
                e.Cancel = true;
            }
        }

        private void warningCheckBox_Validating(object sender, CancelEventArgs e)
        {
            if (warningCheckBox.Visible && !warningCheckBox.Checked)
            {
                errorProvider1.SetError(warningCheckBox, LocRM.GetString("agreeConditions", currentCulture));
                e.Cancel = true;
            }

        }

        private void warningCheckBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(warningCheckBox, "");
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("importInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void importDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
