using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;


namespace Tetris
{
    /// <summary>
    /// A group of tiles that can move, rotate, and collide with obstacles
    /// </summary>
    class Tetromino
    {
        Point Position;
        public List<Tile> Tiles { get; }

        Point[] Hero = new Point[] { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0) };
        Point[] DarkCyanRicky = new Point[] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 0) };
        Point[] BlueRicky = new Point[] { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1) };
        Point[] CleavlandZ = new Point[] { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 1) };
        Point[] RhodeIslandZ = new Point[] { new Point(1, 0), new Point(2, 0), new Point(0, 1), new Point(1, 1) };
        Point[] TeeWee = new Point[] { new Point(1, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1) };
        Point[] SmashBoy = new Point[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) };

        public Tetromino(Point position, Shape shape)
        {
            Position = position;
            Tiles = new List<Tile>();
            Point[] Shape;
            switch (shape)
            {
                case Tetris.Shape.Hero:
                    Shape = Hero;
                    break;
                case Tetris.Shape.DarkCyanRicky:
                    Shape = DarkCyanRicky;
                    break;
                case Tetris.Shape.BlueRicky:
                    Shape = BlueRicky;
                    break;
                case Tetris.Shape.CleavlandZ:
                    Shape = CleavlandZ;
                    break;
                case Tetris.Shape.RhodeIslandZ:
                    Shape = RhodeIslandZ;
                    break;
                case Tetris.Shape.TeeWee:
                    Shape = TeeWee;
                    break;
                case Tetris.Shape.SmashBoy:
                    Shape = SmashBoy;
                    break;
                default:
                    Shape = SmashBoy;
                    break;
            }

            foreach (Point point in Shape)
            {
                Tiles.Add(new Tile(new Point(point.X * 2 + Position.X, point.Y + Position.Y), (ConsoleColor)(shape)));
            }
        }


        /// <summary>
        /// Moves the tetromino, and all of the tiles that make it up, by the given vector.
        /// Does not move the tetromino if any of the tiles are blocked by anything in the "obstacles" list
        /// </summary>
        /// <param name="vector">Point value representing a direction and intensity of movement</param>
        /// <param name="obstacles">ArrayList of Point values</param>
        /// <returns>True if the tetromino was able to make the specified movement</returns>
        public bool Move(Point vector, List<Point> obstacles)
        {
            Erase();
            foreach (Tile tile in Tiles)
            {
                tile.Move(vector);
            }
            if (Colliding(obstacles))
            {
                foreach (Tile tile in Tiles)
                {
                    tile.Move(new Point(-vector.X, -vector.Y));
                }
                Draw();
                return false;
            }
            Position.X += vector.X * 2;
            Position.Y += vector.Y;
            return true;
        }


        /// <summary>
        /// Rotates the tiles making up the tetromino 90 degrees
        /// Does not rotate the tiles if the rotation would cause them to collide with
        /// any item in the "Obstacles" arraylist.
        /// </summary>
        /// <param name="obstacles">ArrayList of Point values</param>
        public void Rotate(List<Point> obstacles)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Rotate(Position);
            }
            if (Colliding(obstacles))
            {
                foreach (Tile tile in Tiles)
                {
                    tile.Rotate(Position);
                    tile.Rotate(Position);
                    tile.Rotate(Position);
                }
            }
        }


        /// <summary>
        /// Returns true if the tetromino is colliding with any of the points in the "obstacles" ArrayList
        /// </summary>
        /// <param name="obstacles">ArrayList of Point values</param>
        /// <returns>True if the tetromino is colliding with any of the obstacles</returns>
        public bool Colliding(List<Point> obstacles)
        {
            foreach (Tile tile in Tiles)
            {
                if (tile.Colliding(obstacles))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Draws all of the tetromino's Tiles to the screen.
        /// </summary>
        public void Draw()
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw();
            }
        }

        public void Erase()
        {
            foreach (Tile tile in Tiles)
            {
                tile.Erase();
            }
        }


    }
}