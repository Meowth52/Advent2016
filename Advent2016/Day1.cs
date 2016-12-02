using System;

namespace Advent2016
{
    internal class Day1
    {
        private string Input;
        private string[] strings;
        private int[] position = { 0, 0 };
        private int direction = 0;

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
                        position[0] = position[0] + blocks;
                        break;
                    case 1:
                        position[1] = position[1] - blocks;
                        break;
                    case 2:
                        position[0] = position[0] - blocks;
                        break;
                    case 3:
                        position[1] = position[1] + blocks;
                        break;
                    default:
                        throw new Exception();
                        break;
                }

            }
            return "Dag 1 ej implementerad" + (Math.Abs(position[0])+Math.Abs(position[1]));
            throw new NotImplementedException();
        }
    }
}