using System;
using System.Security.Cryptography;
using System.Text;

namespace Advent2016
{
    internal class Day5
    {
        private string Input;

        public Day5(string input)
        {
            Input = input.Replace("\r\n", "");
        }
        //Del 1
        //internal string Result()
        //{

        //    string testData = Input;
        //    int i = 0;
        //    byte[] byteData;
        //    StringBuilder Resultat = new StringBuilder();

        //    MD5 hashis = MD5.Create();
        //    while (true)
        //    {
        //        bool pling = true;
        //        testData = Input + i.ToString();
        //        byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(testData));
        //        pling = ((byteData[0] == 0) && (byteData[1] == 0) && (byteData[2] <= 15));
        //        if (pling)
        //        {
        //            StringBuilder sBuilder = new StringBuilder();
        //            sBuilder.Append(byteData[2].ToString("x2"));
        //            Resultat = Resultat.Append( sBuilder[1].ToString());
        //        }
        //        if (Resultat.Length >= 8)
        //            return Resultat.ToString();
        //        i++;
        //    }
        //    throw new NotImplementedException();
        //Del 2
        internal string Result()
        {

            string testData = Input;
            int i = 0;
            byte[] byteData;
            StringBuilder Resultat = new StringBuilder("________");

            MD5 hashis = MD5.Create();
            while (true)
            {
                bool pling = true;
                testData = Input + i.ToString();
                byteData = hashis.ComputeHash(Encoding.UTF8.GetBytes(testData));
                pling = ((byteData[0] == 0) && (byteData[1] == 0) && (byteData[2] <= 15));
                if ((byteData[2] <= 7))
                {
                    if (pling && Resultat[byteData[2]] == '_')
                    {
                        StringBuilder sBuilder = new StringBuilder();
                        sBuilder.Append((byteData[3]/16).ToString("x2"));
                        Resultat[byteData[2]] = ((char)sBuilder[1]);
                    }
                }
                bool plong = true;
                for (int x = 0; x <= 7; x++)
                    if (Resultat[x] == '_')
                        plong = false;
                if (plong)
                    return Resultat.ToString();
                i++;
            }
            throw new NotImplementedException();
        }
    }
}