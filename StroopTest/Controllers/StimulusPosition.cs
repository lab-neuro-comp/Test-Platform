using System;
using System.Collections.Generic;
using System.Drawing;

namespace TestPlatform.Controllers
{
    /// <summary>  
    ///  This class manipulates a eight position matrix to show stimulus arround users screen, and also generates random positions
    ///  In x axis there are 7 possible positions from A to G
    ///  In y axis there are 3 possible positions from 1 to 3
    ///  An example of a point is D2 (center of the screen)
    /// </summary> 
    public class StimulusPosition
    {
        private int pointCount = 0;
        private Size clientSize, stimulusSize;
        private int pointsNumber;
        private const int X = 0, Y = 1;
        private const int A1 = 0, B1 = 1, C1 = 2, D1 = 3, E1 = 4, F1 = 5, G1 = 6, A2 = 7, B2 = 8, C2 = 9, D2 = 10, E2 = 11, F2 = 12, G2 = 13, A3 = 14, B3 = 15, C3 = 16, D3 = 17, E3 = 18, F3 = 19, G3 = 20;
        List<int> randomPositionsUsed;
        private static string[] matrixPositionsNames = new string[21] {"A1", "B1", "C1", "D1", "E1", "F1", "G1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "A3", "B3", "C3", "D3", "E3", "F3", "G3" };
        private string currentPosition = "-";

        public int PointsNumber
        {
            get
            {
                return pointsNumber;
            }

            set
            {
                if (value <= 8 && value > 0)
                {
                    pointsNumber = value;
                }
                else
                {
                    throw new ArgumentException();
                }

            }
        }

        public string CurrentPosition
        {
            get
            {
                return currentPosition;
            }

            set
            {
                currentPosition = value;
            }
        }

        public StimulusPosition(Size clientSize, int pointNumber)
        {
            this.clientSize = clientSize;
            PointsNumber = pointNumber;
            randomPositionsUsed = new List<int>();
        }

        public StimulusPosition(Size clientSize, Size stimulusSize)
        {
            this.clientSize = clientSize;
            this.stimulusSize = stimulusSize;
        }

        /// <summary>  
        ///  Create all possible points that can be used during exposition, according to the user screen
        /// </summary> 
        private Point generatePoint(int point)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };

            switch (point)
            {
                case A1:
                    currentPosition = matrixPositionsNames[A1];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                       (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2));

                case B1:
                    currentPosition = matrixPositionsNames[B1];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2),
                      (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2));

                case C1:
                    currentPosition = matrixPositionsNames[C1];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                  (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2));

                case D1:
                    currentPosition = matrixPositionsNames[D1];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2));

                case E1:
                    currentPosition = matrixPositionsNames[E1];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2));

                case F1:
                    currentPosition = matrixPositionsNames[F1];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2));

                case G1:
                    currentPosition = matrixPositionsNames[G1];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) - (int)(clientMiddle[Y] / 2));

                case A2:
                    currentPosition = matrixPositionsNames[A2];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2));

                case B2:
                    currentPosition = matrixPositionsNames[B2];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2),
               (int)clientMiddle[Y] - (stimulusSize.Height / 2));

                case C2:
                    currentPosition = matrixPositionsNames[C2];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2));

                case D2:
                    currentPosition = matrixPositionsNames[D2];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2),
               (int)clientMiddle[Y] - (stimulusSize.Height / 2));

                case E2:
                    currentPosition = matrixPositionsNames[E2];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2));

                case F2:
                    currentPosition = matrixPositionsNames[F2];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2));

                case G2:
                    currentPosition = matrixPositionsNames[G2];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2));

                case A3:
                    currentPosition = matrixPositionsNames[A3];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2));

                case B3:
                    currentPosition = matrixPositionsNames[B3];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2));

                case C3:
                    currentPosition = matrixPositionsNames[C3];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2));

                case D3:
                    currentPosition = matrixPositionsNames[D3];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2),
                   (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2));

                case E3:
                    currentPosition = matrixPositionsNames[E3];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                    (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2));

                case F3:
                    currentPosition = matrixPositionsNames[F3];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2),
                    (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2));

                case G3:
                    currentPosition = matrixPositionsNames[G3];
                    return new Point((int)clientMiddle[X] - (stimulusSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                    (int)clientMiddle[Y] - (stimulusSize.Height / 2) + (int)(clientMiddle[Y] / 2));

                default:
                    throw new ArgumentException();
            }

        }

        public Point getPositon(Size stimulusSize)
        {
            this.stimulusSize = stimulusSize;
            Console.WriteLine(pointCount);
            Point position = new Point();
            switch (PointsNumber)
            {
                case 1:
                    position = centerPosition(PointsNumber, pointCount);
                    break;
                case 2:
                    position = twoPointsHorizontalPosition(pointCount);
                    break;
                case 3:
                    position = threePointsPosition(pointCount);
                    break;
                case 4:
                    position = fourPointsPosition(pointCount);
                    break;
                case 5:
                    position = fivePointsPosition(pointCount);
                    break;
                case 6:
                    position = sixPointsPosition(pointCount);
                    break;
                case 7:
                    position = sevenPointsPosition(pointCount);
                    break;
                case 8:
                    position = eightPointsPosition(pointCount);
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
        public Point centerPosition(int pointsNumber, int pointPosition)
        {
            if (pointPosition < pointsNumber)
            {
                /*middle center*/
                float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
                return generatePoint(D2); // D2
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
        public Point twoPointsHorizontalPosition(int pointPosition)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*middle left */
                    return generatePoint(B2);
                case 1: /*middle right */
                    return generatePoint(F2);
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generate point in middle left, middle right or middle center of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be 0, 1 or 2</param>
        /// </summary>
        public Point threePointsPosition(int pointPosition)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*middle left*/
                    return generatePoint(B2);
                case 1: /*middle right*/
                    return generatePoint(F2);
                case 2:/*middle center*/
                    return generatePoint(D2); 
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left or bottom right of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 3</param>
        /// </summary>
        public Point fourPointsPosition(int pointPosition)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    return generatePoint(B1);
                case 1: /*top right*/
                    return generatePoint(F1);
                case 2: /*bottom left*/
                    return generatePoint(B3);
                case 3: /*bottom right*/
                    return generatePoint(F3);
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left, bottom right or middle center of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 4</param>
        /// </summary>
        public Point fivePointsPosition(int pointPosition)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    return generatePoint(B1);
                case 1: /*top right*/
                    return generatePoint(F1);
                case 2: /*bottom left*/
                    return generatePoint(B3);
                case 3: /*bottom right*/
                    return generatePoint(F3);
                case 4: /*middle center*/
                    return generatePoint(D2);
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left, bottom right, top center or bottom center of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 5</param>
        /// </summary>
        public Point sixPointsPosition(int pointPosition)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    return generatePoint(B1);
                case 1: /*top right*/
                    return generatePoint(F1);
                case 2: /*bottom left*/
                    return generatePoint(B3);
                case 3: /*bottom right*/
                    return generatePoint(F3);
                case 4: /*top center*/
                    return generatePoint(D1);
                case 5: /*bottom center*/
                    return generatePoint(D3);
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generate point in top left, top right, bottom left, bottom right, middle center, middle right or middle left of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 6</param>
        /// </summary>
        public Point sevenPointsPosition(int pointPosition)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left*/
                    return generatePoint(B1);
                case 1: /*top right*/
                    return generatePoint(F1);
                case 2: /*bottom left*/
                    return generatePoint(B3);
                case 3: /*bottom right*/
                    return generatePoint(F3);
                case 4: /*middle left*/
                    return generatePoint(B2);
                case 5: /*middle right*/
                    return generatePoint(F2);
                case 6:/*middle center*/
                    return generatePoint(D2);
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generate point in top left left, top left right, top rigt left, top right right, bottom left left, bottom left right, bottom right left or bottom right right of user screen
        /// <param name="stimulusSize"> size of the stimulus that will be shown to user</param>
        /// <param name="pointPosition">poistion of point that will be generated, must be between 0 and 7</param>
        /// </summary>
        public Point eightPointsPosition(int pointPosition)
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            switch (pointPosition)
            {
                case 0: /*top left left*/
                    return generatePoint(A1);
                case 1: /*top left right*/
                    return generatePoint(C1);
                case 2: /*top right left*/
                    return generatePoint(E1);
                case 3: /*top right right*/
                    return generatePoint(G1);
                case 4: /*bottom left left*/
                    return generatePoint(A3);
                case 5: /*bottom left right*/
                    return generatePoint(C3);
                case 6: /*bottom right left*/
                    return generatePoint(E3);
                case 7: /*bottom right right*/
                    return generatePoint(G3);
                default:
                    throw new InvalidOperationException();
            }
        }

        public Point getRandomPosition(Size stimulusSize)
        {
            this.stimulusSize = stimulusSize;
            int number;
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };
            
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            do
            {
                number = rng.Next(21);
            } while (randomPositionsUsed.Contains(number));
            randomPositionsUsed.Add(number);
            switch (number)
            {
                case 0: // A1
                    return generatePoint(A1);
                case 1: // B1
                    return generatePoint(B1);
                case 2: // C1
                    return generatePoint(C1);
                case 3: // D1
                    return generatePoint(D1);
                case 4: // E1
                    return generatePoint(E1);
                case 5: // F1
                    return generatePoint(F1);
                case 6: // G1
                    return generatePoint(G1);
                case 7: // A2
                    return generatePoint(A2);
                case 8: // B2
                    return generatePoint(B2);
                case 9: // C2
                    return generatePoint(C2);
                case 10: // D2
                    return generatePoint(D2);
                case 11: // E2
                    return generatePoint(E2);
                case 12: // F2 
                    return generatePoint(F2);
                case 13: // G2
                    return generatePoint(G2);
                case 14: // A3
                    return generatePoint(A3);
                case 15: // B3
                    return generatePoint(B3);
                case 16: // C3  
                    return generatePoint(C3);
                case 17: // D3
                    return generatePoint(D3);
                case 18: // E3
                    return generatePoint(E3);
                case 19: // F3
                    return generatePoint(F3);
                case 20: // G3
                    return generatePoint(G3);
                default:
                    throw new ArgumentException();
            }
        }

        public string getStimulusPositionMap(Point position, Size stimulusSize)
        {
            int index = -1;
            this.stimulusSize = stimulusSize;

            for (int i = 0; i <= G3; i++)
            {
                if (position == generatePoint(i))
                {
                    index = i;
                }
            }
            if (index > -1)
            {
                return matrixPositionsNames[index];
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
