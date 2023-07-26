namespace Gomoku.Models
{
    public class Cell
    {
        public StoneColor Color { get; set; } = StoneColor.Red;
        public Cell()
        {

        }

        public enum StoneColor
        {
            Black,
            Red,
            Empty
        }
    }
}
