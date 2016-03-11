using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormExposition exposeProgram = new FormExposition(prgNameSL.Text, usrNameSL.Text, dataFolderPath);
            try { exposeProgram.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void programaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrgConfig configureProgram = new FormPrgConfig(dataFolderPath);
            try { configureProgram.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void textoECoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLstConfig configureWordsList = new FormLstConfig(dataFolderPath);
            try { configureWordsList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutWindow = new AboutBox1();
            aboutWindow.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(dataFolderPath + instructionsFileName);
            infoBox.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void programaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram = new FormDefine("Programa: ", dataFolderPath);
            var result = defineProgram.ShowDialog();
            if (result == DialogResult.OK)
            {
                string progName = defineProgram.ReturnValue;
                prgNameSL.Text = progName;
            }
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefine defineUser = new FormDefine("Usuário: ", dataFolderPath);
            var result = defineUser.ShowDialog();
            if (result == DialogResult.OK)
            {
                string userName = defineUser.ReturnValue;
                usrNameSL.Text = userName;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram = new FormDefine("Programa: ", dataFolderPath);
            var result = defineProgram.ShowDialog();
            if (result == DialogResult.OK)
            {
                string progName = defineProgram.ReturnValue;
                prgNameSL.Text = progName;
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            FormDefine defineUser = new FormDefine("Usuário: ", dataFolderPath);
            var result = defineUser.ShowDialog();
            if (result == DialogResult.OK)
            {
                string userName = defineUser.ReturnValue;
                usrNameSL.Text = userName;
            }
        }

        private void dirPathSL_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.UserProfile;
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

        private void initializeDefaultProgram() // inicializa programDefaulta padrão
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

        /* commit test */
    }
}
