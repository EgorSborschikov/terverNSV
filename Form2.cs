using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace terverNSV
{
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            double a = double.Parse(textBox1.Text); // параметр распределения
            double sigma = double.Parse(textBox2.Text); // параметр распределения
            int N = int.Parse(textBox3.Text); // объем выборки
            double spread = (a + 3 * sigma) - (a - 3 * sigma); // разброс

            int k = (int)Math.Log(N, 2) + 1; // количество интервалов

            double delta_x = spread / k; // длина интервала

            double[] middle_interval = new double[k]; // середины интервалов
            double delta_xx = delta_x / 2;

            for (int i = 0; i < k; i++)
            {
                middle_interval[i] = delta_xx;
                delta_xx += delta_x;
            }

            double[] theory = new double[k];  // массив значений ожидаемых количеств событий 

            for (int i = 0; i < k; i++)
            {
                double n_theory = N * (1/(sigma* Math.Sqrt(6.28))* Math.Pow(Math.E, (-Math.Pow((middle_interval[i]-a), 2)/(2* Math.Pow(sigma, 2))))) * delta_x;
                theory[i] = n_theory;
            }

            double[] middle_val = new double[k]; // значения в серединах интервалов

            for (int i = 0; i < k; i++)
            {
                middle_val[i] = (1 / (sigma * Math.Sqrt(6.28)) * Math.Pow(Math.E, (-Math.Pow((middle_interval[i] - a), 2) / (2 * Math.Pow(sigma, 2)))));
            }

            double[] func_middle_val = new double[k]; // вероятности

            for (int i = 0; i < k; i++)
            {
                func_middle_val[i] = (1 / (sigma * Math.Sqrt(6.28)) * Math.Pow(Math.E, (-Math.Pow((middle_interval[i] - a), 2) / (2 * Math.Pow(sigma, 2))))) * delta_x;
            }

            double summ = 0;
            for (int i = 0; i < k; i++)
            {
                summ += func_middle_val[i];
            }

            if (summ > 0.9 && summ <= 1)
            {
                MessageBox.Show("Работает корректно");
            }
            double x = delta_xx;
            for (int i = 0; i < k; i++)
            {
                chart1.Series[0].Points.AddXY(x, func_middle_val[i]);
                x += delta_x;
            }

        }

    }   
}
