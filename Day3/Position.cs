using System.Collections.Generic;

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

       
    }

    public class PositionComparer : IEqualityComparer<Position>
    {
        public bool Equals(Position item1, Position item2)
        {
            if (object.ReferenceEquals(item1, item2))
                return true;
            if (item1 == null || item2 == null)
                return false;
            return item1.X.Equals(item2.X) &&
                   item1.Y.Equals(item2.Y);
        }

        public int GetHashCode(Position item)
        {
            return new { item.X, item.Y }.GetHashCode();
        }
    }
}
