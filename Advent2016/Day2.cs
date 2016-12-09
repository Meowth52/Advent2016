using System;

namespace Advent2016
{
    internal class Day2
    {
        private string Input;
        private string[] Instructions;
        private Button[] Codepad=new Button[10];
        private Button[] Codepad2 = new Button[14];

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

            Codepad2[1] = new Button(1, 1, 1, 3, 1);
            Codepad2[2] = new Button(2, 2, 3, 6, 2);
            Codepad2[3] = new Button(3, 1, 4, 7, 2);
            Codepad2[4] = new Button(4, 4, 4, 8, 3);
            Codepad2[5] = new Button(5, 5, 6, 5, 5);
            Codepad2[6] = new Button(6, 2, 7, 10, 5);
            Codepad2[7] = new Button(7, 3, 8, 11, 6);
            Codepad2[8] = new Button(8, 4, 9, 12, 8);
            Codepad2[9] = new Button(9, 9, 9, 9, 8);
            Codepad2[10] = new Button(10, 6, 11, 10, 10);
            Codepad2[11] = new Button(11, 7, 12, 13, 10);
            Codepad2[12] = new Button(12, 8, 12, 12, 11);
            Codepad2[13] = new Button(13, 11, 13, 13, 13);
        }

        internal string Result()
        {
            string resultat="";
            string resultat2 = "";
            int n = 5;
            foreach (string s in Instructions)
            {
                if (s == "")
                    break;
                foreach (char c in s)
                {
                    n = Codepad[n].move(c);
                }
                resultat = string.Concat(resultat, n.ToString("X"));
            }

            n = 5;
            foreach (string s in Instructions)
            {
                if (s == "")
                    break;
                foreach (char c in s)
                {
                    n = Codepad2[n].move(c);
                }
                resultat2 = string.Concat(resultat2, n.ToString("X"));
            }
            return "Dag 2, koden är: " + resultat + " och för del 2: " + resultat2;
        }
    }
}