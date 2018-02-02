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
        public class MatchingGroup
        {
            private Image modelImage;
            private Image[] stimulus;
            public MatchingGroup(Image modelImage, List<Image> stimulus)
            {
                this.modelImage = modelImage;
                this.stimulus = stimulus.ToArray();
            }
            public bool match(Image stimulus)
            {
                return modelImage.Equals(stimulus);
            }
            public Image getModelImage()
            {
                return modelImage;
            }
            public List<Image> getStimulusImages()
            {
                return stimulus.ToList();
            }
        }
        MatchingTest executingTest = new MatchingTest();
        private const int X = 0, Y = 1;
        private string path = Global.matchingTestFilesPath;
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private bool intervalCancelled;
        private int[,] positions;
        private bool exposing;
        private int intervalElapsedTime, intervalShouldBe, groupCounter = 0;
        private Object currentStimulus;
        private string outputFile;
        private string outputDataPath = Global.matchingTestFilesPath + Global.resultsFolderName;
        private string[] imageList;
        private long expositionAccumulative;
        private PictureBox modelPictureBox;
        private List<MatchingGroup> matchingGroups;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private List<Control> currentControl;
        int currentExposition;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private bool cancelExposition;
        private Stopwatch accumulativeStopWatch = new Stopwatch();
        private Stopwatch hitStopWatch;
        private bool showModel = true;
        private List<Control> stimuluPictureBox;

        public MatchingExposition(string prgName, string participantName, char mark)
        {
            matchingGroups = new List<MatchingGroup>();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.setProgramInUse(path + "/prg/", prgName);
            executingTest.Mark = mark;
            stimuluPictureBox = new List<Control>();

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
            if (executingTest.ProgramInUse.Ready(path))
            {
                initializeExposition();
            }
            else
            {
                if (!executingTest.ProgramInUse.Exists(path))
                {
                    throw new Exception(LocRM.GetString("file", currentCulture) + executingTest.ProgramInUse.ProgramName + ".prg" +
                                    LocRM.GetString("notFoundIn", currentCulture) + Path.GetDirectoryName(path + "/prg/"));
                }

                else
                {
                    // do nothing
                }

            }
        }

        private async void initializeExposition()
        {
            loadLists();
            await exposition();
        }

        private async Task exposition()
        {
            await showInstructions(this.cancellationTokenSource.Token);
            await Task.Delay(this.executingTest.ProgramInUse.AttemptsIntervalTime);
            if (!expositionControllerBW.IsBusy)
            {
                expositionControllerBW.RunWorkerAsync();
            }
        }

        private void loadLists()
        {
            this.imageList = this.executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();
            if (this.executingTest.ProgramInUse.ExpositionRandom)
            {
                imageList = ExpositionController.ShuffleArray(imageList, executingTest.ProgramInUse.AttemptsNumber, 3);
            }
            createMatchingGroups();
        }

        private void createMatchingGroups()
        {
            int nextImgIndex;
            Image nextImg;
            Random rng = new Random(int.Parse(this.seconds));
            List<Image> groupModels = new List<Image>();
            List<Image> groupStimulus = new List<Image>();
            for(int count = 0; count < this.executingTest.ProgramInUse.AttemptsNumber; count++)//define the models of the exposition
            {
                if(count == imageList.Length)
                {
                    count = 0;
                }
                groupModels.Add(Image.FromFile(imageList[count]));
            }
            foreach(Image image in groupModels) //each model has to have an stimulu group.
            {
                groupStimulus.Clear();
                groupStimulus.Add(image); //model should aways be part of stimulus
                for(int count = 0; count < this.executingTest.ProgramInUse.NumExpositions-1; count++)
                {
                    nextImgIndex = rng.Next(this.imageList.Length);
                    nextImg = Image.FromFile(imageList[nextImgIndex]);
                    if (!groupStimulus.Contains(nextImg)) //if image isnt in the group yet
                    {
                        groupStimulus.Add(nextImg); //adds it to group
                    }
                    else 
                    {
                        if (imageList.Length >= this.executingTest.ProgramInUse.NumExpositions - 1) //if image list have less elements then the stimulu number to be shown, then it's impossible to don't have duplicated items.
                        {
                            while (groupStimulus.Contains(nextImg)) //else, find an item that don't exist on list.
                            {
                                nextImgIndex = rng.Next(this.imageList.Length);
                                nextImg = Image.FromFile(imageList[nextImgIndex]);
                            }
                        }
                        groupStimulus.Add(nextImg);
                    }
                }
                matchingGroups.Add(new MatchingGroup(image, groupStimulus));
            }
        }

        private async Task showInstructions(CancellationToken cancellationToken)
        {
            if (executingTest.ProgramInUse.InstructionText != null)
            {
                List<string> instructions = executingTest.ProgramInUse.InstructionText;
                if (instructions != null || instructions.Count != 0)
                {
                    this.instructionLabel.Visible = true;
                    foreach (string instruction in instructions)
                    {
                        this.instructionLabel.Text = instruction;
                        await Task.Delay(Program.instructionAwaitTime);
                    }
                    this.instructionLabel.Visible = false;
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

        private void expositionControllerBW_DoWork(object sender, DoWorkEventArgs e)
        {
            /*define test initil time and start accumulative stopwatch*/
            executingTest.InitialTime = DateTime.Now;
            accumulativeStopWatch.Start();
            for(int count = 0; count < this.executingTest.ProgramInUse.AttemptsNumber; count++)
            {
                currentExposition = count;
                startExpositionBW();
                while (expositionBW.IsBusy)
                {
                    /*do nothing*/
                }
                startExpositionBW();
                while (expositionBW.IsBusy)
                {
                    /*do nothing*/
                }
                Thread.Sleep(1);
            }
        }

        private void startExpositionBW()
        {
            expositionBW = new BackgroundWorker();
            expositionBW.WorkerSupportsCancellation = true;
            expositionBW.WorkerReportsProgress = true;
            expositionBW.DoWork += new DoWorkEventHandler(expositionBW_DoWork);
            expositionBW.ProgressChanged += new ProgressChangedEventHandler(expositionBW_ProgressChanged);
            expositionBW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(expositionBW_RunWorkerCompleted);
            if (!expositionBW.IsBusy)
            {
                expositionBW.RunWorkerAsync();
            }
            else
            {
                /*do nothing*/
            }
        }



        private void expositionBW_DoWork(object sender, DoWorkEventArgs e)
        {
            int time;
            /*wait interval between attempts*/
            intervalElapsedTime = waitIntervalTime(executingTest.ProgramInUse.IntervalTimeRandom,
                executingTest.ProgramInUse.AttemptsIntervalTime);
            /*set exposition accumulative time and test exposition time*/
            executingTest.ExpositionTime = DateTime.Now;
            expositionAccumulative = accumulativeStopWatch.ElapsedMilliseconds;
            /*start reaction stopwatch*/
            hitStopWatch = new Stopwatch();
            hitStopWatch.Start();
            /*send mark keys*/
            SendKeys.SendWait(executingTest.Mark.ToString());

            drawExposition();

            if (intervalCancelled)
            {
                e.Cancel = true;
            }
            else
            {
                if (this.showModel)
                {
                    time = executingTest.ProgramInUse.ExpositionTime;
                }
                else
                {
                    time = executingTest.ProgramInUse.ModelExpositionTime;
                }
                while (hitStopWatch.ElapsedMilliseconds < time)
                {
                    if (expositionBW.CancellationPending)
                    {
                        hitStopWatch.Stop();
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        /* just wait for exposition time to be finished */
                    }
                }
            }
        }

        private int waitIntervalTime(bool isWaitTimeRandom, int waitTime)
        {
            int intervalTimeRandom = 200; // minimal rnd interval time
            intervalCancelled = false;

            // if random interval active, it will be a value between 200 and the defined interval time
            if (isWaitTimeRandom && waitTime > 400)
            {
                Random random = new Random();
                intervalTimeRandom = random.Next(400, waitTime);
            }
            else
            {
                intervalTimeRandom = waitTime;
            }

            Stopwatch intervalStopWatch = new Stopwatch();
            intervalStopWatch.Start();
            while (intervalStopWatch.ElapsedMilliseconds < intervalTimeRandom)
            {
                if (expositionBW.CancellationPending)
                {
                    intervalCancelled = true;
                    break;
                }
                /* just wait for interval time to be finished */
            }
            intervalShouldBe = intervalTimeRandom;
            intervalStopWatch.Stop();
            int elapsedTime = (int)intervalStopWatch.ElapsedMilliseconds;
            return elapsedTime;
        }

        private void drawExposition()
        {
            if (showModel)
            {
                drawModelImage();
            }
            else
            {
                waitIntervalTime(this.executingTest.ProgramInUse.IntervalTimeRandom, this.executingTest.ProgramInUse.IntervalTime);
                drawStimuluImage();
            }
        }

        private void drawModelImage()
        {
            List<Control> image = new List<Control>();
            showModel = false;
            modelPictureBox = new PictureBox();
            modelPictureBox.Size = new Size(executingTest.ProgramInUse.StimuluSize, executingTest.ProgramInUse.StimuluSize);
            int[] screenPosition = ScreenPosition(modelPictureBox.Size, "center");
            modelPictureBox.Location = new Point(screenPosition[X], screenPosition[Y]);
            modelPictureBox.Image = matchingGroups.ElementAt(groupCounter).getModelImage();
            currentStimulus = matchingGroups.ElementAt(groupCounter);
            modelPictureBox.Enabled = true;
            image.Add(modelPictureBox);
            expositionBW.ReportProgress(currentExposition / executingTest.ProgramInUse.AttemptsNumber * 100, image);
        }

        private void drawStimuluImage()
        {
            PictureBox newPicBox;
            showModel = true;
            stimuluPictureBox.Clear();
            foreach (Image img in matchingGroups.ElementAt(groupCounter).getStimulusImages())
            {
                newPicBox = new PictureBox();
                newPicBox.Size = new Size(executingTest.ProgramInUse.StimuluSize, executingTest.ProgramInUse.StimuluSize);
                int[] screenPosition = randomScreenPosition(newPicBox.Size);
                newPicBox.Location = new Point(screenPosition[X], screenPosition[Y]);
                newPicBox.Image = img;
                currentStimulus = matchingGroups.ElementAt(groupCounter);
                newPicBox.Enabled = true;
                stimuluPictureBox.Add(newPicBox);
            }
            groupCounter++;
            if(groupCounter > this.executingTest.ProgramInUse.AttemptsNumber)
            {
                groupCounter = 0;
            }
            expositionBW.ReportProgress(currentExposition / executingTest.ProgramInUse.AttemptsNumber * 100, stimuluPictureBox);
        }

        private int[] randomScreenPosition(Size item)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int[] screen = new int[2];
            screen[X] = rand.Next(ClientSize.Width);
            screen[Y] = rand.Next(ClientSize.Height);
            screen[X] = rand.Next(ClientSize.Width - item.Width);
            screen[Y] = rand.Next(ClientSize.Height - item.Height);
            return screen;
        }

        private int[] ScreenPosition(Size size, string key)
        {
            switch (key)
            {
                case "center":
                    return centerShapePosition(size);
                default:
                    throw new Exception(LocRM.GetString("positionInvalid", currentCulture));
            }
        }

        private void expositionControllerBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("controls antes: " + this.Controls.Count.ToString());
            List<Control> controls = (List<Control>)e.UserState;
            foreach (Control c in controls)
            {
                if (exposing)
                {
                    this.Controls.Add(c);
                }
                else
                {
                    this.Controls.Remove(c);
                }
            }
            Console.WriteLine("controls depois: " + this.Controls.Count.ToString());
        }

        private void expositionControllerBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                /* exposition was a success*/
                Program.writeOutputFile(outputFile, string.Join("\n", executingTest.Output.ToArray()));
                if (Application.OpenForms.OfType<MatchingExposition>().Any())
                {
                    Close();
                }
            }
            else
            {
                /* there was an error while doing exposition */
            }
        }

        private void MatchingExposition_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                CancelExposition();
            }
        }

        private void SendUserResponse(string keyName)
        {
            if (expositionBW.WorkerSupportsCancellation == true)
            {
                expositionBW.CancelAsync();
            }
        }

        private void CancelExposition()
        {
            cancelExposition = true;
            if (expositionBW.IsBusy)
            {
                expositionBW.CancelAsync();
            }
            else if (expositionControllerBW.IsBusy)
            {
                expositionControllerBW.CancelAsync();
            }
            else
            {
                /*do nothing*/
            }
            while (expositionBW.CancellationPending && expositionControllerBW.CancellationPending)
            {
                //wait
                Thread.Sleep(10);
            }
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm is MatchingExposition)
                {
                    Close();
                }
            }
        }

        /* creates a x and y vector on center of the screen */
        private int[] centerShapePosition(Size size)
        {
            float[] clientMiddle = { (ClientSize.Width / 2), (ClientSize.Height / 2) };
            return new int[] { (int)clientMiddle[X] - (size.Width / 2), (int)clientMiddle[Y] - (size.Height / 2) };
        }

        private void expositionBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exposing = true;
            currentControl = (List<Control>)e.UserState;
            expositionControllerBW.ReportProgress(20, (List<Control>)e.UserState);
        }

        private void expositionBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!cancelExposition)
            {
                if (ActiveForm != null)
                {
                    this.CreateGraphics().Clear(ActiveForm.BackColor);
                }
                // if expositions type uses any kind of control to show stimulus such as a word label or image picture box 
                if (currentControl != null)
                {
                    // if current control is enabled it means that just showed a stimulus
                    if (currentControl[0].Enabled)
                    {
                        // signaling to interval background worker that exposing must end and control must be removed from screen
                        exposing = false;
                        expositionControllerBW.ReportProgress(50, currentControl);
                    }
                }
            }
            else
            {
                /*do nothing*/
            }

            if ((e.Cancelled == true) && !intervalCancelled)
            {
                //executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, 0, currentExposition + 1, expositionAccumulative, currentStimulus, position_converter(currentPosition), currentBeep);
                /* user clicked after stimulus is shown*/
            }

            else
            {
                /* user missed stimulus */
                //executingTest.writeLineOutput(intervalElapsedTime, intervalShouldBe, 0, currentExposition + 1, expositionAccumulative, currentStimulus, position_converter(currentPosition), currentBeep);
                hitStopWatch.Stop();
            }
            expositionBW.Dispose();
        }
    }
}
