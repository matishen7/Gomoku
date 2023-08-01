using System;
using static Gomoku.Models.Cell;
using static System.Formats.Asn1.AsnWriter;

namespace Gomoku.Models
{
    public class Board
    {
        public Cell[][]? Grid { get; private set; }
        private int GridSize = 15;
        private bool end = false;

        public Board()
        {
            GridBuild();
        }

        public void SetGridSize(int size)
        {
            GridSize = size;
            GridBuild();
        }

        public int GetGridSize()
        {
            return GridSize;
        }

        private void GridBuild()
        {
            Grid = new Cell[GridSize][];
            for (int i = 0; i < GridSize; i++)
            {
                Grid[i] = new Cell[GridSize];
                for (int j = 0; j < GridSize; j++)
                    Grid[i][j] = new Cell();
            }
        }

        public bool IsEndOfGame()
        {
            return end;
        }

        public void CheckForWin(int x, int y)
        {
            var color = Grid[x][y].Color;
            if (isHorizontalWin(x, y, color)
            || isVerticalWin(x, y, color)
            || isDiagonalDownWin(x, y, color)
            || isDiagonalUpWin(x, y, color)) end = true;
        }

        private bool isHorizontalWin(int row, int column, StoneColor color)
        {
            return count(row, column, 1, 0, color)
                    + count(row, column, -1, 0, color) == 4;
        }

        private bool isVerticalWin(int row, int column, StoneColor color)
        {
            return count(row, column, 0, 1, color)
                    + count(row, column, 0, -1, color) == 4;
        }

        private bool isDiagonalDownWin(int row, int column, StoneColor color)
        {
            return count(row, column, 1, 1, color)
                    + count(row, column, -1, -1, color) == 4;
        }

        private bool isDiagonalUpWin(int row, int column, StoneColor color)
        {
            return count(row, column, -1, 1, color)
                    + count(row, column, 1, -1, color) == 4;
        }

        private int count(int row, int col, int deltaRow, int deltaCol, StoneColor color)
        {

            int result = 0;
            int r = row + deltaRow;
            int c = col + deltaCol;

            while (r >= 0 && r < GridSize && c >= 0 && c < GridSize && Grid[r][c].Color == color)
            {
                result++;
                r += deltaRow;
                c += deltaCol;
            }

            return result;
        }
    }
}
