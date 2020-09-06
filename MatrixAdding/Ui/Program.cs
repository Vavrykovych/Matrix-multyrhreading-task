
using System;
using System.Diagnostics;
using System.Threading;
using MatrixAdding;
using MatrixExtension;

namespace Ui
{
    static class Program
    {
        static void Main(string[] args)
        {
            int size = 2000;
            var a = MatrixAdding.MatrixExtension.GetRandomMatrix(size, size);
            var b = MatrixAdding.MatrixExtension.GetRandomMatrix(size, size);

            Console.WriteLine("Add matrixes " + size.ToString() + "x" + size.ToString());
            var sw = new Stopwatch();
            sw.Start();
            var c = a.Add(b);
            sw.Stop();
            Console.Write("Without multithreading: ");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");

            sw.Restart();
            sw.Start();
            var c6 = a.AddInNThreads(b, 1);
            sw.Stop();
            Console.Write("1 thread:          \t");
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


            Console.WriteLine("Multiply matrixes " + size.ToString() + "x" + size.ToString());

            sw.Restart();
            sw.Start();
            var m = a.Multiply(b);
            sw.Stop();
            Console.Write("Without multithreading: ");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");

            sw.Restart();
            sw.Start();
            var m1 = a.MultiplyInNThreads(b,1);
            sw.Stop();
            Console.Write("1 thread:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");




            sw.Restart();
            sw.Start();
            var m2 = a.MultiplyInNThreads(b, 2);
            sw.Stop();
            Console.Write("2 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");


            sw.Restart();
            sw.Start();
            var m3 = a.MultiplyInNThreads(b, 4);
            sw.Stop();
            Console.Write("4 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");


            //sw.Restart();
            //sw.Start();
            //var m4 = a.MultiplyInNThreads(b, 6);
            //sw.Stop();
            //Console.Write("6 threads:          \t");
            //Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");

            sw.Restart();
            sw.Start();
            var m5 = a.MultiplyInNThreads(b, 8);
            sw.Stop();
            Console.Write("8 threads:         \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");


            sw.Restart();
            sw.Start();
            var m6 = a.MultiplyInNThreads(b, 10);
            sw.Stop();
            Console.Write("10 threads:        \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");

            sw.Restart();
            sw.Start();
            var m7 = a.MultiplyInNThreads(b, 20);
            sw.Stop();
            Console.Write("20 threads:        \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}
