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

        // Day 5
        public static int CalcOpCodeV3(string input)
        {
            int[] values = input.Split(',').Select(s => int.Parse(s)).ToArray();

            int opStepSize = 4;
            for (int i = 0; i < values.Length; i += opStepSize)
            {
                string instr = values[i].ToString();
                int opCode = instr.Length == 1 ? values[i] : int.Parse(instr.Substring(instr.Length - 2));
                int firstParamMode = instr.Length > 2 ? int.Parse(instr.Substring(instr.Length-3,1)): 0;
                int secondParamMode = instr.Length > 3 ? int.Parse(instr.Substring(instr.Length - 4, 1)) : 0;
                int thirdParamMode = instr.Length > 4 ? int.Parse(instr.Substring(instr.Length - 5, 1)) : 0;

                if (opCode == 99)
                {
                    break;
                }

                switch (opCode)
                {
                    case 1:
                    case 2:
                        {
                            int param1 = values[i + 1];
                            int param2 = values[i + 2];
                            int resultPos = values[i + 3];

                            int res;
                            int param1Val = (firstParamMode == 0 ? values[param1] : param1);
                            int param2Val = (secondParamMode == 0 ? values[param2] : param2);

                            if (opCode == 1)
                            {
                                res = param1Val + param2Val;
                            }
                            else
                            {
                                res = param1Val * param2Val;

                            }
                            SetMem(values, resultPos, res);
                            opStepSize = 4;
                            break;
                        }

                    // Take input and store at address 
                    case 3:
                        {
                            int address = values[i + 1];
                            
                            int inputVal = int.Parse(Console.ReadLine());
                            SetMem(values, address, inputVal);
                            opStepSize = 2;
                            break;
                        }
                    // Output value stored at address
                    case 4:
                        {
                            int param1 = values[i + 1];
                            if (firstParamMode == 0)
                            {
                                // Output value from address X
                                Console.WriteLine(values[param1]);
                            }
                            else
                            {
                                // Output value
                                Console.WriteLine(param1);
                            }

                            opStepSize = 2;
                            break;
                        }
                    default:
                        Console.WriteLine($"Unkown opcode detected: {opCode}, aborting..");
                        break;
                }

            }

            return values[0];
        }

        private static void SetMem(int[] mem, int address, int value)
        {
            mem[address] = value;
        }

    }
}
