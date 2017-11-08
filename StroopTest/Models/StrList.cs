using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using TestPlatform.Views;

namespace TestPlatform.Models
{
    class StrList
    {
        private List<string> listContent = new List<string>();
        private String listName;
        private String type;
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


        public bool saveDirectories()
        {
            StreamWriter wr = new StreamWriter(getFilePath());
            foreach (string item in listContent)
            {
                wr.WriteLine(item);
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

        private static void writesDefaultList(string filepath, string listNameTermination, string listContent)
        {
            // properties used to localize strings during runtime
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;
            try
            {
                string defaultListName = LocRM.GetString("default", currentCulture) + listNameTermination;
                TextWriter tw = new StreamWriter(filepath + defaultListName);
                tw.WriteLine(LocRM.GetString(listContent, currentCulture));
                tw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(LocRM.GetString("file", currentCulture) + LocRM.GetString("default", currentCulture) + listNameTermination + LocRM.GetString("notCreated", currentCulture) + ex.Message);
            }
        }

        // writes default word list with yellow blue green and red
        public static void writeDefaultWordsList(string filepath)
        {
            writesDefaultList(filepath, "_words.lst", "defaultWordList");
        }

        // writes default color list
        public static void writeDefaultColorsList(string filepath)
        {
            writesDefaultList(filepath, "_color.lst", "defaultColorList");
        }

        // reads each word in file and returns a vector of them
        static internal string[] readListFile(string filepath)
        {           
            if (File.Exists(filepath))
            {
                TextReader tr = new StreamReader(filepath, Encoding.Default, true);
                List<string>  list = new List<string>();
                while (tr.Peek() >= 0)
                {
                    string[] splitedLine = tr.ReadLine().Split();
                    for (int i = 0; i < splitedLine.Count(); i++) //adding elements to list one by one
                    {
                        list.Add(splitedLine[i]);
                    }
                }
                tr.Close();
                return list.ToArray(); // returning list in array                
            }
            else
            {
                // properties used to localize strings during runtime
                ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
                CultureInfo currentCulture = CultureInfo.CurrentUICulture;
                throw new FileNotFoundException(LocRM.GetString("file", currentCulture) + Path.GetFileName(filepath) +
                    LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(filepath));
            }           
        }



    }
}
