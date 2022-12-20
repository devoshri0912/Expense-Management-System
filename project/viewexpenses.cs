using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class viewexpenses : Form
    {
        public static string cat;
        public viewexpenses()
        {
            InitializeComponent();
            //DisplayExpenses();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void DisplayExpenses()
        {
            Con.Open();
            //string query = "select * from ExpenseTbl where ExpUser='"+loginpage.loginuser+"'";
            string query; //= "select * from IncomeTbl where IncUser='" + loginpage.loginuser + "'";
            //string query = "select "

            if (cat != "All")
            {
                query = "select * from ExpenseTbl where ExpUser='" + loginpage.loginuser + "' and ExpCat='" + cat + "'";
            }
            else
            {
                query = "select * from ExpenseTbl where ExpUser='" + loginpage.loginuser + "'";
            }
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpensesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-T7A47N7V;Initial Catalog=demo;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            viewincome Obj = new viewincome();
            Obj.Show();
            this.Hide();
        }

        private void label35_Click(object sender, EventArgs e)
        {
            income Obj = new income();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            loginpage Obj = new loginpage();
            Obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form2 Obj = new Form2();
            Obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cat = comboBox1.SelectedItem.ToString();
            //MessageBox.Show(cat);
            DisplayExpenses();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void viewexpenses_Load(object sender, EventArgs e)
        {

        }
    }
}
