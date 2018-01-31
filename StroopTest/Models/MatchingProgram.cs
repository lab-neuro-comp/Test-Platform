using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models
{
    class MatchingProgram : Program
    {
        private String disposition;
        private Int32 stimuluSize;
        private Boolean randomPosition;
        private Boolean endExpositionWithClick;
        private Int32 modelExpositionTime;
        private Int32 attemptsIntervalTime;
        private String DNMTSBackground;
        private Int32 AttemptsNumber;

        public MatchingProgram()
        {

        }

        public MatchingProgram(string programPath)
        {
            this.readProgramFile(programPath);
        }

        public override string ToString()
        {
            return String.Concat("Nome do programa: ", programName, " tempo de exposição: ", expositionTime,
                                 " Numero de exposicoes:", numExpositions, " tamanho do estimulo", stimuluSize
                                 );
        }

        /// <summary>
        /// This constructor is used to create an matching program
        /// </summary>
        public MatchingProgram(string programName, string expositionType, string disposition, 
            int numExpositions, int AttemptsNumber, int stimuluSize, bool randomPosition,
            bool endExpositionWithClick, string imageList, int intervalTime, 
            bool intervalTimeRandom, int expositionTime, int modelExpositionTime, 
            int attemptsIntervalTime,  string backgroundColor, string DNMTSBackground, bool randomOrder)
        {
            // Program properties
            this.programName = programName;
            this.expositionTime = expositionTime;
            this.numExpositions = numExpositions;
            this.intervalTime = intervalTime;
            this.backgroundColor = backgroundColor;
            this.intervalTimeRandom = intervalTimeRandom;
            this.setImageListFile(imageList);
            // Matching properties
            this.stimuluSize = stimuluSize;
            this.disposition = disposition;
            this.randomPosition = randomPosition;
            this.endExpositionWithClick = endExpositionWithClick;
            this.modelExpositionTime = modelExpositionTime;
            this.attemptsIntervalTime = attemptsIntervalTime;
            this.DNMTSBackground = DNMTSBackground;
            this.AttemptsNumber = AttemptsNumber;

            //default configurations for Mathing program
            this.setAudioListFile("false");
            this.setColorListFile("false");
            this.setWordListFile("false");
            this.expositionRandom = randomOrder;
            this.expositionType = expositionType;
            this.fixPoint = "false";
            this.fixPointColor = "false";
        }

        public string data()
        {
            string audioList = "false";
            if (this.getAudioListFile() != null)
            {
                audioList = this.getAudioListFile().ListName;
            }

            string wordList = "false";
            if (this.getWordListFile() != null)
            {
                wordList = this.getWordListFile().ListName;
            }

            string colorList = "false";
            if (this.getColorListFile() != null)
            {
                colorList = this.getColorListFile().ListName;
            }

            string imageList = "false";
            if (this.getImageListFile() != null)
            {
                imageList = this.getImageListFile().ListName;
            }
            string data = this.ProgramName + " " +
                 this.NumExpositions.ToString() + " " +
                 this.ExpositionTime.ToString() + " " +
                 this.expositionRandom.ToString() + " " +
                 this.IntervalTime.ToString() + " " +
                 this.IntervalTimeRandom + " " +
                 wordList + " " +
                 colorList + " " +
                 this.BackgroundColor.ToUpper() + " " +
                 this.expositionType + " " +
                 imageList + " " +
                 this.FixPoint + " " +
                 audioList + " " +
                 this.FixPointColor + " " +
                 this.intervalTime.ToString() + " " +
                this.stimuluSize.ToString() + " " +
                this.disposition + " " +
                this.randomPosition.ToString() + " " +
                this.endExpositionWithClick.ToString() + " " +
                this.modelExpositionTime.ToString() + " " +
                this.attemptsIntervalTime.ToString() + " " +
                this.DNMTSBackground.ToUpper() + " " +
                this.AttemptsNumber.ToString();

            return data;
        }

        public string getExpositionType()
        {
            return expositionType;
        }

        public string getDisposition()
        {
            return disposition;
        }
        public int getStimuluSize()
        {
            return stimuluSize;
        }
        public bool getRandomPosition()
        {
            return randomPosition;
        }
        public bool getEndExpositionWithClick()
        {
            return endExpositionWithClick;
        }
        public int getModelExpositionTime()
        {
            return modelExpositionTime;
        }
        public int getAttemptsIntervalTime()
        {
            return attemptsIntervalTime;
        }
        public string getDNMTSBackground()
        {
            return DNMTSBackground;
        }
        public int getAttemptsNumber()
        {
            return AttemptsNumber;
        }

        public void readProgramFile(string filepath)
        {
            StreamReader tr;
            string line;
            string[] linesInstruction;
            List<string> config = new List<string>();


            if (!File.Exists(filepath)) { throw new FileNotFoundException(); } // confere existência do arquivo

            tr = new StreamReader(filepath, Encoding.Default, true);
            line = tr.ReadLine();
            line = encodeLatinText(line);
            config = line.Split().ToList();
            tr.Close();

            ProgramName = config[0];
            if (Path.GetFileNameWithoutExtension(filepath) != (this.ProgramName))
            {
                throw new Exception("Parâmetro escrito no arquivo como: '" + this.ProgramName +
                    "'\ndeveria ser igual ao nome no arquivo: '" + Path.GetFileNameWithoutExtension(filepath) + "'.prg");
            }
            NumExpositions = int.Parse(config[1]);
            ExpositionTime = int.Parse(config[2]);
            expositionRandom = bool.Parse(config[3]);
            IntervalTime = int.Parse(config[4]);
            IntervalTimeRandom = bool.Parse(config[5]);
            setWordListFile(config[6]);
            setColorListFile(config[7]);
            BackgroundColor = config[8];
            expositionType = config[9];
            setImageListFile(config[10]);
            FixPoint = config[11];
            setAudioListFile(config[12]);
            FixPointColor = config[13];
            intervalTime = int.Parse(config[14]);
            stimuluSize = int.Parse(config[15]);
            disposition = config[16];
            randomPosition = bool.Parse(config[17]);
            endExpositionWithClick = bool.Parse(config[18]);
            modelExpositionTime = int.Parse(config[19]);
            attemptsIntervalTime = int.Parse(config[20]);
            DNMTSBackground = config[21];
            AttemptsNumber = int.Parse(config[22]);
            linesInstruction = File.ReadAllLines(filepath);
            if (linesInstruction.Length > 1) // read instructions if any
            {
                for (int i = 1; i < linesInstruction.Length; i++)
                {
                    this.InstructionText.Add(linesInstruction[i]);
                }
            }
            else
            {
                this.InstructionText = null;
            }



        }

        public bool saveProgramFile(string path, string instructionBoxText)
        {
            StreamWriter writer = new StreamWriter(path + ProgramName + ".prg");
            writer.WriteLine(data());
            if (instructionBoxText.Length > 0)
            {
                    writer.WriteLine(instructionBoxText);
            }
            writer.Close();
            return true;
        }
    }
}
