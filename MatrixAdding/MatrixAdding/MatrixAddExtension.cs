using System;
using System.Threading;


namespace MatrixAdding
{
    public static class MatrixAddExtension
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

        public static double[,] Subtract(this double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return res;
        }

        public static double[,] AddMultithreading(this double[,] matrix1, double[,] matrix2, int N)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            Thread[] threads = new Thread[N];
            int step = (int)Math.Ceiling((double)matrix1.GetLength(0) / (double)N);
            for(int i = 0;i<N;i++)
            {
                threads[i] = new Thread((object ind) => { AddPartial(matrix1, matrix2, res,
                    step * (int)ind,
                    step * ((int)ind + 1) >= matrix1.GetLength(0) ? matrix1.GetLength(0) : step * ((int)ind + 1)); });
                threads[i].Start(i);
            }

            for(int i = 0;i<N;i++)
            {
                threads[i].Join();
            }


            return res;
        }

        public static double[,] SubtractMultithreading(this double[,] matrix1, double[,] matrix2, int N)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            Thread[] threads = new Thread[N];
            int step = (int)Math.Ceiling((double)matrix1.GetLength(0) / (double)N);
            for (int i = 0; i < N; i++)
            {
                threads[i] = new Thread((object ind) => {
                    SubPartial(matrix1, matrix2, res,
                    step * (int)ind,
                    step * ((int)ind + 1) >= matrix1.GetLength(0) ? matrix1.GetLength(0) : step * ((int)ind + 1));
                });
                threads[i].Start(i);
            }

            for (int i = 0; i < N; i++)
            {
                threads[i].Join();
            }


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

        static void SubPartial(double[,] matrix1, double[,] matrix2, double[,] res, int startI, int endI)
        {
            for (int i = startI; i < endI; i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    res[i, j] = matrix1[i, j] - matrix2[i, j];
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
