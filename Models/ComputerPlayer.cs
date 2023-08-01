using Gomoku.Models;
using System;
using System.Numerics;
using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public class ComputerPlayer : Player
    {
        private Random random = new Random();
        private string name;
        private StoneColor myColor;
        private string[] names = new string[] {
            "John",
            "Mark",
            "Isabella",
            "Emma",
            "Liam",
            "Olivia",
            "Noah",
            "Ava",
            "Elijah",
            "Sophia",
            "James",
            "Isabella",
            "Lucas"};
        public ComputerPlayer(StoneColor color)
        {
            name = names[random.Next(0, names.Length)];
            this.myColor = color;
        }
        public Board Move(Board board)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));
            var x = random.Next(board.GetGridSize());
            var y = random.Next(board.GetGridSize());
            while (board?.grid?[x][y].Color != StoneColor.Empty)
            {
                x = random.Next(board.GetGridSize());
                y = random.Next(board.GetGridSize());
            }

            board.grid[x][y].Color = myColor;

            board.CheckForWin(x, y);
            return board;
        }

        public string GetName()
        {
            return name;
        }
    }
}
