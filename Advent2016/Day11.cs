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
            FloorCounter = 1;
            List<Component> Elevator = new List<Component>();
            int ElevatorDirection;
            while (Floors[1].Any() || Floors[2].Any() || Floors[3].Any())
            {
                StepCounter++;
                ElevatorDirection = 0;
                if (FloorCounter >= 4)
                    FloorCounter = 1;
                foreach(Component c in Floors[FloorCounter])
                {
                    if (Elevator.Count() <= 2)
                    {
                        Elevator.Add(c);
                        ElevatorDirection = 1;
                    }
                }
                foreach(Component c in Elevator)
                {
                    Floors[FloorCounter].Remove(c);
                    Floors[FloorCounter + ElevatorDirection].Add(c);
                }
                FloorCounter = FloorCounter + ElevatorDirection;
                Elevator.Clear();

            }
            return StepCounter.ToString();
        }
    }
}