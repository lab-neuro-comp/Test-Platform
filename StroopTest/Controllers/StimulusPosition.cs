using System;
using System.Collections.Generic;
using System.Drawing;

namespace TestPlatform.Controllers
{
    public class StimulusPosition
    {
        private int pointCount = 0;
        private Size clientSize, stimuluSize;
        private int pointsNumber;
        private const int X = 0, Y = 1;
        List<int> randomPositionsUsed;

        public StimulusPosition(int pointsNumber, Size clientSize, Size stimuluSize)
        {
            if (pointsNumber > 8 || pointsNumber < 1)
            {
                throw new ArgumentException();
            }
            this.stimuluSize = stimuluSize;
            this.pointsNumber = pointsNumber;
            this.clientSize = clientSize;
            randomPositionsUsed = new List<int>();
        }

        public Point getPositon()
        {

            Point position = new Point();
            switch (pointsNumber)
            {
                case 1:
                    position = centerPosition(stimuluSize, clientSize, pointsNumber, pointCount);
                    break;
                case 2:
                    position = twoPointsHorizontalPosition(stimuluSize, clientSize, pointCount);
                    break;
                case 3:
                    position = threePointsPosition(stimuluSize, clientSize, pointCount);
                    break;
                case 4:
                    position = fourPointsPosition(stimuluSize, clientSize, pointCount);
                    break;
                case 5:
                    position = fivePointsPosition(stimuluSize, clientSize, pointCount);
                    break;
                case 6:
                    position = sixPointsPosition(stimuluSize, clientSize, pointCount);
                    break;
                case 7:
                    position = sevenPointsPosition(stimuluSize, clientSize, pointCount);
                    break;
                case 8:
                    position = eightPointsPosition(stimuluSize, clientSize, pointCount);
                    break;
            }
            pointCount++;
            return position;
        }

        /// <summary>
        /// Generate point in center of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointsNumber">total number of points, must be greater than pointPosition</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be smaller than pointsNumber</param>
        /// </summary>
        public static Point centerPosition(Size stimulusSize, Size clientSize, int pointsNumber, int pointPosition)
        {
            if (pointPosition < pointsNumber)
            {
                /*middle center*/
                float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
                return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2), (int)clientMiddle[Y] - (stimulusSize.Height / 2));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generate point in middle left or middle right of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be 0 or 1</param>
        /// </summary>
        public static Point twoPointsHorizontalPosition(Size stimulusSize, Size clientSize, int pointPosition)
        {
            Point position = new Point();
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*middle left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                case 1: /*middle right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return position;
        }

        /// <summary>
        /// Generate point in middle left, middle right or middle center of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be 0, 1 or 2</param>
        /// </summary>
        public static Point threePointsPosition(Size stimulusSize, Size clientSize, int pointPosition)
        {
            Point position = new Point();
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*middle left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                case 1: /*middle right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                case 2:/*middle center*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return position;
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left or bottom right of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 3</param>
        /// </summary>
        public static Point fourPointsPosition(Size stimulusSize, Size clientSize, int pointPosition)
        {
            Point position = new Point();
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 1: /*top right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 2: /*bottom left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 3: /*bottom right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return position;
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left, bottom right or middle center of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 4</param>
        /// </summary>
        public static Point fivePointsPosition(Size stimulusSize, Size clientSize, int pointPosition)
        {
            Point position = new Point();
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 1: /*top right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 2: /*bottom left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 3: /*bottom right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 4: /*middle center*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return position;
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left, bottom right, top center or bottom center of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 5</param>
        /// </summary>
        public static Point sixPointsPosition(Size stimulusSize, Size clientSize, int pointPosition)
        {
            Point position = new Point();
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 1: /*top right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 2: /*bottom left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 3: /*bottom right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 4: /*top center*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 5: /*bottom center*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return position;
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left, bottom right, middle center, middle right or middle left of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 6</param>
        /// </summary>
        public static Point sevenPointsPosition(Size stimulusSize, Size clientSize, int pointPosition)
        {
            Point position = new Point();
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 1: /*top right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 2: /*bottom left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 3: /*bottom right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 4: /*middle left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                case 5: /*middle right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                case 6:/*middle center*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return position;
        }

        /// <summary>
        /// Generate point in top left left, top left right, top rigt left, top right right, bottom left left, bottom left right, bottom right left or bottom right right of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 7</param>
        /// </summary>
        public static Point eightPointsPosition(Size stimulusSize, Size clientSize, int pointPosition)
        {
            Point position = new Point();
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 1: /*top left right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 2: /*top right left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 3: /*top right right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 4: /*bottom left left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 5: /*bottom left right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 6: /*bottom right left*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 7: /*bottom right right*/
                    position.X = (int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
                    position.Y = (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return position;
        }

        public void setStimulusSize(Size stimuluSize)
        {
            this.stimuluSize = stimuluSize;
        }

        public Point getRandomPosition(Size clientSize, Size stimuluSize)
        {
            int number;
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            Point p = new Point();
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            do
            {
                number = rng.Next(21);
            } while (randomPositionsUsed.Contains(number));
            randomPositionsUsed.Add(number);
            switch (number)
            {
                case 0:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 1:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4); ;
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 2:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 3:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 4:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 5:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
                case 6:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 7:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 8:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 9:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 10:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 11:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4); ;
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
                    break;
                case 12:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 13:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 14:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 15:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 16:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 17:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 18:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4); ;
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 19:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
                    break;
                case 20:
                    p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2);
                    p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
                    break;
            }
            return p;
        }
        public static string getStimuluPositionMap(Point position, Size clientSize, Size stimuluSize)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            Point p = new Point();
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "A1";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "B1";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "C1";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "D1";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "E1";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "F1";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4); ;
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "G1";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "A2";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "B2";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "C2";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "D2";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "E2";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "F2";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4); ;
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "G2";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2);
            if (position == p)
            {
                return "A3";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "B3";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "C3";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "D3";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "E3";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2);
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "F3";
            }
            p.X = (int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4); ;
            p.Y = (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2);
            if (position == p)
            {
                return "G3";
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
