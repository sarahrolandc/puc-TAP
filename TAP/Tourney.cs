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
            // Adiciona Ducan no Ranking, inicialmente considerando que ele ganhou todas as lutas    
            this.ducan = new Knight(-1, knights.Count, 0);        
            this.Ranking = new Ranking(knights, this.ducan);            

            //ordena os cavaleiros por ordem descrescente de esforço
            this.knights.Sort();               
        }

        public Tourney()
        {
            this.knights = new List<Knight>();
            this.desiredPlacing = 0;
        }

        // METODO RECURSIVO
        private int fight(int opponent, int acumulate)
        {

            if (opponent <= this.Knights.Count - 1)
            {
                CheckIfCanLose(this.Knights[opponent]);

                if (this.Knights[opponent].win)
                {
                    acumulate += fight(opponent + 1, this.Knights[opponent].effort);
                }
                else
                {
                    acumulate += fight(opponent + 1, 0);
                }

            }

            return acumulate;
        }

        public int CalculateEffortRecursive(out TimeSpan time)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (!CheckIfItsPossible())
            {
                sw.Stop();
                time = sw.Elapsed;

                return -1;
            }

            // início método
            int effort = fight(0, 0);

            sw.Stop();
            time = sw.Elapsed;

            return effort;
        }

        // METODO INTERATIVO
        public int CalculateEffortIterative()
        {
            if (!CheckIfItsPossible()) 
            {
                return -1;
            }

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

        private bool CheckIfItsPossible()
        {
            // Inicialmente Ducan está com o máximo de pontos possíveis
            // Retorna false se com o máximo de pontos não é possível chegar entre os lugares desejados
            if (DucanPosition() > this.desiredPlacing) {
                return false;
            }

            return true;
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

        // Retorna em qual posição do Torneio Ducan está
        private int DucanPosition()
        {
            Ranking.RefreshRanking();
            return this.Ranking.DucanPosition(ducan, 0, Knights.Count - 1);
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
