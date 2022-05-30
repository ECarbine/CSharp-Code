using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Tetris
{
    /// <summary>
    /// A single square that makes up a tetromino
    /// </summary>
    class Tile
    {
        public Point Position;
        ConsoleColor Color;

        public Tile(Point position, ConsoleColor color)
        {
            Position = position;
            Color = color;
        }


        /// <summary>
        /// Moves the tile by the given directional vector
        /// </summary>
        /// <param name="vector"></param>
        public void Move(Point vector)
        {
            Position.X += vector.X * 2;
            Position.Y += vector.Y;
        }


        /// <summary>
        /// Rotates the tile 90 degrees around the given point
        /// </summary>
        /// <param name="around"></param>
        public void Rotate(Point around)
        {
            int x = Position.X - around.X;
            int y = Position.Y - around.Y;
            Position.X = (int)(y * 2 + around.X + 0.5);
            Position.Y = (int)(-x / 2 + around.Y + 1);
            if (Position.X % 2 != 0) Position.X -= 1;

        }


        /// <summary>
        /// Returns true if the tile is in the same position as any of the positions in the "obstacles" ArrayList
        /// </summary>
        /// <param name="obstacles"></param>
        /// <returns>True if the tile is colliding with any points in the list</returns>
        public bool Colliding(List<Point> obstacles)
        {
            foreach (Point obstacle in obstacles)
            {
                if (Position.X == obstacle.X && Position.Y == obstacle.Y)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Draws the tile to the screen
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.BackgroundColor = Color;
            Console.WriteLine("  ");
        }

        public void Erase()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("  ");
        }
    }
}