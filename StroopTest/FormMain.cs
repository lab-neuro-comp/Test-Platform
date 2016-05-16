using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormMain : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;
        private string dataFolderPath;
        private string prgFolderName = "/prg/";
        private string lstFolderName = "/lst/";
        private string resultsFolderName = "/data/";
        public string defaultPath = (Path.GetDirectoryName(Application.ExecutablePath) + "/StroopTestFiles/");
        private StroopProgram programDefault = new StroopProgram(); // programa padrão
        private string defaultPrgName = "padrao";
        private string defaultUsrName = "padrao";
        private string instructionsFileName = "editableInstructions.txt";

        public FormMain()
        {
            InitializeComponent();
            dataFolderPath = defaultPath;

            if(!Directory.Exists(dataFolderPath)) Directory.CreateDirectory(dataFolderPath); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(dataFolderPath + prgFolderName)) Directory.CreateDirectory(dataFolderPath + prgFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(dataFolderPath + lstFolderName)) Directory.CreateDirectory(dataFolderPath + lstFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(dataFolderPath + resultsFolderName)) Directory.CreateDirectory(dataFolderPath + resultsFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if(!File.Exists(dataFolderPath + instructionsFileName)) { File.Create(dataFolderPath + "editableInstructions.txt").Dispose(); }
            
            initializeDefaultProgram(); // inicializa programa padrão (cria arquivo programa padrão e listas de palavras e cores padrão)

            prgNameSL.Text = defaultPrgName;
            usrNameSL.Text = defaultUsrName;

            dirPathSL.Text = dataFolderPath;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                beginTest();
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                defineProgram();
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                defineUser();
            }
            if (e.Control && e.KeyCode == Keys.N)
            {
                newProgram();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            beginTest();
        }
        
        private void programaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrgConfig configureProgram = new FormPrgConfig(dataFolderPath, "false");
            try { configureProgram.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void textoECoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLstConfig configureWordsList = new FormLstConfig(dataFolderPath, "false");
            try { configureWordsList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutWindow = new AboutBox1();
            try { aboutWindow.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(dataFolderPath + instructionsFileName);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void programaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            defineProgram();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defineUser();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            defineProgram();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            defineUser();
        }

        private void dirPathSL_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dirPathSL.Text = folderBrowserDialog1.SelectedPath;
            }
            dataFolderPath = dirPathSL.Text;
        }

        private void imagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLstImgConfig configureImagesList = new FormLstImgConfig(dataFolderPath);
            try { configureImagesList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void initializeDefaultProgram() // inicializa programDefault padrão
        {
            programDefault.UserName = defaultPrgName;
            programDefault.ProgramName = defaultUsrName;
            try
            {
                programDefault.writeDefaultProgramFile(dataFolderPath + prgFolderName + programDefault.ProgramName + ".prg"); // ao inicializar formulario escreve arquivo programa padrao
                programDefault.writeDefaultWordsList(dataFolderPath + lstFolderName); // escreve lista de palavras padrão
                programDefault.writeDefaultColorsList(dataFolderPath + lstFolderName); // escreve lista de cores padrão 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void programaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPrgConfig configureProgram;
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";

            try
            {
                defineProgram = new FormDefine("Editar Programa: ", dataFolderPath + "/prg/", "prg");
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    configureProgram = new FormPrgConfig(dataFolderPath, editProgramName);
                    configureProgram.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void textoECoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormLstConfig configureWordsList;
            FormDefine defineProgram;
            DialogResult result;
            string editListName = "error";
            try
            {
                defineProgram = new FormDefine("Editar Lista: ", dataFolderPath, "lst");
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editListName = defineProgram.ReturnValue;
                    configureWordsList = new FormLstConfig(dataFolderPath, editListName);
                    configureWordsList.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void programaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                FormDefine defineUser = new FormDefine("Excluir Programa: ", dataFolderPath + "/prg/", "prg");
                var result = defineUser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string excludeFilePath = dataFolderPath + "/prg/" + defineUser.ReturnValue + ".prg";
                    DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o programa " + defineUser.ReturnValue + ".prg?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa

                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Delete(excludeFilePath);
                        MessageBox.Show(defineUser.ReturnValue + ".prg excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void listaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FormDefine defineUser = new FormDefine("Excluir Lista: ", dataFolderPath + "/lst/", "lst");
                var result = defineUser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string excludeFilePath = dataFolderPath + "/lst/" + defineUser.ReturnValue + ".lst";
                    DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir a lista " + defineUser.ReturnValue + ".lst?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa

                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Delete(excludeFilePath);
                        MessageBox.Show(defineUser.ReturnValue + ".lst excluída com sucesso!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void iniciarTesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginTest();
        }

        private void beginTest()
        {
            Screen[] screens;
            FormExposition exposeProgram = new FormExposition(prgNameSL.Text, usrNameSL.Text, dataFolderPath);

            try
            {
                screens = Screen.AllScreens;

                if (screens.Length == 2)
                {
                    //MessageBox.Show(screens[1].Bounds.Width.ToString() + " / " + screens[1].Bounds.Height + "\n" + screens[0].Bounds.Width.ToString() + " / " + screens[0].Bounds.Height);
                    Rectangle r1 = screens[0].WorkingArea;
                    exposeProgram.StartPosition = FormStartPosition.Manual;
                    exposeProgram.Top = r1.Top;
                    exposeProgram.Left = r1.Left;
                    SendKeys.SendWait("i");
                    exposeProgram.Show();
                }
                else
                {
                    SendKeys.SendWait("i");
                    exposeProgram.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void defineProgram()
        {
            FormDefine defineProgram = new FormDefine("Definir Programa: ", dataFolderPath + "/prg/", "prg");
            try
            {
                var result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string progName = defineProgram.ReturnValue;
                    prgNameSL.Text = progName;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void defineUser()
        {
            try
            {
                FormDefine defineUser = new FormDefine("Definir Usuário: ", dataFolderPath, "usr");
                var result = defineUser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string userName = defineUser.ReturnValue;
                    usrNameSL.Text = userName;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void newProgram()
        {
            FormPrgConfig configureProgram = new FormPrgConfig(dataFolderPath, "false");
            try { configureProgram.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData showData;
            
            try
            {
                showData = new FormShowData(dataFolderPath + "/data/");
                showData.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormDefine defineUser = new FormDefine("Excluir Arquivo de Dados: ", dataFolderPath + "/data/", "txt");
                var result = defineUser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string excludeFilePath = dataFolderPath + "/data/" + defineUser.ReturnValue + ".txt";
                    DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o arquivo de dados " + defineUser.ReturnValue + ".txt?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa

                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Delete(excludeFilePath);
                        MessageBox.Show(defineUser.ReturnValue + ".txt excluído com sucesso!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
