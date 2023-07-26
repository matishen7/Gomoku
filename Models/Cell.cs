namespace Gomoku.Models
{
    public class Cell
    {
        public StoneColor Color { get; set; } = StoneColor.Empty;
        public int x, y;
        public Cell()
        {
        }

        public enum StoneColor
        {
            Black,
            White,
            Empty
        }
    }
}
