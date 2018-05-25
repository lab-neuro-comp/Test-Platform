using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestPlatform.Models
{
    /*
    * This class is a pure fabrication that handles file paths, and all file manipulations in the application
    * it is marked as sealed to prevent derivations, ensuring that the singleton implementation is respected (only one instance of this
    * class must be created).
    * */
    public sealed class FileManipulation
    {

        /// <summary>
        /// Only instance allowed, following singleton pattern
        /// </summary>
        private static FileManipulation instance;

        private static FormMain _globalFormMain;
        private static string _defaultPath; // path of execution program

        private static string _testFilesPath = "/TestFiles/";
        private static string _stroopTestFilesPath = "/StroopTestFiles/";
        private static string _reactionTestFilesPath = "/ReactionTestFiles/";
        private static string _experimentTestFilesPath = "/ExperimentTestFiles/";
        private static string _matchingTestFilesPath = "/MatchingTestFiles/";

        private static string _stroopTestFilesBackupPath = "/StroopTestFiles/";
        private static string _reactionTestFilesBackupPath = "/ReactionTestFiles/";
        private static string _experimentTestFilesBackupPath = "/ExperimentTestFiles/";
        private static string _matchingTestFilesBackupPath = "/MatchingTestFiles/";
        private static string _listFilesBackup = "/Lst/";

        private static string _listFolderName = "/Lst/";
        private static string _importPath = "/import";

        private static string _programFolderName = "/prg/";
        private static string _resultsFolderName = "/data/";

        private static string _backupFolderName = "/backup/";

        private static string PROGRAM_EXTENSION = ".prg";

        private static FormMain GlobalFormMain
        {
            get { return _globalFormMain; }
            set { _globalFormMain = value; }
        }

        private FileManipulation(FormMain globalFormMain) {
            GlobalFormMain = globalFormMain;

            CreateMainFolderAndPaths();

            MoveOldStroopVersion();

            CreateSubFolders(_reactionTestFilesPath);
            CreateSubFolders(_stroopTestFilesPath);
            CreateSubFolders(_experimentTestFilesPath);
            CreateSubFolders(_matchingTestFilesPath);

            /* creating Lists folder*/
            if (!Directory.Exists(_listFolderName))
            {
                Directory.CreateDirectory(_listFolderName);
            }

            CreateBackupFolders();

            if (Directory.Exists(_defaultPath + "/StroopTestFiles"))
                Directory.Delete(_defaultPath + "/StroopTestFiles", true);

            // converting old implementations of file lists to new version
            StrList.convertFileLists();

            // create default stroop and reaction programs, adding default word and color lists
            InitializeDefaultPrograms();

        }

        public static FileManipulation Instance(FormMain globalFormMain)
        {
            if (instance == null)
            {
                instance = new FileManipulation(globalFormMain);
            }
            return instance;
        }

        public static FileManipulation Instance()
        {
            return instance;
        }

        public static string[] GetAllFilesInFolder(string dataFolderPath, string fileType)
        {
            if (Directory.Exists(dataFolderPath))
            {
                string[] filePaths = Directory.GetFiles(dataFolderPath, ("*." + fileType), SearchOption.AllDirectories);
                return filePaths;
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }

        public static List<string> ReadStroopProgram(string programName)
        {
            string filePath = _stroopTestFilesPath + _programFolderName + programName + PROGRAM_EXTENSION;
            return ReadFileFirstLine(filePath);
        }

        public static List<string> ReadStroopProgramFromBackup(string programName)
        {
            string filePath = _stroopTestFilesBackupPath + programName + PROGRAM_EXTENSION;
            return ReadFileFirstLine(filePath);
        }

        public static List<string> ReadStroopProgramInstructions(string programName)
        {
            string filePath = _stroopTestFilesPath + _programFolderName + programName + PROGRAM_EXTENSION;
            return ReadProgramInstructions(filePath);
        }

        private static List<string> ReadProgramInstructions(string filePath)
        {

            // reads instructions if there are any
            string[] linesInstruction = File.ReadAllLines(filePath);
            List<string> instructions = new List<string>();
            if (linesInstruction.Length > 1)
            {
                for (int i = 1; i < linesInstruction.Length; i++)
                {
                    instructions.Add(linesInstruction[i]);
                }
            }
            else
            {
                instructions = null;
            }
            return instructions;
        }

        public bool SaveProgramFile(string path, string data, List<string> instructionText)
        {
            StreamWriter writer = new StreamWriter(path + PROGRAM_EXTENSION);
            writer.WriteLine(data);
            if (instructionText != null)
            {
                for (int i = 0; i < instructionText.Count; i++)
                {
                    writer.WriteLine(instructionText[i]);
                }
            }
            writer.Close();
            return true;
        }

        public static List<string> ReadFileFirstLine(string filePath)
        {
            if (File.Exists(filePath))
            {
                StreamReader streamReader = new StreamReader(filePath, Encoding.Default, true);
               
                string line = streamReader.ReadLine();
                line = encodeLatinText(line);

                List<string> config = new List<string>();
                config = line.Split().ToList();
                streamReader.Close();

                return config;
            }
            else
            {
                throw new FileNotFoundException();
            }

        }

        public static bool StroopProgramExists(string programName)
        {
            return FileExists(_stroopTestFilesPath + _programFolderName + programName + PROGRAM_EXTENSION);
        }

        private static bool FileExists(string file)
        {
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string encodeLatinText(string text)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;

            byte[] utfBytes = utf8.GetBytes(text);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            string encodedStr = iso.GetString(isoBytes);

            return encodedStr;
        }


        private void CreateBackupFolders()
        {
            if (!Directory.Exists(_defaultPath + _backupFolderName))
                Directory.CreateDirectory(_defaultPath + _backupFolderName);

            _stroopTestFilesBackupPath = _defaultPath + _backupFolderName + _stroopTestFilesBackupPath;
            _reactionTestFilesBackupPath = _defaultPath + _backupFolderName + _reactionTestFilesBackupPath;
            _experimentTestFilesBackupPath = _defaultPath + _backupFolderName + _experimentTestFilesBackupPath;
            _matchingTestFilesBackupPath = _defaultPath + _backupFolderName + _matchingTestFilesBackupPath;
            _listFilesBackup = _defaultPath + _backupFolderName + _listFilesBackup;

            if (!Directory.Exists(_experimentTestFilesBackupPath))
                Directory.CreateDirectory(_experimentTestFilesBackupPath);
            if (!Directory.Exists(_stroopTestFilesBackupPath))
                Directory.CreateDirectory(_stroopTestFilesBackupPath);
            if (!Directory.Exists(_reactionTestFilesBackupPath))
                Directory.CreateDirectory(_reactionTestFilesBackupPath);
            if (!Directory.Exists(_matchingTestFilesBackupPath))
                Directory.CreateDirectory(_matchingTestFilesBackupPath);
            if (!Directory.Exists(_listFilesBackup))
                Directory.CreateDirectory(_listFilesBackup);
        }

        /// <summary>
        ///  creating testfiles, program and results directories related to parameter in case they don't already exists*/
        /// </summary>
        private void CreateSubFolders(string testFile)
        {
            if (!Directory.Exists(testFile))
                Directory.CreateDirectory(testFile);

            if (!Directory.Exists(testFile + _programFolderName))
                Directory.CreateDirectory(testFile + _programFolderName);

            if (!Directory.Exists(testFile + _resultsFolderName))
                Directory.CreateDirectory(testFile + _resultsFolderName);
        }

        public static void CreatImportFolder()
        {
            Directory.CreateDirectory(_importPath);

            if (Directory.Exists(_importPath))
            {
                Directory.Delete(_importPath, true);
            }
            else
            {
                /* do nothing */
            }
        }

        public static void ExtractImportFile(string fileName)
        {
            ZipFile.ExtractToDirectory(fileName, _importPath);
        }

        /// <summary>
        /// Create default programs of tests, examples of tests configurations that can be run without needing any modification
        /// Currently, there are stroop program, reaction program, color list and word list.
        /// </summary>
        private void InitializeDefaultPrograms()
        {
            StroopProgram programDefault = new StroopProgram();
            programDefault.writeDefaultProgramFile(_stroopTestFilesPath + _programFolderName + programDefault.ProgramName + ".prg");

            ReactionProgram defaultProgram = new ReactionProgram();
            defaultProgram.writeDefaultProgramFile();

            StrList.writeDefaultWordsList(_testFilesPath + _listFolderName);
            StrList.writeDefaultColorsList(_testFilesPath + _listFolderName);
        }

        /// <summary>
        /// updating local directory of new version of platform, excluding old stroop one in case it there is one
        /// </summary>
        private void MoveOldStroopVersion()
        {
            if (File.Exists(_defaultPath + "/StroopTest.exe"))
            {
                DirectoryInfo directoryOldLst = new DirectoryInfo(_defaultPath + "/StroopTestFiles/lst");
                directoryOldLst.MoveTo(_listFolderName);

                DirectoryInfo directoryOldStroop = new DirectoryInfo(_defaultPath + "/StroopTestFiles/");
                directoryOldStroop.MoveTo(_stroopTestFilesPath);

                DirectoryInfo directoryOldData = new DirectoryInfo(_defaultPath + _resultsFolderName);
                directoryOldData.MoveTo(_stroopTestFilesPath +_resultsFolderName);
                File.Delete(_defaultPath + "/StroopTest.exe");
            }
            else
            {
                /*do nothing*/
            }
        }

        /// <summary>
        /// Create main folder for application and update paths according to executable path
        /// </summary>
        private void CreateMainFolderAndPaths(){
            //saving on variable current executing path
            _defaultPath = (Path.GetDirectoryName(Application.ExecutablePath)); 

            _testFilesPath = _defaultPath + _testFilesPath;
            _stroopTestFilesPath = _testFilesPath + _stroopTestFilesPath;
            _listFolderName = _testFilesPath + _listFolderName;
            _reactionTestFilesPath = _testFilesPath + _reactionTestFilesPath;
            _experimentTestFilesPath = _testFilesPath + _experimentTestFilesPath;
            _matchingTestFilesPath = _testFilesPath + _matchingTestFilesPath;
            _importPath = _testFilesPath + _importPath;

            if (!Directory.Exists(_testFilesPath))
            {
                Directory.CreateDirectory(_testFilesPath);
            }
            else
            {
                /*do nothing*/
            }
        }

    }
}
