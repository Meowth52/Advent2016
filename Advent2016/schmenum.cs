using System;

namespace Advent2016
{
    public class schmenum : IComparable<schmenum>

    {
        public int CompareTo(schmenum other)
        {
            if (this.i == other.i)
            {
                return this.c.CompareTo(other.c);
            }
            return other.i.CompareTo(this.i);
        }
        public char c;
        public int i;

        public schmenum(char c, int i)
        {
            this.c = c;
            this.i = i;
        }
        public bool compare(char comp)
        {
        return (c==comp);
        }
    }

}