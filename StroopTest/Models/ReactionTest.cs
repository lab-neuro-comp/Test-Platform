using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models
{
    class ReactionTest
    {
        private static String headerOutputFileText = "programa\tparticipante\tdata\thorario\ttempohit(ms)\tintervalo(ms)"
            + "\tintervaloestimado(ms)\texposicao(ms)\tsequencia\ttipoEstimulo\tFormaDoStimulo\tCordoEstimulo";
        private Char mark;
        private ReactionProgram programInUse = new ReactionProgram();
        private string participantName;
        private DateTime initialTime;
        private List<string> output = new List<string>();

        public string ParticipantName
        {
            get
            {
                return participantName;
            }

            set
            {
                participantName = value;
            }
        }

        public DateTime InitialTime
        {
            get
            {
                return initialTime;
            }

            set
            {
                initialTime = value;
            }
        }

        public List<string> Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
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

        internal ReactionProgram ProgramInUse
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

        public void setProgramInUse(string path, string prgName)
        {
            string programFile = path + prgName + ".prg";
            if (File.Exists(programFile))
            {
                ProgramInUse = new ReactionProgram(programFile);
            }
            else
            {
                throw new Exception("Arquivo programa: " + ProgramInUse.ProgramName + ".prg" +
                                    "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/"));
            }
        }

        public void writeLineOutput(long intervalTime, long intervalShouldBe, long reactTime, int currentExposition)
        {
            /* This variable keeps data from an exposition to only one stimulus, being them:
             * program  name    participant     name    date    hour    hit time(ms) interval(ms)  interval should be(ms)  
             * exposition time(ms)  number of sequency   type of stimulus    shape of stimulus   stimulus color */
            var text = ProgramInUse.ProgramName + "\t" + participantName + "\t" + initialTime.Day + "/" +
                       initialTime.Month + "/" + initialTime.Year + "\t" + initialTime.Hour + ":" + initialTime.Minute +
                       ":" + initialTime.Second + ":" + initialTime.Millisecond.ToString() + "\t" + reactTime.ToString() +
                        "\t" + intervalTime.ToString() + "\t" + intervalShouldBe.ToString() + "\t" + 
                        ProgramInUse.ExpositionTime +  "\t" + currentExposition + "\t" + ProgramInUse.ExpositionType + "\t" +
                        ProgramInUse.StimuluShape + "\t" + ProgramInUse.StimulusColor;
             Output.Add(text); 
             
        }


    }
}
