using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication2
{
    public partial class Product : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        int cn = 0;
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("INSERT INTO products(Pid,PName,BasePrice,WeightInPounds,InventoryStatus,EstimatedDelivery,AmountOnHand,WarrentyPeriod,ProductType)Values(@Pid,@PName,@BasePrice,@WeightInPounds,@InventoryStatus,@EstimatedDelivery,@AmountOnHand,@WarrentyPeriod,@ProductType)", mc.conn);
            cmd.Parameters.AddWithValue("@Pid", textBox10.Text);
            cmd.Parameters.AddWithValue("@PName", textBox12.Text);
            cmd.Parameters.AddWithValue("@BasePrice", textBox11.Text);
            cmd.Parameters.AddWithValue("@WeightInPounds", textBox13.Text);
            cmd.Parameters.AddWithValue("@InventoryStatus", textBox14.Text);
            cmd.Parameters.AddWithValue("@EstimatedDelivery", textBox15.Text);
            cmd.Parameters.AddWithValue("@AmountOnHand", textBox16.Text);
            cmd.Parameters.AddWithValue("@WarrentyPeriod", textBox17.Text);
            cmd.Parameters.AddWithValue("@ProductType", textBox18.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sucessfully Added Product!!");
            mc.conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox10.Text = textBox12.Text+"00"+ cn++.ToString();
        }
    }
}
