using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent2016
{
    internal class Adress
    {
        string Instruction = "";
        string InstructionCinBrackets = "";
        string brackets = "";
        public Adress(string instruction)
        {

            Instruction = instruction;
            InstructionCinBrackets = Instruction;
            Regex Bracketmatch = new Regex(@"\w+]");
            foreach (Match m in Bracketmatch.Matches(instruction))
            {
                brackets = String.Concat(brackets, m);
                InstructionCinBrackets = InstructionCinBrackets.Replace(m.ToString(), "");
            }

        }
        public bool isValid()
        {
            Regex theMatch = new Regex(@"(\w)((?!\1)\w)\2\1");
            return (theMatch.IsMatch(Instruction) & !theMatch.IsMatch(brackets));
        }
        public bool isValid2()
        {
            StringBuilder SBuilder = new StringBuilder();
            Regex theMatch = new Regex(@"(?=((\w)((?!\2)\w)\2))");
            foreach (Match m in theMatch.Matches(InstructionCinBrackets))
            {
                SBuilder.Append(m.Groups[1].ToString()[1]);
                SBuilder.Append(m.Groups[1].ToString()[0]);
                SBuilder.Append(m.Groups[1].ToString()[1]);
                if (brackets.Contains(SBuilder.ToString()))
                    return true;
                SBuilder.Clear();
            }
            return (false);
        }

    }
}