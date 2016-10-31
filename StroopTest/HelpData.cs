using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroopTest
{
    public class HelpData
    {
        private static string audioConfigInstructions = "";
        private static string imageConfigInstructions = "";
        private static string wordColorConfigInstructions = "";
        private static string showDataInstructions = "";
        private static string programConfigInstructions = "";

        public static string AudioConfigInstructions        { get { return audioConfigInstructions; } }
        public static string ImageConfigInstructions        { get { return imageConfigInstructions; } }
        public static string WordColorConfigInstructions    { get { return wordColorConfigInstructions; } }
        public static string ShowDataInstructions           { get { return showDataInstructions; } }
        public static string ProgramConfigInstructions      { get { return programConfigInstructions; } }
    }
}
