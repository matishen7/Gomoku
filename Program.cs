// See https://aka.ms/new-console-template for more information
using Gomoku.Models;
{
    var consoleScreen = new ConsoleScreen();
    var game = new ConsoleGameEngine(consoleScreen);
    game.Run();
}
