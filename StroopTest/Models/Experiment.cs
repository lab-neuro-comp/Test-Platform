using System;
using System.Collections.Generic;
using System.IO;
using TestPlatform.Views;

namespace TestPlatform.Models
{
    class Experiment
    {
        private String experimentName;
        private List<Program> programList = new List<Program>();
        private Boolean isOrderRandom; // if true it means that programs will not be executed in the list order
        private Int32 intervalTime;               // duration time for interval between program expositions in millisec, it can be zero
        private List<string> instructionText = new List<string>();

        public bool IsOrderRandom
        {
            get
            {
                return isOrderRandom;
            }

            set
            {
                isOrderRandom = value;
            }
        }

        public int IntervalTime
        {
            get
            {
                return intervalTime;
            }

            set
            {
                if (Validations.isExperimentIntervalTimeValid(value))
                {
                    intervalTime = value;
                }
                else
                {
                    throw new ArgumentException("\nTempo de intervalo entre programas deve ser maior ou igual a zero (em milissegundos)");
                }
            }
        }

        public string Name
        {
            get
            {
                return experimentName;
            }

            set
            {
                if (Validations.isAlphanumeric(value))
                {
                    experimentName = value;
                }
                else
                {
                    throw new ArgumentException("Nome do experimento deve ser composto apenas de caracteres alphanumericos " +
                                                "e sem espaços;\nExemplo: 'MeuExperimento'");
                }
            }
        }

        public List<string> InstructionText
        {
            get
            {
                return instructionText;
            }

            set
            {
                instructionText = value;
            }
        }

        internal List<Program> ProgramList
        {
            get
            {
                return programList;
            }

            set
            {
                programList = value;
            }
        }

        public void addStroopProgram(string programName)
        {
            StroopProgram newProgram = new StroopProgram();
            newProgram.ProgramName = programName;
            newProgram.readProgramFile(Global.stroopTestFilesPath + Global.programFolderName + newProgram.ProgramName + ".prg");
            ProgramList.Add(newProgram);
        }

        public void addReactionProgram(string programName)
        {
            ReactionProgram newProgram = new ReactionProgram(Global.reactionTestFilesPath + Global.programFolderName + programName + ".prg");
            ProgramList.Add(newProgram);
        }

        private string data()
        {
            string experimentData = this.experimentName + " " + this.intervalTime + " " + this.isOrderRandom;
            return experimentData;
        }

        private string writeProgramList()
        {
            string stringList = "";
            foreach (Program program in ProgramList)
            {
                if(program.GetType() == typeof(StroopProgram))
                {
                    stringList = stringList + program.ProgramName + " StroopProgram ";
                }
                else if (program.GetType() == typeof(ReactionProgram))
                {
                    stringList = stringList + program.ProgramName + " ReactionProgram ";
                }
            }
            return stringList;
        }

        public bool saveExperimentFile(string path)
        {
            StreamWriter writer = new StreamWriter(path + experimentName + ".prg");
            writer.WriteLine(data());
            writer.WriteLine(writeProgramList());
            if (InstructionText != null)
            {
                for (int i = 0; i < InstructionText.Count; i++)
                {
                    writer.WriteLine(InstructionText[i]);
                }
            }
            writer.Close();
            return true;
        }

    }
}
