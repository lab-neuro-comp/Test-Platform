using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;
using TestPlatform.Controllers;
using TestPlatform.Models;
using System.IO.Compression;
using System.IO;

namespace TestPlatform.Views.MainForms
{
    public partial class ExportUserControl : UserControl
    {
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
                    AddType("Lista", Global.testFilesPath + Global.listFolderName, "lst", "image, audio, words, color", true);
                    break;
                case 1:
                    string programName = AddType("Stroop", Global.stroopTestFilesPath + Global.programFolderName, "prg", "program", false);
                    if (!string.IsNullOrEmpty(programName))
                    {
                        StroopProgram newProgram = new StroopProgram();
                        newProgram.readProgramFile(Global.stroopTestFilesPath + Global.programFolderName + programName + ".prg");
                        addLists(newProgram, Global.testFilesPath + Global.listFolderName);
                    }
                    
                    break;
                case 2:
                    string reactionProgramName = AddType("Tempo de Reação", Global.reactionTestFilesPath + Global.programFolderName, "prg", "program", false);
                    if (!string.IsNullOrEmpty(reactionProgramName))
                    {
                        ReactionProgram newReaction = new ReactionProgram(Global.reactionTestFilesPath + Global.programFolderName + reactionProgramName + ".prg");
                        addLists(newReaction, Global.testFilesPath + Global.listFolderName);
                    }
                    break;
                case 3:
                    string experimentName = AddType("Experimento", Global.experimentTestFilesPath + Global.programFolderName, "prg", "program", false);
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
                    if (!isAlreadyThere(program.ProgramName, "Stroop"))
                    {
                        exportDataGridView.Rows.Add(program.ProgramName, "Stroop", Global.stroopTestFilesPath + Global.programFolderName + program.ProgramName + ".prg");
                        addLists(program, Global.testFilesPath + Global.listFolderName);
                    }
                }
                else if(program.GetType() == typeof(ReactionProgram))
                {
                    if (!isAlreadyThere(program.ProgramName, "Tempo de Reação"))
                    {
                        exportDataGridView.Rows.Add(program.ProgramName, "Tempo de Reação", Global.reactionTestFilesPath + Global.programFolderName + program.ProgramName + ".prg");
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

                if (!isAlreadyThere(fileName, "Lista"))
                {
                    exportDataGridView.Rows.Add(fileName, "Lista", path + fileName + ".lst");
                }
            }
            if (newProgram.getColorListFile() != null)
            {
                string fileName = newProgram.getColorListFile().ListName + "_color";
                if (!isAlreadyThere(fileName, "Lista"))
                {                    
                    exportDataGridView.Rows.Add(fileName, "Lista", path + fileName + ".lst");
                }
            }
            if (newProgram.getImageListFile() != null)
            {
                string fileName = newProgram.getImageListFile().ListName + "_image";
                if (!isAlreadyThere(fileName, "Lista"))
                {
                    exportDataGridView.Rows.Add(fileName, "Lista", path + fileName + ".lst");
                }
            }
            if (newProgram.getWordListFile() != null)
            {
                string fileName = newProgram.getWordListFile().ListName + "_words";
                if (!isAlreadyThere(fileName, "Lista"))
                {
                    exportDataGridView.Rows.Add(fileName, "Lista", path + fileName + ".lst");
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

                foreach (DataGridViewRow row in exportDataGridView.Rows)
                {
                    switch (row.Cells[1].Value.ToString())
                    {
                        case "Lista":
                            if ((row.Cells[0].Value.ToString().Split('_')[1] == "color") || (row.Cells[0].Value.ToString().Split('_')[1] == "words"))
                            {
                                exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "StringLists/" + row.Cells[0].Value.ToString() + ".lst");
                            }
                            else
                            {
                                exportListContent(row.Cells[0].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "FileLists");
                            }
                            break;
                        case "Tempo de Reação":
                            exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "ReactionProgram/" + row.Cells[0].Value.ToString() + ".prg");
                            break;
                        case "Stroop":
                            exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "StroopProgram/" + row.Cells[0].Value.ToString() + ".prg");
                            break;
                        case "Experimento":
                            exportFile(row.Cells[2].Value.ToString(), folderDialog.FileName + "/ExportingFiles/" + "ExperimentProgram/" + row.Cells[0].Value.ToString() + ".prg");
                            break;
                    }
                }
                
                ZipFile.CreateFromDirectory(folderDialog.FileName + "/ExportingFiles/", folderDialog.FileName + "/exportingFiles.zip");
                Directory.Delete(folderDialog.FileName + "/ExportingFiles/", true);

            }
            else
            {
                MessageBox.Show("Selecione um diretório válido onde ainda não há nenhuma exportação da plataforma");
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
            string[] filePaths = newList.ListContent.ToArray();
            foreach (string content in filePaths)
            {
                string fileName = Path.GetFileName(content);
                if (File.Exists(fileName))
                {
                    System.IO.File.Copy(Path.GetFullPath(content), listDestination + fileName, true);
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o arquivo no caminho: " + fileName);
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
                MessageBox.Show("Selecione um arquivo para remover da lista!");
            }
        }
    }
}
