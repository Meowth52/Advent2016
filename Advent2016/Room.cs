using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent2016
{
    internal class Room
    {
        public List<string> Groups= new List<string>();
        public int RoomID;
        public string Checksum;
        public Room(string s)
        {

            Regex GroupsMatch = new Regex(@"\b([a-z]+)[-]");
            foreach(Match m in GroupsMatch.Matches(s))
                Groups.Add(m.Groups[1].ToString());
            Regex IntMatch = new Regex(@"(\d+)[[](\w+)");
            RoomID = Convert.ToInt32 (IntMatch.Match(s).Groups[1].ToString());
            Checksum = IntMatch.Match(s).Groups[2].ToString();
        }
        public int getIDifOK()
        {
            List<char> CharList = new List<char>();
            char CharMem = '0';
            List<schmenum> schmenums = new List<schmenum>();
            int CounterMem = 0;
            string ChecksumChecker = "";
            foreach (string s in Groups)
            {
                foreach (char c in s)
                {
                    CharList.Add(c);
                }
            }
            CharList.Sort();
            CharList.Add('0');
            foreach(char c in CharList)
            {
                if (c==CharMem)
                {
                    CounterMem++;
                }
                else
                {
                    if (CharMem != '0')
                    {
                        CounterMem++;
                        schmenums.Add(new schmenum(CharMem, CounterMem));
                    }
                        CharMem = c;
                        CounterMem = 0;
                }

            }



            schmenums.Sort((x, y) => derp(x, y));
            //schmenums.Sort((x,y) => x.c.CompareTo(y.c));
            //schmenums.Sort((x, y) => y.i.CompareTo(x.i));
            for (int i = 1; i <=5; i++)
            {
                ChecksumChecker = String.Concat(ChecksumChecker, schmenums[i-1].c);
            }
            if (Checksum == ChecksumChecker)
            {
                return RoomID;
            }
            else
                return 0;
        }
        public int derp(schmenum x, schmenum y)
        {
            if (x.i == y.i)
            {
                return x.c.CompareTo(y.c);


    }
            else
            {
                return y.i.CompareTo(x.i);


    }
        }
    }
}