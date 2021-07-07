using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Goods : Form
    {
        public Goods()
        {
            InitializeComponent();
        }
        public static int k;
        private void Goods_Load(object sender, EventArgs e)
        {
            string select = "SELECT itm_id AS №, itm_name AS Товары, itm_price AS Цена FROM items";
            Payment.TableFill("AllGoods", select);
            dataGridView1.DataSource = Form1.ds.Tables["AllGoods"];
            dataGridView1.CurrentCell = null;
            dataGridView1.AutoResizeColumns();
        }
        private void dataGridView1_CellClick(object sender, EventArgs e)
        {
            k = dataGridView1.CurrentRow.Index;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddGood add = new AddGood();
            add.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            if (MainWindow.Execute("DELETE FROM items WHERE itm_id = " + Form1.ds.Tables["AllGoods"].Rows[k]["№"].ToString()) == 0)
                Form1.ds.Tables["AllGoods"].Rows.RemoveAt(k);
        }
    }
}
