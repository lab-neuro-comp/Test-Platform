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

        public ExportUserControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            switch (typeComboBox.SelectedIndex)
            {
                case 0:
                    AddType(LocRM.GetString("lists", currentCulture), Global.testFilesPath + Global.listFolderName, "lst", "image, audio, words, color", true);
                    break;
                case 1:
                    string programName = AddType(LocRM.GetString("stroopTest", currentCulture), Global.stroopTestFilesPath + Global.programFolderName, "prg", "program", false);
                    if (!string.IsNullOrEmpty(programName))
                    {
                        StroopProgram newProgram = new StroopProgram();
                        newProgram.readProgramFile(Global.stroopTestFilesPath + Global.programFolderName + programName + ".prg");
                        addLists(newProgram, Global.testFilesPath + Global.listFolderName);
                    }
                    
                    break;
                case 2:
                    string reactionProgramName = AddType(LocRM.GetString("reactionTest", currentCulture), Global.reactionTestFilesPath + Global.programFolderName, "prg", "program", false);
                    if (!string.IsNullOrEmpty(reactionProgramName))
                    {
                        ReactionProgram newReaction = new ReactionProgram(Global.reactionTestFilesPath + Global.programFolderName + reactionProgramName + ".prg");
                        addLists(newReaction, Global.testFilesPath + Global.listFolderName);
                    }
                    break;
                case 3:
                    string experimentName = AddType(LocRM.GetString("experiment", currentCulture), Global.experimentTestFilesPath + Global.programFolderName, "prg", "program", false);
                    if (!string.IsNullOrEmpty(experimentName))
                    {
                        addPrograms(experimentName);
                    }
                    break;
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
                        addLists(program, Global.testFilesPath + Global.listFolderName);
                    }
                }
                else if(program.GetType() == typeof(ReactionProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, LocRM.GetString("reactionTest", currentCulture)))
                    {
                        exportDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("reactionTest", currentCulture), Global.reactionTestFilesPath + Global.programFolderName + program.ProgramName + ".prg");
                        addLists(program, Global.testFilesPath + Global.listFolderName);
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
        private void addLists(Program newProgram, string path)
        {
            if (newProgram.getAudioListFile() != null)
            {
                string fileName = newProgram.getAudioListFile().ListName + "_audio";

                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                }
            }
            if (newProgram.getColorListFile() != null)
            {
                string fileName = newProgram.getColorListFile().ListName + "_color";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {                    
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                }
            }
            if (newProgram.getImageListFile() != null)
            {
                string fileName = newProgram.getImageListFile().ListName + "_image";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                }
            }
            if (newProgram.getWordListFile() != null)
            {
                string fileName = newProgram.getWordListFile().ListName + "_words";
                if (!isAlreadyThere(fileName, LocRM.GetString("lists", currentCulture)))
                {
                    exportDataGridView.Rows.Add(fileName, LocRM.GetString("lists", currentCulture), path + fileName + ".lst");
                }
            }
            exportDataGridView.Refresh();
        }

        private string AddType(string type, string path,string file, string typeName, bool sufix)
        {
            FormDefine defineProgram = new FormDefine(type, path, file, typeName, sufix);
            DialogResult result = defineProgram.ShowDialog();
            if (result == DialogResult.OK)
            {
                string name = defineProgram.ReturnValue;
                if (!isAlreadyThere(name, type))
                {
                    exportDataGridView.Rows.Add(name, type, path + name + "." + file);
                    exportDataGridView.Refresh();
                }
                return name;
            }
            return null;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            folderDialog.InitialDirectory = "C:\\";
            folderDialog.IsFolderPicker = true;

            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(folderDialog.FileName) && !File.Exists(folderDialog.FileName + "/exportingFiles.zip"))
            {
                System.IO.Directory.CreateDirectory(folderDialog.FileName + "/ExportingFiles");
                System.IO.Directory.CreateDirectory(folderDialog.FileName + "/ExportingFiles/" + "StroopProgram");
                System.IO.Directory.CreateDirectory(folderDialog.FileName + "/ExportingFiles/" + "ReactionProgram");
                System.IO.Directory.CreateDirectory(folderDialog.FileName + "/ExportingFiles/" + "ExperimentProgram");
                System.IO.Directory.CreateDirectory(folderDialog.FileName + "/ExportingFiles/" + "StringLists");
                System.IO.Directory.CreateDirectory(folderDialog.FileName + "/ExportingFiles/" + "FileLists");

                // exporting each row according to type: list, reaction program, stroop program or experiment program
                foreach (DataGridViewRow row in exportDataGridView.Rows)
                {
                    if (row.Cells[1].Value.ToString() == LocRM.GetString("lists", currentCulture))
                    {
                        if ((row.Cells[0].Value.ToString().Split('_')[1] == "color") || (row.Cells[0].Value.ToString().Split('_')[1] == "words"))
                        {
                            exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "StringLists/" + row.Cells[0].Value.ToString() + ".lst");
                        }
                        else
                        {
                            exportListContent(row.Cells[0].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "FileLists");
                            exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "FileLists/" + row.Cells[0].Value.ToString() + "/" + row.Cells[0].Value.ToString() + ".lst");
                        }
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("reactionTest", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "ReactionProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("stroopTest", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "StroopProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    else if (row.Cells[1].Value.ToString() == LocRM.GetString("experiment", currentCulture))
                    {
                        exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "ExperimentProgram/" + row.Cells[0].Value.ToString() + ".prg");
                    }
                    
                }
                
                ZipFile.CreateFromDirectory(folderDialog.FileName + "/ExportingFiles/", folderDialog.FileName + "/exportingFiles.zip");
                Directory.Delete(folderDialog.FileName + "/ExportingFiles/", true);

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

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            if (exportDataGridView.RowCount > 0 && exportDataGridView.SelectedRows[0] != null)
            {
                DGVManipulation.DeleteDGVRow(exportDataGridView);
            }
            else
            {
                MessageBox.Show(LocRM.GetString("removeItem", currentCulture));
            }
        }
    }
}
