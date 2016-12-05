using System;

namespace Advent2016
{
    internal class Day2
    {
        private string Input;
        private string[] Instructions;
        private string TheCode;
        private Button[] Codepad=new Button[10];

        public Day2(string input)
        {
            this.Input = input;
            Input = Input.Replace("\n", "");
            Instructions = Input.Split('\r');
            Codepad[1] = new Button(1, 1, 2, 4, 1);
            Codepad[2] = new Button(2, 2, 3, 5, 1);
            Codepad[3] = new Button(3, 3, 3, 6, 2);
            Codepad[4] = new Button(4, 1, 5, 7, 4);
            Codepad[5] = new Button(5, 2, 6, 8, 4);
            Codepad[6] = new Button(6, 3, 6, 9, 5);
            Codepad[7] = new Button(7, 4, 8, 7, 7);
            Codepad[8] = new Button(8, 5, 9, 8, 7);
            Codepad[9] = new Button(9, 6, 9, 9, 8);
        }

        internal string Result()
        {
            string resultat="";
            int n = 5;
            foreach (string s in Instructions)
            {
                if (s == "")
                    break;
                foreach (char c in s)
                {
                    n = Codepad[n].move(c);
                }
                resultat = string.Concat(resultat, n.ToString());
            }
            return "Dag 2, koden är: " + resultat;
        }
    }
}