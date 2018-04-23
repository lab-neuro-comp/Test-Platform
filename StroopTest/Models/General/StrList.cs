using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using TestPlatform.Views;

namespace TestPlatform.Models
{
    class StrList
    {
        private List<string> listContent = new List<string>();
        private String listName;
        private String type;
        private static String[] types = { "_image", "_audio", "_words", "_color" };
        public readonly static int IMAGE = 0, AUDIO = 1, WORD = 2, COLOR = 3;

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

            // adding content of word and color lists
            if (type == 2 || type == 3)
            {
                string file = Global.testFilesPath + Global.listFolderName + "/" + listname + types[type] + ".lst";
                if (File.Exists(file))
                {
                    TextReader tr = new StreamReader(file, Encoding.Default, true);
                    List<string> list = new List<string>(); // lista de palavras
                    while (tr.Peek() >= 0)
                    {
                        string[] splitedLine = tr.ReadLine().Split();
                        for (int i = 0; i < splitedLine.Count(); i++) //adding elements to list one by one
                        {
                            list.Add(splitedLine[i]);
                        }
                    }
                    tr.Close();
                    ListContent = list; // returning list in array                
                }
                else
                {
                    throw new FileNotFoundException(listName + " (" + types[type].Substring(1, types[type].Length-1) + ")");
                }
            }
            // adding content of image and audio list
            else if (type == 0 || type == 1)
            {
                string[] content;
                string directoryList = Global.testFilesPath + Global.listFolderName + "/" + listname + types[type];
                try
                {
                    content = Directory.GetFiles(directoryList);
                }
                catch (DirectoryNotFoundException)
                {
                    throw new FileNotFoundException(listName + " (" + types[type].Substring(1, types[type].Length - 1) + ")");
                }
                ListContent = content.ToList();
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
            foreach (string item in listContent.Skip(1))
            {
                wr.Write("\t" + item);
            }
            wr.Close();
            return true;
        }

        public bool saveContent(bool shouldSave)
        {
            if (shouldSave && (Type.Equals(types[0]) || Type.Equals(types[1])))
            {
                string listDestination = Global.testFilesPath + Global.listFolderName + ListName + Type + "/";
                Directory.CreateDirectory(listDestination);
                int i = 0;
                foreach (string content in listContent)
                {
                    try
                    {
                        File.Copy(content, listDestination + i + Path.GetFileName(content), true);

                    }
                    catch
                    {
                        ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
                        CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
                        MessageBox.Show(LocRM.GetString("fileNotFound", currentCulture) + "\n" + content);
                    }
                    i++;
                }
                return true;
            }
            else
            {
                return false;
            }
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

        // converts image and audio list files *.lst to new implementation that imports files to a folder
        public static void convertFileLists()
        {
            string listFolder = Global.testFilesPath + Global.listFolderName;
            string[] audioFiles = Directory.GetFiles(listFolder, ("*_audio.lst"), SearchOption.AllDirectories);
            string[] imageFiles = Directory.GetFiles(listFolder, ("*_image.lst"), SearchOption.AllDirectories);

            convertingList(audioFiles);
            convertingList(imageFiles);
        }

        private static void convertingList(string[] lists)
        {
            foreach (string list in lists)
            {
                string[] name = Path.GetFileNameWithoutExtension(list).Split('_');
                List<string> content = readListFile(list).ToList();
                StrList newList = new StrList(content, name[0], "_" + name[1]);
                newList.saveContent(true);
                File.Delete(list);
            }
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

        public static string outPutItemName(string path)
        {
            string fileName = Path.GetFileName(path);
            return fileName;
        }


    }
}
