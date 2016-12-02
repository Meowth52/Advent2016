namespace Advent2016
{
    internal class coordinate
    {
        public int x;
        public int y;
        public coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool compare(coordinate c)
        {
            return(c.x==this.x && c.y==this.y);            
        }
    }
}