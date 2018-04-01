using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Models
{
    class MatchingTest
    {
        private static String headerOutputFileText;
        private Char mark;
        private MatchingProgram programInUse = new MatchingProgram();
        private string participantName;
        private DateTime initialTime;
        private DateTime expositionTime;
        private List<string> output = new List<string>();
        // properties used to localize strings during runtime
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        
        public MatchingTest()
        {
            headerOutputFileText = LocRM.GetString("matchingTestHeader", currentCulture);
        }

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

        internal MatchingProgram ProgramInUse
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
                ProgramInUse = new MatchingProgram(programFile);
            }
            else
            {
                throw new Exception(LocRM.GetString("file", currentCulture) + ProgramInUse.ProgramName + ".prg" +
                                    LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(path + "/prg/"));
            }
        }

        public void writeLineOutput(long attemptIntervalTime, long stimuluIntervalTime, long modelReactTime, long stimuluReactTime, int currentExposition, 
            long modelExpositionAccumulative, long stimuluExpositionAccumulative, string modelFirstposition, string modelSecondPosition, string testType, string match, 
            string model, string currentList, string[] stimulus, string stimuluPosition, string stimuluType, string modelColor, string clickedStimuluColor)
        {
            string text = ProgramInUse.ProgramName + "\t" +
                        participantName + "\t" +
                        initialTime.Day + "/" + initialTime.Month + "/" + initialTime.Year + "\t" +
                        initialTime.Hour + ":" + initialTime.Minute + ":" + initialTime.Second + ":" + initialTime.Millisecond.ToString() + "\t" +
                        ExpositionTime.Hour + ":" + ExpositionTime.Minute + ":" + ExpositionTime.Second + ":" + ExpositionTime.Millisecond.ToString() + "\t" +
                        modelReactTime.ToString() + "\t" +
                        stimuluReactTime.ToString() + "\t" +
                        attemptIntervalTime.ToString() + "\t" +
                        stimuluIntervalTime.ToString() + "\t" +
                        modelExpositionAccumulative + "\t" +
                        stimuluExpositionAccumulative + "\t" +
                        currentExposition + "\t" +
                        testType + "\t" +
                        stimuluType + "\t" +
                        currentList + "\t" +
                        modelFirstposition + "\t" +
                        model + "\t" +
                        modelColor + "\t" +
                        stimulus[0] + "\t" +
                        stimulus[1] + "\t" +
                        stimulus[2] + "\t" +
                        stimulus[3] + "\t" +
                        stimulus[4] + "\t" +
                        stimulus[5] + "\t" +
                        stimulus[6] + "\t" +
                        modelSecondPosition + "\t" +
                        stimulus[7] + "\t" +
                        clickedStimuluColor + "\t" +
                        stimuluPosition + "\t" +
                        match;
            Output.Add(text);

        }


    }
}
