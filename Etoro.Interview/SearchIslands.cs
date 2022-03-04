using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etoro.Interview
{
    internal class SearchIslands
    {
        static int[,] board = {
                          { 1, 0, 0, 0, 0 },
                          {0, 0, 0, 0, 0 },
                          {0, 0, 1, 0, 1 },
                          {0, 0, 0, 0, 0 },
                          {1, 0, 0, 0, 1 },
                          {1, 1, 0, 0, 1 }
                        };

        // function to explore each island
        static void searchIslands(int row, int col, int[,] matrix)
        {
            // boarder cheking
            if (row < 0 || col < 0 || row >= matrix.GetLength(1) || col >= Enumerable.Range(0, matrix.GetLength(1))
                                                                    .Select(x => matrix[row, x])
                                                                    .ToArray().Length)
            {
                return;
            }

            // checking if its not part of the island or already explored
            if (matrix[row,col] == 0)
            {
                return;
            }

            // marking the current part as "explored"
            matrix[row,col] = 0;

            // the exploring logic
            // look all around the element
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    // testing to ignore the current element
                    if (r != row || c != col)
                    {
                        searchIslands(r, c, matrix);
                    }
                }
            }
            return;
        }

        // function to explore the board
        static int rotateBoard(int[,] matrix)
        {
            int numOfIslands = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] currentRow = Enumerable.Range(0, matrix.GetLength(1))
                                    .Select(x => matrix[row, x])
                                    .ToArray();// matrix[row];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    // explore only parts that are island and isnt explored yet
                    if (currentRow[col] == 1)
                    {
                        numOfIslands++;
                        searchIslands(row, col, matrix);
                    }
                }
            }
            return numOfIslands;
        }

        public static void Run() {
            Console.WriteLine(rotateBoard(board));
        }
    }
}
