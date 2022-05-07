using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LP9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "2,2";
            textBox3.Text = "0,2";
            textBox4.Text = "3,2";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double xmin = double.Parse(textBox1.Text);
            double xmax = double.Parse(textBox2.Text);
            double h = double.Parse(textBox3.Text);
            double b = double.Parse(textBox4.Text);
            if (xmin > xmax)
            {
                (xmin, xmax) = (xmax, xmin);
            }

            int count = (int)Math.Ceiling(Math.Abs(xmax - xmin) / Math.Abs(h)) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];

            for (int i = 0; i < count; i++)
            {
                x[i] = xmax + h * i;
                y1[i] = 9 * (Math.Pow(x[i], 3) + Math.Pow(b, 3)) * Math.Tan(x[i]);
                y2[i] = Math.Pow(Math.Exp(x[i]), 2) + 2 * i * x[i] - 2;
            }
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Math.Abs(h);
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}