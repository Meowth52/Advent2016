using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2016
{
    internal class Day8
    {
        private string Input;
        private string[] Instructions;
        bool[,] Display = new bool[50, 6];

        public Day8(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            for (int y = 0; y <= 5; y++)
                for (int x = 0; x <= 49; x++)
                    Display[x, y] = false;
        }

        internal string Result()
        {
            Regex theMatch = new Regex(@"(\d+)\D+(\d+)");
            StringBuilder SBuilder = new StringBuilder();
            int Counter = 0;
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    if (s.Contains("rect"))
                    {
                        int a = Convert.ToInt32(theMatch.Match(s).Groups[1].ToString());
                        int b = Convert.ToInt32(theMatch.Match(s).Groups[2].ToString());

                        for (int y = 0; y < b; y++)
                            for (int x = 0; x < a; x++)
                                Display[x, y] = true;
                    }
                    if (s.Contains("rotate column"))
                    {
                        int a = Convert.ToInt32(theMatch.Match(s).Groups[1].ToString());
                        int b = Convert.ToInt32(theMatch.Match(s).Groups[2].ToString());
                        for (int i = 1; i <= b; i++)
                        {
                            bool blurp = Display[a, 5];
                            for (int smurf = 5; smurf >= 1; smurf--)
                            {
                                Display[a, smurf] = Display[a, smurf - 1];
                            }
                            Display[a, 0] = blurp;
                        }
                    }
                    if (s.Contains("rotate row"))
                    {
                        int a = Convert.ToInt32(theMatch.Match(s).Groups[1].ToString());
                        int b = Convert.ToInt32(theMatch.Match(s).Groups[2].ToString());
                        for (int i = 1; i <= b; i++)
                        {
                            bool blurp = Display[49, a];
                            for (int smurf = 49; smurf >= 1; smurf--)
                            {
                                Display[smurf, a] = Display[smurf - 1, a];
                            }
                            Display[0, a] = blurp;

                        }
                    }
                }
            }
            for (int y = 0; y <= 5; y++)
                for (int x = 0; x <= 49; x++)
                {
                    if (Display[x, y])
                    {
                        SBuilder.Append("X");
                        Counter++;
                    }
                    else
                        SBuilder.Append("_");
                    if (x == 49)
                        SBuilder.Append('\n');
                }

            return SBuilder.ToString() + Counter.ToString();
        }
    }
}