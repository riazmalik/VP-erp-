using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
         
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string un = textBox1.Text;
            string pw = textBox2.Text;
            if
                (un == "riaz" && pw == "1234")
            {

                ERP erp = new ERP();
                this.Hide();
                erp.Show();

            }
            else
            {
                MessageBox.Show("Invalid user ID or Password");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        }
    
}
