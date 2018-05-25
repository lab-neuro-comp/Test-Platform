using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestPlatform.Models;

namespace StroopUnitTestProject
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            FileManipulation._defaultPath = (Path.GetDirectoryName(path));
            FileManipulation._testFilesPath = FileManipulation._defaultPath + FileManipulation._testFilesPath;
            if (!Directory.Exists(FileManipulation._testFilesPath))
            {
                Directory.CreateDirectory(FileManipulation._testFilesPath);
            }

            FileManipulation._stroopTestFilesPath = FileManipulation._testFilesPath + FileManipulation._stroopTestFilesPath;
            if (!Directory.Exists(FileManipulation._stroopTestFilesPath))
                Directory.CreateDirectory(FileManipulation._stroopTestFilesPath);
            if (!Directory.Exists(FileManipulation._stroopTestFilesPath + FileManipulation._programFolderName))
                Directory.CreateDirectory(FileManipulation._stroopTestFilesPath + FileManipulation._programFolderName);
            if (!Directory.Exists(FileManipulation._stroopTestFilesPath + FileManipulation._resultsFolderName))
                Directory.CreateDirectory(FileManipulation._stroopTestFilesPath + FileManipulation._resultsFolderName);

            FileManipulation._reactionTestFilesPath = FileManipulation._testFilesPath + FileManipulation._reactionTestFilesPath;
            if (!Directory.Exists(FileManipulation._reactionTestFilesPath))
                Directory.CreateDirectory(FileManipulation._reactionTestFilesPath);
            if (!Directory.Exists(FileManipulation._reactionTestFilesPath + FileManipulation._programFolderName))
                Directory.CreateDirectory(FileManipulation._reactionTestFilesPath + FileManipulation._programFolderName);
            if (!Directory.Exists(FileManipulation._reactionTestFilesPath + FileManipulation._resultsFolderName))
                Directory.CreateDirectory(FileManipulation._reactionTestFilesPath + FileManipulation._resultsFolderName);

            /* creating directories related to Experiment in case they don't already exists*/
            FileManipulation._experimentTestFilesPath = FileManipulation._testFilesPath + FileManipulation._experimentTestFilesPath;
            if (!Directory.Exists(FileManipulation._experimentTestFilesPath))
                Directory.CreateDirectory(FileManipulation._experimentTestFilesPath);
            if (!Directory.Exists(FileManipulation._experimentTestFilesPath + FileManipulation._programFolderName))
                Directory.CreateDirectory(FileManipulation._experimentTestFilesPath + FileManipulation._programFolderName);
            if (!Directory.Exists(FileManipulation._experimentTestFilesPath + FileManipulation._resultsFolderName))
                Directory.CreateDirectory(FileManipulation._experimentTestFilesPath + FileManipulation._resultsFolderName);

            /* creating Lists folder*/
            if (!Directory.Exists(FileManipulation._listFolderName))
            {
                Directory.CreateDirectory(FileManipulation._listFolderName);
            }

            if (!Directory.Exists(FileManipulation._defaultPath + FileManipulation._backupFolderName))
                Directory.CreateDirectory(FileManipulation._defaultPath + FileManipulation._backupFolderName);
        }
    }
}
