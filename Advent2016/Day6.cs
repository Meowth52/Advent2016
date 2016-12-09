using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2016
{
    internal class Day6
    {
        private string Input;
        private string[] Instructions;
        private List<schmenum> letters = new List<schmenum>();
        public Day6(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            for (int c = 97; c <= 122; c++)
                letters.Add(new schmenum((char)c,0));
        }

        internal string Result()
        {
            StringBuilder Builder = new StringBuilder();
            for (int i = 0; i <= 7; i++)
            {
                List<schmenum> sortedLetters = new List<schmenum>();
                foreach (schmenum s in letters)
                    sortedLetters.Add(new schmenum(s.c,s.i));
                foreach (string s in Instructions)
                    if (s!="")
                    sortedLetters[(int)s[i] - 97].i++;
                sortedLetters.Sort();
                Builder.Append(sortedLetters[25].c);
                sortedLetters.Clear();
            }
            return Builder.ToString();
        }
    }
}