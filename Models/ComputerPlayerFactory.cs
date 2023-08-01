using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gomoku.Models.Cell;

namespace Gomoku.Models
{
    public class ComputerPlayerFactory : IPlayerFactory
    {
        public Player CreatePlayer(StoneColor stoneColor, IScreen screen)
        {
            return new ComputerPlayer(stoneColor);
        }

    }
}
