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
    public partial class Form2 : Form
    {
        MyConnection mc;
        OleDbDataReader dr;
        OleDbCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
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
cmd = new OleDbCommand("Insert into Customer(CID,Cname,CAddress,City,PH1,PH2,CEmail,ContectPerson,CPPH,CreditLimit,CGroup,CStatus) values(@CID,@Cname,@CAddress,@City,@PH1,@PH2,@CEmail,@ContectPerson,@CPPH,@CreditLimit,@CGroup,@CStatus);", mc.conn);
cmd.Parameters.AddWithValue("@CID", textBox1.Text);
cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
cmd.Parameters.AddWithValue("@CAddress", textBox4.Text);
cmd.Parameters.AddWithValue("@City", textBox3.Text);
cmd.Parameters.AddWithValue("@PH1", textBox7.Text);
cmd.Parameters.AddWithValue("@PH2", textBox8.Text);
cmd.Parameters.AddWithValue("@CEmail", textBox5.Text);
cmd.Parameters.AddWithValue("@ContectPerson", textBox10.Text);
cmd.Parameters.AddWithValue("@CPPH", textBox11.Text);
cmd.Parameters.AddWithValue("@CreditLimit", textBox9.Text);
cmd.Parameters.AddWithValue("@CGroup", comboBox1.Text);
cmd.Parameters.AddWithValue("@CStatus", textBox6.Text);
cmd.ExecuteNonQuery();
mc.conn.Close();
MessageBox.Show("Record has been inserted");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            mc.conn.Open();
            cmd = new OleDbCommand("select count(CID) from Customer where CGroup='" + comboBox1.Text + "'", mc.conn);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
