using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace wyszukiwanie
{
    class Program
    {
        public static int counter;
        public static int counterB;

        public static int SimpleSearch(int[] tab, int a) // wyszukiwanie liniowe czasowe
        {
            for (int i = 0; i < tab.Length; i++)
                if (tab[i] == a) return i;
            return -1;
        }

        public static int SimpleSearchOperations(int[] tab, int a) //wyszukiwanie liniowe operacyjne
        {
            counter = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                counter++;
                if (tab[i] == a) return i;
            }
            return -1;
        }

        public static int BinarySearch(int[] tab, int a) //wyszukiwanie binarne czasowe
        {
            int Left = 0, Right = tab.Length - 1, Middle;
            while (Left <= Right)
            {
                Middle = (Left + Right) / 2;
                if (tab[Middle] == a) return Middle;
                else if (tab[Middle] > a) Right = Middle - 1;
                else Left = Middle + 1;
            }
            return -1;
        }

        public static int BinarySearchOperations(int[] tab, int a) //wyszukiwanie binarne operacyjne
        {
            counterB = 0;
            int Left = 0, Right = tab.Length - 1, Middle;
            while (Left <= Right)
            {
                counterB++;
                Middle = (Left + Right) / 2;
                if (tab[Middle] == a) return Middle;
                else if (tab[Middle] > a) Right = Middle - 1;
                else Left = Middle + 1;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int lookUpVaule = 1001;
            int result;
            long srednia = 0;
            Console.WriteLine("size" + ";" + "lookUpVaule" + ";" + "result" + ";" + "time" + ";" + "oper");


            //pesymistyczne liniowe
            for (int k = 200000; k < Math.Pow(2, 28); k += 20000)
            {
                int[] tab = new int[k];
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = rand.Next(1, 1000);

                }
                long start = Stopwatch.GetTimestamp();
                result = SimpleSearch(tab, lookUpVaule);
                long stop = Stopwatch.GetTimestamp();
                result = SimpleSearchOperations(tab, lookUpVaule);

                Console.WriteLine(k + ";" + lookUpVaule + ";" + result + ";" + (stop - start) + ";" + counter + ";lp");

            }

            //optymalne liniowe
            result = 0;
            for (int k = 200000; k < Math.Pow(2, 28); k += 20000)
            {
                int[] tab = new int[k];


                for (int j = 0; j < 10; j++)
                {
                    for (int i = 0; i < tab.Length; i++)
                    {
                        tab[i] = rand.Next(1, 1000);

                        lookUpVaule = rand.Next(1, 1000);
                    }

                    long start = Stopwatch.GetTimestamp();
                    result = SimpleSearch(tab, lookUpVaule);
                    long stop = Stopwatch.GetTimestamp();
                    srednia += stop - start;
                    result = SimpleSearchOperations(tab, lookUpVaule);

                }
                Console.WriteLine(k + ";" + lookUpVaule + ";" + result + ";" + srednia / 10 + ";" + counter + ";lo");
            }

            //pesymistyczne binarne
            lookUpVaule = 1001;
            for (int k = 200000; k < Math.Pow(2, 28); k += 20000)
            {
                int[] tab = new int[k];
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = rand.Next(1, 1000);

                }
                Array.Sort(tab);
                long start = Stopwatch.GetTimestamp();
                result = BinarySearch(tab, lookUpVaule);
                long stop = Stopwatch.GetTimestamp();
                result = BinarySearchOperations(tab, lookUpVaule);
                Console.WriteLine(k + ";" + lookUpVaule + ";" + result + ";" + (stop - start) + ";" + counterB + ";bp");

            }

            //optymalne binarne
            result = 0;
            for (int k = 200000; k < Math.Pow(2, 28); k += 20000)
            {
                int[] tab = new int[k];
                for (int j = 0; j < 10; j++)
                {
                    for (int i = 0; i < tab.Length; i++)
                    {
                        tab[i] = rand.Next(1, 1000);

                        lookUpVaule = rand.Next(1, 1000);
                    }
                Array.Sort(tab);
                long start = Stopwatch.GetTimestamp();
                    result = BinarySearch(tab, lookUpVaule);
                    long stop = Stopwatch.GetTimestamp();
                    srednia += (stop - start);
                    result = BinarySearchOperations(tab, lookUpVaule);
                }
                Console.WriteLine(k + ";" + lookUpVaule + ";" + result + ";" + srednia/10 + ";" + counterB + ";bo");
            }
        }
    }
}