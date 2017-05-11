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
    public partial class VSearch : Form
    {

        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        public VSearch()
        {
            InitializeComponent();
        }

        private void VSearch_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select VID from Vendor;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]);
            }
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            mc.conn.Open();
            cmd = new OleDbCommand("select * from Vendor where VID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["VGroup"].ToString();
                textBox2.Text = dr["Vname"].ToString();
                textBox3.Text = dr["VCity"].ToString();
                textBox5.Text = dr["VEmail"].ToString();
                textBox12.Text = dr["VAddress"].ToString();
                textBox7.Text = dr["PH1"].ToString();
                textBox8.Text = dr["PH2"].ToString();
                textBox9.Text = dr["VFax"].ToString();
                textBox10.Text = dr["CPName"].ToString();
                textBox11.Text = dr["CPPH"].ToString();
                textBox4.Text = dr["VCode"].ToString();
                textBox6.Text = dr["VStatus"].ToString();
            }
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            mc.conn.Open();
cmd = new OleDbCommand("update Vendor set VStatus='Active';",mc.conn);
cmd.ExecuteNonQuery();

textBox6.Text = "Active";
mc.conn.Close();
MessageBox.Show("Status Changed!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        }
    }

