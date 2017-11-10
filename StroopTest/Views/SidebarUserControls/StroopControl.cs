using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace TestPlatform.Views
{
    public partial class StroopControl : DefaultUserControl
    {
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

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
                    FormDefine defineProgram = new FormDefine(LocRM.GetString("editProgram", currentCulture), Global.stroopTestFilesPath + Global.programFolderName, "prg", "program", false);
                    DialogResult result = defineProgram.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        editProgramName = defineProgram.ReturnValue;
                        FormPrgConfig configureProgram = new FormPrgConfig(editProgramName);
                        Global.GlobalFormMain._contentPanel.Controls.Add(configureProgram);
                        editStroopButton.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
