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
        CoordinateEqualityComparer CoordinateCompare;
        Dictionary<Coordinate, GridNode> GridDic;
        Coordinate TheTarget;
        public GridPathNodeFinder(Coordinate theData,Coordinate TheEmptyOne, List<Coordinate> v, Dictionary<Coordinate,GridNode> d)
        {
            CurrentPosition = TheEmptyOne;
            VisitedPositions = new List<Coordinate>(v);
            TheData = new Coordinate(theData);
            VisitedPositions.Add(CurrentPosition);
            CoordinateCompare = new CoordinateEqualityComparer();
            GridDic = d;
            TheTarget = new Coordinate(0, 0);
        }
        public GridPathNodeFinder(GridPathNodeFinder p)
        {
            CurrentPosition = new Coordinate( p.CurrentPosition);
            VisitedPositions = new List<Coordinate>();
            foreach (Coordinate c in p.VisitedPositions)
                VisitedPositions.Add(new Coordinate(c));
            TheData = new Coordinate( p.TheData);
            CoordinateCompare = new CoordinateEqualityComparer();
            GridDic = new Dictionary<Coordinate, GridNode>();
            foreach (KeyValuePair<Coordinate, GridNode> g in p.GridDic)
                GridDic.Add(new Coordinate(g.Key), new GridNode(g.Value));
            TheTarget = new Coordinate(0, 0);
        }
        public bool IsLeftOfTheData()
        {
            Coordinate LeftOfData;
            LeftOfData = GridDic[TheData].GetLeftCoordinate();
            if (GridDic[TheData].IsViablePair(GridDic[LeftOfData]))
            {
                GridDic[LeftOfData].Recive(GridDic[TheData]);
                GridDic[TheData].Clear();
                TheData.x--;
                CurrentPosition.x++;
                VisitedPositions.Clear();
                return true;
            }
            else
                return false;
        }
        public bool IsOnTarget()
        {
            return CurrentPosition.IsOn(TheTarget);
        }
        public bool IsViableMove(Coordinate TestCoordinate)
        {
            return GridDic.ContainsKey(TestCoordinate) && GridDic[TestCoordinate].IsViablePair(GridDic[CurrentPosition]) & !VisitedPositions.Contains(TestCoordinate) & !TestCoordinate.IsOn(TheData);
        }
        public void MoveIt(Coordinate TestCoordinate)
        {
            GridDic[CurrentPosition].Recive(GridDic[TestCoordinate]);
            GridDic[TestCoordinate].Clear();
            CurrentPosition = new Coordinate( TestCoordinate);
            VisitedPositions.Add(new Coordinate( TestCoordinate));
        }
        public Coordinate GetCurrentPosition()
        {
            return new Coordinate( CurrentPosition);
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
