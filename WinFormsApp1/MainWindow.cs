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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static NpgsqlCommand command;
        static NpgsqlDataReader reader;
        public static int[] num = {0, 0, 0, 0};
        public static string[] name = new string[4];
        public static void Reading (string select, ComboBox comboBox)
        {
            command = Form1.connection.CreateCommand();
            command.CommandText = select;
            Form1.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read()) comboBox.Items.Add(reader[0]);
            Form1.connection.Close();
        }
        public static string Reader (string select)
        {
            command = new NpgsqlCommand(select, Form1.connection);
            Form1.connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            string result;
            try
            {
                result = reader[0].ToString();
            }
            catch
            {
                result = "";
            }
            Form1.connection.Close();
            return result;
        }
        public static int Execute(string sql)
        {
            command = new NpgsqlCommand(sql, Form1.connection);
            Form1.connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException)
            {
                MessageBox.Show("Проверьте заполненность обязательных полей и соответствие типов введённых значений на логичность", "Ошибка");
                Form1.connection.Close();
                return -1;
            }
            Form1.connection.Close();
            return 0;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.surname + " " + Form1.name + " " + Form1.patr;
            Reading("SELECT b_name FROM buyer ORDER BY b_id", comboBox1);
            Reading("SELECT pr_name FROM provider ORDER BY pr_id", comboBox2);
            Reading("SELECT sh_name FROM shipper ORDER BY sh_id", comboBox3);
            Reading("SELECT c_name FROM consignee ORDER BY c_id", comboBox4);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            worker.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            num[0] = comboBox1.SelectedIndex + 1;
            name[0] = comboBox1.SelectedItem.ToString();
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            num[1] = comboBox2.SelectedIndex + 1;
            name[1] = comboBox2.SelectedItem.ToString();
        }
        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            num[2] = comboBox3.SelectedIndex + 1;
            name[2] = comboBox3.SelectedItem.ToString();
        }
        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            num[3] = comboBox4.SelectedIndex + 1;
            name[3] = comboBox4.SelectedItem.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            InfoCard info = new InfoCard(0, true);
            info.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            InfoCard info = new InfoCard(0, false);
            info.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            string warning = "Вы точно хотите удалить покупателя " + comboBox1.Text + "?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(warning, "Удаление", buttons);
            if (result == DialogResult.No) return;
            Execute("DELETE FROM buyer WHERE b_id = " + num[0]);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            InfoCard info = new InfoCard(1, true);
            info.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            InfoCard info = new InfoCard(1, false);
            info.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            string warning = "Вы точно хотите удалить поставщика " + comboBox2.Text + "?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(warning, "Удаление", buttons);
            if (result == DialogResult.No) return;
            Execute("DELETE FROM provider WHERE pr_id = " + num[1]);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            InfoCard info = new InfoCard(2, true);
            info.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            InfoCard info = new InfoCard(2, false);
            info.Show();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            string warning = "Вы точно хотите удалить грузоотправителя " + comboBox3.Text + "?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(warning, "Удаление", buttons);
            if (result == DialogResult.No) return;
            Execute("DELETE FROM shipper WHERE sh_id = " + num[2]);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            InfoCard info = new InfoCard(3, true);
            info.Show();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            InfoCard info = new InfoCard(3, false);
            info.Show();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан экземпляр!", "Ошибка");
                return;
            }
            string warning = "Вы точно хотите удалить грузополучателя " + comboBox4.Text + "?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(warning, "Удаление", buttons);
            if (result == DialogResult.No) return;
            Execute("DELETE FROM consignee WHERE c_id = " + num[3]);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Goods goods = new Goods();
            goods.Show();
        }
    }
}
