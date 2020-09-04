using MatrixAdding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<TimeStatistic> statistics = new List<TimeStatistic>();
            int matrixSize = 500;

            for (int i = 0; i < 19; i++)
            {
                var a = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);
                var b = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);

                var sw = new Stopwatch();
                sw.Start();
                var c = a.Add(b);
                sw.Stop();
                statistics.Add(new TimeStatistic { K_Threads = 0,Size = matrixSize,Time = sw.ElapsedMilliseconds });

                matrixSize += 500;
            }
            matrixSize = 500;
            for (int i = 0; i < 19; i++)
            {
                var a = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);
                var b = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);

                var sw = new Stopwatch();
                sw.Start();
                var c = a.AddInTwoThreads(b);
                sw.Stop();
                statistics.Add(new TimeStatistic { K_Threads = 2, Size = matrixSize, Time = sw.ElapsedMilliseconds });

                matrixSize += 500;
            }
            matrixSize = 500;
            for (int i = 0; i < 19; i++)
            {
                var a = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);
                var b = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);

                var sw = new Stopwatch();
                sw.Start();
                var c = a.AddInFourThreads(b);
                sw.Stop();
                statistics.Add(new TimeStatistic { K_Threads = 4, Size = matrixSize, Time = sw.ElapsedMilliseconds });

                matrixSize += 500;
            }
            matrixSize = 500;
            for (int i = 0; i < 19; i++)
            {
                var a = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);
                var b = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);

                var sw = new Stopwatch();
                sw.Start();
                var c = a.AddInSixThread(b);
                sw.Stop();
                statistics.Add(new TimeStatistic { K_Threads = 6, Size = matrixSize, Time = sw.ElapsedMilliseconds });

                matrixSize += 500;
            }
            matrixSize = 500;
            for (int i = 0; i < 19; i++)
            {
                var a = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);
                var b = MatrixExtencion.GetRandomMatrix(matrixSize, matrixSize);

                var sw = new Stopwatch();
                sw.Start();
                var c = a.AddInEightThread(b);
                sw.Stop();
                statistics.Add(new TimeStatistic { K_Threads = 8, Size = matrixSize, Time = sw.ElapsedMilliseconds });

                matrixSize += 500;
            }
            DataGrid.DataSource = statistics;
        }
    }


    public class TimeStatistic
    {
        public int Size { get; set; }
        public int K_Threads { get; set; }
        public double Time { get; set; }
    }
}