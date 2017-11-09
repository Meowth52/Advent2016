using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Advent2016
{
    internal class Day10
    {
        private string Input;
        private string[] Instructions;
        private List<Instruction> InstructionsObjects = new List<Instruction>();
        public Dictionary<int, Bot> Bots = new Dictionary<int, Bot>();
        int Answere = -1;
        int Answere2;
        public Dictionary<int, int> Outputs = new Dictionary<int, int>();
        
        public Day10(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        internal string Result()
        {
            foreach (string s in Instructions)
            {
                string[] Words;
                Words = s.Split(' ');
                if (Words.FirstOrDefault() == "bot")
                {
                    Bots.Add(Int32.Parse(Words[1]), new Bot());
                }
            }
            foreach (string s in Instructions)
            {
                string[] Words;
                Words = s.Split(' ');
                if (Words.FirstOrDefault() == "value")
                {
                    Bots[Int32.Parse(Words[5])].reciveValue(Int32.Parse(Words[1]));
                }
                else
                    if (s != "")
                        InstructionsObjects.Add(new Instruction(s));
            }
            bool whileThis = true;
            while (whileThis)
            {
                whileThis = false;
                foreach (Instruction i in InstructionsObjects)
                {
                    if (i.isActive())
                    {
                        int botIndex = i.giveBot();
                        if (Bots[botIndex].wannaDance(i))
                        {
                            if (Bots[botIndex].isThisIt())
                            {
                                Answere = botIndex;
                            }
                            if (i.isLowBot())
                                Bots[i.giveLow()].reciveValue(Bots[botIndex].giveLow());
                            else
                                Outputs[i.giveLow()] = Bots[botIndex].giveLow();
                            if (i.isHighBot())
                                Bots[i.giveHigh()].reciveValue(Bots[botIndex].giveHigh());
                            else
                                Outputs[i.giveHigh()] = Bots[botIndex].giveHigh(); ;
                        }
                        else
                            whileThis = true;
                    }
                }
            }
            Answere2 = Outputs[0] * Outputs[1] * Outputs[2];
        return Answere.ToString() + " och " + Answere2.ToString();
        }
    }
}