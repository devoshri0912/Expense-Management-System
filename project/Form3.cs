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
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-T7A47N7V;Initial Catalog=demo;Integrated Security=True");


        private void label1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("DeleteAct",Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", loginpage.loginuser);
            MessageBox.Show("Account Deleted!");
            cmd.ExecuteNonQuery();
            Con.Close();
            loginpage obj = new loginpage();
            obj.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void Form3_Load(object sender, EventArgs e)
        {
            label10.Text = loginpage.loginuser;
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select UDob,UPhone,UAddress,UId from UserTbl where UName='" + loginpage.loginuser + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label11.Text = dt.Rows[0][0].ToString();
            label12.Text = dt.Rows[0][1].ToString();
            label13.Text = dt.Rows[0][2].ToString();
            label9.Text = dt.Rows[0][3].ToString();
            //TotIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            loginpage Obj = new loginpage();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
