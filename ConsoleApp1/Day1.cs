using System;
using System.IO;

namespace ConsoleApp1
{
    class Day1
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"input1.txt");

            double sum = 0;

            int currValue;
            for (int i = 0; i < lines.Length; i++)
            {
                currValue = int.Parse(lines[i]);

                sum += CalcFuel(currValue);
            }

            Console.WriteLine($"Sum: {sum}");
            Console.ReadKey();
        }

        private static int CalcFuel(int currValue)
        {
            int fuel = ((currValue / 3) - 2);

            if (fuel > 0)
            {
                fuel += CalcFuel(fuel);
            }

            if (fuel < 0)
            {
                fuel = 0;
            }
            Console.WriteLine($"CalcFuel results: " + fuel);
            return fuel;
        }
    }
}
