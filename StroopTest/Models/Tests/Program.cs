using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Resources;
using System.Globalization;

namespace TestPlatform.Models
{
    class Program
    {
        // properties used to localize strings during runtime
        protected ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        protected CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        protected String defaultRedColor = "#D01C1F";
        public static Int32 instructionAwaitTime = 4000; // default await time for each frame of instruction shown before the test
        protected Boolean needsEditionFlag;

        protected List<string> instructionText = new List<string>();
        protected String programName;             // [0]   program name
        protected Int32 numExpositions;             // [1]*  number of expositions to be shown 
        protected Int32 expositionTime;             // [2]*  duration time of each exposition (millisec)
        protected Boolean expositionRandom;          // [3]*  is exposition random
        protected Int32 intervalTime;               // [4]*  duration time for interval between expositions (millisec)
        protected StrList wordsListFile;           // [6]   words list file name (.lst)
        protected StrList colorsListFile;          // [7]   colors list file name (.lst)
        protected String backgroundColor;         // [8]   background color during exposition (hex)
        protected String expositionType;          // [13]  exposition type
        protected StrList imagesListFile;          // [14]  images path list file name (.lst)
        protected String fixPoint;                // [15]  fixation point shown during interval time - cross / circle - false = deactivated
        protected StrList audioListFile;           // [18]  audio list file name (.lst) - if it is and audio exposition type [13]
        protected String fixPointColor;           // [20]  cor do ponto de fixação - vermelho - se ponto de fixação != false definir cor
        protected Boolean intervalTimeRandom;        // [5]*  is interval time random - rnd num between defined intervalTime and minRandomTime (bool)
        protected Boolean expandImage;               // [17]  expands image adjusting it to the screen - if true, subtitles false


        public List<string> InstructionText
        {
            get { return instructionText; }
            set
            {
                instructionText = value;
            }
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
                    throw new ArgumentException(LocRM.GetString("programNotAlphanumeric", currentCulture));
                }
            }
        }

        public int NumExpositions
        {
            get { return numExpositions; }
            set
            {
                // number of expositions must be greater than zero
                if (Validations.isNumExpositionsValid(value))
                {
                    numExpositions = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("expoNumber", currentCulture));
                }
            }   
        }

        public int ExpositionTime
        {
            get { return expositionTime; }
            set
            {
                // exposition time must be greater than zero
                if (Validations.isExpositionTimeValid(value))
                {
                    expositionTime = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("expoTime", currentCulture));
                }   
            }
        }

        public int IntervalTime
        {
            get { return intervalTime; }
            set
            {
                // interval time must be greater than zero
                if (Validations.isIntervalTimeValid(value))
                {
                    intervalTime = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("intervalTime", currentCulture));
                }   
            }
        }

        // creates word list object in case program has one 
        public void setWordListFile(string listName)
        {
            if (listName != "false")
            {
                wordsListFile = new StrList(listName, 2);
            }
            else
            {
                wordsListFile = null;
            }

        }

        // gets program word list in case there is one
        public StrList getWordListFile()
        {
            if (wordsListFile != null)
            {
                return wordsListFile;
            }
            else
            {
                return null;
            }

        }

        public void setColorListFile(string listName)
        {
            if (listName != "false")
            {
                colorsListFile = new StrList(listName, 3);
            }
            else
            {
                colorsListFile = null;
            }

        }

        public StrList getColorListFile()
        {
            if (colorsListFile != null)
            {
                return colorsListFile;
            }
            else
            {
                return null;
            }

        }

        public string BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                // colors must match with the hexadecimal (#000000) pattern for color codes or be "false" to indicate that theres no color defined
                if (Validations.isColorValid(value))
                {
                    backgroundColor = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("backgroundColorError", currentCulture));
                }   
            }
        }

        public void setImageListFile(string listName)
        {
            if (listName != "false")
            {
                imagesListFile = new StrList(listName, 0);
            }
            else
            {
                imagesListFile = null;
            }

        }

        public StrList getImageListFile()
        {
            if (imagesListFile != null)
            {
                return imagesListFile;
            }
            else
            {
                return null;
            }

        }

        public string FixPoint
        {
            get { return fixPoint; }
            set
            {
                if (Validations.isFixPointValid(value))
                {
                    fixPoint = value.ToLower();
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("fixPointError", currentCulture));
                }
            }
        }

        public void setAudioListFile(string listName)
        {
            if (listName != "false")
            {
                audioListFile = new StrList(listName, 1);
            }
            else
            {
                audioListFile = null;
            }

        }

        public StrList getAudioListFile()
        {
            if (audioListFile != null)
            {
                return audioListFile;
            }
            else
            {
                return null;
            }

        }
        
        public string FixPointColor
        {
            get { return fixPointColor; }
            set
            {
                if (Validations.isColorValid(value))
                {
                    fixPointColor = value;
                    if (fixPointColor.ToLower().Equals("false"))
                    {
                        fixPointColor = defaultRedColor;
                    }
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("fixPointColorError", currentCulture));
                }
            }
        }

        public bool ExpositionRandom
        {
            get
            {
                return expositionRandom;
            }
            set
            {
                expositionRandom = value;

            }
        }

        public bool IntervalTimeRandom
        {
            get
            {
                return intervalTimeRandom;
            }
            set
            {
                intervalTimeRandom = value;
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

        public bool NeedsEdition
        {
            get
            {
                return needsEditionFlag;
            }
        }

        public static string encodeLatinText(string text)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;

            byte[] utfBytes = utf8.GetBytes(text);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            string encodedStr = iso.GetString(isoBytes);

            return encodedStr;
        }

        public static string[] readDirListFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                string[] imageDirs = File.ReadAllLines(filepath);
                return imageDirs; // return directories
            }
            else
            {
                throw new FileNotFoundException(Path.GetFileName(filepath) + 
                    "  " + Path.GetDirectoryName(filepath));
            }
            
            
        }

        // reads data file and returns a list with attributes
        public static string[] readDataFile(string filepath)
        {
            if (File.Exists(filepath)) {
                string[] linesList = File.ReadAllLines(filepath);
                return linesList;                
            }
            else
            {
                throw new FileNotFoundException(Path.GetFileName(filepath) +
                    "   " + Path.GetDirectoryName(filepath));
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


        // writes lines in output file
        public static void writeOutputFile(string filepath, string outContent)
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
