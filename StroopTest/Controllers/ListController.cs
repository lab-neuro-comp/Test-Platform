using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StroopTest.Models;
using System.Drawing;
using System.Windows.Forms;

namespace StroopTest.Controllers
{
    class ListController
    {
        public static StrList createList(List<string> list, string listName)
        {
            StrList wordList = new StrList(list, listName);
            return wordList;
        }


        public static string pickColor(Control control)
        {
            ColorDialog MyDialog = new ColorDialog();
            Color colorPicked = new Color();

            MyDialog.CustomColors = new int[] {
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#F8E000")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#007BB7")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#7EC845")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#D01C1F"))
                                      };
            colorPicked = control.BackColor;

            string hexColor = "#FFFFFF";

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = MyDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }

            return hexColor;
        }


        public static string openListFile(string itemType,string path)
        {
            string progName = "abrir";

            FormDefine defineProgram = new FormDefine("Lista: ", path + "/Lst/", "lst", itemType, false);
            var result = defineProgram.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                progName = defineProgram.ReturnValue + itemType + ".lst";
            }

            return progName;
        }
    }
}
