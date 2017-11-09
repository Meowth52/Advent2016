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
                        InstructionsObjects.Add(new Instruction(Int32.Parse(Words[1]), Int32.Parse(Words[6]), Int32.Parse(Words[11])));
            }
            while (Answere < 0)
            {
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
                                break;
                            }
                            Bots[i.giveLow()].reciveValue(Bots[botIndex].giveLow());
                            Bots[i.giveHigh()].reciveValue(Bots[botIndex].giveHigh());
                        }
                    }
                }
            }
        return Answere.ToString();
        }
    }
}