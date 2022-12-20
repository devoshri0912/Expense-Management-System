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

namespace project
{
    public partial class Form2 : Form
    {
        public static int id;
        public Form2()
        {
            InitializeComponent();
            getuid();
            DisplayIncomes();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getuid()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select UId from UserTbl where UName='" + loginpage.loginuser + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            id = Convert.ToInt32(dt.Rows[0][0]);
            Con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
      

        }
        private void DisplayIncomes()
        {
            Con.Open();
            string query = "select * from SaveTbl where UId='" +id+ "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SavingsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-T7A47N7V;Initial Catalog=demo;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int sav = int.Parse(textBox2.Text)*100;
            float per = (sav / Form1.x); 
            //MessageBox.Show(per.ToString());

            textBox3.Text = per.ToString()+ "%";

            Con.Open();
            SqlCommand cmd = new SqlCommand("insert into SaveTbl(Save_Goal,Save_Name,UId,Save_Per)values(@SG,@SN,@UI,@SP)", Con);
            cmd.Parameters.AddWithValue("@SG", textBox2.Text);
            cmd.Parameters.AddWithValue("@SN", textBox1.Text);
            cmd.Parameters.AddWithValue("@UI", id.ToString());
            cmd.Parameters.AddWithValue("@SP", textBox3.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Goal Added");
            Con.Close();
            DisplayIncomes();
            Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form2 Obj = new Form2();
            Obj.Show();
            this.Hide();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void label35_Click(object sender, EventArgs e)
        {
            income Obj = new income();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           viewincome Obj = new viewincome();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            viewexpenses Obj = new viewexpenses();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            loginpage Obj = new loginpage();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }
    }
}
