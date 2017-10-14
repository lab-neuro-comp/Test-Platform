using System.Collections.Generic;
using TestPlatform.Models;
using System.Drawing;
using System.Windows.Forms;
using TestPlatform.Views;

namespace TestPlatform.Controllers
{
    class ListController
    {
        public static StrList createList(List<string> list, string listName, string listType)
        {
            StrList wordList = new StrList(list, listName, listType);
            return wordList;
        }


        public static string pickColor(Control control)
        {
            ColorDialog MyDialog = new ColorDialog();
            

            MyDialog.CustomColors = new int[] {
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#F8E000")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#007BB7")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#7EC845")),
                                        ColorTranslator.ToOle(ColorTranslator.FromHtml("#D01C1F"))
                                      };
            Color colorPicked = control.BackColor;
            string hexColor = "#FFFFFF";

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = MyDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }

            return hexColor;
        }


        public static string openListFile(string itemType)
        {
            string progName = "abrir";

            FormDefine defineProgram = new FormDefine("Lista: ", Global.testFilesPath + Global.listFolderName, "lst", itemType, false);
            var result = defineProgram.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                progName = defineProgram.ReturnValue;
            }

            return progName;
        }
    }
}
