using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SnakeGame
{
    /// <summary>
    /// A Class that represents the game board, 
    /// with its background and obstacles.
    /// </summary>
    class PlayArea
    {

        private int Top { get; }
        private int Left { get; }
        public ConsoleColor Color { get; }
        public ArrayList obstaclePositions = new ArrayList();

        public Pellet activePellet { get; set; }

        public int length;
        public int height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l">Length of the playArea</param>
        /// <param name="h">Height of the playArea</param>
        /// <param name="c">Color of the playArea</param>
        public PlayArea(int l, int h, ConsoleColor c = ConsoleColor.DarkGray)
        {
            this.length = l;
            this.height = h;

            Top = 2;
            Left = 5;


            this.Color = c;


        }

        /// <summary>
        /// Draws the Playarea
        /// </summary>
        public void Draw()
        {
            Console.CursorTop = Top;
            Console.BackgroundColor = Color;


            for (int x = 0; x < height; x++)
            {
                Console.CursorLeft = Left;
                Console.WriteLine(new String(' ', length));
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Setup method to create obstacles, draw them, and add to obstacle list.
        /// Also draws the playarea
        /// </summary>
        /// <param name="s"></param>
        public void Setup(Snake s)
        {
            Draw();

            s.drawSnake();

            Obstacle o1 = new Obstacle(new Position(20, 6), 5, true);
            obstaclePositions.AddRange(o1.getPositions());
            o1.Draw();

            Obstacle o2 = new Obstacle(new Position(40,6), 5, true);
            obstaclePositions.AddRange(o2.getPositions());
            o2.Draw();

            Obstacle o3 = new Obstacle(new Position(25, 15), 10, false);
            obstaclePositions.AddRange(o3.getPositions());
            o3.Draw();

            Obstacle leftWall = new Obstacle(new Position(5,2), 20, true);
            obstaclePositions.AddRange(leftWall.getPositions());
            leftWall.Draw();

            Obstacle topWall = new Obstacle(new Position(5, 2), 60, false);
            obstaclePositions.AddRange(topWall.getPositions());
            topWall.Draw();

            Obstacle rightWall = new Obstacle(new Position(64, 2), 20, true);
            obstaclePositions.AddRange(rightWall.getPositions());
            rightWall.Draw();

            Obstacle bottomWall = new Obstacle(new Position(5, 22), 60, false);
            obstaclePositions.AddRange(bottomWall.getPositions());
            bottomWall.Draw();

            drawNewPellet();

        }

        /// <summary>
        /// A method that listens for keyboard input.
        /// if input is detected to be one of the arrowkeys, it updates the snakes Direction Property.
        /// </summary>
        /// <param name="snakeyBoy"> the snake object to update if keyinput is detected.</param>
        public void ReadInput(Snake snakeyBoy)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey x = Console.ReadKey().Key;

                switch (x)
                {
                    case ConsoleKey.UpArrow:

                        if(snakeyBoy.SnakeDirection != Direction.DOWN)
                        {
                            snakeyBoy.SnakeDirection = Direction.UP;
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        if(snakeyBoy.SnakeDirection != Direction.UP)
                        {
                            snakeyBoy.SnakeDirection = Direction.DOWN;
                        }
                        
                        break;

                    case ConsoleKey.LeftArrow:

                        if (snakeyBoy.SnakeDirection != Direction.RIGHT)
                        {
                            snakeyBoy.SnakeDirection = Direction.LEFT;
                        }

                        break;

                    case ConsoleKey.RightArrow:

                        if (snakeyBoy.SnakeDirection != Direction.LEFT)
                        {
                            snakeyBoy.SnakeDirection = Direction.RIGHT;
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// A method that checks for collision between the snake and other objects
        /// </summary>
        /// <param name="head"> The head of the snake</param>
        /// <param name="s"> the snake object for reference</param>
        /// <returns></returns>
        internal bool CheckCollision(Position head, Snake s)
        {
            ArrayList snakePositions = new ArrayList();
            snakePositions.AddRange(s.queue.getElements());
            snakePositions.RemoveAt(s.queue.getRear());

            ArrayList allObstacles = new ArrayList(obstaclePositions);
            allObstacles.AddRange(snakePositions);

            foreach(Position o in allObstacles)
            {

                if (o.Equals(head))
                {
                    return false;
                }
            }

            return true;
        }

        public void drawNewPellet()
        {
            Random r = new Random();

            Position newPos = new Position(r.Next(6, 64), r.Next(4, 22));
            Pellet newPellet = new Pellet(newPos);
            newPellet.draw();

            activePellet = newPellet;
        }
    }
}
