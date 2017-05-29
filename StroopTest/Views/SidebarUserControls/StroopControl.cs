using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestPlatform.Views
{
    public partial class StroopControl : DefaultUserControl
    {
        string testFilesPath;
        public StroopControl()
        {
            InitializeComponent();
        }

        public string TestFilesPath
        {
            set
            {
                testFilesPath = value;
            }
        }

              


        private void newStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newStroopButton.Checked)
            {
                FormPrgConfig configureProgram = new FormPrgConfig();
                configureProgram.Path = testFilesPath;
                Parent.Controls.Add(configureProgram);
                newStroopButton.Checked = false;
            }
        }

        private void editStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (editStroopButton.Checked)
            {
                try
                {
                    string editProgramName = "error";
                    FormDefine defineProgram = new FormDefine("Editar Programa: ", testFilesPath + "StroopTestFiles/prg/", "prg", "program", false);
                    DialogResult result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        editProgramName = defineProgram.ReturnValue;
                        FormPrgConfig configureProgram = new FormPrgConfig();
                        configureProgram.Path = testFilesPath;
                        configureProgram.PrgName = editProgramName;
                        Parent.Controls.Add(configureProgram);
                        editStroopButton.Checked = false;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
