using MatrixAdding;
using System;
using System.Diagnostics;
using System.Threading;

namespace Ui
{
    static class Program
    {
        static void Main(string[] args)
        {
            var a = MatrixExtencion.GetRandomMatrix(10000, 10000);
            var b = MatrixExtencion.GetRandomMatrix(10000, 10000);

            var sw = new Stopwatch();
            sw.Start();
            var c = a.Add(b);
            sw.Stop();
            Console.Write("Without multithreading: ");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");





            sw.Restart();
            sw.Start();
            var c1 = a.AddInTwoThreads(b);
            sw.Stop();
            Console.Write("2 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");


            sw.Restart();
            sw.Start();
            var c2 = a.AddInFourThreads(b);
            sw.Stop();
            Console.Write("4 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");


            sw.Restart();
            sw.Start();
            var c3 = a.AddInSixThread(b);
            sw.Stop();
            Console.Write("6 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");

            sw.Restart();
            sw.Start();
            var c4 = a.AddInEightThread(b);
            sw.Stop();
            Console.Write("8 threads:         \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");


            sw.Restart();
            sw.Start(); 
            var c5 = a.AddInNThreads(b,10);
            sw.Stop();
            Console.Write("10 threads:        \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");


            for (int i = 0;i<c.GetLength(0);i++)
            {
                for(int j = 0;j < c.GetLength(1);j++)
                {

                    Console.Write(Math.Round(c5[i, j],3).ToString() + " ");
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {

                    Console.Write(Math.Round(c[i, j], 3).ToString() + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
