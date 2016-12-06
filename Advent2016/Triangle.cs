using System.Collections.Generic;
using System;

namespace Advent2016

{
    internal class Triangle
    {
        string[] SidesRaw;
        List<int> Sides = new List<int>();
        public Triangle(string s)
        {
            SidesRaw = s.Split(' ');
            foreach(string d in SidesRaw)
            {
                if (d !="")
                    Sides.Add(Convert.ToInt32(d));
            }
        }
        public Triangle(int x, int y, int z)
        {
            Sides.Add(x);
            Sides.Add(y);
            Sides.Add(z);
        }
        public bool isTriangle()
        {
            Sides.Sort();
            if (Sides[0] + Sides[1] > Sides[2])
                return true;
            else
                return false;
        }
    }
}