using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Day3
    {
        static void Main(string[] args)
        {
            var input1 = File.ReadAllLines(@"input1.txt");

            var test1 = new string[2] { "R75, D30, R83, U83, L12, D49, R71, U7, L72", "U62,R66,U55,R34,D71,R55,D58,R83" };
            var test2 = new string[2] { "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" };

            // Part 1
            Console.WriteLine(CalcShortestDistance(test1));
            Console.WriteLine(CalcShortestDistance(test2));
            Console.WriteLine(CalcShortestDistance(input1));

            // Part 2
            // TODO: find intersection with least amount of steps for both wires

            Console.ReadKey();
        }

        private static int FindIntersectionWithLeastAmountOfSteps(string[] wires)
        {
            List<Wire> allWires = GetWires(wires);
            var intersectionPoints = FindIntersectionPoints(allWires);

            var intersectionPointSteps = new int[intersectionPoints.Count];

            for (int i = 0; i < intersectionPoints.Count; i++)
            {
                var currIntersectionPoint = intersectionPoints[i];
            }

            // TODO

            return -1;
        }

        private static int CalcShortestDistance(string[] wires)
        {
            List<Wire> allWires = GetWires(wires);
            var intersectionPoints = FindIntersectionPoints(allWires);

            // calc closest intersection point
            var shortestDistance = int.MaxValue;
            for (int i = 0; i < intersectionPoints.Count; i++)
            {
                var currIntersectionPoint = intersectionPoints[i];

                var distance = Math.Abs(currIntersectionPoint.X) + Math.Abs(currIntersectionPoint.Y);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                }
            }

            return shortestDistance;
        }

        private static List<Position> FindIntersectionPoints(List<Wire> allWires)
        {
            List<Position> intersectionPoints = new List<Position>();
            // find intersection points
            for (int i = 0; i < allWires.Count; i++)
            {
                var currWire = allWires[i];


                for (int j = 0; j < currWire.Lines.Count; j++)
                {
                    var currLine = currWire.Lines[j];
                    for (int k = 0; k < allWires.Count; k++)
                    {
                        if (i == k)
                        {
                            continue;
                        }
                        var otherWire = allWires[k];

                        for (int l = 0; l < otherWire.Lines.Count; l++)
                        {
                            var otherLine = otherWire.Lines[l];

                            var intersectionPoint = Line.Intersect(currLine, otherLine);

                            if (intersectionPoint != null && intersectionPoint.X == 0 && intersectionPoint.Y == 0)
                            {
                                continue;
                            }

                            if (intersectionPoint != null)
                            {
                                intersectionPoints.Add(intersectionPoint);
                            }
                        }
                    }
                }
            }
            return intersectionPoints;
        }

        private static List<Wire> GetWires(string[] wires)
        {
            List<Wire> allWires = new List<Wire>(wires.Length);
            for (int i = 0; i < wires.Length; i++)
            {
                var currentWire = new Wire();
                string currentWireString = wires[i].Trim().Replace(" ", "");

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
                    string distString = currInstr.Substring(1);
                    int distance = int.Parse(distString);


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

                allWires.Add(currentWire);
            }
            return allWires;
        }

        
    }
}
