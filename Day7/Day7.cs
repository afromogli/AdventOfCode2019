using System;
using System.IO;

namespace Day7
{
    class Day7
    {
        static void Main(string[] args)
        {
            var input1 = File.ReadAllLines(@"input1.txt")[0];
            var test1 = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0";
            var test1PhaseSettingSequence = new int[]
            {
                4,3,2,1,0
            };
            int highestCollectedThrusterSignal = 0;

            int[] amplifierOutputs = new int[5];
            int[] phaseSettingSequence = test1PhaseSettingSequence;


            for (int i = 0; i < amplifierOutputs.Length; i++)
            {
                int input = i == 0 ? 0 : amplifierOutputs[i-1]; 
                amplifierOutputs[i] = IntCode.IntCode.CalcOpCodeV4(test1, phaseSettingSequence[i]);
                Console.Write(input);
            }

            highestCollectedThrusterSignal = amplifierOutputs[4];

            Console.WriteLine(highestCollectedThrusterSignal);

            //IntCode.IntCode.CalcOpCodeV3(input1);

            Console.ReadKey();
        }
    }
}
