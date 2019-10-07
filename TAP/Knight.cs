using System;
using System.Collections.Generic;
using System.Text;

namespace TAP
{
    public class Knight : IComparable
    {
        public int id { get; private set; }
        public int score { get; set; }
        public int effort { get; private set; }

        public bool win { get; set; }

        public Knight(int id, int score, int effort)
        {
            this.id = id;
            this.score = score;
            this.effort = effort;
            this.win = true;
        }

        public override string ToString()
        {
            return "{\"Knight\": { \"id\":" + this.id + ", \"score\":" + this.score + ", \"effort\": " + this.effort + "}}";
        }

        public int CompareTo(Object obj)
        {
            Knight knight = (Knight)obj;

            if (knight.effort < this.effort)
            {
                return -1;
            }
            else if (knight.effort > this.effort)
            {
                return 1;
            }

            // Segunda ordenação por pontuação, quando o esforço for igual            
            if (knight.score > this.score)
            {
                return -1;
            }
            else
            {
                return 1;
            }            
        }
    }
}
