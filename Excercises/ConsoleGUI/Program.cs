using System;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorLeft = 8;
            Console.CursorTop = 3;
            Console.WriteLine("Console GUI");


            DemoConsole.DemoColor();



            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
