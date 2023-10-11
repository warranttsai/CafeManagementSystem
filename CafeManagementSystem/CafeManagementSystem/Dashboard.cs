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

namespace CafeManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\OneDrive\文件\Cafedb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder guest = new GuestOrder();
            guest.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this.Hide();
            // UserOrder uorder = new UserOrder();
            // uorder.Show();
            if(UnameTb.Text == "" || PasswordTb.Text =="")
            {
                MessageBox.Show("Enter A Username Or Password.");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT count(*) FROM UsersTbl WHERE Uname='" +UnameTb.Text+"' and Upassword='"+PasswordTb.Text+"'",Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    UserOrder uorder = new UserOrder();
                    uorder.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Wrong Username or Password.");
                }
                Con.Close();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void UnameTb_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
