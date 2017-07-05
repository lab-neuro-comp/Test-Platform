using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestPlatform.Views.ExperimentPages
{
    public partial class ExperimentConfig : UserControl
    {
        private string path;
        private static string stroopProgramPath = "StroopTestFiles/prg/";
        private static string reactionProgramPath = "ReactionTestFiles/prg/";

        public ExperimentConfig()
        {
            Location = new Point(500, 38);
            InitializeComponent();
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        private string[] defineTest()
        {
            FormDefineTest defineTest = new FormDefineTest(path, stroopProgramPath, reactionProgramPath);
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
    }
}
