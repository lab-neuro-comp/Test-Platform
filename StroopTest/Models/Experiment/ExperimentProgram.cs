namespace TestPlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using System.Windows.Forms;
    using Views;

    public class ExperimentProgram
    {
        private string experimentName;
        private List<Program> programList = new List<Program>();
        private bool isOrderRandom; // if true it means that programs will not be executed in the list order
        private int intervalTime;               // duration time for interval between program expositions in millisec, it can be zero
        private List<string> instructionText = new List<string>();
        private bool trainingProgram; // if true there is a program which is fixed (training program) and the  rest is random
       // properties used to localize strings during runtime
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;

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
                    throw new ArgumentException(LocRM.GetString("intervalInvalid", currentCulture));
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
                    throw new ArgumentException(LocRM.GetString("experimentName", currentCulture));
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

        public bool AddStroopProgram(string programName)
        {
            try
            {
                if(!File.Exists(Global.stroopTestFilesPath + Global.programFolderName + programName + ".prg")) { throw new MissingMemberException(programName + " (" + LocRM.GetString("stroopTest", currentCulture) + ")"); };
                StroopProgram newProgram = new StroopProgram();
                newProgram.ProgramName = programName;
                newProgram.readProgramFile(Global.stroopTestFilesPath + Global.programFolderName + newProgram.ProgramName + ".prg");
                ProgramList.Add(newProgram);
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            return true;
        }

        public bool AddReactionProgram(string programName)
        {
            try
            {
                if (!File.Exists(Global.reactionTestFilesPath + Global.programFolderName + programName + ".prg")) { throw new MissingMemberException(programName + " (" + LocRM.GetString("reactionTest", currentCulture) + ")"); };
                ReactionProgram newProgram = new ReactionProgram(Global.reactionTestFilesPath + Global.programFolderName + programName + ".prg");
                ProgramList.Add(newProgram);
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            return true;
        }

        public bool AddMatchingProgram(string programName)
        {
            try
            {
                if (!File.Exists(Global.matchingTestFilesPath + Global.programFolderName + programName + ".prg")) { throw new MissingMemberException(programName + " (" + LocRM.GetString("matchingTest", currentCulture) + ")"); };
                MatchingProgram newProgram = new MatchingProgram(Global.matchingTestFilesPath + Global.programFolderName + programName + ".prg");
                ProgramList.Add(newProgram);
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            return true;
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
                else if (program.GetType() == typeof(MatchingProgram))
                {
                    stringList = stringList + program.ProgramName + " MatchingProgram ";
                }

            }
            return stringList;
        }

        /* getting information from .prg file and converting to an experiment object */
        public void ReadProgramFile(bool recoverFromBackup = false) 
        {
            string filePath;
            bool isProgramValid = true;
            if (recoverFromBackup)
            {
                filePath = Global.experimentTestFilesBackupPath + ExperimentName + ".prg";

            }
            else
            {
                filePath = Global.experimentTestFilesPath + Global.programFolderName + ExperimentName + ".prg";
            }
            if (File.Exists(filePath))
            {
                string[] fileLines = File.ReadAllLines(filePath);
                string line = fileLines[0];
                line = Program.encodeLatinText(line);
                List<string> configurationFile = line.Split().ToList();

                ExperimentName = configurationFile[0];
                if (Path.GetFileNameWithoutExtension(filePath) != (this.ExperimentName))
                {
                    throw new Exception(LocRM.GetString("parameter", currentCulture) + this.ExperimentName +
                       LocRM.GetString("parameterShould", currentCulture) + Path.GetFileNameWithoutExtension(filePath) + "'.prg");
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
                        isProgramValid = AddStroopProgram(listConfiguration[i - 1]);
                    }
                    else if (listConfiguration[i] == "ReactionProgram")
                    {
                        isProgramValid = AddReactionProgram(listConfiguration[i - 1]);
                    }
                    else if (listConfiguration[i] == "MatchingProgram")
                    {
                        isProgramValid = AddMatchingProgram(listConfiguration[i - 1]);
                    }
                    if(!isProgramValid && recoverFromBackup)
                    {
                        throw new FileNotFoundException(listConfiguration[i - 1]);
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
                if (!isProgramValid)
                {
                    this.SaveExperimentFile(Global.experimentTestFilesPath + Global.programFolderName);
                }
            }
            else
            {
               throw new FileNotFoundException(LocRM.GetString("fileNotFound", currentCulture) + Path.GetDirectoryName(filePath));
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
