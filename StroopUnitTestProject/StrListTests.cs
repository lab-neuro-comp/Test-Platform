using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPlatform.Models;
using System.IO;
using TestPlatform.Views;
using System;

namespace StroopUnitTestProject
{
    [TestClass]
    public class StrListTests
    {
        StrList testList;
        string listsPath;
        string[] wordList = new string[] { "amarelo", "azul", "verde", "vermelho" };
        string[] colorList = new string[] { "#F8E000", "#007BB7", "#7EC845", "#D01C1F" };

        [TestInitialize]
        public void TestInitialize()
        {
            listsPath = Global.testFilesPath + Global.listFolderName;
            StrList.writeDefaultColorsList(listsPath);
            StrList.writeDefaultWordsList(listsPath);
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            testList = new StrList(list, "test", "_words");
        }

        [TestMethod]
        public void StrListConstructortTest()
        {
            string listName = "list";
            string listType = "_words";
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList actualStrList = new StrList(list, listName, listType);
            Assert.IsTrue(actualStrList is StrList);
            Assert.AreEqual(listName, actualStrList.ListName);
            Assert.AreEqual(listType, actualStrList.Type);
        }

        [TestMethod]
        public void StrListSaveFile()
        {
            bool testSaved = testList.save();
            Assert.IsTrue(testSaved);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nO tipo de lista é inválido, a lista deve ser de aúdio, imagens," + 
            "palavras ou cores.")]
        public void CreateWrongListType()
        {
            string listName = "list";
            string wrongType = "wrong type";
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList actualStrList = new StrList(list, listName, wrongType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nO nome da lista não pode ser nulo.")]
        public void CreateNullListName()
        {
            string listType = "_words";
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList actualStrList = new StrList(list, null, listType);
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
            StrList strList = new StrList(list,"padrao", "_words");
            Assert.IsTrue(strList is StrList);
        }

        [TestMethod]
        public void ReadStandardWordListTest()
        {
            string[] expected = wordList;
            string[] actual = StrList.readListFile(listsPath +"padrao_words.lst");
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void ReadStandardColorListTest()
        {
            string[] expected = colorList;
            string[] actual = StrList.readListFile(listsPath + "padrao_color.lst");
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
    }
}
