
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day16
    {
        private string Input;
        private List<bool> DragonData = new List<bool>();
        Stopwatch stopWatch = new Stopwatch();
        public Day16(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            foreach(char c in Input)
            {
                if (c == '1')
                    DragonData.Add(true);
                if (c == '0')
                    DragonData.Add(false);
            }
        }

        public string Result()
        {
            string Sum = "";
            string Sum2 = "";
            List<bool> Part2Copy = new List<bool>(DragonData);
            int DiskLenght = 272;
            List<bool> DragonCopy = new List<bool>();
            while(DragonData.Count < DiskLenght)
            {
                DragonCopy.Clear();
                foreach(bool b in DragonData)
                {
                    DragonCopy.Add(!b);
                }
                DragonCopy.Reverse();
                DragonData.Add(false);
                DragonData.AddRange(DragonCopy);
            }
            DragonData.RemoveRange(DiskLenght, DragonData.Count - DiskLenght);
            List<bool> DragonChecksum = new List<bool>();
            while (DragonData.Count%2==0)
            {
                DragonChecksum.Clear();
                for (int i = 0; i < DragonData.Count; i += 2)
                {
                    DragonChecksum.Add(DragonData[i] == DragonData[i + 1]);
                }
                DragonData = new List<bool>(DragonChecksum);
            }
            foreach(bool b in DragonChecksum)
            {
                if (b)
                    Sum += 1;
                else
                    Sum += 0;
            }

            //del 2

            DiskLenght = 35651584;
            DragonData = new List<bool>(Part2Copy);
            while (DragonData.Count < DiskLenght)
            {
                DragonCopy.Clear();
                foreach (bool b in DragonData)
                {
                    DragonCopy.Add(!b);
                }
                DragonCopy.Reverse();
                DragonData.Add(false);
                DragonData.AddRange(DragonCopy);
            }
            DragonData.RemoveRange(DiskLenght, DragonData.Count - DiskLenght);
            DragonChecksum.Clear();
            while (DragonData.Count % 2 == 0)
            {
                DragonChecksum.Clear();
                for (int i = 0; i < DragonData.Count; i += 2)
                {
                    DragonChecksum.Add(DragonData[i] == DragonData[i + 1]);
                }
                DragonData = new List<bool>(DragonChecksum);
            }
            foreach (bool b in DragonChecksum)
            {
                if (b)
                    Sum2 += 1;
                else
                    Sum2 += 0;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}