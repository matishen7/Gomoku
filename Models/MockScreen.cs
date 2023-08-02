using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Models
{
    public class MockScreen : IScreen
    {
        private Queue<string> inputQueue = new Queue<string>();

        public void SetUserInput(params string[] inputs)
        {
            foreach (var input in inputs)
            {
                inputQueue.Enqueue(input);
            }
        }

        public string ReadLine()
        {
            if (inputQueue.Count > 0)
            {
                return inputQueue.Dequeue();
            }

            return null; // or throw an exception for unexpected ReadLine calls
        }

        public void Display(string message)
        {
            // Do nothing for the Display method in the mock implementation.
        }

        public void DisplayBoard(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
