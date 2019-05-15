using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace projekt2
{
    class Program
    {
        public static uint counter;


        public static bool IsPrime(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    if (Num % u == 0) return false;
                }
            return true;
        }

        public static bool IsPrimeOperations(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                {

                    if (Num % u == 0) return false;
                    counter++;
                }
            return true;
        }

        public static bool IsPrime2(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u * u <= Num / 2; u += 2)
                {
                    if (Num % u == 0) return false;
                }
            return true;
        }

        public static bool IsPrimeOperations2(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u * u <= Num / 2; u += 2)
                {

                    if (Num % u == 0) return false;
                    counter++;
                }
            return true;
        }


        static void Main(string[] args)
        {
            BigInteger[] tab = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

            for (int i = 0; i < 7; i++)
            {
                long start = Stopwatch.GetTimestamp();
                bool czyPierwsza = IsPrime(tab[i]);
                long stop = Stopwatch.GetTimestamp();

                Console.WriteLine(czyPierwsza + ";" + (stop - start) + ";" + "t1");
                Console.WriteLine(IsPrimeOperations(tab[i]) + ";" + counter + ";" + "o1");

                start = Stopwatch.GetTimestamp();
                bool czyPierwsza2 = IsPrime2(tab[i]);
                stop = Stopwatch.GetTimestamp();

                Console.WriteLine(czyPierwsza2 + ";" + (stop - start) + ";" + "t2");
                Console.WriteLine(IsPrimeOperations2(tab[i]) + ";" + counter + ";" + "o2");

            }

            Console.ReadKey();
        }
    }
}
