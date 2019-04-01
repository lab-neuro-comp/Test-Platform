using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models.Tests.SpacialRecognition
{
    class SpacialRecognitionTest : Test
    {
        private List<string> output = new List<string>();
        private DateTime expositionTime;
        public SpacialRecognitionProgram ProgramInUse;

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

        public void WriteLineOutput(long attemptIntervalTime, long stimuluIntervalTime, long reactTime, int currentExposition,
            long expositionAccumulative, string match,
            string model, string currentList, string stimuluType, string modelColor, string clickedStimuluLocation,
            string lastStimuluLocation)
        {
            string[] currentParticipant = participant();
            string text = ProgramInUse.ProgramName + "\t" +
                        currentParticipant[0] + "\t" +
                        currentParticipant[1] + "\t" +
                        initialDate.Day + "/" + initialDate.Month + "/" + initialDate.Year + "\t" +
                        initialDate.Hour + ":" + initialDate.Minute + ":" + initialDate.Second + ":" + initialDate.Millisecond.ToString() + "\t" +
                        ExpositionTime.Hour + ":" + ExpositionTime.Minute + ":" + ExpositionTime.Second + ":" + ExpositionTime.Millisecond.ToString() + "\t" +
                        reactTime.ToString() + "\t" +
                        attemptIntervalTime.ToString() + "\t" +
                        stimuluIntervalTime.ToString() + "\t" +
                        expositionAccumulative + "\t" +
                        currentExposition + "\t" +
                        stimuluType + "\t" +
                        currentList + "\t" +
                        model + "\t" +
                        modelColor + "\t" +
                        lastStimuluLocation + "\t" +
                        clickedStimuluLocation + "\t" +
                        match;
            Output.Add(text);
        }

        public void setProgramInUse(string prgName)
        {
            if (SpacialRecognitionProgram.ProgramExists(prgName))
            {
                ProgramInUse = new SpacialRecognitionProgram(prgName);
            }
            else
            {
                throw new Exception(LocRM.GetString("file", currentCulture) + ProgramInUse.ProgramName + ".prg" +
                                    LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(MatchingProgram.GetProgramsPath()));
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
    }
}
