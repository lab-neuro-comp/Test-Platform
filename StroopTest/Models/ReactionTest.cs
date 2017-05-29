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
        private static String headerOutputFileText = "programa\tparticipante\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tFormaDoStimulo\tCordoEstimulo\tCordoPontodefixacao";
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

        public void writeLineOutput(long intervalTime, long reactTime, int currentExposition)
        {
            long elapsedTime = intervalTime + reactTime;

            /* programa\tparticipante\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tFormaDoStimulo\tCordoEstimulo\CordoPontodefixacao */
            var text = ProgramInUse.ProgramName + "\t" + participantName + "\t" + initialTime.Day + "/" + 
                       initialTime.Month + "/" + initialTime.Year + "\t" + initialTime.Hour + ":" + initialTime.Minute + 
                       ":" + initialTime.Second + ":" + initialTime.Millisecond.ToString() + "\t" + elapsedTime.ToString() + "\t" +
                       currentExposition + "\t" + ProgramInUse.ExpositionType + "\t" + ProgramInUse.StimuluShape + "\t" +
                       ProgramInUse.StimulusColor + "\t" + ProgramInUse.FixPointColor;
             Output.Add(text); 
             
        }


    }
}
