using System;

namespace TAP
{
    class Program
    {
        static void Main(string[] args)
        {

            //Tourney tourney_Iterative = ReadFile.tourney(@"..\..\..\Teste.txt");
            Tourney tourney_Recursive = ReadFile.tourney(@"..\..\..\Teste.txt");

            TimeSpan time;
            int effort;

            effort = tourney_Recursive.CalculateEffortRecursive(out time);
            string timeString = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

            Console.WriteLine("Resultado RECURSIVO");
            Console.WriteLine("");
            Console.WriteLine("Valor de N: " + (tourney_Recursive.Knights.Count));
            Console.WriteLine("Esforço calculado: " + effort);
            Console.WriteLine("Tempo passado: " + timeString);

            //Console.WriteLine("");
            //Console.WriteLine("=========================================");
            //Console.WriteLine("");

            //effort = tourney_Iterative.CalculateEffortIterative();

            //Console.WriteLine("Resultado INTERATIVO");
            //Console.WriteLine("");
            //Console.WriteLine("Valor de N: " + (tourney_Iterative.Knights.Count));
            //Console.WriteLine("Esforço calculado: " + effort);



            Console.ReadKey();
        }

    }

}
