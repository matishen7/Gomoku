using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Models
{
    public interface IScreen
    {
        public void Display(string output);
        public string ReadLine();

        public void DisplayBoard(Board board);
    }
}
