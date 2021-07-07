using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class NewGood : Form
    {
        public NewGood()
        {
            InitializeComponent();
        }
        private int id;
        private string name, price;
        private void NewGood_Load(object sender, EventArgs e)
        {
            string select = "SELECT itm_id AS №, itm_name AS Товары, itm_price AS Цена FROM items";
            Payment.TableFill("AllGoods", select);
            dataGridView1.DataSource = Form1.ds.Tables["AllGoods"];
            dataGridView1.CurrentCell = null;
            dataGridView1.AutoResizeColumns();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            if (MainWindow.Execute("INSERT INTO score VALUES (" + Payment.current_id + ", " + id + ")") == 0)
            {
                Form1.ds.Tables["Score"].Rows.Add(new object[] {id, name, 1, price, price});
            }
            dataGridView1.CurrentCell = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            if (MainWindow.Execute("DELETE FROM score WHERE pay_id = " + Payment.current_id + " AND itm_id = " + id) == 0)
            {
                foreach (DataRow row in Form1.ds.Tables["Score"].Rows)
                {
                    if (row["Товары"].ToString() == name)
                    {
                        Form1.ds.Tables["Score"].Rows.Remove(row);
                        break;
                    }
                }
            }
            dataGridView1.CurrentCell = null;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(Form1.ds.Tables["AllGoods"].Rows[dataGridView1.CurrentRow.Index]["№"].ToString());
            name = Form1.ds.Tables["AllGoods"].Rows[dataGridView1.CurrentRow.Index]["Товары"].ToString();
            price = Form1.ds.Tables["AllGoods"].Rows[dataGridView1.CurrentRow.Index]["Цена"].ToString();
        }
    }
}
