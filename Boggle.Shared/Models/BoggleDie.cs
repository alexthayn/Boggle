using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Models
{
    public class BoggleDie
    {
        //Six sides of the die
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }

        public BoggleDie(string one, string two, string three, string four, string five, string six)
        {
            One = one;
            Two = two;
            Three = three;
            Four = four;
            Five = five;
            Six = six;
        }
    }
}
