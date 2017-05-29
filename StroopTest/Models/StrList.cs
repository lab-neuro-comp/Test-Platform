using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestPlatform.Models
{
    class StrList
    {
        private List<string> listContent = new List<string>();
        private String listName;
        private static String defaultWordsListName = "padrao_words.lst";
        private static String defaultWordsListText = "amarelo azul verde vermelho";
        private static String defaultColorsListName = "padrao_color.lst";
        private static String defaultColorsListText = "#F8E000 #007BB7 #7EC845 #D01C1F";

        public StrList(List<string> list, string name)
        {
            this.listContent = list;
            this.listName = name;
        }


        public List<string> ListContent
        {
            get { return listContent; }
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
                listName = value;
            }
        }
 
        public bool save(string filePath)
        {
            StreamWriter wr = new StreamWriter(filePath);
            wr.Write(listContent[0]);
            foreach (string item in listContent.Skip(0))
            {
                wr.Write("\t" + item);
            }
            wr.Close();
            return true;
        }

        public bool exists(string path)
        {
            if (File.Exists(path))
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

        public StrList readListIntoStrList(string filepath, string listName)
        {
            return new StrList(new List<string>(readListFile(filepath)), listName);
        }

        // lê palavras do arquivo e retorna vetor
        static internal string[] readListFile(string filepath)
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
                    for (int i = 0; i < splitedLine.Count(); i++) { list.Add(splitedLine[i]); } // adiciona cada palavra como novo item a uma lista
                }
                tr.Close();
                return list.ToArray(); // retorna palavras em vetor
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Arquivo lista (parâmetro): '" + Path.GetFileName(filepath) + "'\nnão foi encontrado no local:\n" + Path.GetDirectoryName(filepath) + "\n\n( " + ex.Message + " )");
            }
        }
    }
}
