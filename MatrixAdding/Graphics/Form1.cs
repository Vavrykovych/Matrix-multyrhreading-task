using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixAdding;

namespace Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var a = MatrixExtencion.GetRandomMatrix(10000, 10000);
            var b = MatrixExtencion.GetRandomMatrix(10000, 10000);

            var sw = new Stopwatch();
            sw.Start();
            var c = a.Add(b);
            sw.Stop();


            int matrix_size = 500;   
            for(int i = 0;i<19;i++)
            {


                matrix_size += 500;
            }
        }

    }
}
