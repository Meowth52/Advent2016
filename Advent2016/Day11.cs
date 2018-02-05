using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Linq;

namespace Advent2016
{
    internal class Day11
    {
        private string Input;
        Stopwatch stopWatch = new Stopwatch();
        private string[] Instructions;
        public List<Dictionary<int, string>> FloorStates = new List<Dictionary<int, string>>();
        public List<Dictionary<int, string>> NextFloorsStates = new List<Dictionary<int, string>>();
        public List<Dictionary<int, string>> NexterFloorsStates = new List<Dictionary<int, string>>();
        Dictionary<int, string> Next;
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
            FloorStates[0].Add(0, "1");
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
                    }
                    Int32.TryParse(f[0], out FloorCounter);
                    foreach(char c in f[FloorCounter])
                    {
                        foreach(char d in f[FloorCounter])
                        {
                            NexterFloorsStates.Clear();
                            if (FloorCounter > 1 && c!=d)
                            {
                                Next = new Dictionary<int, string>(f);
                                Next[FloorCounter]= Next[FloorCounter].Replace(c.ToString(), "");
                                Next[FloorCounter - 1] += c.ToString();
                                Next[0] = (FloorCounter-1).ToString();
                                NextFloorsStates.Add(Next);
                                Next = new Dictionary<int, string>(f);
                                Next[FloorCounter] = Next[FloorCounter].Replace(c.ToString(), "");
                                Next[FloorCounter] = Next[FloorCounter].Replace(d.ToString(), "");
                                Next[FloorCounter - 1] += c.ToString() + d.ToString();
                                Next[0] = (FloorCounter - 1).ToString();
                                NextFloorsStates.Add(Next);
                                Next = new Dictionary<int, string>(f);
                                Next[FloorCounter] = Next[FloorCounter].Replace(c.ToString(), "");
                                Next[FloorCounter] = Next[FloorCounter].Replace(d.ToString(), "");
                                Next[FloorCounter - 1] += d.ToString() + c.ToString();
                                Next[0] = (FloorCounter - 1).ToString();
                                NextFloorsStates.Add(Next);
                            }
                            if (FloorCounter < 4 && c!=d)
                            {
                                Next = new Dictionary<int, string>(f);
                                Next[FloorCounter] = Next[FloorCounter].Replace(c.ToString(), "");
                                Next[FloorCounter + 1] += c.ToString();
                                Next[0] = (FloorCounter + 1).ToString();
                                NextFloorsStates.Add(Next);
                                Next = new Dictionary<int, string>(f);
                                Next[FloorCounter] = Next[FloorCounter].Replace(c.ToString(), "");
                                Next[FloorCounter] = Next[FloorCounter].Replace(d.ToString(), "");
                                Next[FloorCounter + 1] += c.ToString() + d.ToString();
                                Next[0] = (FloorCounter + 1).ToString();
                                NextFloorsStates.Add(Next);
                                Next = new Dictionary<int, string>(f);
                                Next[FloorCounter] = Next[FloorCounter].Replace(c.ToString(), "");
                                Next[FloorCounter] = Next[FloorCounter].Replace(d.ToString(), "");
                                Next[FloorCounter + 1] += d.ToString() + c.ToString();
                                Next[0] = (FloorCounter + 1).ToString();
                                NextFloorsStates.Add(Next);
                            }
                        }
                        foreach (Dictionary<int,string> d in NextFloorsStates)
                        {
                            bool isOK = true;
                            foreach (KeyValuePair<int, string> k in d)
                            {
                                foreach (char p in k.Value)
                                {
                                    if (k.Value.Any(char.IsUpper) && char.IsLower(p) &! k.Value.Contains(p.ToString().ToUpper()))
                                        isOK = false;
                                }
                            }
                            if (isOK)
                                NexterFloorsStates.Add(d);
                        }
                        NextFloorsStates.Clear();
                    }
                }
                FloorStates = new List<Dictionary<int, string>>(NexterFloorsStates);
                NexterFloorsStates.Clear();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}