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
            FileManipulation.Instance(path);
        }
    }
}
