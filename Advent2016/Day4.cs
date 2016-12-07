using System;
using System.Collections.Generic;

namespace Advent2016
{
    internal class Day4
    {

        private string Input;
        private string[] Instructions;
        private List<Room> Rooms = new List<Room>();
        public List<int> fuu = new List<int>();

        public Day4(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
            foreach (string s in Instructions)
                if (s!="")
                    Rooms.Add(new Room(s));
        }

        internal string Result()
        {
            int Resultat = 0;
            int id = 0;
            //string bajs = "";
            foreach (Room r in Rooms)
            {
                id=r.getIDifOK();
                fuu.Add(id);
                Resultat = Resultat + id; r.getIDifOK();
            }
            //foreach(int i in fuu)
            //{
            //    bajs = String.Concat(bajs, i.ToString(),'\n');
            //}
            //return bajs;
            return Resultat.ToString();
        }
    }
}