using System;
using System.Collections.Generic;
using System.Text;

namespace HorseRace
{
    class Lane
    {
        public int StartLeft
        {
            get;
        }

        public int StartTop
        {
            get;
        }

        public int Length
        {
            get;
        }

        public ConsoleColor LaneColor
        {
            get;
        }

        public Lane(int sl, int st, int l, ConsoleColor lc = ConsoleColor.DarkGray)
        {
            StartLeft = sl;
            StartTop = st;
            Length = l;
            LaneColor = lc;
        }

        public void Paint()
        {

            Console.SetCursorPosition(StartLeft, StartTop);
            Console.BackgroundColor = LaneColor;
            Console.Write(new string(' ', Length));
        }

    }
}
