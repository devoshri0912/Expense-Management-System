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
    public partial class viewincome : Form
    {
        public static string cat;
        public viewincome()
        {
            InitializeComponent();
            //DisplayIncomes();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
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

        private void label5_Click(object sender, EventArgs e)
        {
            viewexpenses Obj = new viewexpenses();
            Obj.Show();
            this.Hide();
        }
        private void DisplayIncomes()
        {
            Con.Open();
            string query; //= "select * from IncomeTbl where IncUser='" + loginpage.loginuser + "'";
            //string query = "select "

            if(cat!="All")
            {
                 query = "select * from IncomeTbl where IncUser='" + loginpage.loginuser + "' and IncCat='"+cat+"'";
            }
            else
            {
                query = "select * from IncomeTbl where IncUser='" + loginpage.loginuser + "'";
            }

            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-T7A47N7V;Initial Catalog=demo;Integrated Security=True");

        private void IncomeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            loginpage Obj = new loginpage();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
            DisplayIncomes();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }
    }
}
