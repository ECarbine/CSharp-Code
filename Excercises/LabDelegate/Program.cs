using System;
using System.Collections.Generic;

namespace Delegate
{
    public class Program
    {
        // TODO 1 and 2: 

        static void Main(string[] args)
        {
            // TODO 3 - TODO 6

            Action<int> draw = ConsoleDrawing.Triangle;
            draw += ConsoleDrawing.Square;



            //DrawAll(ConsoleDrawing.Triangle);

            //DrawAll(ConsoleDrawing.Square);

            DrawAll(draw);

        }
       
        /// <summary>
        ///  Loops through all the numbers in the list data. 
        ///  for each of the numbers it calls the method(s) associated with the delegate drawMethod
        ///  and passes the number as parameter
        ///  After each call of drawMethod the cursor is advanced to the next line
        /// </summary>
        /// <param name="drawMethod"></param>
        private static void DrawAll(Action<int> drawMethod)
        {
            IList<int> data = new List<int> { 3, 5, 7 };

            foreach(int x in data)
            {
                drawMethod(x);
                Console.WriteLine();
            }
        }
    }
}
