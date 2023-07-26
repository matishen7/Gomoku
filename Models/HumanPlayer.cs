using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public class HumanPlayer : Player
    {
        private string Name;
        public bool isBlack = true;
        public HumanPlayer(string name, bool isBlack = true)
        {
            Name = name;
            this.isBlack = isBlack;
        }

        public Board Move(Board board, int x, int y)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));
            if (x >= board.GetGridSize() || y >= board.GetGridSize()) throw new ArgumentException("x and y should be less than " + board.GetGridSize());
            if (x < 0 || y < 0) throw new ArgumentException("x and y should be greater than 0");
            if (isBlack) board.Grid[x][y].Color = StoneColor.Black;
            else board.Grid[x][y].Color = StoneColor.White;
            return board;
        }
        public string GetName()
        {
            return Name;
        }
    }
}
