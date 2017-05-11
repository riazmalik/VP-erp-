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
    public partial class ApproveSo : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        public ApproveSo()
        {
            InitializeComponent();
        }

        private void ApproveSo_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select SOID from SO where Approve='Not Approve';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["SOID"]);
            }
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new OleDbCommand("select * from SO where SOID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["CID"].ToString();
                textBox2.Text = dr["DCDate"].ToString();
            }
            mc.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            mc.conn.Open();
            cmd = new OleDbCommand("update SO set Approve='Approve';", mc.conn);
            cmd.ExecuteNonQuery();

            textBox3.Text = "Approve";
            mc.conn.Close();
            MessageBox.Show("Sale Order Approved!");
        }
    }
}
