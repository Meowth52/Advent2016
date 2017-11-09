using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    class Instruction
    {
        int bot;
        int low;
        int high;
        bool active = true;
        public Instruction(int _bot, int _low, int _high)
        {
            bot = _bot;
            low = _low;
            high = _high;
        }
        public int giveBot()
        {
            return bot;
        }
        public int giveLow()
        {
            return low;
        }
        public int giveHigh()
        {
            active = false;
            return high;
        }
        public bool isActive()
        {
            return active;
        }
            
    }
}
