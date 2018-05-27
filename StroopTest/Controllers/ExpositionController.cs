namespace TestPlatform.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using TestPlatform.Views;
    using TestPlatform.Views.ExperimentPages;
    using Views.MatchingPages;

    public class ExpositionController
    {

        private static int brush25 = 25;
        private static int brush4 = 4;

        public static void makingFixPoint(string fixPoint, string fixPointColor, Form expositionForm)
        {
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(fixPointColor));
            float[] clientMiddle = { (expositionForm.ClientSize.Width / 2), (expositionForm.ClientSize.Height / 2) };

            switch (fixPoint)
            {
                case "+": // cross fixPoint
                    float widthCross = 2 * brush25;
                    float heightCross = 2 * brush4;
                    Graphics formGraphicsCross1 = expositionForm.CreateGraphics();
                    Graphics formGraphicsCross2 = expositionForm.CreateGraphics();
                    float xCross1 = clientMiddle[0] - (widthCross / 2);
                    float yCross1 = clientMiddle[1] - (heightCross / 2);
                    float xCross2 = clientMiddle[0] - (heightCross / 2);
                    float yCross2 = clientMiddle[1] - (widthCross / 2);

                    formGraphicsCross1.FillRectangle(myBrush, xCross1, yCross1, widthCross, heightCross);
                    formGraphicsCross2.FillRectangle(myBrush, xCross2, yCross2, heightCross, widthCross);
                    formGraphicsCross1.Dispose();
                    formGraphicsCross2.Dispose();
                    break;
                case "o": // circle fixPoint
                    Graphics formGraphicsEllipse = expositionForm.CreateGraphics();
                    float xEllipse = clientMiddle[0];
                    float yEllipse = clientMiddle[1];
                    float widthEllipse = 2 * brush25;
                    float heightEllipse = 2 * brush25;
                    formGraphicsEllipse.FillEllipse(myBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
                    formGraphicsEllipse.Dispose();
                    break;
                default:
                    break;

            }
            myBrush.Dispose();
        }


        public static string[] ShuffleArray(string[] array, int expectedLength, int rndSeed) // randomiza Vetor - parâmetros: vetor / tamanho esperado do vetor randomizado
        {
            List<string> randomArray = new List<string>();
            Random rnd = new Random(DateTime.Now.Millisecond + expectedLength + rndSeed);

            if (expectedLength == array.Count()) 
            {
                // if there is intent to keep the same vector size, there are no repetitions
                randomArray = array.OrderBy(x => rnd.Next()).ToList();
            }
            else
            {
                // if there is intent to extent vector size it will be filled with random values from the original one, repeting itself
                for (int i = 0; i < expectedLength; i++) 
                {
                    randomArray.Add(array[rnd.Next(array.Length)]);
                }
            }

            return randomArray.ToArray();
        }

        public static string[] mergeLists(string[] firstList, string[] secondList, bool isRandExposition)
        {
            List<string> mergedList = new List<string>();
            bool hasFirstListEnded = false, hasSecondListEnded = false;
            int firstListIndex = 0, secondListIndex = 0;
            while(!hasFirstListEnded || !hasSecondListEnded)
            {
                if(firstListIndex != firstList.Length-1) //do this till reach last element in first array
                {
                    mergedList.Add(firstList[firstListIndex]);
                    firstListIndex++;
                }
                else //when reach last element add it on list and set flag as true
                {
                    mergedList.Add(firstList[firstListIndex]);
                    hasFirstListEnded = true;
                    firstList = ShuffleArray(firstList, firstList.Length, Math.Abs(firstListIndex - secondListIndex));
                    firstListIndex = 0;
                }
                if(secondListIndex < secondList.Length-1)
                {
                    mergedList.Add(secondList[secondListIndex]);
                    secondListIndex++;
                }
                else
                {
                    mergedList.Add(secondList[secondListIndex]);
                    hasSecondListEnded = true;
                    secondList = ShuffleArray(secondList, secondList.Length, Math.Abs(secondListIndex - firstListIndex));
                    secondListIndex = 0;
                }
            }
            return mergedList.ToArray();
        }

        public static void BeginStroopTest(string programName, string participantName, char mark, Form form)
        {
            try
            {
                SendKeys.SendWait("i");
                FormExposition formExposition = new FormExposition(programName, participantName, mark);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void BeginReactionTest(string programName, string participantName, char mark, Form form)
        {
            try
            {
                SendKeys.SendWait("i");
                FormReactExposition reactionExposition = new FormReactExposition(programName, participantName, mark);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void BeginMatchingTest(string programName, string participantName, char mark, Form form)
        {
            try
            {
                SendKeys.SendWait("i");
                MatchingExposition matchingExposition = new MatchingExposition(programName, participantName, mark);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static PictureBox InitializeImageBox(double stimuliSize, Image image, bool expandImage, Form form)
        {
            PictureBox newPictureBox = new PictureBox();
            int size = CentimeterToPixel(stimuliSize, form);
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Size = new Size(size, size);

            newPictureBox.Image = image;
            newPictureBox.Enabled = true;

            if (expandImage)
            {
                newPictureBox.Dock = DockStyle.Fill;
            }
            else
            {
                newPictureBox.Dock = DockStyle.None;
            }

            return newPictureBox;
        }

        public static Button InitializeButton(string text)
        {
            Button newButton = new Button();
            newButton.AutoSize = true;
            newButton.BackColor = System.Drawing.SystemColors.ControlLightLight; ;
            newButton.Text = text;
            newButton.Enabled = true;
            return newButton;
        }

        public static Label InitializeWordLabel(int size,string stimulus, string color, Point position)
        {
            // configuring label that have word stimulus dimensions, color and position
            Label wordLabel = new Label();
            wordLabel.AutoSize = true;
            wordLabel.Font = new Font("Arial", size, FontStyle.Bold);
            wordLabel.Text = stimulus;
            wordLabel.Visible = true;
            wordLabel.ForeColor = ColorTranslator.FromHtml(color);
            wordLabel.Enabled = true;
            wordLabel.Location = position;
            return wordLabel;
        }

        public static void BeginExperimentTest(string programName, string participantName, char mark, Form form)
        {
            try
            {
                SendKeys.SendWait("i");
                FormExperimentExposition experimentExposition = new FormExperimentExposition(programName, participantName, mark);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        public static void formSecondScreen(Form form)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (sc.Count<Screen>() > 1)
            {
                foreach (Screen s in sc)
                {
                    if (!s.Primary)
                    {
                        form.WindowState = FormWindowState.Maximized;
                        form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        form.Bounds = s.Bounds;
                        form.MaximizeBox = true;
                    }
                }
            }

        }

        public static int CentimeterToPixel(double Centimeter, Form form)
        {
            double pixel = -1;
            using (Graphics g = form.CreateGraphics())
            {
                pixel = Centimeter * g.DpiY / 2.54d;
            }
            return (int)pixel;
        }


    }
}
