using System;
using System.Collections.Generic;

namespace Advent2016
{
    internal class Day4
    {

        private string Input;
        private string[] Instructions;
        private List<Room> Rooms = new List<Room>();

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
            foreach (Room r in Rooms)
            {
                Resultat = Resultat + r.getIDifOK();
            }
            return Resultat.ToString();
        }
    }
}