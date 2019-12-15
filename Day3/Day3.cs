using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            Console.WriteLine("Part 2:");

            // Part 2
            Console.WriteLine(FindIntersectionWithLeastAmountOfSteps(input1));

            Console.ReadKey();
        }

        private static int FindIntersectionWithLeastAmountOfSteps(string[] wires)
        {
            List<Wire> allWires = GetWires(wires);
            var intersectionPoints = FindIntersections(allWires);
            
            var leastAmountOfSteps = int.MaxValue;

            for (int i = 0; i < intersectionPoints.Count; i++)
            {
                var currIntersectionPoint = intersectionPoints[i];

                var targetPoint = currIntersectionPoint.Point;

                var stepsToTarget1 = currIntersectionPoint.Wire1.Points.IndexOf(targetPoint);
                var stepsToTarget2 = currIntersectionPoint.Wire2.Points.IndexOf(targetPoint);

                if (stepsToTarget1 + stepsToTarget2 < leastAmountOfSteps)
                {
                    leastAmountOfSteps = stepsToTarget1 + stepsToTarget2;
                }
            }

            return leastAmountOfSteps;
        }

        private static int CalcShortestDistance(string[] wires)
        {
            List<Wire> allWires = GetWires(wires);
            var intersectionPoints = FindIntersections(allWires);

            // calc closest intersection point
            var shortestDistance = int.MaxValue;
            for (int i = 0; i < intersectionPoints.Count; i++)
            {
                var currIntersectionPoint = intersectionPoints[i];

                var distance = Math.Abs(currIntersectionPoint.Point.X) + Math.Abs(currIntersectionPoint.Point.Y);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                }
            }

            return shortestDistance;
        }

        private static List<Intersection> FindIntersections(List<Wire> allWires)
        {
            List<Intersection> intersections = new List<Intersection>();
            // find intersection points
            for (int i = 0; i < allWires.Count; i++)
            {
                var currWire = allWires[i];

                for (int j = 0; j < allWires.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    var otherWire = allWires[j];

                    var intersectionPoints = currWire.Points.Intersect(otherWire.Points).ToArray();

                    for (int k = 0; k < intersectionPoints.Length; k++)
                    {
                        var intersectionPoint = intersectionPoints[k];
                        if ( intersectionPoint.X == 0 && intersectionPoint.Y == 0)
                        {
                            continue;
                        }
                        Intersection intersection = new Intersection()
                        {
                            Point = intersectionPoint,
                            Wire1 = currWire,
                            Wire2 = otherWire
                        };
                        intersections.Add(intersection);
                        
                    }
                }
            }
            return intersections;
        }

        private static List<Wire> GetWires(string[] wires)
        {
            List<Wire> allWires = new List<Wire>(wires.Length);
            for (int i = 0; i < wires.Length; i++)
            {
                var currentWire = new Wire();
                string currentWireString = wires[i].Trim().Replace(" ", "");

                string[] instruction = currentWireString.Split(',');

                currentWire.Points.Add(new Position(0, 0));

                var currentPos = new Position(0, 0);
                for (int j = 0; j < instruction.Length; j++)
                {
                    string currInstr = instruction[j];

                    char direction = currInstr[0];
                    int distance = int.Parse(currInstr.Substring(1));

                    for (int k = 0; k < distance; k++)
                    {
                        switch (direction)
                        {
                            case 'R':
                                currentPos.X++;
                                break;
                            case 'U':
                                currentPos.Y++;
                                break;
                            case 'D':
                                currentPos.Y--;
                                break;
                            case 'L':
                                currentPos.X--;
                                break;
                        }
                        currentWire.Points.Add(new Position(currentPos.X, currentPos.Y));
                    }
                }

                allWires.Add(currentWire);
            }
            return allWires;
        }


    }
}
