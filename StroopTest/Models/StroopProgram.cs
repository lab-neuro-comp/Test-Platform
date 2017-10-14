/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestPlatform.Models;

namespace TestPlatform.Models
{
    class StroopProgram : Program
    {
        private String defaultProgramFileText = "padrao 16 1000 true 1000 False padrao_words.lst padrao_color.lst false true false 1 false txt false false 160 false false false false 0 0 false false";
        private String[] defaultInstructionText = { "Serão apresentadas palavras coloridas de forma aleatória. Palavras surgirão rapidamente e em seguida desaparecerão",
                                                    "Diga a cor em que a palavra está escrita",
                                                    "A tarefa vai começar agora"};
        private Boolean audioCapture;              // [9]*  is audio capture activated
        private Boolean subtitleShow;              // [10]* subtitles activated
        private Int32 subtitlePlace;              // [11]* subtitles place in screen (left, right, up and down the exposition stimulus)
        private String subtitleColor;           // [12]  subtitles color
        private String fontWordLabel;           // [16]  wordLabel size - 160 default
        private Boolean expandImage;               // [17]  expands image adjusting it to the screen - if true, subtitles false
        private String subtitlesListFile;       // [19]  subtitles list file name (.lst) - if subtitles are activated [10]

        private Int32 rotateImage;                // [22]  rotacionar imagem (90, 180, 270, 360)
        private Boolean rndSubtitlePlace;          // [23]  localizacão da legenda aleatória
        private String wordColor;               // [24]  cor da palavra apresentada em palavraimg
        private Int32 delayTime;

        public StroopProgram()
        {
            new Program();
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
                    throw new ArgumentException(errorExMsg + "\nPosição da legenda " + value + " deve ser um número de 1 a 5");
                }   // each number indicates a position
            }
        }

        public string SubtitleColor
        {
            get { return subtitleColor; }
            set
            {
                if (Validations.isColorValid(value))
                {
                    subtitleColor = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor da Legenda deve ser 'false' ou um código hexadecimal de cor");
                }   // colors must match with the hexadecimal pattern for color codes or be "false" to indicate that theres no color defined
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

        public bool ExpandImage
        {
            get { return expandImage; }
            set
            {
                 expandImage = value;
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
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista deve ter terminação .lst");
                }
            }
        }

        public string ExpositionType
        {
            get { return expositionType; }
            set
            {
                if (Validations.isExpoTypeValid(value)) expositionType = value.ToLower();
                else throw new ArgumentException("Tipo de exposição deve ser do tipo 'txt', 'img', 'imgtxt', 'txtaud' ou 'imgaud'");
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
                    if (value.ToLower().Equals("false")) { wordColor = defaultRedColor; }
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor do ponto da palavra deve ser 'false' ou um código hexadecimal de cor");
                }
            }
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
                List<string> defaultConfig = defaultProgramFileText.Split().ToList();
                tr.Close();

                Console.WriteLine(config[0]);

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
                if (Path.GetFileNameWithoutExtension(filepath) != (this.ProgramName)) { throw new Exception("Parâmetro escrito no arquivo como: '" + this.ProgramName + "'\ndeveria ser igual ao nome no arquivo: '" + Path.GetFileNameWithoutExtension(filepath) + "'.prg"); }
                NumExpositions = Int32.Parse(config[1]);
                ExpositionTime = Int32.Parse(config[2]); 
                ExpositionRandom = Boolean.Parse(config[3]);
                IntervalTime = Int32.Parse(config[4]);
                IntervalTimeRandom = Boolean.Parse(config[5]);
                setWordListFile(config[6]);
                setColorListFile(config[7]);
                BackgroundColor = config[8];
                AudioCapture = Boolean.Parse(config[9]);
                SubtitleShow = Boolean.Parse(config[10]);

                if (SubtitleShow) { SubtitlePlace = Int32.Parse(config[11]); SubtitleColor = config[12]; }
                else { SubtitlePlace = 1; SubtitleColor = "false"; }
                ExpositionType = config[13]; // aqui
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
        
        // escreve arquivo com programa padrão
        public void writeDefaultProgramFile(string filepath) // escreve 
        {
            try
            {
                TextWriter tw = new StreamWriter(filepath);
                tw.WriteLine(defaultProgramFileText);
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