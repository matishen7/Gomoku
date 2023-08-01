using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Models
{
    public class ConsoleGameEngine
    {
        private Player currentPlayer;
        private Player winner;
        private Player player1;
        private Player player2;
        private Board board;
        private BoardBuilder boardBuilder;
        private IScreen screen;
        public ConsoleGameEngine(IScreen screen) { this.screen = screen; }

        public void Run()
        {
            screen.Display("Choose option to play:\n 1-Computer vs Human 2-Human vs Human 3-Computer vs Computer");
            var option = screen.ReadLine();
            CreatePlayers(option);

            boardBuilder = new BoardBuilder();
            board = boardBuilder.Build();
            currentPlayer = player1;
            while (!board.IsEndOfGame())
            {
                screen.Display(string.Format("{0}'s move", currentPlayer.GetName()));
                currentPlayer.Move(board);
                screen.DisplayBoard(board);
                if (!board.IsEndOfGame())
                    currentPlayer = swapPlayers(currentPlayer, player1, player2);
                else winner = currentPlayer;
            }
            screen.Display("Winner is " + winner.GetName());
        }

        private Player swapPlayers(Player currentPlayer, Player player1, Player player2)
        {
            if (currentPlayer.GetName().Equals(player1.GetName()))
                currentPlayer = player2;
            else currentPlayer = player1;
            return currentPlayer;
        }

        private void CreatePlayers(string option)
        {
            switch (option)
            {
                default:
                case "1":
                    {
                        screen.Display("Enter your name:");
                        var name = screen.ReadLine();
                        player1 = new ComputerPlayer(Cell.StoneColor.Black);
                        screen.Display("Computer's name is " + player1.GetName());
                        player2 = new HumanPlayer(name, Cell.StoneColor.White, screen);
                    }
                    break;
                case "2":
                    {
                        screen.Display("Enter name for Player-1:");
                        var name = screen.ReadLine();
                        player1 = new HumanPlayer(name, Cell.StoneColor.Black, screen);
                        screen.Display("Enter name for Player-2:");
                        name = screen.ReadLine();
                        player2 = new HumanPlayer(name, Cell.StoneColor.White, screen);
                    }
                    break;
                case "3":
                    {
                        player1 = new ComputerPlayer(Cell.StoneColor.Black);
                        screen.Display("1st Computer's name is " + player1.GetName());
                        player2 = new ComputerPlayer(Cell.StoneColor.White);
                        screen.Display("2nd Computer's name is " + player2.GetName());
                    }
                    break;
            }
        }
    }
}
