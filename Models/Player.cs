using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public interface Player
    {
        public string GetName();
        public (int x, int y) MakeMove(Board board);
        public StoneColor GetColor();
    }

    public interface IPlayerFactory
    {
        public Player CreatePlayer(StoneColor stoneColor, IScreen screen);
    }
}
