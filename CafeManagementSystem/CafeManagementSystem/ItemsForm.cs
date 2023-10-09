using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class ItemsForm : Form
    {
        public ItemsForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\OneDrive\文件\Cafedb.mdf;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            Console.WriteLine("Getting db data");
            Con.Open();
            string query = "select * from ItemTbl";
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
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm uform = new UsersForm();
            uform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder uorder = new UserOrder();
            uorder.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add Button
            if (ItemNameTb.Text == "" || ItemNumTb.Text=="" || ItemPriceTb.Text=="")
            {
                MessageBox.Show("Please fill in all the fields.");
            }
            else
            {
                Guid myuuid = Guid.NewGuid();
                string myuuidAsString = myuuid.ToString();
                Con.Open();
                string query = "INSERT INTO ItemTbl VALUES('" + myuuidAsString + "','" + ItemNumTb.Text + "','" + ItemNameTb.Text + "','" + CatCb.Text + "'," + ItemPriceTb.Text +  ")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Successfully Created!");
                Con.Close();
                populate(); 
            };
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            populate();
        }
        public static string id;
        private void button5_Click(object sender, EventArgs e)
        {
            //Edit Button
            if (id == null)
            {
                MessageBox.Show("Please select the item to be edited.");
            }
            else if (ItemNameTb.Text == "" || ItemNumTb.Text == "" || ItemPriceTb.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.");
            }
            else
            {
                Con.Open();
                string query = "UPDATE ItemTbl SET ItemNum = '" + ItemNumTb.Text + "', ItemName='" + ItemNameTb.Text + "', ItemCat = '" + CatCb.Text +"', ItemPrice = " + ItemPriceTb.Text + " WHERE Id = '" + id.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Edited.");
                Con.Close();
                populate();
            }
        }

        private void ItemsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = ItemsGV.SelectedRows[0].Cells[0].Value.ToString();
            ItemNumTb.Text = ItemsGV.SelectedRows[0].Cells[1].Value.ToString();
            ItemNameTb.Text = ItemsGV.SelectedRows[0].Cells[2].Value.ToString();
            CatCb.Text = ItemsGV.SelectedRows[0].Cells[3].Value.ToString();
            ItemPriceTb.Text = ItemsGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Delete Button
            if (id == null)
            {
                MessageBox.Show("Please select the item to be deleted.");
            }
            else if (ItemNameTb.Text == "" || ItemNumTb.Text == "" || ItemPriceTb.Text == "")
            {
                MessageBox.Show("Please select the item to be deleted.");
            }
            else
            {
                Con.Open();
                string query = "DELETE FROM ItemTbl WHERE id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Successfully Deleted.");
                Con.Close();
                populate();
            }
        }
    }
}
