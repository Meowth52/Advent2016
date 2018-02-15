using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day23
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        List<string[]> Instructions2 = new List<string[]>();
        public Day23(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                {
                    Instructions.Add(s.Split(' '));
                    Instructions2.Add(s.Split(' '));
                }
            }
        }

        public string Result()
        {
            long Sum = 0;
            long Sum2 = 0;
            Dictionary<char, long> Registers = new Dictionary<char, long>() { { 'a', 7 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { '1', 1 } };
            int InstructionIndex = 0;
            char Keyword;
            char Target;
            long Value;
            int ToggleIndex;
            while (InstructionIndex < Instructions.Count)
            {
                string[] s = Instructions[InstructionIndex];
                Keyword = s[0][0];
                switch (Keyword)
                {
                    case 'c':
                        try
                        {
                            Target = s[2][0];
                            if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                                Int64.TryParse(s[1], out Value);
                            else
                                Value = Registers[s[1][0]];
                            Registers[Target] = Value;
                        }
                        catch
                        {

                        }
                        InstructionIndex++;
                        break;
                    case 'i':
                        try
                        {
                            Target = s[1][0];
                            Registers[Target]++;
                        }
                        catch
                        {

                        }
                        InstructionIndex++;
                        break;
                    case 'd':
                        try
                        {
                            Target = s[1][0];
                            Registers[Target]--;
                        }
                        catch
                        {

                        }
                        InstructionIndex++;
                        break;
                    case 'j':
                        try
                        {
                            if (Registers[s[1][0]] != 0)
                            {
                                if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                                    Int64.TryParse(s[2], out Value);
                                else
                                    Value = Registers[s[2][0]];
                                InstructionIndex += (int)Value;
                            }
                            else
                                InstructionIndex++;
                        }
                        catch
                        {
                            InstructionIndex++;
                        }
                        break;
                    case 't':
                        if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                            Int32.TryParse(s[1], out ToggleIndex);
                        else
                            ToggleIndex = (int)Registers[s[1][0]];
                        ToggleIndex += InstructionIndex;
                        if (ToggleIndex >= 0 && ToggleIndex < Instructions.Count)
                        {
                            if (Instructions[ToggleIndex].Length == 2)
                            {
                                if (Instructions[ToggleIndex][0][0] == 'i')
                                {
                                    Instructions[ToggleIndex][0] = "dec";
                                }
                                else
                                {
                                    Instructions[ToggleIndex][0] = "inc";
                                }
                            }
                            else
                            {
                                if (Instructions[ToggleIndex][0][0] == 'j')
                                {
                                    Instructions[ToggleIndex][0] = "cpy";
                                }
                                else
                                {
                                    Instructions[ToggleIndex][0] = "jnz";
                                }
                            }

                        }
                        InstructionIndex++;
                        break;
                    default:
                        ;
                        break;

                }
            }
            Sum = Registers['a'];
            // part 2
            Registers = new Dictionary<char, long>() { { 'a', 12 }, { 'b', 0 }, { 'c', 0 }, { 'd', 0 }, { '1', 1 } };
            InstructionIndex = 0;
            Keyword = '_';
            Target = '_';
            Value = 0;
            ToggleIndex = 0;
            while (InstructionIndex < Instructions2.Count)
            {
                string[] s = Instructions2[InstructionIndex];
                Keyword = s[0][0];
                switch (Keyword)
                {
                    case 'c':
                        try
                        {
                            Target = s[2][0];
                            if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                                Int64.TryParse(s[1], out Value);
                            else
                                Value = Registers[s[1][0]];
                            Registers[Target] = Value;
                        }
                        catch
                        {

                        }
                        InstructionIndex++;
                        break;
                    case 'i':
                        try
                        {
                            Target = s[1][0];
                            Registers[Target]++;
                        }
                        catch
                        {

                        }
                        InstructionIndex++;
                        break;
                    case 'd':
                        try
                        {
                            Target = s[1][0];
                            Registers[Target]--;
                        }
                        catch
                        {

                        }
                        InstructionIndex++;
                        break;
                    case 'j':
                        try
                        {
                            if (Registers[s[1][0]] != 0)
                            {
                                if (char.IsNumber(s[2], 0) || s[2][0] == '-')
                                    Int64.TryParse(s[2], out Value);
                                else
                                    Value = Registers[s[2][0]];
                                InstructionIndex += (int)Value;
                            }
                            else
                                InstructionIndex++;
                        }
                        catch
                        {
                            InstructionIndex++;
                        }
                        break;
                    case 't':
                        if (char.IsNumber(s[1], 0) || s[1][0] == '-')
                            Int32.TryParse(s[1], out ToggleIndex);
                        else
                            ToggleIndex = (int)Registers[s[1][0]];
                        ToggleIndex += InstructionIndex;
                        if (ToggleIndex >= 0 && ToggleIndex < Instructions2.Count)
                        {
                            if (Instructions2[ToggleIndex].Length == 2)
                            {
                                if (Instructions2[ToggleIndex][0][0] == 'i')
                                {
                                    Instructions2[ToggleIndex][0] = "dec";
                                }
                                else
                                {
                                    Instructions2[ToggleIndex][0] = "inc";
                                }
                            }
                            else
                            {
                                if (Instructions2[ToggleIndex][0][0] == 'j')
                                {
                                    Instructions2[ToggleIndex][0] = "cpy";
                                }
                                else
                                {
                                    Instructions2[ToggleIndex][0] = "jnz";
                                }
                            }

                        }
                        InstructionIndex++;
                        break;
                    default:
                        ;
                        break;

                }
            }
            Sum2 = Registers['a'];
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}