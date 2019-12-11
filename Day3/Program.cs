using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = File.ReadAllLines(@"input1.txt");

            Console.WriteLine(CalcShortestDistance(input1));
        }

        private static int CalcShortestDistance(string[] wires)
        {
            List<Wire> allWires = new List<Wire>();
            
            for (int i = 0; i < wires.Length; i++)
            {
                var currentWire = new Wire();
                string currentWireString = wires[i];

                string[] instruction = currentWireString.Split(',');

                for (int j = 0; j < instruction.Length; j++)
                {
                    var currentLine = new Line();

                    if (j == 0)
                    {
                        currentLine.Start = new Position();   
                    }
                    else
                    {
                        currentLine.Start = new Position() { X = currentWire.Lines[j - 1].End.X, Y = currentWire.Lines[j - 1].End.Y };
                    }

                    string currInstr = instruction[j];

                    char direction = currInstr[0];
                    int distance = int.Parse(currInstr.Substring(1));


                    var endPosition = new Position();
                    switch (direction)
                    {
                        case 'R':
                            endPosition.X = currentLine.Start.X + distance;
                            endPosition.Y = currentLine.Start.Y;
                            break;
                        case 'U':
                            endPosition.X = currentLine.Start.X;
                            endPosition.Y = currentLine.Start.Y + distance;
                            break;
                        case 'D':
                            endPosition.X = currentLine.Start.X;
                            endPosition.Y = currentLine.Start.Y - distance;
                            break;
                        case 'L':
                            endPosition.X = currentLine.Start.X - distance;
                            endPosition.Y = currentLine.Start.Y;
                            break;
                    }
                    currentLine.End = endPosition;

                    currentWire.Lines.Add(currentLine);
                }
            }

            // find intersection points


            // calc closest intersection point

            return -1;
        }        
    }

    // TODO:
    //private static Position Intersect(Line a, Line b)
    //{
    //   https://stackoverflow.com/questions/20677795/how-do-i-compute-the-intersection-point-of-two-lines
    //}


    public class Wire
    {
        public Wire()
        {
            Lines = new List<Line>();
        }

        public List<Line> Lines;
    }

    public class Line
    {
        public Position Start { get; set; }
        public Position End { get; set; }
    }

    public struct Position
    {
        public int X;
        public int Y;
    }
}
