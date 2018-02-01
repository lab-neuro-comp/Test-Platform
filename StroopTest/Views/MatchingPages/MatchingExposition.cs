using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Controllers;
using TestPlatform.Models;

namespace TestPlatform.Views.MatchingPages
{
    public partial class MatchingExposition : Form
    {
        MatchingTest executingTest = new MatchingTest();
        private string path = Global.matchingTestFilesPath;
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private int[,] positions;
        private string outputFile;
        private string outputDataPath = Global.matchingTestFilesPath + Global.resultsFolderName;

        private PictureBox[] stimuluPictureBox;

        public MatchingExposition(string prgName, string participantName, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.setProgramInUse(path + "/prg/", prgName);
            executingTest.Mark = mark;
            stimuluPictureBox = new PictureBox[executingTest.ProgramInUse.NumExpositions];

            // initializes position propertie so that they become avaible for stimulus
            positions = new int[9, 2]{      {0, 0 }, //center position
                                            { (2 * executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize), 0 }, // on the right side of the screen
                                            { - (2 * executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize), 0 }, // on the left side of the screen
                                             { 0, ( - executingTest.ProgramInUse.StimuluDistance + executingTest.ProgramInUse.StimuluSize)}, // on top of the screen
                                             { 0, (executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize) }, // on bottom of the screen
                                             { - (2 * executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize),
                                                ( - executingTest.ProgramInUse.StimuluDistance + executingTest.ProgramInUse.StimuluSize)
                                             }, // on left top of the screen
                                             {  (2 * executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize),
                                                ( - executingTest.ProgramInUse.StimuluDistance + executingTest.ProgramInUse.StimuluSize)
                                             }, // on right top of the screen
                                             { - (2 * executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize),
                                                (executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize)
                                             }, // on left bottom of the screen
                                             { (2 * executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize),
                                                (executingTest.ProgramInUse.StimuluDistance - executingTest.ProgramInUse.StimuluSize)
                                             } // on right bottom of the screen                                             
                                     };

            outputFile = outputDataPath + executingTest.ParticipantName + "_" + executingTest.ProgramInUse.ProgramName + ".txt";
            startExposition();
        }

        private void startExposition()
        {

        }
    }
}
