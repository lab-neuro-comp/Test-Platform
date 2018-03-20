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
using System.Resources;
using System.Globalization;
using TestPlatform.Models;

namespace TestPlatform.Views.MainForms
{
    public partial class FileManagment : UserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private char mode;
        private bool hasConflict = false;

        private string originPath, destinationPath, type;

        public FileManagment(string originPath, string destinationPath, char mode, string type)
        {
            InitializeComponent();
            this.mode = mode;
            this.originPath = originPath;
            this.destinationPath = destinationPath;
            this.type = type;
            if (mode == 'r') //recover mode
            {
                sendButton.Text = LocRM.GetString("recover", currentCulture);
                originListLabel.Text = LocRM.GetString("deletedPrograms", currentCulture);
                destinationListLabel.Text = LocRM.GetString("toRecoverPrograms", currentCulture);
                errorMessage.Text = LocRM.GetString("warningRecover", currentCulture);
            }
            else if (mode == 'd') //delete mode
            {
                sendButton.Text = LocRM.GetString("delete", currentCulture);
                originListLabel.Text = LocRM.GetString("existingPrograms", currentCulture);
                destinationListLabel.Text = LocRM.GetString("toDeletePrograms", currentCulture);
                errorMessage.Text = LocRM.GetString("warningDelete", currentCulture);
            }
            else
            {
                throw new ArgumentException();
            }
            loadOriginList();
        }

        private void originFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush redSolidBrush = new SolidBrush(Color.Red);
            SolidBrush orangeSolidBush = new SolidBrush(Color.Orange);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < originFilesList.Items.Count)
            {
                string text = originFilesList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else if (type != LocRM.GetString("experiment", currentCulture) && mode == 'd' && isProgramUsed(text))
                {
                    backgroundBrush = orangeSolidBush;
                    warningLabel.Visible = true;
                }
                else if (File.Exists(destinationPath + text + ".prg") == true)
                {
                    backgroundBrush = redSolidBrush;
                }
                else
                {
                    backgroundBrush = whiteSolidBrush;
                }

                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, originFilesList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }
        
        private void destinationFilesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush whiteSolidBrush = new SolidBrush(Color.White);
            SolidBrush blackSolidBrush = new SolidBrush(Color.Black);
            SolidBrush blueSolidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
            SolidBrush redSolidBrush = new SolidBrush(Color.Red);
            SolidBrush orangeSolidBush = new SolidBrush(Color.Orange);

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < destinationFilesList.Items.Count)
            {
                string text = destinationFilesList.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                {
                    backgroundBrush = blueSolidBrush;
                }
                else if (File.Exists(destinationPath + text + ".prg") == true)
                {
                    backgroundBrush = redSolidBrush;
                }
                else
                {
                    if (type != LocRM.GetString("experiment", currentCulture) && mode == 'd' && isProgramUsed(text))
                    {
                        backgroundBrush = orangeSolidBush;
                    }
                    else
                    {
                        backgroundBrush = whiteSolidBrush;
                    }
                }
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? whiteSolidBrush : blackSolidBrush;
                g.DrawString(text, e.Font, foregroundBrush, destinationFilesList.GetItemRectangle(index).Location);
            }
            e.DrawFocusRectangle();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Parent.Controls.Remove(this);
        }

        private bool isProgramUsed(string programName)
        {
            string[] experiments = Directory.GetFiles(Global.experimentTestFilesPath + Global.programFolderName);
            foreach (string file in experiments)
            {
                ExperimentProgram experiment = new ExperimentProgram();
                experiment.Name = Path.GetFileNameWithoutExtension(file);
                experiment.ReadProgramFile();
                foreach (Program program in experiment.ProgramList)
                {
                    if (program.ProgramName == programName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void addToDestinationList_Click(object sender, EventArgs e)
        {
            string programName;
            if (originFilesList.SelectedItem != null)
            {
                programName = originFilesList.SelectedItem.ToString();
                if (type == LocRM.GetString("experiment", currentCulture) || !isProgramUsed(programName))
                {
                    originFilesList.Items.Remove(programName);
                    destinationFilesList.Items.Add(programName);
                }
                else
                {
                    /*do nothing*/
                }
            }
            else
            {
                /*do nothing*/
            }
        }

        private void addToOriginList_Click(object sender, EventArgs e)
        {
            string programName;
            if (destinationFilesList.SelectedItem != null)
            {
                programName = destinationFilesList.SelectedItem.ToString();
                destinationFilesList.Items.Remove(programName);
                originFilesList.Items.Add(programName);
            }
            else
            {
                /*do nothing*/
            }
        }

        private void moveFiles()
        {
            string[] programs = new string[destinationFilesList.Items.Count];
            if (destinationFilesList.Items.Count > 0)
            {
                for (int count = 0; count < destinationFilesList.Items.Count; count++)
                {
                    programs[count] = destinationFilesList.Items[count].ToString();
                }
                for (int count = 0; count < programs.Length; count++)
                {
                    try
                    {
                        File.Move(originPath + programs[count] + ".prg", destinationPath + programs[count] + ".prg");
                        destinationFilesList.Items.Remove(programs[count]);
                    }
                    catch (IOException)
                    {
                        File.Delete(destinationPath + programs[count] + ".prg");
                        File.Move(originPath + programs[count] + ".prg", destinationPath + programs[count] + ".prg");
                        destinationFilesList.Items.Remove(programs[count]);
                    }
                }
                if (sendButton.Text == LocRM.GetString("recover", currentCulture))
                {
                    MessageBox.Show(LocRM.GetString("recoveredSucessful", currentCulture));
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("deletedSucessful", currentCulture));
                }
                loadOriginList();
            }
            else
            {
                /* do nothing*/
            }
        }

        private bool filesHasNoDepedency()
        {
            if (mode == 'r' && destinationFilesList.Items.Count > 0)
            {
                for (int count = 0; count < destinationFilesList.Items.Count; count++)
                {
                    if (this.type == LocRM.GetString("experiment"))
                    {
                        ExperimentProgram experiment = new ExperimentProgram();
                        experiment.ExperimentName = Path.GetFileNameWithoutExtension(destinationFilesList.Items[count].ToString());
                        try
                        {
                            experiment.ReadProgramFile(true);
                        }
                        catch(MissingMemberException e)
                        {
                            MessageBox.Show(e.Message + " " + LocRM.GetString("cantBeFoundPleaseRocoverFirst", currentCulture) + destinationFilesList.Items[count].ToString() + ")");
                            return false;
                        }
                        catch (FileNotFoundException e)
                        {
                            MessageBox.Show(LocRM.GetString("cannotRecoverFilesByMotive", currentCulture) + destinationFilesList.Items[count].ToString() + "\":\n" + e.Message);
                            return false;
                        }
                    }
                    else
                    {
                        if (type == LocRM.GetString("stroopTest", currentCulture))
                        {
                            StroopProgram program = new StroopProgram();
                            try
                            {
                                program.readProgramFile(Global.stroopTestFilesBackupPath + destinationFilesList.Items[count].ToString() + ".prg");
                            }
                            catch (FileNotFoundException e)
                            {
                                MessageBox.Show(LocRM.GetString("cannotRecoverFilesByMotive", currentCulture) + destinationFilesList.Items[count].ToString() + "\":\n" + e.Message);
                                return false;
                            }
                        }
                        else if(type == LocRM.GetString("reactionTest",currentCulture))
                        {
                            ReactionProgram program = new ReactionProgram();
                            try
                            {
                                program.readProgramFile(Global.reactionTestFilesBackupPath + destinationFilesList.Items[count].ToString() + ".prg");
                            }
                            catch (FileNotFoundException e)
                            {
                                MessageBox.Show(LocRM.GetString("cannotRecoverFilesByMotive", currentCulture) + destinationFilesList.Items[count].ToString() + "\":\n" + e.Message);
                                return false;
                            }
                        }
                        else if(type == LocRM.GetString("matchingTest", currentCulture))
                        {
                            MatchingProgram program = new MatchingProgram();
                            try
                            {
                                program.readProgramFile(Global.matchingTestFilesBackupPath + destinationFilesList.Items[count].ToString() + ".prg");
                            }
                            catch (FileNotFoundException e)
                            {
                                MessageBox.Show(LocRM.GetString("cannotRecoverFilesByMotive", currentCulture) + destinationFilesList.Items[count].ToString() + "\":\n" + e.Message);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (destinationFilesList.Items.Count > 0 && filesHasNoDepedency())
            {
                DialogResult dialogResult = MessageBox.Show(LocRM.GetString("deleteFiles", currentCulture), LocRM.GetString("delete", currentCulture), MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    moveFiles();
                }
                else
                {
                    MessageBox.Show(LocRM.GetString("FilesNotDeleted", currentCulture));
                }
            }
        }

        private void warningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (warningCheckBox.Checked)
            {
                sendButton.Enabled = true;
            }
            else
            {
                sendButton.Enabled = false;
            }
        }

        private void originFilesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void destinationFilesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("fileManagmentConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void loadOriginList()
        {
            string[] filePaths;
            string programName;
            originFilesList.Items.Clear();
            filePaths = Directory.GetFiles(originPath, ("*.prg"), SearchOption.AllDirectories);
            foreach (string file in filePaths)
            {
                programName = Path.GetFileNameWithoutExtension(file);
                originFilesList.Items.Add(programName);
                if (File.Exists(destinationPath + programName + ".prg"))
                {
                    hasConflict = true;
                }
            }
            if (hasConflict)
            {
                warningCheckBox.Visible = true;
                errorMessage.Visible = true;
                sendButton.Enabled = false;
            }
            else
            {
                errorMessage.Visible = false;
                warningCheckBox.Visible = false;
                sendButton.Enabled = true;
            }
        }
    }
}
