using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPlatform.Models;
using System.IO;
using TestPlatform.Views;
using System;
using System.Threading;
using System.Globalization;

namespace StroopUnitTestProject
{
    [TestClass]
    public class StrListTests
    {
        StrList testList;
        string listsPath;
        string[] wordList = new string[] { "amarelo", "azul", "verde", "vermelho" };
        string[] colorList = new string[] { "#F8E000", "#007BB7", "#7EC845", "#D01C1F" };

        // This craetes default color list and default word list prior to testing
        [TestInitialize]
        public void TestInitialize()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("pt-BR");
            listsPath = Global.testFilesPath + Global.listFolderName;
            StrList.writeDefaultColorsList(listsPath);
            StrList.writeDefaultWordsList(listsPath);
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            testList = new StrList(list, "test", "_words");
        }

        // Tests if constructor method to strlist works passing list name, type and list object as parameters
        [TestMethod]
        public void TestStrListConstructor()
        {
            string listName = "list";
            string listType = "_words";
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList actualStrList = new StrList(list, listName, listType);
            Assert.IsTrue(actualStrList is StrList);
            Assert.AreEqual(listName, actualStrList.ListName);
            Assert.AreEqual(listType, actualStrList.Type);
        }

        // Tests returning variable of method to save a strlist file
        [TestMethod]
        public void TestStrListSaveFile()
        {
            bool testSaved = testList.save();
            Assert.IsTrue(testSaved);
        }

        // Testing constructor method of strlist sending type list parameter in a wrong way
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nO tipo de lista é inválido, a lista deve ser de aúdio, imagens," + 
            "palavras ou cores.")]
        public void TestCreateWrongListType()
        {
            string listName = "list";
            string wrongType = "wrong type";
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList actualStrList = new StrList(list, listName, wrongType);
        }

        // Testing constructor method of strlist sending list name parameter in a wrong way
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nO nome da lista não pode ser nulo.")]
        public void TestCreateNullListName()
        {
            string listType = "_words";
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList actualStrList = new StrList(list, null, listType);
        }

        // Testing reading file of a list that doesnt exist
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestReadInexistentList()
        {
            StrList.readListFile(null);
        }

        // Testing constructor method of list with word type with valid parameters
        [TestMethod]
        public void TestWordListExists()
        {
            List<string> list = new List<string>(wordList);
            StrList strList = new StrList(list,"padrao", "_words");
            Assert.IsTrue(strList is StrList);
        }

        // Testing to read default word list to see if it matches to expected
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

        // Testing to read default color list to see if it matches to expected
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
