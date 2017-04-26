using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TestPlatform.Models;

namespace TestPlatform.Views
{
    public partial class FormReactExposition : Form
    {
        ReactionProgram programInUse = new ReactionProgram();
        ReactionTest executingTest = new ReactionTest();
        private static float elapsedTime;               
        private string path;                           
        private List<string> outputContent;            
        private string outputDataPath;                
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private string outputFile;


        public FormReactExposition(string prgName, string participantName, string defaultPath)
        {
            path = defaultPath + "/ReactionTestFiles/";
            outputDataPath = path + "/data";
            startTime = hour + "_" + minutes + "_" + seconds;
            programInUse.ProgramName = prgName;
            executingTest.ParticipantName = participantName;
            InitializeComponent();
        }


        public void startExposition()
        {
            if (programInUse.Ready(path))
            {
                initializeExposition();
            }
            else
            {
                if (!programInUse.Exists(path))
                {
                    throw new Exception("Arquivo programa: " + programInUse.ProgramName + ".prg" +
                                    "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/"));
                }
                else if (programInUse.NeedsEdition)
                {
                    repairProgram();
                }

                else
                {
                    // do nothing
                }
                
            }
        }

        public void initializeExposition()
        {
            switch (programInUse.ExpositionType)
            {
                case "txt":
                  //  await startWordExposition();
                    break;
                case "imgtxt":
                  //  await startImageExposition();
                    break;
                case "img":
                  //  await startImageExposition();
                    break;
                case "txtaud":
                  //  await startWordExposition();
                    break;
                case "imgaud":
                   // await startImageExposition();
                    break;
                default:
                    throw new Exception("Tipo de Exposição: " + programInUse.ExpositionType + " inválido!");
            }
        }

        private void repairProgram()
        {
            try
            {
                FormTRConfig configureProgram = new FormTRConfig();
                configureProgram.Path = path;
                configureProgram.PrgName = "/" + programInUse.ProgramName;
                this.Controls.Add(configureProgram);
            }
            catch (Exception ex) { throw new Exception("Edição não pode ser feita " + ex.Message); }
        }

    }
}
