using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    class PathFinder
    {
        Coordinate CurrentPosition;
        List<Coordinate> VisitedPositions;
        Dictionary<char, Coordinate> Targets;
        public PathFinder(Coordinate c, List<Coordinate> v, Dictionary<char, Coordinate> t)
        {
            CurrentPosition = c;
            VisitedPositions = new List<Coordinate>(v);
            Targets = new Dictionary<char, Coordinate>(t);
            VisitedPositions.Add(CurrentPosition);
        }
        public PathFinder(Dictionary<char, Coordinate> t)
        {
            char SomewhereToStart = t.First().Key;
            CurrentPosition = t[SomewhereToStart];
            VisitedPositions = new List<Coordinate>();
            VisitedPositions.Add(CurrentPosition);
            Targets = t;
            Targets.Remove(SomewhereToStart);
        }
        public bool TargetFound()
        {
            bool FoundIt = false;
            char RemoveThis = '_';
            foreach (KeyValuePair<char, Coordinate> k in Targets)
            {
                if (k.Value.IsOn(CurrentPosition))
                {
                    FoundIt = true;
                    RemoveThis = k.Key;
                }
            }
            if (FoundIt)
            {
                Targets.Remove(RemoveThis);
                VisitedPositions.Clear();
                VisitedPositions.Add(CurrentPosition);
            }
            return Targets.Count == 0;
        }
        public Coordinate GetCurrentPosition()
        {
            return CurrentPosition;
        }
        public bool HasVisited(Coordinate coordinate)
        {
            bool YesItHas = false;
            foreach (Coordinate c in VisitedPositions)
                if (c.IsOn(coordinate))
                    YesItHas = true;
            return YesItHas;
        }
        public List<Coordinate> getVisitedPositions()
        {
            return VisitedPositions;
        }
        public Dictionary<char, Coordinate> getTargets()
        {
            return Targets;
        }
        public string MakePathDigest()
        {
            string PathDigest = "";
            PathDigest += CurrentPosition.ToString();
            foreach(KeyValuePair<char, Coordinate> c in Targets)
            {
                PathDigest += c.ToString();
            }
            return PathDigest;
        }
    }
}
