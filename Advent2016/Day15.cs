using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day15
    {
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        List<BallWheel> BallWheels = new List<BallWheel>();
        Stopwatch stopWatch = new Stopwatch();
        public Day15(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                {
                    string NoMoreDots = s.Replace(".", "");
                    Instructions.Add(NoMoreDots.Split(' '));
                }
            }
            foreach(string[] s in Instructions)
            {
                int Positions = 0;
                Int32.TryParse(s[3], out Positions);
                int StarterPosition = 0;
                Int32.TryParse(s[11], out StarterPosition);
                BallWheels.Add(new BallWheel(Positions, StarterPosition));
            }
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            bool Done = false;
            while (!Done)
            {
                Done = true;
                int Offset = 0;
                foreach (BallWheel b in BallWheels)
                {
                    Offset++;
                    if (!b.IsAtZero(Sum+Offset))
                        Done = false;
                }
                Sum++;
            }
            Sum--;
            //del2
            BallWheels.Add(new BallWheel(11, 0));
            Done = false;
            while (!Done)
            {
                Done = true;
                int Offset = 0;
                foreach (BallWheel b in BallWheels)
                {
                    Offset++;
                    if (!b.IsAtZero(Sum2 + Offset))
                        Done = false;
                }
                Sum2++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}