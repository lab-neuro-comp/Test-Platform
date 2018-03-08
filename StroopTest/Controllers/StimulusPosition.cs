using System;
using System.Collections.Generic;
using System.Drawing;

namespace TestPlatform.Controllers
{
    /// <summary>  
    ///  This class manipulates a eight position matrix to show stimulus arround users screen, and also generates random positions
    /// </summary> 
    public class StimulusPosition
    {
        private int pointCount = 0;
        private Size clientSize, stimuluSize;
        private int pointsNumber;
        private const int X = 0, Y = 1;
        private const int A1 = 0, B1 = 1, C1 = 2, D1 = 3, E1 = 4, F1 = 5, G1 = 6, A2 = 7, B2 = 8, C2 = 9, D2 = 10, E2 = 11, F2 = 12, G2 = 13, A3 = 14, B3 = 15, C3 = 16, D3 = 17, E3 = 18, F3 = 19, G3 = 20;
        List<int> randomPositionsUsed;
        private static string[] matrixPositionsNames = new string[21] {"A1", "B1", "C1", "D1", "E1", "F1", "G1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "A3", "B3", "C3", "D3", "E3", "F3", "G3" };
        private Point[] matrixPoints = new Point[21];
        // TODO criar um array de 21 posições, com os a1,a2... e ai criar um array com os points, verificar o iterador de um no outro pra poder responder de forma correta tanto na ida quanto na volta

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

            populatePointsArray();
        }

        /// <summary>  
        ///  Create all possible points that can be used during exposition, according to the user screen
        /// </summary> 
        private void populatePointsArray()
        {
            float[] clientMiddle = { (clientSize.Width / 2), (clientSize.Height / 2) };

            Point A1 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                       (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2));
            matrixPoints[0] = A1;

            Point B1 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2),
                      (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2));
            matrixPoints[1] = B1;

            Point C1 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                  (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2));
            matrixPoints[2] = C1;

            Point D1 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2));
            matrixPoints[3] = D1;

            Point E1 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2));
            matrixPoints[4] = E1;

            Point F1 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2));
            matrixPoints[5] = F1;

            Point G1 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2) - (int)(clientMiddle[Y] / 2));
            matrixPoints[6] = G1;

            Point A2 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[7] = A2;

            Point B2 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[8] = B2;

            Point C2 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[9] = C2;

            Point D2 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[10] = D2;

            Point E2 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[11] = E2;

            Point F2 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[12] = F2;

            Point G2 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[13] = G2;

            Point A3 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2));
            matrixPoints[14] = A3;

            Point B3 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2));
            matrixPoints[15] = B3;

            Point C3 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) - (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2));
            matrixPoints[16] = C3;

            Point D3 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2),
                   (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2));
            matrixPoints[17] = D3;

            Point E3 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) - (int)(clientMiddle[X] / 4),
                    (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2));
            matrixPoints[18] = E3;

            Point F3 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2),
                    (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2));
            matrixPoints[19] = F3;

            Point G3 = new Point((int)clientMiddle[X] - (stimuluSize.Width / 2) + (int)(clientMiddle[X] / 2) + (int)(clientMiddle[X] / 4),
                    (int)clientMiddle[Y] - (stimuluSize.Height / 2) + (int)(clientMiddle[Y] / 2));
            matrixPoints[20] = G3;
        }

        public Point getPositon()
        {

            Point position = new Point();
            switch (pointsNumber)
            {
                case 1:
                    position = centerPosition(pointsNumber, pointCount);
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
                return matrixPoints[D2]; // D2
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
                    return matrixPoints[B2];
                case 1: /*middle right */
                    return matrixPoints[F2];
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
                    return matrixPoints[B2];
                case 1: /*middle right*/
                    return matrixPoints[F2];
                case 2:/*middle center*/
                    return matrixPoints[D2]; 
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
                    return matrixPoints[B1];
                case 1: /*top right*/
                    return matrixPoints[F1];
                case 2: /*bottom left*/
                    return matrixPoints[B3];
                case 3: /*bottom right*/
                    return matrixPoints[F3];
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
                    return matrixPoints[B1];
                case 1: /*top right*/
                    return matrixPoints[F1];
                case 2: /*bottom left*/
                    return matrixPoints[B3];
                case 3: /*bottom right*/
                    return matrixPoints[F3];
                case 4: /*middle center*/
                    return matrixPoints[D2];
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
                    return matrixPoints[B1];
                case 1: /*top right*/
                    return matrixPoints[F1];
                case 2: /*bottom left*/
                    return matrixPoints[B3];
                case 3: /*bottom right*/
                    return matrixPoints[F3];
                case 4: /*top center*/
                    return matrixPoints[D1];
                case 5: /*bottom center*/
                    return matrixPoints[D3];
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
                    return matrixPoints[B1];
                case 1: /*top right*/
                    return matrixPoints[F1];
                case 2: /*bottom left*/
                    return matrixPoints[B3];
                case 3: /*bottom right*/
                    return matrixPoints[F3];
                case 4: /*middle left*/
                    return matrixPoints[B2];
                case 5: /*middle right*/
                    return matrixPoints[F2];
                case 6:/*middle center*/
                    return matrixPoints[D2];
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
                    return matrixPoints[A1];
                case 1: /*top left right*/
                    return matrixPoints[C1];
                case 2: /*top right left*/
                    return matrixPoints[E1];
                case 3: /*top right right*/
                    return matrixPoints[G1];
                case 4: /*bottom left left*/
                    return matrixPoints[A3];
                case 5: /*bottom left right*/
                    return matrixPoints[C3];
                case 6: /*bottom right left*/
                    return matrixPoints[E3];
                case 7: /*bottom right right*/
                    return matrixPoints[G3];
                default:
                    throw new InvalidOperationException();
            }
        }

        public void setStimulusSize(Size stimuluSize)
        {
            this.stimuluSize = stimuluSize;
        }

        public Point getRandomPosition(Size stimuluSize)
        {
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
                    return matrixPoints[0];
                case 1: // B1
                    return matrixPoints[1];
                case 2: // C1
                    return matrixPoints[2];
                case 3: // D1
                    return matrixPoints[3];
                case 4: // E1
                    return matrixPoints[4];
                case 5: // F1
                    return matrixPoints[5];
                case 6: // G1
                    return matrixPoints[6];
                case 7: // A2
                    return matrixPoints[7];
                case 8: // B2
                    return matrixPoints[8];
                case 9: // C2
                    return matrixPoints[9];
                case 10: // D2
                    return matrixPoints[10];
                case 11: // E2
                    return matrixPoints[11];
                case 12: // F2 
                    return matrixPoints[12];
                case 13: // G2
                    return matrixPoints[13];
                case 14: // A3
                    return matrixPoints[14];
                case 15: // B3
                    return matrixPoints[15];
                case 16: // C3  
                    return matrixPoints[16];
                case 17: // D3
                    return matrixPoints[17];
                case 18: // E3
                    return matrixPoints[18];
                case 19: // F3
                    return matrixPoints[19];
                case 20: // G3
                    return matrixPoints[20];
                default:
                    throw new ArgumentException();
            }
        }

        public string getStimulusPositionMap(Point position)
        {
            int index = Array.IndexOf(matrixPoints, position);

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
