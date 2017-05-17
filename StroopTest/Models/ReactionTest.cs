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
        // todos os dados de horario devem guardar hora, minuto e segundo
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

        public void setProgramInUse(string path, string prgName)
        {
            if (File.Exists(path + "/prg/" + prgName + ".prg"))
            {
                programInUse.readProgramFile(path + "/prg/");
            }
            else
            {
                throw new Exception("Arquivo programa: " + programInUse.ProgramName + ".prg" +
                                    "\nnão foi encontrado no local:\n" + Path.GetDirectoryName(path + "/prg/"));
            }
        }

        public void writeLineOutput(long intervalTime, long reactTime, int currentExposition)
        {
            long elapsedTime = intervalTime + reactTime;

            /* programa\tparticipante\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tFormaDoStimulo\tCordoEstimulo\CordoPontodefixacao */
            var text = programInUse.ProgramName + "\t" + participantName + "\t" + initialTime.Day + "/" + 
                       initialTime.Month + "/" + initialTime.Year + "\t" + initialTime.Hour + ":" + initialTime.Minute + 
                       ":" + initialTime.Second + ":" + initialTime.Millisecond.ToString() + "\t" + elapsedTime.ToString() + "\t" +
                       currentExposition + "\t" + programInUse.ExpositionType + "\t" + programInUse.StimuluShape + "\t" +
                       programInUse.StimulusColor + "\t" + programInUse.FixPointColor;
             Output.Add(text); 
             
        }


    }
}
