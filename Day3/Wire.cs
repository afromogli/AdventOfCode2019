﻿using System.Collections.Generic;

namespace Day3
{
    public class Wire
    {
        public Wire()
        {
            Points = new List<Position>();
        }

        public List<Position> Points;

        public override string ToString()
        {
            return $"Points size:{Points.Count}";
        }
    }
}
