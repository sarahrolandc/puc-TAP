using System;

namespace TAP
{
    class Program
    {

        static int optionToN(int option)
        {
            if (option <= 2)
                return option == 1 ? 2 : 5;
            else if (option < 13)
            {
                switch (option)
                {
                    case 3: return 10; break;
                    case 4: return 20; break;
                    case 5: return 30; break;
                    case 6: return 40; break;
                    case 7: return 50; break;
                    case 8: return 60; break;
                    case 9: return 70; break;
                    case 10: return 80; break;
                    case 11: return 90; break;
                    default:
                        return 100;
                }
            }
            else
                if (option == 13)
                return 1000;
            else
                return option == 14 ? 10000 : 100000;
        }

        static string OptionMethodToStr(int option)
        {
            return option == 1 ? "RECURSIVO" : "INTERATIVO";
        }

        static void menu(int option_N, int method)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("=====      Trabalho Prático - Torneio de Vaufreixo       =====");
            Console.WriteLine("==============================================================");

            if ((option_N > 0) && (method > 0))
            {
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Aquivo de entrada tamanho N: " + optionToN(option_N));
                Console.WriteLine("Método: " + OptionMethodToStr(method));
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }

        static int SubMenu_SelectFile()
        {
            int number = 0;
            bool success = false;

            menu(0, 0);

            Console.WriteLine("Ecolha uma opção de arquivo de entrada:");
            Console.WriteLine("");

            Console.WriteLine("[1] - Arquivo N = 2");
            Console.WriteLine("[2] - Arquivo N = 5");

            for (int i = 1; i <= 10; i++)
                Console.WriteLine("[" + (i + 2) + "] - Arquivo N = " + i * 10);

            Console.WriteLine("[13] - Arquivo N = 1.000");
            Console.WriteLine("[14] - Arquivo N = 10.000");
            Console.WriteLine("[15] - Arquivo N = 100.000");

            Console.WriteLine("");
            Console.Write("Opção: ");

            while (!success)
            {
                Console.Write("Opção: ");
                success = Int32.TryParse(Console.ReadLine(), out number);

                if (success)
                   success = ((number > 0) && (number < 16));
            }

            Console.Clear();

            return number;
        }

        static int SubMenu_SelectMethod()
        {
            menu(0, 0);

            int number = 0;
            bool success = false;

            Console.WriteLine("Ecolha uma método para executar:");
            Console.WriteLine("");

            Console.WriteLine("[1] - Método RECURSIVO");
            Console.WriteLine("[2] - Método INTERATIVO");

            Console.WriteLine("");

            while (!success)
            {
                Console.Write("Opção: ");
                success = Int32.TryParse(Console.ReadLine(), out number);

                if (success)
                    success = ((number > 0) && (number < 3));
            }

            Console.Clear();

            return number;
        }

        static string returnNameFile(int option)
        {
            if (option <= 2)
                return option == 1 ? "N 2.txt" : "N 5.txt";
            else if (option < 13)
            {
                switch (option)
                {
                    case  3: return "N 10.txt"; break;
                    case  4: return "N 20.txt"; break;
                    case  5: return "N 30.txt"; break;
                    case  6: return "N 40.txt"; break;
                    case  7: return "N 50.txt"; break;
                    case  8: return "N 60.txt"; break;
                    case  9: return "N 70.txt"; break;
                    case 10: return "N 80.txt"; break;
                    case 11: return "N 90.txt"; break;
                    default:
                        return "N 100.txt";
                }
            }
            else
                if (option == 13)
                return "N 1000.txt";
            else
                return option == 14 ? "N 10000.txt" : "N 100000.txt";
        }

        static void Main(string[] args)
        {
            TimeSpan time;
            string timeString;
            int effort;

            int TypeFile = SubMenu_SelectFile();
            int TypeMethod = SubMenu_SelectMethod();

            menu(TypeFile, TypeMethod);

            string file = returnNameFile(TypeFile);
            Tourney tourney = ReadFile.tourney(@"..\..\..\" + file);

            if (TypeMethod == 1)
                effort = tourney.CalculateEffortRecursive(out time);
            else
                effort = tourney.CalculateEffortIterative(out time);

            timeString = String.Format("{0:00}:{1:00}:{2:00}.{3:00000}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

            Console.WriteLine("Esforço calculado: " + effort);
            //Console.WriteLine("Tempo de execução: " + timeString);

            Console.ReadKey();
        }

    }

}
