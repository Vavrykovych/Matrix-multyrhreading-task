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
            //var a = new double[3, 4]
            //    {
            //        {1, 2, 3, 4},
            //        {1, 2, 3, 4},
            //        {1, 2, 3, 4}
            //    };
            //    
            //
            //var b = new double[3, 4]
            //    {
            //        {4, 3, 2, 1},
            //        {4, 3, 2, 1},
            //        {4, 3, 2, 1},
            //    };


            var a = MatrixExtencion.GetRandomMatrix(5000, 5000);
            var b = MatrixExtencion.GetRandomMatrix(5000, 5000);

            var sw = new Stopwatch();
            sw.Start();
            var c = a.AddInTwoThreads(b);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);





            sw.Restart();
            sw.Start();
            var c1 = a.Add(b);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);





        }
    }
}
