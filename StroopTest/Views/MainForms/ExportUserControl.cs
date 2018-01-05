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
        private string listPath = Global.testFilesPath + Global.listFolderName;
        private string reactioPath = Global.reactionTestFilesPath + Global.programFolderName;
        private string stroopPath = Global.stroopTestFilesPath + Global.programFolderName;
        private string experimentPath = Global.experimentTestFilesPath + Global.programFolderName;

        public ExportUserControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            // initializing table with reaction test, stroop test, experiments, color and word lists
            InitializeTypeFile(reactioPath, LocRM.GetString("reactionTest", currentCulture), "prg");
            InitializeTypeFile(stroopPath, LocRM.GetString("stroopTest", currentCulture), "prg");
            InitializeTypeFile(experimentPath, LocRM.GetString("experiment", currentCulture), "prg");
            InitializeTypeFile(listPath, LocRM.GetString("lists", currentCulture), "lst");

            InitializeTypeLists();

            originDataGridView.Refresh();

            
            
        }

        private void InitializeTypeLists()
        {
            string[] filePaths = Directory.GetDirectories(listPath, ("*_*"));

            foreach (string filePath in filePaths)
            {
                string file = Path.GetFileNameWithoutExtension(filePath);
                originDataGridView.Rows.Add(file, LocRM.GetString("lists", currentCulture), filePath);
            }
        }

        private void InitializeTypeFile(string path, string type, string termination)
        {
            string[] filePaths = Directory.GetFiles(path, ("*." + termination), SearchOption.AllDirectories);
            foreach (string filePath in filePaths)
            {
                string file = Path.GetFileNameWithoutExtension(filePath);
                Console.WriteLine("File> " + file + "Type> " + type + "path > " + path);

                originDataGridView.Rows.Add(file, type, filePath);
            }
        }

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
                else if(program.GetType() == typeof(ReactionProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("reactionTest", currentCulture)))
                    {
                        exportDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("reactionTest", currentCulture), Global.reactionTestFilesPath + Global.programFolderName + program.ProgramName + ".prg");
                        removeItemOrigin(program.ProgramName, LocRM.GetString("reactionTest", currentCulture));
                        addLists(program);
                    }
                }
            }
            exportDataGridView.Refresh();
        }

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

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog  saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Filter = ".zip";
            saveFileDialog.Title = "Save exporting files";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != ""  && !File.Exists(saveFileDialog.FileName))
            {
                Directory.CreateDirectory(saveFileDialog.FileName + "/ExportingFiles");
                Directory.CreateDirectory(saveFileDialog.FileName + "/ExportingFiles/" + "StroopProgram");
                Directory.CreateDirectory(saveFileDialog.FileName + "/ExportingFiles/" + "ReactionProgram");
                Directory.CreateDirectory(saveFileDialog.FileName + "/ExportingFiles/" + "ExperimentProgram");
                Directory.CreateDirectory(saveFileDialog.FileName + "/ExportingFiles/" + "Lists");

                // exporting each row according to type: list, reaction program, stroop program or experiment program
                foreach (DataGridViewRow row in exportDataGridView.Rows)
                {
                    if (row.Cells[1].Value.ToString() == LocRM.GetString("lists", currentCulture))
                    {
                        if ((row.Cells[0].Value.ToString().Split('_')[1] == "color") || (row.Cells[0].Value.ToString().Split('_')[1] == "words"))
                        {
                            exportFile(row.Cells[2].Value.ToString(), saveFileDialog.FileName + "/ExportingFiles/" + "StringLists/" + row.Cells[0].Value.ToString() + ".lst");
                        }
                        else
                        {
                            exportListContent(row.Cells[0].Value.ToString(), saveFileDialog.FileName + "/ExportingFiles/" + "FileLists");
                            exportFile(row.Cells[2].Value.ToString(), saveFileDialog.FileName + "/ExportingFiles/" + "FileLists/" + row.Cells[0].Value.ToString() + "/" + row.Cells[0].Value.ToString() + ".lst");
                        }
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("reactionTest", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), saveFileDialog.FileName + "/ExportingFiles/" + "ReactionProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("stroopTest", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), saveFileDialog.FileName + "/ExportingFiles/" + "StroopProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("experiment", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), saveFileDialog.FileName + "/ExportingFiles/" + "ExperimentProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    
                }
                
                ZipFile.CreateFromDirectory(saveFileDialog.FileName + "/ExportingFiles/", saveFileDialog.FileName + ".zip");
                Directory.Delete(saveFileDialog.FileName + "/ExportingFiles/", true);

            }
            else
            {
                MessageBox.Show(LocRM.GetString("exportDirectory", currentCulture));
            }
        }

        private void exportListContent(string listName, string path)
        {
            string listDestination = path + "/" + listName + "/";
            System.IO.Directory.CreateDirectory(listDestination);
            string[] name = listName.Split('_');
            StrList newList;
            if (name[1] == "image")
            {
               newList = new StrList(name[0], 0);
            }
            else
            {
                newList = new StrList(name[0], 1);
            }


            foreach (string content in newList.ListContent)
            {
                string fileName = Path.GetFileName(content);
                if (File.Exists(content))
                {
                    System.IO.File.Copy(Path.GetFullPath(content), listDestination + fileName, true);
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("fileNotFound",currentCulture) + content);
                }
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
            else if (selectedRowType == LocRM.GetString("experiment", currentCulture))
            {
               addPrograms(selectedRowName);
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

    }
}
