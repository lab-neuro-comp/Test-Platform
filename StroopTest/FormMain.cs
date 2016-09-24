/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StroopTest
{
    public partial class FormMain : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;
        private string testFilesPath;
        private string prgFolderName = "/prg/";
        private string lstFolderName = "/lst/";
        private string resultsFolderName = "/data/";
        public string defaultPath = (Path.GetDirectoryName(Application.ExecutablePath));
        private StroopProgram programDefault = new StroopProgram(); // programa padrão
        private string defaultPrgName = "padrao";
        private string defaultUsrName = "padrao";
        private string instructionsFileName = "editableInstructions.txt";
        private string prgConfigHelpFileName = "prgConfigHelp.txt";
        private string instructionsText = "Execute um teste com o atalho 'Ctrl + R'\nDefina o programa do teste com o atalho 'Ctrl + D'\nPara utilizar o software, execute-o uma primeira vez.\nA partir da primeira execução será criado o diretório\n'StroopTestFiles'\nno mesmo diretório em que o programa executa.\nTal diretório contém os subdiretórios:\n'data' - com os resultados das execuções;\n'prg' - contém os arquivos .prg onde estão escitos os programas;\n'lst' - contém os arquivos .lst onde estão escritas as listas";

        public FormMain()
        {
            InitializeComponent();
            testFilesPath = defaultPath + "/StroopTestFiles/";

            if(!Directory.Exists(testFilesPath)) Directory.CreateDirectory(testFilesPath); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(testFilesPath + prgFolderName)) Directory.CreateDirectory(testFilesPath + prgFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(testFilesPath + lstFolderName)) Directory.CreateDirectory(testFilesPath + lstFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(defaultPath + resultsFolderName)) Directory.CreateDirectory(defaultPath + resultsFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if(!File.Exists(testFilesPath + instructionsFileName)) { File.Create(testFilesPath + "editableInstructions.txt").Dispose(); }
            if (!File.Exists(testFilesPath + prgConfigHelpFileName)) { File.Create(testFilesPath + prgConfigHelpFileName).Dispose(); }
            initializeDefaultProgram(); // inicializa programa padrão (cria arquivo programa padrão e listas de palavras e cores padrão)

            prgNameSL.Text = defaultPrgName;
            usrNameSL.Text = defaultUsrName;

            dirPathSL.Text = testFilesPath;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R) // Ctrl+R - roda teste
            {
                beginTest();
            }
            if (e.Control && e.KeyCode == Keys.D) // Ctrl+D - define programa
            {
                defineProgram();
            }
            if (e.Control && e.KeyCode == Keys.U) // Ctrl+U - define usuário
            {
                defineUser();
            }
            if (e.Control && e.KeyCode == Keys.N) // Ctrl+N - novo programa
            {
                newProgram();
            }
            if (e.Control && e.KeyCode == Keys.H) // Ctrl+H - intruções / ajuda
            {
                showInstructions();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            beginTest();
        }
        
        private void programaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrgConfig configureProgram = new FormPrgConfig(testFilesPath, "false");
            try { configureProgram.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void textoECoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLstConfig configureWordsList = new FormLstConfig(testFilesPath, "false");
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
            showInstructions();
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
        
        private void dirPathSL_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dirPathSL.Text = folderBrowserDialog1.SelectedPath;
            }
            testFilesPath = dirPathSL.Text;
        }

        private void imagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLstImgConfig configureImagesList = new FormLstImgConfig(testFilesPath + "/lst/");
            try { configureImagesList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void initializeDefaultProgram() // inicializa programDefault padrão
        {
            programDefault.UserName = defaultPrgName;
            programDefault.ProgramName = defaultUsrName;
            try
            {
                programDefault.writeDefaultProgramFile(testFilesPath + prgFolderName + programDefault.ProgramName + ".prg"); // ao inicializar formulario escreve arquivo programa padrao
                programDefault.writeDefaultWordsList(testFilesPath + lstFolderName); // escreve lista de palavras padrão
                programDefault.writeDefaultColorsList(testFilesPath + lstFolderName); // escreve lista de cores padrão 
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
                defineProgram = new FormDefine("Editar Programa: ", testFilesPath + "/prg/", "prg");
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    configureProgram = new FormPrgConfig(testFilesPath, editProgramName);
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
                defineProgram = new FormDefine("Editar Lista: ", testFilesPath, "lst");
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editListName = defineProgram.ReturnValue;
                    configureWordsList = new FormLstConfig(testFilesPath, editListName);
                    configureWordsList.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void programaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                FormDefine defineUser = new FormDefine("Excluir Programa: ", testFilesPath + "/prg/", "prg");
                var result = defineUser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string excludeFilePath = testFilesPath + "/prg/" + defineUser.ReturnValue + ".prg";
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
                FormDefine defineUser = new FormDefine("Excluir Lista: ", testFilesPath + "/lst/", "lst");
                var result = defineUser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string excludeFilePath = testFilesPath + "/lst/" + defineUser.ReturnValue + ".lst";
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
            Screen[] screens = Screen.AllScreens;
            FormExposition exposeProgram = new FormExposition(prgNameSL.Text, usrNameSL.Text, defaultPath);
            
            try
            {

                Rectangle r1 = new Rectangle();
                
                /*
                for (int i = 0; i < screens.Length; i++)
                {
                    MessageBox.Show(i + "\n" +screens[i].DeviceName + "\n" + screens[i].Bounds.ToString() + "\n" + screens[i].WorkingArea.ToString() + "\n****\n");
                }
                */
                if (screens.Length > 1)
                {
                    //MessageBox.Show(screens[1].Bounds.Width.ToString() + " / " + screens[1].Bounds.Height + "\n" + screens[0].Bounds.Width.ToString() + " / " + screens[0].Bounds.Height);
                    Rectangle bounds = screens[1].Bounds;
                    exposeProgram.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
                    exposeProgram.StartPosition = FormStartPosition.Manual;
                    //exposeProgram.Show();
                    /*
                        r1 = screens[0].WorkingArea;
                        exposeProgram.StartPosition = FormStartPosition.Manual;
                        exposeProgram.Top = r1.Top;
                        exposeProgram.Left = r1.Left;*/
                }
                SendKeys.SendWait("i");
                exposeProgram.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void defineProgram()
        {
            FormDefine defineProgram = new FormDefine("Definir Programa: ", testFilesPath + "/prg/", "prg");
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
                FormDefine defineUser = new FormDefine("Definir Participante: ", testFilesPath, "usr");
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
            FormPrgConfig configureProgram = new FormPrgConfig(testFilesPath, "false");
            try { configureProgram.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData showData;
            try
            {
                showData = new FormShowData(defaultPath + "/data/");
                showData.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormDefine defineUser = new FormDefine("Excluir Arquivo de Dados: ", defaultPath + "/data/", "txt");
                var result = defineUser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string excludeFilePath = defaultPath + "/data/" + defineUser.ReturnValue + ".txt";
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

        private void showInstructions()
        {
            FormInstructions infoBox = new FormInstructions((testFilesPath + instructionsFileName), instructionsText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void defineProgramButton_Click(object sender, EventArgs e)
        {
            defineProgram();
        }

        private void defineUserButton_Click(object sender, EventArgs e)
        {
            defineUser();
        }
    }
}
