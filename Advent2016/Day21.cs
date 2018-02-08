using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Advent2016
{
    class Day21
    {
        private string Input;
        private string[] RawInstructions;
        private List<string[]> Instructions = new List<string[]>();
        Stopwatch stopWatch = new Stopwatch();
        public Day21(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            RawInstructions = Input.Split('_');
            foreach (string s in RawInstructions)
            {
                if (s != "")
                {
                    Instructions.Add(s.Split(' '));
                }
            }
        }

        public string Result()
        {
            string Sum = "";
            string Sum2 = "";
            string Keyword = "";
            string PasswordInput = "abcdefgh";
            List<char> Password = new List<char>();
            foreach(char c in PasswordInput)
            {
                Password.Add(c);
            }
            int X = 0;
            int Y = 0;
            char BufferChar = ' ';
            foreach (string[] s in Instructions)
            {
                Keyword = s[0] + s[1];
                switch (Keyword)
                {
                    case "swapposition":
                        Int32.TryParse(s[2], out X);
                        Int32.TryParse(s[5], out Y);
                        BufferChar = Password[X];
                        Password[X] = Password[Y];
                        Password[Y] = BufferChar;
                        break;
                    case "swapletter":
                        X = Password.IndexOf(s[2][0]);
                        Y = Password.IndexOf(s[5][0]);
                        Password[X] = s[5][0];
                        Password[Y] = s[2][0];
                        break;
                    case "rotateleft":
                        Int32.TryParse(s[2], out X);
                        for (int i = 0; i < X; i++)
                        {
                            Password.Add(Password[0]);
                            Password.RemoveAt(0);
                        }
                        break;
                    case "rotateright":
                        Int32.TryParse(s[2], out X);
                        for (int i = 0; i < X; i++)
                        {
                            Password.Insert(0, Password[Password.Count-1]);
                            Password.RemoveAt(Password.Count-1);
                        }
                        break;
                    case "rotatebased":
                        X = Password.IndexOf(s[6][0]);
                        if (X >= 4)
                            X++;
                        X++;
                        for (int i = 0; i < X; i++)
                        {
                            Password.Insert(0, Password[Password.Count - 1]);
                            Password.RemoveAt(Password.Count - 1);
                        }
                        break;
                    case "reversepositions":
                        Int32.TryParse(s[2], out X);
                        Int32.TryParse(s[4], out Y);
                        List<char> Reversed = new List<char>(Password.GetRange(X, Y - X+1));
                        Password.RemoveRange(X, Y - X+1);
                        Reversed.Reverse();
                        Password.InsertRange(X, Reversed);
                        break;
                    case "moveposition":
                        Int32.TryParse(s[2], out X);
                        Int32.TryParse(s[5], out Y);
                        BufferChar = Password[X];
                        Password.RemoveAt(X);
                        Password.Insert(Y, BufferChar);
                        break;
                    default:
                        ;
                        break;
                }
            }
            foreach(char c in Password)
            {
                Sum += c;
            }
            //del 2
            Instructions.Reverse();
            PasswordInput = "fbgdceah";
            Password.Clear();
            foreach (char c in PasswordInput)
            {
                Password.Add(c);
            }
            foreach (string[] s in Instructions)
            {
                Keyword = s[0] + s[1];
                switch (Keyword)
                {
                    case "swapposition":
                        Int32.TryParse(s[2], out X);
                        Int32.TryParse(s[5], out Y);
                        BufferChar = Password[X];
                        Password[X] = Password[Y];
                        Password[Y] = BufferChar;
                        break;
                    case "swapletter":
                        X = Password.IndexOf(s[2][0]);
                        Y = Password.IndexOf(s[5][0]);
                        Password[X] = s[5][0];
                        Password[Y] = s[2][0];
                        break;
                    case "rotateleft":
                        Int32.TryParse(s[2], out X);
                        for (int i = 0; i < X; i++)
                        {
                            Password.Add(Password[0]);
                            Password.RemoveAt(0);
                        }
                        break;
                    case "rotateright":
                        Int32.TryParse(s[2], out X);
                        for (int i = 0; i < X; i++)
                        {
                            Password.Insert(0, Password[Password.Count - 1]);
                            Password.RemoveAt(Password.Count - 1);
                        }
                        break;
                    case "rotatebased":
                        X = Password.IndexOf(s[6][0]);
                        if (X >= 4)
                            X++;
                        X++;
                        for (int i = 0; i < X; i++)
                        {
                            Password.Insert(0, Password[Password.Count - 1]);
                            Password.RemoveAt(Password.Count - 1);
                        }
                        break;
                    case "reversepositions":
                        Int32.TryParse(s[2], out X);
                        Int32.TryParse(s[4], out Y);
                        List<char> Reversed = new List<char>(Password.GetRange(X, Y - X + 1));
                        Password.RemoveRange(X, Y - X + 1);
                        Reversed.Reverse();
                        Password.InsertRange(X, Reversed);
                        break;
                    case "moveposition":
                        Int32.TryParse(s[2], out X);
                        Int32.TryParse(s[5], out Y);
                        BufferChar = Password[X];
                        Password.RemoveAt(X);
                        Password.Insert(Y, BufferChar);
                        break;
                    default:
                        ;
                        break;
                }
            }
            foreach (char c in Password)
            {
                Sum2 += c;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum + " och del 2: " + Sum2 + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
}