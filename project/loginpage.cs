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
    public partial class loginpage : Form
    {
        public static string loginuser;
       /* public static string loginDob;
        public static string loginPhone;
        public static string loginPass;
        public static string loginAdd;*/


        public loginpage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginpage_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-T7A47N7V;Initial Catalog=demo;Integrated Security=True");
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            loginuser = UnameTb.Text;
        Con.Open();
            SqlDataAdapter sda= new SqlDataAdapter("select count(*) from UserTbl where UName='"+UnameTb.Text+"' and UPass='"+PasswordTb.Text+"' ",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form1 Obj = new Form1();
                Obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
                UnameTb.Text = "";
                PasswordTb.Text = "";
            }
            Con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
