using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        public static DataSet ds = new DataSet();
        public static int id = -1;
        public static string current_id;
        public static void TableFill (string name, string sql)
        {
            Form1.connection.Open();
            if (Form1.ds.Tables[name] != null)
                Form1.ds.Tables[name].Clear();
            NpgsqlDataAdapter da;
            da = new NpgsqlDataAdapter(sql, Form1.connection);
            da.Fill(Form1.ds, name);
            Form1.connection.Close();
        }
        private void LoadPay(string id)
        {
            NpgsqlCommand command = Form1.connection.CreateCommand();
            command.CommandText = "SELECT * FROM payment WHERE pay_id = " + id;
            Form1.connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                Form1.connection.Close();
                current_id = id;
                label1.Text = "Счёт на оплату №" + id + " от " + MainWindow.Reader("SELECT pay_date FROM payment WHERE pay_id = " + id).Replace(" 0:00:00", "");
                textBox1.Text = MainWindow.Reader("SELECT CONCAT_WS(', ', pr_name, CONCAT('ИНН ', pr_inn), CONCAT('КПП ', pr_kpp), pr_index, pr_region, pr_city, CONCAT('д. ', pr_house), CONCAT('корп. ', pr_korpus), CONCAT('кв. ', pr_flat), CONCAT('тел. ', pr_phone)) FROM provider INNER JOIN payment ON pay_id = " + id + " AND provider.pr_id = payment.pr_id");
                textBox2.Text = MainWindow.Reader("SELECT CONCAT_WS(', ', sh_name, CONCAT('ИНН ', sh_inn), CONCAT('КПП ', sh_kpp), sh_index, sh_region, sh_city, CONCAT('д. ', sh_house), CONCAT('корп. ', sh_korpus), CONCAT('кв. ', sh_flat), CONCAT('тел. ', sh_phone)) FROM shipper INNER JOIN payment ON pay_id = " + id + " AND shipper.sh_id = payment.sh_id");
                textBox3.Text = MainWindow.Reader("SELECT CONCAT_WS(', ', b_name, CONCAT('ИНН ', b_inn), CONCAT('КПП ', b_kpp), b_index, b_region, b_city, CONCAT('д. ', b_house), CONCAT('корп. ', b_korpus), CONCAT('кв. ', b_flat), CONCAT('тел. ', b_phone)) FROM buyer INNER JOIN payment ON pay_id = " + id + " AND buyer.b_id = payment.b_id");
                textBox4.Text = MainWindow.Reader("SELECT CONCAT_WS(', ', c_name, CONCAT('ИНН ', c_inn), CONCAT('КПП ', c_kpp), c_index, c_region, c_city, CONCAT('д. ', c_house), CONCAT('корп. ', c_korpus), CONCAT('кв. ', c_flat), CONCAT('тел. ', c_phone)) FROM consignee INNER JOIN payment ON pay_id = " + id + " AND consignee.c_id = payment.c_id");
                string select = "SELECT DISTINCT items.itm_id AS №, itm_name AS Товары, COUNT(items.itm_id) AS Количество, itm_price AS Цена, SUM(itm_price) AS Сумма FROM items INNER JOIN score ON pay_id = " + id + " AND score.itm_id = items.itm_id GROUP BY items.itm_id, itm_name, itm_price";
                TableFill("Score", select);
                dataGridView1.DataSource = Form1.ds.Tables["Score"];
                dataGridView1.CurrentCell = null;
                dataGridView1.AutoResizeColumns();
            }
            else Form1.connection.Close();
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            LoadPay("1");
            label7.Text += Form1.surname + " " + Form1.name + " " + Form1.patr;
            MainWindow.Reading("SELECT CONCAT_WS(' ', 'Счёт №', pay_id, 'от', pay_date) FROM payment ORDER BY pay_id", comboBox1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CurrentPay pay = new CurrentPay(true);
            pay.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CurrentPay pay = new CurrentPay(false);
            pay.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string warning = "Вы точно хотите удалить данный счёт?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(warning, "Удаление", buttons);
            if (result == DialogResult.No) return;
            MainWindow.Execute("DELETE FROM payment WHERE pay_id = " + current_id + " CASCADE");
            if (Convert.ToInt32(current_id) > 1) LoadPay((Convert.ToInt32(current_id) - 1).ToString());
            else
            {
                label1.Text = "Счёт на оплату № _ от __-__-____";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Form1.ds.Tables["Score"].Clear();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            LoadPay(id.ToString());
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            id = comboBox1.SelectedIndex + 1;
        }
    }
}
