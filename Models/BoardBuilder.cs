namespace Gomoku.Models
{
    public class BoardBuilder
    {
        protected Board Board;
        private int GridSize = 15;
        public BoardBuilder()
        {
            Board = new Board();
        }

        public BoardBuilder WithGridSize(int size)
        {
            GridSize = size;
            return this;
        }

        public Board Build()
        {
            Board.SetGridSize(GridSize);
            return Board;
        }
    }
}
