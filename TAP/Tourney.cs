using System;
using System.Collections.Generic;
using System.Text;

namespace TAP
{
    public class Tourney
    {
        public List<Knight> knights { get; private set; }
        public int desiredPlacing { get; private set; }

        public Tourney(List<Knight> knights, int desiredPlacing)
        {
            this.knights = knights;
            this.desiredPlacing = desiredPlacing;
        }

        public int CalculateEffortRecursive()
        {
            return 0;
        }

        public int CalculateEffortIterative()
        {
            return 0;
        }
    }
}
