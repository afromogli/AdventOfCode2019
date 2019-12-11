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

            // go through all wires and add positions
            for (int i = 0; i < wires.Length; i++)
            {
                var wire = new Wire();
                allWires.Add(wire);
                string currentWire = wires[i];

                string[] moves = currentWire.Split(',');

                for (int j = 0; j < moves.Length; j++)
                {
                    string currentMove = moves[j];

                    char direction = currentMove[0];
                    int steps = int.Parse(currentMove.Substring(1));

                    var pos = new Position();

                    if (wire.Positions.Count == 0)
                    {
                        // init first position
                        if (i > 0 && allWires[i-1].Positions.Count > 0)
                        {
                            pos.X = allWires[i - 1].Positions[0].X;
                            pos.Y = allWires[i - 1].Positions[0].Y;
                        }
                        // else 
                        // default to 0, 0
                    }
                    else
                    {
                        pos.X = wire.Positions[j - 1].X;
                        pos.Y = wire.Positions[j - 1].Y;
                    }
                    
                    switch (direction)
                    {
                        case 'R':

                            break;
                        case 'U':
                            break;
                        case 'D':
                            break;
                        case 'L':
                            break;
                    }

                    wire.Positions.Add(pos);

                    // TODO: fix..
                }
            }

            // find intersection points

            // calc closest intersection point

            return -1;
        }        
    }


    public class Wire
    {
        public Wire()
        {
            Positions = new List<Position>();
        }

        public List<Position> Positions { get; set; }
    }

    public struct Position
    {
        public int X;
        public int Y;
    }
}
