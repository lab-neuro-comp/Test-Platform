using System;
using System.Collections.Generic;
using System.IO;

namespace TestPlatform.Models
{
    /*
     * Class that represents results found while executing a test program (ReactionProgram) and stores data from a partincipant test
     *
     */
    class ReactionTest
    {
        private static String headerOutputFileText = "programa\tparticipante\tdata\thorarioInicial\thorarioExposicao\ttr(ms)\tintervalo(ms)"
            + "\tintervaloestimado(ms)\texposicaoTempo(ms)\texposicao(ms)\tsequencia\tpos\ttipoEstimulo\tEstimulo\tCordoEstimulo";
        private Char mark;
        private ReactionProgram programInUse = new ReactionProgram();
        private string participantName;
        private DateTime initialTime;
        private DateTime expositionTime;
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

        public DateTime ExpositionTime
        {
            get
            {
                return expositionTime;
            }

            set
            {
                expositionTime = value;
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

        public void writeLineOutput(long intervalTime, long intervalShouldBe, long reactTime, int currentExposition, long expositionAccumulative, string currentStimulus, string position)
        {
            /* This variable keeps data from an exposition to only one stimulus, being them:
             * program  name    participant     name    date    hour    exposition hour    hit time(ms) interval(ms)  interval should be(ms)  
             * exposition accumulative timeexposition time(ms)  number of sequency   type of stimulus    stimulus   
             * stimulus color */
            var text = ProgramInUse.ProgramName + "\t" + participantName + "\t" + initialTime.Day + "/" +
                       initialTime.Month + "/" + initialTime.Year + "\t" + initialTime.Hour + ":" + initialTime.Minute +
                       ":" + initialTime.Second + ":" + initialTime.Millisecond.ToString() + "\t" + ExpositionTime.Hour + ":" + ExpositionTime.Minute +
                       ":" + ExpositionTime.Second + ":" + ExpositionTime.Millisecond.ToString() + "\t" + reactTime.ToString() +
                        "\t" + intervalTime.ToString() + "\t" + intervalShouldBe.ToString() + "\t" + expositionAccumulative + "\t" +
                        ProgramInUse.ExpositionTime +  "\t" + currentExposition + "\t" + position  + "\t"+ ProgramInUse.ExpositionType + "\t" +
                        currentStimulus + "\t" + ProgramInUse.StimulusColor;
             Output.Add(text); 
             
        }


    }
}
