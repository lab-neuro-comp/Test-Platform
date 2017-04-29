
using StroopTest;
using StroopTest.Views;
using System;
using System.Windows.Forms;

namespace TestPlatform.Views.SidebarUserControls
{
    public partial class ReactionControl : DefaultUserControl
    {
        string testFilesPath;
        public ReactionControl()
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

        private void newReactButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (newReactButton.Checked)
                {
                    FormTRConfig configureProgram = new FormTRConfig("false");
                    configureProgram.Path = testFilesPath;
                    Parent.Controls.Add(configureProgram);
                    newReactButton.Checked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void editReactButton_Click(object sender, EventArgs e)
        {

            FormDefine defineProgram;
            DialogResult result;

            try
            {
                defineProgram = new FormDefine("Editar Programa: ", testFilesPath + "ReactionTestFiles/prg/", "prg", 
                                                "program", false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FormTRConfig configureProgram = new FormTRConfig(defineProgram.ReturnValue);
                    configureProgram.Path = testFilesPath;
                    this.Controls.Add(configureProgram);
                    editReactButton.Checked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
