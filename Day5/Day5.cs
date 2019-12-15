using System;
using System.IO;

namespace Day5
{
    public class Day5
    {
        static void Main(string[] args)
        {
            var input1 = File.ReadAllLines(@"input1.txt")[0];

            //IntCode.IntCode.CalcOpCodeV3(input1);

            var test1 = "3,9,8,9,10,9,4,9,99,-1,8";
            var test2 = "3,9,7,9,10,9,4,9,99,-1,8";
            var test3 = "3,3,1108,-1,8,3,4,3,99";
            var test4 = "3,3,1107,-1,8,3,4,3,99";

            // jump tests
            var test5 = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9";

            IntCode.IntCode.CalcOpCodeV3(input1);

            Console.ReadKey();
        }
    }
}
