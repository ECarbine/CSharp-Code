using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows;
using System.Drawing;

namespace Tetris
{
    /// <summary>
    /// An obstacle class
    /// that can be created vertical or horizontal
    /// </summary>
    class Obstacle
    {
        public int length;
        public bool IsVertical { get; }
        List<Point> Points = new List<Point>();

        public Point drawPoint { get; }

        /// <summary>
        /// Returns the Point of the obstacle
        /// </summary>
        /// <returns>Returns the Point Object</returns>
        public List<Point> getPoints()
        {
            return Points;
        }

        /// <summary>
        /// Creates an obstacle object
        /// Adds the Point of every character it
        /// takes up to an array for use during collision detection
        /// </summary>
        /// <param name="p"> the Point of the obstacle</param>
        /// <param name="length">the length of the obstacle</param>
        /// <param name="isVertical">A bool value representing 
        /// whether or not the obstacle is Vertical or horizontal</param>
        public Obstacle(Point p, int length, bool isVertical)
        {
            this.drawPoint = p;
            this.length = length;

            this.IsVertical = isVertical;



            if (!IsVertical)
            {
                for(int x = drawPoint.X; x < drawPoint.X + length; x++)
                {
                    Points.Add(new Point(x, drawPoint.Y));
                }
            }
            else
            {
                for (int i = drawPoint.Y; i < drawPoint.Y + length; i++)
                {
                    Points.Add(new Point(drawPoint.X, i));
                    Points.Add(new Point(drawPoint.X + 1, i));

                }
            }
        }

        /// <summary>
        /// Draws the obstacle based on it's values
        /// </summary>
        public void Draw()
        {

            Console.CursorLeft = drawPoint.X;
            Console.CursorTop = drawPoint.Y;
            Console.BackgroundColor = ConsoleColor.DarkGray;

            if (!IsVertical)
            {
                Console.WriteLine(new string(' ', length));                                                                                                         
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine("  ");
                    Console.CursorLeft = drawPoint.X;
                }
            }
        }
    }
}
