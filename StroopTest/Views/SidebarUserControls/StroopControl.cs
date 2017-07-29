using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestPlatform.Views
{
    public partial class StroopControl : DefaultUserControl
    {
        public StroopControl()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }     

        private void newStroopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newStroopButton.Checked)
            {
                FormPrgConfig configureProgram = new FormPrgConfig("false");
                Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
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
                    FormDefine defineProgram = new FormDefine("Editar Programa: ", Global.stroopTestFilesPath + Global.programFolderName, "prg", "program", false);
                    DialogResult result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        editProgramName = defineProgram.ReturnValue;
                        FormPrgConfig configureProgram = new FormPrgConfig(editProgramName);
                        Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                        editStroopButton.Checked = false;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
