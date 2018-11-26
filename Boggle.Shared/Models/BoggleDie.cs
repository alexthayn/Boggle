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

        public string RollDie()
        {
            Random r = new Random(System.DateTime.Now.Millisecond);

            //Simulate rolling the die
            switch (r.Next(1, 6))
            {
                case 1: return One;
                case 2: return Two;
                case 3: return Three;
                case 4: return Four;
                case 5: return Five;
                case 6: return Six;
                default: throw new ArgumentOutOfRangeException("Invalid die roll.");
            }
        }
    }
}
