namespace Gomoku.Models
{
    public interface Player
    {
        public string GetName();
        public Board Move(Board board);
    }
}
