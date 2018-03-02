using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestPlatform.Views;
using TestPlatform.Views.MainForms;

namespace TestPlatform.Controllers
{
    class HelpPagesController
    {
        private static string INSTRUCTIONSFILENAME = "editableInstructions.txt";

        public static void showInstructions()
        {
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            FormInstructions infoBox = new FormInstructions(LocRM.GetString("instructionBoxText", currentCulture), (Global.testFilesPath + INSTRUCTIONSFILENAME));
            try
            {
                infoBox.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static System.Windows.Forms.Control showTechInfo()
        {
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            HelpPagesUserControl infoBox = new HelpPagesUserControl(LocRM.GetString("technicalInformation", currentCulture));
            try
            {
                Global.GlobalFormMain._contentPanel.Controls.Add(infoBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return infoBox;
        }

        public static System.Windows.Forms.Control showHelp()
        {
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            HelpPagesUserControl infoBox = new HelpPagesUserControl(LocRM.GetString("viewHelp", currentCulture));
            try
            {
                Global.GlobalFormMain._contentPanel.Controls.Add(infoBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return infoBox;
        }

        public static void showAboutBox()
        {
            AboutBox aboutWindow = new AboutBox();
            try { aboutWindow.Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
