namespace Advent2016
{
    public class schmenum
    {
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