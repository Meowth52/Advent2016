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
        List<Component> Floor1 = new List<Component>();
        List<Component> Floor2 = new List<Component>();
        List<Component> Floor3 = new List<Component>();
        List<Component> Floor4 = new List<Component>();

        public Day11(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');

        }

        internal string Result()
        {
            throw new NotImplementedException();
        }
    }
}