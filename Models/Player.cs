using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public interface Player
    {
        public string GetName();
        public Board Move(Board board);
    }

    public interface IPlayerFactory
    {
        public Player CreatePlayer(StoneColor stoneColor, IScreen screen);
    }
}
