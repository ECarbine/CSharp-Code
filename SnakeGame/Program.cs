using System;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayTitle();

            Snake snake = new Snake(20);
            PlayArea p = new PlayArea(60, 20);
            p.Setup(snake);

            DisplayInstructions();

            Stopwatch timer = new Stopwatch();
            timer.Start();

            //Game Loop
            while (snake.IsAlive)
            {
                snake.Move(p);
                p.ReadInput(snake);
                Thread.Sleep(75);
            }

            DisplayGameOver(timer);

        }

        /// <summary>
        /// Displays the timer when the game is over
        /// </summary>
        /// <param name="timer"></param>
        private static void DisplayGameOver(Stopwatch timer)
        {
            Console.SetCursorPosition(24, 23);

            timer.Stop();
            Console.Beep();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Time Alive: " + timer.ElapsedMilliseconds / 1000 + "." + timer.ElapsedMilliseconds);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(70, 23);

        }

        /// <summary>
        /// Displays the title
        /// </summary>
        private static void DisplayTitle()
        {
            Console.CursorVisible = false;

            Console.CursorLeft = 26;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("S N A K E  G A M E");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the instructions before the game begins
        /// Instructions disappear when enter is hit
        /// </summary>
        private static void DisplayInstructions()
        {
            Console.SetCursorPosition(24, 25);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press enter to being");
            Console.ReadLine();

            Console.SetCursorPosition(24, 25);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                    ");
        }
    }
}
