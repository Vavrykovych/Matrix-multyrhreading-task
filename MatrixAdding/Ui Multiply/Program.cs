using MatrixExtension;
using System;
using System.Diagnostics;

namespace Ui_Multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 500;
            var a = MatrixAdding.MatrixAddExtension.GetRandomMatrix(size, size);
            var b = MatrixAdding.MatrixAddExtension.GetRandomMatrix(size, size);
            long defaultTime;

            Console.WriteLine("Multiply matrixes " + size.ToString() + "x" + size.ToString());

            var sw = new Stopwatch();
            sw.Start();
            var m = a.Multiply(b);
            sw.Stop();
            Console.Write("Without multithreading: ");
            defaultTime = sw.ElapsedMilliseconds;
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 1, 3).ToString());

            sw.Restart();
            sw.Start();
            var m1 = a.MultiplyMultithreading(b, 1);
            sw.Stop();
            Console.Write("1 thread:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 1, 3).ToString());




            sw.Restart();
            sw.Start();
            var m2 = a.MultiplyMultithreading(b, 2);
            sw.Stop();
            Console.Write("2 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 2, 3).ToString());


            sw.Restart();
            sw.Start();
            var m3 = a.MultiplyMultithreading(b, 4);
            sw.Stop();
            Console.Write("4 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 4, 3).ToString());


            sw.Restart();
            sw.Start();
            var m4 = a.MultiplyMultithreading(b, 6);
            sw.Stop();
            Console.Write("6 threads:          \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 6, 3).ToString());

            sw.Restart();
            sw.Start();
            var m5 = a.MultiplyMultithreading(b, 8);
            sw.Stop();
            Console.Write("8 threads:         \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 8, 3).ToString());

            sw.Restart();
            sw.Start();
            var m6 = a.MultiplyMultithreading(b, 10);
            sw.Stop();
            Console.Write("10 threads:        \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 10, 3).ToString());

            sw.Restart();
            sw.Start();
            var m7 = a.MultiplyMultithreading(b, 20);
            sw.Stop();
            Console.Write("20 threads:        \t");
            Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms  " + "speed " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds), 3).ToString()
                                + "  one thread profit  " + Math.Round(((double)defaultTime / (double)sw.ElapsedMilliseconds) / 20, 3).ToString());
        }
    }
}
