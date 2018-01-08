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
        private string removeItemOrigin(string itemName, string itemType)
        {
            foreach (DataGridViewRow row in originDataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(itemName) && row.Cells[1].Value.ToString().Equals(itemType))
                {
                    int rowIndex = row.Index;
                    string path = originDataGridView.Rows[rowIndex].Cells[2].Value.ToString();
                    originDataGridView.Rows.RemoveAt(rowIndex);
                    return path;
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
                        string path = removeItemOrigin(program.ProgramName, LocRM.GetString("stroopTest", currentCulture));
                        importDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("stroopTest", currentCulture), path);
                        addLists(program);
                    }
                }
                else if (program.GetType() == typeof(ReactionProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("reactionTest", currentCulture)))
                    {
                        string path = removeItemOrigin(program.ProgramName, LocRM.GetString("reactionTest", currentCulture));
                        importDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("reactionTest", currentCulture), path);
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
                    string importPath = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), importPath);
                }
            }
            if (newProgram.getColorListFile() != null)
            {
                string fileName = newProgram.getColorListFile().ListName + "_color";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    string importPath = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), importPath);
                }
            }
            if (newProgram.getImageListFile() != null)
            {
                string fileName = newProgram.getImageListFile().ListName + "_image";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    string importPath = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), importPath);
                }
            }
            if (newProgram.getWordListFile() != null)
            {
                string fileName = newProgram.getWordListFile().ListName + "_words";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    string importPath = removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                    importDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), importPath);
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
                if (Directory.Exists(importDirectory))
                {
                    Directory.Delete(importDirectory, true);
                    Directory.CreateDirectory(importDirectory);
                }
                else
                {
                    Directory.CreateDirectory(importDirectory);
                }
                ZipFile.ExtractToDirectory(openFileDialog.FileName, importDirectory);
                fileTextBox.Text = openFileDialog.FileName;

                addFilesToOriginGrid(importDirectory + "/StroopProgram/", LocRM.GetString("stroopTest", currentCulture), stroopPath);
                addFilesToOriginGrid(importDirectory + "/ReactionProgram/", LocRM.GetString("reactionTest", currentCulture), reactionPath);
                addFilesToOriginGrid(importDirectory + "/ExperimentProgram/", LocRM.GetString("experiment", currentCulture), experimentPath);
                addFilesToOriginGrid(importDirectory + "/Lists/", LocRM.GetString("lists", currentCulture), listPath);
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

        private void addToDestinationList_Click(object sender, EventArgs e)
        {
            string selectedRowType = originDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            string selectedRowName = originDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int index = importDataGridView.Rows.Add();
            importDataGridView.Rows[index].Cells[0].Value = (originDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            importDataGridView.Rows[index].Cells[1].Value = (originDataGridView.SelectedRows[0].Cells[1].Value.ToString());
            importDataGridView.Rows[index].Cells[2].Value = (originDataGridView.SelectedRows[0].Cells[2].Value.ToString());


            originDataGridView.Rows.Remove(originDataGridView.SelectedRows[0]);

            if (selectedRowType == LocRM.GetString("stroopTest", currentCulture))
            {
                StroopProgram newProgram = new StroopProgram();
                newProgram.readProgramFile(stroopPath + selectedRowName + ".prg");
                addLists(newProgram);

            }
            else if (selectedRowType == LocRM.GetString("reactionTest", currentCulture))
            {
                ReactionProgram newReaction = new ReactionProgram(Global.reactionTestFilesPath + Global.programFolderName + selectedRowName + ".prg");
                addLists(newReaction);
            }
            else if (selectedRowType == LocRM.GetString("experiment", currentCulture))
            {
                addPrograms(selectedRowName);
            }
        }
    }
}
