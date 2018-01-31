namespace Advent2016
{
    internal class Coordinate
    {
        public int x;
        public int y;
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool compare(Coordinate c)
        {
            return(c.x==this.x && c.y==this.y);
        }
        public void AddTo(Coordinate A)
        {
            x += A.x;
            y += A.y;
        }
        public Coordinate GetSum(Coordinate A)
        {
            int x2 = x + A.x;
            int y2 = y + A.y;
            return new Coordinate(x2, y2);
        }
    }
}