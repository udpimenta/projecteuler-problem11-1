using System;
using System.IO;
using System.Linq;

namespace ProjectEuler.Business
{
    /// <summary>Represents Euler's Problem #11</summary>
    public class Problem11
    {
        #region Public Methods

        /// <summary></summary>
        /// <param name="inputGrid"></param>
        /// <returns>The greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally)</returns>
        public int Solve(string inputGrid)
        {
            return Solve(ReadInputFromString(inputGrid));
        }

        /// <summary></summary>
        /// <param name="inputGrid"></param>
        /// <returns>The greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally)</returns>
        public int Solve(int[,] inputGrid)
        {
            var rows = inputGrid.GetLength(0);
            var columns = inputGrid.GetLength(1);
            var greatest = 0;
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    if (c < columns - 3) // Right and "Left"
                        greatest = Math.Max(greatest, inputGrid[r, c] * inputGrid[r, c + 1] * inputGrid[r, c + 2] * inputGrid[r, c + 3]);

                    if (r < rows - 3)
                    {
                        // Down and "Up"
                        greatest = Math.Max(greatest, inputGrid[r, c] * inputGrid[r + 1, c] * inputGrid[r + 2, c] * inputGrid[r + 3, c]);

                        // Diagonally, down to the right
                        if (c < columns - 3)
                            greatest = Math.Max(greatest, inputGrid[r, c] * inputGrid[r + 1, c + 1] * inputGrid[r + 2, c + 2] * inputGrid[r + 3, c + 3]);

                        // Diagonally, down to the left
                        if (c > 3)
                            greatest = Math.Max(greatest, inputGrid[r, c] * inputGrid[r + 1, c - 1] * inputGrid[r + 2, c - 2] * inputGrid[r + 3, c - 3]);
                    }
                }
            }

            return greatest;
        }

        /// <summary></summary>
        /// <param name="fileName">The file name where the array in string format is in</param>
        /// <returns>The greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally)</returns>
        public int SolveFromFileName(string filename)
        {
            return Solve(ReadInputFromFilename(filename));
        }

        #endregion

        #region Private Methods

        /// <summary>Converts a given string into a 2D array</summary>
        /// <param name="inputGrid">The array in string format</param>
        /// <returns>2D array of int[,]</returns>
        private int[,] ReadInputFromString(string inputGrid)
        {
            inputGrid = inputGrid.Replace(",", "");
            inputGrid = inputGrid.Replace(";", "");
            inputGrid = inputGrid.Replace("\r", "");
            return To2D<int>(inputGrid
                .Split('\n')
                .Select(t => t.Split(' ')
                            .Where(t1 =>
                            {
                                int i = 0;
                                return int.TryParse(t1, out i);
                            })
                            .Select(int.Parse).ToArray()
                        ).ToArray());
        }

        /// <summary>Reads a file with an array as string and converts it into a 2D array</summary>
        /// <param name="fileName">The file name where the array in string format is in</param>
        /// <returns>2D array of int[,]</returns>
        private int[,] ReadInputFromFilename(string fileName)
        {
            int lines = 0;
            string line;
            string[] linePieces;

            var r = new StreamReader(fileName);
            while (r.ReadLine() != null)
            {
                lines++;
            }

            var inputGrid = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    inputGrid[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }
            r.Close();

            return inputGrid;
        }

        /// <summary>Converts the given jagged array into a 2D array</summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="source">The jagged array</param>
        /// <returns>2D array of type 'T'</returns>
        private T[,] To2D<T>(T[][] source)
        {
            try
            {
                int firstDim = source.Length;
                int secondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[firstDim, secondDim];
                for (int i = 0; i < firstDim; ++i)
                    for (int j = 0; j < secondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }

        #endregion
    }
}