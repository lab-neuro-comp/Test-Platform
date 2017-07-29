using System;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform.Views.ExperimentPages
{
    public partial class ExperimentConfig : UserControl
    {

        public ExperimentConfig()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
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

        private void addProgramButton_Click(object sender, System.EventArgs e)
        {
            string[] result = defineTest();
            if(result != null)
            {
                programDataGridView.Rows.Add(result[1], result[0]);
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
            Experiment savingExperiment = new Experiment();
            savingExperiment.Name = experimentNameTextBox.Text;
            savingExperiment.IsOrderRandom = beepingCheckbox.Checked;
            savingExperiment.IntervalTime = Convert.ToInt32(intervalTime.Value);

            if (instructionsBox.Lines.Length > 0) // lê instrução se houver
            {
                for (int i = 0; i < instructionsBox.Lines.Length; i++)
                {
                    savingExperiment.InstructionText.Add(instructionsBox.Lines[i]);
                }
            }
            else
            {
                savingExperiment.InstructionText = null;
            }
        }
    }
}
