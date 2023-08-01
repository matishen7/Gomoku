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
            var gameMode = new GameMode(screen);
            player1 = gameMode.CreatePlayer(Cell.StoneColor.Black);
            screen.Display($"Player with name {player1.GetName()} created.");
            player2 = gameMode.CreatePlayer(Cell.StoneColor.White);
            screen.Display($"Player with name {player1.GetName()} created.");

            boardBuilder = new BoardBuilder();
            board = boardBuilder.Build();
            currentPlayer = player1;
            while (!board.IsEndOfGame())
            {
                screen.Display($"{currentPlayer.GetName()}'s move");
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
    }
}
