using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public interface IPlayerFactory
    {
        public Player CreatePlayer(StoneColor stoneColor, IScreen screen);
    }
}
