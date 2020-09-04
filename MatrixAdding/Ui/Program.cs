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
            var a = MatrixExtencion.GetRandomMatrix(5000, 5000);
            var b = MatrixExtencion.GetRandomMatrix(5000, 5000);

            var sw = new Stopwatch();
            sw.Start();
            var c = a.Add(b);
            sw.Stop();
            Console.Write("Without threads: ");
            Console.WriteLine(sw.ElapsedMilliseconds);





            sw.Restart();
            sw.Start();
            var c1 = a.AddInTwoThreads(b);
            sw.Stop();
            Console.Write("2 threads:\t");
            Console.WriteLine(sw.ElapsedMilliseconds);


            sw.Restart();
            sw.Start();
            var c2 = a.AddInFourThreads(b);
            sw.Stop();
            Console.Write("4 threads:\t");
            Console.WriteLine(sw.ElapsedMilliseconds);


            sw.Restart();
            sw.Start();
            var c3 = a.AddInSixThread(b);
            sw.Stop();
            Console.Write("6 threads:\t");
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            sw.Start();
            var c4 = a.AddInEightThread(b);
            sw.Stop();
            Console.Write("8 threads:\t");
            Console.WriteLine(sw.ElapsedMilliseconds);

            for (int i = 0;i<c.GetLength(0);i++)
            {
                for(int j = 0;j < c.GetLength(1);j++)
                {
                    if(c4[i,j]!= c[i,j])
                    {
                        Console.Write(c3[i, j]);
                    }
                }
            }
        }
    }
}
