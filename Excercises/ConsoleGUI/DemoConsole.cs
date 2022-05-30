using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGUI
{
    class DemoConsole
    {

        public static void DemoColor()
        {


            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.CursorTop = 4;


            int row = 0;
            int i = 0;
            int remaining;
            bool bottomHalf = false;

            for(int x = 0; x < 17; x++)
            {

                Console.CursorLeft = 5;
                remaining = 18 - (row * 2);

                i = row;


                if (row == 8)
                {
                    bottomHalf = true;
                }


                while (i > 0)
                {
                    Console.Write(" ");
                    ToggleBackground();
                    i--;
                }


                Console.Write("{0," + remaining + "}", "  ");


                i = row;
                while (i > 0)
                {
                    ToggleBackground();

                    Console.Write(" ");
                    i--;
                }
                Console.WriteLine();

                if(!bottomHalf)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

        }

        private static void ToggleBackground()
        {
            if(Console.BackgroundColor == ConsoleColor.DarkBlue)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
        }
    }
}
