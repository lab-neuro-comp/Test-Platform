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

            foreach (Program program in savingExperiment.ProgramList)
            {
                if (program.GetType() == typeof(StroopProgram))
                {
                    programDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("stroopTest", currentCulture));
                }
                else if (program.GetType() == typeof(ReactionProgram))
                {
                    programDataGridView.Rows.Add(program.ProgramName, LocRM.GetString("reactionTest", currentCulture));
                }
            }

            if (savingExperiment.TrainingProgram)
            {
                programDataGridView.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
                programDataGridView.Rows[0].Cells[1].Style.BackColor = Color.LightGray;
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
                programDataGridView.Rows.Add(result[1], result[0]);
                if (result[0] == "StroopTest")
                {
                    savingExperiment.AddStroopProgram(result[1]);
                }
                else if (result[0] == "ReactionTest")
                {
                    savingExperiment.AddReactionProgram(result[1]);
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
                if (programDataGridView.Rows[0].Cells[0].Style.BackColor == Color.LightGray)
                {
                    savingExperiment.TrainingProgram = true;
                }
                else
                {
                    savingExperiment.TrainingProgram = false;
                }
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
                if (programDataGridView.SelectedRows[0].Index == 0 && programDataGridView.Rows[0].Cells[0].Style.BackColor != Color.LightGray)
                {
                    changingBackColorFirstRow(Color.LightGray);
                    changingFontStyleFirstRow(FontStyle.Bold);
                }
                else if (programDataGridView.SelectedRows[0].Index == 0 && programDataGridView.Rows[0].Cells[0].Style.BackColor == Color.LightGray)
                {
                    changingBackColorFirstRow(Color.White);
                    changingFontStyleFirstRow(FontStyle.Regular);
                }
                else if (programDataGridView.SelectedRows[0].Index != 0)
                {
                    if (programDataGridView.Rows[0].Cells[0].Style.BackColor == Color.LightGray)
                    {
                        changingBackColorFirstRow(Color.White);
                        changingFontStyleFirstRow(FontStyle.Regular);
                    }
                    // swapping first row and selected row
                    swappingRows();

                    // marking first row as training
                    changingBackColorFirstRow(Color.LightGray);
                    changingFontStyleFirstRow(FontStyle.Bold);
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
            programDataGridView.Rows.Remove(currentFirsRow);
            programDataGridView.Rows.Remove(selectedRow);
            programDataGridView.Rows.Insert(0, selectedRow);
            programDataGridView.Rows.Insert(index, currentFirsRow);
        }

        private void changingBackColorFirstRow(Color color)
        {
            programDataGridView.Rows[0].Cells[0].Style.BackColor = color;
            programDataGridView.Rows[0].Cells[1].Style.BackColor = color;
        }

        private void changingFontStyleFirstRow(FontStyle style)
        {
            programDataGridView.Rows[0].Cells[0].Style.Font = new Font(programDataGridView.Font, style);
            programDataGridView.Rows[0].Cells[1].Style.Font = new Font(programDataGridView.Font, style);
        }

        private void randomOrderCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomOrderCheckbox.Checked)
            {
                trainingButton.Enabled = true;
            }
            else
            {
                if (programDataGridView.RowCount != 0 &&  programDataGridView.Rows[0].Cells[0].Style.BackColor == Color.LightGray)
                {
                    changingBackColorFirstRow(Color.White);
                    changingFontStyleFirstRow(FontStyle.Regular);
                }
                trainingButton.Enabled = false;

            }
        }
    }
}
