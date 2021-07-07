using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class InfoCard : Form
    {
        public InfoCard(int arg, bool f)
        {
            InitializeComponent();
            mode = arg; isNew = f;
        }
        private int mode;
        private bool isNew;
        private string[] end = {"покупателе", "поставщике", "грузоотправителе", "грузополучателе"};
        private string[] nameTable = {"buyer", "provider", "shipper", "consignee"};
        private string[][] column = new string[4][];
        private void InfoCard_Load(object sender, EventArgs e)
        {
            column[0] = new string[11] { "b_id", "b_name", "b_inn", "b_kpp", "b_index", "b_region", "b_city", "b_house", "b_korpus", "b_flat", "b_phone" };
            column[1] = new string[11] { "pr_id", "pr_name", "pr_inn", "pr_kpp", "pr_index", "pr_region", "pr_city", "pr_house", "pr_korpus", "pr_flat", "pr_phone" };
            column[2] = new string[11] { "sh_id", "sh_name", "sh_inn", "sh_kpp", "sh_index", "sh_region", "sh_city", "sh_house", "sh_korpus", "sh_flat", "sh_phone" };
            column[3] = new string[11] { "c_id", "c_name", "c_inn", "c_kpp", "c_index", "c_region", "c_city", "c_house", "c_korpus", "c_flat", "c_phone" };
            if (isNew) label2.Text = "Новый объект";
            else label2.Text = MainWindow.name[mode];
            label1.Text += end[mode];
            if (!isNew)
            {
                textBox1.Text = MainWindow.Reader("SELECT " + column[mode][1] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox2.Text = MainWindow.Reader("SELECT " + column[mode][2] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox3.Text = MainWindow.Reader("SELECT " + column[mode][3] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox4.Text = MainWindow.Reader("SELECT " + column[mode][4] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox5.Text = MainWindow.Reader("SELECT " + column[mode][5] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox6.Text = MainWindow.Reader("SELECT " + column[mode][6] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox7.Text = MainWindow.Reader("SELECT " + column[mode][7] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox8.Text = MainWindow.Reader("SELECT " + column[mode][8] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox9.Text = MainWindow.Reader("SELECT " + column[mode][9] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
                textBox10.Text = MainWindow.Reader("SELECT " + column[mode][10] + " FROM " + nameTable[mode] + " WHERE " + column[mode][0] + " = " + MainWindow.num[mode]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            if (isNew)
            {
                sql = "INSERT INTO " + nameTable[mode] + " (" + column[mode][1] + ", " + column[mode][2] + ", " + column[mode][3] + ", " + column[mode][4] + ", " + column[mode][5] + ", " + column[mode][6] + ", " + column[mode][7];
                if (textBox8.Text != "") sql += ", " + column[mode][8];
                if (textBox9.Text != "") sql += ", " + column[mode][9];
                if (textBox10.Text != "") sql += ", " + column[mode][10];
                sql += ") VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "'";
                if (textBox8.Text != "") sql += ", '" + textBox8.Text + "'";
                if (textBox9.Text != "") sql += ", '" + textBox9.Text + "'";
                if (textBox10.Text != "") sql += ", '" + textBox10.Text + "'";
                sql += ")";
            }
            else
            {
                sql = "UPDATE " + nameTable[mode] + " SET " + column[mode][1] + " = '" + textBox1.Text + "', " + column[mode][2] + " = '" + textBox2.Text + "', " + column[mode][3] + " = '" + textBox3.Text + "', " + column[mode][4] + " = '" + textBox4.Text + "', " + column[mode][5] + " = '" + textBox5.Text + "', " + column[mode][6] + " = '" + textBox6.Text + "', " + column[mode][7] + " = '" + textBox7.Text + "'";
                if (textBox8.Text != "") sql += ", " + column[mode][8] + " = '" + textBox8.Text + "'";
                if (textBox9.Text != "") sql += ", " + column[mode][9] + " = '" + textBox9.Text + "'";
                if (textBox10.Text != "") sql += ", " + column[mode][10] + " = '" + textBox10.Text + "'";
                sql += " WHERE " + column[mode][0] + " = " + MainWindow.num[mode];
            }
            if (MainWindow.Execute(sql) == 0) {
                isNew = false;
                label2.Text = textBox1.Text;
            }
        }
    }
}
