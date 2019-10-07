using System;
using System.Collections.Generic;
using System.Text;

namespace TAP
{
    public class Ranking
    {
        public Knight[] knights { get; set; }

        public Ranking(List<Knight> knights)
        {
            this.knights = knights.ToArray();
        }

        public void RefreshRanking()
        {
            QuickSort q = new QuickSort(knights);
            knights = q.knights;
        }

        public int DucanPosition()
        {
            for(int i = 0; i < knights.Length; i++)
            {
                if (knights[i].id == -1)
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}
