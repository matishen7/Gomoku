// See https://aka.ms/new-console-template for more information
using Gomoku.Models;
using GomokuGame.Models;

Console.WriteLine("Welcome to Gomoku game!");
Console.WriteLine("Choose option to play:\n 1-Computer vs Human 2-Human vs Human 3-Computer vs Computer");
var option = Console.ReadLine();
Player currentPlayer = null;
Player player1 = null;
Player player2 = null;
switch (option)
{
    default:
    case "1":
        {
            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();
            player1 = new ComputerPlayer();
            Console.WriteLine("Computer's name is " + player1.GetName());
            player2 = new HumanPlayer(name);
        }
        break;
    case "2":
        {
            Console.WriteLine("Enter name for Player-1:");
            var name = Console.ReadLine();
            player1 = new HumanPlayer(name);
            Console.WriteLine("Enter name for Player-2:");
            name = Console.ReadLine();
            player2 = new HumanPlayer(name);
        }
        break;
    case "3":
        {
            player1 = new ComputerPlayer();
            Console.WriteLine("1st Computer's name is " + player1.GetName());
            player2 = new ComputerPlayer();
            Console.WriteLine("2nd Computer's name is " + player2.GetName());
        }
        break;
}
