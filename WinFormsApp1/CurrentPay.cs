using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CurrentPay : Form
    {
        public CurrentPay(bool f)
        {
            InitializeComponent();
            isNew = f;
        }
        bool isNew;
        string pr_id, sh_id, b_id, c_id;
        private void CurrentPay_Load(object sender, EventArgs e)
        {
            MainWindow.Reading("SELECT pr_name FROM provider ORDER BY pr_id", comboBox1);
            MainWindow.Reading("SELECT sh_name FROM shipper ORDER BY sh_id", comboBox2);
            MainWindow.Reading("SELECT b_name FROM buyer ORDER BY b_id", comboBox3);
            MainWindow.Reading("SELECT c_name FROM consignee ORDER BY c_id", comboBox4);
            if (!isNew)
            {
                comboBox1.Text = MainWindow.Reader("SELECT pr_name FROM provider INNER JOIN payment ON pay_id = " + Payment.current_id + " AND provider.pr_id = payment.pr_id");
                pr_id = MainWindow.Reader("SELECT provider.pr_id FROM provider INNER JOIN payment ON pay_id = " + Payment.current_id + " AND provider.pr_id = payment.pr_id");
                comboBox2.Text = MainWindow.Reader("SELECT sh_name FROM shipper INNER JOIN payment ON pay_id = " + Payment.current_id + " AND shipper.sh_id = payment.sh_id");
                sh_id = MainWindow.Reader("SELECT shipper.sh_id FROM shipper INNER JOIN payment ON pay_id = " + Payment.current_id + " AND shipper.sh_id = payment.sh_id");
                b_id = MainWindow.Reader("SELECT buyer.b_id FROM buyer INNER JOIN payment ON pay_id = " + Payment.current_id + " AND buyer.b_id = payment.b_id");
                comboBox3.Text = MainWindow.Reader("SELECT b_name FROM buyer INNER JOIN payment ON pay_id = " + Payment.current_id + " AND buyer.b_id = payment.b_id");
                comboBox4.Text = MainWindow.Reader("SELECT c_name FROM consignee INNER JOIN payment ON pay_id = " + Payment.current_id + " AND consignee.c_id = payment.c_id");
                c_id = MainWindow.Reader("SELECT consignee.c_id FROM consignee INNER JOIN payment ON pay_id = " + Payment.current_id + " AND consignee.c_id = payment.c_id");
                dateTimePicker1.Text = MainWindow.Reader("SELECT pay_date FROM payment WHERE pay_id = " + Payment.current_id);
                dataGridView1.DataSource = Form1.ds.Tables["Score"];
                dataGridView1.CurrentCell = null;
                dataGridView1.AutoResizeColumns();
            }
            else Payment.current_id = (Convert.ToInt32(Payment.current_id) + 1).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NewGood good = new NewGood();
            good.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql;
            if (isNew)
            {
                sql = "INSERT INTO payment (pay_date, w_id, pr_id, sh_id, b_id, c_id) VALUES ('" + dateTimePicker1.Value.ToShortDateString() + "', " + Form1.id + ", ";
                if (pr_id == null) sql += "null, "; else sql += pr_id + ", ";
                if (sh_id == null) sql += "null, "; else sql += sh_id + ", ";
                if (b_id == null) sql += "null, "; else sql += b_id + ", ";
                if (c_id == null) sql += "null)"; else sql += c_id + ")";
            }
            else
            {
                sql = "UPDATE payment SET pay_date = '" + dateTimePicker1.Value.ToShortDateString() + "', w_id = " + Form1.id + ", pr_id = " + pr_id + ", sh_id = " + sh_id + ", b_id = " + b_id + ", c_id = " + c_id + " WHERE pay_id = " + Payment.current_id;
            }
            MainWindow.Execute(sql);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pr_id = (comboBox1.SelectedIndex + 1).ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sh_id = (comboBox2.SelectedIndex + 1).ToString();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            b_id = (comboBox3.SelectedIndex + 1).ToString();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_id = (comboBox4.SelectedIndex + 1).ToString();
        }
        private void CurrentPay_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
