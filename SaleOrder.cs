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
    public partial class SaleOrder : Form
    {
        int counter = 0;
        string[] prds = new string[50];
        int[] qty = new int[50];



        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        int total = 0;
        public SaleOrder()
        {
            InitializeComponent();
        }

        private void SaleOrder_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select CGroup from Client;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CGroup"]);
            }
            mc.conn.Close();


            {
                mc = new MyConnection();
                mc.conn.Open();
                cmd = new OleDbCommand("select CID from Client ", mc.conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["CID"]);
                }
                mc.conn.Close();
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int c = 0;
            mc.conn.Open();
            cmd = new OleDbCommand("select count(SOID) from SO where CDept='" + comboBox1.Text + "'", mc.conn);
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
            cmd = new OleDbCommand("select * from Client where CID='" + comboBox2.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Cname"].ToString();
                textBox2.Text = dr["PH1"].ToString();

                textBox4.Text = dr["ContectPerson"].ToString();
                textBox5.Text = dr["CPPH"].ToString();
                textBox13.Text = dr["CAddress"].ToString();

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
                OleDbCommand cmd = new OleDbCommand("insert into SoProducts (SOID,Pid,PQty,TotalPrice) values(@SOID,@Pid,@PQty,@TotalPrice)", mc.conn);
                cmd.Parameters.AddWithValue("@SOID", textBox9.Text);
                cmd.Parameters.AddWithValue("@Pid", comboBox3.Text);
                cmd.Parameters.AddWithValue("@PQty", textBox8.Text);
                cmd.Parameters.AddWithValue("@TotalPrice", textBox12.Text);
                cmd.ExecuteNonQuery();
            }
            mc.conn.Close();
            mc.conn.Open();
            for (int i = 0; i < counter; i++)
            {

                OleDbCommand cmd1 = new OleDbCommand("INSERT INTO SO(SOID,DCDate,Status,CDept,CName,CID,CContectPerson,CCPPH,TotalAmount,Approve)VALUES(@SOID,@DCDate,@Status,@CDept,@CName,@CID,@CContectPerson,@CCPPH,@TotalAmount,@Approve)", mc.conn);
                cmd1.Parameters.AddWithValue("@SOID", textBox9.Text);
                cmd1.Parameters.AddWithValue("@DCDate", dateTimePicker1.Text);
                cmd1.Parameters.AddWithValue("@Status", textBox3.Text);
                cmd1.Parameters.AddWithValue("@CDept", comboBox1.Text);
                cmd1.Parameters.AddWithValue("@CName", textBox1.Text);
                cmd1.Parameters.AddWithValue("@CID", comboBox2.Text);
                cmd1.Parameters.AddWithValue("@CContectPerson", textBox4.Text);
                cmd1.Parameters.AddWithValue("@CCPPH", textBox5.Text);
                cmd1.Parameters.AddWithValue("@TotalAmount", textBox12.Text);
                cmd1.Parameters.AddWithValue("@Approve", textBox14.Text);

                cmd1.ExecuteNonQuery();
            }
            mc.conn.Close();
            MessageBox.Show("Transaction done!!");
        }
    }
}
