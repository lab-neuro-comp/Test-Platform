using TestPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Globalization;

namespace TestPlatform.Models
{
    /*
    * Class that represents results found while executing a test program (StroopProgram) and stores data from a partincipant test
    *
    */
    class StroopTest
    {
        private static String headerOutputFileText;
        private DateTime initialDate;           // test execution date
        private String participantName;                // tested person name
        private Char mark; // char mark made into neurospectrum program
        private StroopProgram programInUse;

        public StroopTest()
        {
            // used to localize strings during runtime
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;

            headerOutputFileText = LocRM.GetString("stroopResultHeader", currentCulture);
        }
        public static string HeaderOutputFileText
        {
            get
            {
                return headerOutputFileText;
            }

            set
            {
                headerOutputFileText = value;
            }
        }

        public DateTime InitialDate
        {
            get { return initialDate; }
            set { initialDate = value; }
        }

        public string ParticipantName
        {
            get { return participantName; }
            set
            {
                // user name can have only alphanumeric elements, without spaces
                if (!Validations.isEmpty(value) && Validations.isAlphanumeric(value))
                {
                    participantName = value;
                }
                else
                { 
                    // used to localize strings during runtime
                    ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
                    CultureInfo currentCulture = CultureInfo.CurrentUICulture;

                    throw new ArgumentException(LocRM.GetString("participantNameAlphanumericError", currentCulture));
                }
            }   
        }

        public char Mark
        {
            get
            {
                return mark;
            }

            set
            {
                mark = value;
            }
        }

        internal StroopProgram ProgramInUse
        {
            get
            {
                return programInUse;
            }

            set
            {
                programInUse = value;
            }
        }

        public void writeLineOutputResult(string nameStimulus, string color, int counter,
                                   List<string> output, float elapsedTime, string audioName)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
            var text = programInUse.ProgramName + "\t" +
                       participantName + "\t" +
                       InitialDate.Day + "/" + InitialDate.Month + "/" + InitialDate.Year + "\t" +
                       DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "\t" +
                       elapsedTime.ToString() + "\t" +
                       counter + "\t" +
                       programInUse.ExpositionType + "\t" +
                       programInUse.SubtitleShow.ToString().ToLower() + "\t" +
                       programInUse.SubtitlePlace + "\t" +
                       nameStimulus + "\t" +
                       color + "\t" +
                       audioName;

            output.Add(text);
        }
    }
}
