using System;
using System.IO;

namespace Day2
{
    class Day2
    {
        static void Main(string[] args)
        {
            var inputTest1 = "1,0,0,0,99";
            var inputResult1 = "2,0,0,0,99";


            var inputTest2 = "2,3,0,3,99";
            var inputResult2 = "2,3,0,6,99";

            var inputTest3 = "2,4,4,5,99,0";
            var inputResult3 = "2,4,4,5,99,9801";

            var inputTest4 = "1,1,1,4,99,5,6,0,99";
            var inputResult4 = "30,1,1,4,2,5,6,0,99";

            Console.WriteLine(IntCode.IntCode.CalcOpCode(inputTest1) == inputResult1);
            Console.WriteLine(IntCode.IntCode.CalcOpCode(inputTest2) == inputResult2);
            Console.WriteLine(IntCode.IntCode.CalcOpCode(inputTest3) == inputResult3);
            Console.WriteLine(IntCode.IntCode.CalcOpCode(inputTest4) == inputResult4);

            var input1 = File.ReadAllLines(@"input1.txt")[0];

            Console.WriteLine(IntCode.IntCode.CalcOpCode(File.ReadAllLines(@"input1.txt")[0]));

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    if (IntCode.IntCode.CalcOpCodeWithNounAndVerb(input1, noun, verb) == 19690720)
                    {
                        Console.WriteLine($"Answer found:\nnuon: {noun}\nverb: {verb}\nresult: {(100 * noun + verb)}");
                    }
                }
            }

            Console.ReadLine();
            
        }
    }
}
