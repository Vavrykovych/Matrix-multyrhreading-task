using MatrixAdding;
using NUnit.Framework;

namespace MatrixAddingTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


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
            }

        };
        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void Matrix_Add_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.Add(matrix2);
            Assert.AreEqual(result,actual);
        }

        [TestCaseSource(nameof(ArraysPlusOperator))]
        public void Matrix_Add_Paralel_Works_Correctly(double[,] matrix1, double[,] matrix2, double[,] result)
        {
            double[,] actual = matrix1.AddParalel(matrix2);
            Assert.AreEqual(result, actual);
        }
    }
}
