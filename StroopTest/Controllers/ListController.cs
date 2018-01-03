namespace TestPlatform.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Windows.Forms;
    using TestPlatform.Models;
    using TestPlatform.Views;

    class ListController
    {
        public static StrList CreateList(List<string> list, string listName, string listType)
        {
            StrList wordList = new StrList(list, listName, listType);
            return wordList;
        }

        public static string PickColor(Control control)
        {
            ColorDialog myDialog = new ColorDialog();
            
            myDialog.CustomColors = new int[] 
                                        {
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#F8E000")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#007BB7")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#7EC845")),
                                            ColorTranslator.ToOle(ColorTranslator.FromHtml("#D01C1F"))
                                        };
            Color colorPicked = control.BackColor;
            string hexColor = "#FFFFFF";

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                colorPicked = myDialog.Color;
                hexColor = "#" + colorPicked.R.ToString("X2") + colorPicked.G.ToString("X2") + colorPicked.B.ToString("X2");
            }

            return hexColor;
        }

        public static string OpenListFile(string itemType, string current, string type)
        {
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;

            string progName = LocRM.GetString("open", currentCulture);

            FormDefine defineProgram = new FormDefine("Lista: ", Global.testFilesPath + Global.listFolderName, type, itemType, false);
            var result = defineProgram.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (defineProgram.ReturnValue.Length != 0)
                {
                    progName = defineProgram.ReturnValue;
                }
                else
                {
                    progName = current;
                }
            }

            return progName;
        }
    }
}
