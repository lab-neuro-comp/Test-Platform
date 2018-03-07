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

        public class WordsMatchingGroup
        {
            private string model;
            private string[] stimulus;
            private string[] colors;
            public WordsMatchingGroup(string model, List<string> stimulus, List<string> colors)
            {
                this.model = model;
                this.stimulus = stimulus.ToArray();
                this.colors = colors.ToArray();
            }

            public bool match(string stimulus)
            {
                return model.Equals(stimulus);
            }

            public void shuffleStimulus()
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                stimulus = stimulus.OrderBy(x => rnd.Next()).ToArray();
            }

            public string getModel()
            {
                return model;
            }
            public List<string> getStimulus()
            {
                return stimulus.ToList();
            }
            public List<string> getColors()
            {
                return colors.ToList();
            }

        }

        public class ImagesMatchingGroup
        {
            private Image modelImage;
            private Image[] stimulus;
            private string modelImageName;
            private string[] stimulusImagesName;
            public ImagesMatchingGroup(Image modelImage, string modelName, List<Image> stimulus, List<string> stimulusName)
            {
                this.modelImage = modelImage;
                modelImageName = modelName;
                this.stimulus = stimulus.ToArray();
                stimulusImagesName = stimulusName.ToArray();
            }
            public bool match(Image stimulus)
            {
                return modelImage.Equals(stimulus);
            }

            public void shuffleStimulus()
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                stimulus = stimulus.OrderBy(x => rnd.Next()).ToArray();
            }

            public Image getModelImage()
            {
                return modelImage;
            }
            public List<Image> getStimulusImages()
            {
                return stimulus.ToList();
            }
            public string getModelImageName()
            {
                return modelImageName;
            }
            public string getStimuluImageName(Image image)
            {
                int i;
                for (i = 0; i < stimulus.Length; i++)
                {
                    if (stimulus[i].Equals(image))
                    {
                        break;
                    }
                }
                return stimulusImagesName[i];
            }

            public string[] getStimuluImageNames()
            {
                return stimulusImagesName;
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
        private PictureBox modelPictureBox, modelAsStimuluPictureBox;
        private Button modelAsStimuluButton;
        private Button modelButton;
        private List<ImagesMatchingGroup> imagesMatchingGroups;
        private List<WordsMatchingGroup> wordsMatchingGroups;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private List<Control> currentControl;
        int currentExposition;
        private ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        private CultureInfo currentCulture = CultureInfo.CurrentUICulture;
        private bool cancelExposition;
        private Stopwatch accumulativeStopWatch = new Stopwatch();
        private Stopwatch hitStopWatch;
        private bool showModel = true;
        private List<Control> stimuluControl;
        private bool waitingExpositionEnd;
        string currentExpositionType;
        private object modelClicked;
        private bool showAudioFeedbackOnNextClick = false;
        private long modelReactTime;
        private long attemptIntervalTime;

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
            stimuluControl = new List<Control>();
            outputFile = outputDataPath + executingTest.ParticipantName + "_" + executingTest.ProgramInUse.ProgramName + ".txt";
            startExposition();
            this.ShowDialog();
        }

        private void startExposition()
        {
            if (executingTest.ProgramInUse.Ready(path))
            {
                currentExpositionType = this.executingTest.ProgramInUse.getExpositionType();
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
            if (this.executingTest.ProgramInUse.getImageListFile() != null)
            {
                imagesMatchingGroups = new List<ImagesMatchingGroup>();
                this.imageList = this.executingTest.ProgramInUse.getImageListFile().ListContent.ToArray();
                if (this.executingTest.ProgramInUse.ExpositionRandom)
                {
                    imageList = ExpositionController.ShuffleArray(imageList, imageList.Length, 3);
                }
                createImagesMatchingGroups();
            }
            else if (this.executingTest.ProgramInUse.getWordListFile() != null)
            {
                wordsMatchingGroups = new List<WordsMatchingGroup>();
                this.wordList = this.executingTest.ProgramInUse.getWordListFile().ListContent.ToArray();
                if (this.executingTest.ProgramInUse.ExpositionRandom)
                {
                    wordList = ExpositionController.ShuffleArray(wordList, wordList.Length, 3);
                }
                if (this.executingTest.ProgramInUse.getColorListFile() != null)
                {
                    this.colorList = this.executingTest.ProgramInUse.getColorListFile().ListContent.ToArray();
                    if (this.executingTest.ProgramInUse.ExpositionRandom)
                    {
                        colorList = ExpositionController.ShuffleArray(colorList, colorList.Length, 3);
                    }
                }
                else
                {
                    this.colorList = new string[1];
                    colorList[0] = this.executingTest.ProgramInUse.WordColor;
                }
                createWordsMatchingGroups();
            }
            else throw new InvalidOperationException();
        }

        private bool noneImageLeft(bool[] imageCanBeUsed)
        {
            foreach (bool canBeUsed in imageCanBeUsed)
            {
                if (canBeUsed)
                {
                    return false;
                }
            }
            return true;
        }

        private void createWordsMatchingGroups()
        {
            WordsMatchingGroup nextGroup;
            bool willHaveRepetition = (wordList.Length < this.executingTest.ProgramInUse.NumExpositions * this.executingTest.ProgramInUse.AttemptsNumber);
            int modelCounter = 0, stimuluCounter = 0, startingIndex = 0, colorCounter = 0;
            Random rng = new Random(int.Parse(this.seconds));
            string[] groupModels = new string[this.executingTest.ProgramInUse.AttemptsNumber];
            string[] groupStimulus = new string[this.executingTest.ProgramInUse.NumExpositions];
            string[] colors = new string[this.executingTest.ProgramInUse.NumExpositions];
            bool[] wordCanBeUsed = new bool[wordList.Length];
            for (int i = 0; i < wordList.Length; i++)
            {
                wordCanBeUsed[i] = true;
            }
            for (int count = 0; modelCounter < this.executingTest.ProgramInUse.AttemptsNumber; count++)//define the models of the exposition
            {
                if (count >= wordList.Length) // prevent out of range exception
                {
                    count = 0;
                }
                wordCanBeUsed[count] = false;
                groupModels[modelCounter] = wordList[count];
                modelCounter++;
                startingIndex = count;
            }
            for (int group = 0; group < groupModels.Length; group++)
            {
                for (int count = 1; count < this.executingTest.ProgramInUse.NumExpositions; count++)
                {
                    groupStimulus[count] = null;
                    colors[count] = null;
                }
                stimuluCounter = startingIndex;
                groupStimulus[0] = groupModels[group];
                for (int count = 1; count < this.executingTest.ProgramInUse.NumExpositions; count++)
                {
                    if (stimuluCounter >= wordList.Length)
                    {
                        stimuluCounter = 0;
                    }
                    if (wordList.Length >= this.executingTest.ProgramInUse.NumExpositions)
                    {
                        if (!willHaveRepetition)
                        {
                            while (!wordCanBeUsed[stimuluCounter])
                            {
                                stimuluCounter++;
                            }
                        }
                        else
                        {
                            string name = wordList[stimuluCounter];
                            while (groupStimulus.Contains(name))
                            {
                                stimuluCounter++;
                                name = wordList[stimuluCounter];
                            }
                        }
                    }
                    groupStimulus[count] = wordList[stimuluCounter];
                    stimuluCounter++;
                }
                for (int count = 0; count < colors.Length; count++)
                {
                    if (colorCounter >= colorList.Length)
                    {
                        colorCounter = 0;
                    }
                    string color = colorList[colorCounter];
                    if (colorList.Length >= colors.Length)
                    {
                        while (colors.Contains(color))
                        {
                            colorCounter++;
                            color = colorList[colorCounter];

                        }
                    }
                    colors[count] = colorList[colorCounter];
                    colorCounter++;
                }
                nextGroup = new WordsMatchingGroup(groupModels[group], groupStimulus.ToList(), colors.ToList());
                nextGroup.shuffleStimulus();
                wordsMatchingGroups.Add(nextGroup);
            }

        }

        private void createImagesMatchingGroups()
        {
            ImagesMatchingGroup nextGroup;
            bool willHaveRepetition = (imageList.Length < this.executingTest.ProgramInUse.NumExpositions * this.executingTest.ProgramInUse.AttemptsNumber);
            int modelCounter = 0, stimuluCounter = 0, startingIndex = 0;
            Random rng = new Random(int.Parse(this.seconds));
            Image[] groupModels = new Image[this.executingTest.ProgramInUse.AttemptsNumber];
            string[] groupModelsName = new string[this.executingTest.ProgramInUse.AttemptsNumber];
            Image[] groupStimulus = new Image[this.executingTest.ProgramInUse.NumExpositions];
            string[] groupStimulusName = new string[this.executingTest.ProgramInUse.NumExpositions];
            bool[] imageCanBeUsed = new bool[imageList.Length];
            for (int i = 0; i < imageList.Length; i++)
            {
                imageCanBeUsed[i] = true;
            }
            for (int count = 0; modelCounter < this.executingTest.ProgramInUse.AttemptsNumber; count++)//define the models of the exposition
            {
                if (count >= imageList.Length) // prevent out of range exception
                {
                    count = 0;
                }
                imageCanBeUsed[count] = false;
                groupModels[modelCounter] = Image.FromFile(imageList[count]);
                groupModelsName[modelCounter] = Path.GetFileNameWithoutExtension(imageList[count]);
                modelCounter++;
                startingIndex = count;
            }
            for (int group = 0; group < groupModels.Length; group++)
            {
                for (int count = 1; count < this.executingTest.ProgramInUse.NumExpositions; count++)
                {
                    groupStimulus[count] = null;
                    groupStimulusName[count] = null;
                }
                stimuluCounter = startingIndex;
                groupStimulus[0] = groupModels[group];
                groupStimulusName[0] = groupModelsName[group];
                for (int count = 1; count < this.executingTest.ProgramInUse.NumExpositions; count++)
                {
                    if (stimuluCounter >= imageList.Length)
                    {
                        stimuluCounter = 0;
                    }
                    if (imageList.Length >= this.executingTest.ProgramInUse.NumExpositions)
                    {
                        if (!willHaveRepetition)
                        {
                            while (!imageCanBeUsed[stimuluCounter])
                            {
                                stimuluCounter++;
                            }
                        }
                        else
                        {
                            string name = Path.GetFileNameWithoutExtension(imageList[stimuluCounter]);
                            while (groupStimulusName.Contains(name))
                            {
                                stimuluCounter++;
                                name = Path.GetFileNameWithoutExtension(imageList[stimuluCounter]);
                            }
                        }
                    }
                    groupStimulus[count] = Image.FromFile(imageList[stimuluCounter]);
                    groupStimulusName[count] = Path.GetFileNameWithoutExtension(imageList[stimuluCounter]);
                    stimuluCounter++;
                }
                nextGroup = new ImagesMatchingGroup(groupModels[group], groupModelsName[group], groupStimulus.ToList(), groupStimulusName.ToList());
                if (this.executingTest.ProgramInUse.ExpositionRandom)
                {
                    nextGroup.shuffleStimulus();
                }
                imagesMatchingGroups.Add(nextGroup);
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
                Thread.Sleep(100);
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
                stimuluPosition = new StimulusPosition(1, ClientSize, new Size(0, 0));
                if (this.executingTest.ProgramInUse.getImageListFile() != null)
                {
                    drawModelImage();
                }
                else
                {
                    drawModelWord();
                }
            }
            else
            {
                if (!this.executingTest.ProgramInUse.RandomStimulusPosition)
                {
                    stimuluPosition = new StimulusPosition(this.executingTest.ProgramInUse.NumExpositions, ClientSize, new Size(0, 0));
                }
                intervalElapsedTime = waitIntervalTime(this.executingTest.ProgramInUse.RandomIntervalModelStimulus, this.executingTest.ProgramInUse.IntervalTime);
                if (this.executingTest.ProgramInUse.getImageListFile() != null)
                {
                    drawStimuluImage();
                }
                else
                {
                    drawStimuluWord();
                }
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

        private void drawModelWord()
        {
            List<Control> buttons = new List<Control>();
            showModel = false;
            modelButton = new Button();
            modelButton.Font = new Font("Arial", this.executingTest.ProgramInUse.StimuluSize, FontStyle.Bold);
            modelButton.BackColor = System.Drawing.SystemColors.ControlLightLight; ;
            modelButton.ForeColor = ColorTranslator.FromHtml(wordsMatchingGroups.ElementAt(groupCounter).getColors().ElementAt(wordsMatchingGroups.ElementAt(groupCounter).getStimulus().IndexOf(wordsMatchingGroups.ElementAt(groupCounter).getModel())));
            modelButton.AutoSize = true;
            modelButton.Text = wordsMatchingGroups.ElementAt(groupCounter).getModel();
            if (this.executingTest.ProgramInUse.RandomModelPosition)
            {
                modelButton.Location = stimuluPosition.getRandomPosition(ClientSize, modelButton.PreferredSize);
            }
            else
            {
                stimuluPosition.setStimulusSize(modelButton.PreferredSize);
                Point position = stimuluPosition.getPositon();
                modelButton.Location = position;
            }
            currentStimulus = wordsMatchingGroups.ElementAt(groupCounter);

            if (executingTest.ProgramInUse.EndExpositionWithClick)
            {
                modelButton.Enabled = true;
                modelButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MatchingExposition_MouseClick);
            }
            buttons.Add(modelButton);
            expositionBW.ReportProgress(currentExposition / (executingTest.ProgramInUse.AttemptsNumber * 2) * 100, buttons);
        }

        private void drawModelImage()
        {
            List<Control> image = new List<Control>();
            showModel = false;
            modelPictureBox = new PictureBox();
            modelPictureBox.Size = new Size(executingTest.ProgramInUse.StimuluSize, executingTest.ProgramInUse.StimuluSize);
            if (this.executingTest.ProgramInUse.RandomModelPosition)
            {
                modelPictureBox.Location = stimuluPosition.getRandomPosition(ClientSize, modelPictureBox.PreferredSize);
            }
            else
            {
                stimuluPosition.setStimulusSize(modelPictureBox.PreferredSize);
                Point position = stimuluPosition.getPositon();
                modelPictureBox.Location = position;
            }
            modelPictureBox.Image = imagesMatchingGroups.ElementAt(groupCounter).getModelImage();
            currentStimulus = imagesMatchingGroups.ElementAt(groupCounter);
            modelPictureBox.Enabled = true;
            modelPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (executingTest.ProgramInUse.EndExpositionWithClick)
            {
                modelPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MatchingExposition_MouseClick);
            }
            image.Add(modelPictureBox);
            expositionBW.ReportProgress(currentExposition / (executingTest.ProgramInUse.AttemptsNumber * 2) * 100, image);
        }

        private void drawStimuluWord()
        {
            showModel = true;
            stimuluControl.Clear();
            int count = 0;
            foreach (string word in wordsMatchingGroups.ElementAt(groupCounter).getStimulus())
            {
                Button newButton = new Button();
                newButton.Font = new Font("Arial", this.executingTest.ProgramInUse.StimuluSize, FontStyle.Bold);
                newButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
                newButton.AutoSize = true;
                newButton.Text = word;
                newButton.ForeColor = ColorTranslator.FromHtml(wordsMatchingGroups.ElementAt(groupCounter).getColors().ElementAt(count));
                if (this.executingTest.ProgramInUse.RandomStimulusPosition)
                {
                    newButton.Location = stimuluPosition.getRandomPosition(ClientSize, newButton.PreferredSize);
                }
                else
                {
                    stimuluPosition.setStimulusSize(newButton.PreferredSize);
                    Point position = stimuluPosition.getPositon();
                    newButton.Location = position;
                }
                currentStimulus = wordsMatchingGroups.ElementAt(groupCounter);
                newButton.Enabled = true;
                newButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MatchingExposition_MouseClick);
                if (newButton.Text == wordsMatchingGroups.ElementAt(groupCounter).getModel())
                {
                    modelAsStimuluButton = newButton;
                }
                stimuluControl.Add(newButton);
                count++;
            }
            groupCounter++;
            if (groupCounter > this.executingTest.ProgramInUse.AttemptsNumber)
            {
                groupCounter = 0;
            }
            expositionBW.ReportProgress(currentExposition / (executingTest.ProgramInUse.AttemptsNumber * 2) * 100, stimuluControl);
        }

        private void drawStimuluImage()
        {
            showModel = true;
            stimuluControl.Clear();

            foreach (Image img in imagesMatchingGroups.ElementAt(groupCounter).getStimulusImages())
            {
                PictureBox newPicBox = ExpositionController.InitializeImageBox(executingTest.ProgramInUse.StimuluSize, img);

                if (this.executingTest.ProgramInUse.RandomStimulusPosition)
                {
                    newPicBox.Location = stimuluPosition.getRandomPosition(ClientSize, newPicBox.Size);
                }
                else
                {
                    stimuluPosition.setStimulusSize(newPicBox.Size);
                    Point position = stimuluPosition.getPositon();
                    newPicBox.Location = position;
                }

                currentStimulus = imagesMatchingGroups.ElementAt(groupCounter);
                newPicBox.Enabled = true;
                newPicBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MatchingExposition_MouseClick);
                if (img == imagesMatchingGroups.ElementAt(groupCounter).getModelImage())
                {
                    modelAsStimuluPictureBox = newPicBox;
                }
                stimuluControl.Add(newPicBox);
            }
            groupCounter++;
            if (groupCounter > this.executingTest.ProgramInUse.AttemptsNumber)
            {
                groupCounter = 0;
            }
            expositionBW.ReportProgress(currentExposition / (executingTest.ProgramInUse.AttemptsNumber * 2) * 100, stimuluControl);
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
            if (exposing && !cancelExposition)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.bell);
                player.Play();
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


        private void SendUserResponse(object modelClicked)
        {
            if (expositionBW.WorkerSupportsCancellation == true)
            {
                this.modelClicked = modelClicked;
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
            SendUserResponse(sender);
        }

        private void playDMTSFeedbackSound(object sender)
        {
            if (executingTest.ProgramInUse.FeedbackAudioResponse && this.imagesMatchingGroups.ElementAt(groupCounter - 1).getStimuluImageName(((PictureBox)sender).Image) == this.imagesMatchingGroups.ElementAt(groupCounter - 1).getModelImageName())
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.hit);
                player.Play();
            }
            else if (executingTest.ProgramInUse.FeedbackAudioResponse)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.error);
                player.Play();
            }
        }

        private void playDNMTSFeedbackSound(object sender)
        {
            if (executingTest.ProgramInUse.FeedbackAudioResponse && this.imagesMatchingGroups.ElementAt(groupCounter - 1).getStimuluImageName(((PictureBox)sender).Image) != this.imagesMatchingGroups.ElementAt(groupCounter - 1).getModelImageName())
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.hit);
                player.Play();
            }
            else if (executingTest.ProgramInUse.FeedbackAudioResponse)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestPlatform.Properties.Resources.error);
                player.Play();
            }
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
            if (!cancelExposition)
            {
                if (this.executingTest.ProgramInUse.getImageListFile() != null)
                {
                    if (modelAsStimuluPictureBox != null)
                    {
                        modelSecondPosition = StimulusPosition.getStimuluPositionMap(modelAsStimuluPictureBox.Location, ClientSize, modelAsStimuluPictureBox.Size);
                    }

                    if (showModel && (e.Cancelled == true) && !intervalCancelled) /* user clicked after stimulus is shown*/
                    {
                        List<string> stimulus = this.imagesMatchingGroups.ElementAt(groupCounter - 1).getStimuluImageNames().ToList();
                        stimulus.Remove(this.imagesMatchingGroups.ElementAt(groupCounter - 1).getModelImageName());
                        for (int count = 0; count < stimulus.Count; count++)
                        {
                            stimulus[count] = this.executingTest.ProgramInUse.getImageListFile().ListName + "/" + stimulus[count];
                        }
                        while (stimulus.Count <= 7)
                        {
                            stimulus.Add("-");
                        }
                        stimulus[7] = this.executingTest.ProgramInUse.getImageListFile().ListName + "/" + this.imagesMatchingGroups.ElementAt(groupCounter - 1).getStimuluImageName(((PictureBox)modelClicked).Image);
                        executingTest.writeLineOutput(
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
                            (this.imagesMatchingGroups.ElementAt(groupCounter - 1).getStimuluImageName(((PictureBox)modelClicked).Image) == this.imagesMatchingGroups.ElementAt(groupCounter - 1).getModelImageName()).ToString(),
                            this.executingTest.ProgramInUse.getImageListFile().ListName + "/" + this.imagesMatchingGroups.ElementAt(groupCounter - 1).getModelImageName(),
                            stimulus.ToArray(),
                            StimulusPosition.getStimuluPositionMap(((PictureBox)modelClicked).Location, ClientSize, ((PictureBox)modelClicked).Size)
                            );
                        showAudioFeedbackOnNextClick = false;
                    }
                    else if (showModel)/* user missed stimulus */
                    {
                        List<string> stimulus = this.imagesMatchingGroups.ElementAt(groupCounter - 1).getStimuluImageNames().ToList();
                        stimulus.Remove(this.imagesMatchingGroups.ElementAt(groupCounter - 1).getModelImageName());
                        while (stimulus.Count <= 8)
                        {
                            stimulus.Add("-");
                        }
                        executingTest.writeLineOutput(
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
                            this.imagesMatchingGroups.ElementAt(groupCounter - 1).getModelImageName(),
                            stimulus.ToArray(),
                            "-");
                        hitStopWatch.Stop();
                        showAudioFeedbackOnNextClick = false;
                    }
                    else if (!showModel && (e.Cancelled == true) && !intervalCancelled)  /* user clicked model */
                    {
                        modelReactTime = hitStopWatch.ElapsedMilliseconds;
                        modelFirstposition = StimulusPosition.getStimuluPositionMap(((PictureBox)modelClicked).Location, ClientSize, modelPictureBox.Size);
                        showAudioFeedbackOnNextClick = true;
                    }
                    else if (!executingTest.ProgramInUse.EndExpositionWithClick) /* model shouldn't be clicked */
                    {
                        modelReactTime = executingTest.ProgramInUse.ModelExpositionTime;
                        modelFirstposition = StimulusPosition.getStimuluPositionMap(modelPictureBox.Location, ClientSize, modelPictureBox.Size);
                        hitStopWatch.Stop();
                        showAudioFeedbackOnNextClick = true;
                    }
                    else  /*user missed model*/
                    {
                        modelReactTime = 0;
                        modelFirstposition = StimulusPosition.getStimuluPositionMap(modelPictureBox.Location, ClientSize, modelPictureBox.Size);
                        hitStopWatch.Stop();
                    }
                }
                else if (this.executingTest.ProgramInUse.getWordListFile() != null)
                {
                    if (modelAsStimuluButton != null)
                    {
                        modelSecondPosition = StimulusPosition.getStimuluPositionMap(modelAsStimuluButton.Location, ClientSize, modelAsStimuluButton.PreferredSize);
                    }

                    if (showModel && (e.Cancelled == true) && !intervalCancelled) /* user clicked after stimulus is shown*/
                    {
                        List<string> stimulus = this.wordsMatchingGroups.ElementAt(groupCounter - 1).getStimulus().ToList();
                        stimulus.Remove(this.wordsMatchingGroups.ElementAt(groupCounter - 1).getModel());
                        for (int count = 0; count < stimulus.Count; count++)
                        {
                            stimulus[count] = stimulus[count] + "#" + this.wordsMatchingGroups.ElementAt(groupCounter - 1).getColors().ElementAt(count);
                        }
                        while (stimulus.Count <= 7)
                        {
                            stimulus.Add("-");
                        }
                        stimulus[7] = ((Button)modelClicked).Text + "#" + ColorTranslator.ToHtml(((Button)modelClicked).ForeColor);
                        executingTest.writeLineOutput(
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
                            (((Button)modelClicked).Text == this.wordsMatchingGroups.ElementAt(groupCounter - 1).getModel()).ToString(),
                            this.wordsMatchingGroups.ElementAt(groupCounter - 1).getModel() + "#" + this.wordsMatchingGroups.ElementAt(groupCounter - 1).getColors().ElementAt(this.wordsMatchingGroups.ElementAt(groupCounter - 1).getStimulus().IndexOf(this.wordsMatchingGroups.ElementAt(groupCounter - 1).getModel())),
                            stimulus.ToArray(),
                            StimulusPosition.getStimuluPositionMap(((Button)modelClicked).Location, ClientSize, ((Button)modelClicked).PreferredSize)
                            );
                    }
                    else if (showModel)/* user missed stimulus */
                    {
                        List<string> stimulus = this.wordsMatchingGroups.ElementAt(groupCounter - 1).getStimulus().ToList();
                        stimulus.Remove(this.wordsMatchingGroups.ElementAt(groupCounter - 1).getModel());
                        while (stimulus.Count <= 8)
                        {
                            stimulus.Add("-");
                        }
                        executingTest.writeLineOutput(
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
                            this.wordsMatchingGroups.ElementAt(groupCounter - 1).getModel(),
                            stimulus.ToArray(),
                            "-");
                        hitStopWatch.Stop();
                    }
                    else if (!showModel && (e.Cancelled == true) && !intervalCancelled)  /* user clicked model */
                    {
                        modelReactTime = hitStopWatch.ElapsedMilliseconds;
                        modelFirstposition = StimulusPosition.getStimuluPositionMap(((Button)modelClicked).Location, ClientSize, modelButton.PreferredSize);
                    }
                    else if (!executingTest.ProgramInUse.EndExpositionWithClick) /* model shouldn't be clicked */
                    {
                        modelReactTime = executingTest.ProgramInUse.ModelExpositionTime;
                        modelFirstposition = StimulusPosition.getStimuluPositionMap(modelButton.Location, ClientSize, modelButton.PreferredSize);
                        hitStopWatch.Stop();
                    }
                    else  /*user missed model*/
                    {
                        modelReactTime = 0;
                        modelFirstposition = StimulusPosition.getStimuluPositionMap(modelButton.Location, ClientSize, modelButton.PreferredSize);
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
