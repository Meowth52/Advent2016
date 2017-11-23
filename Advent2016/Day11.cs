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
            bool TranferePossible;
            while (Floors[1].Any() || Floors[2].Any() || Floors[3].Any())
            {
                StepCounter++;
                ElevatorDirection = 0;
                foreach (Component c in Floors[FloorCounter])
                {
                    TranferePossible = false;
                    if (Elevator.Count() < 2 && c.Type == "microchip" && FloorCounter < 4)
                    {
                        foreach (Component cee in Floors[FloorCounter])
                            if (cee.Type == "generator" && cee.Element == c.Element)
                            {
                                Elevator.Add(c);
                                Elevator.Add(cee);
                                ElevatorDirection = 1;
                            }
                        if (Elevator.Count() < 2)
                        {
                            if (!Floors[FloorCounter + 1].Any())
                                TranferePossible = true;
                            else
                                foreach (Component cee in Floors[FloorCounter + 1])
                                    if (cee.Element == c.Element)
                                        TranferePossible = true;
                            if (TranferePossible)
                            {
                                Elevator.Add(c);
                                ElevatorDirection = 1;
                            }
                        }
                    }
                }
                //foreach (Component c in Floors[FloorCounter])
                //{
                //    if (Elevator.Count() == 1 && c.Type == "generator")
                //    {
                //        if (Elevator.First().Element == c.Element)
                //        {
                //            Elevator.Add(c);
                //            ElevatorDirection = 1;
                //        }
                //    }
                //}
                if (Elevator.Count == 1 && FloorCounter > 1)
                {
                    for(int i = 1; i <= FloorCounter; i++)
                    {
                        if (Floors[i].Any())
                            ElevatorDirection = -1;
                    }
                }
                if (!Elevator.Any() && FloorCounter >1)
                {
                    foreach (Component c in Floors[FloorCounter])
                    {
                        if (!Elevator.Any() && c.Type == "microchip")
                        {
                            TranferePossible = true;
                            foreach (Component cee in Floors[FloorCounter - 1])
                                if (cee.Type == "generator")
                                    TranferePossible = false;
                            foreach (Component cee in Floors[FloorCounter - 1])
                                if (c.Element != cee.Element)
                                    TranferePossible = true;
                            if (TranferePossible)
                            {
                                Elevator.Add(c);
                                ElevatorDirection = -1;
                            }
                            else
                            {
                                return "oh no";
                            }
                        }
                    }
                }
                foreach (Component c in Elevator)
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