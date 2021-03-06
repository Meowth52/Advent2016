﻿using System;
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
            ID = new Coordinate(X, Y);
        }
        public GridNode(GridNode g)
        {
            X = g.X;
            Y = g.Y;
            ID = new Coordinate(g.ID);
            Size = g.Size;
            Used = g.Used;
            Avail = g.Avail;
        }
        public bool IsViablePair(GridNode g)
        {
            return ID != g.ID && Used <= g.Avail;
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
