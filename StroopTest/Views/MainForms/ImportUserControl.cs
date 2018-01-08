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
        private string reactioPath = Global.reactionTestFilesPath + Global.programFolderName;
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
            File.Copy(sourcePath, destinationPath);
        }

        private void addFilesToOriginGrid(string directory, string type)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                originDataGridView.Rows.Add(Path.GetFileNameWithoutExtension(file.Name), type, directory);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                originDataGridView.Rows.Add(subdir.Name, type, directory);
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
                file.CopyTo(temppath, false);
            }
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

                addFilesToOriginGrid(importDirectory + "/StroopProgram/", LocRM.GetString("stroopTest", currentCulture));
                addFilesToOriginGrid(importDirectory + "/ReactionProgram/", LocRM.GetString("reactionTest", currentCulture));
                addFilesToOriginGrid(importDirectory + "/ExperimentProgram/", LocRM.GetString("experiment", currentCulture));
                addFilesToOriginGrid(importDirectory + "/Lists/", LocRM.GetString("lists", currentCulture));
            }
        }

        private void importAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (importAllCheckbox.Checked)
            {
                for (int i = 0; i < originDataGridView.Rows.Count; i++)
                {
                    importDataGridView.Rows.Add();
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
                    importFile(row.Cells[2].Value.ToString(), row.Cells[0].Value.ToString() + ".prg", reactioPath);
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
        
    }
}
