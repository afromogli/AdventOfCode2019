using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = File.ReadAllLines(@"input1.txt");

            var test1 = new string[2] { "R75, D30, R83, U83, L12, D49, R71, U7, L72", "U62,R66,U55,R34,D71,R55,D58,R83" };
            var test2 = new string[2] { "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" };

            Console.WriteLine(CalcShortestDistance(test1));
            Console.WriteLine(CalcShortestDistance(test2));
            Console.WriteLine(CalcShortestDistance(input1));
            Console.ReadKey();
        }

        private static int CalcShortestDistance(string[] wires)
        {
            List<Wire> allWires = new List<Wire>();
            
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

            var intersectionPoints = new List<Position>();


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

                            var intersectionPoint = Intersect(currLine, otherLine);

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
        
        private static Position Intersect(Line lineA, Line lineB, double tolerance = 0.001)
        {
            // Code taken from: https://stackoverflow.com/questions/4543506/algorithm-for-intersection-of-2-lines
            double x1 = lineA.Start.X, y1 = lineA.Start.Y;
            double x2 = lineA.End.X, y2 = lineA.End.Y;

            double x3 = lineB.Start.X, y3 = lineB.Start.Y;
            double x4 = lineB.End.X, y4 = lineB.End.Y;

            // equations of the form x = c (two vertical lines)
            if (Math.Abs(x1 - x2) < tolerance && Math.Abs(x3 - x4) < tolerance && Math.Abs(x1 - x3) < tolerance)
            {
                //throw new Exception("Both lines overlap vertically, ambiguous intersection points.");
                return null;
            }

            //equations of the form y=c (two horizontal lines)
            if (Math.Abs(y1 - y2) < tolerance && Math.Abs(y3 - y4) < tolerance && Math.Abs(y1 - y3) < tolerance)
            {
                //throw new Exception("Both lines overlap horizontally, ambiguous intersection points.");
                return null;
            }

            //equations of the form x=c (two vertical lines)
            if (Math.Abs(x1 - x2) < tolerance && Math.Abs(x3 - x4) < tolerance)
            {
                return default(Position);
            }

            //equations of the form y=c (two horizontal lines)
            if (Math.Abs(y1 - y2) < tolerance && Math.Abs(y3 - y4) < tolerance)
            {
                return default(Position);
            }

            //general equation of line is y = mx + c where m is the slope
            //assume equation of line 1 as y1 = m1x1 + c1 
            //=> -m1x1 + y1 = c1 ----(1)
            //assume equation of line 2 as y2 = m2x2 + c2
            //=> -m2x2 + y2 = c2 -----(2)
            //if line 1 and 2 intersect then x1=x2=x & y1=y2=y where (x,y) is the intersection point
            //so we will get below two equations 
            //-m1x + y = c1 --------(3)
            //-m2x + y = c2 --------(4)

            double x, y;

            //lineA is vertical x1 = x2
            //slope will be infinity
            //so lets derive another solution
            if (Math.Abs(x1 - x2) < tolerance)
            {
                //compute slope of line 2 (m2) and c2
                double m2 = (y4 - y3) / (x4 - x3);
                double c2 = -m2 * x3 + y3;

                //equation of vertical line is x = c
                //if line 1 and 2 intersect then x1=c1=x
                //subsitute x=x1 in (4) => -m2x1 + y = c2
                // => y = c2 + m2x1 
                x = x1;
                y = c2 + m2 * x1;
            }
            //lineB is vertical x3 = x4
            //slope will be infinity
            //so lets derive another solution
            else if (Math.Abs(x3 - x4) < tolerance)
            {
                //compute slope of line 1 (m1) and c2
                double m1 = (y2 - y1) / (x2 - x1);
                double c1 = -m1 * x1 + y1;

                //equation of vertical line is x = c
                //if line 1 and 2 intersect then x3=c3=x
                //subsitute x=x3 in (3) => -m1x3 + y = c1
                // => y = c1 + m1x3 
                x = x3;
                y = c1 + m1 * x3;
            }
            //lineA & lineB are not vertical 
            //(could be horizontal we can handle it with slope = 0)
            else
            {
                //compute slope of line 1 (m1) and c2
                double m1 = (y2 - y1) / (x2 - x1);
                double c1 = -m1 * x1 + y1;

                //compute slope of line 2 (m2) and c2
                double m2 = (y4 - y3) / (x4 - x3);
                double c2 = -m2 * x3 + y3;

                //solving equations (3) & (4) => x = (c1-c2)/(m2-m1)
                //plugging x value in equation (4) => y = c2 + m2 * x
                x = (c1 - c2) / (m2 - m1);
                y = c2 + m2 * x;

                //verify by plugging intersection point (x, y)
                //in orginal equations (1) & (2) to see if they intersect
                //otherwise x,y values will not be finite and will fail this check
                if (!(Math.Abs(-m1 * x + y - c1) < tolerance
                    && Math.Abs(-m2 * x + y - c2) < tolerance))
                {
                    return default(Position);
                }
            }

            //x,y can intersect outside the line segment since line is infinitely long
            //so finally check if x, y is within both the line segments
            if (IsInsideLine(lineA, x, y) &&
                IsInsideLine(lineB, x, y))
            {
                return new Position { X = (int)x, Y = (int)y };
            }

            //return default null (no intersection)
            return default(Position);


        }

        // Returns true if given point(x,y) is inside the given line segment
        private static bool IsInsideLine(Line line, double x, double y)
        {
            return (x >= line.Start.X && x <= line.End.X
                        || x >= line.End.X && x <= line.Start.X)
                   && (y >= line.Start.Y && y <= line.End.Y
                        || y >= line.End.Y && y <= line.Start.Y);
        }
    }

    


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

        public override string ToString()
        {
            return $"Start:{Start}, End:{End}";
        }
    }

    public class Position
    {
        public int X;
        public int Y;

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}";
        }
    }


}
