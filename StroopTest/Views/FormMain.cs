/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.IO;
using System.Windows.Forms;
using StroopTest.Models;
using StroopTest.Views;
using StroopTest.Views.SidebarControls;
using TestPlatform.Views.SidebarUserControls;
using System.Collections.Generic;
using TestPlatform.Views;

namespace StroopTest
{
    public partial class FormMain : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;
        
        /*
         * Valores constantes do programa
         * */
        private static string PGRFOLDERNAME = "/prg/";
        private static string LSTFOLDERNAME = "/lst/";
        private static string RESULTSFOLDERNAME = "/data/";
        private static string BACKUPFOLDERNAME = "/backup/";
        private static string DEFAULTPGRNAME = "padrao";
        private static string DEFAULTUSERNAME = "padrao";
        private static string INSTRUCTIONSFILENAME = "editableInstructions.txt";
        private static string PGRCONFIGHELPFILENAME = "prgConfigHelp.txt";
        private static string INSTRUCTIONSTEXT = "O participante deve ser orientado para execução de forma clara e uniforme entre os experimentares e o grupo de participantes.<br><br>Para o Stroop clássico as instruções básicas praticadas são:<br>'Nesta tarefa você deve falar o nome da cor em que as palavras estão pintadas.'<br>ou<br>'Nesta tarefa você deve ler a palavra apresentada na tela.'";
        private static string TECHTEXT = HelpData.TechnicalInformations;
        private static string HELPTEXT = HelpData.VisualizeHelp;

        /* Variaveis
         */
        private StroopProgram programDefault = new StroopProgram();
        private Control currentPanelContent; //guarda o painel do segundo menu que esta renderizado no momento da execução
        private string testFilesPath;
        public string defaultPath = (Path.GetDirectoryName(Application.ExecutablePath));

        /**
         * Metodo construtor do formulario, cria os diretorios necessarios para o programa caso nao existam
         * */
        public FormMain()
        {
            InitializeComponent();
            testFilesPath = defaultPath + "/StroopTestFiles/";

            if(!Directory.Exists(testFilesPath)) Directory.CreateDirectory(testFilesPath); 
            if (!Directory.Exists(testFilesPath + PGRFOLDERNAME)) Directory.CreateDirectory(testFilesPath + PGRFOLDERNAME); 
            if (!Directory.Exists(testFilesPath + LSTFOLDERNAME)) Directory.CreateDirectory(testFilesPath + LSTFOLDERNAME); 
            if (!Directory.Exists(defaultPath + RESULTSFOLDERNAME)) Directory.CreateDirectory(defaultPath + RESULTSFOLDERNAME); 
            if (!Directory.Exists(defaultPath + BACKUPFOLDERNAME)) Directory.CreateDirectory(defaultPath + BACKUPFOLDERNAME); 
            if (!File.Exists(testFilesPath + INSTRUCTIONSFILENAME)) { File.Create(testFilesPath + "editableInstructions.txt").Dispose(); }
            if (!File.Exists(testFilesPath + PGRCONFIGHELPFILENAME)) { File.Create(testFilesPath + PGRCONFIGHELPFILENAME).Dispose(); }
            initializeDefaultProgram(); // inicializa programa padrão (cria arquivo programa padrão e listas de palavras e cores padrão)

            prgNameSL.Text = DEFAULTPGRNAME;
            usrNameSL.Text = DEFAULTUSERNAME;

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
        
        private void newTextColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWordColorConfig configureList = new FormWordColorConfig(testFilesPath + "/lst/", false);
            try
            {
                this.Controls.Add(configureList);
            }
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
            try
            {
                this.Controls.Add(configureImagesList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void initializeDefaultProgram() // inicializa programDefault padrão
        {
            programDefault.UserName = DEFAULTPGRNAME;
            programDefault.ProgramName = DEFAULTUSERNAME;
            try
            {
                programDefault.writeDefaultProgramFile(testFilesPath + PGRFOLDERNAME + programDefault.ProgramName + ".prg"); // ao inicializar formulario escreve arquivo programa padrao
                StrList.writeDefaultWordsList(testFilesPath + LSTFOLDERNAME); // escreve lista de palavras padrão
                StrList.writeDefaultColorsList(testFilesPath + LSTFOLDERNAME); // escreve lista de cores padrão 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void editProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editTextColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWordColorConfig configureList = new FormWordColorConfig(testFilesPath + "/lst/", true);
            try
            {
                this.Controls.Add(configureList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void deleteDataFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(defaultPath + RESULTSFOLDERNAME, defaultPath + BACKUPFOLDERNAME, "txt");
        }

        private void deleteProgramFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(testFilesPath + PGRFOLDERNAME, defaultPath + BACKUPFOLDERNAME, "prg");
        }

        private void deleteListFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(testFilesPath + LSTFOLDERNAME, defaultPath + BACKUPFOLDERNAME, "lst");
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

            FormPrgConfig configureProgram = new FormPrgConfig();
            configureProgram.Path = testFilesPath;
            this.Controls.Add(configureProgram);
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData showData;
            try
            {
                showData = new FormShowData(defaultPath + "/data/");
                this.Controls.Add(showData);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void showInstructions()
        {
            FormInstructions infoBox = new FormInstructions(INSTRUCTIONSTEXT, (testFilesPath + INSTRUCTIONSFILENAME));
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
            try { this.Controls.Add(configureImagesList); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudioConfig configureAudioList = new FormAudioConfig(testFilesPath + "/lst/", false);
            try
            {
                this.Controls.Add(configureAudioList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void techInfoButto_ToolStrip_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(TECHTEXT);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInstructions infoBox = new FormInstructions(HELPTEXT);
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        
        private void editAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudioConfig configureAudioList = new FormAudioConfig(testFilesPath + "/lst/", true);
            try
            {
                this.Controls.Add(configureAudioList);
            }
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
                this.Controls.Add(newAudio);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void experimentButton_CheckedChanged(object sender, EventArgs e)
        {
            if (experimentButton.Checked)
            {
                if(currentPanelContent != null)
                {
                    Controls.Remove(currentPanelContent);
                }

                ExperimentControl experimentControl = new ExperimentControl();
                this.Controls.Add(experimentControl);
                currentPanelContent = experimentControl;
            }
        }

        private void buttonStroop_CheckedChanged(object sender, EventArgs e)
        {
            
            if (buttonStroop.Checked)
            {
                if (currentPanelContent != null)
                {
                    Controls.Remove(currentPanelContent);
                }
                StroopControl stroopControl = new StroopControl();
                stroopControl.TestFilesPath = testFilesPath;
                this.Controls.Add(stroopControl);
                currentPanelContent = stroopControl;
            }
        }

        private void buttonReaction_Click(object sender, EventArgs e)
        {
            if (buttonReaction.Checked)
            {
                if (currentPanelContent != null)
                {
                    Controls.Remove(currentPanelContent);
                }
                ReactionControl reactControl = new ReactionControl();
                reactControl.TestFilesPath = testFilesPath;
                this.Controls.Add(reactControl);
                currentPanelContent = reactControl;
            }

        }

        private void buttonList_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonList.Checked)
            {
                if (currentPanelContent != null)
                {
                    Controls.Remove(currentPanelContent);
                }
                ListUserControl listControl = new ListUserControl();
                listControl.TestFilesPath = testFilesPath;
                this.Controls.Add(listControl);
                currentPanelContent = listControl;
            }
        }

        private void resultButton_CheckedChanged(object sender, EventArgs e)
        {
            if (resultButton.Checked)
            {
                if (currentPanelContent != null)
                {
                    Controls.Remove(currentPanelContent);
                }
                FormShowData showData;
                try
                {
                    showData = new FormShowData(defaultPath + "/data/");
                    this.Controls.Add(showData);
                    currentPanelContent = showData;
                    resultButton.Checked = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }


        private void executeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (executeButton.Checked)
            {
                if (currentPanelContent != null)
                {
                    Controls.Remove(currentPanelContent);
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            List<Control> controls = new List<Control>();

            if (e.Control.GetType().BaseType == typeof(UserControl))
            {
                int count = 0;
                foreach (Control c in Controls)
                {
                    if (!(c.Equals(currentPanelContent)) && c is UserControl)
                    {
                        controls.Add(c);
                        count++;
                    }
                }
                if (count > 1)
                {
                    Controls.Remove(controls[0]);

                }
            }
        }

        private void stroopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrgConfig configureProgram = new FormPrgConfig();
            configureProgram.Path = testFilesPath;
            this.Controls.Add(configureProgram);
        }

        private void reactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTRConfig configureProgram = new FormTRConfig();
            configureProgram.Path = testFilesPath;
            this.Controls.Add(configureProgram);
        }

        private void stroopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";

            try
            {
                defineProgram = new FormDefine("Editar Programa: ", testFilesPath + "/prg/", "prg", "program", false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    FormPrgConfig configureProgram = new FormPrgConfig();
                    configureProgram.Path = testFilesPath;
                    configureProgram.PrgName = editProgramName;
                    this.Controls.Add(configureProgram);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
