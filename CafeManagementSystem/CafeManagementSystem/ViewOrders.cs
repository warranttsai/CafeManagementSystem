using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\OneDrive\文件\Cafedb.mdf;Integrated Security=True;Connect Timeout=30");
        void populateOrders()
        {
            Console.WriteLine("Getting db data");
            Con.Open();
            string query = "SELECT * FROM OrderTbl ";
            System.Console.WriteLine(query);
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            // Verify if the dataset contains any data
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Printing the retrieved data in the grid view
                OrdersGV.DataSource = ds.Tables[0];
                Console.WriteLine("Order retrieved successfully.");
            }
            else
            {
                Console.WriteLine("No order found in the database.");
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
                OrdersGV.DataSource = ds.Tables[0];
            }
            else
            {
                Console.WriteLine("No data found in the database.");
            }
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            populateOrders();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filterByCategory();
        }

        private void OrdersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
