using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TestPlatform.Views
{
    class ExpositionsViews
    {
        private static int brush25 = 25;
        private static int brush4 = 4;

        public static int intervalTime(bool isIntervalTimeRandom, int intervalTime)
        {
            int intervalTimeRandom = 200; // minimal rnd interval time

            // if random interval active, it will be a value between 200 and the defined interval time
            if (isIntervalTimeRandom && intervalTime > 400)
            {
                Random random = new Random();
                intervalTimeRandom = random.Next(400, intervalTime);
            }
            else
            {
                intervalTimeRandom = intervalTime;
            }

            Stopwatch intervalStopWatch = new Stopwatch();
            intervalStopWatch.Start();
            while (intervalStopWatch.ElapsedMilliseconds < intervalTimeRandom)
            {
                /* just wait for interval time to be finished */
            }
            intervalStopWatch.Stop();
            int elapsedTime = (int) intervalStopWatch.ElapsedMilliseconds;
            return elapsedTime;
        }

        public static void makingFixPoint(string fixPoint, string fixPointColor, Form expositionForm)
        {
            SolidBrush myBrush = new SolidBrush(ColorTranslator.FromHtml(fixPointColor));
            float[] clientMiddle = { (expositionForm.ClientSize.Width / 2), (expositionForm.ClientSize.Height / 2) };
            
            switch (fixPoint)
            {
                case "+": // cross fixPoint
                    Graphics formGraphicsCross1 = expositionForm.CreateGraphics();
                    Graphics formGraphicsCross2 = expositionForm.CreateGraphics();
                    float xCross1 = clientMiddle[0] - brush25;
                    float yCross1 = clientMiddle[1] - brush4;
                    float xCross2 = clientMiddle[0] - brush4;
                    float yCross2 = clientMiddle[1] - brush25;
                    float widthCross = 2 * brush25;
                    float heightCross = 2 * brush4;
                    formGraphicsCross1.FillRectangle(myBrush, xCross1, yCross1, widthCross, heightCross);
                    formGraphicsCross2.FillRectangle(myBrush, xCross2, yCross2, heightCross, widthCross);
                    formGraphicsCross1.Dispose();
                    formGraphicsCross2.Dispose();
                    break;
                case "o": // circle fixPoint
                    Graphics formGraphicsEllipse = expositionForm.CreateGraphics();
                    float xEllipse = clientMiddle[0] - brush25;
                    float yEllipse = clientMiddle[1] - brush25;
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
    }
}
