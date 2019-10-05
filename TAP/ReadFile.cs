using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAP
{
    public static class ReadFile
    {
        public static Tourney tourney(String fileName)
        {
            String s;
            String[] aux;
            StreamReader inputFile;
            List<Knight> knights = new List<Knight>();

            try
            {
                inputFile = new StreamReader(fileName);
                s = inputFile.ReadLine();
                aux = s.Split(' ');

                int numberKnights = int.Parse(aux[0]);
                int desiredPlacing = int.Parse(aux[1]);

                for (int i = 0; i < numberKnights; i++)
                {
                    s = inputFile.ReadLine();
                    aux = s.Split(' ');

                    Knight knight = new Knight(int.Parse(aux[0]), int.Parse(aux[1]));
                    knights.Add(knight);
                }

                return new Tourney(knights, desiredPlacing);
            }

            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
    }
}