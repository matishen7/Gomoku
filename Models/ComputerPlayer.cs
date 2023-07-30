using Gomoku.Models;
using System;
using System.Numerics;
using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public class ComputerPlayer : Player
    {
        private Random random = new Random();
        private string Name;
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
        private bool isBlack = false;
        public ComputerPlayer(bool isBlack = false)
        {
            Name = names[random.Next(0, names.Length)];
            this.isBlack = isBlack;
        }
        public Board Move(Board board, int x, int y)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));
            x = random.Next(board.GetGridSize());
            y = random.Next(board.GetGridSize());
            while (board?.Grid?[x][y].Color != StoneColor.Empty)
            {
                x = random.Next(board.GetGridSize());
                y = random.Next(board.GetGridSize());
            }

            if (isBlack) board.Grid[x][y].Color = StoneColor.Black;
            else board.Grid[x][y].Color = StoneColor.White;

            board.CheckForWin(x, y);
            return board;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
