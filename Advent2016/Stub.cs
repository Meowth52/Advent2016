using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    class Stub
    {
        private string Input;
        private string[] Instructions;
        private List<Room> Triangles = new List<Room>();

        public Stub(string input)
        {
            Input = input.Replace("\r\n  ", "_");
            Instructions = Input.Split('_');
        }

        internal string Result()
        {
            throw new NotImplementedException();
        }
    }
}
