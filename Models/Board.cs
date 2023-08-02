using System;
using static Gomoku.Models.Cell;
using static System.Formats.Asn1.AsnWriter;

namespace Gomoku.Models
{
    public class Board
    {
        public Cell[][]? grid { get; private set; }
        private int gridSize = 15;
        private bool end = false;
        private static int[,] deltas = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 }, { 1, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 } };

        public Board()
        {
            GridBuild();
        }

        public void SetGridSize(int size)
        {
            gridSize = size;
            GridBuild();
        }

        public int GetGridSize()
        {
            return gridSize;
        }

        private void GridBuild()
        {
            grid = new Cell[gridSize][];
            for (int i = 0; i < gridSize; i++)
            {
                grid[i] = new Cell[gridSize];
                for (int j = 0; j < gridSize; j++)
                    grid[i][j] = new Cell();
            }
        }

        public bool IsEndOfGame()
        {
            return end;
        }

        public void CheckForWin(int x, int y)
        {
            var color = grid[x][y].Color;

            for (int i = 0; i < deltas.GetLength(0); i++)
            {
                int dx = deltas[i, 0];
                int dy = deltas[i, 1];

                int count = 1; // Count the current stone
                int r = x + dx;
                int c = y + dy;

                while (r >= 0 && r < gridSize && c >= 0 && c < gridSize && grid[r][c].Color == color)
                {
                    count++;
                    r += dx;
                    c += dy;
                }

                r = x - dx; // Move back to the original position
                c = y - dy;

                while (r >= 0 && r < gridSize && c >= 0 && c < gridSize && grid[r][c].Color == color)
                {
                    count++;
                    r -= dx;
                    c -= dy;
                }

                if (count >= 5)
                {
                    end = true;
                    break; // No need to check other directions if a win is found
                }
            }
        }
    }
}
