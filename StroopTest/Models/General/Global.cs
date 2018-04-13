namespace TestPlatform.Views
{
    /*
    * Constants for tests platform
    * */
    static class Global
    {
        private static FormMain _globalFormMain;
        public static string defaultPath; // path of execution program

        public static string testFilesPath = "/TestFiles/";
        public static string stroopTestFilesPath = "/StroopTestFiles/";
        public static string reactionTestFilesPath = "/ReactionTestFiles/";
        public static string experimentTestFilesPath = "/ExperimentTestFiles/";
        public static string matchingTestFilesPath = "/MatchingTestFiles/";
        public static string partcipantDataPath = "/ParticipantData/";

        public static string stroopTestFilesBackupPath = "/StroopTestFiles/";
        public static string reactionTestFilesBackupPath = "/ReactionTestFiles/";
        public static string experimentTestFilesBackupPath = "/ExperimentTestFiles/";
        public static string matchingTestFilesBackupPath = "/MatchingTestFiles/";
        public static string listFilesBackup = "/Lst/";

        public static string listFolderName = "/Lst/";

        public static string programFolderName = "/prg/";
        public static string resultsFolderName = "/data/";
        
        public static string backupFolderName = "/backup/";
        public static FormMain GlobalFormMain
        {
            get { return _globalFormMain; }
            set { _globalFormMain = value; }
        }
    }
}
