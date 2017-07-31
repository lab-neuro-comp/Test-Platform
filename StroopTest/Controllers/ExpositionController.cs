using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TestPlatform.Views;
using TestPlatform.Views.ExperimentPages;

namespace TestPlatform.Controllers
{
    class ExpositionController
    {
        public static string[] shuffleArray(string[] array, int expectedLength, int rndSeed) // randomiza Vetor - parâmetros: vetor / tamanho esperado do vetor randomizado
        {
            List<string> randomArray = new List<string>();
            Random rnd = new Random(DateTime.Now.Millisecond + expectedLength + rndSeed);

            if (expectedLength == array.Count()) // se pretende-se manter o mesmo tamanho do vetor, não há repetições
            {
                randomArray = array.OrderBy(x => rnd.Next()).ToList();
            }
            else
            {
                for (int i = 0; i < expectedLength; i++) // se não o vetor aleatório será preenchido com valores aleatórios do original, podendo haver repetições
                {
                    randomArray.Add(array[rnd.Next(array.Length)]);
                }
            }
            return randomArray.ToArray();
        }

        public static void beginStroopTest(string programName, string participantName, char mark, Form form)
        {
            try
            {
                FormExposition ormExposition = new FormExposition(programName, participantName, mark);
                ormExposition.StartPosition = FormStartPosition.Manual;
                ormExposition.Location = Screen.AllScreens[showOnMonitor(form)].WorkingArea.Location;
                SendKeys.SendWait("i");
                ormExposition.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void beginReactionTest(string programName, string participantName, char mark, Form form)
        {
            try
            {
                FormReactExposition reactionExposition = new FormReactExposition(programName, participantName, mark);
                reactionExposition.StartPosition = FormStartPosition.Manual;
                reactionExposition.Location = Screen.AllScreens[showOnMonitor(form)].WorkingArea.Location;
                SendKeys.SendWait("i");
                reactionExposition.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void beginExperimentTest(string programName, string participantName, char mark, Form form)
        {
                FormExperimentExposition experimentExposition = new FormExperimentExposition(programName, participantName, mark);
                experimentExposition.StartPosition = FormStartPosition.Manual;
                experimentExposition.Location = Screen.AllScreens[showOnMonitor(form)].WorkingArea.Location;
                SendKeys.SendWait("i");
                experimentExposition.Show();
        }

        private static int showOnMonitor(Form form)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            int showOnMonitor = 0;
            if (sc.Length > 1)
            {
                if (sc[0].Bounds == Screen.FromControl(form).Bounds)
                {
                    showOnMonitor = 1;
                }
                if (sc[1].Bounds == Screen.FromControl(form).Bounds)
                {
                    showOnMonitor = 0;
                }
            }
            return showOnMonitor;
        }
    }
}
