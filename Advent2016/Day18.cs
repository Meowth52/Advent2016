using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day18
    {
        private string Input;
        Stopwatch stopWatch = new Stopwatch();
        public Day18(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int NumberOfRows = 400000;
            //Initial Row
            List<string> Floor = new List<string>();
            Floor.Add("." + Input + ".");
            // the rest
            string TestString;
            for (int Row = 1; Row < NumberOfRows; Row++)
            {
                Floor.Add(".");
                for (int i = 1; i < Floor[0].Length - 1; i++)
                {
                    TestString = "";
                    TestString += Floor[Row - 1][i - 1];
                    TestString += Floor[Row - 1][i];
                    TestString += Floor[Row - 1][i + 1];
                    if (TestString == "^^." || TestString == ".^^" || TestString == "^.." || TestString == "..^")
                        Floor[Row] += "^";
                    else
                        Floor[Row] += ".";
                }
                Floor[Row] += ".";
                if (Row == 39)
                {
                    // Count
                    foreach (string s in Floor)
                    {
                        foreach (char c in s)
                            if (c == '.')
                                Sum++;
                    }
                }
            }
            // Count 2
            foreach (string s in Floor)
            {
                foreach (char c in s)
                    if (c == '.')
                        Sum2++;
            }
            Sum -= 40 * 2;
            Sum2 -= NumberOfRows * 2;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}