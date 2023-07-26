namespace Gomoku.Models
{
    public class Board
    {
        public Cell[][]? Grid { get; private set; }
        private int GridSize = 15;

        public Board()
        {
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
    }
}
