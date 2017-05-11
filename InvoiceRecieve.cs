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
    public partial class InvoiceRecieve : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        string SOID, Cname, Cid, Contectperson, Cpph, Dcdate;
        public InvoiceRecieve()
        {
            InitializeComponent();
        }

        private void InvoiceRecieve_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select GDCID from DChalan where  Status='Open';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GDCID"]);
            }
            mc.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new OleDbCommand("select * from DChalan where GDCID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SOID = dr["BaseDocument"].ToString();
            }
            // GRN ID
            textBox3.Text = "INV-" + comboBox1.Text;
            // Get Data from SO total Ammount
            cmd = new OleDbCommand("Select * from SO where SOID = '" + SOID.ToString() + "' ", mc.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr["TotalAmount"].ToString();
                Cid = dr["CID"].ToString();
                Dcdate = dr["DCDate"].ToString();
                Cname = dr["CName"].ToString();
                Contectperson = dr["CContectPerson"].ToString();
                Cpph = dr["CCPPH"].ToString();


                // Add Tax on total ammount
                int ammount = Convert.ToInt32(dr["TotalAmount"].ToString());
                int oneper = ammount / (100);
                int total = oneper * 17;

                textBox4.Text = (total + ammount).ToString();
                //  Vendor Info


            }
            // Fetch SModel and product Quanity

            textBox1.Clear();
            textBox2.Clear();
            cmd = new OleDbCommand("Select * from SOProducts where SOID = '" + SOID.ToString() + "'", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr["Pid"].ToString() + Environment.NewLine;
                textBox2.Text += dr["PQty"].ToString() + Environment.NewLine;

            }


            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into InvoiceR (GDCID,InvoiceID,ClientID,ClientName,ContectPerson,CPPH,DCDate,AmountPayable,Tax) values(@GDCID,@InvoiceID,@ClientID,@ClientName,@ContectPerson,@CPPH,@DCDate,@AmountPayable,@Tax)", mc.conn);
            cmd.Parameters.AddWithValue("GDCID", comboBox1.Text);
            cmd.Parameters.AddWithValue("InvoiceID", textBox3.Text);
            cmd.Parameters.AddWithValue("ClientID", Cid);
            cmd.Parameters.AddWithValue("ClientName", Cname);
            cmd.Parameters.AddWithValue("ContectPerson", Contectperson);
            cmd.Parameters.AddWithValue("CPPH", Cpph);
            cmd.Parameters.AddWithValue("DCDate", Dcdate);
            cmd.Parameters.AddWithValue("AmountPayable", textBox4.Text);
            cmd.Parameters.AddWithValue("Tax", textBox6.Text);

            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("Update DChalan Set Status='Close' where GDCID = '" + comboBox1.Text + "' ", mc.conn);
            cmd.ExecuteReader();
            MessageBox.Show("Invoice Succesfully Recieved '" + Environment.NewLine + "' Delievry Chalan status Closed.....!!");



            mc.conn.Close();
        }
    }
}
