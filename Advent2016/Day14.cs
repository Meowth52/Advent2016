using System;
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
            byte[] byteData;
            string TestString;
            int KeyCounter = 0;
            MD5 hashis = MD5.Create();
            StringBuilder HexString = new StringBuilder();
            string TestBuilder;
            List<string> TrippleTest = new List<string>();
            //List<string> FrippleTest = new List<string>();
            Dictionary<int, string> FrippleTestContenders = new Dictionary<int, string>();
            for(int i = 0; i < 16; i++)
            {
                TestBuilder = Convert.ToString(i, 16);
                TestBuilder += TestBuilder + TestBuilder;
                TrippleTest.Add(TestBuilder);
            }
            //for (int i = 0; i < 16; i++)
            //{
            //    TestBuilder = Convert.ToString(i, 16);
            //    TestBuilder += TestBuilder + TestBuilder + TestBuilder + TestBuilder;
            //    FrippleTest.Add(TestBuilder);
            //}

            while (true)
            {
                HexString.Clear();
                byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(Salt + Iterator.ToString()));
                int ByteLenght = byteData.Length;
                for (int i = 0; i < ByteLenght-2; i += 2)
                {                   
                    ushort Hashnumber = BitConverter.ToUInt16(byteData, i);
                    HexString.Append(Convert.ToString(Hashnumber, 16));
                }
                TestString = HexString.ToString();
                foreach(string s in TrippleTest)
                {
                    if (TestString.Contains(s))
                    {
                        FrippleTestContenders.Add(Iterator, s + s[0] + s[0]);
                        break;
                    }
                }
                FrippleTestContenders.Remove(Iterator-1000);
                foreach(KeyValuePair<int, string> s in FrippleTestContenders)
                {
                    if (TestString.Contains(s.Value))
                    {
                        KeyCounter++;
                        Sum = s.Key;
                        break;
                    }
                }
                if (KeyCounter >= 1)
                    break;
                Iterator++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}