using Gomoku.Models;
using System;
using System.Numerics;
using static Gomoku.Models.Cell;

namespace GomokuGame.Models
{
    public class ComputerPlayer : Player
    {
        private Random random = new Random();
        private string Name;
        private string[] names = new string[] {
            "John", "Mark", "Isabella","Alano", "Trever", "Delphine", "Sigismundo",
            "Shermie", "Filide", "Daniella", "Annmarie", "Bartram",
            "Pennie", "Rafael", "Celine", "Kacey", "Saree", "Tu",
            "Erny", "Evonne", "Charita", "Anny", "Mavra", "Fredek",
            "Silvio", "Cam", "Hulda", "Nanice", "Iolanthe", "Brucie",
            "Kara", "Paco"};
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
            return board;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
