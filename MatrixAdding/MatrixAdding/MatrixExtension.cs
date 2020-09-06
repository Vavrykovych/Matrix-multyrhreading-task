using System;
using System.Threading;


namespace MatrixAdding
{
    public static class MatrixExtension
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


        public static double[,] AddInFourThreads(this double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            Thread[] threads = new Thread[4];
            threads[0] = new Thread(() => { AddPartial(matrix1, matrix2, res,        0, matrix1.GetLength(0) / 4); });
            threads[1] = new Thread(() => { AddPartial(matrix1, matrix2, res,        matrix1.GetLength(0) / 4, matrix1.GetLength(0) /2); });
            threads[2] = new Thread(() => { AddPartial(matrix1, matrix2, res,        matrix1.GetLength(0) / 2, matrix1.GetLength(0) / 2 + matrix1.GetLength(0) / 4); });
            threads[3] = new Thread(() => { AddPartial(matrix1, matrix2, res,        matrix1.GetLength(0) / 2 + matrix1.GetLength(0) / 4, matrix1.GetLength(0)); });

            foreach(var i in threads)
            {
                i.Start();
            }
            foreach (var i in threads)
            {
                i.Join();
            }


            return res;
        }

        public static double[,] AddInSixThread(this double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            Thread[] threads = new Thread[6];
            threads[0] = new Thread(() => { AddPartial(matrix1, matrix2, res,       0, matrix1.GetLength(0) / 6); });
            threads[1] = new Thread(() => { AddPartial(matrix1, matrix2, res,       matrix1.GetLength(0) / 6, 2*matrix1.GetLength(0) / 6); });
            threads[2] = new Thread(() => { AddPartial(matrix1, matrix2, res,       2* matrix1.GetLength(0) / 6, 3*matrix1.GetLength(0) / 6); });
            threads[3] = new Thread(() => { AddPartial(matrix1, matrix2, res,       3 * matrix1.GetLength(0) / 6, 4 * matrix1.GetLength(0) / 6); });
            threads[4] = new Thread(() => { AddPartial(matrix1, matrix2, res,       4 * matrix1.GetLength(0) / 6, 5 * matrix1.GetLength(0) / 6); });
            threads[5] = new Thread(() => { AddPartial(matrix1, matrix2, res,       5 * matrix1.GetLength(0) / 6, matrix1.GetLength(0)); });
            foreach (var i in threads)
            {
                i.Start();
            }
            foreach (var i in threads)
            {
                i.Join();
            }


            return res;
        }

        public static double[,] AddInEightThread(this double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            Thread[] threads = new Thread[8];
            threads[0] = new Thread(() => { AddPartial(matrix1, matrix2, res,       0, matrix1.GetLength(0) / 8); });
            threads[1] = new Thread(() => { AddPartial(matrix1, matrix2, res,       matrix1.GetLength(0) / 8, 2 * matrix1.GetLength(0) / 8); });
            threads[2] = new Thread(() => { AddPartial(matrix1, matrix2, res,       2 * matrix1.GetLength(0) / 8, 3 * matrix1.GetLength(0) / 8); });
            threads[3] = new Thread(() => { AddPartial(matrix1, matrix2, res,       3 * matrix1.GetLength(0) / 8, 4 * matrix1.GetLength(0) / 8); });
            threads[4] = new Thread(() => { AddPartial(matrix1, matrix2, res,       4 * matrix1.GetLength(0) / 8, 5 * matrix1.GetLength(0) / 8); });
            threads[5] = new Thread(() => { AddPartial(matrix1, matrix2, res,       5 * matrix1.GetLength(0) / 8, 6 * matrix1.GetLength(0) / 8); });
            threads[6] = new Thread(() => { AddPartial(matrix1, matrix2, res,       6 * matrix1.GetLength(0) / 8, 7 * matrix1.GetLength(0) / 8); });
            threads[7] = new Thread(() => { AddPartial(matrix1, matrix2, res,       7 * matrix1.GetLength(0) / 8, matrix1.GetLength(0)); });
            foreach (var i in threads)
            {
                i.Start();
            }
            foreach (var i in threads)
            {
                i.Join();
            }


            return res;
        }
        public static double[,] AddInNThreads(this double[,] matrix1, double[,] matrix2, int N)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new ArgumentException("Matrixes must be the same size.");
            }
            if(matrix1.GetLength(0)%N != 0 || N <= 0)
            {
                throw new ArgumentException("Not correct N");
            }
            double[,] res = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            Thread[] threads = new Thread[N];
            int step = matrix1.GetLength(0) / N;
            for(int i = 0;i<N;i++)
            {
                threads[i] = new Thread((object ind) => { AddPartial(matrix1, matrix2, res,
                    step * (int)ind,
                    step * ((int)ind + 1) > matrix1.GetLength(0) ? matrix1.GetLength(0) : step * ((int)ind + 1)); });
                threads[i].Start(i);
            }

            for(int i = 0;i<N;i++)
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
