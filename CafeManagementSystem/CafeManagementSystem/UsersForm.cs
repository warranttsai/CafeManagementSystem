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
using static System.Net.Mime.MediaTypeNames;

namespace CafeManagementSystem
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\OneDrive\文件\Cafedb.mdf;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            Console.WriteLine("Getting db data");
            Con.Open();
            string query = "select * from UsersTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            // Verify if the dataset contains any data
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Printing the retrieved data in the grid view
                UsersGV.DataSource = ds.Tables[0];
                Console.WriteLine("Data retrieved successfully.");
            }
            else
            {
                Console.WriteLine("No data found in the database.");
            }
            Con.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder uorder = new UserOrder();
            uorder.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsForm iform = new ItemsForm();
            iform.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "insert into UsersTbl values('" + UnameTb.Text + "','" + UphoneTb.Text + "','" + UpasswordTb.Text + "')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Successfully Created!");
            Con.Close();
            populate();
        }

        private void ItemGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
            UphoneTb.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            UpasswordTb.Text = UsersGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            populate();
            Datelbl.Text = DateTime.Today.Date.ToString();
        }

        private void UnameTb_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (UphoneTb.Text == "")
            {
                MessageBox.Show("Select The User to be Deleted.");
            }
            else
            {
                Con.Open();
                string query = "DELETE FROM UsersTbl WHERE Uphone = '" + UphoneTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted.");
                Con.Close();
                populate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (UphoneTb.Text == "" || UpasswordTb.Text == "" || UnameTb.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.");
            } else
            {
                Con.Open();
                string query = "UPDATE UsersTbl SET Uname = '" + UnameTb.Text + "', Upassword='"+ UpasswordTb.Text +"', Uphone = '" + UphoneTb.Text + "' WHERE Uphone = '" + UphoneTb.Text +"'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Edited.");
                Con.Close();
                populate();
            }
        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
