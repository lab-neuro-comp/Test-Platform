using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models
{
    class ReactionProgram : Program
    {
        private String defaultProgramFileText = "padraoTR 5 500 50 1000 50 false false false false 0 #D01C1F false false o false #D01C1F 160";
        private Int32 stimuluSize; // [3]
        private Int32 stimulusDistance; // [5] distance from the center of the screen to stimulus
        private Boolean isBeeping; // [9]
        private Int32 beepDuration; // [10]
        private String stimulusColor; // [11]
        private static Int32 ELEMENTS = 18; //quantity of fields used in ReactionProgram 



        public ReactionProgram(string programName, int expositionTime, int numExpositions, int stimuluSize, int intervalTime,
                                int stimulusDistance, bool isBeeping, int beepDuration, string stimulusColor, int delayTime,
                                string fixPoint, string backgroundColor, string fixPointColor)
        {
            // Program properties
            this.programName = programName;
            this.expositionTime = expositionTime;
            this.numExpositions = numExpositions;
            this.intervalTime = intervalTime;
            this.delayTime = delayTime;
            this.fixPoint = fixPoint;
            this.backgroundColor = backgroundColor;
            this.fixPointColor = fixPointColor;
            

            // ReactionProgram properties
            this.stimuluSize = stimuluSize;
            this.stimulusDistance = stimulusDistance;
            this.isBeeping  = isBeeping;
            this.beepDuration = beepDuration;
            this.stimulusColor = stimulusColor;

            //default configurations for first version of ReactionProgram
            this.audioListFile = "false";
            this.colorsListFile = "false";
            this.wordsListFile = "false";
            this.imagesListFile = "false";
            this.expositionType = "standard";

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

        public string data()
        {
            string data = this.ProgramName + " " +
                 this.NumExpositions.ToString() + " " +
                 this.ExpositionTime.ToString() + " " +
                 this.StimuluSize.ToString() + " " +
                 this.IntervalTime.ToString() + " " +
                 this.StimulusDistance.ToString() + " " +
                 this.WordsListFile + " " +
                 this.ColorsListFile + " " +
                 this.BackgroundColor.ToUpper() + " " +
                 this.BeepDuration.ToString() + " " +
                 this.StimulusColor.ToString() + " " +
                 this.ExpositionType.ToLower() + " " +
                 this.ImagesListFile + " " +
                 this.FixPoint + " " +
                 this.AudioListFile + " " +
                 this.FixPointColor + " " +
                 this.DelayTime;
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

                    List<string> defaultConfig = defaultProgramFileText.Split().ToList();
                    for (int i = config.Count(); i < ELEMENTS; i++)
                    {
                        config.Add(defaultConfig[i]);
                    }
                }

                ProgramName = config[0];
                if (Path.GetFileNameWithoutExtension(filepath) != (this.ProgramName)) { throw new Exception("Parâmetro escrito no arquivo como: '" + this.ProgramName + "'\ndeveria ser igual ao nome no arquivo: '" + Path.GetFileNameWithoutExtension(filepath) + "'.prg"); }
                NumExpositions = int.Parse(config[1]);
                ExpositionTime = int.Parse(config[2]);
                StimuluSize = int.Parse(config[3]);
                IntervalTime = int.Parse(config[4]);
                StimulusDistance = int.Parse(config[5]);
                WordsListFile = config[6];
                ColorsListFile = config[7];
                BackgroundColor = config[8];
                IsBeeping = Boolean.Parse(config[9]);
                BeepDuration = int.Parse(config[10]);
                StimulusColor = config[11];
                ExpositionType = config[12]; 
                ImagesListFile = config[13];
                FixPoint = config[14];
                AudioListFile = config[15];
                FixPointColor = config[16];
                DelayTime = Int32.Parse(config[17]);
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
            StreamWriter writer = new StreamWriter(path + "prg/" + ProgramName + ".tr");
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

        public static void writeLineOutput(ReactionProgram program, string nameStimulus, string color, int counter,
                                           List<string> output, float elapsedTime, string expoType, string audioName,
                                           string hour, string minute, string second)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
           /* var text = program.ProgramName + "\t" +
                       program.UserName + "\t" +
                       program.InitialDate.Day + "/" + program.InitialDate.Month + "/" + program.InitialDate.Year + "\t" +
                       hour + ":" + minute + ":" + second + ":" + DateTime.Now.Millisecond.ToString() + "\t" +
                       elapsedTime.ToString() + "\t" +
                       counter + "\t" +
                       expoType + "\t" +
                       program.SubtitleShow.ToString().ToLower() + "\t" +
                       program.SubtitlePlace + "\t" +
                       nameStimulus + "\t" +
                       color + "\t" +
                       audioName;
            output.Add(text); 
            */
        }

    }
}
