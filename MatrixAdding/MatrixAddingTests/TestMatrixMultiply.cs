using MatrixAdding;
using MatrixExtension;
using NUnit.Framework;

namespace MatrixTests
{
    public class TestMatrixMultiply
    {
        private static readonly object[] ArraysOperatorMultiply =
        {
            new object[]
            {
                new double[2, 2] {{2, 2}, {2, 2}}, new double[2, 2] {{2, 2}, {2, 2}}, new double[2, 2] {{8, 8}, {8, 8}}
            },
            new object[]
            {
                new double[2, 3]
                {
                    {1, 4, 2},
                    {2, 5, 1}
                },
                new double[3, 3]
                {
                    {3, 4, 2},
                    {3, 5, 7},
                    {1, 2, 1}
                },
                new double[2, 3]
                {
                    {17, 28, 32},
                    {22, 35, 40}
                }
            },
            new object[]
            {
                new double[4, 3]
                {
                    {1, 2, 3},
                    {1, 2, 3},
                    {1, 2, 3},
                    {1, 2, 3}
                },
                new double[3, 4]
                {
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                },
                new double[4, 4]
                {
                    {24, 18, 12, 6},
                    {24, 18, 12, 6},
                    {24, 18, 12, 6},
                    {24, 18, 12, 6}
                }
            }
        };


        [TestCaseSource(nameof(ArraysOperatorMultiply))]
        public void Matrix_Multiply_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.Multiply(matrix2);
            Assert.AreEqual(result, actual);
        }

        [TestCaseSource(nameof(ArraysOperatorMultiply))]
        public void Matrix_MultiplyInNThreads_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.MultiplyInNThreads(matrix2,1);
            Assert.AreEqual(result, actual);
        }
    }
}
