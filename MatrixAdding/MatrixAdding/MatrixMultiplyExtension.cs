using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MatrixExtension
{
    public static class MatrixExtension
    {
        public static double[,] Multiply(this double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new ArgumentException("Matrix sizes not correct.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        res[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return res;

        }

        public static double[,] MultiplyMultithreading(this double[,] matrix1, double[,] matrix2, int N)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new ArgumentException("Matrix sizes not correct.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            Thread[] threads = new Thread[N];
            int step = (int)Math.Ceiling((double)matrix1.GetLength(0) / (double)N);
            for (int i = 0; i < N; i++)
            {
                threads[i] = new Thread((object ind) => {
                    MultiplyPartial(matrix1, matrix2, res,
                    step * (int)ind,
                    step * ((int)ind + 1) > matrix1.GetLength(0) ? matrix1.GetLength(0) : step * ((int)ind + 1));
                });
                threads[i].Start(i);
            }
            for (int i = 0; i < N; i++)
            {
                threads[i].Join();
            }
            return res;
        }





        static void MultiplyPartial(double[,] matrix1, double[,] matrix2, double[,] res, int startI, int endI)
        {
            for (int i = startI; i < endI; i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        res[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
        }
    }
}