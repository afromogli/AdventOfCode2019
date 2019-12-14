using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input1 = File.ReadAllLines(@"input1.txt")[0];

            IntCode.IntCode.CalcOpCodeV3(input1);
            
            Console.ReadKey();
        }
    }
}
