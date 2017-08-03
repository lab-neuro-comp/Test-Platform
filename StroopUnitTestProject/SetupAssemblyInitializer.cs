using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestPlatform.Views;

namespace StroopUnitTestProject
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Global.defaultPath = (Path.GetDirectoryName(path));
            Global.testFilesPath = Global.defaultPath + Global.testFilesPath;
            if (!Directory.Exists(Global.testFilesPath))
            {
                Directory.CreateDirectory(Global.testFilesPath);
            }

            Global.stroopTestFilesPath = Global.testFilesPath + Global.stroopTestFilesPath;
            if (!Directory.Exists(Global.stroopTestFilesPath))
                Directory.CreateDirectory(Global.stroopTestFilesPath);
            if (!Directory.Exists(Global.stroopTestFilesPath + Global.programFolderName))
                Directory.CreateDirectory(Global.stroopTestFilesPath + Global.programFolderName);
            if (!Directory.Exists(Global.stroopTestFilesPath + Global.resultsFolderName))
                Directory.CreateDirectory(Global.stroopTestFilesPath + Global.resultsFolderName);

            Global.reactionTestFilesPath = Global.testFilesPath + Global.reactionTestFilesPath;
            if (!Directory.Exists(Global.reactionTestFilesPath))
                Directory.CreateDirectory(Global.reactionTestFilesPath);
            if (!Directory.Exists(Global.reactionTestFilesPath + Global.programFolderName))
                Directory.CreateDirectory(Global.reactionTestFilesPath + Global.programFolderName);
            if (!Directory.Exists(Global.reactionTestFilesPath + Global.resultsFolderName))
                Directory.CreateDirectory(Global.reactionTestFilesPath + Global.resultsFolderName);

            /* creating directories related to Experiment in case they don't already exists*/
            Global.experimentTestFilesPath = Global.testFilesPath + Global.experimentTestFilesPath;
            if (!Directory.Exists(Global.experimentTestFilesPath))
                Directory.CreateDirectory(Global.experimentTestFilesPath);
            if (!Directory.Exists(Global.experimentTestFilesPath + Global.programFolderName))
                Directory.CreateDirectory(Global.experimentTestFilesPath + Global.programFolderName);
            if (!Directory.Exists(Global.experimentTestFilesPath + Global.resultsFolderName))
                Directory.CreateDirectory(Global.experimentTestFilesPath + Global.resultsFolderName);

            /* creating Lists folder*/
            if (!Directory.Exists(Global.testFilesPath + Global.listFolderName))
            {
                Directory.CreateDirectory(Global.testFilesPath + Global.listFolderName);
            }

            if (!Directory.Exists(Global.defaultPath + Global.backupFolderName))
                Directory.CreateDirectory(Global.defaultPath + Global.backupFolderName);
        }
    }
}
