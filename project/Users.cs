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
using Microsoft.VisualBasic;

namespace project
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-T7A47N7V;Initial Catalog=demo;Integrated Security=True");
        private void Clear()
        {
            UnameTb.Text = "";
            PhoneTb.Text = "";
            PasswordTb.Text = "";
            AddressTb.Text = "";
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {




            if(UnameTb.Text== ""|| PhoneTb.Text== ""|| PasswordTb.Text== ""|| AddressTb.Text== "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("CheckUser",Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@temp", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@name", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@dob", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@phone", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@password",PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@add", AddressTb.Text);

                    IDbDataParameter msg = cmd.CreateParameter();
                    msg.ParameterName = "@msg";
                    msg.Direction = System.Data.ParameterDirection.Output;
                    msg.DbType = System.Data.DbType.Int32;
                    cmd.Parameters.Add(msg);
                    cmd.ExecuteNonQuery();

                   

                    
                   
                    //MessageBox.Show(msg.Value.ToString());
                    if((int)msg.Value==1)
                    {
                        MessageBox.Show("User Already Exists");
                    }
                    else
                    {
                        MessageBox.Show("User Added");
                    }
                    
                    
                    Con.Close();
                    Clear();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            loginpage Obj = new loginpage();
            Obj.Show();
            this.Hide();
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
    }
}
