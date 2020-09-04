using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixAdding
{
    public static class MatrixExtencion
    {
        public static double[,] Add(this double[,] matrix1, double[,] matrix2)
        {
            if(matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            for(int i = 0;i< res.GetLength(0);i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return res;
        }
        public static double[,] AddInTwoThreads(this double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            Thread[] threads = new Thread[2];
            threads[0] = new Thread(() => { AddPartial(matrix1, matrix2, res, 0, matrix1.GetLength(0) / 2); });
            threads[1] = new Thread(() => { AddPartial(matrix1, matrix2, res, matrix1.GetLength(0) / 2, matrix1.GetLength(0)); });
            threads[0].Start();
            threads[1].Start();
            threads[0].Join();
            threads[1].Join();


            return res;
        }
        static void AddPartial(double[,] matrix1, double[,] matrix2, double[,] res, int startI, int endI)
        {
            for (int i = startI; i < endI; i ++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    res[i, j] = matrix2[i, j] + matrix1[i, j];
                }
            }
        }
        public static double[,] GetRandomMatrix(int n,int m)
        {
            Random rand = new Random();
            double[,] res = new double[n, m];
            for(int i = 0; i<n;i++)
            {
                for(int j = 0;j<m;j++)
                {
                    res[i, j] = rand.NextDouble();
                }
            }
            return res;
        }
    }
}
