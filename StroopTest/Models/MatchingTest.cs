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

        public void writeLineOutput(long intervalTime, long intervalShouldBe, long reactTime, int currentExposition, long expositionAccumulative, string currentStimulus, string position, string testType, bool match)
        {
            /* This variable keeps data from an exposition to only one stimulus, being them:
             * Program\tParticipant\tDate\tInitial Time\tExposition Time\tReaction Time(ms)\tInterval(ms)\tEstimated Interval(ms)\tExposition Duration(ms)\tExposition(ms)\tSenquency\tPos\tTest Type\tStimulus Type\tStimulus\Match
             * Program\tParticipant\tDate\tInitial Time\tExposition Time\tReaction Time(ms)\tInterval(ms)\tEstimated Interval(ms)\tExposition Duration(ms)\tExposition(ms)\tSenquency\tPos\tTest Type\tStimulus Type\tStimulus\tMatch
             * program name | participant name| date | hour | exposition hour | hit time(ms) | interval(ms) | interval should be(ms) | exposition accumulative time |exposition time(ms) | number of sequency | position on screen | type of test | type of stimulus | stimulus | Match */
            var text =  ProgramInUse.ProgramName + "\t" + 
                        participantName + "\t" + 
                        initialTime.Day + "/" + initialTime.Month + "/" + initialTime.Year + "\t" + 
                        initialTime.Hour + ":" + initialTime.Minute + ":" + initialTime.Second + ":" + initialTime.Millisecond.ToString() + "\t" + 
                        ExpositionTime.Hour + ":" + ExpositionTime.Minute + ":" + ExpositionTime.Second + ":" + ExpositionTime.Millisecond.ToString() + "\t" + 
                        reactTime.ToString() + "\t" + 
                        intervalTime.ToString() + "\t" + 
                        intervalShouldBe.ToString() + "\t" + 
                        expositionAccumulative + "\t" +
                        ProgramInUse.ExpositionTime + "\t" + 
                        currentExposition + "\t" + 
                        position + "\t" + 
                        testType + "\t" + 
                        LocRM.GetString("image", currentCulture) + "\t" +
                        currentStimulus + "\t" + 
                        match.ToString();
            Output.Add(text);

        }



    }
}
