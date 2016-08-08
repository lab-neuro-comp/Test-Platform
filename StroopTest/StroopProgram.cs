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
        private string defaultProgramFileText = "padrao 16 1000 true 1000 False padrao_Words.lst padrao_Colors.lst false false false 0 false txt false false 160 false false false";
        private string defaultWordsListName = "padrao_Words.lst";
        private string defaultWordsListText = "amarelo azul verde vermelho";
        private string defaultColorsListName = "padrao_Colors.lst";
        private string defaultColorsListText = "#F8E000 #007BB7 #7EC845 #D01C1F";
        private string headerOutputFileText = "programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor";
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private string[] defaultInstructionText = { "Serão apresentadas palavras coloridas de forma aleatória. Palavras surgirão rapidamente e em seguida desaparecerão",
                                                    "Diga a cor em que a palavra está escrita",
                                                    "A tarefa vai começar agora"};

        public static int instructionAwaitTime = 4000;

        private List<string> instructionText = new List<string>();

        private string userName;                // nome do usuário do programa
        private string programName;             // [0]   nome do programa
        private int numExpositions;             // [1]*  numero de exposicoes 
        private int expositionTime;             // [2]*  tempo de exposicao (millisec)
        private bool expositionRandom;          // [3]*  exposicao randomica (bool)
        private int intervalTime;               // [4]*  tempo de intervalo (millisec)
        private bool intervalTimeRandom;        // [5]*  tempo de intervalo randomico (bool)
        private string wordsListFile;           // [6]   lista de palavras
        private string colorsListFile;          // [7]   lista de cores
        private string backgroundColor;         // [8]   cor de fundo da tela
        private bool audioCapture;              // [9]*  captura de audio (bool)
        private bool subtitleShow;              // [10]* com legenda
        private int subtitlePlace;              // [11]* localizacao da legenda
        private string subtitleColor;           // [12]  cor da legenda
        private DateTime initialDate;           //       data inicial
        private string expositionType;          // [13]  tipo de exposição txt e/ou img
        private string imagesListFile;          // [14]  lista com caminhos de imagens
        private string fixPoint;                // [15]  ponto de fixação - cruz / ponto / false
        private string fontWordLabel;           // [16]  tamanho da palavra
        private bool expandImage;               // [17]  expande imagem ajustando à tela
        private string audioListFile = "false";          // [18]  lista com caminhos dos áudios
        private string subtitlesListFile = "false";       // [19]  lista de legendas
        private string fixPointColor = "#D01C1F";

        // Definição gets 
        // Definição sets (e suas restrições)

        // Arrumar argument execptions para uma exeção diferente no caso que não seja nome do programa ou do usuario
        // assim não vai dar bug de fechar programa na proxima fase (para teste -> entrar com "jabuti" como nome do programa no arquivo de entrada)


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
            }       
        }

        public string ProgramName
        {
            get { return programName; }
            set
            {
                if (value.All(Char.IsLetterOrDigit) && !String.IsNullOrEmpty(value)) programName = value;
                else throw new ArgumentException("Nome do programa deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'MeuPrograma'");
            }
        }

        public int NumExpositions
        {
            get { return numExpositions; }
            set
            {
                if (value > 0) numExpositions = value;
                else throw new ArgumentException("Erro no Arquivo com Programa:\nNumero de exposições deve ser maior que zero");
            }
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nTempo de exposição deve ser maior que zero (em milissegundos)");
                }
            }
        }

        public bool ExpositionRandom
        {
            get { return expositionRandom; }
            set
            {
                if (value == true || value == false)
                {
                    expositionRandom = value;
                }
                else
                {
                    throw new ArgumentException("Erro no Arquivo com Programa:\nExposicao Randômica deve ser boleana (true or false)");
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nTempo de intervalo deve ser maior que zero (em milissegundos)");
                }
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nTempo de intervalo randômico deve ser boleana (true or false)");
                }
            }
        }

        public string WordsListFile
        {
            get { return wordsListFile; }
            set
            {
                if (value.Substring(value.Length - 4) == ".lst" || value.ToLower() == "false")
                {
                    wordsListFile = value;
                }
                else
                {
                    throw new ArgumentException("Erro no Arquivo com Programa:\nNome do arquivo " + value + " de lista deve ter terminação .lst");
                }
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nNome do arquivo" + value + " de lista deve ter terminação .lst");
                }
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nCor de Fundo deve ser 'false' ou um código hexadecimal de cor");
                }
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nCaptura de audio deve ser boleana (true or false)");
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nApresentação de legenda deve ser boleana (true or false)");
                }
            }
        }

        public int SubtitlePlace
        {
            get { return subtitlePlace; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    subtitlePlace = value;
                }
                else
                {
                    throw new ArgumentException("Erro no Arquivo com Programa:\nPosição da legenda deve ser maior um número entre 0 e 5");
                }
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nCor da Legenda deve ser 'false' ou um código hexadecimal de cor");
                }
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
                if (value.ToLower() == "txt" || value.ToLower() == "img" || value.ToLower() == "imgtxt") expositionType = value.ToLower();
                else throw new ArgumentException("Nome do programa deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'MeuPrograma'");
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nNome do arquivo " + value + " de lista deve ter terminação .lst");
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nExpansão de Imagem deve ser boleana (true or false)");
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nNome do arquivo " + value + " de lista deve ter terminação .lst");
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
                    throw new ArgumentException("Erro no Arquivo com Programa:\nNome do arquivo " + value + " de lista deve ter terminação .lst");
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
                    fixPointColor = value;
                }
                else
                {
                    throw new ArgumentException("Erro no Arquivo com Programa:\nCor do ponto de fixação deve ser 'false' ou um código hexadecimal de cor");
                }
            }
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
            string[] linesInstruction, config;

            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); } // confere existência do arquivo

                tr = new StreamReader(filepath, Encoding.Default, true);
                line = tr.ReadLine();
                line = encodeLatinText(line);
                config = line.Split();
                tr.Close();
                
                if(config.Length != 20)
                    throw new FormatException("Arquivo programa deve ter 20 parâmetros\nexemplo - programa padrão:\n" + defaultProgramFileText);

                // atribuição de valores no arquivos às variáveis do programa:
                // nomePrograma /NumExposições /TempoExposição /ExpAleatória /TempoIntervalo /TempoIntervAleatorio /ListaPalavras /ListaCores /CorFundo /CaptAudio /mostrarLegenda /lugarLegenda /corLegenda /tipoExposicao /listaImg / PontoFixacao
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
                else { SubtitlePlace = 0; SubtitleColor = "false"; }
                ExpositionType = config[13];
                ImagesListFile = config[14];
                FixPoint = config[15];
                FontWordLabel = config[16];
                ExpandImage = Boolean.Parse(config[17]);
                AudioListFile = config[18];
                SubtitlesListFile = config[19];
                
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
        public string[] readListFile(string filepath)
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
                TextWriter tw = new StreamWriter(filepath);
                tw.WriteLine(outContent);
                tw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static public void writeLineOutput(StroopProgram program, string nameStimulus, string color, int counter, List<string> output, float elapsedTime)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
            var text = program.ProgramName + "\t" +
                       program.UserName + "\t" +
                       program.InitialDate.Day + "/" + program.InitialDate.Month + "/" + program.InitialDate.Year + "\t" +
                       DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString() + "\t" +
                       elapsedTime.ToString() + "\t" +
                       counter + "\t" +
                       program.ExpositionType + "\t" +
                       program.SubtitleShow.ToString().ToLower() + "\t" +
                       program.SubtitlePlace + "\t" +
                       nameStimulus + "\t" +
                       color;
            output.Add(text);
        }
    }

}