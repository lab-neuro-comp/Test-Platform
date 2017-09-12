using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform.Views.ExperimentPages
{
    public partial class ExperimentConfig : UserControl
    {
        ExperimentProgram savingExperiment = new ExperimentProgram();
        string editProgramName;
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
            savingExperiment.readProgramFile();
            beepingCheckbox.Checked = savingExperiment.IsOrderRandom;
            intervalTime.Value = savingExperiment.IntervalTime;
            trainingProgramCheckBox.Checked = savingExperiment.TrainingProgram;

            foreach (Program program in savingExperiment.ProgramList)
            {
                if (program.GetType() == typeof(StroopProgram))
                {
                    programDataGridView.Rows.Add(program.ProgramName, "StroopTest");
                }
                else if (program.GetType() == typeof(ReactionProgram))
                {
                    programDataGridView.Rows.Add(program.ProgramName, "ReactionTest");
                }
            }

            if (savingExperiment.InstructionText != null) // lê instrução se houver
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
            FormDefineTest defineTest = new FormDefineTest();
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void addProgramButton_Click(object sender, EventArgs e)
        {
            string[] result = defineTest();
            if(result != null)
            {
                programDataGridView.Rows.Add(result[1], result[0]);
                if(result[0] == "StroopTest")
                {
                    savingExperiment.addStroopProgram(result[1]);
                }
                else if (result[0] == "ReactionTest")
                {
                    savingExperiment.addReactionProgram(result[1]);
                }

                else
                {
                    /*do nothin*/
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {

                savingExperiment.Name = experimentNameTextBox.Text;
                savingExperiment.IsOrderRandom = beepingCheckbox.Checked;
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
                if (trainingProgramCheckBox.Checked)
                {
                    savingExperiment.TrainingProgram = true;
                }
                else
                {
                    savingExperiment.TrainingProgram = false;
                }
                if (savingExperiment.saveExperimentFile(Global.experimentTestFilesPath + Global.programFolderName))
                {
                    MessageBox.Show("O programa foi salvo com sucesso");
                    this.Parent.Controls.Remove(this);
                }
            }
            else
            {
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");
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
                errorMessage = "O nome do programa deve ser preenchido.";
                return false;
            }
            if (!Validations.isAlphanumeric(pgrName))
            {
                errorMessage = "Nome do programa deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'MeuPrograma'";
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
                errorMessage = "A lista está \n vazia!";
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
    }
}
