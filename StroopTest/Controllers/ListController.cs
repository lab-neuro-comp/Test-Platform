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
        private static Control controlToRestore = null;
        private static string listType = "";
        private static ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private static CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        public static StrList CreateList(List<string> list, string listName, string listType)
        {
            StrList strlist = new StrList(list, listName, listType);
            return strlist;
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

        public static void recoverEditingProgram(string newListName)
        {
            if(controlToRestore != null)
            {
                Global.GlobalFormMain._contentPanel.Controls.Clear();
                switch (listType)
                {
                    case "_color":
                        controlToRestore.Controls.Find("openColorListButton", true)[0].Text = newListName;
                        break;
                    case "_words":
                        controlToRestore.Controls.Find("openWordListButton", true)[0].Text = newListName;
                        break;
                    case "_audio":
                        controlToRestore.Controls.Find("openAudioListButton", true)[0].Text = newListName;
                        break;
                    case "_image":
                        controlToRestore.Controls.Find("openImgListButton", true)[0].Text = newListName;
                        break;
                }
                Global.GlobalFormMain._contentPanel.Controls.Add(controlToRestore);
            }
            controlToRestore = null;
        }

        public static void createListFile(string listTypeParam, FormDefine formDefine)
        {
            listType = listTypeParam;
            MessageBox.Show(LocRM.GetString("inFormListWarning", currentCulture));
            if(Global.GlobalFormMain._contentPanel.Controls.Count > 0)
            {
                Control listCreationControl = null;
                controlToRestore = Global.GlobalFormMain._contentPanel.Controls[0];
                Global.GlobalFormMain._contentPanel.Controls.Clear();
                switch (listType)
                {
                    case "_color":
                    case "_words":
                        listCreationControl = new FormWordColorConfig(false);
                        break;
                    case "_audio":
                        listCreationControl = new FormAudioConfig(false);
                        break;
                    case "_image":
                        listCreationControl = new FormImgConfig("false");
                        break;
                }
                Global.GlobalFormMain._contentPanel.Controls.Add(listCreationControl);
            }
            else
            {
                /*do nothing*/
            }
        }

        public static string OpenListFile(string itemType, string current, string type)
        {
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;

            string progName = LocRM.GetString("open", currentCulture);

            FormDefine defineProgram = new FormDefine("Lista: ", Global.testFilesPath + Global.listFolderName, type, itemType, false, true);
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
