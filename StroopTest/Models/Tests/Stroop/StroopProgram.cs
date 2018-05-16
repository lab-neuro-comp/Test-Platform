using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestPlatform.Views;

namespace TestPlatform.Models
{
    class StroopProgram : Program
    {
        private Boolean audioCapture;              // [9]*  is audio capture activated
        private Boolean subtitleShow;              // [10]* subtitles activated
        private Int32 subtitlePlace;              // [11]* subtitles place in screen (left, right, up and down the exposition stimulus)
        private String subtitleColor;           // [12]  subtitles color
        private String fontWordLabel;           // [16]  wordLabel size - 160 default
        private String subtitlesListFile;       // [19]  subtitles list file name (.lst) - if subtitles are activated [10]

        private Int32 rotateImage;                // [22]  rotacionar imagem (90, 180, 270, 360)
        private Boolean rndSubtitlePlace;          // [23]  localizacão da legenda aleatória
        private String wordColor;               // [24]  cor da palavra apresentada em palavraimg
        private Int32 delayTime;

        public StroopProgram()
        {
            new Program();
        }

        public StroopProgram(string programName)
        {
            new Program();
            readProgramFile(Global.stroopTestFilesPath + "/prg/" + programName + ".prg");
        }

        // set values for type txt
        public void setTxtType(string programName, int expoTime, int numExpo, bool expoRandom, string wordSize, int intervalTime,
                             bool intervalRandom, string wordList, string colorList)
        {
            this.ProgramName = programName;
            this.ExpositionTime = expoTime;
            this.NumExpositions = numExpo;
            this.ExpositionRandom = expoRandom;
            this.FontWordLabel = wordSize;
            this.IntervalTime = intervalTime;
            this.IntervalTimeRandom = intervalRandom;
            this.setWordListFile(wordList);
            this.setColorListFile(colorList);
            this.setImageListFile("false");
            this.setAudioListFile("false");
            this.ExpositionType = "txt";
            this.SubtitleColor = "false";
            this.SubtitlesListFile = "false";
            this.BackgroundColor = "false";
            this.FixPoint = "false";
            this.FixPointColor = "false";

        }

        // set values for type image
        public void setImageType(string programName, int expoTime, int numExpo, bool expoRandom, string wordSize, int intervalTime,
                             bool intervalRandom, string imageList)
        {
            this.ProgramName = programName;
            this.ExpositionTime = expoTime;
            this.NumExpositions = numExpo;
            this.ExpositionRandom = expoRandom;
            this.FontWordLabel = wordSize;
            this.IntervalTime = intervalTime;
            this.IntervalTimeRandom = intervalRandom;
            this.setImageListFile(imageList);
            this.setWordListFile("false");
            this.setColorListFile("false");
            this.setAudioListFile("false");
            this.ExpositionType = "img";
            this.SubtitleColor = "false";
            this.SubtitlesListFile = "false";
            this.BackgroundColor = "false";
            this.FixPoint = "false";
            this.FixPointColor = "false";

        }

        // set values for type imgtxt
        public void setImgTxtType(string programName, int expoTime, int numExpo, bool expoRandom, string wordSize, int intervalTime,
                             string wordList, string imageList, bool intervalRandom)
        {
            this.ProgramName = programName;
            this.ExpositionTime = expoTime;
            this.NumExpositions = numExpo;
            this.ExpositionRandom = expoRandom;
            this.FontWordLabel = wordSize;
            this.IntervalTime = intervalTime;
            this.IntervalTimeRandom = intervalRandom;
            this.setImageListFile(imageList);
            this.setWordListFile(wordList);
            this.setAudioListFile("false");
            this.setColorListFile("false");
            this.ExpositionType = "imgtxt";
            this.SubtitleColor = "false";
            this.SubtitlesListFile = "false";
            this.BackgroundColor = "false";
            this.FixPoint = "false";
            this.FixPointColor = "false";

        }

        // set values for type txtimg
        public void setTxtImgType(string programName, int expoTime, int numExpo, bool expoRandom, string wordSize, int intervalTime,
                             string wordList, string imageList, bool intervalRandom)
        {
            this.ProgramName = programName;
            this.ExpositionTime = expoTime;
            this.NumExpositions = numExpo;
            this.ExpositionRandom = expoRandom;
            this.FontWordLabel = wordSize;
            this.IntervalTime = intervalTime;
            this.IntervalTimeRandom = intervalRandom;
            this.setImageListFile(imageList);
            this.setWordListFile(wordList);
            this.setAudioListFile("false");
            this.setColorListFile("false");
            this.ExpositionType = "txtimg";
            this.SubtitleColor = "false";
            this.SubtitlesListFile = "false";
            this.BackgroundColor = "false";
            this.FixPoint = "false";
            this.FixPointColor = "false";

        }
        // set values for type txtaud
        public void setTxtAudType(string programName, int expoTime, int numExpo, bool expoRandom, string wordSize, int intervalTime,
                             bool intervalRandom, string wordList, string colorList, string audioList)
        {
            this.ProgramName = programName;
            this.ExpositionTime = expoTime;
            this.NumExpositions = numExpo;
            this.ExpositionRandom = expoRandom;
            this.FontWordLabel = wordSize;
            this.IntervalTime = intervalTime;
            this.IntervalTimeRandom = intervalRandom;
            this.setImageListFile("false");
            this.setWordListFile(wordList);
            this.setColorListFile(colorList);
            this.setAudioListFile(audioList);
            this.ExpositionType = "txtaud";
            this.SubtitleColor = "false";
            this.SubtitlesListFile = "false";
            this.BackgroundColor = "false";
            this.FixPoint = "false";
            this.FixPointColor = "false";

        }

        // set values for type imgaud
        public void setImgAudioType(string imageList, string audioList,string programName, int expoTime, int numExpo, bool expoRandom, string wordSize, int intervalTime,
                             bool intervalRandom)
        {
            this.ProgramName = programName;
            this.ExpositionTime = expoTime;
            this.NumExpositions = numExpo;
            this.ExpositionRandom = expoRandom;
            this.FontWordLabel = wordSize;
            this.IntervalTime = intervalTime;
            this.IntervalTimeRandom = intervalRandom;
            this.setWordListFile("false");
            this.setColorListFile("false");
            this.setAudioListFile(audioList);
            this.setImageListFile(imageList);
            this.ExpositionType = "imgaud";
            this.SubtitleColor = "false";
            this.SubtitlesListFile = "false";
            this.BackgroundColor = "false";
            this.FixPoint = "false";
            this.FixPointColor = "false";

        }


        public bool AudioCapture
        {
            get { return audioCapture; }
            set
            {
                audioCapture = value;              
            }
        }

        public bool SubtitleShow
        {
            get { return subtitleShow; }
            set
            {
                 subtitleShow = value;
            }
        }

        public int SubtitlePlace
        {
            get { return subtitlePlace; }
            set
            {
                if (Validations.isSubtitlePlaceValid(value))
                {
                    subtitlePlace = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("subtitlePositionError", currentCulture) + value + LocRM.GetString("subtitlePositionError1", currentCulture));
                }   // each number indicates a position
            }
        }

        public string SubtitleColor
        {
            get { return subtitleColor; }
            set
            {
                // colors must match with the hexadecimal pattern for color codes or be "false" to indicate that theres no color defined
                if (Validations.isColorValid(value))
                {
                    subtitleColor = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("subtitleColorError", currentCulture));
                }   
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
                 this.ExpositionRandom.ToString() + " " +
                 this.IntervalTime.ToString() + " " +
                 this.IntervalTimeRandom.ToString() + " " +
                 wordList + " " +
                 colorList + " " +
                 this.BackgroundColor.ToUpper() + " " +
                 this.AudioCapture.ToString() + " " +
                 this.SubtitleShow.ToString() + " " +
                 this.SubtitlePlace.ToString() + " " +
                 this.SubtitleColor.ToUpper() + " " +
                 this.ExpositionType.ToLower() + " " +
                 imageList + " " +
                 this.FixPoint + " " +
                 this.FontWordLabel + " " +
                 this.ExpandImage + " " +
                 audioList + " " +
                 this.SubtitlesListFile + " " +
                 this.FixPointColor + " " +
                 this.DelayTime + " " +
                 this.RotateImage + " " +
                 this.RndSubtitlePlace + " " +
                 this.WordColor;
            return data;
        }

        public int DelayTime
        {
            get { return delayTime; }
            set
            {
                delayTime = value;
            }
        }

        public string FontWordLabel
        {
            get { return fontWordLabel; }
            set
            {
                if (Validations.isDigit(value)) { fontWordLabel = value; }
            }
        }
 

        public string SubtitlesListFile
        {
            get { return subtitlesListFile; }
            set
            {
                if (Validations.isListValid(value))
                {
                    subtitlesListFile = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("fileName", currentCulture) + value + LocRM.GetString("fileNameError", currentCulture));
                }
            }
        }

        public string ExpositionType
        {
            get { return expositionType; }
            set
            {
                if (Validations.isExpoTypeValid(value)) expositionType = value.ToLower();
                else throw new ArgumentException(LocRM.GetString("expositionTypeError", currentCulture) + " 'txt', 'img', 'imgtxt', 'txtaud' ou 'imgaud'");
            }
        }

        public int RotateImage
        {
            get { return rotateImage;  }
            set
            {
                rotateImage = value;
            }
        }

        public bool RndSubtitlePlace
        {
            get { return rndSubtitlePlace; }
            set
            {
                rndSubtitlePlace = value;
            }
        }

        public string WordColor
        {
            get { return wordColor; }
            set
            {
                if (Validations.isColorValid(value))
                {
                    wordColor = value;
                    if (value.ToLower().Equals("false"))
                    {
                        wordColor = defaultRedColor;
                    }
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("wordColorError", currentCulture));
                }
            }
        }

        // converts .prg file into a stroopprogram object
        public void readProgramFile(string filepath)
        {
            StreamReader tr;
            string line;
            string[] linesInstruction;
            List<string> config = new List<string>();


            if (!File.Exists(filepath)) { throw new FileNotFoundException(); }

            tr = new StreamReader(filepath, Encoding.Default, true);
            line = tr.ReadLine();
            line = encodeLatinText(line);
            config = line.Split().ToList();
            List<string> defaultConfig = LocRM.GetString("defaultStroopProgram", currentCulture).Split().ToList();
            tr.Close();

            needsEditionFlag = false;
            if (config.Count() < defaultConfig.Count() && config.Count() > 15)
            {
                needsEditionFlag = true;
                for (int i = config.Count(); i < defaultConfig.Count(); i++)
                {
                    config.Add(defaultConfig[i]);
                }
            }

            ProgramName = config[0];
            if (Path.GetFileNameWithoutExtension(filepath) != (this.ProgramName))
            {
                throw new Exception(LocRM.GetString("fileNameError1", currentCulture) + this.ProgramName + " != " + Path.GetFileNameWithoutExtension(filepath) + "'.prg");
            }

            NumExpositions = Int32.Parse(config[1]);
            ExpositionTime = Int32.Parse(config[2]);
            ExpositionRandom = Boolean.Parse(config[3]);
            IntervalTime = Int32.Parse(config[4]);
            IntervalTimeRandom = Boolean.Parse(config[5]);
            setWordListFile(config[6]);
            setColorListFile(config[7]);
            BackgroundColor = config[8];
            AudioCapture = Boolean.Parse(config[9]);

            // subtitle configurations
            SubtitleShow = Boolean.Parse(config[10]);
            if (SubtitleShow)
            {
                SubtitlePlace = Int32.Parse(config[11]);
                SubtitleColor = config[12];
            }
            else
            {
                SubtitlePlace = 1;
                SubtitleColor = "false";
            }

            ExpositionType = config[13];
            setImageListFile(config[14]);
            FixPoint = config[15];
            FontWordLabel = config[16];
            ExpandImage = Boolean.Parse(config[17]);
            setAudioListFile(config[18]);
            SubtitlesListFile = config[19];

            FixPointColor = config[20];
            DelayTime = Int32.Parse(config[21]);
            RotateImage = Int32.Parse(config[22]);
            RndSubtitlePlace = Boolean.Parse(config[23]);
            WordColor = config[24];

            // reads instructions if there are any
            linesInstruction = File.ReadAllLines(filepath);
            if (linesInstruction.Length > 1)
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
        
        // writes default file
        public void writeDefaultProgramFile(string filepath) // escreve 
        {
            string[] defaultInstructionText = { LocRM.GetString("defaultStroopInstruction1", currentCulture),
                                                LocRM.GetString("defaultStroopInstruction2", currentCulture),
                                                LocRM.GetString("defaultStroopInstruction3", currentCulture)};
            try
            {
                TextWriter tw = new StreamWriter(filepath);
                tw.WriteLine(LocRM.GetString("defaultStroopProgram", currentCulture));
                for(int i = 0; i < defaultInstructionText.Length; i++)
                {
                    tw.WriteLine(defaultInstructionText[i]);
                }
                tw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
        }
    }
}