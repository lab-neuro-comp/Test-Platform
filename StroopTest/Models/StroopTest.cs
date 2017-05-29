using TestPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models
{
    class StroopTest
    {
        private static String headerOutputFileText = "programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor\taudio";
        private DateTime initialDate;           // test execution date
        private String participantName;                // tested person name
        private Char mark; // char mark made into neurospectrum program
        private StroopProgram programInUse;


        public StroopTest()
        {
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
                if (!Validations.isEmpty(value) && Validations.isAlphanumeric(value)) participantName = value;
                else throw new ArgumentException("Nome do usuario deve ser composto apenas de caracteres alphanumericos e sem espaços;\nExemplo: 'JoaoSilva'");
            }   // user name has only alphanumeric elements, without spaces
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

        public static void writeLineOutputResult(StroopProgram program, string nameStimulus, string color, int counter,
                                   List<string> output, float elapsedTime, string expoType, string audioName,
                                   string hour, string minute, string second, StroopTest test)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
            var text = program.ProgramName + "\t" +
                       test.participantName + "\t" +
                       test.InitialDate.Day + "/" + test.InitialDate.Month + "/" + test.InitialDate.Year + "\t" +
                       hour + ":" + minute + ":" + second + ":" + DateTime.Now.Millisecond.ToString() + "\t" +
                       elapsedTime.ToString() + "\t" +
                       counter + "\t" +
                       expoType + "\t" +
                       program.SubtitleShow.ToString().ToLower() + "\t" +
                       program.SubtitlePlace + "\t" +
                       nameStimulus + "\t" +
                       color + "\t" +
                       audioName;

            output.Add(text);
        }
    }
}
