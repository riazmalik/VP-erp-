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
    public partial class Invoice : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        string POID,Vname,Vid,Contectperson,Cpph,Ddate;
       

        public Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            mc = new MyConnection();
            mc.conn.Open();
            cmd = new OleDbCommand("select GRNID from GRN where  Status='Open';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GRNID"]);
            }
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            cmd = new OleDbCommand("select * from GRN where GRNID='" + comboBox1.SelectedItem + "';", mc.conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                POID = dr["BaseDocument"].ToString();
            }
            // GRN ID
            textBox3.Text = "INV-" + comboBox1.Text;
            // Get Data from PO total Ammount
            cmd = new OleDbCommand("Select * from PO where POID = '"+POID.ToString()+"' ",mc.conn);
           dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr["TotalAmount"].ToString();
                Vid = dr["VID"].ToString();
                Ddate = dr["DDate"].ToString();
                Vname = dr["VName"].ToString();
                Contectperson = dr["VContectPerson"].ToString();
                Cpph = dr["VCPPH"].ToString();


                // Add Tax on total ammount
               int ammount = Convert.ToInt32(dr["TotalAmount"].ToString());
               int oneper = ammount / (100);
                int total = oneper * 17;

                textBox4.Text = (total + ammount).ToString();
              //  Vendor Info
               
                
            }
            // Fetch PModel and product Quanity

            textBox1.Clear();
            textBox2.Clear();
            cmd = new OleDbCommand("Select * from POProducts where POID = '"+POID.ToString() + "'", mc.conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                textBox1.Text += dr["Pid"].ToString()+Environment.NewLine;
                textBox2.Text += dr["PQty"].ToString() + Environment.NewLine;

            }


            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
             OleDbCommand cmd = new OleDbCommand("insert into InvoiceP (GRNID,InvoiceID,VendorID,VendorName,ContectPerson,CPPH,DDate,AmountPayable,Tax) values(@GRNID,@InvoiceID,@VendorID,@VendorName,@ContectPerson,@CPPH,@DDate,@AmountPayable,@Tax)", mc.conn);
cmd.Parameters.AddWithValue("GRNID", comboBox1.Text);
cmd.Parameters.AddWithValue("InvoiceID", textBox3.Text);
cmd.Parameters.AddWithValue("VendorID", Vid);
cmd.Parameters.AddWithValue("VendorName", Vname); 
cmd.Parameters.AddWithValue("ContectPerson",Contectperson);
cmd.Parameters.AddWithValue("CPPH", Cpph);           
cmd.Parameters.AddWithValue("DDate",Ddate);            
cmd.Parameters.AddWithValue("AmountPayable",textBox4.Text);
cmd.Parameters.AddWithValue("Tax", textBox6.Text);

cmd.ExecuteNonQuery();

 cmd = new OleDbCommand("Update GRN Set Status='Close' where GRNID = '" + comboBox1.Text + "' ", mc.conn);
 cmd.ExecuteReader();
 MessageBox.Show("Invoice Succesfully Paid '"+Environment.NewLine +"' GRN status Closed.....!!");
                
             

mc.conn.Close();
        }
    }
}
