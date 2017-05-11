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
    public partial class GRN : Form
    {

        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        string vname, ddate;


        public GRN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GRN_Load(object sender, EventArgs e)
        {
            // GRN ID 
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select POID from PO where Approve='Approve' and Status='Open';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["POID"]);
            }
            mc.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

           

            
            // PModel PQTY
            mc.conn.Open();
            cmd = new OleDbCommand("select * from POProducts where POID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr["Pid"].ToString()+Environment.NewLine;
                textBox2.Text += dr["PQty"].ToString()+ Environment.NewLine;
            }
            // GRN ID
            textBox3.Text = "GRN-" + comboBox1.Text;
            mc.conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // vName , DDate
            /*mc = new MyConnection();
            mc.conn.Open();

            cmd = new OleDbCommand("Select * from PO where POID = '"+comboBox1.Text+"'",mc.conn);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                vname = dr["VName"].ToString();
                ddate = dr["DDate"].ToString();

            }*/
            

            // GRN Data Insertion
            mc = new MyConnection();
            mc.conn.Open();

            cmd = new OleDbCommand("Insert into GRN(GRNID,BaseDocument,Status,GRDate) values(@GRNID,@BaseDocument,@Status,@GRDate)", mc.conn);
            cmd.Parameters.AddWithValue("@GRNID",textBox3.Text);
            cmd.Parameters.AddWithValue("@BaseDocument",comboBox1.Text);
            cmd.Parameters.AddWithValue("@Status","Open");
            cmd.Parameters.AddWithValue("@GRDate",System.DateTime.Today.Date.ToString());
            cmd.ExecuteNonQuery();
            MessageBox.Show("GRN Generate Completed ");

            cmd = new OleDbCommand("Select * from PO where POID = '"+comboBox1.Text+"'",mc.conn);
             dr = cmd.ExecuteReader();
             if (dr.Read())
             {
                 vname = dr["VName"].ToString();
                 ddate = dr["DDate"].ToString();

                 cmd = new OleDbCommand("Update GRN Set VName='" + dr["VName"].ToString() + "', DDAte = '" + dr["DDate"].ToString() + "' where GRNID = '" + textBox3.Text + "' ", mc.conn);
                 cmd.ExecuteReader();
                 MessageBox.Show("GRN table Complete");
                 cmd = new OleDbCommand("Update PO set Status = 'Close' where POID ='"+comboBox1.Text+"'");
                 MessageBox.Show("PO status Close");
             }
            mc.conn.Close();
        }
    }
}
