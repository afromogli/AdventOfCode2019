namespace Day3
{
    public class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;

            var pos = (Position)obj;
            return X.Equals(pos.X) &&
                   Y.Equals(pos.Y);
        }

        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }
    }
}
