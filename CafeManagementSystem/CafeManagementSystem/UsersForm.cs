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
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "insert into UsersTbl values('"+UnameTb.Text+"','"+UphoneTb.Text+"','" +UpasswordTb.Text+"')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Successfully Created!");
            Con.Close();
        }

        private void ItemGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
