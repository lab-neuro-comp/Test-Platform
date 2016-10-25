/*
 * Copyright (c) 2016 All Rights Reserved
 * Hugo Honda
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StroopTest
{
    class StroopProgram
    {
        private string defaultProgramFileText = "padrao 16 1000 true 1000 False padrao_words.lst padrao_color.lst false false false 1 false txt false false 160 false false false false 0 0 false false";
        private string defaultWordsListName = "padrao_words.lst";
        private string defaultColorsListName = "padrao_color.lst";
        private string defaultWordsListText = "amarelo azul verde vermelho";
        private string defaultColorsListText = "#F8E000 #007BB7 #7EC845 #D01C1F";
        private string defaultRedColor = "#D01C1F";
        private string headerOutputFileText = "programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor\taudio";
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private string errorExMsg = "Arquivo de Programa - parâmetro inválido.";
        private string[] defaultInstructionText = { "Serão apresentadas palavras coloridas de forma aleatória. Palavras surgirão rapidamente e em seguida desaparecerão",
                                                    "Diga a cor em que a palavra está escrita",
                                                    "A tarefa vai começar agora"};
        private bool needsEditionFlag;
        public static int instructionAwaitTime = 4000; // default await time for each frame of instruction shown before the test
        private int minRandomTime = 400; // minimum random value that a random interval time can be

        private List<string> instructionText = new List<string>();

        private DateTime initialDate;           // test execution date
        private string userName;                // tested person name
        private string programName;             // [0]   program name
        private int numExpositions;             // [1]*  number of expositions to be shown 
        private int expositionTime;             // [2]*  duration time of each exposition (millisec)
        private bool expositionRandom;          // [3]*  is exposition random
        private int intervalTime;               // [4]*  duration time for interval between expositions (millisec)
        private bool intervalTimeRandom;        // [5]*  is interval time random - rnd num between defined intervalTime and minRandomTime (bool)
        private string wordsListFile;           // [6]   words list file name (.lst)
        private string colorsListFile;          // [7]   colors list file name (.lst)
        private string backgroundColor;         // [8]   background color during exposition (hex)
        private bool audioCapture;              // [9]*  is audio capture activated
        private bool subtitleShow;              // [10]* subtitles activated
        private int subtitlePlace;              // [11]* subtitles place in screen (left, right, up and down the exposition stimulus)
        private string subtitleColor;           // [12]  subtitles color
        private string expositionType;          // [13]  exposition type
        private string imagesListFile;          // [14]  images path list file name (.lst)
        private string fixPoint;                // [15]  fixation point shown during interval time - cross / circle - false = deactivated
        private string fontWordLabel;           // [16]  wordLabel size - 160 default
        private bool expandImage;               // [17]  expands image adjusting it to the screen - if true, subtitles false
        private string audioListFile;           // [18]  audio list file name (.lst) - if it is and audio exposition type [13]
        private string subtitlesListFile;       // [19]  subtitles list file name (.lst) - if subtitles are activated [10]

        private string fixPointColor;           // [20]  cor do ponto de fixação - vermelho - se ponto de fixação != false definir cor
        private int delayTime;                  // [21]  tempo de atraso = intervalo se não for definido
        private int rotateImage;                // [22]  rotacionar imagem (90, 180, 270, 360)
        private bool rndSubtitlePlace;          // [23]  localizacão da legenda aleatória
        private string wordColor;               // [24]  cor da palavra apresentada em palavraimg


        public List<string> InstructionText
        {
            get { return instructionText; }
            set
            {
                instructionText = value;
            }
        }
        
        public string UserName
        {
            get { return userName; }
            set
            {
                if (value.All(Char.IsLetterOrDigit) && !String.IsNullOrEmpty(value)) userName = value;
                else throw new ArgumentException("Nome do usuario deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'JoaoSilva'");
            }   // user name has only alphanumeric elements, without spaces
        }

        public string ProgramName
        {
            get { return programName; }
            set
            {
                if (value.All(Char.IsLetterOrDigit) && !String.IsNullOrEmpty(value)) programName = value;
                else throw new ArgumentException("Nome do programa deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'MeuPrograma'");
            }   // program name has only alphanumeric elements, without spaces
        }

        public int NumExpositions
        {
            get { return numExpositions; }
            set
            {
                if (value > 0) numExpositions = value;
                else throw new ArgumentException(errorExMsg + "\nNumero de exposições deve ser maior que zero");
            }   // number of expositions must be greater than zero
        }

        public int ExpositionTime
        {
            get { return expositionTime; }
            set
            {
                if (value > 0)
                {
                    expositionTime = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nTempo de exposição deve ser maior que zero (em milissegundos)");
                }   // exposition time must be greater than zero
            }
        }

        public bool ExpositionRandom
        {
            get { return expositionRandom; }
            set
            {
                if (value == true || value == false)    // checks boolean
                {
                    expositionRandom = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nExposicao Randômica deve ser boleana (true or false)");
                }
            }
        }

        public int IntervalTime
        {
            get { return intervalTime; }
            set
            {
                if (value > 0)
                {
                    intervalTime = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nTempo de intervalo deve ser maior que zero (em milissegundos)");
                }   // interval time must be greater than zero
            }
        }

        public bool IntervalTimeRandom
        {
            get { return intervalTimeRandom; }
            set
            {
                if (value == true || value == false)
                {
                    intervalTimeRandom = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nTempo de intervalo randômico deve ser boleana (true or false)");
                }
            }
        }

        public string WordsListFile
        {
            get { return wordsListFile; }
            set
            {
                if(value.Length > 4)
                {
                    if (value.Substring(value.Length - 4) == ".lst" || value.ToLower() == "false")
                    {
                        wordsListFile = value;
                    }
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista deve ter terminação .lst");
                }   // list files must have (.lst) termination or be "false" to indicate that theres no list defined
            }
        }

        public string ColorsListFile
        {
            get { return colorsListFile; }
            set
            {
                if (value.Substring(value.Length - 4) == ".lst" || value.ToLower() == "false")
                {
                    colorsListFile = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo" + value + " de lista deve ter terminação .lst");
                }   // list files must have (.lst) termination or be "false" to indicate that theres no list defined
            }
        }

        public string BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (Regex.IsMatch(value, hexPattern) || value.ToLower() == "false")
                {
                    backgroundColor = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor de Fundo deve ser 'false' ou um código hexadecimal de cor");
                }   // colors must match with the hexadecimal pattern for color codes or be "false" to indicate that theres no color defined
            }
        }

        public bool AudioCapture
        {
            get { return audioCapture; }
            set
            {
                if (value == true || value == false)
                {
                    audioCapture = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCaptura de audio deve ser boleana (true or false)");
                }
            }
        }

        public bool SubtitleShow
        {
            get { return subtitleShow; }
            set
            {
                if (value == true || value == false)
                {
                    subtitleShow = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nApresentação de legenda deve ser boleana (true or false)");
                }
            }
        }

        public int SubtitlePlace
        {
            get { return subtitlePlace; }
            set
            {
                if (value > 0 && value <= 6)
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
                if (Regex.IsMatch(value, hexPattern) || value.ToLower() == "false")
                {
                    subtitleColor = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor da Legenda deve ser 'false' ou um código hexadecimal de cor");
                }   // colors must match with the hexadecimal pattern for color codes or be "false" to indicate that theres no color defined
            }
        }

        public DateTime InitialDate
        {
            get { return initialDate; }
            set { initialDate = value; }
        }

        public string ExpositionType
        {
            get { return expositionType; }
            set
            {
                if (value.ToLower() == "txt" || value.ToLower() == "img" || value.ToLower() == "imgtxt" || value.ToLower() == "txtaud" || value.ToLower() == "imgaud") expositionType = value.ToLower();
                else throw new ArgumentException("Tipo de exposição deve ser do tipo 'txt', 'img', 'imgtxt', 'txtaud' ou 'imgaud'");
            }
        }

        public string ImagesListFile
        {
            get { return imagesListFile; }
            set
            {
                if (value.Substring(value.Length - 4) == ".lst" || value.ToLower() == "false")
                {
                    imagesListFile = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista deve ter terminação .lst");
                }
            }
        }

        public string FixPoint
        {
            get { return fixPoint; }
            set
            {
                if (value == "+" || value.ToLower() == "o" || value.ToLower() == "false") fixPoint = value.ToLower();
                else throw new ArgumentException("Ponto de fixação deve ser representado por:\n'+' - ponto de fixação cruz\n'o' - ponto de fixação circulo\n'false' - se não houver ponto;");
            }
        }

        public string FontWordLabel
        {
            get { return fontWordLabel; }
            set
            {
                if (value.All(char.IsDigit)) { fontWordLabel = value; }
            }
        }

        public bool ExpandImage
        {
            get { return expandImage; }
            set
            {
                if (value == true || value == false)
                {
                    expandImage = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nExpansão de Imagem deve ser boleana (true or false)");
                }
            }
        }

        public string AudioListFile
        {
            get { return audioListFile; }
            set
            {
                if (value.Substring(value.Length - 4) == ".lst" || value.ToLower() == "false")
                {
                    audioListFile = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista deve ter terminação .lst");
                }
            }
        }

        public string HeaderOutputFile
        {
            get { return headerOutputFileText; }
        }

        public string SubtitlesListFile
        {
            get { return subtitlesListFile; }
            set
            {
                if (value.Substring(value.Length - 4) == ".lst" || value.ToLower() == "false")
                {
                    subtitlesListFile = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista deve ter terminação .lst");
                }
            }
        }

        public string FixPointColor
        {
            get { return fixPointColor; }
            set
            {
                if (Regex.IsMatch(value, hexPattern) || value.ToLower() == "false")
                {
                    if (value.ToLower() == "false") { fixPointColor = defaultRedColor; }
                    else { fixPointColor = value; }
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor do ponto de fixação deve ser 'false' ou um código hexadecimal de cor");
                }
            }
        }

        public int DelayTime
        {
            get { return delayTime; }
            set
            {
                delayTime = value;
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
                if (value == true || value == false)
                {
                    rndSubtitlePlace = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nPosição Aleátória deve ser boleana (true or false)");
                }
            }
        }

        public string WordColor
        {
            get { return wordColor; }
            set
            {
                if (Regex.IsMatch(value, hexPattern) || value.ToLower() == "false")
                {
                    wordColor = value;
                    if (value.ToLower() == "false") { wordColor = defaultRedColor; }
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor do ponto da palavra deve ser 'false' ou um código hexadecimal de cor");
                }
            }
        }

        public bool NeedsEdition
        {
            get { return needsEditionFlag; }
        }

        // decodifica texto
        static public string encodeLatinText(string text)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes;
            byte[] isoBytes;
            string encodedStr = "";

            utfBytes = utf8.GetBytes(text);
            isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            encodedStr = iso.GetString(isoBytes);

            return encodedStr;
        }

        // construtor classe StroopProgram
        public StroopProgram()
        {
            this.InitialDate = DateTime.Now; // seta Data inicial como o momento da inicialização
        }

        // lê arquivo com programa e retorna true para sucesso
        public void readProgramFile(string filepath)
        {
            StreamReader tr;
            string line;
            string[] linesInstruction;
            List<string> config = new List<string>();
            List<string> defaultConfig = new List<string>();

            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); } // confere existência do arquivo

                tr = new StreamReader(filepath, Encoding.Default, true);
                line = tr.ReadLine();
                line = encodeLatinText(line);
                config = line.Split().ToList();
                defaultConfig = defaultProgramFileText.Split().ToList();
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
                WordsListFile = config[6];
                ColorsListFile = config[7];
                BackgroundColor = config[8];
                AudioCapture = Boolean.Parse(config[9]);
                SubtitleShow = Boolean.Parse(config[10]);

                if (SubtitleShow) { SubtitlePlace = Int32.Parse(config[11]); SubtitleColor = config[12]; }
                else { SubtitlePlace = 1; SubtitleColor = "false"; }
                ExpositionType = config[13]; // aqui
                ImagesListFile = config[14];
                FixPoint = config[15];
                FontWordLabel = config[16];
                ExpandImage = Boolean.Parse(config[17]);
                AudioListFile = config[18];
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

        // escreve arquivo com lista de palavras padrão
        public void writeDefaultWordsList(string filepath)
        {
            try
            {
                TextWriter tw = new StreamWriter(filepath + defaultWordsListName);
                tw.WriteLine(defaultWordsListText);
                tw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Arquivo '" + defaultWordsListName + "' não foi escrito\n\n( " + ex.Message + " )");
            }
        }
        
        // escreve arquivo com lista de cores padrão
        public void writeDefaultColorsList(string filepath)
        {
            try
            {
                TextWriter tw = new StreamWriter(filepath + defaultColorsListName);
                tw.WriteLine(defaultColorsListText);
                tw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Arquivo '" + defaultColorsListName + "' não foi escrito\n\n( " + ex.Message + " )");
            }
        }
        
        // lê palavras do arquivo e retorna vetor
        static public string[] readListFile(string filepath)
        {
            TextReader tr;
            List<string> list;
            string[] splitedLine;

            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); } // checa se arquivo existe
                tr = new StreamReader(filepath, Encoding.Default, true);
                list = new List<string>(); // lista de palavras
                while (tr.Peek() >= 0)
                {
                    splitedLine = tr.ReadLine().Split();
                    for(int i = 0; i < splitedLine.Count(); i++) { list.Add(splitedLine[i]); } // adiciona cada palavra como novo item a uma lista
                }
                tr.Close();
                return list.ToArray(); // retorna palavras em vetor
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Arquivo lista (parâmetro): '" + Path.GetFileName(filepath) + "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + "\n\n( " + ex.Message + " )");
            }
        }

        // lê diretórios do arquivo e retorna vetor
        static public string[] readDirListFile(string filepath)
        {
            string[] imageDirs;

            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); }
                imageDirs = File.ReadAllLines(filepath);
                return imageDirs; // retorna vetor com diretórios
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Arquivo lista (parâmetro): '" + Path.GetFileName(filepath) + "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + "\n\n( " + ex.Message + " )");
            }
        }

        // lê dados do arquivo e retorna vetor
        static public string[] readDataFile(string filepath)
        {
            string[] linesList;

            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); }
                linesList = File.ReadAllLines(filepath);
                return linesList;
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Arquivo Data: '" + Path.GetFileName(filepath) + "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + "\n\n( " + ex.Message + " )");
            }
        }
        
        // escreve linha a linha no arquivo de saída
        static public void writeOutputFile(string filepath, string outContent)
        {
            try
            {
                StreamWriter sw;
                if (!File.Exists(filepath))
                {
                    sw = File.CreateText(filepath);
                    sw.WriteLine(outContent);
                }
                else
                {
                    sw = File.AppendText(filepath);
                    sw.WriteLine(outContent);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static public void writeLineOutput(StroopProgram program, string nameStimulus, string color, int counter, List<string> output, float elapsedTime, string expoType, string audioName)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
            var text = program.ProgramName + "\t" +
                       program.UserName + "\t" +
                       program.InitialDate.Day + "/" + program.InitialDate.Month + "/" + program.InitialDate.Year + "\t" +
                       DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString() + "\t" +
                       elapsedTime.ToString() + "\t" +
                       counter + "\t" +
                       expoType + "\t" +
                       program.SubtitleShow.ToString().ToLower() + "\t" +
                       program.SubtitlePlace + "\t" +
                       nameStimulus + "\t" +
                       color + "\t" +
                       audioName;
                       output.Add(text);
        }
    }
}