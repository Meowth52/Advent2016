using System;
using System.Collections.Generic;

namespace Advent2016
{
    internal class Day1
    {
        private string Input;
        private string[] strings;
        private Coordinate position = new Coordinate(0, 0); 
        private int direction = 0;
        private List<Coordinate> positions = new List<Coordinate>();

        public Day1(string input)
        {
            this.Input = input;
            Input = Input.Replace(" ", "");
            strings = Input.Split(',');
        }

        internal string Result()
        {
            foreach (string s in strings)
            {
                if (s[0] == 'R')
                {
                    direction--;
                    if (direction < 0)
                        direction = 3;
                }
                else
                {
                    direction++;
                    if (direction > 3)
                        direction = 0;
                }
                string cropped = s.Remove(0, 1);
                int blocks = Convert.ToInt32(cropped);

                switch (direction)
                {
                    case 0:
                        for (int i = 1; i <= blocks; i++)
                        {
                            position.x = position.x + 1;
                            positions.Add(new Coordinate(position.x, position.y));
                        }
                        break;
                    case 1:
                        for (int i = 1; i <= blocks; i++)
                        {
                            position.y = position.y - 1;
                            positions.Add(new Coordinate(position.x, position.y));
                        }
                        break;
                    case 2:
                        for (int i = 1; i <= blocks; i++)
                        {
                            position.x = position.x - 1;
                            positions.Add(new Coordinate(position.x, position.y));
                        }
                        break;
                    case 3:
                        for (int i = 1; i <= blocks; i++)
                        {
                            position.y = position.y + 1;
                            positions.Add(new Coordinate(position.x, position.y));
                        }
                        break;
                    default:
                        throw new Exception();
                }

            }
            List<Coordinate> tempList = new List<Coordinate>();
            Coordinate intersection = new Coordinate(0,0);
            foreach (Coordinate i in positions)
            {
                if (tempList.Exists(x=> x.compare(i)))
                {
                    intersection = i;
                    break;
                }
                else
                    tempList.Add(i);

            }
            return "Lösning del 1: " + (Math.Abs(position.x) + Math.Abs(position.y)) + " Lösning del 2: " + (Math.Abs(intersection.x) + Math.Abs(intersection.y));
        }
    }
}