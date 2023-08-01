using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public class HumanPlayerFactory : IPlayerFactory
    {
        public Player CreatePlayer(StoneColor stoneColor, IScreen screen)
        {
            screen.Display("Specify name :");
            var name = screen.ReadLine();
            return new HumanPlayer(name, stoneColor, screen);   
        }
    }
}
