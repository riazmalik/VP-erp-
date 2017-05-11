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
    public partial class ApprovePO : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        public ApprovePO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApprovePO_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select POID from PO where Approve='Not Approve';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["POID"]);
            }
            mc.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new OleDbCommand("select * from PO where POID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Vid"].ToString();
                textBox2.Text = dr["DDate"].ToString();
            }
            mc.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            mc.conn.Open();
            cmd = new OleDbCommand("update PO set Approve='Approve';", mc.conn);
            cmd.ExecuteNonQuery();

            textBox3.Text = "Approve";
            mc.conn.Close();
            MessageBox.Show("Purchase Order Approved!");
        }
    }
}
