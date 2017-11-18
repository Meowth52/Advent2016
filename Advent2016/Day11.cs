using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Advent2016
{
    internal class Day11
    {
        private string Input;
        private string[] Instructions;
        public List<Component>[] Floors = { new  List<Component>(), new List<Component>(), new List<Component>(), new List<Component>()};
        int FloorCounter=0;
        public Day11(string input)
                {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            foreach(string s in Instructions)
            {
                FloorCounter++;
                string[] Words;
                Words = s.Split(' ');
                string Lastword = "";
                foreach (string word in Words)
                {
                    if (word = "generator")

                    Lastword = word;
                }
                Regex theMatch = new Regex(@"(\d+)\D+(\d+)");
            }
            Floors[1].Add();

        }

        internal string Result()
        {
            throw new NotImplementedException();
        }
    }
}