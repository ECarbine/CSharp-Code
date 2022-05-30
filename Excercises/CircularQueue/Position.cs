namespace CircularQueue
{
    public class Position
    {
        public int Left
        {
            get;
        }

        public int Top
        {
            get;
        }

        public Position(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public override string ToString()
        {
            return $"({Left},{Top})";
        }



    }
}