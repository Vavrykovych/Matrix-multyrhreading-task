using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixAdding
{
    public static class MatrixAddingExtencion
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
        public static double[,] AddParalel(this double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            //Thread[] threads = new Thread[matrix1.GetLength(0)];
            for(int i = 0;i< matrix1.GetLength(0);i++)
            {
                (new Thread(() => { })).Start();
                //threads[i] =
                new Thread((ind) =>
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        res[(int)ind, j] = matrix1[(int)ind, j] + matrix2[(int)ind, j];
                    }
                }).Start(i);
                //threads[i].Start(i);
            }


            return res;
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

        static void AddCol(double[,] matrix1, double[,] matrix2, double[,] res, int col)
        {
            for(int j = 0;j<matrix1.GetLength(1);j++)
            {
                res[col, j] = matrix1[col, j] + matrix2[col, j];
            }
        }
    }
}
