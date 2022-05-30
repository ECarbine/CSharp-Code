using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    /// <summary>
    /// A class to play the game snake
    /// </summary>
    class Snake
    {
        public CircularQueue queue { get; }
        public ConsoleColor HeadColor { get; }
        public ConsoleColor BodyColor { get;}
        public bool IsAlive { get; set; }
        public Direction SnakeDirection { get; set; }

        public int length;


        /// <summary>
        /// Creates a snake object and sets its length
        /// enqueues the snakes positions to the circularQueue
        /// </summary>
        /// <param name="l"></param>
        public Snake(int l)
        {
            HeadColor = ConsoleColor.Black;
            BodyColor = ConsoleColor.DarkGreen;
            this.length = l;

            queue = new CircularQueue(length);

            for (int x = 0; x < length; x++)
            {
                queue.Enqueue(new Position(57 - x, 18));
            }


            IsAlive = true;
            SnakeDirection = Direction.LEFT;
        }

        /// <summary>
        /// Draws the snake to the playarea
        /// </summary>
        public void drawSnake()
        {
            Position[] positions = queue.getElements();


            for (int x = 0; x < length; x++)
            {
                Position p = positions[x];


                if (x == queue.getRear())
                {
                    Console.BackgroundColor = HeadColor;
                }
                else
                {
                    Console.BackgroundColor = BodyColor;
                }


                Console.SetCursorPosition(p.Left, p.Top);
                Console.Write(" ");

                Console.SetCursorPosition(0, 26);


            }
        }

        /// <summary>
        /// Moves the snake in it's current direction
        /// </summary>
        /// <param name="p">The playarea the snake is on</param>
        public void Move(PlayArea p)
        {
            Position[] positions = queue.getElements();
            Position tail = positions[queue.getFront()];
            Position head = positions[queue.getRear()];
            Position newHead = head; 

            //Overwrite tail
            Console.SetCursorPosition(tail.Left, tail.Top);
            Console.BackgroundColor = p.Color;
            Console.Write(" ");
            queue.Dequeue();


            //enqueue new position
            switch(SnakeDirection)
            { 
                case Direction.LEFT:
                    newHead = new Position(head.Left - 1, head.Top);
                    break;

                case Direction.UP:
                    newHead = new Position(head.Left, head.Top - 1);
                    break;

                case Direction.DOWN:
                    newHead = new Position(head.Left, head.Top + 1);
                    break;

                case Direction.RIGHT:
                    newHead = new Position(head.Left + 1, head.Top);
                    break;
            }

            queue.Enqueue(newHead);

            //Drawsnake
            drawSnake();

            //Check for Collision
            IsAlive = p.CheckCollision(newHead, this);


            if(newHead.Equals(p.activePellet.pos))
            {
                p.drawNewPellet();
            }
        }
    }

    /// <summary>
    /// A list of directions the snake can move in
    /// </summary>
    public enum Direction
    {
        LEFT,
        UP,
        DOWN,
        RIGHT
    }

    /// <summary>
    /// A verson of a queue that moves in a circle
    /// Front of queue is irrelative to queue index
    /// </summary>
    class CircularQueue
    {

        private int front;
        private int rear;
        private int n;
        private int capacity;
        private Position[] elements;

        /// <summary>
        /// Creates a Circular queue of a given size
        /// </summary>
        /// <param name="capacity">the size of the Circular queue</param>
        public CircularQueue(int capacity)
        {
            this.capacity = capacity;
            this.elements = new Position[capacity];

            n = 0;
            front = -1;
            rear = -1;
        }

        /// <summary>
        /// Gets the elements of the queue
        /// </summary>
        /// <returns>returns the array elements</returns>
        public Position[] getElements()
        {
            return elements;
        }

        /// <summary>
        /// Gets the front Element
        /// </summary>
        /// <returns>the index of the front element</returns>
        public int getFront()
        {
            return front;
        }

        /// <summary>
        /// Gets the rear Element
        /// </summary>
        /// <returns>the index of the rear element</returns>
        public int getRear()
        {
            return rear;
        }

        /// <summary>
        /// Determines if the queue is empty or not
        /// </summary>
        /// <returns>a bool value representing whether the queue is empty or not</returns>
        public bool Empty()
        {
            return n == 0;
        }

        /// <summary>
        /// Determines if the queue is full or not
        /// </summary>
        /// <returns>a bool value representing whether the queue is full or not</returns>
        public bool Full()
        {
            return n == capacity;
        }

        /// <summary>
        /// adds a new element at the front of the queue
        /// </summary>
        /// <param name="p">The position to add to the queue</param>
        public void Enqueue(Position p)
        {
            if (Full())
            {
                throw new InvalidOperationException("Can't add an element to a full queue");
            }

            rear = ++rear % capacity;
            elements[rear] = p;


            if (Empty())
            {
                front = rear;
            }

            n++;

        }

        /// <summary>
        /// Removes an element from the front of the queue
        /// </summary>
        /// <returns>The element at index front</returns>
        public Position Dequeue()
        {
            if (Empty())
            {
                throw new InvalidOperationException("Can't remove an element from an empty queue");

            }

            Position P = elements[front];
            elements[front] = null;

            n--;

            if (!Empty())
            {
                front = ++front % capacity;
            }

            return P;

        }
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            for (int i = front; i < front + n; i++)
            {
                sb.Append(elements[i % capacity]).Append(" ");
            }


            return $"{sb.ToString()} n :{n} front:{front} rear: {rear}";
        }

    }

    /// <summary>
    /// A class that represents X and Y coordinate
    /// </summary>
    public class Position
    {
        public int Left { get; }

        public int Top { get; }

        /// <summary>
        /// Creates a point X,Y
        /// </summary>
        /// <param name="left">the x coordinate</param>
        /// <param name="top">the y coordinate</param>
        public Position(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public override string ToString()
        {
            return $"({Left},{Top})";
        }

        public override bool Equals(object obj)
        {
            Position other = (Position)obj;


            if((this.Left == other.Left) && (this.Top == other.Top))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


