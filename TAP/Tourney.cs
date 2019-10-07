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
        private Knight ducan;
        
        public int DesiredPlacing { get => desiredPlacing; set => desiredPlacing = value; }
        public List<Knight> Knights { get => knights; set => knights = value; }
        public Knight Ducan { get => ducan; set => ducan = value; }
        public Ranking Ranking { get; set; }

        public Tourney(List<Knight> knights, int desiredPlacing)
        {
            this.knights = knights;
            this.desiredPlacing = desiredPlacing;
            this.ducan = new Knight(-1, knights.Count, 0);

            List<Knight> knightsRanking = knights;
            knightsRanking.Add(ducan);
            this.Ranking = new Ranking(knightsRanking);

            //ordena os cavaleiros por ordem descrescente de esforço
            this.knights.Sort();               
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
            int effort = 0;

            // Percore todos os cavaleiros, que estão ordenados em ordem descresente por esforço
            // verificando quais lutas Ducan pode perder e continuar entre as posições desejadas
            foreach(Knight knight in knights)
            {
                CheckIfCanLose(knight);

                // Soma os esforços da luta que Ducan ganhou
                if (knight.win)
                {
                    effort += knight.effort;
                }                
            }           
            
            return effort;
        }

        private void CheckIfCanLose(Knight knight)
        {
            knight.win = false;
            knight.score++;
            ducan.score--;

            // Se a posição do Ducan perdendo a luta for maior que a desejada, 
            // significa que ele nao pode perder essa luta
            if (DucanPosition() > this.desiredPlacing)
            {
                knight.win = true;
                knight.score--;
                ducan.score++;
            }
        }

        //Implementar
        private int DucanPosition()
        {
            this.Ranking.RefreshRanking();
            return this.Ranking.DucanPosition();
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
