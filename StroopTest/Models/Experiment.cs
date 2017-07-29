using System;
using System.Collections.Generic;
using System.IO;

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

        public void addStroopProgram(string programName, string path)
        {
            StroopProgram newProgram = new StroopProgram();
            newProgram.ProgramName = programName;
            newProgram.readProgramFile(path + "/prg/" + newProgram.ProgramName + ".prg");
            addingProgramToList(newProgram);
        }

        public void addReactionProgram(string path)
        {
            ReactionProgram newProgram = new ReactionProgram(path);
            addingProgramToList(newProgram);
        }

        private string data()
        {
            string experimentData = this.experimentName + " " + this.intervalTime + " " + this.isOrderRandom + "\n";
            experimentData = experimentData + String.Join(", ", programList);

            return experimentData;
        }

        public bool saveExperimentFile(string path, string instructionBoxText)
        {
            StreamWriter writer = new StreamWriter(path + "ExperimentTestFiles/prg/" + experimentName + ".prg");
            writer.Write(data());
            if (InstructionText != null && InstructionText[0] != instructionBoxText)
            {
                for (int i = 0; i < InstructionText.Count; i++)
                {
                    writer.WriteLine(InstructionText[i]);
                }
            }
            writer.Close();
            return true;
        }

        private void addingProgramToList(Program program)
        {
            programList.Add(program);
        }
    }
}
