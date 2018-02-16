using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day24
    {
        private string Input;
        private string[] Instructions;
        Stopwatch stopWatch = new Stopwatch();
        public Day24(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Input = Input.TrimEnd('_');
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int MaxX = Instructions.Length;
            int MaxY = Instructions[0].Length;
            bool[,] TheGrid = new bool[MaxX, MaxY];
            Coordinate TestCoordinate;
            Dictionary<char, Coordinate> PlacesToBe = new Dictionary<char, Coordinate>();
            Dictionary<char, Coordinate> PlacesToBeen = new Dictionary<char, Coordinate>();
            List<Coordinate> AllAdjantDirections = new List<Coordinate>
            {
                {new Coordinate(0, 1) },
                {new Coordinate(0, -1) },
                {new Coordinate(-1, 0) },
                {new Coordinate(1, 0) }
            };
            List<PathFinder> Paths = new List<PathFinder>();
            List<PathFinder> NextPaths = new List<PathFinder>();
            //Make the grid and collect the targets
            for (int x = 0; x < MaxX; x++)
            {
                for (int y = 0; y < MaxY; y++)
                {
                    if (Instructions[x][y] == '#')
                        TheGrid[x, y] = true;
                    else
                    {
                        TheGrid[x, y] = false;
                        if (char.IsDigit(Instructions[x][y]))
                        {
                            PlacesToBe.Add(Instructions[x][y], new Coordinate(x, y));
                        }
                    }
                }
            }
            Paths.Add(new PathFinder(PlacesToBe));
            bool GetOut = false;
            while (!GetOut)
            {
                Remove = false;
                Sum++;
                foreach (PathFinder p in Paths)
                {
                    if (p.TargetFound())
                        GetOut = true;
                    foreach (Coordinate d in AllAdjantDirections)
                    {
                        TestCoordinate = p.GetCurrentPosition().GetSum(d);
                        if (TestCoordinate.IsInPositiveBounds(MaxX-1, MaxY - 1) &! TheGrid[TestCoordinate.x,TestCoordinate.y] &! p.HasVisited(TestCoordinate))
                        {
                            NextPaths.Add(new PathFinder(TestCoordinate, p.getVisitedPositions(), p.getTargets()));
                        }
                    }
                }
                Paths = new List<PathFinder>(NextPaths);
                NextPaths.Clear();
            }
            Sum--;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}