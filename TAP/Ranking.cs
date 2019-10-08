﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAP
{
    public class Ranking
    {
        public Knight[] knights { get; set; }

        public Ranking(List<Knight> knights, Knight ducan)
        {
            knights.Add(ducan);
            this.knights = knights.ToArray();
        }       

        // Pode melhorar!
        public int DucanPosition(Knight ducan, int begin, int end)
        {
            int middle = (begin + end) / 2;
            if (begin >= end)
            {
                if(knights[middle].id == -1)
                {
                    return middle + 1;
                }
                else
                {
                    return -1;
                }
            }
            if(knights[middle].score < ducan.score)
            {
                //Procura o ducan na esquerda
                return DucanPosition(ducan, begin, middle - 1);
            }
            else if (knights[middle].score > ducan.score)
            {
                //procura o ducan na direita
                return DucanPosition(ducan, middle + 1, end);
            }
            else
            {
                if(knights[middle].id == -1)
                {
                    return middle + 1;
                }
                else if (!knights[middle].win)
                {
                    //procura o ducan na direita
                    return DucanPosition(ducan, middle + 1, end);
                }
                else
                {
                    //procura o ducan na esquerda
                    return DucanPosition(ducan, begin, middle - 1);
                }
            }
        }

        public void RefreshRanking()
        {
            this.Quicksort(0, knights.Length - 1);
        }

        /// <summary>
        /// Método que implementa o Quicksort recursivamente
        /// </summary>
        private void Quicksort(int inicio, int final)
        {
            if (inicio >= final) return;

            int pivo = Particao(inicio, final);

            Quicksort(inicio, pivo - 1);
            Quicksort(pivo + 1, final);
        }

        /// <summary>
        /// Método que implementa o Quicksort recursivamente
        /// </summary>
        private int Particao(int inicio, int final)
        {
            int i = inicio;

            for (int j = inicio; j < final; j++)
            {
                /* Elemento atual maior ao pivô? */
                if (knights[j].score >= knights[final].score)
                {
                    if (knights[j].score == knights[final].score)
                    {
                        // Se ocorreu empate, verifica se o cavaleiro é o Ducan
                        // para decidir o criterio de desempate
                        if (knights[final].id == -1)
                        {
                            if (!knights[j].win)
                            {
                                Trocar(i++, j);
                            }
                        }

                        if (knights[j].id == -1)
                        {
                            if (knights[final].win)
                            {
                                Trocar(i++, j);
                            }
                        }
                    }
                    else { Trocar(i++, j); }                    
                }
            }
            Trocar(i, final);

            return i;
        }

        /// <summary>
        /// Método para fazer a troca de dados entre duas posições no vetor
        /// </summary>
        private void Trocar(int i, int j)
        {
            Knight k = knights[i];
            knights[i] = knights[j];
            knights[j] = k;
        }
    }
}
