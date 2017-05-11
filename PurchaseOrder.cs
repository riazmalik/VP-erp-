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
    public partial class PurchaseOrder : Form

    {
        int counter = 0;
        string[] prds = new string[50];
        int[] qty = new int[50];
        
    

        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        int total = 0;

        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select VGroup from Vendor;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Vgroup"]);
            }
            mc.conn.Close();


            {
                mc = new MyConnection();
                mc.conn.Open();
                cmd = new OleDbCommand("select VID from Vendor;", mc.conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["VID"]);
                }
                mc.conn.Close();
            }

            {
                mc = new MyConnection();
                mc.conn.Open();
                cmd = new OleDbCommand("select Pid from Products;", mc.conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["Pid"]);
                }
                mc.conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int c = 0;
            mc.conn.Open();
            cmd = new OleDbCommand("select count(POID) from PO where VDept='" + comboBox1.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            if (comboBox1.Text == "Consumer")
            {
                textBox9.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox1.Text == "HR")
            {
                textBox9.Text = "HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox1.Text == "Marketing")
            {
                textBox9.Text = "Mark-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox1.Text == "Sales")
            {
                textBox9.Text = "Sal-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            mc.conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            mc.conn.Open();
            cmd = new OleDbCommand("select * from Vendor where VID='" + comboBox2.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["VName"].ToString();
                textBox2.Text = dr["PH1"].ToString();
                
                textBox4.Text = dr["CPName"].ToString();
                textBox5.Text = dr["CPPH"].ToString();
                textBox13.Text = dr["VAddress"].ToString();
                
            }
            mc.conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new OleDbCommand("select * from Products where Pid='" + comboBox3.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox6.Text = dr["PName"].ToString();
                textBox7.Text = dr["BasePrice"].ToString();
            }
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            textBox10.Text += comboBox3.Text + Environment.NewLine;
            textBox11.Text += textBox8.Text + Environment.NewLine;
            prds[counter] = comboBox3.Text;
            qty[counter] = Convert.ToInt32(textBox8.Text);
            counter++;
            total += Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox8.Text);
            textBox12.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
for (int i = 0; i < counter; i++)
{
    OleDbCommand cmd = new OleDbCommand("insert into PoProducts (POID,Pid,PQty,TotalPrice) values(@POID,@Pid,@PQty,@TotalPrice)", mc.conn);
cmd.Parameters.AddWithValue("@POID", textBox9.Text);
cmd.Parameters.AddWithValue("@Pid", comboBox3.Text);
cmd.Parameters.AddWithValue("@PQty", textBox8.Text);
cmd.Parameters.AddWithValue("@TotalPrice", textBox12.Text);
cmd.ExecuteNonQuery();
}
mc.conn.Close();
mc.conn.Open();
for (int i = 0; i < counter; i++)
{

    OleDbCommand cmd1 = new OleDbCommand("INSERT INTO PO(POID,DDate,Status,VDept,VName,VID,VContectPerson,VCPPH,TotalAmount,Approve)VALUES(@POID,@DDate,@Status,@VDept,@VName,@VID,@VContectPerson,@VCPPH,@TotalAmount,@Approve)", mc.conn);
    cmd1.Parameters.AddWithValue("@POID", textBox9.Text);
    cmd1.Parameters.AddWithValue("@DDate", dateTimePicker1.Text);
    cmd1.Parameters.AddWithValue("@Status", textBox3.Text );
    cmd1.Parameters.AddWithValue("@VDept", comboBox1.Text);
    cmd1.Parameters.AddWithValue("@VName", textBox1.Text);
    cmd1.Parameters.AddWithValue("@VID", comboBox2.Text);
    cmd1.Parameters.AddWithValue("@VContectPerson", textBox4.Text);
    cmd1.Parameters.AddWithValue("@VCPPH", textBox5.Text);
    cmd1.Parameters.AddWithValue("@TotalAmount", textBox12.Text);
    cmd1.Parameters.AddWithValue("@Approve", textBox14.Text);
   
    cmd1.ExecuteNonQuery();
}
mc.conn.Close();
MessageBox.Show("Transaction done!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
