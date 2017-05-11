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
    public partial class CSearch : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        public CSearch()
        {
            InitializeComponent();
        }

        private void CSearch_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select CID from Client;", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]);
            }
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new OleDbCommand("select * from Client where CID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox12.Text = dr["CGroup"].ToString();
                textBox2.Text = dr["Cname"].ToString();
                textBox4.Text = dr["City"].ToString();
                textBox5.Text = dr["CEmail"].ToString();
                textBox6.Text = dr["CAddress"].ToString();
                textBox7.Text = dr["PH1"].ToString();
                textBox8.Text = dr["PH2"].ToString();
                textBox9.Text = dr["CreditLimit"].ToString();
                textBox1.Text = dr["ContectPerson"].ToString();
                textBox10.Text = dr["CPPH"].ToString();
            }
            mc.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new OleDbCommand("update Client set CStatus='Active';", mc.conn);
            cmd.ExecuteNonQuery();

            textBox3.Text = "Active";
            mc.conn.Close();
            MessageBox.Show("Status has been activated...!");
        }
    }
}
