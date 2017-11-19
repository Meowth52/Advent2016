﻿using System;
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
        public List<Component>[] Floors = { new  List<Component>(), new List<Component>(), new List<Component>(), new List<Component>(), new List<Component>() };
        int FloorCounter=0;
        public Day11(string input)
                {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            foreach(string s in Instructions)
            {
                FloorCounter++;
                Regex theMatch = new Regex(@"(\w+)(?= generator)");
                foreach (Match m in theMatch.Matches(s))
                {
                    Floors[FloorCounter].Add(new Component("generator", m.ToString()));
                }
                Regex theMatch2 = new Regex(@"(\w+)(?=-compatible)");
                foreach (Match m in theMatch2.Matches(s))
                {
                    Floors[FloorCounter].Add(new Component("microchip", m.ToString()));
                }
            }

        }

        internal string Result()
        {
            int StepCounter = 0;
            FloorCounter = 0;
            List<Component> FloorCopy = new List<Component>();
            while (Floors[1].Any() || Floors[2].Any() || Floors[3].Any())
            {
                FloorCopy.Clear();
                FloorCounter++;
                if (FloorCounter >= 4)
                    FloorCounter = 1;
                foreach(Component c in Floors[FloorCounter])
                {
                    FloorCopy.Add(c);
                }
                foreach(Component c in FloorCopy)
                {
                    Floors[FloorCounter].Remove(c);
                    Floors[FloorCounter + 1].Add(c);
                }

            }
            return StepCounter.ToString();
        }
    }
}