using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Advent2016
{
    internal class Day12
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        public Day12(string input)
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
            Dictionary<char, long> Registers = new Dictionary<char, long>() { { 'a', 0 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { '1', 1 } };
            int InstructionIndex = 0;
            char Keyword;
            char Target;
            long Value;
            while (InstructionIndex < Instructions.Count)
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
            }
            //del 2

            Registers = new Dictionary<char, long>() { { 'a', 0 }, { 'b', 0 }, { 'c', 1 }, { 'd', 0 }, { '1', 1 } };
            InstructionIndex = 0;
            while (InstructionIndex < Instructions.Count)
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
            }
            Sum = Registers['a'];
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }

    }
}