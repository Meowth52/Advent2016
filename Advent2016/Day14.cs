﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Advent2016
{
    class Day14
    {
        private string Salt;
        Stopwatch stopWatch = new Stopwatch();
        public Day14(string input)
        {
            stopWatch.Start();
            Salt = input.Replace("\r\n", "");
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int Iterator = 0;
            int EndCounter = 0;
            byte[] byteData;
            string TestString;
            List<int> RemoveKeys = new List<int>();
            MD5 hashis = MD5.Create();
            StringBuilder HexString = new StringBuilder();
            Dictionary<int, string> FrippleTestContenders = new Dictionary<int, string>();
            Dictionary<int, string> KeyContenders = new Dictionary<int, string>();
            while (true)
            {
                HexString.Clear();
                byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(Salt + Iterator.ToString()));
                int ByteLenght = byteData.Length;
                for (int i = 0; i < byteData.Length; i++)
                {
                    HexString.Append(byteData[i].ToString("x2"));
                }
                TestString = HexString.ToString();
                foreach (KeyValuePair<int, string> s in FrippleTestContenders)
                {
                    if (TestString.Contains(s.Value))
                    {
                        KeyContenders.Add(s.Key, s.Value);
                        RemoveKeys.Add(s.Key);
                    }
                }
                if (EndCounter == 0)
                {
                    char LastChar = 'x';
                    char EvenLasterChar = 'y';
                    foreach (char c in TestString)
                    {
                        if (c == LastChar && c== EvenLasterChar)
                        {
                            FrippleTestContenders.Add(Iterator, c.ToString() + c + c + c + c);
                            break;
                        }
                        EvenLasterChar = LastChar;
                        LastChar = c;
                    }
                }
                FrippleTestContenders.Remove(Iterator-1000);
                foreach(int i in RemoveKeys)
                {
                    FrippleTestContenders.Remove(i);
                }
                RemoveKeys.Clear();
                if (KeyContenders.Count >= 64)
                    EndCounter++;
                if (EndCounter >= 1000)
                    break;
                Iterator++;
            }
            List<int> ResultIndex = new List<int>();
            foreach(KeyValuePair<int,string> k in KeyContenders)
            {
                ResultIndex.Add(k.Key);
            }
            ResultIndex.Sort();
            Sum = ResultIndex[63];
            // del 2
            Iterator = 0;
            EndCounter = 0;
            FrippleTestContenders.Clear();
            KeyContenders.Clear();
            while (true)
            {
                HexString.Clear();
                string Hashstring = Salt + Iterator.ToString();
                for (int i = 0; i <= 2016; i++)
                {
                    byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(Hashstring));
                    HexString.Clear();
                    int ByteLenght = byteData.Length;
                    for (int bi = 0; bi < byteData.Length; bi++)
                    {
                        HexString.Append(byteData[bi].ToString("x2"));
                    }
                    Hashstring = HexString.ToString();
                }
                TestString = Hashstring;
                foreach (KeyValuePair<int, string> s in FrippleTestContenders)
                {
                    if (TestString.Contains(s.Value))
                    {
                        KeyContenders.Add(s.Key, s.Value);
                        RemoveKeys.Add(s.Key);
                    }
                }
                if (EndCounter == 0)
                {
                    char LastChar = 'x';
                    char EvenLasterChar = 'y';
                    foreach (char c in TestString)
                    {
                        if (c == LastChar && c == EvenLasterChar)
                        {
                            FrippleTestContenders.Add(Iterator, c.ToString() + c + c + c + c);
                            break;
                        }
                        EvenLasterChar = LastChar;
                        LastChar = c;
                    }
                }
                FrippleTestContenders.Remove(Iterator - 1000);
                foreach (int i in RemoveKeys)
                {
                    FrippleTestContenders.Remove(i);
                }
                RemoveKeys.Clear();
                if (KeyContenders.Count >= 64)
                    EndCounter++;
                if (EndCounter >= 1000)
                    break;
                Iterator++;
            }
            ResultIndex.Clear();
            foreach (KeyValuePair<int, string> k in KeyContenders)
            {
                ResultIndex.Add(k.Key);
            }
            ResultIndex.Sort();
            Sum2 = ResultIndex[63];
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            //HexString.Clear();
            //foreach (int r in ResultIndex)
            //    HexString.Append( r.ToString() + ", " + KeyContenders[r] + "\r\n");
            return  "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}