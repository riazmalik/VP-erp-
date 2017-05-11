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
    public partial class DChalan : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        string vname, dcdate;

        public DChalan()
        {
            InitializeComponent();
        }

        private void GDN_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select SOID from SO where Approve='Approve' and Status='Open';", mc.conn);
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
            cmd = new OleDbCommand("select * from SOProducts where SOID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr["Pid"].ToString() + Environment.NewLine;
                textBox2.Text += dr["PQty"].ToString() + Environment.NewLine;
            }
            // GRN ID
            textBox3.Text = "GDC-" + comboBox1.Text;
            mc.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();

            cmd = new OleDbCommand("Insert into DChalan(GDCID,BaseDocument,Status,GDDate) values(@GDCID,@BaseDocument,@Status,@GDDate)", mc.conn);
            cmd.Parameters.AddWithValue("@GDCID", textBox3.Text);
            cmd.Parameters.AddWithValue("@BaseDocument", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Status", "Open");
            cmd.Parameters.AddWithValue("@GDDate", System.DateTime.Today.Date.ToString());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delievry Chalan  Generate Completed ");

            cmd = new OleDbCommand("Select * from SO where SOID = '" + comboBox1.Text + "'", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                vname = dr["CName"].ToString();
                dcdate = dr["DCDate"].ToString();

                cmd = new OleDbCommand("Update DChalan Set CName='" + dr["CName"].ToString() + "', DCDAte = '" + dr["DCDate"].ToString() + "' where DChalanID = '" + textBox3.Text + "' ", mc.conn);
                cmd.ExecuteReader();
                MessageBox.Show("Delievry Chalan Complete");
                cmd = new OleDbCommand("Update SO set Status = 'Close' where SOID ='" + comboBox1.Text + "'");
                MessageBox.Show("SO status Close");
            }
            mc.conn.Close();
        }
    }
}
