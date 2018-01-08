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

        public ImportUserControl()
        {
            InitializeComponent();
        }

        private void importFiles(string currentDirectory, string targetDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(currentDirectory);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(targetDirectory, file.Name);
                file.CopyTo(temppath, false);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(targetDirectory, subdir.Name);
                importFiles(subdir.FullName, temppath);
            }
        }

        private void addFilesToOriginGrid(string directory, string type)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                originDataGridView.Rows.Add(file.Name, type, directory);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                originDataGridView.Rows.Add(subdir.Name, type, directory);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZIP|*.zip";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Directory.Delete(importDirectory, true);
                ZipFile.ExtractToDirectory(openFileDialog.FileName, importDirectory);
                fileTextBox.Text = openFileDialog.FileName;

                addFilesToOriginGrid(importDirectory + "/StroopProgram/", LocRM.GetString("stroopTest", currentCulture));
                addFilesToOriginGrid(importDirectory + "/ReactionProgram/", LocRM.GetString("reactionTest", currentCulture));
                addFilesToOriginGrid(importDirectory + "/ExperimentProgram/", LocRM.GetString("experiment", currentCulture));
                addFilesToOriginGrid(importDirectory + "/Lists/", LocRM.GetString("lists", currentCulture));
            }
        }
    }
}
