using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPlatform.Models;
using System.IO;
using TestPlatform.Views;
using System;
using System.Windows.Documents;

namespace StroopUnitTestProject
{
    [TestClass]
    public class StrListTests
    {
        string listsPath;
        string[] wordList = new string[] { "amarelo", "azul", "verde", "vermelho" };
        string[] colorList = new string[] { "#F8E000", "#007BB7", "#7EC845", "#D01C1F" };

        [TestInitialize]
        public void TestInitialize()
        {
            listsPath = Global.testFilesPath + Global.listFolderName;
            StrList.writeDefaultColorsList(listsPath);
            StrList.writeDefaultWordsList(listsPath);
        }

        [TestMethod]
        public void StrListObjectTest()
        {
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList strList = new StrList( list, "list", "_word");
            Assert.IsTrue(strList is StrList);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadInexistentList()
        {
            StrList.readListFile(null);
        }

        [TestMethod]
        public void WordListExists()
        {
            List<string> list = new List<string>(wordList);
            StrList strList = new StrList(list,"padrao", "_word");
            Assert.IsTrue(strList is StrList);
        }

        [TestMethod]
        public void ReadStandardWordListTest()
        {
            string[] expected = new string[] { "amarelo", "azul", "verde", "vermelho" };
            string[] actual = StrList.readListFile(listsPath +"padrao_words.lst");
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void ReadStandardColorListTest()
        {
            string[] expected = new string[] {"#F8E000", "#007BB7", "#7EC845", "#D01C1F"};
            string[] actual = StrList.readListFile(listsPath + "padrao_color.lst");
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
    }
}
