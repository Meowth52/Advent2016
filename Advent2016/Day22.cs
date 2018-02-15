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
            Dictionary<Coordinate, GridNode> GridDic = new Dictionary<Coordinate, GridNode>();
            Coordinate GridMax = new Coordinate(0, 0);
            Coordinate TheEmptyOne = new Coordinate(0,0);
            List<Coordinate> AllAdjantDirections = new List<Coordinate>();
            AllAdjantDirections.Add(new Coordinate(1, 0));
            AllAdjantDirections.Add(new Coordinate(0, 1));
            AllAdjantDirections.Add(new Coordinate(0, -1));
            AllAdjantDirections.Add(new Coordinate(-1, 0));
            //foreach (GridNode g in GridNodes)
            //{
            //    GridDic.Add(g.GetID(), g);
            //    if (g.GetID().x > GridMax.x)
            //        GridMax.x = g.GetID().x;
            //    if (g.GetID().y > GridMax.y)
            //        GridMax.y = g.GetID().y;
            //    if (g.IsEmpty())
            //        TheEmptyOne = g;
            //}
            Coordinate Target = new Coordinate(0,0);
            Coordinate TheData = new Coordinate(GridMax.x, 0);
            Coordinate LeftOfData;
            Coordinate TestCoordinate;
            while (!TheData.IsOn(Target))
            {
                LeftOfData = GridDic[TheData].GetLeftCoordinate();
                if (GridDic[TheData].IsViablePair(GridDic[LeftOfData]))
                {
                    GridDic[LeftOfData].Recive(GridDic[TheData]);
                    GridDic[TheData].Clear();
                    TheData.x--;
                    continue;
                }
                foreach (Coordinate c in AllAdjantDirections)
                {
                    TestCoordinate = TheEmptyOne.GetSum(c);
                    if (GridDic.ContainsKey(TestCoordinate) && GridDic[TheEmptyOne].IsViablePair(GridDic[TestCoordinate]))
                    {

                    }
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}