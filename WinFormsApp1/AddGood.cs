using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AddGood : Form
    {
        public AddGood()
        {
            InitializeComponent();
        }
        private void AddGood_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO items (itm_name, itm_price) VALUES (";
            if (textBox1.Text == "") sql += "null, "; else sql += "'" + textBox1.Text + "', ";
            if (textBox2.Text == "") sql += "null)"; else sql += textBox2.Text + ")";
            if (MainWindow.Execute(sql) == 0)
                Form1.ds.Tables["AllGoods"].Rows.Add(new object[] {MainWindow.Reader("SELECT MAX(itm_id) FROM items") ,textBox1.Text, textBox2.Text});
        }
    }
}
