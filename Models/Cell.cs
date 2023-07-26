namespace Gomoku.Models
{
    public class Cell
    {
        public StoneColor Color { get; set; } = StoneColor.Empty;
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
