using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StroopTest;
using StroopTest.Models;
using StroopTest.Views;
using StroopTest.Controllers;

namespace StroopUnitTestProject
{
    [TestClass]
    public class StrListTests
    {
        [TestMethod]
        public void StrListObjectTest()
        {
            List<string> list = new List<string>(new string[] { "element1", "element2", "element3" });
            StrList strList = new StrList( list, "list");
            Assert.IsTrue(strList is StrList);
        }
    }
}
