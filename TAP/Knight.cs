using System;
using System.Collections.Generic;
using System.Text;

namespace TAP
{
    public class Knight
    {
        public int id { get; private set; }
        public int score { get; private set; }
        public int effort { get; private set; }

        public Knight(int id, int score, int effort)
        {
            this.id = id;
            this.score = score;
            this.effort = effort;
        }

        public override string ToString()
        {
            return "{\"Knight\": { \"id\":" + this.id + ", \"score\":" + this.score + ", \"idade\": " + this.effort + "}}";
        }
    }
}
