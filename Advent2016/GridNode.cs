using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Advent2016
{
    class GridNode
    {
        int X;
        int Y;
        Coordinate ID;
        int Size;
        int Used;
        int Avail;
        int UsePrecent;
        public GridNode(string s)
        {
            Regex NumberMatches = new Regex(@"\d+");
            List<string> Numbers = new List<string>();
            foreach (Match m in NumberMatches.Matches(s))
                Numbers.Add(m.Value);
            Int32.TryParse(Numbers[0], out X);
            Int32.TryParse(Numbers[1], out Y);
            Int32.TryParse(Numbers[2], out Size);
            Int32.TryParse(Numbers[3], out Used);
            Int32.TryParse(Numbers[4], out Avail);
            Int32.TryParse(Numbers[5], out UsePrecent);
            ID = new Coordinate(X, Y);
        }
        public GridNode(GridNode g)
        {
            int X = g.X;
            int Y = g.Y;
            Coordinate ID = new Coordinate(g.ID);
            int Size = g.Size;
            int Used = g.Used;
            int Avail = g.Avail;
            int UsePrecent = g.UsePrecent;
        }
        public bool IsViablePair(GridNode g)
        {
            return ID != g.ID && Used != 0 && Used <= g.Avail;
        }
        public Coordinate GetID()
        {
            return ID;
        }
        public bool IsEmpty()
        {
            return Used == 0;
        }
        public Coordinate GetLeftCoordinate()
        {
            return new Coordinate(ID.x - 1, ID.y);
        }
        public void Recive(GridNode g)
        {
            Used = g.Used;
            Avail = Size - Used;
        }
        public void Clear()
        {
            Used = 0;
            Avail = Size;
        }

    }
}
