using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    class Component
    {
        public string Type { get; set; }
        public string Element { get; set; }
        public Component(string type, string element)
        {
            Type = type;
            Element = element;
        }
    }
}
