using System;
using System.Collections.Generic;
using System.Text;

namespace TAP
{
    class Knight
    {
        public int score { get; private set; }
        public int effort { get; private set; }

        public Knight(int score, int effort)
        {
            this.score = score;
            this.effort = effort;
        }
    }
}
