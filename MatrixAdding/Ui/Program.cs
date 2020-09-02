using MatrixAdding;
using System;
using System.Threading;

namespace Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = MatrixAddingExtencion.GetRandomMatrix(500, 500);
            var b = MatrixAddingExtencion.GetRandomMatrix(500, 500);
            Console.WriteLine("Starts");
            var c = a.AddParalel(b);
            
            for(int i = 0;i<c.GetLength(0);i++)
            {
                for(int j = 0;j<c.GetLength(0);j++)
                {
                    Console.Write((c[i, j],3).ToString() + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
