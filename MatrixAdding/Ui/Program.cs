
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
            int size = 7000;
            var a = MatrixAdding.MatrixAddExtension.GetRandomMatrix(size, size);
            var b = MatrixAdding.MatrixAddExtension.GetRandomMatrix(size, size);
            long defaultTime;

            Console.WriteLine("Add matrixes " + size.ToString() + "x" + size.ToString());
            var sw = new Stopwatch();
            sw.Start();
            var c = a.Add(b);
            sw.Stop(); 
            Console.Write("Without multithreading: ");
            defaultTime = sw.ElapsedMilliseconds;
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString() 
                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds)/1, 3).ToString());

            sw.Restart();
            sw.Start();
            var c6 = a.AddInNThreads(b, 1);
            sw.Stop();
            Console.Write("1 thread:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                 +"  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 1, 3).ToString());


            sw.Restart();
            sw.Start();
            var c1 = a.AddInNThreads(b,2);
            sw.Stop();
            Console.Write("2 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 2, 3).ToString());

            sw.Restart();
            sw.Start();
            var c2 = a.AddInNThreads(b,4);
            sw.Stop();
            Console.Write("4 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 4, 3).ToString());


            sw.Restart();
            sw.Start();
            var c3 = a.AddInNThreads(b,6);
            sw.Stop();
            Console.Write("6 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 6, 3).ToString());

            sw.Restart();
            sw.Start();
            var c4 = a.AddInNThreads(b,8);
            sw.Stop();
            Console.Write("8 threads:         \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 8, 3).ToString());


            sw.Restart();
            sw.Start(); 
            var c5 = a.AddInNThreads(b,10);
            sw.Stop();
            Console.Write("10 threads:        \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 10, 3).ToString());
        }
    }
}
