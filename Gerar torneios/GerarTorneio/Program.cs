using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GerarTorneio
{
    class Program
    {

        static void menu()
        {
            Console.Clear();

            Console.WriteLine("===============================================================");
            Console.WriteLine("=====   Trabalho Prático - CRIAR Torneios de Vaufreixo    =====");
            Console.WriteLine("===============================================================");

            Console.WriteLine("");
            Console.WriteLine("");
        }

        static bool CreateTourney(int fighters, int winners, out string fileName)
        {
            fileName = "N " + fighters + ".txt";

            int score = 0;
            int effort = 0;
            int currentTopLineCursor = Console.CursorTop;
            int currentLeftLineCursor = Console.CursorLeft;

            Random randNum = new Random();
            StreamWriter swriter = new StreamWriter(@fileName);


            try
            {
                swriter.WriteLine(fighters + " " + winners);

                for (int i = 1; i <= fighters; i++)
                {
                    score = randNum.Next(fighters - 1);        // Como cada guerreiro já lutou 1 vez com todos no torneio, sua pontuação pode ser no máximo N - 1
                    effort = randNum.Next(10);                 // Esforço para ganhar deste jogador é um valor randômico de 0 a 10.

                    swriter.WriteLine(score + " " + effort);

                    Console.SetCursorPosition(currentLeftLineCursor, currentTopLineCursor);
                    Console.WriteLine(((i * 100) / fighters) + "%)");
                }

                swriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        static void Main(string[] args)
        {
            int number = 0;
            bool success = false;

            int fighters = 0;
            int winners = 0;

            string file = "";

            while (!success)
            {
                menu();
                Console.Write("Quantos participantes: ");
                success = Int32.TryParse(Console.ReadLine(), out number);

                if (success)
                    success = (number > 0);
            }

            fighters = number;

            success = false;
            while (!success)
            {
                menu();
                Console.WriteLine("Quantos participantes: " + fighters);
                Console.Write("Quantos vencedores: ");
                success = Int32.TryParse(Console.ReadLine(), out number);

                if (success)
                    success = ((number > 0) && (number < fighters));
            }

            winners = number;

            menu();
            Console.WriteLine("Quantos participantes: " + fighters);
            Console.WriteLine("Quantos vencedores: " + winners);

            Console.WriteLine("");
            Console.Write("Gerando torneio. Aguarde... (");

            success = CreateTourney(fighters, winners, out file);

            if (success)
                Console.WriteLine("Arquivo \"" + file + "\" gerado com sucesso.");
            else
                Console.WriteLine("Falha ao criar arquivo \"" + file + "\". Verifique!");

            Console.ReadKey();
        }
    }
}
