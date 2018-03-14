using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Controllers;
using TestPlatform.Models;

namespace TestPlatform.Views.MainForms
{
    public partial class ExportUserControl : UserControl
    {
        // properties used to localize strings during runtime
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        // file paths used in methods of this class
        private string listPath = Global.testFilesPath + Global.listFolderName;
        private string reactionPath = Global.reactionTestFilesPath + Global.programFolderName;
        private string matchingPath = Global.matchingTestFilesPath + Global.programFolderName;
        private string stroopPath = Global.stroopTestFilesPath + Global.programFolderName;
        private string experimentPath = Global.experimentTestFilesPath + Global.programFolderName;

        public ExportUserControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            // initializing  origin table with reaction test, stroop test, experiments, color and word lists giving user options from what to export
            InitializeTypeFile(reactionPath, LocRM.GetString("reactionTest", currentCulture), "prg");
            InitializeTypeFile(stroopPath, LocRM.GetString("stroopTest", currentCulture), "prg");
            InitializeTypeFile(matchingPath, LocRM.GetString("matchingTest", currentCulture), "prg");
            InitializeTypeFile(experimentPath, LocRM.GetString("experiment", currentCulture), "prg");
            InitializeTypeFile(listPath, LocRM.GetString("lists", currentCulture), "lst");
            InitializeTypeLists();
            originDataGridView.Refresh();

        }

        // fills table with lists such as image and audio lists, that are composed by a directory full of files, instead of just a file
        private void InitializeTypeLists()
        {
            string[] filePaths = Directory.GetDirectories(listPath, ("*_*"));

            foreach (string filePath in filePaths)
            {
                string file = Path.GetFileNameWithoutExtension(filePath);
                originDataGridView.Rows.Add(file, LocRM.GetString("lists", currentCulture), filePath);
            }
        }

        // fills table with files such as programs and lists that are only composed by one file being .prg or .lst
        private void InitializeTypeFile(string path, string type, string termination)
        {
            string[] filePaths = Directory.GetFiles(path, ("*." + termination), SearchOption.AllDirectories);
            foreach (string filePath in filePaths)
            {
                string file = Path.GetFileNameWithoutExtension(filePath);

                originDataGridView.Rows.Add(file, type, filePath);
            }
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
                        exportDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("stroopTest", currentCulture), Global.stroopTestFilesPath + Global.programFolderName + program.ProgramName + ".prg");
                        removeItemOrigin(program.ProgramName, LocRM.GetString("stroopTest", currentCulture));
                        addLists(program);
                    }
                }
                else if (program.GetType() == typeof(ReactionProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("reactionTest", currentCulture)))
                    {
                        exportDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("reactionTest", currentCulture), Global.reactionTestFilesPath + Global.programFolderName + program.ProgramName + ".prg");
                        removeItemOrigin(program.ProgramName, LocRM.GetString("reactionTest", currentCulture));
                        addLists(program);
                    }
                }
                else if (program.GetType() == typeof(MatchingProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("matching", currentCulture)))
                    {
                        exportDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("matchingTest", currentCulture), Global.matchingTestFilesPath + Global.programFolderName + program.ProgramName + ".prg");
                        removeItemOrigin(program.ProgramName, LocRM.GetString("matchingTest", currentCulture));
                        addLists(program);
                    }
                }
            }
            exportDataGridView.Refresh();
        }

        // verifies if an item is in the export list
        private bool isAlreadyThere(string name, string type)
        {
            foreach(DataGridViewRow row in exportDataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString() == name && row.Cells[1].Value.ToString() == type)
                {
                    return true;
                }
            }
            return false;
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
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                    removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                }
            }
            if (newProgram.getColorListFile() != null)
            {
                string fileName = newProgram.getColorListFile().ListName + "_color";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {                    
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                    removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                }
            }
            if (newProgram.getImageListFile() != null)
            {
                string fileName = newProgram.getImageListFile().ListName + "_image";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                    removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                }
            }
            if (newProgram.getWordListFile() != null)
            {
                string fileName = newProgram.getWordListFile().ListName + "_words";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                    removeItemOrigin(fileName, LocRM.GetString("lists", currentCulture));
                }
            }
            exportDataGridView.Refresh();
        }

        // remove item from the origin list, used when item is being transfered to export list
        private void removeItemOrigin(string itemName, string itemType)
        {
            foreach(DataGridViewRow row in originDataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(itemName) && row.Cells[1].Value.ToString().Equals(itemType))
                {
                    int rowIndex = row.Index;
                    originDataGridView.Rows.RemoveAt(rowIndex);
                    break;
                }
            }            
        }

        // exporting items to directories accordingly to type and zipping them together
        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog  saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Filter = "Zip Files | *.zip";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != ""  && !File.Exists(saveFileDialog.FileName))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/");
                Directory.CreateDirectory(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "StroopProgram");
                Directory.CreateDirectory(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "ReactionProgram");
                Directory.CreateDirectory(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "ExperimentProgram");
                Directory.CreateDirectory(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "Lists");
                Directory.CreateDirectory(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "MatchingProgram");

                // exporting each row according to type: list, reaction program, stroop program or experiment program
                foreach (DataGridViewRow row in exportDataGridView.Rows)
                {
                    if (row.Cells[1].Value.ToString() == LocRM.GetString("lists", currentCulture))
                    {
                        if ((row.Cells[0].Value.ToString().Split('_')[1] == "color") || (row.Cells[0].Value.ToString().Split('_')[1] == "words"))
                        {
                            exportFile(row.Cells[2].Value.ToString(), Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/Lists/" + row.Cells[0].Value.ToString() + ".lst");
                        }
                        else
                        {
                            exportListContent(row.Cells[0].Value.ToString(), Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/Lists");
                        }
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("reactionTest", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "ReactionProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("stroopTest", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "StroopProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("matchingTest", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "MatchingProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("experiment", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/" + "ExperimentProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    
                }

                ZipFile.CreateFromDirectory(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/", @saveFileDialog.FileName);
                Directory.Delete(Path.GetDirectoryName(saveFileDialog.FileName) + "/ExportingFiles/", true);
                MessageBox.Show(LocRM.GetString("exportSuccess", currentCulture));
                Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show(LocRM.GetString("exportDirectory", currentCulture));
            }
        }

        private void exportListContent(string listName, string path)
        {
            string listDestination = path + "/" + listName + "/";
            Directory.CreateDirectory(listDestination);

            DirectoryInfo dir = new DirectoryInfo(listPath + "/" + listName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(listDestination, file.Name);
                file.CopyTo(temppath, false);
            }

        }

        private void exportFile(string sourceFile, string destinationPath)
        {
            System.IO.File.Copy(sourceFile, destinationPath, true);
        }

        private void addToDestinationList_Click(object sender, EventArgs e)
        {
            string selectedRowType = originDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            string selectedRowName = originDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int index = exportDataGridView.Rows.Add();
            exportDataGridView.Rows[index].Cells[0].Value = (originDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            exportDataGridView.Rows[index].Cells[1].Value = (originDataGridView.SelectedRows[0].Cells[1].Value.ToString());
            exportDataGridView.Rows[index].Cells[2].Value = (originDataGridView.SelectedRows[0].Cells[2].Value.ToString());


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
            else if (selectedRowType == LocRM.GetString("matchingTest", currentCulture))
            {
                MatchingProgram newMatching = new MatchingProgram(Global.matchingTestFilesPath + Global.programFolderName + selectedRowName + ".prg");
                addLists(newMatching);
            }
            else if (selectedRowType == LocRM.GetString("experiment", currentCulture))
            {
               addPrograms(selectedRowName);
            }
            else
            {
                /* do nothing*/
            }
        }

        private void addToOriginList_Click(object sender, EventArgs e)
        {
            if (exportDataGridView.SelectedRows.Count > 0)
            {
                int index = originDataGridView.Rows.Add();
                originDataGridView.Rows[index].Cells[0].Value = (exportDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                originDataGridView.Rows[index].Cells[1].Value = (exportDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                originDataGridView.Rows[index].Cells[2].Value = (exportDataGridView.SelectedRows[0].Cells[2].Value.ToString());
                exportDataGridView.Rows.Remove(exportDataGridView.SelectedRows[0]);
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("exportInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void originDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
