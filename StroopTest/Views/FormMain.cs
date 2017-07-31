/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.IO;
using System.Windows.Forms;
using TestPlatform.Models;
using TestPlatform.Views;
using TestPlatform.Views.SidebarControls;
using TestPlatform.Views.SidebarUserControls;
using System.Collections.Generic;
using TestPlatform.Controllers;

namespace TestPlatform
{
    public partial class FormMain : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;
        

        private static string DEFAULTPGRNAME = "padrao";
        private static string DEFAULTUSERNAME = "padrao";
        private static string INSTRUCTIONSFILENAME = "editableInstructions.txt";
        private static string PGRCONFIGHELPFILENAME = "prgConfigHelp.txt";
        private static string INSTRUCTIONSTEXT = "O participante deve ser orientado para execução de forma clara e uniforme entre os experimentares e o grupo de participantes.<br><br>Para o Stroop clássico as instruções básicas praticadas são:<br>'Nesta tarefa você deve falar o nome da cor em que as palavras estão pintadas.'<br>ou<br>'Nesta tarefa você deve ler a palavra apresentada na tela.'";
        private static string TECHTEXT = HelpData.TechnicalInformations;
        private static string HELPTEXT = HelpData.VisualizeHelp;
        public Panel _contentPanel;
        /* Variables
         */
        private StroopProgram programDefault = new StroopProgram();
        private Control currentPanelContent; //holds current panel in exact execution time
        
        

        /**
         * Constructor method, creates directories for program, in case they dont exist
         * */
        public FormMain()
        {
            /* Creating main folder for application*/
            Global.defaultPath = (Path.GetDirectoryName(Application.ExecutablePath)); //saving on variable current executing path
            Global.testFilesPath = Global.defaultPath + Global.testFilesPath;
            if (!Directory.Exists(Global.testFilesPath))
            {
                Directory.CreateDirectory(Global.testFilesPath);
            }
            else
            {
                /*do nothing*/
            }
            Global.stroopTestFilesPath = Global.testFilesPath + Global.stroopTestFilesPath;
            // updating local directory of new version of platform, excluding old stroop one
            if (File.Exists(Global.defaultPath + "/StroopTest.exe")) 
            {               

                DirectoryInfo directoryOldLst = new DirectoryInfo(Global.defaultPath + "/StroopTestFiles/lst");
                directoryOldLst.MoveTo(Global.testFilesPath + Global.listFolderName);
                
                DirectoryInfo directoryOldStroop = new DirectoryInfo(Global.defaultPath + "/StroopTestFiles/");
                directoryOldStroop.MoveTo(Global.stroopTestFilesPath);                

                DirectoryInfo directoryOldData = new DirectoryInfo(Global.defaultPath + "/data");
                directoryOldData.MoveTo(Global.stroopTestFilesPath + Global.resultsFolderName);


                try
                {
                    File.Delete(Global.defaultPath + "/StroopTest.exe");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

            }
            else
            {
                /*do nothing*/
            }
            
            /* creating directories related to StroopTest in case they don't already exists*/
            if (!Directory.Exists(Global.stroopTestFilesPath))
                Directory.CreateDirectory(Global.stroopTestFilesPath);
            if (!Directory.Exists(Global.stroopTestFilesPath + Global.programFolderName))
                Directory.CreateDirectory(Global.stroopTestFilesPath + Global.programFolderName);
            if (!Directory.Exists(Global.stroopTestFilesPath + Global.resultsFolderName))
                Directory.CreateDirectory(Global.stroopTestFilesPath + Global.resultsFolderName);

            /* creating directories related to ReactionTest in case they don't already exists*/
            Global.reactionTestFilesPath = Global.testFilesPath + Global.reactionTestFilesPath;
            if (!Directory.Exists(Global.reactionTestFilesPath))
                Directory.CreateDirectory(Global.reactionTestFilesPath);
            if (!Directory.Exists(Global.reactionTestFilesPath + Global.programFolderName))
                Directory.CreateDirectory(Global.reactionTestFilesPath + Global.programFolderName);
            if (!Directory.Exists(Global.reactionTestFilesPath + Global.resultsFolderName))
                Directory.CreateDirectory(Global.reactionTestFilesPath + Global.resultsFolderName);

            /* creating directories related to Experiment in case they don't already exists*/
            Global.experimentTestFilesPath = Global.testFilesPath + Global.experimentTestFilesPath;
            if (!Directory.Exists(Global.experimentTestFilesPath))
                Directory.CreateDirectory(Global.experimentTestFilesPath);
            if (!Directory.Exists(Global.experimentTestFilesPath + Global.programFolderName))
                Directory.CreateDirectory(Global.experimentTestFilesPath + Global.programFolderName);
            if (!Directory.Exists(Global.experimentTestFilesPath + Global.resultsFolderName))
                Directory.CreateDirectory(Global.experimentTestFilesPath + Global.resultsFolderName);

            /* creating Lists folder*/
            if (!Directory.Exists(Global.testFilesPath + Global.listFolderName))
            {
                Directory.CreateDirectory(Global.testFilesPath + Global.listFolderName);
            }

            if (!Directory.Exists(Global.defaultPath + Global.backupFolderName))
                Directory.CreateDirectory(Global.defaultPath + Global.backupFolderName);
            if (!File.Exists(Global.testFilesPath + INSTRUCTIONSFILENAME))
                File.Create(Global.testFilesPath + "editableInstructions.txt").Dispose();
            if (!File.Exists(Global.testFilesPath + PGRCONFIGHELPFILENAME))
                File.Create(Global.testFilesPath + PGRCONFIGHELPFILENAME).Dispose();

            if (File.Exists(Global.defaultPath + "/StroopTestFiles"))
                File.Delete(Global.defaultPath + "/StroopTestFiles");


            initializeDefaultProgram(); // inicializa programa padrão (cria arquivo programa padrão e listas de palavras e cores padrão)
            InitializeComponent();
            _contentPanel = contentPanel;
            dirPathSL.Text = Global.testFilesPath;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R) // Ctrl+R - roda teste
            {
                ExpositionController.beginStroopTest(executingNameLabel.Text, participantTextBox.Text, markTextBox.Text[0], this);
            }
            if (e.Control && e.KeyCode == Keys.D) // Ctrl+D - define programa
            {
                defineTest();
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


        
        private void newTextColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWordColorConfig configureList = new FormWordColorConfig(false);
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
            defineTest();
        }
        
        private void dirPathSL_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dirPathSL.Text = folderBrowserDialog1.SelectedPath;
            }
            Global.testFilesPath = dirPathSL.Text;
        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImgConfig configureImagesList = new FormImgConfig("false");
            try
            {
                this.Controls.Add(configureImagesList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void initializeDefaultProgram() // inicializa programDefault padrão
        {
            programDefault.ProgramName = DEFAULTUSERNAME;
            try
            {
                programDefault.writeDefaultProgramFile(Global.stroopTestFilesPath + Global.programFolderName + programDefault.ProgramName + ".prg"); // ao inicializar formulario escreve arquivo programa padrao
                StrList.writeDefaultWordsList(Global.testFilesPath + Global.listFolderName); // escreve lista de palavras padrão
                StrList.writeDefaultColorsList(Global.testFilesPath + Global.listFolderName); // escreve lista de cores padrão 
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
            FormWordColorConfig configureList = new FormWordColorConfig(true);
            try
            {
                this.Controls.Add(configureList);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void deleteDataFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(Global.stroopTestFilesPath + Global.resultsFolderName, Global.defaultPath + Global.backupFolderName, "txt");
        }

        private void deleteProgramFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(Global.stroopTestFilesPath + Global.programFolderName, Global.defaultPath + Global.backupFolderName, "prg");
        }

        private void deleteListFile_ToolStrip_Click(object sender, EventArgs e)
        {
            moveFileToBackup(Global.testFilesPath + Global.listFolderName, Global.defaultPath + Global.backupFolderName, "lst");
        }

        private void moveFileToBackup (string originPath, string backupPath, string fileType)
        {
            try
            {
                FormDefine defineFilePath = new FormDefine("Excluir: ", originPath, fileType, "_image_words_color_audio", 
                    true);
                var result = defineFilePath.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir " + defineFilePath.ReturnValue 
                        + "?", "", MessageBoxButtons.YesNo); // pergunta se deseja repetir o programa

                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Move(originPath + defineFilePath.ReturnValue + "." + fileType, backupPath + "backup_" + 
                            defineFilePath.ReturnValue + "." + fileType);
                        MessageBox.Show(defineFilePath.ReturnValue + ".lst excluída com sucesso!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void startTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpositionController.beginStroopTest(executingNameLabel.Text, participantTextBox.Text, markTextBox.Text[0], this);
        }


        private void defineTest()
        {
            FormDefineTest defineTest = new FormDefineTest();
            try
            {
                var result = defineTest.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string progName = defineTest.returnValues[1];
                    executingNameLabel.Text = progName;
                    executingTypeLabel.Text = defineTest.returnValues[0];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void newProgram()
        {

            FormPrgConfig configureProgram = new FormPrgConfig("false");
            this.Controls.Add(configureProgram);
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData showData;
            try
            {
                showData = new FormShowData();
                this.Controls.Add(showData);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void showInstructions()
        {
            FormInstructions infoBox = new FormInstructions(INSTRUCTIONSTEXT, (Global.testFilesPath + INSTRUCTIONSFILENAME));
            try { infoBox.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void editImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImgConfig configureImagesList = new FormImgConfig("");
            try { this.Controls.Add(configureImagesList); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudioConfig configureAudioList = new FormAudioConfig(false);
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
            FormAudioConfig configureAudioList = new FormAudioConfig(true);
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
                showAudio = new FormShowAudio();
                this.Controls.Add(showAudio);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void newAudioToolStripMenu_Click(object sender, EventArgs e)
        {
            FormShowAudio showAudio;
            try
            {
                showAudio = new FormShowAudio();
                this.Controls.Add(showAudio);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void experimentButton_CheckedChanged(object sender, EventArgs e)
        {
            if (experimentButton.Checked)
            {
                // removing second side bar from view, if there is one, and removing its context too
                if (currentPanelContent != null)
                {
                    Controls.Remove(currentPanelContent);
                    contentPanel.Controls.Clear();
                }

                ExperimentControl experimentControl = new ExperimentControl();
                this.sideBarPanel.Controls.Add(experimentControl);
                currentPanelContent = experimentControl;
            }
        }

        private void buttonStroop_CheckedChanged(object sender, EventArgs e)
        {
            
            if (buttonStroop.Checked)
            {
                // removing second side bar from view, if there is one, and removing its context too
                if (sideBarPanel.Controls.Count > 0)
                {
                    sideBarPanel.Controls.Remove(currentPanelContent);
                    contentPanel.Controls.Clear();
                }
                StroopControl stroopControl = new StroopControl();
                this.sideBarPanel.Controls.Add(stroopControl);
                currentPanelContent = stroopControl;
            }
        }

        private void buttonReaction_Click(object sender, EventArgs e)
        {
            if (buttonReaction.Checked)
            {
                // removing second side bar from view, if there is one, and removing its context too
                if (sideBarPanel.Controls.Count > 0)
                {
                    sideBarPanel.Controls.Remove(currentPanelContent);
                    contentPanel.Controls.Clear();
                }
                ReactionControl reactControl = new ReactionControl();
                this.sideBarPanel.Controls.Add(reactControl);
                currentPanelContent = reactControl;
            }

        }

        private void buttonList_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonList.Checked)
            {
                // removing second side bar from view, if there is one, and removing its context too
                if (sideBarPanel.Controls.Count > 0)
                {
                    sideBarPanel.Controls.Remove(currentPanelContent);
                    contentPanel.Controls.Clear();
                }
                else
                {
                    /*do nothing*/
                }
                ListUserControl listControl = new ListUserControl();
                this.sideBarPanel.Controls.Add(listControl);
                currentPanelContent = listControl;
            }
        }

        private void resultButton_CheckedChanged(object sender, EventArgs e)
        {
            if (resultButton.Checked)
            {
                // removing second side bar from view, if there is one, and removing its context too
                if (sideBarPanel.Controls.Count > 0)
                {
                    sideBarPanel.Controls.Remove(currentPanelContent);
                    contentPanel.Controls.Clear();
                }
                else
                {
                    /*do nothing*/
                }
                ResultsUserControl resultsControl = new ResultsUserControl();
                this.sideBarPanel.Controls.Add(resultsControl);
                currentPanelContent = resultsControl;
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
            FormPrgConfig configureProgram = new FormPrgConfig("false");
            this.Controls.Add(configureProgram);
        }

        private void reactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTRConfig configureProgram = new FormTRConfig("false");
            this.Controls.Add(configureProgram);
        }

        private void stroopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";

            try
            {
                defineProgram = new FormDefine("Editar Programa: ", Global.stroopTestFilesPath + Global.programFolderName, "prg", "program", false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    FormPrgConfig configureProgram = new FormPrgConfig(editProgramName);
                    this.Controls.Add(configureProgram);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void reactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDefine defineProgram;
            DialogResult result;
            string editProgramName = "error";

            try
            {
                defineProgram = new FormDefine("Editar Programa: ", Global.reactionTestFilesPath + Global.programFolderName, "prg", "program", false);
                result = defineProgram.ShowDialog();
                if (result == DialogResult.OK)
                {
                    editProgramName = defineProgram.ReturnValue;
                    FormTRConfig configureProgram = new FormTRConfig(editProgramName);
                    configureProgram.PrgName = editProgramName;
                    this.Controls.Add(configureProgram);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {             
                if (executingTypeLabel.Text.Equals("StroopTest"))
                {
                    ExpositionController.beginStroopTest(executingNameLabel.Text, participantTextBox.Text, markTextBox.Text[0], this);
                }

                else if (executingTypeLabel.Text.Equals("ReactionTest"))
                {
                    ExpositionController.beginReactionTest(executingNameLabel.Text, participantTextBox.Text, markTextBox.Text[0], this);
                }
                else if (executingTypeLabel.Text.Equals("Experimento"))
                {
                    ExpositionController.beginExperimentTest(executingNameLabel.Text, participantTextBox.Text, markTextBox.Text[0], this);
                }
                else
                {
                    /* do nothing*/
                }
            }
            else
            {
                MessageBox.Show("Algum campo não foi preenchido de forma correta.");

            }

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
                defineTest();            
        }

        private void participantTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(participantTextBox, "");
        }

        public bool ValidParticipantName(string participantName, out string errorMessage)
        {
            if (participantName.Length == 0)
            {
                errorMessage = "O nome do participante deve ser preenchido.";
                return false;
            }
            if (!Validations.isAlphanumeric(participantName))
            {
                errorMessage = "Nome do participante deve ser composto apenas de caracteres alphanumericos" + 
                    "e sem espaços;\nExemplo: 'MeuPrograma'";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void participantTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (ValidParticipantName(participantTextBox.Text, out errorMsg))
            {
                /* field is valid */
            }
            else
            {
                e.Cancel = true;
                this.errorProvider1.SetError(participantTextBox, errorMsg);
            }
        }

        private void markTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(markTextBox, "");
        }

        public bool ValidMark(string mark, out string errorMessage)
        {
            if (mark.Length == 0)
            {
                errorMessage = "O campo da marca deve ser preenchido.";
                return false;
            }
            if (mark.Length > 1)
            {
                errorMessage = "A marca deve ser composta apenas de um caracter";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void markTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (ValidMark(markTextBox.Text, out errorMsg))
            {
                /* field is valid */
            }
            else
            {
                e.Cancel = true;
                this.errorProvider1.SetError(markTextBox, errorMsg);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void menuPanel_Click(object sender, EventArgs e)
        {
            sideBarPanel.Controls.Clear();
            contentPanel.Controls.Clear();
        }
    }
}
