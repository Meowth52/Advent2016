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
            int id = 0;
            string DecryptMatch = "northpole";
            string Resultat2 = "";
            foreach (Room r in Rooms)
            {
                id=r.getIDifOK();
                Resultat = Resultat + id; r.getIDifOK();
                Resultat2 = String.Concat(Resultat2, r.getDecryptMatch(DecryptMatch));
            }

            return "Del 1 blir: " + Resultat.ToString() + " del 2 blir: " + Resultat2;
        }
    }
}