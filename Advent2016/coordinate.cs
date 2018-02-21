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
        public Coordinate(Coordinate c)
        {
            x = c.x;
            y = c.y;
        }
        public bool IsOn(Coordinate c)
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
        public bool IsInPositiveBounds(int x2, int y2)
        {
            return (x >= 0 && y >= 0 && x <= x2 && y <= y2);
        }
        public override string ToString()
        {
            return string.Format("{0},{1}", x, y);
        }
    }
}