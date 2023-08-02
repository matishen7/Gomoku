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
        private GameMode gameMode;
        public ConsoleGameEngine(IScreen screen)
        {
            this.screen = screen;
            gameMode = new GameMode(screen);
        }

        public void Run()
        {
            player1 = gameMode.CreatePlayer(Cell.StoneColor.Black);
            screen.Display($"Player with name {player1.GetName()} created.");
            player2 = gameMode.CreatePlayer(Cell.StoneColor.White);
            screen.Display($"Player with name {player2.GetName()} created.");

            boardBuilder = new BoardBuilder();
            board = boardBuilder.Build();
            currentPlayer = player1;
            while (!board.IsEndOfGame())
            {
                screen.Display($"{currentPlayer.GetName()}'s move");
                var move = currentPlayer.MakeMove(board);
                board.grid[move.x][move.y].Color = currentPlayer.GetColor();
                board.CheckForWin(move.x, move.y);
                screen.DisplayBoard(board);
                if (board.IsEndOfGame()) winner = currentPlayer;
                MoveTurn();
            }
            screen.Display("Winner is " + winner.GetName());
        }

        private void MoveTurn()
        {
            if (currentPlayer.GetName().Equals(player1.GetName()))
                currentPlayer = player2;
            else currentPlayer = player1;
        }
    }
}
