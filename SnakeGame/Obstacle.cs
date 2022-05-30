using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SnakeGame
{
    /// <summary>
    /// An obstacle class
    /// that can be created vertical or horizontal
    /// </summary>
    class Obstacle
    {
        public int length;
        public bool IsVertical { get; }
        ArrayList Positions = new ArrayList();

        public Position drawPosition { get; }

        /// <summary>
        /// Returns the position of the obstacle
        /// </summary>
        /// <returns>Returns the Position Object</returns>
        public ArrayList getPositions()
        {
            return Positions;
        }

        /// <summary>
        /// Creates an obstacle object
        /// Adds the position of every character it
        /// takes up to an array for use during collision detection
        /// </summary>
        /// <param name="p"> the Position of the obstacle</param>
        /// <param name="length">the length of the obstacle</param>
        /// <param name="isVertical">A bool value representing 
        /// whether or not the obstacle is Vertical or horizontal</param>
        public Obstacle(Position p, int length, bool isVertical)
        {
            this.drawPosition = p;
            this.length = length;

            this.IsVertical = isVertical;



            if (!IsVertical)
            {
                for(int x = drawPosition.Left; x < drawPosition.Left + length; x++)
                {
                    Positions.Add(new Position(x, drawPosition.Top));
                }
            }
            else
            {
                for (int i = drawPosition.Top; i < drawPosition.Top + length; i++)
                {
                    Positions.Add(new Position(drawPosition.Left, i));
                }
            }
        }

        /// <summary>
        /// Draws the obstacle based on it's values
        /// </summary>
        public void Draw()
        {

            Console.CursorTop = drawPosition.Top;
            Console.CursorLeft = drawPosition.Left;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            if (!IsVertical)
            {
                Console.WriteLine(new string(' ', length));                                                                                                         
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(' ');
                    Console.CursorLeft = drawPosition.Left;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;

        }

    }
}
