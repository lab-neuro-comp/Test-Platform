using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using TestPlatform.Models.Tests;

namespace TestPlatform.Models
{
    /*
    * Class that represents results found while executing a test program (ExperimentProgram) and stores data from a partincipant test
    *
    */
    class ExperimentTest : Test
    {
        private ExperimentProgram programInUse = new ExperimentProgram();
        private List<string> output = new List<string>();
        private DateTime expositionTime;

        public ExperimentTest()
        {
            headerOutputFileText = LocRM.GetString("experimentHeader", currentCulture);
        }

        internal ExperimentProgram ProgramInUse
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

        public string HeaderOutputFileText
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

        public void writeLineOutput(int currentExposition, Program currentProgram)
        {
            /* This variable keeps data from an exposition to only one program on the list, being them:
             * program  name    participant     name    date    hour    exposition hour    hit time(ms) interval(ms)  interval should be(ms)  
             * exposition accumulative timeexposition time(ms)  number of sequency   type of stimulus    shape of stimulus   
             * stimulus color */
            string programType = null;
            if(currentProgram.GetType() == typeof(StroopProgram))
            {
                programType = "StroopTest";
            }
            else if (currentProgram.GetType() == typeof(ReactionProgram))
            {
                programType = "ReactionTest";
            }
            else if (currentProgram.GetType() == typeof(MatchingProgram))
            {
                programType = "MatchingTest";
            }
            string[] currentParticipant = participant();
            var text = programInUse.Name + "\t" + currentProgram.ProgramName + "\t" + programType + "\t" + currentParticipant[0] + "\t" +
                       currentParticipant[1] + "\t" + initialDate.Day + "/" +
                       initialDate.Month + "/" + initialDate.Year + "\t" + initialDate.Hour + ":" + initialDate.Minute +
                       ":" + initialDate.Second + ":" + initialDate.Millisecond.ToString() + "\t" + ExpositionTime.Hour + ":" + ExpositionTime.Minute +
                       ":" + ExpositionTime.Second + ":" + ExpositionTime.Millisecond.ToString() + "\t" + currentExposition;
            Output.Add(text);

        }
    }
}
