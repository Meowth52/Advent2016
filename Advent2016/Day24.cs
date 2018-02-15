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
            Dictionary<Coordinate, Dictionary<char, Coordinate>> Paths = new Dictionary<Coordinate, Dictionary<char, Coordinate>>();
            Dictionary<Coordinate, Dictionary<char, Coordinate>> NextPaths = new Dictionary<Coordinate, Dictionary<char, Coordinate>>();
            List<Coordinate> VisitedPositions = new List<Coordinate>();
            char RemoveIndex = '_';
            bool Remove;
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
            Paths.Add(PlacesToBe['0'], PlacesToBe);
            Paths[PlacesToBe['0']].Remove('0');
            bool GetOut = false;
            while (!GetOut)
            {
                Remove = false;
                Sum++;
                foreach (KeyValuePair<Coordinate, Dictionary<char, Coordinate>> p in Paths)
                {
                    foreach (KeyValuePair<char, Coordinate> k in p.Value)
                    {
                        if (k.Value.IsOn(p.Key))
                        {
                            Remove = true;
                            RemoveIndex = k.Key;
                            PlacesToBeen = new Dictionary<char, Coordinate>( p.Value);
                            //This path is now dead
                            continue;
                        }
                    }
                    if (Remove)
                    {
                        continue;
                    }
                    foreach (Coordinate d in AllAdjantDirections)
                    {
                        TestCoordinate = p.Key.GetSum(d);
                        bool AnotherBloodyTestBool = false;
                        foreach (Coordinate c in VisitedPositions)
                            if (c.IsOn(TestCoordinate))
                                AnotherBloodyTestBool = true;
                        if (TestCoordinate.IsInPositiveBounds(MaxX-1, MaxY - 1) &! TheGrid[TestCoordinate.x,TestCoordinate.y] &! AnotherBloodyTestBool)
                        {
                            NextPaths.Add(TestCoordinate, p.Value);
                            //VisitedPositions.Add(TestCoordinate);
                        }
                    }
                }
                Paths = new Dictionary<Coordinate, Dictionary<char, Coordinate>>(NextPaths);
                NextPaths.Clear();
                if (Remove)
                {
                    VisitedPositions.Clear();
                    Paths.Add(PlacesToBeen[RemoveIndex], PlacesToBeen);
                    Paths[PlacesToBeen[RemoveIndex]].Remove(RemoveIndex);
                    foreach (KeyValuePair<Coordinate, Dictionary<char, Coordinate>> p in Paths)
                        if (p.Value.Count == 0)
                            GetOut = true;
                }
            }
            Sum--;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}