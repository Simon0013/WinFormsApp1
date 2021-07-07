using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();
        }
        private void Worker_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.surname + " " + Form1.name + " " + Form1.patr;
            textBox1.Text = Form1.surname;
            textBox2.Text = Form1.name;
            textBox3.Text = Form1.patr;
            textBox4.Text = MainWindow.Reader("SELECT login FROM worker WHERE w_id = " + Form1.id);
            textBox5.Text = MainWindow.Reader("SELECT password FROM worker WHERE w_id = " + Form1.id);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label5.Visible = true;
                textBox4.Visible = true;
                label6.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                label5.Visible = false;
                textBox4.Visible = false;
                label6.Visible = false;
                textBox5.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE worker SET w_surname = '" + textBox1.Text + "', w_name = '" + textBox2.Text + "', w_patr = '" + textBox3.Text + "'";
            if (checkBox1.Checked) sql += ", login = '" + textBox4.Text + "', password = '" + textBox5.Text + "'";
            sql += " WHERE w_id = " + Form1.id;
            if (MainWindow.Execute(sql) == 0)
            {
                Form1.surname = textBox1.Text;
                Form1.name = textBox2.Text;
                Form1.patr = textBox3.Text;
                label1.Text = Form1.surname + " " + Form1.name + " " + Form1.patr;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE worker SET w_surname = '" + textBox1.Text + "', w_name = '" + textBox2.Text + "', w_patr = '" + textBox3.Text + "'";
            if (checkBox1.Checked) sql += ", login = '" + textBox4.Text + "', password = '" + textBox5.Text + "'";
            sql += " WHERE w_id = " + Form1.id;
            if (MainWindow.Execute(sql) == 0)
            {
                Form1.surname = textBox1.Text;
                Form1.name = textBox2.Text;
                Form1.patr = textBox3.Text;
                label1.Text = Form1.surname + " " + Form1.name + " " + Form1.patr;
            }
            Close();
        }
    }
}
