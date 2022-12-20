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
    public partial class Form1 : Form
    {
        public static int x;
        public static int Inc;
        public static int Exp;
        public Form1()
        {
            InitializeComponent();
            GetTotInc();
            GetTotExp();
            GetNumInc();
            GetNumExp();
            GetIncLDate();
            GetExpLDate();
            GetMaxInc();
            GetMaxExp();
            GetMinInc();
            GetMinExp();
            GetMaxExpCat();
            GetMaxIncCat();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
      
        private void label4_Click(object sender, EventArgs e)
        {
            viewincome Obj = new viewincome();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-T7A47N7V;Initial Catalog=demo;Integrated Security=True");

        private void GetTotInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + loginpage.loginuser + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Inc = Convert.ToInt32(dt.Rows[0][0]);
                TotIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch(Exception ex)
            {
                Con.Close();
            }

        }
        private void GetTotExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser='" + loginpage.loginuser + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Exp = Convert.ToInt32(dt.Rows[0][0]);
                TotExpLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                x = Inc- Exp;
                BalanceLbl.Text = x.ToString();
                Con.Close();
            }
            catch(Exception ex)
            {
                Con.Close();
            }

        }
       
        private void GetNumInc()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from IncomeTbl where IncUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            NumIncLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }

        private void GetNumExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ExpenseTbl where ExpUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            NumExpLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetIncLDate()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncDate) from IncomeTbl where IncUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DateIncLbl.Text = dt.Rows[0][0].ToString();
            LastIncLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetExpLDate()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpDate) from ExpenseTbl where ExpUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DateExpLbl.Text = dt.Rows[0][0].ToString();
            LastExpLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetMaxInc()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTbl where IncUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MaxIncLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetMaxExp()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpAmt) from ExpenseTbl where ExpUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MaxExpLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetMinInc()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(IncAmt) from IncomeTbl where IncUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MinIncLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetMinExp()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(ExpAmt) from ExpenseTbl where ExpUser='"+loginpage.loginuser+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MinExpLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetMaxExpCat()
        {
            Con.Open();
           /* string InnerQuery = "select Max(ExpAmt) from ExpenseTbl";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
            sda1.Fill(dt1);*/
            string Query= "select ExpCat from ExpenseTbl where ExpAmt in(select Min(ExpAmt) from ExpenseTbl)";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            sda.Fill(dt);
            BestExpCatLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void GetMaxIncCat()
        {
            Con.Open();
           /* string InnerQuery = "select Max(IncAmt) from IncomeTbl";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
            sda1.Fill(dt1);*/
            string Query = "select IncCat from IncomeTbl where IncAmt in (select Max(IncAmt) from IncomeTbl)";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            sda.Fill(dt);
            BestIncCatLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IncLbl_Click(object sender, EventArgs e)
        {
            income Obj = new income();
            Obj.Show();
            this.Hide();
        }

        private void ExpLbl_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses(); 
            Obj.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            viewexpenses Obj = new viewexpenses(); 
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            loginpage Obj = new loginpage();
            Obj.Show();
            this.Hide();
        }

        private void TotIncLbl_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 Obj = new Form2();
            Obj.Show();
            this.Hide();
        }

        private void TotExpLbl_Click(object sender, EventArgs e)
        {

        }

        private void MaxIncLbl_Click(object sender, EventArgs e)
        {

        }

        private void NumExpLbl_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }
    }
}