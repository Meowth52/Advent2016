using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day22
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        public Day22(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            for (int i = 0; i < 10; i++)
            {
                Input = Input.Replace("  ", " ");
            }
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<GridNode> GridNodes = new List<GridNode>();
            foreach (string s in Instructions)
            {
                if (s.Contains("/"))
                {
                    GridNodes.Add(new GridNode(s));
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}