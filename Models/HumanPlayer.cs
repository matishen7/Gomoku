using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public class HumanPlayer : Player
    {
        private string name;
        private IScreen screen;
        private StoneColor myColor;
        public HumanPlayer(string name, StoneColor color, IScreen screen)
        {
            this.name = name;
            this.screen= screen;
            myColor = color;
        }

        public Board Move(Board board)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            screen.Display("Enter coordinates to put a stone: x and y");
            var xStr = screen.ReadLine();
            var yStr = screen.ReadLine();
            var x = Int32.Parse(xStr);
            var y = Int32.Parse(yStr);

            if (x >= board.GetGridSize() || y >= board.GetGridSize()) throw new ArgumentOutOfRangeException("x and y should be less than " + board.GetGridSize());
            if (x < 0 || y < 0) throw new ArgumentOutOfRangeException("x and y should be greater than 0");
            board.Grid[x][y].Color = myColor;
            
            board.CheckForWin(x, y);
            return board;
        }
        public string GetName()
        {
            return name;
        }
    }
}
