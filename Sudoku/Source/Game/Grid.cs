using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku;

namespace Sudoku.Source.Game
{
    internal static class Grid
    {
        private static readonly List<int> Squares = new List<int>(Constants.BoardSize);

        static Grid()
        {
            for (int i = 0; i < Constants.BoardSize; i++)
            {
                Grid.Squares.Add(i);
            }
        }

        internal static List<int> GetAllSquares()
        {
            return Grid.Squares;
        }

        internal static List<int> GetRow(int rowNumber)
        {
            List<int> row = new List<int>(9);
            for (int i = 0; i < 9; i++)
            {
                row.Add(Squares[i + (rowNumber * 9)]);
            }
            return row;
        }

        internal static List<int> GetColumn(int columnNumber)
        {
            List<int> column = new List<int>(9);
            for (int i = 0; i < 9; i++)
            {
                column.Add(Grid.Squares[(i * 9) + columnNumber]);
            }
            return column;
        }

        internal static List<int> GetRegion(int regionNumber)
        {
            List<int> region = new List<int>(9);
            int horizontalOffset = (regionNumber / 3) * 3;
            for (int i = horizontalOffset; i < horizontalOffset + 3; i++)
            {
                List<int> row = Grid.GetRow(i);
                int verticalOffset = (regionNumber % 3) * 3;
                for (int j = verticalOffset; j < verticalOffset + 3; j++)
                {
                    region.Add(row[j]);
                }
            }
            return region;
        }
    }
}