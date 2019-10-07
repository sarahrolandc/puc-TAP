using System;

namespace TAP
{
    class Program
    {
        static void Main(string[] args)
        {

            Tourney tourney = ReadFile.tourney(@"..\..\..\Teste.txt");

            TimeSpan time;
            int effort = tourney.CalculateEffortIterative();

            //int effort = tourney.CalculateEffortRecursive(out time);
            //string timeString = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

            Console.WriteLine("Resultado RECURSIVO");
            Console.WriteLine("");
            Console.WriteLine("Valor de N: " + tourney.Knights.Count);
            Console.WriteLine("Esforço calculado: " + effort);
            //Console.WriteLine("Tempo passado: " + timeString);

            Console.WriteLine("");
            Console.WriteLine("=========================================");
            Console.WriteLine("");

            Console.ReadKey();


            Console.ReadKey();
        }

    }

}
