using System;
using System.Collections.Generic;
using StroopTest.Models;
using System.IO;
using System.Text;

namespace TestPlatform.Models
{
    class Program
    {
        protected String headerOutputFileText = "programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor\taudio";
        protected String errorExMsg = "Arquivo de Programa - parâmetro inválido.";
        protected String defaultRedColor = "#D01C1F";
        public static Int32 instructionAwaitTime = 4000; // default await time for each frame of instruction shown before the test
        protected Boolean needsEditionFlag;

        protected List<string> instructionText = new List<string>();
        protected DateTime initialDate;           // test execution date
        protected String participantName;                // tested person name
        protected String programName;             // [0]   program name
        protected Int32 numExpositions;             // [1]*  number of expositions to be shown 
        protected Int32 expositionTime;             // [2]*  duration time of each exposition (millisec)
        protected Int32 intervalTime;               // [4]*  duration time for interval between expositions (millisec)
        protected String wordsListFile;           // [6]   words list file name (.lst)
        protected String colorsListFile;          // [7]   colors list file name (.lst)
        protected String backgroundColor;         // [8]   background color during exposition (hex)
        protected String expositionType;          // [13]  exposition type
        protected String imagesListFile;          // [14]  images path list file name (.lst)
        protected String fixPoint;                // [15]  fixation point shown during interval time - cross / circle - false = deactivated
        protected String audioListFile;           // [18]  audio list file name (.lst) - if it is and audio exposition type [13]
        protected String fixPointColor;           // [20]  cor do ponto de fixação - vermelho - se ponto de fixação != false definir cor
        protected Boolean intervalTimeRandom;        // [5]*  is interval time random - rnd num between defined intervalTime and minRandomTime (bool)



        public Program()
        {
            this.InitialDate = DateTime.Now; // seta Data inicial como o momento da inicialização
        }

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
            get { return participantName; }
            set
            {
                if (!Validations.isEmpty(value) && Validations.isAlphanumeric(value)) participantName = value;
                else throw new ArgumentException("Nome do usuario deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'JoaoSilva'");
            }   // user name has only alphanumeric elements, without spaces
        }

        public string ProgramName
        {
            get { return programName; }
            set
            {
                if (Validations.isAlphanumeric(value))
                {
                    programName = value;
                }
                else
                {
                    throw new ArgumentException("Nome do programa deve ser composto apenas de caracteres alphanumericos " +
                                                "e sem espaços;\nExemplo: 'MeuPrograma'");
                }
            }
        }

        public int NumExpositions
        {
            get { return numExpositions; }
            set
            {
                if (Validations.isNumExpositionsValid(value)) numExpositions = value;
                else throw new ArgumentException(errorExMsg + "\nNumero de exposições deve ser maior que zero");
            }   // number of expositions must be greater than zero
        }

        public int ExpositionTime
        {
            get { return expositionTime; }
            set
            {
                if (Validations.isExpositionTimeValid(value))
                {
                    expositionTime = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nTempo de exposição deve ser maior que zero (em milissegundos)");
                }   // exposition time must be greater than zero
            }
        }

        public int IntervalTime
        {
            get { return intervalTime; }
            set
            {
                if (Validations.isIntervalTimeValid(value))
                {
                    intervalTime = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nTempo de intervalo deve ser maior que zero (em milissegundos)");
                }   // interval time must be greater than zero
            }
        }

        public string WordsListFile
        {
            get { return wordsListFile; }
            set
            {
                if (value.Length > 4)
                {
                    if (Validations.isListValid(value))
                    {
                        wordsListFile = value;
                    }
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista de palavras deve ter terminação .lst");
                }   // list files must have (.lst) termination or be "false" to indicate that theres no list defined
            }
        }

        public string ColorsListFile
        {
            get { return colorsListFile; }
            set
            {
                if (Validations.isListValid(value))
                {
                    colorsListFile = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo" + value + " de lista de cores deve ter terminação .lst");
                }   // list files must have (.lst) termination or be "false" to indicate that theres no list defined
            }
        }

        public string BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (Validations.isColorValid(value))
                {
                    backgroundColor = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor de Fundo deve ser 'false' ou um código hexadecimal de cor");
                }   // colors must match with the hexadecimal pattern for color codes or be "false" to indicate that theres no color defined
            }
        }

        public DateTime InitialDate
        {
            get { return initialDate; }
            set { initialDate = value; }
        }

        public string ImagesListFile
        {
            get { return imagesListFile; }
            set
            {
                if (Validations.isListValid(value))
                {
                    imagesListFile = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista de imagens deve ter terminação .lst");
                }
            }
        }

        public string FixPoint
        {
            get { return fixPoint; }
            set
            {
                if (Validations.isFixPointValid(value)) fixPoint = value.ToLower();
                else throw new ArgumentException("Ponto de fixação deve ser representado por:\n'+' - ponto de fixação cruz\n'o' - ponto de fixação circulo\n'false' - se não houver ponto;");
            }
        }

        public string AudioListFile
        {
            get { return audioListFile; }
            set
            {
                if (Validations.isListValid(value))
                {
                    audioListFile = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nNome do arquivo " + value + " de lista de aúdios deve ter terminação .lst");
                }
            }
        }

        public string HeaderOutputFile
        {
            get { return headerOutputFileText; }
        }

        public string FixPointColor
        {
            get { return fixPointColor; }
            set
            {
                if (Validations.isColorValid(value))
                {
                    fixPointColor = value;
                    if (fixPointColor.ToLower().Equals("false")) { fixPointColor = defaultRedColor; }
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nCor do ponto de fixação deve ser 'false' ou um código hexadecimal de cor");
                }
            }
        }

        public bool IntervalTimeRandom
        {
            get { return intervalTimeRandom; }
            set
            {
                if (Validations.isBoolean(value))
                {
                    intervalTimeRandom = value;
                }
                else
                {
                    throw new ArgumentException(errorExMsg + "\nTempo de intervalo randômico deve ser boleana (true or false)");
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
                throw new Exception("Arquivo Data: '" + Path.GetFileName(filepath) + 
                                    "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + 
                                    "\n\n( " + ex.Message + " )");
            }
        }

        public bool Exists(string path)
        {
            if (File.Exists(path + "/prg/" + ProgramName + ".prg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Ready(string path)
        {
            if (!needsEditionFlag && Exists(path))
            {
                return true;
            }
            else
            {
                return false;
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



    }
}
