using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day19
    {
        private string Input;
        Stopwatch stopWatch = new Stopwatch();
        public Day19(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "");
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int NrOfElves = 0;
            Int32.TryParse(Input, out NrOfElves);
            int NrOfElves2 = NrOfElves;
            List<Coordinate> ElvenParty = new List<Coordinate>();
            List<Coordinate> ElvenPartyCopy = new List<Coordinate>();
            //setting up
            for (int i = 1;i <= NrOfElves; i++)
            {
                ElvenParty.Add(new Coordinate (i, 1));
            }
            //Swapping around
            while (ElvenParty.Count > 1)
            {
                for (int i = 0; i < ElvenParty.Count; i++)
                {
                    if (ElvenParty[i].y > 0)
                    {
                        if (i != ElvenParty.Count - 1)
                        {
                            ElvenParty[i].y += ElvenParty[i + 1].y;
                            ElvenParty[i + 1].y = 0;
                            ElvenPartyCopy.Add(ElvenParty[i]);
                        }
                        else
                        {
                            ElvenParty[i].y += ElvenPartyCopy[0].y;
                            ElvenPartyCopy.RemoveAt(0);
                            ElvenPartyCopy.Add(ElvenParty[i]);
                        }
                    }
                }
                ElvenParty = new List<Coordinate>(ElvenPartyCopy);
                ElvenPartyCopy.Clear();
            }
            foreach(Coordinate Elf in ElvenParty)
            {
                Sum = Elf.x;
            }
            //Part 2
            ElvenParty.Clear();
            ElvenPartyCopy.Clear();
            List<int> ElvenParty2 = new List<int>();
            //setting up
            for (int i = 1; i <= NrOfElves2; i++)
            {
                ElvenParty2.Add(i);
            }
            //Swapping around
            int CurrentElf = 1;
            string DeadElves = "";
            // Slightly faster brute force that doesnt work.
            //while (NrOfElves2 > 1)
            //{
            //    int middle = NrOfElves2 / 2;
            //    int offset = middle + CurrentElf;
            //    int mod = offset % NrOfElves2;
            //    DeadElves += ElvenParty2[mod].ToString() + ", ";
            //    ElvenParty2.RemoveAt(mod);
            //    NrOfElves2--;
            //    CurrentElf++;
            //    if (CurrentElf == NrOfElves2)
            //        CurrentElf = NrOfElves2-1;
            //    if (CurrentElf > NrOfElves2)
            //        CurrentElf = 0;
            //}
            //Slow brute force that works
            for (int i = 1; i <= NrOfElves2-1; i++)
            {
                ElvenParty2.RemoveAt(ElvenParty2.Count / 2);
                ElvenParty2.Add(ElvenParty2[0]);
                ElvenParty2.RemoveAt(0);
            }
            // Fast soulution based on patterns in soulutions
            //for (int i = 1; i <= NrOfElves2; i++)
            //{
            //    if (CurrentElf < i/2)
            //        CurrentElf++;
            //    else
            //        CurrentElf += 2;
            //    if (CurrentElf > i)
            //        CurrentElf = 1;
            //}
            Sum2 = ElvenParty2[0];
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return DeadElves+"Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}