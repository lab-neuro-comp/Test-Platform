using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestPlatform.Views;

namespace TestPlatform.Models
{
    class ReactionProgram : Program
    {
        private Int32 stimuluSize; // [3]
        private Int32 stimulusDistance; // [5] distance from the center of the screen to stimulus
        private Boolean isBeeping; // [9]
        private Boolean beepingRandom; // [19]
        private Int32 beepDuration; // [10]
        private String stimulusColor; // [11]
        private String stimuluShape; // keeps a list of shapes in this program, which one separated by a comma (",")
        private Int32 numberPositions; // [20]
        private String responseType; // [21]
        private Boolean hasColorList;

        private static Int32 ELEMENTS = 24; //quantity of fields used in ReactionProgram 

        public ReactionProgram()
        {

        }

        public ReactionProgram(string programPath)
        {
            this.readProgramFile(programPath);
        }

        public override string ToString()
        {
            return String.Concat("Nome do programa: ", programName, " tempo de exposição: ",expositionTime, 
                                 " Numero de exposicoes:", numExpositions, " tamanho do estimulo", stimuluSize
                                 );
        }

        /// <summary>
        /// This constructor is used to create a reaction program with shapes
        /// </summary>
        public ReactionProgram(string programName, int expositionTime, int numExpositions, int stimuluSize, int intervalTime,
                                int stimulusDistance, bool isBeeping, int beepDuration, string stimulusColor,
                                string fixPoint, string backgroundColor, string fixPointColor, bool intervalTimeRandom,
                                string stimuluShape, bool beepRandom, int numberPositions,
                                string responseType, string colorList, bool hasColorList)
        {
            // Program properties
            this.programName = programName;
            this.expositionTime = expositionTime;
            this.numExpositions = numExpositions;
            this.intervalTime = intervalTime;
            this.fixPoint = fixPoint;
            this.backgroundColor = backgroundColor;
            this.fixPointColor = fixPointColor;
            this.intervalTimeRandom = intervalTimeRandom;

            // ReactionProgram properties
            this.stimuluSize = stimuluSize;
            this.stimulusDistance = stimulusDistance;
            this.isBeeping  = isBeeping;
            this.beepDuration = beepDuration;
            this.stimuluShape = stimuluShape;
            this.BeepingRandom = beepRandom;
            this.ResponseType = responseType;
            this.NumberPositions = numberPositions;
            this.hasColorList = hasColorList;
            if(!hasColorList)
            {
                this.stimulusColor = stimulusColor;
                this.setColorListFile("false");
            }
            else
            {
                this.stimulusColor = "false";
                this.setColorListFile(colorList);
            }

            //default configurations for shapes version of ReactionProgram
            this.setAudioListFile("false");
            this.setImageListFile("false");
            this.setWordListFile("false");
            this.expositionRandom = false;
            this.expositionType =  "shapes";

            

        }

        /// <summary>
        /// This constructor is used to create a reaction program with words
        /// </summary>
        public ReactionProgram(string programName, int expositionTime, int numExpositions, int stimuluSize, int intervalTime,
                                int stimulusDistance, bool isBeeping, int beepDuration, string stimulusColor,
                                string fixPoint, string backgroundColor, string fixPointColor, bool intervalTimeRandom,
                                bool beepRandom, int numberPositions, string responseType,
                                string wordList, bool expositionRandom, string colorList, bool hasColorList)
        {
            // Program properties
            this.programName = programName;
            this.expositionTime = expositionTime;
            this.numExpositions = numExpositions;
            this.intervalTime = intervalTime;
            this.fixPoint = fixPoint;
            this.backgroundColor = backgroundColor;
            this.fixPointColor = fixPointColor;
            this.intervalTimeRandom = intervalTimeRandom;
            this.expositionRandom = expositionRandom;

            // ReactionProgram properties
            this.stimuluSize = stimuluSize;
            this.stimulusDistance = stimulusDistance;
            this.isBeeping = isBeeping;
            this.beepDuration = beepDuration;
            this.stimuluShape = "false";
            this.BeepingRandom = beepRandom;
            this.ResponseType = responseType;
            this.NumberPositions = numberPositions;
            this.setWordListFile(wordList);
            this.hasColorList = hasColorList;
            if (!hasColorList)
            {
                this.stimulusColor = stimulusColor;
                this.setColorListFile("false");
            }
            else
            {
                this.stimulusColor = "false";
                this.setColorListFile(colorList);
            }

            //default configurations for shapes version of ReactionProgram
            this.setAudioListFile("false");
            this.setImageListFile("false");
            this.expositionType = "words";

        }

        /// <summary>
        /// This constructor is used to create a reaction program with image type
        /// </summary>
        public ReactionProgram(string programName, int expositionTime, int numExpositions, int stimuluSize, int intervalTime,
                        int stimulusDistance, bool isBeeping, int beepDuration,
                        string fixPoint, string backgroundColor, string fixPointColor, bool intervalTimeRandom,
                        string imageList, bool beepRandom, int numberPositions,
                        string responseType, bool isExpositionRandom)
        {
            // Program properties
            this.programName = programName;
            this.expositionTime = expositionTime;
            this.numExpositions = numExpositions;
            this.intervalTime = intervalTime;
            this.fixPoint = fixPoint;
            this.backgroundColor = backgroundColor;
            this.fixPointColor = fixPointColor;
            this.intervalTimeRandom = intervalTimeRandom;
            this.expositionRandom = isExpositionRandom;

            // ReactionProgram properties
            this.stimuluSize = stimuluSize;
            this.stimulusDistance = stimulusDistance;
            this.isBeeping = isBeeping;
            this.beepDuration = beepDuration;
            this.stimulusColor = "false";
            this.stimuluShape = "false";
            this.BeepingRandom = beepRandom;
            this.ResponseType = responseType;
            this.NumberPositions = numberPositions;
            this.hasColorList = false;

            //default configurations for first version of ReactionProgram
            this.setAudioListFile("false");
            this.setColorListFile("false");
            this.setWordListFile("false");
            this.setImageListFile(imageList);
            this.expositionType = "images"; 

        }

        /// <summary>
        /// This constructor is used to create a reaction program with image and words
        /// </summary>
        public ReactionProgram(string programName, int expositionTime, int numExpositions, int stimuluSize, int intervalTime,
                        int stimulusDistance, bool isBeeping, int beepDuration,
                        string fixPoint, string backgroundColor, string fixPointColor, bool intervalTimeRandom,
                        string imageList, string wordList,  string colorList, bool beepRandom, int numberPositions,
                        bool hasColorList, string responseType, bool isExpositionRandom, string stimulusColor)
        {
            // Program properties
            this.programName = programName;
            this.expositionTime = expositionTime;
            this.numExpositions = numExpositions;
            this.intervalTime = intervalTime;
            this.fixPoint = fixPoint;
            this.backgroundColor = backgroundColor;
            this.fixPointColor = fixPointColor;
            this.intervalTimeRandom = intervalTimeRandom;
            this.expositionRandom = isExpositionRandom;

            // ReactionProgram properties
            this.stimuluSize = stimuluSize;
            this.stimulusDistance = stimulusDistance;
            this.isBeeping = isBeeping;
            this.beepDuration = beepDuration;
            this.stimuluShape = "false";
            this.BeepingRandom = beepRandom;
            this.ResponseType = responseType;
            this.NumberPositions = numberPositions;
            this.hasColorList = hasColorList;
            if (!hasColorList)
            {
                this.stimulusColor = stimulusColor;
                this.setColorListFile("false");
            }
            else
            {
                this.stimulusColor = "false";
                this.setColorListFile(colorList);
            }

            //default configurations for first version of ReactionProgram
            this.setAudioListFile("false");
            this.setWordListFile(wordList);
            this.setImageListFile(imageList);
            this.expositionType = "imageAndWord";
        }

        public int StimuluSize
        {
            get
            {
                return stimuluSize;
            }

            set
            {
                stimuluSize = value;
            }
        }

        public int StimulusDistance
        {
            get
            {
                return stimulusDistance;
            }

            set
            {
                stimulusDistance = value;
            }
        }

        public bool IsBeeping
        {
            get
            {
                return isBeeping;
            }

            set
            {
                isBeeping = value;
            }
        }

        public int BeepDuration
        {
            get
            {
                return beepDuration;
            }

            set
            {
                beepDuration = value;
            }
        }

        public string StimulusColor
        {
            get
            {
                return stimulusColor;
            }

            set
            {
                stimulusColor = value;
            }
        }

        public string ExpositionType
        {
            get { return expositionType; }
            set
            {
                if (Validations.isExpoReactValid(value))
                {
                    expositionType = value;
                }
                else
                {
                    throw new ArgumentException("Tipo de exposição deve ser do tipo 'Formas', 'Palavra', 'Imagem'," +
                                                   "'Imagem e Palavra', 'Palavra com Aúdio' ou 'Imagem com Aúdio'");
                }
            }
        }

        public string StimuluShape
        {
            get
            {
                return stimuluShape;
            }

            set
            {
                stimuluShape = value;
            }
        }

        public bool BeepingRandom
        {
            get
            {
                return beepingRandom;
            }

            set
            {
                beepingRandom = value;
            }
        }

        public bool getHasColorList()
        {
            return this.hasColorList;
        }

        public void setHasColorList(Boolean hasColorList)
        {
            this.hasColorList = hasColorList;

        }

        public int NumberPositions
        {
            get
            {
                return numberPositions;
            }

            set
            {
                numberPositions = value;
            }
        }

        public string ResponseType
        {
            get
            {
                return responseType;
            }

            set
            {
                responseType = value;
            }
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
                 this.StimuluSize.ToString() + " " +
                 this.IntervalTime.ToString() + " " +
                 this.StimulusDistance.ToString() + " " +
                 wordList + " " +
                 colorList + " " +
                 this.BackgroundColor.ToUpper() + " " +
                 this.isBeeping.ToString() + " " +
                 this.BeepDuration.ToString() + " " +
                 this.StimulusColor.ToString() + " " +
                 this.ExpositionType + " " +
                 imageList + " " +
                 audioList + " " +
                 this.FixPoint + " " +
                 this.FixPointColor + " " +
                 this.IntervalTimeRandom + " " +
                 this.stimuluShape + " " +
                 this.BeepingRandom + " " +
                 this.NumberPositions + " " +
                 this.ResponseType + " " +
                 this.ExpositionRandom.ToString() + " " +
                 this.hasColorList.ToString();
            
            return data;
        }

        // lê arquivo com programa e retorna true para sucesso
        public void readProgramFile(string filepath)
        {
            StreamReader tr;
            string line;
            string[] linesInstruction;
            List<string> config = new List<string>();

            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); } // confere existência do arquivo
                
                tr = new StreamReader(filepath, Encoding.Default, true);
                line = tr.ReadLine();
                line = encodeLatinText(line);
                config = line.Split().ToList();
                tr.Close();

                needsEditionFlag = false;
                if (config.Count() != ELEMENTS)
                {
                    needsEditionFlag = true;

                    List<string> defaultConfig = LocRM.GetString("defaultReactionProgram", currentCulture).Split().ToList();
                    for (int i = 0; i < ELEMENTS; i++)
                    {
                        config.Add(defaultConfig[i]);
                    }
                }

                ProgramName = config[0];
                if (Path.GetFileNameWithoutExtension(filepath) != (this.ProgramName)) {
                    throw new Exception("Parâmetro escrito no arquivo como: '" + this.ProgramName + 
                        "'\ndeveria ser igual ao nome no arquivo: '" + Path.GetFileNameWithoutExtension(filepath) + "'.prg");
                }
                NumExpositions = int.Parse(config[1]);
                ExpositionTime = int.Parse(config[2]);
                StimuluSize = int.Parse(config[3]);
                IntervalTime = int.Parse(config[4]);
                StimulusDistance = int.Parse(config[5]);
                setWordListFile(config[6]);
                setColorListFile(config[7]);
                BackgroundColor = config[8];
                IsBeeping = bool.Parse(config[9]);
                BeepDuration = int.Parse(config[10]);
                StimulusColor = config[11];
                ExpositionType = config[12]; 
                setImageListFile(config[13]);
                setAudioListFile(config[14]);
                FixPoint = config[15];
                FixPointColor = config[16];
                IntervalTimeRandom = bool.Parse(config[17]);
                StimuluShape = config[18];
                BeepingRandom = bool.Parse(config[19]);
                NumberPositions = int.Parse(config[20]);
                ResponseType = config[21];
                expositionRandom = bool.Parse(config[22]);
                hasColorList = bool.Parse(config[23]);
                linesInstruction = File.ReadAllLines(filepath);
                if (linesInstruction.Length > 1) // lê instrução se houver
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
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Arquivo programa: " + Path.GetFileName(filepath) + "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + "\n\n( " + ex.Message + " )");
            }

        }

        // saves default reaction program file on disk
        public void writeDefaultProgramFile()  
        {
            try
            {
                string[] defaultInstructionText = { LocRM.GetString("defaultReactionInstructions1", currentCulture),
                                                    LocRM.GetString("defaultReactionInstructions2", currentCulture)};
                TextWriter tw = new StreamWriter(Global.reactionTestFilesPath + Global.programFolderName + LocRM.GetString("default", currentCulture) + ".prg");
                tw.WriteLine(LocRM.GetString("defaultReactionProgram", currentCulture));
                for (int i = 0; i < defaultInstructionText.Length; i++)
                {
                    tw.WriteLine(defaultInstructionText[i]);
                }
                tw.Close();
            }
            catch (Exception e)
            {
                throw new Exception(LocRM.GetString("defaultReactionProgramError", currentCulture) + "\n\n\n" +  e.Message);
            }
        }

        public bool saveProgramFile(string path, string instructionBoxText)
        {
            StreamWriter writer = new StreamWriter(path + ProgramName + ".prg");
            writer.WriteLine(data());
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

    }
}
