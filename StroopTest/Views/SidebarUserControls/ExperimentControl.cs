using System;
using System.Windows.Forms;
using TestPlatform.Views.ExperimentPages;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ExperimentControl : DefaultUserControl
    {
        public ExperimentControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }
        

        private void newExperimentButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (newExperimentButton.Checked)
                {
                    ExperimentConfig newExperiment = new ExperimentConfig("false");
                    Global.GlobalFormMain._contentPanel.Controls.Add(newExperiment);
                    newExperimentButton.Checked = false;
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
        }

        private void editExperimentButton_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";


                defineProgram = new FormDefine("Editar Programa: ", Global.experimentTestFilesPath + Global.programFolderName, "prg", "program", false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    ExperimentConfig editExperiment = new ExperimentConfig(editProgramName);
                    Global.GlobalFormMain._contentPanel.Controls.Add(editExperiment);
                    editExperimentButton.Checked = false;
                }
                else
                {
                    /*do nothing, user cancelled selection of program*/
                }
        }
    }
}
