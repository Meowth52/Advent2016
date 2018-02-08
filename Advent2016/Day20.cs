using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day20
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        public Day20(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            long Sum = 0;
            long Sum2 = 0;
            List<long> BlockListLow = new List<long>();
            List<long> BlockListHigh = new List<long>();
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    string[] Split = s.Split('-');
                    long[] Numbers = new long[2];
                    Int64.TryParse(Split[0], out Numbers[0]);
                    Int64.TryParse(Split[1], out Numbers[1]);
                    BlockListLow.Add(Numbers[0]);
                    BlockListHigh.Add(Numbers[1]);
                }
            }

            BlockListHigh.Sort();
            BlockListLow.Sort();
            long MaxAdress = 4294967296;
            BlockListLow.Add(MaxAdress);
            long Rangemaybe;
            for (int i = 0; i < BlockListHigh.Count; i++)
            {
                Rangemaybe = BlockListLow[i + 1] - BlockListHigh[i]-1;
                if (Rangemaybe > 0)
                    Sum2 += Rangemaybe;
                if (Sum == 0 && Rangemaybe > 0)
                    Sum = BlockListHigh[i] + 1;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}