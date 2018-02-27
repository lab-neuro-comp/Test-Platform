using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlatform.Controllers;
using TestPlatform.Models;

namespace TestPlatform.Views.ExperimentPages
{
    public partial class FormExperimentExposition : Form
    {
        private ExperimentTest executingTest = new ExperimentTest();
        private string path = Global.experimentTestFilesPath;
        private string outputDataPath = Global.experimentTestFilesPath + Global.resultsFolderName;
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private string outputFile;

        public FormExperimentExposition(string progamName, string participantName, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.ProgramInUse.Name = progamName;
            executingTest.ProgramInUse.ReadProgramFile();
            executingTest.Mark = mark;
            outputFile = outputDataPath + executingTest.ParticipantName + "_" + executingTest.ProgramInUse.Name + ".txt";
            this.Show();
            startExposition();
        }

        private async void startExposition()
        {
            await showInstructions();
            await startTesting();
        }

        /* this method shows each line of instruction recorded on file, in case there are any, waiting default instruction time*/
        private async Task showInstructions()
        {
            if (executingTest.ProgramInUse.InstructionText != null)
            {
                instructionLabel.Enabled = true; instructionLabel.Visible = true;
                for (int i = 0; i < executingTest.ProgramInUse.InstructionText.Count; i++)
                {
                    instructionLabel.Text = executingTest.ProgramInUse.InstructionText[i];
                    await Task.Delay(Program.instructionAwaitTime);
                }
                instructionLabel.Enabled = false; instructionLabel.Visible = false;
            }
            else
            {
                /*do nothing, experiment doesn't have any instruction to be shown*/
            }
        }

        private async Task startTesting()
        {
            if (executingTest.ProgramInUse.IsOrderRandom && !executingTest.ProgramInUse.TrainingProgram)
            {
                executingTest.ProgramInUse.Shuffle();
            }
            else if (executingTest.ProgramInUse.IsOrderRandom && executingTest.ProgramInUse.TrainingProgram)
            {
                executingTest.ProgramInUse.ShuffleWithTrainingProgram();
            }
            int index = 0;
            foreach (Program program in executingTest.ProgramInUse.ProgramList)
            {
                index++;
                await Task.Delay(executingTest.ProgramInUse.IntervalTime);
                executingTest.ExpositionTime = DateTime.Now;

                if (program.GetType() == typeof(StroopProgram))
                {
                    ExpositionController.BeginStroopTest(program.ProgramName, executingTest.ParticipantName, executingTest.Mark, this);
                }
                else if (program.GetType() == typeof(ReactionProgram))
                {
                    ExpositionController.BeginReactionTest(program.ProgramName, executingTest.ParticipantName, executingTest.Mark, this);
                }
                else if (program.GetType() == typeof(MatchingProgram))
                {
                    ExpositionController.BeginMatchingTest(program.ProgramName, executingTest.ParticipantName, executingTest.Mark, this);
                }
                executingTest.writeLineOutput(index, program);                
            }
            Program.writeOutputFile(outputFile, string.Join("\n", executingTest.Output.ToArray()));
            Close();
        }
    }
}
