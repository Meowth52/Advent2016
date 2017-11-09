using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    class Bot
    {
        int chip1 = -1;
        int chip2 = -1;
        int Low;
        int High;

        public Bot()
        {
        }
        public void reciveValue(int i)
        {
            if (chip1 == -1)
                chip1 = i;
            else
                chip2 = i;
        }
        public bool wannaDance(Instruction i)
        {
            if (chip1 >= 0 && chip2 >= 0)
            {
                if (chip1 < chip2)
                {
                    Low = chip1;
                    High = chip2;
                }
                else
                {
                    Low = chip2;
                    High = chip1;
                }
                return true;
            }
            else
                return false;
        }
        public int giveLow()
        {
            return Low;
        }
        public int giveHigh()
        {
            return High;
        }
        public bool isThisIt()
        {
            return (Low == 17 && High == 61);
        }


    }
}
