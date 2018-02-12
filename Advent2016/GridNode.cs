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
            Regex NumberMatches = new Regex(@"(\d+)");
            List<string> Numbers = new List<string>();
            foreach (Match m in NumberMatches.Matches("s"))
                Numbers.Add(m.Value);
            Int32.TryParse(Numbers[0], out X);
            Int32.TryParse(Numbers[1], out Y);
            Int32.TryParse(Numbers[2], out Size);
            Int32.TryParse(Numbers[3], out Used);
            Int32.TryParse(Numbers[4], out Avail);
            Int32.TryParse(Numbers[5], out UsePrecent);
            ID = new Coordinate(X, Y);
        }
    }
}
