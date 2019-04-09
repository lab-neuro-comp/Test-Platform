using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models.Tests.SpacialRecognition
{
    class SpacialRecognitionProgram : Program
    {
        private Int32 stimuluType;
        private float stimuluSize;
        private Int32 fontSize;
        private Int32 stimuluCount;
        private String stimuluSingleColor;
        private Int32 stimuluDelay;
        private bool stimuluDelayRandom;
        private bool playExpositionSound;
        private bool playOmissionSound;
        private bool playClickSound;
        public const int IMAGE_TEST = 0;
        public const int WORD_TEST = 1;
        public const int WORD_COLOR_TEST = 2;
        
        public bool PlayOmissionSound
        {
            get
            {
                return playOmissionSound;
            }
            set
            {
                playOmissionSound = value;
            }
        }

        public bool PlayClickSound
        {
            get
            {
                return playClickSound;
            }
            set
            {
                playClickSound = value;
            }
        }

        public int StimuluType
        {
            get { return stimuluType; }
        }
        public float StimuluSize
        {
            get { return stimuluSize; }
        }
        public Int32 FontSize
        {
            get { return fontSize; }
        }
        public Int32 StimuluCount
        {
            get { return stimuluCount; }
        }
        public String StimuluSingleColor
        {
            get { return stimuluSingleColor; }
        }
        public Int32 StimuluDelay
        {
            get { return stimuluDelay; }
        }
        public bool StimuluDelayRandom
        {
            get { return stimuluDelayRandom; }
        }
        public bool PlayExpositionSound
        {
            get { return playExpositionSound; }
        }

        public SpacialRecognitionProgram(string programName)
        {
            this.configureReadProgram(GetProgramsPath() + programName + FileManipulation.ProgramExtension);
        }

        public void configureReadProgram(string filepath)
        {
            StreamReader tr;
            string line;
            string[] linesInstruction;
            List<string> config = new List<string>();


            if (!File.Exists(filepath)) { throw new FileNotFoundException(); } // confere existência do arquivo

            tr = new StreamReader(filepath, Encoding.Default, true);
            line = tr.ReadLine();
            line = FileManipulation.EncodeLatinText(line);
            config = line.Split().ToList();
            tr.Close();

            ProgramName = config[0];
            if (Path.GetFileNameWithoutExtension(filepath) != (this.ProgramName))
            {
                throw new Exception("Parâmetro escrito no arquivo como: '" + this.ProgramName +
                    "'\ndeveria ser igual ao nome no arquivo: '" + Path.GetFileNameWithoutExtension(filepath) + "'.prg");
            }
            this.numExpositions = Int32.Parse(config[1]);
            this.expositionRandom = Boolean.Parse(config[2]);
            setWordListFile(config[3]);
            setColorListFile(config[4]);
            setImageListFile(config[5]);
            this.expositionTime = Int32.Parse(config[6]);
            this.intervalTime = Int32.Parse(config[7]);
            this.intervalTimeRandom = Boolean.Parse(config[8]);
            this.stimuluType = Int32.Parse(config[9]);
            this.stimuluSize = float.Parse(config[10]);
            this.fontSize = Int32.Parse(config[11]);
            this.stimuluCount = Int32.Parse(config[12]);
            this.stimuluSingleColor = config[13];
            this.stimuluDelay = Int32.Parse(config[14]);
            this.stimuluDelayRandom = Boolean.Parse(config[15]);
            this.playExpositionSound = Boolean.Parse(config[16]);
            this.playOmissionSound = Boolean.Parse(config[17]);
            this.playClickSound = Boolean.Parse(config[18]);

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

        public SpacialRecognitionProgram(
            String programName, int numExpositions, bool expositionRandom, 
            String wordsListFile, String colorsListFile, String imagesListFile,
            int expositionTime, int intervalTime, bool intervalTimeRandom,
            int stimuluType, float stimuluSize, int fontSize,
            int stimuluCount, String stimuluSingleColor, int stimuluDelay,
            bool stimuluDelayRandom, bool playExpositionSound, bool playOmissionSound, bool playClickSound
        )
        {
            this.programName = programName;
            this.numExpositions = numExpositions;
            this.expositionRandom = expositionRandom;
            this.expositionTime = expositionTime;
            this.intervalTime = intervalTime;
            this.intervalTimeRandom = intervalTimeRandom;
            this.stimuluType = stimuluType;
            this.stimuluSize = stimuluSize;
            this.fontSize = fontSize;
            this.stimuluCount = stimuluCount;
            this.stimuluDelay = stimuluDelay;
            this.stimuluDelayRandom = stimuluDelayRandom;
            this.playExpositionSound = playExpositionSound;
            this.playOmissionSound = playOmissionSound;
            this.playClickSound = playClickSound;

            this.setExpositionLists(imagesListFile, wordsListFile, colorsListFile, stimuluSingleColor);
        }

        public SpacialRecognitionProgram()
        {
        }

        private void setExpositionLists(string imageList, string wordList, string colorList, string wordColor)
        {
            if (imageList != LocRM.GetString("open", currentCulture))
            {
                this.setImageListFile(imageList);
                this.setWordListFile("false");
                this.setColorListFile("false");
                this.stimuluSingleColor = "false";
            }
            else if (wordList != LocRM.GetString("open", currentCulture))
            {
                this.setWordListFile(wordList);
                this.setImageListFile("false");
                if (colorList != LocRM.GetString("open", currentCulture))
                {
                    this.setColorListFile(colorList);
                    this.stimuluSingleColor = "false";
                }
                else
                {
                    this.stimuluSingleColor = wordColor;
                    this.setColorListFile("false");
                }
            }
        }

        public static bool ProgramExists(string programName)
        {
            return FileManipulation.FileExists(GetProgramsPath() + programName + FileManipulation.ProgramExtension);
        }

        public static string GetProgramsPath()
        {
            return FileManipulation.SpacialRecognitionTestFilesPath + FileManipulation._programFolderName;
        }

        public static string GetResultsPath()
        {
            return FileManipulation.SpacialRecognitionTestFilesPath + FileManipulation._resultsFolderName;
        }

        public bool saveProgramFile(string instructionBoxText)
        {
            StreamWriter writer = new StreamWriter(GetProgramsPath() + ProgramName + ".prg");
            writer.WriteLine(data());
            if (instructionBoxText.Length > 0)
            {
                writer.WriteLine(instructionBoxText);
            }
            writer.Close();
            return true;
        }

        public string data()
        {
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
            string singleColor = "false";
            if (this.stimuluSingleColor != null)
            {
                singleColor = this.stimuluSingleColor;
            }
            string data = this.programName + " " +
            this.numExpositions.ToString() + " " +
            this.expositionRandom.ToString() + " " +
            wordList.ToString() + " " +
            colorList.ToString() + " " +
            imageList.ToString() + " " +
            this.expositionTime.ToString() + " " +
            this.intervalTime.ToString() + " " +
            this.intervalTimeRandom.ToString() + " " +
            this.stimuluType.ToString() + " " +
            this.stimuluSize.ToString() + " " +
            this.fontSize.ToString() + " " +
            this.stimuluCount.ToString() + " " +
            singleColor.ToString() + " " +
            this.stimuluDelay.ToString() + " " +
            this.stimuluDelayRandom.ToString() + " " +
            this.playExpositionSound.ToString() + " " +
            this.playOmissionSound.ToString() + " " +
            this.playClickSound.ToString();

            return data;
        }
    }
}
