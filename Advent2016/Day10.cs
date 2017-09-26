using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Advent2016
{
    internal class Day10
    {
        private string Input;
        private string[] Instructions;
        public ArrayList Bots = new ArrayList();
        
        public Day10(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        internal string Result()
        {
            foreach (string s in Instructions)
            {
                string[] Words;
                Words = s.Split(' ');
                if (Words.FirstOrDefault() == "bot")
                {
                    Bots[Int32.Parse(Words[1])] = new Bot(1,1);
                }
            }
        return "";
        }
    }
}