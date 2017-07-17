using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral2dArrayMatrix
{
    /// <summary>
    /// Print a given matrix in spiral form
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[,] {
                                        {1, 2, 3, 4 ,5}, 
                                        {6, 7, 8, 9, 10 }, 
                                        {11,12,13, 14, 15},
                                        {16,17, 18, 19,20}
                                    };

            PrintInSpiralOrder(array, array.GetLength(0), array.GetLength(0)); // col is--> and row is down
        }

        private enum DirectionType { right = 0, down = 1, left = 2, Up = 3 };

        private static void PrintInSpiralOrder(int[,] Arr, int row, int col)
        {
            List<int> result = new List<int>();

            int T = 0;
            int L = 0;
            int R = col;
            int B = row;

            DirectionType direction = DirectionType.right;

            while (T < B && L < R)
            {
                if (direction.Equals(DirectionType.right))
                {
                    for (int i = L; i <= R; i++)
                    {
                        result.Add(Arr[T, i]);
                    }
                    direction++;
                    T++; // move to another row
                }
                else if (direction.Equals(DirectionType.down))
                {
                    for (int i = T; i < B; i++)
                    {
                        result.Add(Arr[i, R]);
                    }
                    direction++;
                    R--; //decrement column
                }
                else if (direction.Equals(DirectionType.left))
                {
                    for (int i = R; i >= L; i--) // in a decreasing order
                    {
                        result.Add(Arr[B-1, i]);
                    }
                    direction++;
                    B--; //decrement B.
                }
                else if (direction.Equals(DirectionType.Up))
                {
                    for (int i = B-1; i >= T; i--) // in a decreasing order
                    {
                        result.Add(Arr[i, L]);
                    }
                    direction = 0;
                    L++;
                }

            }
        }
    }
}
