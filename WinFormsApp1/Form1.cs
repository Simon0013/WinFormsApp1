using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string conn = "Host = localhost; User Id = postgres; Database = pay; Port = 5432; Password = a;";
        public static NpgsqlConnection connection = new NpgsqlConnection(conn);
        public static DataSet ds = new DataSet();
        public static string id, surname, name, patr;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool trueLogin = false, truePass = false;
            connection.Open();
            string sql = "SELECT login FROM worker";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["login"].ToString() == textBox1.Text)
                {
                    trueLogin = true;
                    break;
                }
            }
            connection.Close();
            connection.Open();
            sql = "SELECT password FROM worker WHERE login = '" + textBox1.Text + "'";
            command = new NpgsqlCommand(sql, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["password"].ToString() == textBox2.Text)
                {
                    truePass = true;
                    break;
                }
            }
            connection.Close();
            if (!trueLogin || !truePass)
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка");
                return;
            }
            else
            {
                sql = "SELECT w_id, w_surname, w_name, w_patr FROM worker WHERE login = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                command = new NpgsqlCommand(sql, connection);
                connection.Open();
                reader = command.ExecuteReader();
                reader.Read();
                id = reader["w_id"].ToString();
                surname = reader["w_surname"].ToString();
                name = reader["w_name"].ToString();
                patr = reader["w_patr"].ToString();
                connection.Close();
                Hide();
                MainWindow sot = new MainWindow();
                sot.ShowDialog();
                Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }
    }
}
