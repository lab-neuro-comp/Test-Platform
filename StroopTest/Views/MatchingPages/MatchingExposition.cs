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
            private string model, modelColor;
            private string[] stimulus;
            private string[] colors;
            public MatchingGroup(string model, List<string> stimulus, List<string> colors, string modelColor)
            {
                if(colors.Count > 0)
                {
                    this.colors = colors.ToArray();
                }
                else
                {
                    this.colors = null;
                }
                this.modelColor = modelColor;
                this.model = model;
                this.stimulus = stimulus.ToArray();
            }

            public string getModelColor()
            {
                return modelColor;
            }

            public bool match(string stimulus)
            {
                return model.Equals(stimulus);
            }

            public void shuffleStimulus()
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                var zipped = stimulus.Zip(colors, (a, b) => new { a, b }).ToList();
                var shuffled = zipped.OrderBy(x => rnd.Next()).ToArray();
                stimulus = shuffled.Select(pair => pair.a).ToArray();
                colors = shuffled.Select(pair => pair.b).ToArray();
            }

            public string getModelName()
            {
                return model;
            }

            public string[] getStimulusNames()
            {
                return stimulus;
            }

            public string[] getColors()
            {
                return colors;
            }

            public string getControlName(Control control, int stimuluType)
            {
                int count;
                for (count = 0; count < stimulus.Length; count++)
                {
                    if (stimuluType == 0 && stimulus[count].Equals(((PictureBox)control).Tag))
                    {
                        break;
                    }
                    else if(stimulus[count].Equals(((Control)control).Text))
                    {
                        break;
                    }
                }
                return stimulus[count];
            }

        }

        StimulusPosition stimuluPosition;
        string modelFirstposition, modelSecondPosition;
        MatchingTest executingTest = new MatchingTest();
        private const int X = 0, Y = 1;
        private string path = Global.matchingTestFilesPath;
        private string hour = DateTime.Now.Hour.ToString("00");
        private string minutes = DateTime.Now.Minute.ToString("00");
        private string seconds = DateTime.Now.Second.ToString("00");
        private string startTime;
        private bool intervalCancelled;
        private bool exposing;
        private int intervalElapsedTime, intervalShouldBe, groupCounter = 0;
        private Object currentStimulus;
        private string outputFile;
        private string outputDataPath = Global.matchingTestFilesPath + Global.resultsFolderName;
        private string[] imageList, wordList, colorList;
        private long expositionAccumulative;
        private long modelExpositionAccumulative;
        private Control modelAsStimuluControl;
        private Control modelControl, newStimulu;
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
        private List<Control> stimuluControls;
        private bool waitingExpositionEnd;
        string currentExpositionType;
        private Control objectClicked;
        private bool showAudioFeedbackOnNextClick = false;
        private long modelReactTime;
        bool shouldChangeExpositionType = false;
        bool shouldRandomizeExpositionType = false;
        private long attemptIntervalTime;
        private int stimuluType;
        Random randGen = new Random(Guid.NewGuid().GetHashCode());

        public MatchingExposition(string prgName, string participantName, char mark)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.Manual;
            ExpositionController.formSecondScreen(this);

            InitializeComponent();
            startTime = hour + "_" + minutes + "_" + seconds;
            executingTest.ParticipantName = participantName;
            executingTest.setProgramInUse(path + "/prg/", prgName);
            executingTest.Mark = mark;

            stimuluControls = new List<Control>();
            outputFile = outputDataPath + executingTest.ParticipantName + "_" + executingTest.ProgramInUse.ProgramName + ".txt";
            startExposition();
            this.ShowDialog();
        }

        private void startExposition()
        {
            if (executingTest.ProgramInUse.Ready(path))
            {
                currentExpositionType = this.executingTest.ProgramInUse.getExpositionType();
                if(this.currentExpositionType == LocRM.GetString("alternatingDMTS_DNMTS", currentCulture))
                {
                    shouldChangeExpositionType = true;
                    this.currentExpositionType = "DMTS";
                }
                if (this.currentExpositionType == LocRM.GetString("randomDMTS_DNMTS", currentCulture))
                {
                    int rand = randGen.Next(2);
                    shouldRandomizeExpositionType = true;
                    if (rand == 0)
                    {
                        this.currentExpositionType = "DMTS";
                    }
                    else
                    {
                        this.currentExpositionType = "DNMTS";
                    }
                }
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

        private void defineStimuluType()
        {
            if (this.executingTest.ProgramInUse.getImageListFile() != null)
            {
                this.stimuluType = 0; /*Images*/
            }
            else if (this.executingTest.ProgramInUse.getColorListFile() != null)
            {
                this.stimuluType = 2; /*Words*/
            }
            else
            {
                this.stimuluType = 1; /*Words and color*/
            }
        }

        private void loadLists()
        {
            defineStimuluType();
            matchingGroups = new List<MatchingGroup>();

            if (this.stimuluType == 0)
            {
                this.imageList = this.executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();
                if (this.executingTest.ProgramInUse.ExpositionRandom)
                {
                    imageList = ExpositionController.ShuffleArray(imageList, imageList.Length, Guid.NewGuid().GetHashCode());
                }
            }
            else if (this.stimuluType == 1 || this.stimuluType == 2)
            {
                this.wordList = this.executingTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                if (this.executingTest.ProgramInUse.ExpositionRandom)
                {
                    wordList = ExpositionController.ShuffleArray(wordList, wordList.Length, Guid.NewGuid().GetHashCode());
                }
                if (this.stimuluType == 2)
                {
                    this.colorList = this.executingTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    if (this.executingTest.ProgramInUse.ExpositionRandom)
                    {
                        colorList = ExpositionController.ShuffleArray(colorList, colorList.Length, Guid.NewGuid().GetHashCode());
                    }
                }
                else
                {
                    this.colorList = new string[1];
                    colorList[0] = this.executingTest.ProgramInUse.WordColor;
                }
            }
            else throw new InvalidOperationException();
            createMatchingGroups();
        }

        private string[] getCurrentList()
        {
            switch (stimuluType)
            {
                case 0:
                    return imageList;
                case 1: case 2:
                    return wordList;
                default:
                    throw new Exception();
            }
        }

        private void createMatchingGroups()
        {
            MatchingGroup nextGroup;
            string[] currentList = null;
            currentList = getCurrentList();
            List<string> colors = new List<string>();
            bool willHaveRepetition = (currentList.Length < this.executingTest.ProgramInUse.StimuluNumber * this.executingTest.ProgramInUse.AttemptsNumber);
            int modelCounter = 0, stimuluCounter = 0, colorsCount =0;
            int[] startingIndex = new int[2];
            Random rng = new Random(int.Parse(this.seconds));
            string[] groupModelsName = new string[this.executingTest.ProgramInUse.AttemptsNumber];
            string[] groupModelsColors = new string[this.executingTest.ProgramInUse.AttemptsNumber];
            string[] groupStimulusColors = new string[this.executingTest.ProgramInUse.StimuluNumber];
            string[] groupStimulusName = new string[this.executingTest.ProgramInUse.StimuluNumber];
            bool[] itemCanBeUsed = new bool[currentList.Length];
            for (int i = 0; i < currentList.Length; i++)
            {
                itemCanBeUsed[i] = true;
            }
            for (int count = 0; modelCounter < this.executingTest.ProgramInUse.AttemptsNumber; count++)//define the models of the exposition
            {
                if (count >= currentList.Length) // prevent out of range exception
                {
                    count = 0;
                }
                itemCanBeUsed[count] = false;

                if (stimuluType == 0)
                {
                    groupModelsName[modelCounter] = currentList[count];

                }
                else if(stimuluType == 1 || stimuluType == 2)
                {
                    groupModelsName[modelCounter] = currentList[count];
                    if(colorsCount >= colorList.Length)
                    {
                        colorsCount = 0;

                    }
                    groupModelsColors[modelCounter] = colorList[colorsCount++];
                }
                modelCounter++;
                startingIndex[0] = count;
                startingIndex[1] = colorsCount;
            }
            
            for (int group = 0; group < groupModelsName.Length; group++)
            {
                for (int count = 1; count < this.executingTest.ProgramInUse.StimuluNumber; count++)
                {
                    groupStimulusName[count] = null;
                    groupStimulusColors[count] = null;
                }
                stimuluCounter = startingIndex[0];
                colorsCount = startingIndex[1];
                groupStimulusName[0] = groupModelsName[group];
                groupStimulusColors[0] = groupModelsColors[group];
                for (int count = 1; count < this.executingTest.ProgramInUse.StimuluNumber; count++)
                {
                    if (stimuluCounter >= currentList.Length)
                    {
                        stimuluCounter = 0;
                    }
                    if (currentList.Length >= this.executingTest.ProgramInUse.StimuluNumber)
                    {
                        if (!willHaveRepetition)
                        {
                            while (!itemCanBeUsed[stimuluCounter])
                            {
                                if(stimuluCounter >= itemCanBeUsed.Length)
                                {
                                    stimuluCounter = 0;
                                }
                                stimuluCounter++;
                            }
                        }
                        else
                        {
                            string name = currentList[stimuluCounter];
                            while (groupStimulusName.Contains(name))
                            {
                                stimuluCounter++;
                                if (stimuluCounter >= itemCanBeUsed.Length)
                                {
                                    stimuluCounter = 0;
                                }
                                name = currentList[stimuluCounter];
                            }
                        }
                    }
                    if (stimuluType == 0)
                    {
                        groupStimulusName[count] = currentList[stimuluCounter];

                    }
                    else if (stimuluType == 1 || stimuluType == 2)
                    {
                        groupStimulusName[count] = currentList[stimuluCounter];
                        if (colorsCount >= colorList.Length)
                        {
                            colorsCount = 0;
                        }
                        if(stimuluType == 2 && colorList != null)
                        {
                            groupStimulusColors[count] = colorList[colorsCount];
                        }
                    }
                    colorsCount++;
                    stimuluCounter++;
                    if (colorList != null && colorsCount >= colorList.Length)
                    {
                        colorsCount = 0;
                    }
                }
                nextGroup = new MatchingGroup(groupModelsName[group], groupStimulusName.ToList(), groupStimulusColors.ToList(), groupModelsColors[group]);
                if (this.executingTest.ProgramInUse.ExpositionRandom)
                {
                    nextGroup.shuffleStimulus();
                }
                matchingGroups.Add(nextGroup);
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
            executingTest.InitialDate = DateTime.Now;
            accumulativeStopWatch.Start();
            for (int count = 0; count < this.executingTest.ProgramInUse.AttemptsNumber * 2; count++)
            {
                changeBackgroundColor();
                startExpositionBW();
                currentExposition = count++;
                while (expositionBW.IsBusy)
                {
                    /*do nothing*/
                }
                startExpositionBW();
                currentExposition = count;
                while (expositionBW.IsBusy)
                {
                    /*do nothing*/
                }
                if (shouldChangeExpositionType)
                {

                    if (currentExpositionType == "DMTS")
                    {
                        currentExpositionType = "DNMTS";
                    }
                    else
                    {
                        currentExpositionType = "DMTS";
                    }
                    changeBackgroundColor();
                }
                if (shouldRandomizeExpositionType)
                {
                    int rand = randGen.Next(2);
                    if (rand == 0)
                    {
                        this.currentExpositionType = "DMTS";
                    }
                    else
                    {
                        this.currentExpositionType = "DNMTS";
                    }
                }
                Thread.Sleep(10);
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
            attemptIntervalTime = waitIntervalTime(executingTest.ProgramInUse.IntervalTimeRandom,
                executingTest.ProgramInUse.AttemptsIntervalTime);
            /*set exposition accumulative time and test exposition time*/
            executingTest.ExpositionTime = DateTime.Now;
            if (showModel)
            {
                expositionAccumulative = accumulativeStopWatch.ElapsedMilliseconds;
            }
            else
            {
                modelExpositionAccumulative = accumulativeStopWatch.ElapsedMilliseconds;
            }

            /*send mark keys*/
            if (!cancelExposition)
            {
                SendKeys.SendWait(executingTest.Mark.ToString());
            }

            drawExposition();

            /*start reaction stopwatch*/
            hitStopWatch = new Stopwatch();
            hitStopWatch.Start();

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
            waitingExpositionEnd = true;
            if (showModel)
            {
                stimuluPosition = new StimulusPosition(ClientSize, 1);
                drawModel();
            }
            else
            {
                if (!this.executingTest.ProgramInUse.RandomStimulusPosition)
                {
                    stimuluPosition = new StimulusPosition(ClientSize, this.executingTest.ProgramInUse.StimuluNumber);
                }
                intervalElapsedTime = waitIntervalTime(this.executingTest.ProgramInUse.RandomIntervalModelStimulus, this.executingTest.ProgramInUse.IntervalTime);
                drawStimulu();
            }
        }

        private void changeBackgroundColor()
        {
            if (currentExpositionType == "DMTS")
            {
                this.BackColor = ColorTranslator.FromHtml(executingTest.ProgramInUse.BackgroundColor);
            }
            else
            {
                this.BackColor = ColorTranslator.FromHtml(executingTest.ProgramInUse.DNMTSBackground);
            }
        }

        private void drawModel()
        {
            Size size;
            List<Control> controls = new List<Control>();
            showModel = false;
            if (stimuluType == 1 || stimuluType == 2)
            {
                modelControl = ExpositionController.InitializeButton(matchingGroups.ElementAt(groupCounter).getModelName());
                modelControl.Font = new Font("Arial", this.executingTest.ProgramInUse.StimuluSize, FontStyle.Bold);
                modelControl.ForeColor = ColorTranslator.FromHtml(matchingGroups.ElementAt(groupCounter).getModelColor());

                size = modelControl.PreferredSize;
            }
            else
            {
                modelControl = ExpositionController.InitializeImageBox(executingTest.ProgramInUse.StimuluSize, 
                                                                        Image.FromFile(matchingGroups.ElementAt(groupCounter).getModelName()), false, this);
                size = modelControl.Size;
            }
           
            if (this.executingTest.ProgramInUse.RandomModelPosition)
            {
                modelControl.Location = stimuluPosition.getRandomPosition(size);
            }
            else
            {
                Point position = stimuluPosition.getPositon(size);
                modelControl.Location = position;
            }
            currentStimulus = matchingGroups.ElementAt(groupCounter);

            if (executingTest.ProgramInUse.EndExpositionWithClick)
            {
                modelControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MatchingExposition_MouseClick);
            }
            else
            {
                modelControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.wrongClick_mouseClick);
            }
            controls.Add(modelControl);
            expositionBW.ReportProgress(currentExposition / (executingTest.ProgramInUse.AttemptsNumber * 2) * 100, controls);
        }

        private void drawStimulu()
        {
            int count = 0;
            Size size;
            showModel = true;
            stimuluControls.Clear();
            foreach (string element in matchingGroups.ElementAt(groupCounter).getStimulusNames())
            {
                if (stimuluType == 1 || stimuluType == 2)
                {
                    newStimulu = ExpositionController.InitializeButton(element);
                    newStimulu.Font = new Font("Arial", this.executingTest.ProgramInUse.StimuluSize, FontStyle.Bold);
                    newStimulu.ForeColor = ColorTranslator.FromHtml(matchingGroups.ElementAt(groupCounter).getColors().ElementAt(count));

                    size = modelControl.PreferredSize;
                }
                else
                {
                    newStimulu = ExpositionController.InitializeImageBox(executingTest.ProgramInUse.StimuluSize, Image.FromFile(element), false, this);
                    newStimulu.Tag = element;
                    size = modelControl.Size;
                }

                if (this.executingTest.ProgramInUse.RandomStimulusPosition)
                {
                    newStimulu.Location = stimuluPosition.getRandomPosition(size);
                }
                else
                {
                    newStimulu.Location = stimuluPosition.getPositon(size);
                }
                if (matchingGroups.ElementAt(groupCounter).getModelName().Equals(element))
                {
                    modelAsStimuluControl = newStimulu;
                }
                currentStimulus = matchingGroups.ElementAt(groupCounter);
                newStimulu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MatchingExposition_MouseClick);
                stimuluControls.Add(newStimulu);
                count++;
            }
            groupCounter++;
            if (groupCounter > this.executingTest.ProgramInUse.AttemptsNumber)
            {
                groupCounter = 0;
            }
            expositionBW.ReportProgress(currentExposition / (executingTest.ProgramInUse.AttemptsNumber * 2) * 100, stimuluControls);
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

        private void expositionControllerBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
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
                if (this.executingTest.ProgramInUse.ExpositionAudioResponse && exposing && !cancelExposition)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.bell);
                    player.Play();
                }
            }
            catch(Exception)
            {
                /*do nothing*/
            }
        }

        private void expositionControllerBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = "";
            if (e.Error == null)
            {
                /* exposition was a success*/
                do
                {
                    result = string.Join("\n", executingTest.Output.ToArray());
                } while (result == "");
                Program.writeOutputFile(outputFile, result);
                if (Application.OpenForms.OfType<MatchingExposition>().Any())
                {
                    Close();
                }
            }
            else
            {
                /* there was an error while doing exposition */
            }
            CancelExposition();
        }

        private void MatchingExposition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CancelExposition();
            }
        }


        private void SendUserResponse(Control objectClicked)
        {
            if (expositionBW.WorkerSupportsCancellation == true)
            {
                this.objectClicked = objectClicked;
                expositionBW.CancelAsync();
            }
        }

        private void CancelExposition()
        {
            cancelExposition = true;
            if (expositionBW.IsBusy && !waitingExpositionEnd)
            {
                expositionBW.CancelAsync();
            }
            else if (expositionControllerBW.IsBusy && !waitingExpositionEnd)
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

        private void wrongClick_mouseClick(object sender, MouseEventArgs e)
        {
            if (this.executingTest.ProgramInUse.CommissionAudioResponse)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void MatchingExposition_MouseClick(object sender, MouseEventArgs e)
        {
            if (showAudioFeedbackOnNextClick)
            {
                if(this.currentExpositionType == "DMTS")
                {
                    playDMTSFeedbackSound(sender);
                }
                else
                {
                    playDNMTSFeedbackSound(sender);
                }
            }
            SendUserResponse((Control)sender);
        }

        private void playDMTSFeedbackSound(object sender)
        {
            if (executingTest.ProgramInUse.FeedbackAudioResponse)
            {
                System.Media.SoundPlayer player;
                if (this.matchingGroups.ElementAt(groupCounter - 1).getControlName((Control)sender, this.stimuluType) == this.matchingGroups.ElementAt(groupCounter - 1).getModelName())
                {
                    player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.hit);
                }
                else
                {
                    player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.error);
                }
                player.Play();
            }
        }

        private void playDNMTSFeedbackSound(object sender)
        {
            if (executingTest.ProgramInUse.FeedbackAudioResponse)
            {
                System.Media.SoundPlayer player;
                if (this.matchingGroups.ElementAt(groupCounter - 1).getControlName((Control)sender, this.stimuluType) != this.matchingGroups.ElementAt(groupCounter - 1).getModelName())
                {
                    player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.hit);
                }
                else
                {
                    player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.error);
                }
                player.Play();
            }
        }
        
        private String getForeColor(Control control)
        {
            string color = "";
            if(this.stimuluType == 0)
            {
                color = "-";
            }
            else if(this.stimuluType == 1 || this.stimuluType == 2)
            {
                color = ColorTranslator.ToHtml(control.ForeColor);
            }
            return color;
        }

        private void expositionBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exposing = true;
            currentControl = (List<Control>)e.UserState;
            expositionControllerBW.ReportProgress(20, (List<Control>)e.UserState);
        }

        private string getStimuluType()
        {
            string type = "";
            if(this.stimuluType == 0)
            {
                type = LocRM.GetString("image", currentCulture);
            }
            else if (this.stimuluType == 1)
            {
                type = LocRM.GetString("word", currentCulture);
            }
            else if(this.stimuluType == 2)
            {
                type = LocRM.GetString("wordWithColor", currentCulture);
            }
            return type;
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
                    if (currentControl[0].Enabled || currentControl[0].Visible)
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
            if (!cancelExposition)
            {
                Size size = new Size();
                string currentList;
                StrList list = this.executingTest.ProgramInUse.getImageListFile();
                if (list != null)
                {
                    currentList = list.ListName;
                }
                else {
                    list = this.executingTest.ProgramInUse.getWordListFile();
                    if (list != null)
                    {
                        currentList = list.ListName;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                if (showModel) 
                {
                    if (modelAsStimuluControl != null)
                    {
                        if(this.stimuluType == 0)
                        {
                            size = modelAsStimuluControl.Size;
                        }
                        else
                        {
                            size = modelAsStimuluControl.PreferredSize;
                        }
                        modelSecondPosition = stimuluPosition.getStimulusPositionMap(modelAsStimuluControl.Location, size);
                    }
                    List<string> stimulus = this.matchingGroups.ElementAt(groupCounter - 1).getStimulusNames().ToList();
                    stimulus.Remove(this.matchingGroups.ElementAt(groupCounter - 1).getModelName());
                    for (int count = 0; count < stimulus.Count; count++)
                    {
                        stimulus[count] = Path.GetFileNameWithoutExtension(stimulus[count]);
                    }
                    while (stimulus.Count <= 7)
                    {
                        stimulus.Add("-");
                    }
                    if ((e.Cancelled == true) && !intervalCancelled) /* user clicked after stimulus is shown*/
                    {
                        stimulus[7] = Path.GetFileNameWithoutExtension(this.matchingGroups.ElementAt(groupCounter - 1).getControlName(objectClicked, stimuluType));
                        executingTest.WriteLineOutput(
                            attemptIntervalTime,
                            intervalElapsedTime,
                            modelReactTime,
                            hitStopWatch.ElapsedMilliseconds,
                            currentExposition + 1,
                            modelExpositionAccumulative,
                            expositionAccumulative,
                            modelFirstposition,
                            modelSecondPosition,
                            currentExpositionType,
                            (this.matchingGroups.ElementAt(groupCounter - 1).getControlName(objectClicked, stimuluType) == this.matchingGroups.ElementAt(groupCounter - 1).getModelName()).ToString(),
                            Path.GetFileNameWithoutExtension(this.matchingGroups.ElementAt(groupCounter - 1).getModelName()),
                            currentList,
                            stimulus.ToArray(),
                            stimuluPosition.getStimulusPositionMap(objectClicked.Location, size),
                            getStimuluType(),
                            getForeColor(modelControl),
                            getForeColor(objectClicked)
                            );
                        showAudioFeedbackOnNextClick = false;
                    }
                    else /* user missed stimulus */
                    {
                        if (this.executingTest.ProgramInUse.OmissionAudioResponse)
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                        }
                        if (stimuluType == 0)
                        {
                            size = ((PictureBox)modelAsStimuluControl).Size;
                        }
                        else
                        {
                            size = ((Button)modelAsStimuluControl).PreferredSize;
                        }
                        while (stimulus.Count <= 7)
                        {
                            stimulus.Add("-");
                        }
                        executingTest.WriteLineOutput(
                            attemptIntervalTime,
                            intervalElapsedTime,
                            modelReactTime,
                            0,
                            currentExposition + 1,
                            modelExpositionAccumulative,
                            expositionAccumulative,
                            modelFirstposition,
                            modelSecondPosition,
                            currentExpositionType,
                            "-",
                            this.matchingGroups.ElementAt(groupCounter - 1).getModelName(),
                            currentList,
                            stimulus.ToArray(),
                            "-",
                            getStimuluType(),
                            getForeColor(modelControl),
                            "-"
                            );
                        hitStopWatch.Stop();
                        showAudioFeedbackOnNextClick = false;
                    }
                }

                else if (!showModel && (e.Cancelled == true) && !intervalCancelled)  /* user clicked model */
                {
                    if (this.stimuluType == 0)
                    {
                        size = modelControl.Size;
                    }
                    else
                    {
                        size = modelControl.PreferredSize;
                    }
                    modelReactTime = hitStopWatch.ElapsedMilliseconds;
                    modelFirstposition = stimuluPosition.getStimulusPositionMap(objectClicked.Location, size);
                    showAudioFeedbackOnNextClick = true;
                }
                else  /*user missed model*/
                {
                    if (this.stimuluType == 0)
                    {
                        size = modelControl.Size;
                    }
                    else
                    {
                        size = modelControl.PreferredSize;
                    }
                    modelFirstposition = stimuluPosition.getStimulusPositionMap(modelControl.Location, size);
                    if (!executingTest.ProgramInUse.EndExpositionWithClick) /* model shouldn't be clicked */
                    {
                        modelReactTime = executingTest.ProgramInUse.ModelExpositionTime;
                        hitStopWatch.Stop();
                        showAudioFeedbackOnNextClick = true;
                    }
                    else { /*Model should be clicked but wasn't*/
                        if (this.executingTest.ProgramInUse.OmissionAudioResponse)
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                        }
                        modelReactTime = 0;
                        hitStopWatch.Stop();
                    }
                }
            }
            else
            {
                /*do nothing, user pressed esc*/
            }
            waitingExpositionEnd = false;
            expositionBW.Dispose();
        }
    }
}
