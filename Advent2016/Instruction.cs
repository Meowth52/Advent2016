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
        bool lowIsBot;
        int high;
        bool highIsBot;
        bool active = true;
        public Instruction(string s)
        {
            string[] Words;
            Words = s.Split(' ');
            //    Int32.Parse(Words[1]), Int32.Parse(Words[6]), Int32.Parse(Words[11])
            bot = Int32.Parse(Words[1]);
            low = Int32.Parse(Words[6]);
            lowIsBot = Words[5] == "bot";
            high = Int32.Parse(Words[11]);
            highIsBot = Words[10] == "bot";
        }
        public int giveBot()
        {
            return bot;
        }
        public bool isLowBot()
        {
            return lowIsBot;
        }
        public bool isHighBot()
        {
            return highIsBot;
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
