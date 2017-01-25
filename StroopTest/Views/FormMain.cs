/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.IO;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;

namespace StroopTest
{
    public partial class FormMain : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;
        private string testFilesPath;
        private string prgFolderName = "/prg/";
        private string lstFolderName = "/lst/";
        private string resultsFolderName = "/data/";
        private string backupFolderName = "/backup/";
        public string defaultPath = (Path.GetDirectoryName(Application.ExecutablePath));
        private StroopProgram programDefault = new StroopProgram(); // programa padrão
        private string defaultPrgName = "padrao";
        private string defaultUsrName = "padrao";
        private string instructionsFileName = "editableInstructions.txt";
        private string prgConfigHelpFileName = "prgConfigHelp.txt";
        private string instructionsText = "O participante deve ser orientado para execução de forma clara e uniforme entre os experimentares e o grupo de participantes.<br><br>Para o Stroop clássico as instruções básicas praticadas são:<br>'Nesta tarefa você deve falar o nome da cor em que as palavras estão pintadas.'<br>ou<br>'Nesta tarefa você deve ler a palavra apresentada na tela.'";
        private string techText = HelpData.TechnicalInformations;
        private string helpText = HelpData.VisualizeHelp;

        public FormMain()
        {
            InitializeComponent();
            testFilesPath = defaultPath + "/StroopTestFiles/";

            if(!Directory.Exists(testFilesPath)) Directory.CreateDirectory(testFilesPath); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(testFilesPath + prgFolderName)) Directory.CreateDirectory(testFilesPath + prgFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(testFilesPath + lstFolderName)) Directory.CreateDirectory(testFilesPath + lstFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(defaultPath + resultsFolderName)) Directory.CreateDirectory(defaultPath + resultsFolderName); // cria diretório para StroopTestFiles na inicialização do formulario
            if (!Directory.Exists(defaultPath + backupFolderName)) Directory.CreateDirectory(defaultPath + backupFolderName); // cria diretório de backup p/ onde vão os arquivos excluidos
            if (!File.Exists(testFilesPath + instructionsFileName)) { File.Create(testFilesPath + "editableInstructions.txt").Dispose(); }
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
                beginTest(prgNameSL.Text);
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

        private void beginTestMainButton_Click(object sender, EventArgs e)
        {
            beginTest(prgNameSL.Text);
        }
        
        private void newProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrgConfig configureProgram = new FormPrgConfig(testFilesPath, "false");
            try { configureProgram.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void newTextColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWordColorConfig configureList = new FormWordColorConfig(testFilesPath + "/lst/", false);
            try { configureList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutWindow = new AboutBox();
            try { aboutWindow.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showInstructions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void defineProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defineProgram();
        }

        private void newParticipantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defineUser();
        }
        
        private void dirPathSL_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dirPathSL.Text = folderBrowserDialog1.SelectedPath;
            }
            testFilesPath = dirPathSL.Text;
        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImgConfig configureImagesList = new FormImgConfig(testFilesPath + "/lst/", "false");
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

        private void editProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";

            try
            {
                defineProgram = new FormDefine("Editar Programa: ", testFilesPath + "/prg/", "prg","program", false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    FormPrgConfig configureProgram = new FormPrgConfig(testFilesPath, editProgramName);
                    if (!configureProgram.IsDisposed) configureProgram.ShowDialog();
                    else { configureProgram.Close(); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void editTextColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWordColorConfig configureList = new FormWordColorConfig(testFilesPath + "/lst/", true);
            try { configureList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void deleteDataFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(defaultPath + resultsFolderName, defaultPath + backupFolderName, "txt");
        }

        private void deleteProgramFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(testFilesPath + prgFolderName, defaultPath + backupFolderName, "prg");
        }

        private void deleteListFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(testFilesPath + lstFolderName, defaultPath + backupFolderName, "lst");
        }

        private void moveFileToBackup (string originPath, string backupPath, string fileType)
        {
            try
            {
                FormDefine defineFilePath = new FormDefine("Excluir: ", originPath, fileType, "_image_words_color_audio", true);
                var result = defineFilePath.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir " + defineFilePath.ReturnValue + "?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Move(originPath + defineFilePath.ReturnValue + "." + fileType, backupPath + "backup_" + defineFilePath.ReturnValue + "." + fileType);
                        MessageBox.Show(defineFilePath.ReturnValue + ".lst excluída com sucesso!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void startTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginTest(prgNameSL.Text);
        }

        private void beginTest(string programName)
        {
            try
            {
                Screen[] sc;
                sc = Screen.AllScreens;
                int showOnMonitor = 0;
                if (sc.Length > 1)
                {
                    if (sc[0].Bounds == Screen.FromControl(this).Bounds) { showOnMonitor = 1; }
                    if (sc[1].Bounds == Screen.FromControl(this).Bounds) { showOnMonitor = 0; }
                }
                FormExposition f = new FormExposition(programName, usrNameSL.Text, defaultPath);
                f.StartPosition = FormStartPosition.Manual;
                f.Location = Screen.AllScreens[showOnMonitor].WorkingArea.Location;
                SendKeys.SendWait("i");
                f.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void defineProgram()
        {
            FormDefine defineProgram = new FormDefine("Definir Programa: ", testFilesPath + "/prg/", "prg", "program", false);
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
                FormDefine defineUser = new FormDefine("Definir Participante: ", testFilesPath, "usr", "user",false);
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
        
        private void showInstructions()
        {
            FormInstructions infoBox = new FormInstructions(instructionsText, (testFilesPath + instructionsFileName));
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

        private void editImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImgConfig configureImagesList = new FormImgConfig(testFilesPath + "/lst/", "");
            try { configureImagesList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudioConfig configureAudioList = new FormAudioConfig(testFilesPath + "/lst/", false);
            try { configureAudioList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void techInfoButto_ToolStrip_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(techText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(helpText);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        
        private void editAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudioConfig configureAudioList = new FormAudioConfig(testFilesPath + "/lst/", true);
            try { configureAudioList.ShowDialog(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void displayAudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowAudio showAudio;
            try
            {
                showAudio = new FormShowAudio(defaultPath + "/data/");
                showAudio.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void newAudioToolStripMenu_Click(object sender, EventArgs e)
        {
            FormNewAudio newAudio;
            try
            {
                newAudio = new FormNewAudio();
                newAudio.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
