using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace Advent2016
{
    internal class Day11
    {
        private string Input;
        Stopwatch stopWatch = new Stopwatch();
        private string[] Instructions;
        public List<Dictionary<int, string>> FloorStates = new List<Dictionary<int, string>>();
        public List<Dictionary<int, string>> NextFloorsStates = new List<Dictionary<int, string>>();
        int NumberOfComponents = 0;
        int FloorCounter=0;
        public Day11(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            FloorStates.Add(new Dictionary<int, string>());
            FloorStates[0].Add(1, "");
            FloorStates[0].Add(2, "");
            FloorStates[0].Add(3, "");
            FloorStates[0].Add(4, "");
            foreach (string s in Instructions)
            {
                FloorCounter++;
                Regex theMatch = new Regex(@"(\w+)(?= generator)");
                foreach (Match m in theMatch.Matches(s))
                {
                    FloorStates[0][FloorCounter] += m.ToString().ToUpper()[2];
                    NumberOfComponents++;
                }
                Regex theMatch2 = new Regex(@"(\w+)(?=-compatible)");
                foreach (Match m in theMatch2.Matches(s))
                {
                    FloorStates[0][FloorCounter] += m.ToString()[2];
                    NumberOfComponents++;
                }
            }
        }

        internal string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            FloorCounter = 1;
            bool NotYet = true;
            while(NotYet)
            {
                Sum++;
                foreach(Dictionary<int, string> f in FloorStates)
                {
                    if (f[4].Length >= NumberOfComponents)
                    {
                        NotYet = false;
                        break;
                    }
                    foreach(char c in f[FloorCounter])
                    {
                        //the test cant just match. one of the components can be alone. Not sure lowercase will cut it
                        if (FloorCounter > 1 && f[FloorCounter - 1].ToLower().Contains(c.ToString().ToLower()))
                        {
                            //create and add the new state
                            Dictionary<int, string> Next = new Dictionary<int, string>(f);
                            Next[FloorCounter].Remove
                            NextFloorsStates.Add(new Dictionary<int, string>(f));
                            NextFloorsStates.
                        }                            
                        if (FloorCounter < 4 && f[FloorCounter + 1].ToLower().Contains(c.ToString().ToLower()))
                        {

                        }                            

                    }
                }

            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}