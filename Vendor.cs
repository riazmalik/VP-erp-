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
    public partial class Vendor : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        public Vendor()
        {
            InitializeComponent();
        }

        private void Vendor_Load(object sender, EventArgs e)
        {

            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select GrpName from CusGroup;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GrpName"]);
            }
            mc.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            mc.conn.Open();
cmd = new OleDbCommand("Insert into Vendor(VID,Vname,VAddress,VCity,VCode,PH1,PH2,VEmail,CPName,CPPH,VFax,VGroup,VStatus) values(@VID,@Vname,@VAddress,@VCity,@VCode,@PH1,@PH2,@VEmail,@CPName,@CPPH,@VFax,@VGroup,@VStatus);", mc.conn);
cmd.Parameters.AddWithValue("@VID", textBox1.Text);
cmd.Parameters.AddWithValue("@Vname", textBox2.Text);
cmd.Parameters.AddWithValue("@VAddress", textBox12.Text);
cmd.Parameters.AddWithValue("@VCity", textBox3.Text);
cmd.Parameters.AddWithValue("@VCode", textBox4.Text);
cmd.Parameters.AddWithValue("@PH1", textBox7.Text);
cmd.Parameters.AddWithValue("@PH2", textBox8.Text);
cmd.Parameters.AddWithValue("@VEmail", textBox5.Text);
cmd.Parameters.AddWithValue("@CPName", textBox10.Text);
cmd.Parameters.AddWithValue("@CPPH", textBox11.Text);
cmd.Parameters.AddWithValue("@VFax", textBox9.Text);
cmd.Parameters.AddWithValue("@VGroup", comboBox1.Text);
cmd.Parameters.AddWithValue("@VStatus", textBox6.Text);
cmd.ExecuteNonQuery();
mc.conn.Close();
MessageBox.Show("Record has been inserted");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             int c = 0;
            mc.conn.Open();
            cmd = new OleDbCommand("select count(VID) from Vendor where VGroup='" + comboBox1.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }
            if (comboBox1.Text == "Consumer")
            {
                textBox1.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox1.Text == "HR")
            {
                textBox1.Text = "HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox1.Text == "Marketing")
            {
                textBox1.Text = "Mark-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox1.Text == "Sales")
            {
                textBox1.Text = "Sal-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            mc.conn.Close();
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

