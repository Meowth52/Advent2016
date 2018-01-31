using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day13
    {
        private string Input;
        private int FavoriteNumber;
        private bool[,] TheGrid = new bool[50,50];
        Stopwatch stopWatch = new Stopwatch();
        public Day13(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
            Int32.TryParse(Input, out FavoriteNumber);
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    int Number = x * x + 3 * x + 2 * x * y + y + y * y+FavoriteNumber;
                    int NumberOfBits = NumberOfSetBits(Number);
                    TheGrid[x, y] = (NumberOfBits % 2 != 0);
                }
            }
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            Dictionary<int, Coordinate> CurrentPosition = new Dictionary<int, Coordinate>();
            CurrentPosition.Add(1, new Coordinate(1, 1));
            Coordinate LastPosition = new Coordinate(1,1);
            Coordinate TargetPosition = new Coordinate(31,39);
            List<Coordinate> AllAdjantDirections = new List<Coordinate>();
            AllAdjantDirections.Add(new Coordinate(1, 0));
            AllAdjantDirections.Add(new Coordinate(0, 1));
            AllAdjantDirections.Add(new Coordinate(0, -1));
            AllAdjantDirections.Add(new Coordinate(-1, 0));
            Coordinate TestCoordinate;
            int NextInt = 1;
            bool Quit = false;
            int StepCounter = 0;
            while (!Quit)
            {
                StepCounter++;
                Sum++;
                Dictionary<int, Coordinate> IteratingList = new Dictionary<int, Coordinate>(CurrentPosition);
                foreach (KeyValuePair<int,Coordinate> c in IteratingList)
                {
                    bool IsDeadEnd = true;
                    foreach (Coordinate d in AllAdjantDirections)
                    {
                        TestCoordinate = c.Value.GetSum(d);
                        if (TestCoordinate.compare(TargetPosition))
                            Quit = true;
                        if (TestCoordinate.x >= 0 && TestCoordinate.x < 50 && TestCoordinate.y >= 0 && TestCoordinate.y < 50 && !TheGrid[TestCoordinate.x, TestCoordinate.y])
                        {
                            if (StepCounter<=50)
                                Sum2++;
                            NextInt++;
                            CurrentPosition.Add(NextInt, TestCoordinate);
                            TheGrid[TestCoordinate.x, TestCoordinate.y] = true;
                            IsDeadEnd = false;
                        }
                    }
                    CurrentPosition.Remove(c.Key);
                    
                }
            }
            //del 2
            StringBuilder sBuilder = new StringBuilder();
            for (int x = 0; x < 50; x++)
            {
                sBuilder.Append("\r\n");
                for (int y = 0; y < 50; y++)
                {
                    if (TheGrid[y, x] == true)
                        sBuilder.Append("#");
                    else
                        sBuilder.Append(".");
                }
            }
                    stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms" + "\r\n" + sBuilder.ToString();
        }
        int NumberOfSetBits(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }
    }
}