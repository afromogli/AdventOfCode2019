using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public struct Intersection
    {
        public Position Point { get; set; }
        public int Line1Index { get; set; }
        public int Line2Index { get; set; }
        public Wire Wire1 { get; internal set; }
        public Wire Wire2 { get; internal set; }
    }
}
