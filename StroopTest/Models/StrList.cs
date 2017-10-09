using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestPlatform.Views;

namespace TestPlatform.Models
{
    class StrList
    {
        private List<string> listContent = new List<string>();
        private String listName;
        private String type;
        private static String defaultWordsListName = "padrao";
        private static String defaultWordsListText = "amarelo azul verde vermelho";
        private static String defaultColorsListName = "padrao";
        private static String defaultColorsListText = "#F8E000 #007BB7 #7EC845 #D01C1F";
        private static String[] types = { "_image", "_audio", "_words", "_color" };

      public StrList(List<string> list, string name, string type)
      {
            ListContent = list;
            ListName = name;
            Type = type;
      }

        // constructor method for reading an existing list file and transforming it in an object
        public StrList(string name, int type)
        {
            string listname = name;
            if (name.Contains("_"))
            {
               listname = name.Split('_')[0];
            }
            ListName = listname;
            Type = types[type];

            string file = Global.testFilesPath + Global.listFolderName + "/" + listname + types[type] + ".lst";


            if (File.Exists(file))
            {
                TextReader tr = new StreamReader(file, Encoding.Default, true);
                List<string> list = new List<string>(); // lista de palavras
                while (tr.Peek() >= 0)
                {
                    if(type > 1)
                    {
                        string[] splitedLine = tr.ReadLine().Split();
                        for (int i = 0; i < splitedLine.Count(); i++) //adding elements to list one by one
                        {
                            list.Add(splitedLine[i]);
                        }
                    }
                    else
                    {
                        list.Add(tr.ReadLine());
                    }

                }
                tr.Close();
                ListContent = list; // retorning list in array                
            }
            else
            {
                throw new FileNotFoundException("Não foi possível abrir a lista: '" + listName +
                    "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(file));
            }
        }


        public List<string> ListContent
        {
            get
            {
                return listContent;
            }
            set
            {
                listContent = value;
            }
        }

        public string ListName
        {
            get { return listName; }
            set
            {
                if (!Validations.isEmpty(value))
                {
                    listName = value;
                }
                else
                {
                    throw new ArgumentException("\nO nome da lista não pode ser nulo.");
                }
                
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                if (value.Equals(types[0]) || value.Equals(types[1]) || value.Equals(types[2]) || value.Equals(types[3]))
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException("\nO tipo de lista é inválido, a lista deve ser de aúdio," + 
                        "imagens, palavras ou cores.");
                }
            }
        }

        private string getFilePath()
        {
            return Global.testFilesPath + Global.listFolderName + ListName + Type + ".lst";
        }

        public bool save()
        {
            StreamWriter wr = new StreamWriter(getFilePath());
            wr.Write(listContent[0]);
            foreach (string item in listContent.Skip(0))
            {
                wr.Write("\t" + item);
            }
            wr.Close();
            return true;
        }

        public bool exists()
        {
            if (File.Exists(getFilePath()))
                return true;
            else
                return false;
        }


        // escreve arquivo com lista de palavras padrão
        public static void writeDefaultWordsList(string filepath)
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
        public static void writeDefaultColorsList(string filepath)
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
        static internal string[] readListFile(string filepath)
        {           
            if (File.Exists(filepath))
            {
                TextReader tr = new StreamReader(filepath, Encoding.Default, true);
                List<string>  list = new List<string>(); // lista de palavras
                while (tr.Peek() >= 0)
                {
                    string[] splitedLine = tr.ReadLine().Split();
                    for (int i = 0; i < splitedLine.Count(); i++) //adding elements to list one by one
                    {
                        list.Add(splitedLine[i]);
                    }
                }
                tr.Close();
                return list.ToArray(); // retorning list in array                
            }
            else
            {
                throw new FileNotFoundException("Arquivo lista (parâmetro): '" + Path.GetFileName(filepath) + 
                    "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath));
            }           
        }



    }
}
