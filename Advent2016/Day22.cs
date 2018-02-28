using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day22
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        public Day22(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            //Setup
            int Sum = 0;
            int Sum2 = 0;
            List<GridNode> GridNodes = new List<GridNode>();
            foreach (string s in Instructions)
            {
                if (s.Contains("/"))
                {
                    GridNodes.Add(new GridNode(s));
                }
            }
            //Part 1
            foreach(GridNode A in GridNodes)            
                foreach (GridNode B in GridNodes)
                    if (A.IsViablePair(B))
                        Sum++;
            //Part 2
            CoordinateEqualityComparer CoordinateCompare = new CoordinateEqualityComparer();
            Dictionary<Coordinate, GridNode> GridDic = new Dictionary<Coordinate, GridNode>(CoordinateCompare);
            Coordinate GridMax = new Coordinate(0, 0);
            Coordinate TheEmptyOne = new Coordinate(0,0);
            List<Coordinate> AllAdjantDirections = new List<Coordinate>();
            AllAdjantDirections.Add(new Coordinate(-1, 0));
            AllAdjantDirections.Add(new Coordinate(0, -1));
            AllAdjantDirections.Add(new Coordinate(0, 1));
            AllAdjantDirections.Add(new Coordinate(1, 0));
            foreach (GridNode g in GridNodes)
            {
                GridDic.Add(g.GetID(), g);
                if (g.GetID().x > GridMax.x)
                    GridMax.x = g.GetID().x;
                if (g.GetID().y > GridMax.y)
                    GridMax.y = g.GetID().y;
                if (g.IsEmpty())
                    TheEmptyOne = g.GetID();
            }
            Coordinate Target = new Coordinate(0,0);
            Coordinate TheData = new Coordinate(GridMax.x, 0);
            Coordinate Left = new Coordinate(-1, 0);
            int TheEmptyY = TheEmptyOne.y;
            int TheEmptyX = TheEmptyOne.x;
            List<GridPathNodeFinder> Paths = new List<GridPathNodeFinder>();
            Paths.Add(new GridPathNodeFinder(TheData,TheEmptyOne, new List<Coordinate>(), GridDic));
            List<GridPathNodeFinder> NextPaths = new List<GridPathNodeFinder>();
            Coordinate LeftOfData;
            Coordinate TestCoordinate;
            List<Coordinate> MoreVisitedPositions = new List<Coordinate>();
            bool GetOut = false;
            while (!GetOut)
            {
                Sum2++;
                foreach (GridPathNodeFinder p in Paths)
                {
                    LeftOfData = p.GetTheData().GetSum(Left);
                    if (p.IsLeftOfTheData())
                    {
                        if (p.IsOnTarget())
                            GetOut = true;
                        NextPaths.Clear();
                        NextPaths.Add(new GridPathNodeFinder(p));
                        break;
                    }
                    foreach (Coordinate c in AllAdjantDirections)
                    {
                        TestCoordinate = new Coordinate( p.GetCurrentPosition()).GetSum(c);
                        if (p.IsViableMove(TestCoordinate))
                        {
                            GridPathNodeFinder Tempidemp = new GridPathNodeFinder(p);
                            Tempidemp.MoveIt(TestCoordinate);
                            if ((Tempidemp.GetCurrentPosition().y <= TheEmptyY || Tempidemp.GetCurrentPosition().y <= 4) && (Tempidemp.GetCurrentPosition().x >= TheEmptyX || (TheEmptyY > 10 || Math.Abs(TestCoordinate.x - p.GetTheData().x) < 5)))
                            {
                                TheEmptyY = Tempidemp.GetCurrentPosition().y;
                                TheEmptyX = Tempidemp.GetCurrentPosition().x;
                                NextPaths.Add(Tempidemp);
                            }
                        }
                    }
                }
                Paths = new List<GridPathNodeFinder>(NextPaths);
                NextPaths.Clear();
            }
            //Sum2 -=2;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}