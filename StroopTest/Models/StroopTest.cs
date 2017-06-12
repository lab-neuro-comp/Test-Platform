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

        public void writeLineOutputResult(StroopProgram program, string nameStimulus, string color, int counter,
                                   List<string> output, float elapsedTime, string expoType, string audioName)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
            var text = program.ProgramName + "\t" +
                       participantName + "\t" +
                       InitialDate.Day + "/" + InitialDate.Month + "/" + InitialDate.Year + "\t" +
                       DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "\t" +
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
