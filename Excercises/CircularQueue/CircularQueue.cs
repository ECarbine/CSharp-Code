using System;
using System.Collections.Generic;
using System.Text;

namespace CircularQueue
{
    class CircularQueue
    {

        private int front;
        private int rear;
        private int n;
        private int capacity;
        private Position[] elements;

        public CircularQueue(int capacity)
        {
            this.capacity = capacity;
            this.elements = new Position[capacity];

            n = 0;
            front = -1;
            rear = -1;
        }

        public bool Empty()
        {
            return n == 0;
        }

        public bool Full()
        {
            return n == capacity;
        }

        public void Enqueue(Position p)
        {
            if(Full())
            {
                throw new InvalidOperationException("Can't add an element to a full queue");
            }

            rear = ++rear % capacity;
            elements[rear] = p;


            if(Empty())
            {
                front = rear;
            }

            n++;

        }

        public Position Dequeue()
        {
            if(Empty())
            {
                throw new InvalidOperationException("Can't remove an element from an empty queue");

            }

            Position P = elements[front];
            elements[front] = null;

            n--;

            if(!Empty())
            {
                front = ++front % capacity;
            }

            return P;

        }


        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            for(int i = front; i < front + n; i++)
            {
                sb.Append(elements[i % capacity]).Append(" ");
            }


            return $"{sb.ToString()} n :{n} front:{front} rear: {rear}";
        }

    }
}
