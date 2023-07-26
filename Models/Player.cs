namespace Gomoku.Models
{
    public interface Player
    {
        public string GetName();
        public Board Move(Board b, int x = 0, int y = 0);
    }
}
