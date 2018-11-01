using TestPlatform.Models;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Globalization;
using TestPlatform.Models.Tests;

namespace TestPlatform.Models
{
    /*
    * Class that represents results found while executing a test program (StroopProgram) and stores data from a partincipant test
    *
    */
    class StroopTest : Test
    {
        internal StroopProgram ProgramInUse { get; set; }

        public StroopTest(String programName)
        {
            // used to localize strings during runtime
            ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;
            this.ProgramInUse = new StroopProgram(programName);
            headerOutputFileText = LocRM.GetString("stroopResultHeader", currentCulture);
        }

        public void writeLineOutputResult(string nameStimulus, string color, int counter,
                                   List<string> output, float elapsedTime, string audioName)
        {
            // programa\tusuario\tdata\thorario\ttempo(ms)\tsequencia\ttipoEstimulo\tlegenda\tposicaoLegenda\testimulo\tcor
            string[] currentParticipant = participant();

            var text = ProgramInUse.ProgramName + "\t" + currentParticipant[0] + "\t" +
                       currentParticipant[1] + "\t" +
                       InitialDate.Day + "/" + InitialDate.Month + "/" + InitialDate.Year + "\t" +
                       DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond + "\t" +
                       elapsedTime.ToString() + "\t" +
                       counter + "\t" +
                       ProgramInUse.ExpositionType + "\t" +
                       ProgramInUse.SubtitleShow.ToString().ToLower() + "\t" +
                       ProgramInUse.SubtitlePlace + "\t" +
                       nameStimulus + "\t" +
                       color + "\t" +
                       audioName;

            output.Add(text);
        }
    }
}
