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
        ReactionProgram programInUse = new ReactionProgram();
        string participantName;
        DateTime initialTime;
        List<DateTime> estimuluAppearedTime;
        List<DateTime> hitTime;

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

        public static void writeLineOutput(string nameStimulus, string color, int counter, List<string> output, 
                                           float elapsedTime, string expoType, string audioName, string hour, string minute, 
                                           string second)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
            /* var text = program.ProgramName + "\t" +
                        program.UserName + "\t" +
                        program.InitialDate.Day + "/" + program.InitialDate.Month + "/" + program.InitialDate.Year + "\t" +
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
             */
        }


    }
}
