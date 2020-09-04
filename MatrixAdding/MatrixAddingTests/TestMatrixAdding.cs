using MatrixAdding;
using NUnit.Framework;

namespace MatrixAddingTests
{
    public class Tests
    {


        private static readonly object[] ArraysPlusOperator =
       {
            new object[]
            {
                new double[3, 4]
                {
                    {1, 2, 3, 4},
                    {1, 2, 3, 4},
                    {1, 2, 3, 4}
                },
                new double[3, 4]
                {
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                    {4, 3, 2, 1},
                },
                new double[3, 4]
                {
                    {5, 5, 5, 5},
                    {5, 5, 5, 5},
                    {5, 5, 5, 5},
                }
            },
            new object[]
            {
                new double[3, 4]
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1},
                    {1, 1, 1, 1}
                },
                new double[3, 4]
                {
                    {2, 2, 2, 2},
                    {2, 2, 2, 2},
                    {2, 2, 2, 2},
                },
                new double[3, 4]
                {
                    {3, 3, 3, 3},
                    {3, 3, 3, 3},
                    {3, 3, 3, 3},
                }
            }

        };
        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void Matrix_Add_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.Add(matrix2);
            Assert.AreEqual(result,actual);
        }

        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void Matrix_AddInTwoThreads_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.AddInTwoThreads(matrix2);
            Assert.AreEqual(result, actual);
        }

        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void Matrix_AddInFourThread_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.AddInFourThreads(matrix2);
            Assert.AreEqual(result, actual);
        }


        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void Matrix_AddInEightThread_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.AddInSixThread(matrix2);
            Assert.AreEqual(result, actual);
        }
    }
}

