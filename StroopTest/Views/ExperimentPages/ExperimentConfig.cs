using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform.Views.ExperimentPages
{
    public partial class ExperimentConfig : UserControl
    {
        ExperimentProgram savingExperiment = new ExperimentProgram();
        string editProgramName;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public ExperimentConfig(string programName)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            labelEmpty.Visible = false;
            if (programName != "false")
            {
                editProgramName = programName;
                programEdition();
            }
        }

        private void programEdition()
        {
            savingExperiment.Name = editProgramName;
            experimentNameTextBox.Text = editProgramName;
            savingExperiment.ReadProgramFile();
            randomOrderCheckbox.Checked = savingExperiment.IsOrderRandom;
            intervalTime.Value = savingExperiment.IntervalTime;

            if (!savingExperiment.IsOrderRandom)
            {
                foreach (Program program in savingExperiment.ProgramList)
                {
                    int row = programDataGridView.Rows.Add();
                    if (program.GetType() == typeof(StroopProgram))
                    {
                        programDataGridView.Rows[row].SetValues(row + 1, program.ProgramName, LocRM.GetString("stroopTest", currentCulture));
                    }
                    else if (program.GetType() == typeof(ReactionProgram))
                    {
                        programDataGridView.Rows[row].SetValues(row + 1, program.ProgramName, LocRM.GetString("reactionTest", currentCulture));
                    }
                    else if (program.GetType() == typeof(MatchingProgram))
                    {
                        programDataGridView.Rows[row].SetValues(row + 1, program.ProgramName, LocRM.GetString("matchingTest", currentCulture));
                    }
                }
            }
            else
            {
                foreach (Program program in savingExperiment.ProgramList)
                {
                    int row = programDataGridView.Rows.Add();
                    if (program.GetType() == typeof(StroopProgram))
                    {
                        programDataGridView.Rows[row].SetValues(LocRM.GetString("random",currentCulture), program.ProgramName, LocRM.GetString("stroopTest", currentCulture));
                    }
                    else if (program.GetType() == typeof(ReactionProgram))
                    {
                        programDataGridView.Rows[row].SetValues(LocRM.GetString("random", currentCulture), program.ProgramName, LocRM.GetString("reactionTest", currentCulture));
                    }
                    else if (program.GetType() == typeof(MatchingProgram))
                    {
                        programDataGridView.Rows[row].SetValues(LocRM.GetString("random", currentCulture), program.ProgramName, LocRM.GetString("matchingTest", currentCulture));
                    }
                }
                if (savingExperiment.TrainingProgram)
                {
                    programDataGridView.Rows[0].Cells[0].Value = LocRM.GetString("training", currentCulture);
                }
            }
           

            // read instructions if there are any
            if (savingExperiment.InstructionText != null) 
            {
                instructionsBox.ForeColor = Color.Black;
                instructionsBox.Text = savingExperiment.InstructionText[0];
                for (int i = 1; i < savingExperiment.InstructionText.Count; i++)
                {
                    instructionsBox.AppendText(Environment.NewLine + savingExperiment.InstructionText[i]);
                }
            }
        }

        private string[] defineTest()
        {
            FormDefineTest defineTest = new FormDefineTest(CultureInfo.CurrentUICulture);
            try
            {
                var result = defineTest.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return defineTest.returnValues;
                }
                else
                {
                    /*do nothing*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void addProgramButton_Click(object sender, EventArgs e)
        {
            string[] result = defineTest();
            if (result != null)
            {
                if (!randomOrderCheckbox.Checked)
                {
                    int row = programDataGridView.Rows.Add(0, result[1], result[0]);
                    programDataGridView.Rows[row].SetValues(row + 1, result[1], result[0]);
                }
                else
                {
                    programDataGridView.Rows.Add(LocRM.GetString("random", currentCulture), result[1], result[0]);
                }

                if (result[0] == LocRM.GetString("stroopTest", currentCulture))
                {
                    savingExperiment.AddStroopProgram(result[1]);
                }
                else if (result[0] == LocRM.GetString("reactionTest", currentCulture))
                {
                    savingExperiment.AddReactionProgram(result[1]);
                }
                else if (result[0] == LocRM.GetString("matchingTest", currentCulture))
                {
                    savingExperiment.AddMatchingProgram(result[1]);
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (programDataGridView.RowCount > 0)
                {
                    int programIndex = programDataGridView.SelectedRows[0].Index;
                    savingExperiment.ProgramList.RemoveAt(programIndex);
                    programDataGridView.Rows.RemoveAt(this.programDataGridView.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool save()
        {
            saveButton_Click(this, null);
            foreach (Control c in this.errorProvider1.ContainerControl.Controls)
            {
                if (errorProvider1.GetError(c) != "")
                {
                    return false;
                }
            }
            return true;
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                savingExperiment.Name = experimentNameTextBox.Text;
                savingExperiment.IsOrderRandom = randomOrderCheckbox.Checked;
                savingExperiment.IntervalTime = Convert.ToInt32(intervalTime.Value);

                if (instructionsBox.Lines.Length > 0) // lê instrução se houver
                {
                    savingExperiment.InstructionText = new List<string>();
                    for (int i = 0; i < instructionsBox.Lines.Length; i++)
                    {
                        savingExperiment.InstructionText.Add(instructionsBox.Lines[i]);
                    }
                }
                else
                {
                    savingExperiment.InstructionText = null;
                }

                // checking if there is a training program
                if (programDataGridView.Rows[0].Cells[0].Value.ToString() == LocRM.GetString("training", currentCulture))
                {
                    savingExperiment.TrainingProgram = true;
                }
                else
                {
                    savingExperiment.TrainingProgram = false;
                }

                //saving experiment
                if (savingExperiment.SaveExperimentFile(Global.experimentTestFilesPath + Global.programFolderName))
                {
                    MessageBox.Show(LocRM.GetString("programSaved", currentCulture));
                    this.Parent.Controls.Remove(this);
                }
            }
            else
            {
                MessageBox.Show(LocRM.GetString("fieldNotRight", currentCulture));
            }

        }


        private void prgNameTextBox_Validating(object sender,
         System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidProgramName(experimentNameTextBox.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProvider1.SetError(experimentNameTextBox, errorMsg);
            }
        }

        private void experimentNameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(experimentNameTextBox, "");
        }

        public bool ValidProgramName(string pgrName, out string errorMessage)
        {
            if (pgrName.Length == 0)
            {
                errorMessage = LocRM.GetString("programNotFilled", currentCulture);
                return false;
            }
            if (!Validations.isAlphanumeric(pgrName))
            {
                errorMessage = LocRM.GetString("programNotAlphanumeric", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }


        private void listLength_Validated(object sender, System.EventArgs e)
        {
            labelEmpty.Visible = false;
        }

        public bool ValidListLength(int number, out string errorMessage)
        {
            if (number == 0)
            {
                errorMessage = LocRM.GetString("emptyList", currentCulture);
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void listLength_Validating(object sender,
                             System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidListLength(programDataGridView.RowCount, out errorMsg))
            {
                e.Cancel = true;
                labelEmpty.Text = errorMsg;
                labelEmpty.Visible = true;
            }
        }

        private void trainingButton_Click(object sender, EventArgs e)
        {
            if (programDataGridView.RowCount > 0 && programDataGridView.SelectedRows[0] != null)
            {
                if (programDataGridView.SelectedRows[0].Index == 0)
                {
                    programDataGridView.Rows[0].Cells[0].Value = LocRM.GetString("training", currentCulture);
                }
                else if (programDataGridView.SelectedRows[0].Index != 0)
                {
                    programDataGridView.Rows[0].Cells[0].Value = LocRM.GetString("random", currentCulture);
                    
                    // swapping first row and selected row
                    swappingRows();

                    // marking first row as training
                    programDataGridView.Rows[0].Cells[0].Value = LocRM.GetString("training", currentCulture);
                }
            }
            else
            {
                MessageBox.Show(LocRM.GetString("selectTraining", currentCulture));
            }
        }


        /// <summary>
        /// swapping first row of programDatagridView with current selected row by user
        /// </summary>
        private void swappingRows()
        {
            var selectedRow = programDataGridView.SelectedRows[0];
            int index = programDataGridView.SelectedRows[0].Index;
            var currentFirsRow = programDataGridView.Rows[0];
            
            // swapping content on data grid  view
            programDataGridView.Rows.Remove(currentFirsRow);
            programDataGridView.Rows.Remove(selectedRow);
            programDataGridView.Rows.Insert(0, selectedRow);
            programDataGridView.Rows.Insert(index, currentFirsRow);

            // swapping content on experiment file that will be saved
            Program swapTemporaryProgram = savingExperiment.ProgramList[index];
            savingExperiment.ProgramList[index] = savingExperiment.ProgramList[0];
            savingExperiment.ProgramList[0] = swapTemporaryProgram;
        }

        private void randomOrderCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomOrderCheckbox.Checked)
            {
                trainingButton.Enabled = true;
                foreach (DataGridViewRow row in programDataGridView.Rows)
                {
                    row.Cells[0].Value = LocRM.GetString("random", currentCulture);
                }
            }
            else
            {

                for (int i = 0; i < programDataGridView.Rows.Count; i++)
                {
                    programDataGridView.Rows[i].Cells[0].Value = i+1;
                    
                }
                trainingButton.Enabled = false;

            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("experimentConfigInstructions", currentCulture));
            try { infoBox.Show(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
