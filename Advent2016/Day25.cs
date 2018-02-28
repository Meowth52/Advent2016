using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day25
    {
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        Stopwatch stopWatch = new Stopwatch();
        public Day25(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                {
                    Instructions.Add(s.Split(' '));
                }
            }
        }
        public string Result()
        {
            long Sum = 0;
            long Sum2 = 0;
            Dictionary<char, long> Registers = new Dictionary<char, long>() { { 'a', 0 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { '1', 1 }, { '0', 0 } };
            int InstructionIndex;
            char Keyword;
            char Target;
            long Value;
            string TestString;
            bool GetOut = false;
            while (!GetOut)
            {
                GetOut = true;
                Sum++;
                Registers['a'] = Sum;
                TestString = "";
                InstructionIndex = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    string[] s = Instructions[InstructionIndex];
                    Keyword = s[0][0];
                    switch (Keyword)
                    {
                        case 'c':
                            Target = s[2][0];
                            if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                                Int64.TryParse(s[1], out Value);
                            else
                                Value = Registers[s[1][0]];
                            Registers[Target] = Value;
                            InstructionIndex++;
                            break;
                        case 'i':
                            Target = s[1][0];
                            Registers[Target]++;
                            InstructionIndex++;
                            break;
                        case 'd':
                            Target = s[1][0];
                            Registers[Target]--;
                            InstructionIndex++;
                            break;
                        case 'o':
                            Target = s[1][0];
                            TestString += Registers[Target].ToString();
                            InstructionIndex++;
                            break;
                        case 'j':
                            if (Registers[s[1][0]] != 0)
                            {
                                Int64.TryParse(s[2], out Value);
                                InstructionIndex += (int)Value;
                            }
                            else
                                InstructionIndex++;
                            break;
                            ;
                        default:
                            ;
                            break;
                    }
                    char LastChar = '2';
                    foreach (char c in TestString)
                    {
                        if (c == LastChar)
                        {
                            GetOut = false;
                            break;
                        }
                        LastChar = c;
                    }
                    if (!GetOut)
                        break;
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}