using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practice_Problems
{
    internal class SpiralMatrix
    {
        public static void Main(string[] args)
        {
            int[,] board = {
            { 1,  2,   3,   4 },
            { 5,  6,   7,   8 },
            { 9,  10,  11,  12 },
            { 13, 14,  15,  16 }};

            Spiral_Matrix(board);

        }
        /*          cs          ce
             rs     1   2   3   4
                    5   6   7   8
                    9   10  11  12
             re     13  14  15  16
         
         
         */
        static void Spiral_Matrix(int[,] board)
        {
            int rowStart = 0;
            int rowEnd = board.GetLength(0) - 1;
            //Console.WriteLine(rowEnd);
            int colStart = 0;
            int colEnd = board.GetLength(1) - 1;
            //Console.WriteLine(colEnd);
            while (rowStart <= rowEnd && colStart <= colEnd)
            {
                //top 
                for (int i = colStart; i <= colEnd; i++)
                {
                    Console.Write(board[rowStart, i] + " ");
                }
                rowStart++;

                //right 
                for (int j = rowStart; j <= rowEnd; j++)
                {
                    Console.Write(board[j, colEnd] + " ");
                }
                colEnd--;
                //bottom 
                if (rowStart <= rowEnd)
                {
                    for (int k = colEnd; k >= colStart; k--)
                    {
                        Console.Write(board[rowEnd, k] + " ");
                    }
                    rowEnd--;
                }
                //left
                if (colStart <= colEnd)
                {
                    for (int l = rowEnd; l >= rowStart; l--)
                    {
                        Console.Write(board[l, colStart] + " ");
                    }
                    colStart++;
                }
            }
            }
        }
}
