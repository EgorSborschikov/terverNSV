using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace terverNSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Enabled = false;
            button2.Enabled = false;

            checkBox1.CheckedChanged += checkBox_CheckedChanged;
            checkBox2.CheckedChanged += checkBox_CheckedChanged;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            button1.Click += button1_Click;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Если checkBox1 установлен, то включаем кнопку перехода на следующую форму
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false; // Сбрасываем checkBox2, если checkBox1 активен
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else if (!checkBox2.Checked) // Проверяем, что checkBox2 не активен
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Если checkBox2 установлен, то включаем кнопку перехода на следующую форму
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false; // Сбрасываем checkBox1, если checkBox2 активен
                button2.Enabled = true;
                button1.Enabled = false;
            }
            else if (!checkBox1.Checked) // Проверяем, что checkBox1 не активен
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр Form2 и отображаем его
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }


}
