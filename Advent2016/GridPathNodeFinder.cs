using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    class GridPathNodeFinder
    {
        Coordinate CurrentPosition;
        List<Coordinate> VisitedPositions;
        Coordinate TheData;
        public GridPathNodeFinder(Coordinate theData,Coordinate TheEmptyOne, List<Coordinate> v)
        {
            CurrentPosition = TheEmptyOne;
            VisitedPositions = new List<Coordinate>(v);
            TheData = new Coordinate(theData);
            VisitedPositions.Add(CurrentPosition);
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
        public Coordinate GetTheData()
        {
            return TheData;
        }
        public bool CanHasGoLeft()
        {
            return CurrentPosition.IsOn(TheData.GetSum(new Coordinate(-1,0)));
        }
    }
}
