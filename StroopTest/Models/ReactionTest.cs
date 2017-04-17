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


    }
}
