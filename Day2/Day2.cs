using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.WriteLine(CalcOpCode(inputTest1) == inputResult1);
            Console.WriteLine(CalcOpCode(inputTest2) == inputResult2);
            Console.WriteLine(CalcOpCode(inputTest3) == inputResult3);
            Console.WriteLine(CalcOpCode(inputTest4) == inputResult4);

            var input1 = File.ReadAllLines(@"input1.txt")[0];

            Console.WriteLine(CalcOpCode(File.ReadAllLines(@"input1.txt")[0]));

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    if (CalcOpCodeWithNounAndVerb(input1, noun, verb) == 19690720)
                    {
                        Console.WriteLine($"Answer found:\nnuon: {noun}\nverb: {verb}\nresult: {(100 * noun + verb)}");
                    }
                }
            }

            Console.ReadLine();
            
        }

        private static string CalcOpCode(string input)
        {
            string[] tokens = input.Split(',');
            int[] values = tokens.Select(s => int.Parse(s)).ToArray();

            for (int i = 0; i < values.Length; i += 4)
            {
                int opCode = values[i];

                if (opCode == 99)
                {
                    break;
                }

                int pos1 = values[i + 1];
                int pos2 = values[i + 2];
                int resultPos = values[i + 3];

                if (opCode == 1)
                {
                    values[resultPos] = values[pos1] + values[pos2];
                }
                else if (opCode == 2)
                {
                    values[resultPos] = values[pos1] * values[pos2];
                }
                else
                {
                    Console.WriteLine($"Unkown opcode detected: {opCode}, aborting: ");
                }

            }

            return string.Join(",", values);
        }

        private static int CalcOpCodeWithNounAndVerb(string input, int noun, int verb)
        {
            string[] tokens = input.Split(',');
            int[] values = tokens.Select(s => int.Parse(s)).ToArray();
            values[1] = noun;
            values[2] = verb;

            for (int i = 0; i < values.Length; i += 4)
            {
                int opCode = values[i];

                if (opCode == 99)
                {
                    break;
                }

                int pos1 = values[i + 1];
                int pos2 = values[i + 2];
                int resultPos = values[i + 3];

                if (opCode == 1)
                {
                    values[resultPos] = values[pos1] + values[pos2];
                }
                else if (opCode == 2)
                {
                    values[resultPos] = values[pos1] * values[pos2];
                }
                else
                {
                    Console.WriteLine($"Unkown opcode detected: {opCode}, aborting: ");
                }

            }

            return values[0];
        }
    }
}
