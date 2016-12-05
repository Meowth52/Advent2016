using System;
using System.Collections.Generic;
namespace Advent2016
{
    internal class Button
    {
        public int n;
        public List<schmenum> schmenums = new List<schmenum>();

        public Button(int n, int u, int r, int d, int l)
        {
            schmenums.Add(new schmenum('U',u));
            schmenums.Add(new schmenum('R',r));
            schmenums.Add(new schmenum('D',d));
            schmenums.Add(new schmenum('L',l));
            this.n = n;
        }
        public int move(char c)
        {
            foreach (schmenum s in schmenums)
                if (s.compare(c))
                    return (s.i);
            return (0);
        }
    }
}