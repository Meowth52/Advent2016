using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent2016
{
    internal class Adress
    {
        string Instruction = "";
        string brackets = "";
        public Adress(string instruction)
        {
            Regex Bracketmatch = new Regex(@"\w+]");
            foreach (Match m in Bracketmatch.Matches(instruction))
                brackets = String.Concat(brackets, m);
            brackets = brackets.Replace("[", "");
            Instruction = instruction;

        }
        public bool isValid()
        {
            Regex theMatch = new Regex(@"(\w)((?!\1)\w)\2\1");
            return (theMatch.IsMatch(Instruction) & !theMatch.IsMatch(brackets));
        }

    }
}