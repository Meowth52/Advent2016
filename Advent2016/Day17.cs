using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;


namespace Advent2016
{
    class Day17
    {
        private string Input;
        Stopwatch stopWatch = new Stopwatch();
        public Day17(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }

        public string Result()
        {
            string Sum = "";
            int Sum2 = 0;
            Dictionary<string, Coordinate> Paths = new Dictionary<string, Coordinate>
            {
                { "", new Coordinate(0, 3) }
            };
            Dictionary<string, Coordinate> NextSteps = new Dictionary<string, Coordinate>();
            string Hash;
            Dictionary<char, Coordinate> AllAdjantDirections = new Dictionary<char, Coordinate>
            {
                { 'U', new Coordinate(0, 1) },
                { 'D', new Coordinate(0, -1) },
                { 'L', new Coordinate(-1, 0) },
                { 'R', new Coordinate(1, 0) }
            };
            // getting a predictable index fo the dict
            char[] DirectionIndex = { 'U', 'D', 'L', 'R' };
            Coordinate Target = new Coordinate(3, 0);
            MD5 hashis = MD5.Create();
            while (true)
            {
                foreach (KeyValuePair<string, Coordinate> p in Paths)
                {
                    if (p.Value.IsOn(Target))
                    {
                        Sum2 = p.Key.Length;                        
                        if (Sum == "")
                            Sum = p.Key;
                        //This path is now dead
                        continue;
                    }
                    Hash = GetHash(Input + p.Key);
                    //Check every direction
                    for (int i = 0; i < 4; i++)
                    {
                        //if its wihtin bounds and open
                        if (p.Value.GetSum(AllAdjantDirections[DirectionIndex[i]]).IsInPositiveBounds(3, 3) && Hash[i] > 'a')
                        {
                            NextSteps.Add(p.Key + DirectionIndex[i], p.Value.GetSum(AllAdjantDirections[DirectionIndex[i]]));
                        }
                    }
                }
                if (NextSteps.Count == 0)
                {
                    break;
                }

                Paths = new Dictionary<string, Coordinate>(NextSteps);
                NextSteps.Clear();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        //Lets get this hash bulshit out of the way
        public string GetHash(string s)
        {
            MD5 hashis = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();
            byte[] byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(s));
            for (int i = 0; i < byteData.Length; i++)
            {
                sBuilder.Append(byteData[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}