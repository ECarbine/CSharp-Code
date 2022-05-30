using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Pellet
    {
        public Position pos
        {
            get;
        }

        ConsoleColor color;



        public Pellet(Position p, ConsoleColor c = ConsoleColor.Magenta)
        {
            this.pos = p;
            this.color = c;

        }


        public void draw()
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(pos.Left, pos.Top);
            Console.Write(" ");
        }
    }
}
