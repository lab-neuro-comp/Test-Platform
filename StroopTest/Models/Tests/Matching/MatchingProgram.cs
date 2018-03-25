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
        private Int32 numberPositions;
        private Int32 attemptsNumber;
        private String DNMTSbackground;
        private Int32 attemptsIntervalTime;
        private Int32 modelExpositionTime;
        private Boolean endExpositionWithClick;
        private Boolean randomStimuluPosition;
        private Int32 stimuluSize;
        private Boolean randomModelPosition;
        private Boolean randomIntervalModelStimulus;
        private string wordColor;
        private Int32 stimuluNumber;
        private Boolean expositionAudioResponse;
        private Boolean feedbackAudioResponse;
        private Boolean commissionAudioResponse;
        private Boolean omissionAudioResponse;
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
                                 " Numero de estimulos:", stimuluNumber, " tamanho do estimulo", stimuluSize
                                 );
        }

        private void setExpositionLists(string imageList, string wordList, string colorList, string wordColor)
        {
            if (imageList != LocRM.GetString("open", currentCulture))
            {
                this.setImageListFile(imageList);
                this.setWordListFile("false");
                this.setColorListFile("false");
                this.wordColor = "false";
            }
            else if (wordList != LocRM.GetString("open", currentCulture))
            {
                this.setWordListFile(wordList);
                this.setImageListFile("false");
                if (colorList != LocRM.GetString("open", currentCulture))
                {
                    this.setColorListFile(colorList);
                    this.wordColor = "false";
                }
                else
                {
                    this.wordColor = wordColor;
                    this.setColorListFile("false");
                }
            }
        }

        /// <summary>
        /// This constructor is used to create an matching program
        /// </summary>
        public MatchingProgram(string programName, string expositionType, int stimuluNumber,
            int AttemptsNumber, int stimuluSize, bool randomPosition,
            bool endExpositionWithClick, string imageList, int intervalTime, 
            bool intervalTimeRandom, int expositionTime, int modelExpositionTime, 
            int attemptsIntervalTime,  string backgroundColor, string DNMTSBackground, 
            bool randomOrder, bool randomIntervalModelStimulus, bool randomStimuluPosition,
            string wordList, string colorList, string wordColor, bool expositionAudioResponse,
            bool feedbackAudioResponse, bool omissionAudioResponse, bool commissionAudioResponse)
        {
            // Program properties
            this.programName = programName;
            this.expositionTime = expositionTime;
            this.stimuluNumber = stimuluNumber;
            this.intervalTime = intervalTime;
            this.backgroundColor = backgroundColor;
            this.intervalTimeRandom = intervalTimeRandom;
            this.setExpositionLists(imageList, wordList, colorList, wordColor);

            // Matching properties
            this.stimuluSize = stimuluSize;
            this.randomModelPosition = randomPosition;
            this.endExpositionWithClick = endExpositionWithClick;
            this.modelExpositionTime = modelExpositionTime;
            this.attemptsIntervalTime = attemptsIntervalTime;
            this.DNMTSBackground = DNMTSBackground;
            this.AttemptsNumber = AttemptsNumber;
            this.randomIntervalModelStimulus = randomIntervalModelStimulus;
            this.feedbackAudioResponse = feedbackAudioResponse;
            this.omissionAudioResponse = omissionAudioResponse;
            this.commissionAudioResponse = commissionAudioResponse;
            this.expositionAudioResponse = expositionAudioResponse;
            this.randomStimuluPosition = randomStimuluPosition;
            //default configurations for Mathing program
            this.setAudioListFile("false");
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
                 this.stimuluNumber.ToString() + " " +
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
                this.randomModelPosition.ToString() + " " +
                this.endExpositionWithClick.ToString() + " " +
                this.modelExpositionTime.ToString() + " " +
                this.attemptsIntervalTime.ToString() + " " +
                this.DNMTSBackground.ToUpper() + " " +
                this.AttemptsNumber.ToString() + " " +
                this.numberPositions.ToString() + " " +
                this.randomIntervalModelStimulus.ToString() + " " +
                this.randomStimuluPosition.ToString() + " " +
                this.wordColor + " " +
                this.expositionAudioResponse.ToString() + " " +
                this.feedbackAudioResponse.ToString() + " " +
                this.commissionAudioResponse.ToString() + " " +
                this.omissionAudioResponse.ToString();
                
            return data;
        }

        public string getExpositionType()
        {
            return expositionType;
        }

        public Boolean RandomIntervalModelStimulus
        {
            get
            {
                return randomIntervalModelStimulus;
            }
            set
            {
                randomIntervalModelStimulus = value;
            }
        }

        public Boolean RandomStimulusPosition
        {
            get
            {
                return randomStimuluPosition;
            }
            set
            {
                randomStimuluPosition = value;
            }
        }

        public Int32 StimuluSize
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

        public Boolean RandomModelPosition
        {
            get
            {
                return randomModelPosition;
            }

            set
            {
                randomModelPosition = value;
            }
        }
        public Boolean EndExpositionWithClick
        {
            get
            {
                return endExpositionWithClick;
            }

            set
            {
                endExpositionWithClick = value;
            }
        }
        public Boolean ExpositionAudioResponse
        {
            get
            {
                return expositionAudioResponse;
            }

            set
            {
                ExpositionAudioResponse = value;
            }
        }

        public Boolean CommissionAudioResponse
        {
            get
            {
                return commissionAudioResponse;
            }
            set
            {
                commissionAudioResponse = value;
            }
        }

        public Boolean OmissionAudioResponse
        {
            get
            {
                return omissionAudioResponse;
            }
            set
            {
                omissionAudioResponse = value;
            }

        }

        public Boolean FeedbackAudioResponse
        {
            get
            {
                return feedbackAudioResponse;
            }

            set
            {
                feedbackAudioResponse = value;
            }
        }

        public Int32 StimuluNumber
        {
            get
            {
                return stimuluNumber;
            }
            set
            {
                stimuluNumber = value;
            }
        }

        public Int32 ModelExpositionTime
        {
            get
            {
                return modelExpositionTime;
            }

            set
            {
                modelExpositionTime = value;
            }
        }

        public String WordColor
        {
            get
            {
                return wordColor;
            }
            set
            {
                wordColor = value;
            }
        }

        public Int32 AttemptsIntervalTime
        {
            get
            {
                return attemptsIntervalTime;
            }

            set
            {
                attemptsIntervalTime = value;
            }
        }
        public String DNMTSBackground
        {
            get
            {
                return DNMTSbackground;
            }

            set
            {
                DNMTSbackground = value;
            }
        }
        public Int32 AttemptsNumber
        {
            get
            {
                return attemptsNumber;
            }

            set
            {
                attemptsNumber = value;
            }
        }

        public Int32 NumberPositions
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
            stimuluNumber = int.Parse(config[1]);
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
            randomModelPosition = bool.Parse(config[16]);
            endExpositionWithClick = bool.Parse(config[17]);
            modelExpositionTime = int.Parse(config[18]);
            attemptsIntervalTime = int.Parse(config[19]);
            DNMTSBackground = config[20];
            AttemptsNumber = int.Parse(config[21]);
            numberPositions = int.Parse(config[22]);
            randomIntervalModelStimulus = bool.Parse(config[23]);
            randomStimuluPosition = bool.Parse(config[24]);
            wordColor = config[25];
            expositionAudioResponse = Boolean.Parse(config[26]);
            feedbackAudioResponse = Boolean.Parse(config[27]);
            commissionAudioResponse = Boolean.Parse(config[28]);
            omissionAudioResponse = Boolean.Parse(config[29]);
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
