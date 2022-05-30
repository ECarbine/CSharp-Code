using System;

namespace Delegate
{
    public static class ConsoleDrawing
    {
        public static void Square(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                    Console.Write("o ");
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        public static void Triangle(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < i + 1; j++)
                    Console.Write("o ");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}
