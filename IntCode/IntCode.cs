using System;
using System.Linq;

namespace IntCode
{
    public static class IntCode
    {
        public static string CalcOpCodeV1(string input)
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

        public static int CalcOpCodeV2(string input, int noun, int verb)
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


        public static int CalcOpCodeV3(string input)
        {
            // https://adventofcode.com/2019/day/5

            //string[] tokens = input.Split(',');
            int[] values = input.Split(',').Select(s => int.Parse(s)).ToArray();
            //values[1] = noun;
            //values[2] = verb;

            int opStepSize = 4;
            for (int i = 0; i < values.Length; i += opStepSize)
            {
                int opCode = values[i];

                if (opCode == 99)
                {
                    break;
                }

                if (opCode == 1)
                {
                    int pos1 = values[i + 1];
                    int pos2 = values[i + 2];
                    int resultPos = values[i + 3];

                    values[resultPos] = values[pos1] + values[pos2];

                    opStepSize = 4;
                }
                else if (opCode == 2)
                {
                    int pos1 = values[i + 1];
                    int pos2 = values[i + 2];
                    int resultPos = values[i + 3];

                    values[resultPos] = values[pos1] * values[pos2];

                    opStepSize = 4;
                }
                else if (opCode == 3)
                {
                    // Take input and store at address X

                    opStepSize = 2;
                }
                else if (opCode == 4)
                {
                    // Output value from address X

                    opStepSize = 2;
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
