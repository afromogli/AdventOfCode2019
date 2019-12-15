namespace Day3
{
    public struct Intersection
    {
        public Position Point { get; set; }
        public Wire Wire1 { get; internal set; }
        public Wire Wire2 { get; internal set; }
    }
}
