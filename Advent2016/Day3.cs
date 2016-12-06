using System;
using System.Collections.Generic;

namespace Advent2016
{
    internal class Day3
    {
        private string Input;
        private List<Triangle> Triangles = new List<Triangle>();
        private List<Triangle> Triangles2 = new List<Triangle>();
        private string[] Instructions;
        private string[] Instructions2;
        private List<int> sides = new List<int>();

        public Day3(string input)
        {
            Input = input.Replace("\r\n  ", "_");
            Instructions = Input.Split('_');
            Input = Input.Replace("_", " ");
            Instructions2 = Input.Split(' ');
            foreach(string s in Instructions2)
            {
                if (s != "")
                    sides.Add(Convert.ToInt32(s));
            }
            int[,] TriangleSet = new int[4, 4];
            int countColumn = 1;
            int countRow = 1;
            foreach (int i in sides)
            { 
                TriangleSet[countColumn, countRow]=i;
                countColumn++;
                if (countColumn > 3)
                {
                    countColumn = 1;
                    countRow++;
                    if (countRow>3)
                    {
                        countRow = 1;
                        Triangles2.Add(new Triangle(TriangleSet[1, 1], TriangleSet[1, 2], TriangleSet[1, 3]));
                        Triangles2.Add(new Triangle(TriangleSet[2, 1], TriangleSet[2, 2], TriangleSet[2, 3]));
                        Triangles2.Add(new Triangle(TriangleSet[3, 1], TriangleSet[3, 2], TriangleSet[3, 3]));
                    }
                }
                                
            }
        }

        internal string Result()
        {
            int Resultat= 0;
            int Resultat2 = 0;
            foreach(string s in Instructions)
            {
                Triangles.Add(new Triangle(s));
            }
            foreach (Triangle t in Triangles)
                if (t.isTriangle())
                    Resultat++;
            foreach (Triangle t in Triangles2)
                if (t.isTriangle())
                    Resultat2++;
            return "Dag 3 del 1 har " + Resultat.ToString() + " trianglar och del 2 har " + Resultat2.ToString() + "st";
        }
    }
}