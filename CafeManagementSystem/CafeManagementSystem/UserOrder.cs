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
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class UserOrder : Form
    {
        public UserOrder()
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
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsForm iform = new ItemsForm();
            iform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm uform = new UsersForm();
            uform.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int num, amount = 0;
        int price, qty, total;
        string item, cat, itemName;
        private void button1_Click(object sender, EventArgs e)
        {
            if(QuantityTb.Text == "")
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
            AmtLbl.Text = amount.ToString();
        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterByCategory();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Place The Order Button
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();
            Con.Open();
            string query = "INSERT INTO OrderTbl VALUES('" + myuuidAsString + "','" + OrderNumTb.Text + "','" + Datelbl.Text + "','" + SellerNameTb.Text + "', '" + AmtLbl.Text + "')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Order Successfully Created!");
            Con.Close();
            // Refresh the data
            populate();
            populateOrders();
        }

        private void OrdersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        DataTable table = new DataTable();
        int flag = 0;
        private void UserOrder_Load(object sender, EventArgs e)
        {
            populate();
            // Setting Orders Grid View data
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("UnitPrice", typeof(int));
            table.Columns.Add("Total", typeof(int));
            OrdersGV.DataSource = table;
            populateOrders();
            // Setting date label
            Datelbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
            // Replace the text of Seller TextBox to user name
            SellerNameTb.Text = Dashboard.user;
        }
        private void ItemGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemName = ItemsGV.SelectedRows[0].Cells[2].Value.ToString();
            cat = ItemsGV.SelectedRows[0].Cells[3].Value.ToString();
            price = Convert.ToInt32(ItemsGV.SelectedRows[0].Cells[4].Value.ToString());
            flag = 1;
       }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
