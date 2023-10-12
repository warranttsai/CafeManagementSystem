namespace CafeManagementSystem
{
    partial class ViewOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.AmtLbl = new System.Windows.Forms.Label();
            this.LabelAmount = new System.Windows.Forms.Label();
            this.OrdersGV = new System.Windows.Forms.DataGridView();
            this.ListOfOrdersLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.OrdersGV);
            this.panel1.Controls.Add(this.ListOfOrdersLbl);
            this.panel1.Controls.Add(this.AmtLbl);
            this.panel1.Controls.Add(this.LabelAmount);
            this.panel1.Location = new System.Drawing.Point(100, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 436);
            this.panel1.TabIndex = 13;
            // 
            // AmtLbl
            // 
            this.AmtLbl.AutoSize = true;
            this.AmtLbl.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmtLbl.ForeColor = System.Drawing.Color.DarkBlue;
            this.AmtLbl.Location = new System.Drawing.Point(512, 405);
            this.AmtLbl.Name = "AmtLbl";
            this.AmtLbl.Size = new System.Drawing.Size(0, 24);
            this.AmtLbl.TabIndex = 41;
            // 
            // LabelAmount
            // 
            this.LabelAmount.AutoSize = true;
            this.LabelAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAmount.ForeColor = System.Drawing.Color.DarkBlue;
            this.LabelAmount.Location = new System.Drawing.Point(448, 403);
            this.LabelAmount.Name = "LabelAmount";
            this.LabelAmount.Size = new System.Drawing.Size(0, 18);
            this.LabelAmount.TabIndex = 18;
            // 
            // OrdersGV
            // 
            this.OrdersGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersGV.Location = new System.Drawing.Point(149, 42);
            this.OrdersGV.Name = "OrdersGV";
            this.OrdersGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersGV.Size = new System.Drawing.Size(363, 338);
            this.OrdersGV.TabIndex = 43;
            // 
            // ListOfOrdersLbl
            // 
            this.ListOfOrdersLbl.AutoSize = true;
            this.ListOfOrdersLbl.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListOfOrdersLbl.ForeColor = System.Drawing.Color.DarkBlue;
            this.ListOfOrdersLbl.Location = new System.Drawing.Point(262, 15);
            this.ListOfOrdersLbl.Name = "ListOfOrdersLbl";
            this.ListOfOrdersLbl.Size = new System.Drawing.Size(142, 24);
            this.ListOfOrdersLbl.TabIndex = 42;
            this.ListOfOrdersLbl.Text = "List Of Orders";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(763, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 27);
            this.label7.TabIndex = 44;
            this.label7.Text = "X";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(293, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 25);
            this.button1.TabIndex = 44;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewOrders";
            this.Load += new System.EventHandler(this.ViewOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AmtLbl;
        private System.Windows.Forms.Label LabelAmount;
        private System.Windows.Forms.DataGridView OrdersGV;
        private System.Windows.Forms.Label ListOfOrdersLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}