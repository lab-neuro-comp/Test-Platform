/*
 * Copyright (c) 2015 All Rights Reserved
 * Hugo Honda Ferreira
 * October 2015
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace StroopTest
{
    class StroopProgram
    {
        private string defaultProgramFileText = "padrao 16 2000 true 1800 false words.lst colors.lst false true false 0 false txt false false";
        private string defaultWordsListName = "words.lst";
        private string defaultWordsListText = "amarelo azul verde vermelho";
        private string defaultColorsListName = "colors.lst";
        private string defaultColorsListText = "#F8E000 #007BB7 #7EC845 #D01C1F";
        private string headerOutputFileText = "programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor";
        private string hexPattern = "^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$";
        private string[] defaultInstructionText = { "Nesta tarefa surgirão palavras, cada uma colorida de forma aleatória; Diga a cor em que a palavra está escrita; Cada palavra surgirá por um certo tempo e logo após ela desaparecerá",
                                                    "A tarefa vai começar agora"};

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

        // construtor classe StroopProgram
        public StroopProgram()
        {
            this.InitialDate = DateTime.Now; // seta Data inicial como o momento da inicialização
        }

        // lê arquivo com programa e retorna true para sucesso
        public void readProgramFile(string filepath)
        {
            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); } // confere existência do arquivo

                TextReader tr = new StreamReader(filepath);
                string line = tr.ReadLine();
                string[] config = line.Split();
                tr.Close();

                if(config.Length != 16)
                    throw new FormatException("Arquivo programa deve ter 15 parâmetros\nexemplo - programa padrão:\n" + defaultProgramFileText);

                // atribuição de valores no arquivos às variáveis do programa:
                // nomePrograma /NumExposições /TempoExposição /ExpAleatória /TempoIntervalo /TempoIntervAleatorio /ListaPalavras /ListaCores /CorFundo /CaptAudio /mostrarLegenda /lugarLegenda /corLegenda /tipoExposicao /listaImg / PontoFixacao
                this.ProgramName = config[0];
                if (Path.GetFileNameWithoutExtension(filepath) != (this.ProgramName)) { throw new Exception("Parâmetro escrito no arquivo como: '" + this.ProgramName + "'\ndeveria ser igual ao nome no arquivo: '" + Path.GetFileNameWithoutExtension(filepath) + "'.prg"); }
                this.NumExpositions = Int32.Parse(config[1]);
                this.ExpositionTime = Int32.Parse(config[2]); 
                this.ExpositionRandom = Boolean.Parse(config[3]);
                this.IntervalTime = Int32.Parse(config[4]);
                this.IntervalTimeRandom = Boolean.Parse(config[5]);
                this.WordsListFile = config[6];
                this.ColorsListFile = config[7];
                this.BackgroundColor = config[8];
                this.AudioCapture = Boolean.Parse(config[9]);
                this.SubtitleShow = Boolean.Parse(config[10]);
                
                if (this.SubtitleShow)
                {
                    this.SubtitlePlace = Int32.Parse(config[11]);
                    this.SubtitleColor = config[12];
                }
                else // caso legenda esteja desativada, seta configurações padrao
                {
                    this.SubtitlePlace = 0;
                    this.SubtitleColor = "false";
                }

                this.ExpositionType = config[13];

                this.ImagesListFile = config[14];

                this.fixPoint = config[15];

                string[] linesInstruction = File.ReadAllLines(filepath);               
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
        
        // lê arquivo com lista e retorna esta lista
        public string[] readListFile(string filepath)
        {
            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); }
                TextReader tr = new StreamReader(filepath);
                List<string> wordsList = new List<string>();
                string line;
                string[] splitLine;

                while (tr.Peek() >= 0)
                {
                    line = tr.ReadLine();
                    splitLine = line.Split();
                    for(int i = 0; i < splitLine.Count(); i++)
                    {
                        wordsList.Add(splitLine[i]);
                    }
                }
                tr.Close();
                return wordsList.ToArray();
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Arquivo lista (parâmetro): '" + Path.GetFileName(filepath) + "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + "\n\n( " + ex.Message + " )");
            }
        }

        public string[] readImgListFile(string filepath)
        {
            try
            {
                if (!File.Exists(filepath)) { throw new FileNotFoundException(); }

                string[] imageDirs = File.ReadAllLines(filepath);
                Console.WriteLine(imageDirs);

                return imageDirs;
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Arquivo lista (parâmetro): '" + Path.GetFileName(filepath) + "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + "\n\n( " + ex.Message + " )");
            }
        }

        // escreve cabeçalho no arquivo de saída
        public void writeHeaderOutputFile(string filepath)
        {
            try
            {
                TextWriter tw = new StreamWriter(filepath);
                tw.WriteLine(headerOutputFileText);
                tw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
        }

        // escreve linha a linha no arquivo de saída
        public void writeAppendOutputFile(string filepath, string text)
        {
            try
            {
                File.AppendAllText(filepath, text + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
        }
    }
}