using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace TAP
{
    public class Tourney
    {
        private List<Knight> knights;
        private int desiredPlacing;
        
        public int DesiredPlacing { get => desiredPlacing; set => desiredPlacing = value; }
        public List<Knight> Knights { get => knights; set => knights = value; }

        public Tourney(List<Knight> knights, int desiredPlacing)
        {
            this.knights = knights;
            this.desiredPlacing = desiredPlacing;

            this.RefreshRanking();
        }

        public Tourney()
        {
            this.knights = new List<Knight>();
            this.desiredPlacing = 0;
        }

        // METODO RECURSIVO
        private int fight(Knight opponent)
        {
            return opponent.effort;
        }

        public int CalculateEffortRecursive(out TimeSpan time)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // início método
            int effort = 0;
            List<Knight> opponents = new List<Knight>();

            // dando retorno

            sw.Stop();
            time = sw.Elapsed;

            return effort;
        }

        // METODO INTERATIVO
        public int CalculateEffortIterative()
        {
            return 0;
        }

        // Métodos diversos
        private void RefreshRanking()
        {
            if (this.knights.Count == 0)
                return;

            this.Knights.Sort((x, y) => -1 * x.score.CompareTo(y.score));
        }

        public override string ToString()
        {
            string result = "";

            if (this.knights.Count == 0)
                return "";

            foreach (Knight k in this.knights)
                result += k.score + " " + k.effort + "\r\n"; 

            return result;
        }


    }
}
