using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models
{
    class Experiment
    {
        String experimentName;
        List<Program> programList = new List<Program>();
        Boolean isOrderRandom; // if true it means that programs will not be executed in the list order
        Int32 intervalTime;               // duration time for interval between program expositions in millisec, it can be zero

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

        private void addStroopProgram(string programName, string path)
        {
            StroopProgram newProgram = new StroopProgram();
            newProgram.ProgramName = programName;
            newProgram.readProgramFile(path + "/prg/" + newProgram.ProgramName + ".prg");
            addingProgramToList(newProgram);
        }

        private void addReactionProgram(string path)
        {
            ReactionProgram newProgram = new ReactionProgram(path);
            addingProgramToList(newProgram);
        }


        private void addingProgramToList(Program program)
        {
            programList.Add(program);
        }
    }
}
