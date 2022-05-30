using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Threading;
using System.Linq;
using System.IO;

namespace Tetris
{
    class GameBoard
    {
        List<Point> collisions = new List<Point>();
        List<Point> wallPoints = new List<Point>();
        Queue<string> drawQueue = new Queue<string>();
        IList<Tile> Tiles = new List<Tile>();
        Tetromino tetromino;
        private static int score;
        private static int highscore;
        private int gameSpeed = 300;
        bool speedUp = true;

        public GameBoard()
        {
            score = 0;
            try
            {
                StreamReader read = new StreamReader("highscore.txt");
                highscore = Int32.Parse(read.ReadLine());

                read.Close();
            }
            catch(IOException)
            {
                Console.WriteLine("Couldn't find file highscore.txt");
            }

            DisplayScore(score);
            DisplayInstructions();
            Setup();
        }

        public void Setup()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Obstacle leftWall = new Obstacle(new Point(40, 3), 20, true);
            collisions.AddRange(leftWall.getPoints());
            wallPoints.AddRange(leftWall.getPoints());
            leftWall.Draw();


            Obstacle rightWall = new Obstacle(new Point(62, 3), 20, true);
            collisions.AddRange(rightWall.getPoints());
            wallPoints.AddRange(rightWall.getPoints());
            rightWall.Draw();

            Obstacle bottomWall = new Obstacle(new Point(40, 23), 24, false);
            collisions.AddRange(bottomWall.getPoints());
            wallPoints.AddRange(bottomWall.getPoints());
            bottomWall.Draw();

            tetromino = new Tetromino(new Point(50, 3), (Shape)(Enum.GetValues(typeof(Shape)).GetValue(new Random().Next(0, 7))));
            drawQueue.Enqueue("Tetromino");

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    ReadInput(tetromino);
                    if(drawQueue.Count() > 0)
                    {
                        drawThings(drawQueue.Dequeue());
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();


            while (true)
            {
                drawQueue.Enqueue("EraseTetromino");


                tetromino.Erase();
                if (!tetromino.Move(new Point(0, 1), collisions))
                {

                    foreach (Tile tile in tetromino.Tiles)
                    {
                        Tiles.Add(tile);
                        collisions.Add(tile.Position);
                        collisions.Add(new Point(tile.Position.X + 1, tile.Position.Y));
                    }
                    ClearLines();
                    tetromino = new Tetromino(new Point(50, 3), (Shape)(Enum.GetValues(typeof(Shape)).GetValue(new Random().Next(0, 7))));
                    if (tetromino.Colliding(collisions))
                        break;
                }

                drawQueue.Enqueue("Tiles");
                drawQueue.Enqueue("Tetromino");
                

                Thread.Sleep(gameSpeed);

            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You have failed.");

            try
            {
                using (StreamWriter w = File.CreateText("highscore.txt"))
                {
                    if (score > highscore)
                    {
                        w.Write(score);
                    }
                    else
                    {
                        w.Write(highscore);
                    }


                    w.Close();
                }
            }
            catch(IOException)
            {
                Console.WriteLine("Couldn't find file");
            }
        }

        private void ClearLines()
        {
            int lineCounter = 0;
            int lineClearedY = 0;
            bool lineCleared = false;

            for (int line = 22; line > 3; line--)
            {
                var results =
                from tile in Tiles
                where tile.Position.Y == line
                select tile;


                if (results.Count() == 10)
                {
                    if (!lineCleared)
                    {
                        lineClearedY = line;
                        lineCleared = true;
                    }

                    List<Tile> removeTiles = new List<Tile>();

                    foreach (Tile x in Tiles)
                    {
                        if (x.Position.Y == line)
                        {
                            removeTiles.Add(x);
                            x.Erase();
                        }
                    }

                    foreach (Tile x in removeTiles)
                    {
                        Tiles.Remove(x);
                    }

                    List<Point> removePoint = new List<Point>();

                    foreach (Point x in collisions)
                    {
                        if (x.Y == line)
                        {
                            removePoint.Add(x);
                        }
                    }
                    foreach (Point x in removePoint)
                    {
                        collisions.Remove(x);
                    }


                    foreach (Tile x in results)
                    {
                        x.Erase();
                    }

                    lineCounter++;
                }
            }

            if (lineCleared)
            {
                var moveLines =
               from tile in Tiles
               where tile.Position.Y < lineClearedY
               select tile;

                foreach (Tile x in moveLines)
                {
                    x.Erase();
                    x.Move(new Point(0, lineCounter));
                    x.Draw();
                }
            }

            List<Point> newPoints = new List<Point>(wallPoints);

            var moveCollisions =
               from collision in collisions
               where collision.Y > lineClearedY
               select collision;

            newPoints.AddRange(moveCollisions);

            moveCollisions =
                from collision in collisions
                where collision.Y < lineClearedY
                select collision;

            foreach (Point x in moveCollisions)
            {
                newPoints.Add(new Point(x.X, x.Y + lineCounter));
            }

            collisions = newPoints;

            switch (lineCounter)
            {
                case 1:
                    DisplayScore(40);
                    break;

                case 2:
                    DisplayScore(100);
                    break;

                case 3:
                    DisplayScore(300);
                    break;

                case 4:
                    DisplayScore(1200);
                    break;
            }
        }

        private void ReadInput(Tetromino tetromino)
        {
            if (Console.KeyAvailable)
            {
                tetromino.Erase();
                ConsoleKey x = Console.ReadKey().Key;
                drawQueue.Enqueue("EraseTetromino");
                switch (x)
                {

                    case ConsoleKey.RightArrow:
                        tetromino.Move(new Point(1, 0), collisions);
                        break;

                    case ConsoleKey.LeftArrow:
                        tetromino.Move(new Point(-1, 0), collisions);
                        break;

                    case ConsoleKey.DownArrow:
                        if (speedUp)
                        {
                            speedUp = false;
                            gameSpeed = 50;
                        }
                        else
                        {
                            speedUp = true;
                            gameSpeed = 400;
                        }

                        break;

                    case ConsoleKey.UpArrow:
                        tetromino.Rotate(collisions);
                        break;
                }
                drawQueue.Enqueue("Tetromino");

            }

        }

        public void drawThings(string things)
        {
            switch(things)
            {
                case "Tetromino":
                    tetromino.Draw();
                    break;
                case "EraseTetromino":
                    tetromino.Erase();
                    break;
                case "Tiles":
                    drawTiles();
                    break;
            }
        }       
        public void drawTiles()
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw();
            }
        }
        public static void DisplayScore(int addScore)
        {
            score += addScore;


            Console.SetCursorPosition(28, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"Score: {score}");
        }

        public static void DisplayInstructions()
        {
            Console.SetCursorPosition(26, 5);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Scoring:");

            Console.SetCursorPosition(26, 6);
            Console.WriteLine($"1 line: {"40",4}");

            Console.SetCursorPosition(26, 7);
            Console.WriteLine($"2 lines: {"100",2}");

            Console.SetCursorPosition(26, 8);
            Console.WriteLine($"3 lines: {"300",2}");

            Console.SetCursorPosition(26, 9);
            Console.WriteLine($"{"Tetris: 1200",10}");

            Console.SetCursorPosition(66, 5);
            Console.WriteLine($"Move Left: Left Arrow");

            Console.SetCursorPosition(66, 6);
            Console.WriteLine($"Move Right: Right Arrow");

            Console.SetCursorPosition(66, 7);
            Console.WriteLine($"Fall Faster: Down Arrow to Toggle");

            Console.SetCursorPosition(66, 8);
            Console.WriteLine($"Rotate: Up Arrow");

            Console.SetCursorPosition(66, 20);
            Console.WriteLine($"HighScore: {highscore}");
        }
    }
}