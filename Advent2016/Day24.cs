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
            Dictionary<char, Coordinate> PlacesToBe = new Dictionary<char, Coordinate>();
            Dictionary<char, Coordinate> TwoPlaces = new Dictionary<char, Coordinate>();
            StringPermutator Purme = new StringPermutator();
            bool[,] TheGrid = new bool[MaxX, MaxY];
            Dictionary<string, int> Distances = new Dictionary<string, int>();
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
            //Pick out all the pair distances
            foreach (KeyValuePair<char, Coordinate> kx in PlacesToBe)
            {
                foreach (KeyValuePair<char, Coordinate> ky in PlacesToBe)
                {
                    if (kx.Key != ky.Key)
                    {
                        TwoPlaces.Add(kx.Key, kx.Value);
                        TwoPlaces.Add(ky.Key, ky.Value);
                        KeyValuePair<string, int> WhyCantIUseThisDirectly = GetDistance(TwoPlaces, TheGrid);
                        if (!Distances.ContainsKey(WhyCantIUseThisDirectly.Key))
                        {
                            Distances.Add(WhyCantIUseThisDirectly.Key, WhyCantIUseThisDirectly.Value);
                        }
                        TwoPlaces.Clear();
                    }
                }
            }
            //make a list of possible sequenses
            List<char> PossibleSequence = new List<char>();
            List<string> AllThePossibleSequences;
            string TheFirstSequence = "";
            
            foreach(KeyValuePair<char,Coordinate> k in PlacesToBe)
            {
                PossibleSequence.Add(k.Key);
                TheFirstSequence += k.Key;
            }
            TheFirstSequence = TheFirstSequence.Remove(0, 1);
            AllThePossibleSequences = Purme.GetStrings(TheFirstSequence);
            int TestLenght;
            string TestString;
            //make a big sum
            foreach (KeyValuePair<string, int> k in Distances)
                Sum += k.Value;
            Sum2 += Sum;
            //Go through all the strings
            foreach (string s in AllThePossibleSequences)
            {
                TestLenght = 0;
                TestString = s.Insert(0, "0");
                string TesterString;
                List<char> ToSort = new List<char>();
                for(int i = 0; i < s.Length;i++)
                {
                    TesterString = TestString.Substring(i, 2);
                    foreach (char c in TesterString)
                        ToSort.Add(c);
                    ToSort.Sort();
                    TesterString = "";
                    foreach (char c in ToSort)
                        TesterString += c;
                    ToSort.Clear();
                    TestLenght += Distances[TesterString];

                }
                if (TestLenght < Sum)
                    Sum = TestLenght;
            }
            // del 2
            foreach (string s in AllThePossibleSequences)
            {
                TestLenght = 0;
                TestString = s.Insert(0, "0");
                TestString += "0";
                string TesterString;
                List<char> ToSort = new List<char>();
                for (int i = 0; i <= s.Length; i++)
                {
                    TesterString = TestString.Substring(i, 2);
                    foreach (char c in TesterString)
                        ToSort.Add(c);
                    ToSort.Sort();
                    TesterString = "";
                    foreach (char c in ToSort)
                        TesterString += c;
                    ToSort.Clear();
                    TestLenght += Distances[TesterString];

                }
                if (TestLenght < Sum2)
                    Sum2 = TestLenght;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public KeyValuePair<string, int> GetDistance(Dictionary<char, Coordinate> d, bool[,] TheGrid)
        {
            int Distance = 0;
            List<char> AllTheKeys = new List<char>();
            //setting up a key
            foreach (KeyValuePair<char, Coordinate> c in d)
                AllTheKeys.Add(c.Key);
            AllTheKeys.Sort();
            string Keystring = "";
            foreach (char c in AllTheKeys)
                Keystring += c;
            //doing the path
            int MaxX = TheGrid.GetLength(0);
            int MaxY = TheGrid.GetLength(1);
            Coordinate TestCoordinate;
            List<Coordinate> AllAdjantDirections = new List<Coordinate>
            {
                {new Coordinate(0, 1) },
                {new Coordinate(0, -1) },
                {new Coordinate(-1, 0) },
                {new Coordinate(1, 0) }
            };
            List<PathFinder> Paths = new List<PathFinder>();
            Paths.Add(new PathFinder(d));
            List<PathFinder> NextPaths = new List<PathFinder>();
            HashSet<string> PathDigests = new HashSet<string>();
            bool IsCrossing = true;
            int DirectionCounter;
            PathFinder Digesting;
            bool GetOut = false;
            while (!GetOut)
            {
                Distance++;
                foreach (PathFinder p in Paths)
                {
                    if (p.TargetFound())
                    {
                        GetOut = true;
                        break;
                    }
                    DirectionCounter = 0;
                    foreach (Coordinate ad in AllAdjantDirections)
                    {
                        TestCoordinate = p.GetCurrentPosition().GetSum(ad);
                        if (!TheGrid[TestCoordinate.x, TestCoordinate.y])
                            DirectionCounter++;
                        IsCrossing = DirectionCounter > 2;
                    }
                    foreach (Coordinate ad in AllAdjantDirections)
                    {
                        TestCoordinate = p.GetCurrentPosition().GetSum(ad);
                        if (TestCoordinate.IsInPositiveBounds(MaxX - 1, MaxY - 1) & !TheGrid[TestCoordinate.x, TestCoordinate.y] & !p.HasVisited(TestCoordinate))
                        {
                            Digesting = new PathFinder(TestCoordinate, p.getVisitedPositions(), p.getTargets());
                            if (!PathDigests.Contains(Digesting.MakePathDigest()))
                            {
                                NextPaths.Add(new PathFinder(TestCoordinate, p.getVisitedPositions(), p.getTargets()));
                                if (IsCrossing)
                                    PathDigests.Add(Digesting.MakePathDigest());
                            }
                        }
                    }
                }
                Paths = new List<PathFinder>(NextPaths);
                NextPaths.Clear();
            }
            Distance--;
            return new KeyValuePair<string, int>(Keystring, Distance);
        }
    }
}