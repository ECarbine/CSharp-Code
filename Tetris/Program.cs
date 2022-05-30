using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard area = new GameBoard();
            area.Setup();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
