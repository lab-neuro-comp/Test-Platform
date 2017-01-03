using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StroopTest.Models;

namespace StroopTest.Controllers
{
    class ListController
    {
        public static StrList createList(List<string> list, string listName)
        {
            StrList wordList = new StrList(list, listName);
            return wordList;
        }
    }
}
