using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Models
{
    public class ConsoleScreen : IScreen
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Display(string output)
        {
            Console.WriteLine(output);
        }

        public void DisplayBoard(Board board)
        {
            for (int i = 0; i < board.GetGridSize(); i++)
            {
                for (int j = 0; j < board.grid[i].Length; j++)
                    if (board.grid[i][j].Color == Cell.StoneColor.Black) Console.Write("X");
                    else if (board.grid[i][j].Color == Cell.StoneColor.White) Console.Write("O");
                    else Console.Write("-");
                Console.WriteLine();
            }
        }
    }
}
