namespace TestPlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TestPlatform.Views;

    public class ExperimentProgram
    {
        private string experimentName;
        private List<Program> programList = new List<Program>();
        private bool isOrderRandom; // if true it means that programs will not be executed in the list order
        private int intervalTime;               // duration time for interval between program expositions in millisec, it can be zero
        private List<string> instructionText = new List<string>();
        private bool trainingProgram; // if true there is a program which is fixed (training program) and the  rest is random

        public bool IsOrderRandom
        {
            get
            {
                return this.isOrderRandom;
            }

            set
            {
                this.isOrderRandom = value;
            }
        }

        public int IntervalTime
        {
            get
            {
                return this.intervalTime;
            }

            set
            {
                if (Validations.isExperimentIntervalTimeValid(value))
                {
                    this.intervalTime = value;
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
                return this.ExperimentName;
            }

            set
            {
                if (Validations.isAlphanumeric(value))
                {
                    this.ExperimentName = value;
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
                return this.instructionText;
            }

            set
            {
                this.instructionText = value;
            }
        }

        internal List<Program> ProgramList
        {
            get
            {
                return this.programList;
            }

            set
            {
                this.programList = value;
            }
        }

        public string ExperimentName
        {
            get
            {
                return this.experimentName;
            }

            set
            {
                this.experimentName = value;
            }
        }

        public bool TrainingProgram
        {
            get
            {
                return this.trainingProgram;
            }

            set
            {
                this.trainingProgram = value;
            }
        }

        public void AddStroopProgram(string programName)
        {
            StroopProgram newProgram = new StroopProgram();
            newProgram.ProgramName = programName;
            newProgram.readProgramFile(Global.stroopTestFilesPath + Global.programFolderName + newProgram.ProgramName + ".prg");
            ProgramList.Add(newProgram);
        }

        public void AddReactionProgram(string programName)
        {
            ReactionProgram newProgram = new ReactionProgram(Global.reactionTestFilesPath + Global.programFolderName + programName + ".prg");
            ProgramList.Add(newProgram);
        }

        private string Data()
        {
            string experimentData = this.ExperimentName + " " + this.intervalTime + " " + this.isOrderRandom + " " + this.trainingProgram;
            return experimentData;
        }

        private string WriteProgramList()
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

        /* getting information from .prg file and converting to an experiment object */
        public void ReadProgramFile() 
        {            
            string filePath = Global.experimentTestFilesPath + Global.programFolderName + ExperimentName + ".prg";
            if (File.Exists(filePath))
            {
                string[] fileLines = File.ReadAllLines(filePath);
                string line = fileLines[0];
                line = Program.encodeLatinText(line);
                List<string> configurationFile = line.Split().ToList();

                ExperimentName = configurationFile[0];
                if (Path.GetFileNameWithoutExtension(filePath) != (this.ExperimentName))
                {
                    throw new Exception("Parâmetro escrito no arquivo como: '" + this.ExperimentName +
                        "'\ndeveria ser igual ao nome no arquivo: '" + Path.GetFileNameWithoutExtension(filePath) + "'.prg");
                }
                IntervalTime = int.Parse(configurationFile[1]);
                IsOrderRandom = bool.Parse(configurationFile[2]);
                if (configurationFile.Count > 3)
                {
                    TrainingProgram = bool.Parse(configurationFile[3]);
                }
                else
                {
                    TrainingProgram = false;
                }

                string listLine = fileLines[1];
                line = Program.encodeLatinText(line);
                List<string> listConfiguration = listLine.Split().ToList();
                for (int i = 1; i <= listConfiguration.Count() - 2; i = i + 2)
                {
                    if (listConfiguration[i] == "StroopProgram")
                    {
                       AddStroopProgram(listConfiguration[i - 1]);
                    }
                    else if (listConfiguration[i] == "ReactionProgram")
                    {
                        AddReactionProgram(listConfiguration[i - 1]);
                    }
                }

                if (fileLines.Length > 2) // reads instructions if there are any
                {
                    for (int i = 2; i < fileLines.Length; i++)
                    {
                        this.InstructionText.Add(fileLines[i]);
                   }
                }
                else
                {
                    this.InstructionText = null;
                }
            }
            else
            {
               throw new FileNotFoundException("Arquivo programa: " + Path.GetFileName(filePath) + "\nnão foi encontrado no local:\n" +
                Path.GetDirectoryName(filePath));
            }           

        }

        public bool SaveExperimentFile(string path)
        {
            StreamWriter writer = new StreamWriter(path + ExperimentName + ".prg");
            writer.WriteLine(Data());
            writer.WriteLine(WriteProgramList());
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


        public void Shuffle()
        {
            Random random = new Random();
            int counter = programList.Count;
            while (counter > 1)
            {
                counter--;
                int k = random.Next(counter + 1);
                Program value = programList[k];
                programList[k] = programList[counter];
                programList[counter] = value;
            }
        }

        public void ShuffleWithTrainingProgram()
        {
            Random random = new Random();
            int counter = programList.Count;
            while (counter > 2)
            {
                counter--;
                int k = random.Next(1,counter + 1);
                Program value = programList[k];
                programList[k] = programList[counter];
                programList[counter] = value;
            }
        }

    }
}
