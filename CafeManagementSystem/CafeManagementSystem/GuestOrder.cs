using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class GuestOrder : Form
    {
        public GuestOrder()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\OneDrive\文件\Cafedb.mdf;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            Console.WriteLine("Getting db data");
            Con.Open();
            string query = "SELECT * FROM ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            // Verify if the dataset contains any data
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Printing the retrieved data in the grid view
                ItemsGV.DataSource = ds.Tables[0];
                Console.WriteLine("Data retrieved successfully.");
            }
            else
            {
                Console.WriteLine("No data found in the database.");
            }
            Con.Close();
        }
        void filterByCategory()
        {
            Console.WriteLine("Filtering DB data");
            Con.Open();
            string query = "SELECT * FROM ItemTbl WHERE ItemCat = '" + CatCb.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            // Verify if the dataset contains any data
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ItemsGV.DataSource = ds.Tables[0];
            }
            else
            {
                Console.WriteLine("No data found in the database.");
            }
            Con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        int num, amount = 0;
        int price, qty, total;
        DataTable table = new DataTable();
        int flag = 0;
        int sum = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (QuantityTb.Text == "")
            {
                MessageBox.Show("What is the Quantity of item?");
            }
            else if (flag == 0)
            {
                MessageBox.Show("Select The Product To Be Ordered.");
            }
            else
            {
                num = num + 1;
                total = price * Convert.ToInt32(QuantityTb.Text);
                table.Rows.Add(num, itemName, cat, price, total);
                OrdersGV.DataSource = table;
                flag = 0;
            }
            amount = amount + total;
            LabelAmount.Text = " AUD" + amount.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ItemsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemName = ItemsGV.SelectedRows[0].Cells[2].Value.ToString();
            cat = ItemsGV.SelectedRows[0].Cells[3].Value.ToString();
            price = Convert.ToInt32(ItemsGV.SelectedRows[0].Cells[4].Value.ToString());
            flag = 1;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        string item, cat, itemName;
        private void GuestOrder_Load(object sender, EventArgs e)
        {
            populate();
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("UnitPrice", typeof(int));
            table.Columns.Add("Total", typeof(int));
            OrdersGV.DataSource = table;
            Datelbl.Text = DateTime.Today.Date.ToString();
        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterByCategory();
        }
    }
}
