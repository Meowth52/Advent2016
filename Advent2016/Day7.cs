﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    internal class Day7
    {
        private string Input;
        private string[] Instructions;
        private List<Adress> Adresses = new List<Adress>();

        public Day7(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            foreach (string s in Instructions)
                Adresses.Add(new Adress(s));
        }

        internal string Result()
        {
            int i = 0;
            int i2 = 0;
            foreach (Adress a in Adresses)
            {
                if (a.isValid())
                    i++;
                if (a.isValid2())
                    i2++;
            }
            return "del 1 blir: " + i.ToString()+ " del 2 blir: " + i2.ToString();
        }
    }
}