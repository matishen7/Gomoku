﻿using Gomoku.Models;
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
        public bool isBlack = false;
        public ComputerPlayer()
        {
            Name = names[random.Next(0, names.Length)];
        }
        public Board Move(Board board)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));
            var x = random.Next(board.GetGridSize());
            var y = random.Next(board.GetGridSize());
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
