using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberSpiral
{
    public static class SpiralHelper
    {
        public static int[,] SpiralArrayTillNumber(int number, out int rowColCount)
        {
            //find matrix order to create perfect spiral
            rowColCount = Convert.ToInt32(Math.Ceiling(Math.Sqrt(number + 1)));
            
            //if given number does not produce perfect spiral then find the count of empty cells to create perfect square
            int emptyCells = (rowColCount * rowColCount) - (number + 1);

            IList<int> spiralNumbers = new List<int>();

            //Add -1 for empty cells
            for (int iDx = 0; iDx < emptyCells; iDx++)
            {
                spiralNumbers.Add(-1);
            }
            //Add numbers in list from given number to 0.
            for (int iDx = number; iDx >= 0; iDx--)
            {
                spiralNumbers.Add(iDx);
            }

            //arry corresponding to spiral
            int[,] spiralMatrix = new int[rowColCount, rowColCount];

            //constructing spiral matrix
            ConstructSpiralMatrix(spiralNumbers, rowColCount, ref spiralMatrix);

            return spiralMatrix;
        }

        static void ConstructSpiralMatrix(IList<int> spiralNumbers, int rowColCount, ref int[,] mat)
        {
            //define indexes
            int top = 0, bottom = rowColCount - 1;
            int left = 0, right = rowColCount - 1;

            int index = 0;

            while (true)
            {
                if (left > right)
                    break;
                // print top row
                for (int iDx = right; iDx >= left; iDx--)
                {
                    mat[top, iDx] = spiralNumbers[index];
                    index++;
                }
                top++;

                if (top > bottom)
                    break;
                // print left column
                for (int iDx = top; iDx <= bottom; iDx++)
                {
                    mat[iDx, left] = spiralNumbers[index];
                    index++;
                }
                left++;

                if (left > right)
                    break;
                // print bottom row
                for (int iDx = left; iDx <= right; iDx++)
                {
                    mat[bottom, iDx] = spiralNumbers[index];
                    index++;
                }
                bottom--;

                if (top > bottom)
                    break;
                // print right column
                for (int iDx = bottom; iDx >= top; iDx--)
                {
                    mat[iDx, right] = spiralNumbers[index];
                    index++;
                }
                right--;
            }
        }
    }
}